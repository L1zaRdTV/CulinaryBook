using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using КулинарнаяКнига.AppData;
using КулинарнаяКнига.ApplicationData;

namespace КулинарнаяКнига.Pages
{
    public partial class PageLike : Page
    {
        private List<Recipes> recipes;

        public PageLike()
        {
            InitializeComponent();
            UpdateLikeRecipes();
        }

        private void UpdateLikeRecipes()
        {
            try
            {
                var likeRecipes = AppConnect.model01.LikeRecipes
                    .Where(x => x.idAuthor == AppConnect.AuthorID)
                    .Select(x => x.idRecipes)
                    .ToList();

                recipes = AppConnect.model01.Recipes
                    .Where(x => likeRecipes.Contains(x.RecipeID))
                    .ToList();

                listProducts.ItemsSource = recipes;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке избранного: {ex.Message}");
                listProducts.ItemsSource = new List<Recipes>();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы действительно хотите удалить рецепт из избранного?",
                "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result != MessageBoxResult.Yes)
            {
                return;
            }

            try
            {
                var button = sender as Button;
                var recipe = button?.DataContext as Recipes;
                if (recipe == null)
                {
                    return;
                }

                var itemToRemove = AppConnect.model01.LikeRecipes
                    .FirstOrDefault(r => r.idRecipes == recipe.RecipeID && AppConnect.AuthorID == r.idAuthor);

                if (itemToRemove == null)
                {
                    MessageBox.Show("Рецепт уже отсутствует в избранном.");
                    return;
                }

                AppConnect.model01.LikeRecipes.Remove(itemToRemove);
                AppConnect.model01.SaveChanges();

                UpdateLikeRecipes();
                MessageBox.Show("Рецепт удален из избранного!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении из избранного: {ex.Message}");
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new RecipesPage());
        }
    }
}
