using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Demo.Pages.Content
{
    /// <summary>
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        private Entityes.User _currentUser;
        private byte[] _mainImageDate;

        public ProfilePage()
        {
            InitializeComponent();
        }

        public ProfilePage(Entityes.User user)
        {
            InitializeComponent();

            _currentUser = user;

            TbLogin.Text = _currentUser.Login;
            TbName.Text = _currentUser.Name;
            TbSurname.Text = _currentUser.Surname;
            if (_currentUser.PhotoProfile != null )
            {
                ImageService.Source = (ImageSource)new ImageSourceConverter().ConvertFrom( _currentUser.PhotoProfile );
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (_currentUser == null)
            {
                var user = new Entityes.User
                {
                    Name = TbName.Text,
                    Surname = TbSurname.Text,
                    Login = TbLogin.Text,
                    PhotoProfile = _mainImageDate   
                };

                App.Context.Users.Add(user);
                App.Context.SaveChanges();

                MessageBox.Show("Профиль успешно отредактирован!");
            }
            else
            {
                _currentUser.Name = TbName.Text;
                _currentUser.Surname = TbSurname.Text;
                _currentUser.Login = TbLogin.Text;
                if ( _mainImageDate != null )
                {
                    _currentUser.PhotoProfile = _mainImageDate;
                }

                App.Context.SaveChanges();
                MessageBox.Show("Профиль успешно отредактирован!");
            }
        }

        private void BtnEnitPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images | *.png; *.jpg; *.jpeg";
            if (ofd.ShowDialog() == true)
            {
                _mainImageDate = File.ReadAllBytes(ofd.FileName);
                ImageService.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(_mainImageDate);
            }
        }
    }
}
