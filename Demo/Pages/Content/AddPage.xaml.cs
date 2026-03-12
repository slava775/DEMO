using Microsoft.Win32;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;

namespace Demo.Pages.Content
{
    /// <summary>
    /// Логика взаимодействия для AddPage.xaml
    /// </summary>
    public partial class AddPage : Page
    {
        private Entityes.Tovar _currentTovar;
        private byte[] _mainImageData;

        public AddPage()
        {
            InitializeComponent();
            CbClassification.ItemsSource = App.Context.Classifications.Select(c => c.NameClassifications).ToList();
        }

        public AddPage(Entityes.Tovar tovar)
        {
            InitializeComponent();

            _currentTovar = tovar;

            TbNameTovar.Text = _currentTovar.TovarName;
            TbPrice.Text = _currentTovar.Price.ToString();
            TbDescription.Text = _currentTovar.Description;
            CbClassification.ItemsSource = App.Context.Classifications.Select(c => c.NameClassifications).ToList();

            if (_currentTovar.Classification != null)
            {
                CbClassification.SelectedItem = _currentTovar.Classification.NameClassifications;
            }

            if (_currentTovar.Image != null)
            {
                ImageService.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(_currentTovar.Image);
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            var selectedClassification = CbClassification.SelectedItem.ToString();
            var classification = App.Context.Classifications.FirstOrDefault(c => c.NameClassifications == selectedClassification);

            if (_currentTovar == null)
            {
                var tovar = new Entityes.Tovar
                {
                    TovarName = TbNameTovar.Text,
                    Price = decimal.Parse(TbPrice.Text),
                    Description = TbDescription.Text,
                    Image = _mainImageData,
                    Classification = classification
                };

                App.Context.Tovars.Add(tovar);
                App.Context.SaveChanges();

                MessageBox.Show("Товар успешно добавлен!");
            }
            else
            {
                _currentTovar.TovarName = TbNameTovar.Text;
                _currentTovar.Price = decimal.Parse(TbPrice.Text);
                _currentTovar.Description = TbDescription.Text;
                _currentTovar.Classification = classification;

                if (_mainImageData != null)
                {
                    _currentTovar.Image = _mainImageData;
                }

                App.Context.SaveChanges();
                MessageBox.Show("Товар успешно отредактирован!");
            }
            NavigationService.GoBack();
        }

        private void BtnSelectPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images | *.png; *.jpg; *.jpeg";
            if (ofd.ShowDialog() == true)
            {
                _mainImageData = File.ReadAllBytes(ofd.FileName);
                ImageService.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(_mainImageData);
            }
        }
    }
}