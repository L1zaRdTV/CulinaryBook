using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using КулинарнаяКнига.ApplicationData;
using КулинарнаяКнига.AppData;

namespace КулинарнаяКнига.Pages
{
    public partial class RecipesPage : Page
    {
        private readonly RecipeQueryService _recipeService;

        public RecipesPage()
        {
            InitializeComponent();
            _recipeService = new RecipeQueryService(AppConnect.model01);
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            try
            {
                cmbCategory.Items.Clear();
                cmbCategory.Items.Add("Все категории");

                foreach (var category in AppConnect.model01.Categories.OrderBy(c => c.CategoryName).ToList())
                {
                    cmbCategory.Items.Add(category.CategoryName);
                }

                cmbCategory.SelectedIndex = 0;
                cmbSort.ItemsSource = new[] { "Без сортировки", "По возрастанию времени", "По убыванию времени" };
                cmbSort.SelectedIndex = 0;
                ApplyFilters();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки рецептов: {ex.Message}");
            }
        }

        private Recipes[] GetFilteredRecipes()
        {
            var query = _recipeService.GetRecipesWithAllData().AsQueryable();
            if (cmbCategory.SelectedIndex > 0)
            {
                var selectedCategory = cmbCategory.SelectedItem?.ToString();
                query = query.Where(r => r.Category != null && r.Category.CategoryName == selectedCategory);
            }

            var searchText = tbSearch.Text?.ToLower() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                query = query.Where(r => (r.RecipeName ?? string.Empty).ToLower().Contains(searchText) ||
                                         (r.Description ?? string.Empty).ToLower().Contains(searchText) ||
                                         (r.Category?.CategoryName ?? string.Empty).ToLower().Contains(searchText));
            }

            if (cmbSort.SelectedIndex == 1) query = query.OrderBy(r => r.CookingTime);
            else if (cmbSort.SelectedIndex == 2) query = query.OrderByDescending(r => r.CookingTime);
            return query.ToArray();
        }

        private void ApplyFilters()
        {
            try
            {
                var recipes = GetFilteredRecipes();
                lvRecipes.ItemsSource = recipes;
                icRecipes.ItemsSource = recipes;
                tbCount.Text = $"Найдено: {recipes.Length}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка фильтрации: {ex.Message}");
            }
        }

        private void FilterChanged(object sender, RoutedEventArgs e) => ApplyFilters();
        private void ShowList_Click(object sender, RoutedEventArgs e) { lvRecipes.Visibility = Visibility.Visible; icRecipes.Visibility = Visibility.Collapsed; }
        private void ShowTiles_Click(object sender, RoutedEventArgs e) { lvRecipes.Visibility = Visibility.Collapsed; icRecipes.Visibility = Visibility.Visible; }
        private void Add_Click(object sender, RoutedEventArgs e) => NavigationService?.Navigate(new AddEditRecipePage(null));
        private void LikeButton_Click(object sender, RoutedEventArgs e) => NavigationService?.Navigate(new PageLike());

        private void lvRecipes_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lvRecipes.SelectedItem is Recipes recipe) NavigationService?.Navigate(new AddEditRecipePage(recipe));
        }

        private void btnLike_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var button = sender as Button;
                if (!(button?.Tag is Recipes selectedRecipe))
                {
                    return;
                }

                var existing = AppConnect.model01.LikeRecipes
                    .FirstOrDefault(x => x.idAuthor == AppConnect.AuthorID && x.idRecipes == selectedRecipe.RecipeID);

                if (existing == null)
                {
                    var like = new LikeRecipes
                    {
                        idRecipes = selectedRecipe.RecipeID,
                        idAuthor = AppConnect.AuthorID
                    };

                    AppConnect.model01.LikeRecipes.Add(like);
                    AppConnect.model01.SaveChanges();
                    MessageBox.Show("Рецепт добавлен в избранное!");
                }
                else
                {
                    MessageBox.Show("Этот рецепт уже в избранном!");
                }

                ApplyFilters();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка добавления в избранное: {ex.Message}");
            }
        }
    }
}
