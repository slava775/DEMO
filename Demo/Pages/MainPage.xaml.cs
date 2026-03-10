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

namespace Demo.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            ContentFrame.Navigate(new Content.CatalogPage());

            if (App.CurrentUser.IdRole == 2)
            {
                BtnAdd.Visibility = Visibility.Visible;
            }
            else
            {
                BtnAdd.Visibility = Visibility.Collapsed;
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(new Content.AddPage());
        }

        private void BtnProfil_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(new Content.ProfilePage());
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
