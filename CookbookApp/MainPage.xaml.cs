using CookbookApp.ServiceReference;
using System;
using System.Collections.Generic;
using System.IO;
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


            System.Drawing.Image img = System.Drawing.Image.FromFile("zupa-brokulowa-z-grzankami-czosnkowymi.jpg");
            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

            RecipeDto newRecipe = new RecipeDto()
            {
                adaptee = new DataTransferObjects.RecipeDto()
                {
                    Amount = 2,
                    Name = "Zupa brokułowa z grzankami",
                    PreparationDescription = "Zawartość opakowania dokładnie rozprowadź w 500 ml zimnej wody. Postaw na ogniu i mieszaj do chwili zagotowania. Gotuj na małym ogniu przez 3 minuty, często mieszając. Dodaj śmietanę i płatki migdałowe." +
                "Olej wlej na patelnię. Opiecz czosnek, przekrój go na pół i wrzuć na patelnię.Przez chwilę podgrzewaj. W między czasie chleb pokrój w drobną kostkę. Wrzuć chleb na patelnię z olejem czosnkowym i smaż na chrupko. Zupę rozlej do bulionówek i podawaj z grzankami.",
                    PreparationTime = new TimeSpan(0, 10, 0),
                    SkillLevel = "Łatwy",
                    Picture = ms.ToArray(),
                    Ingredients = new DataTransferObjects.IngredientDto[]
                    {
                        new DataTransferObjects.IngredientDto() { Amount = 1, IngredientName = "Zupa brokułowa Jak u Mamy WINIARY", Unit = "opakowanie"},
                        new DataTransferObjects.IngredientDto() { Amount = 2, IngredientName = "śmietana 18% ", Unit = "łyżki"},
                        new DataTransferObjects.IngredientDto() { Amount = 2, IngredientName = "płatki migdałowe ", Unit = "łyżki"},
                        new DataTransferObjects.IngredientDto() { Amount = 3, IngredientName = "olej", Unit = "łyżki"},
                        new DataTransferObjects.IngredientDto() { Amount = 1, IngredientName = "czosnek ", Unit = "ząbek"},
                        new DataTransferObjects.IngredientDto() { Amount = 2, IngredientName = "chleb ciemny", Unit = "kromki"}
                    }
                }
            };

            //client.AddRecipe(newRecipe);



            RecipeSimplifiedDto[] list = client.GetRecipeList();

            ImageConverter converter = new ImageConverter();


            List<Recipe> list1 = converter.ConvertRecipeList(list);
            FrameworkElementFactory factory1 = new FrameworkElementFactory(typeof(Image));
            Binding b1 = new Binding("Picture");
            b1.Mode = BindingMode.TwoWay;
            factory1.SetValue(Image.SourceProperty, b1);
            factory1.SetValue(Image.HeightProperty, 50.0);
            DataTemplate cellTemplate1 = new DataTemplate();
            cellTemplate1.VisualTree = factory1;
            pictureColumn.CellTemplate = cellTemplate1;

            dataGrid.ItemsSource = list1;
            dataGrid.CanUserAddRows = false;
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Recipe selected = (Recipe)dataGrid.SelectedItem;
            var recipe = client.GetRecipe(selected.IdRecipe);
            ImageConverter converter = new ImageConverter();

            // this.NavigationService.Navigate(new Uri("RecipePage.xaml", UriKind.Relative));
            this.NavigationService.Navigate(new RecipePage(converter.ConvertRecipe(recipe)));
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddRecipe());

        }
    }
}
