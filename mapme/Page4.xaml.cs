using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Newtonsoft.Json;
using Microsoft.WindowsAzure.MobileServices;
using mapme;
using mapme.Resources;



namespace PhoneApp10
{
    public partial class Page4 : PhoneApplicationPage
    {
        public class TodoItem
        {
            public int Id { get; set; }

            [JsonProperty(PropertyName = "text")]
            public string Text { get; set; }

            [JsonProperty(PropertyName = "complete")]
            public bool Complete { get; set; }
        }

        private MobileServiceCollection<TodoItem, TodoItem> items;

        private IMobileServiceTable<TodoItem> todoTable = App.MobileService.GetTable<TodoItem>();

        
        

        public Page4()
        {
            InitializeComponent();
        }

        private void TB_Checked(object sender, RoutedEventArgs e)
        {
            if (TB.IsChecked==true)
            {
                string str2 = "123";
                var todoItem = new TodoItem { Text = str2 };
                InsertTodoItem(todoItem);
            }
        }

        private async void InsertTodoItem(TodoItem todoItem)
        {
            // This code inserts a new TodoItem into the database. When the operation completes
            // and Mobile Services has assigned an Id, the item is added to the CollectionView
            await todoTable.InsertAsync(todoItem);
            items.Add(todoItem);
        }

        private async void RefreshTodoItems()
        {
            // This code refreshes the entries in the list view be querying the TodoItems table.
            // The query excludes completed TodoItems
            try
            {
                items = await todoTable
                    .Where(todoItem => todoItem.Complete == false)
                    .ToCollectionAsync();
            }
            catch (MobileServiceInvalidOperationException e)
            {
                MessageBox.Show(e.Message, "Error loading items", MessageBoxButton.OK);
            }

            //ListItems.ItemsSource = items;
           
        }

        private async void UpdateCheckedTodoItem(TodoItem item)
        {
            // This code takes a freshly completed TodoItem and updates the database. When the MobileService 
            // responds, the item is removed from the list 
            await todoTable.UpdateAsync(item);
            items.Remove(item);
        }

        private void ButtonRefresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshTodoItems();
        }

        /*  private void ButtonSave_Click(object sender, RoutedEventArgs e)
          {
             // var todoItem = new TodoItem { Text = TodoInput.Text };
             // InsertTodoItem(todoItem);
          }
          */
        private void CheckBoxComplete_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            TodoItem item = cb.DataContext as TodoItem;
            item.Complete = true;
            UpdateCheckedTodoItem(item);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            RefreshTodoItems();
        }

      
    }
}