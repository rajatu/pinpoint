using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Windows.Media;

namespace mapme
{
    public partial class Resultpage : PhoneApplicationPage
    {
        public Resultpage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            string msg = "";

            if (NavigationContext.QueryString.TryGetValue("msg", out msg))
            {
                callME(msg);
            }

            
            

        }

        private async void callME(string msg)
        {
            HttpClient client = new HttpClient();
            resultbox.Text = "result for "+msg;
            ProgressIndicator p = new ProgressIndicator();
            p.IsVisible = true;
            p.IsIndeterminate = true;
            SystemTray.SetProgressIndicator(this, p);
            HttpResponseMessage response = await client.GetAsync("https://maps.googleapis.com/maps/api/place/textsearch/json?query=" + msg + "&sensor=false&key=AIzaSyAIf6WCGqJe4XJjmdk0cMktLDQT5ZL-zvE");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

          
            p.IsIndeterminate = false;
            p.IsVisible = false;

            dynamic dynObj = JsonConvert.DeserializeObject(responseBody);
            
            
            JObject results = Newtonsoft.Json.Linq.JObject.Parse(responseBody);
            int i = 0;
               
                foreach (var result in results["results"])
                {
                    //tb.Text = result["formatted_address"] + "";
                    Button my = new Button();
                    my.Height = 200;
                    my.Width = 400;
                    my.FontFamily = new FontFamily("Segoe WP SemiLight");
                    //my.Background = new SolidColorBrush(Color.FromArgb(10, 0, 255, 0));
                    my.Foreground = new SolidColorBrush(Color.FromArgb(255,25,176,162) );

                    my.Content = i+"" + result["formatted_address"] + ""; ;
                    my.Margin = new Thickness(0, i*350, 0, 0);
                    i++;
                    my.Content += "hi";
                    ContentPanel.Children.Add(my);
                    
                }

                
            

        }
    }
}