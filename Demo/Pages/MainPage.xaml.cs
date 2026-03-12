using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

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
            ContentFrame.Navigate(new Content.ProfilePage(App.CurrentUser));
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
