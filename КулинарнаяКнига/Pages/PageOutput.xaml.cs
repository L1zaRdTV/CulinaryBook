using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using КулинарнаяКнига.AppData;

namespace КулинарнаяКнига.Pages
{
    public partial class PageOutput : Page
    {
        public PageOutput()
        {
            InitializeComponent();
            FillFilters();
            RefreshRecipes();
        }

        private void FillFilters()
        {
            ComboFilter.Items.Clear();
            ComboSort.Items.Clear();

            ComboFilter.Items.Add("Все категории");
            try
            {
                foreach (var category in AppConnect.model0db.Categories.OrderBy(x => x.CategoryName))
                {
                    ComboFilter.Items.Add(category.CategoryName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(DbErrorHelper.ToUserMessage(ex), "Ошибка загрузки категорий", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            ComboSort.Items.Add("Без сортировки");
            ComboSort.Items.Add("Время ↑");
            ComboSort.Items.Add("Время ↓");

            ComboFilter.SelectedIndex = 0;
            ComboSort.SelectedIndex = 0;
        }

        private void RefreshRecipes()
        {
            ListProducts.ItemsSource = GetRecipes();
        }

        private Recipes[] GetRecipes()
        {
            List<Recipes> recipes;
            try
            {
                recipes = new RecipeQueryService(AppConnect.model0db)
                    .GetRecipesWithAllData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(DbErrorHelper.ToUserMessage(ex), "Ошибка загрузки рецептов", MessageBoxButton.OK, MessageBoxImage.Error);
                tbCounter.Text = "Ничего не найдено";
                return Array.Empty<Recipes>();
            }

            var searchText = TextSearch.Text?.Trim().ToLower();
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                recipes = recipes.Where(x => x.RecipeName.ToLower().Contains(searchText)).ToList();
            }

            if (ComboFilter.SelectedIndex > 0)
            {
                var selectedCategory = ComboFilter.SelectedItem as string;
                recipes = recipes.Where(x => x.Category.CategoryName == selectedCategory).ToList();
            }

            if (ComboSort.SelectedIndex == 1)
            {
                recipes = recipes.OrderBy(x => x.CookingTime).ToList();
            }
            else if (ComboSort.SelectedIndex == 2)
            {
                recipes = recipes.OrderByDescending(x => x.CookingTime).ToList();
            }

            tbCounter.Text = recipes.Count > 0 ? $"Найдено: {recipes.Count}" : "Ничего не найдено";
            return recipes.ToArray();
        }

        private void ComboFilter_SelectionChanged(object sender, SelectionChangedEventArgs e) => RefreshRecipes();
        private void ComboSort_SelectionChanged(object sender, SelectionChangedEventArgs e) => RefreshRecipes();
        private void TextSearch_TextChanged(object sender, TextChangedEventArgs e) => RefreshRecipes();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.framemain.Navigate(new AddRecipes());
        }
    }
}
