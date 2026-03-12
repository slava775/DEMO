using Demo.Classes;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Demo.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        private void BtnReg_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var userExists = App.Context.Users.Any(p => p.Login == TbLogin.Text);

            if (!userExists)
            {
                MessageBox.Show("Пользователь с таким логином не найден:(", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var currentUser = App.Context.Users.FirstOrDefault(p => p.Login == TbLogin.Text && p.Password == TbPassword.Password);

            if (currentUser == null)
            {
                MessageBox.Show("Неверный пароль", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            App.CurrentUser = currentUser;
            App.CurrentUser.Password = TbPassword.Password;

            if (currentUser.IdRole == UserRole.Admin || currentUser.IdRole == UserRole.RegularUser)
            {
                NavigationService.Navigate(new MainPage());
            }
        }

        private void Run_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new RegPage());
        }
    }
}
