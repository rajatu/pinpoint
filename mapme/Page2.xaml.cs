using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace PhoneApp10
{
    public partial class Page2 : PhoneApplicationPage
    {
        public Page2()
        {
            InitializeComponent();
        }

        private void owner_GotFocus(object sender, RoutedEventArgs e)
        {
            owner.Text = "";
            

        }

        private void store_GotFocus(object sender, RoutedEventArgs e)
        {
            store.Text = "";
        }

        private void storeloc_GotFocus(object sender, RoutedEventArgs e)
        {
            storeloc.Text = "";
        }

        private void userid_GotFocus(object sender, RoutedEventArgs e)
        {
            userid.Text = "";
        }


        private void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            pwd1.Password = "";
        }

        private void PasswordBox_GotFocus_1(object sender, RoutedEventArgs e)
        {
            pwd2.Password = "";
        }

        private void finish_Click(object sender, RoutedEventArgs e)
        {
            if (pwd1.Password == pwd2.Password)
                NavigationService.Navigate(new Uri("/Page5.xaml", UriKind.Relative));
            else{
                alert.Visibility = Visibility.Visible;
                pwd1.Password = "";
                pwd2.Password = "";
            }
        
        }

        

       
        
    }
}