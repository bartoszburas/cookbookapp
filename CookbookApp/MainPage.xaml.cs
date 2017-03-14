using CookbookApp.ServiceReference;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace CookbookApp
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        ServiceClient client;

        public MainPage()
        {
            InitializeComponent();
            client = new ServiceClient();

            RecipeSimplifiedDto[] tempList = client.GetRecipeList();
            List<Recipe> recipeList = RecipeConverter.ConvertRecipeList(tempList);
            FrameworkElementFactory factory1 = new FrameworkElementFactory(typeof(Image));
            Binding b1 = new Binding("Picture") { Mode = BindingMode.TwoWay };
            factory1.SetValue(Image.SourceProperty, b1);
            factory1.SetValue(Image.HeightProperty, 50.0);
            DataTemplate cellTemplate1 = new DataTemplate() { VisualTree = factory1 };
            pictureColumn.CellTemplate = cellTemplate1;

            dataGrid.ItemsSource = recipeList;
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Recipe selected = (Recipe)dataGrid.SelectedItem;
            var recipe = client.GetRecipe(selected.IdRecipe);
            ImageConverter converter = new ImageConverter();
            NavigationService.Navigate(new RecipePage(RecipeConverter.ConvertRecipe(recipe)));
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddRecipe());
        }
    }
}
