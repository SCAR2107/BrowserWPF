using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CefSharp.Wpf;

namespace BrowserThree
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> WebPages;
        int current = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WebPages = new List<string>();
            GoHome();
        }
        void GoHome()
        {
            this.urlbox.Text = "www.google.com";
            this.Chrome.Address = "www.google.com";
            WebPages.Add("www.google.com");
        }

        void LoadWebPages(string link, bool addToList = true)
        {
            this.urlbox.Text = link;
            this.Chrome.Address = link;
            //
            MenuItem item = new MenuItem();
            item.Click += History_Click;
            item.Header = link;
            item.Width = 184;
            Menu.Items.Add(item);
            //
            if (addToList)
            {
                current++;
                WebPages.Add(link);
            }
        }

        void ToggleWebPages(string Option)
        {
            if (Option == "←" && (WebPages.Count - current - 1) != 0)
            {   
                current++;
                LoadWebPages(WebPages[current], false);   
            }
            if (Option == "→" && (WebPages.Count + current - 1) >= WebPages.Count)
            {
                current--;
                LoadWebPages(WebPages[current], false);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            ToggleWebPages(btn.Content.ToString());
        }

        private void Button_Home_Click(object sender, RoutedEventArgs e)
        {
            LoadWebPages(WebPages[0]);
        }

        private void Button_Refresh_Click(object sender, RoutedEventArgs e)
        {
            LoadWebPages(WebPages[current]);
        }

        private void History_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void urlbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                LoadWebPages(this.urlbox.Text);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (WebPages.Count != 0)
            {
                Menu.PlacementTarget = this.hbtn;
                Menu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
                Menu.HorizontalOffset = -155;
                Menu.IsOpen = true;
            }
        }

        private void Button_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
        }
    }
}
