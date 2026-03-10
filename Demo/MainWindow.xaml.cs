using System.Windows;

namespace Demo
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new Pages.RegPage());

            Application.Current.MainWindow.MinWidth = 900;
            Application.Current.MainWindow.MinHeight = 650;
        }
    }
}
