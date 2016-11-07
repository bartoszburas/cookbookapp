using CookbookApp.ServiceReference;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;


namespace CookbookApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PageChain CreatePageChain()
        {
            var result = new MainPageOption();
            var error = new ErrorPageOption();
            result.SetNext(error);
            return result;
        }

        public MainWindow()
        {
            InitializeComponent();
            _NavigationFrame.Navigate(CreatePageChain().GetPage());
        }
    }
}
