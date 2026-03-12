using Demo.Classes;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Demo.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public RegPage()
        {
            InitializeComponent();
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            var existingUser = App.Context.Users.FirstOrDefault(p => p.Login == TbLogin.Text);
            if (existingUser != null)
            {
                MessageBox.Show("Пользователь с таким логином уже есть:(");
                return;
            }

            string password = TbPassword.Password;
            string repeatPassword = TbRepeatPassword.Password;
            int userRoles = UserRole.RegularUser;

            if (password != repeatPassword)
            {
                MessageBox.Show("Пароли не сповпадают", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string passwordError = PasswordValidator.CheckPasswordStrength(password);
            if (passwordError != null)
            {
                MessageBox.Show(passwordError, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var user = new Entityes.User
            {
                Login = TbLogin.Text,
                Name = TbName.Text,
                Surname = TbSurName.Text,
                Password = password,
                IdRole = userRoles
            };
            App.Context.Users.Add(user);
            App.Context.SaveChanges();

            NavigationService.Navigate(new AuthPage());
        }

        private void Run_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new AuthPage());
        }
    }
}
