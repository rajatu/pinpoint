using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using mapme;

namespace PhoneApp10
{
    public partial class Page3 : PhoneApplicationPage
    {
        public Page3()
        {
            InitializeComponent();
        }

        string s1 = "memy";
        string s2 = "abc123";

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Page4.xaml", UriKind.Relative));
            if (s1 == username.Text && s2 == pwd.Password)
            {
                NavigationService.Navigate(new Uri("/Page5.xaml", UriKind.Relative));
            }
            else
            {
                pwd.Password = "";
                alert1.Visibility = Visibility.Visible;
            }
        }

        private void username_GotFocus(object sender, RoutedEventArgs e)
        {
            username.Text = "";
        }

        private void pwd_GotFocus(object sender, RoutedEventArgs e)
        {
            pwd.Password = "";
        }

        
    }
}