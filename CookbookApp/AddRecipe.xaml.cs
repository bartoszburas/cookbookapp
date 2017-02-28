using DataTransferObjects;
using CookbookApp.ServiceReference;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace CookbookApp
{
    /// <summary>
    /// Interaction logic for AddRecipe.xaml
    /// </summary>
    public partial class AddRecipe : Page
    {
        string imgPath;

        public AddRecipe()
        {
            InitializeComponent();

            List<IngredientDto> ingredients = new List<IngredientDto>();
            dataGrid.ItemsSource = ingredients;
        }

        private void comboBox_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> skillLevelList = new List<string>() { "Łatwe", "Średnie", "Trudne" };
            comboBox.ItemsSource = skillLevelList;
            comboBox.SelectedIndex = 0;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ImageConverter converter = new ImageConverter();

            ServiceReference.RecipeDto newRecipe = new ServiceReference.RecipeDto()
            {
                adaptee = new DataTransferObjects.RecipeDto()
                {
                    Amount = Int32.Parse(amounttb.Text),
                    Name = nametb.Text,
                    PreparationDescription = preptb.Text,
                    PreparationTime = new TimeSpan(Int32.Parse(hourstb.Text),
                        Int32.Parse(minutestb.Text), Int32.Parse(secondstb.Text)),
                    SkillLevel = comboBox.Text
                }
            };

            if (imgPath != null)
                newRecipe.adaptee.Picture = converter.ImagetoByteArray(imgPath);

            List<IngredientDto> ingredients = (List<IngredientDto>)dataGrid.ItemsSource;
            newRecipe.adaptee.Ingredients = ingredients.ToArray();
            ServiceClient client = new ServiceClient();
            client.AddRecipe(newRecipe);
            NavigationService.Navigate(new MainPage());
        }

        private void uploadImg_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                imgPath = op.FileName;
                image.Source = new BitmapImage(new Uri(imgPath));
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }
    }
}
