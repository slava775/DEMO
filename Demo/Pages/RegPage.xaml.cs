using Demo.Classes;
using System.Linq;
using System.Text.RegularExpressions;
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

            string password = TbPassword.Text;
            string repeatPassword = TbRepeatPassword.Text;
            int userRoles = UserRole.RegularUser;

            if (password != repeatPassword)
            {
                MessageBox.Show("Пароли не сповпадают", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            string passwordError = CheckPasswordStrength(password);
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

        private string CheckPasswordStrength(string password)
        {
            if (password.Length < 5 || password.Length > 15)
            {
                return "Пароль должен быть от 5 до 15 символов";
            }

            if (!Regex.IsMatch(password, "[A-Z]"))
            {
                return "Пароль должен содержать хотя бы одну заглавную букву";
            }

            if (!Regex.IsMatch(password, "[a-z]"))
            {
                return "Пароль должен содержать хотя бы одну строчную букву";
            }

            if (!Regex.IsMatch(password, "[0-9]"))
            {
                return "Пароль должен содержать хотя бы одну цифру";
            }

            if (!Regex.IsMatch(password, "[!@#$%^&*()_+=\\-\\[\\]{};':\"\\\\|,.<>\\/?]"))
            {
                return "Пароль должен содержать хотя бы один спецсимвол (!@#$%^&*()_+ и т.д.)";
            }

            return null; 
        }


        private void Run_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new AuthPage());
        }
    }
}
