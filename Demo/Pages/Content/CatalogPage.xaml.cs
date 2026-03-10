using Demo.Entityes;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Demo.Pages.Content
{
    /// <summary>
    /// Логика взаимодействия для CatalogPage.xaml
    /// </summary>
    public partial class CatalogPage : Page
    {
        public CatalogPage()
        {
            InitializeComponent();

            CbClassification.SelectedIndex = 0;
            CbSortBy.SelectedIndex = 0;
            UpdateCatalog();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateCatalog();
        }

        private void TbSerch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateCatalog();
        }

        private void CbSortBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateCatalog();
        }

        private void CbClassification_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateCatalog();
        }

        public void UpdateCatalog()
        {
            if (CbSortBy == null || TbSerch == null || LvCatalog == null)
            {
                return;
            }

            var tovarList = App.Context.Tovars.ToList();

            if (CbSortBy.SelectedIndex == 0)
            {
                tovarList = tovarList.OrderBy(w => w.Price).ToList();
            }
            else if (CbSortBy.SelectedIndex == 1)
            {
                tovarList = tovarList.OrderByDescending(w => w.Price).ToList();
            }

            if (CbClassification.SelectedIndex > 0)
            {
                var selectedClassification = (CbClassification.SelectedItem as ComboBoxItem).Content.ToString();
                tovarList = tovarList.Where(w => w.Classification != null && w.Classification.NameClassifications == selectedClassification).ToList();
            }

            tovarList = tovarList.Where(w => w.TovarName.ToLower().Contains(TbSerch.Text.ToLower())).ToList();

            LvCatalog.ItemsSource = tovarList;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var currentTovar = (sender as Button).DataContext as Tovar;
            NavigationService.Navigate(new AddPage(currentTovar));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var currentTovar = (sender as Button).DataContext as Tovar;
            if (MessageBox.Show("Вы уверены что хотите удалить товар: " + $"{currentTovar.TovarName}?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                App.Context.Tovars.Remove(currentTovar);
                App.Context.SaveChanges();
                UpdateCatalog();
            }
        }
    }
}
