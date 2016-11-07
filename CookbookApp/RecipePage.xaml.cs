using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CookbookApp
{
    /// <summary>
    /// Interaction logic for RecipePage.xaml
    /// </summary>
    public partial class RecipePage : Page
    {
        public RecipePage(Recipe recipe)
        {
            InitializeComponent();
            nameLabel.Content = recipe.Name;
            picture.Source = recipe.Picture;
            preparationTextBlock.Text = recipe.Preparation;
            foreach (IngredientDto ingredient in recipe.Ingredients)
                ingredientsTextBlock.Text += "- " + ingredient.IngredientName + " (" + ingredient.Amount + " " +
                    ingredient.Unit + ")\n";
            amountLabel.Content = "Porcji: " + recipe.Amount;
            skillLabel.Content = "Poziom trudności: " + recipe.SkillLevel;
            timeLabel.Content = "Czas przygotowania: " + recipe.PreparationTime;

        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }
    }
}
