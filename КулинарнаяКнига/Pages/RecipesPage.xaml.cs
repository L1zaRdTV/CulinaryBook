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
            cmbCategory.Items.Clear();
            cmbCategory.Items.Add("Все категории");

            foreach (var category in AppConnect.model01.Categories.OrderBy(c => c.CategoryName).ToList())
            {
                cmbCategory.Items.Add(category.CategoryName);
            }

            cmbCategory.SelectedIndex = 0;
            cmbSort.ItemsSource = new[]
            {
                "Без сортировки",
                "По возрастанию времени",
                "По убыванию времени"
            };
            cmbSort.SelectedIndex = 0;

            ApplyFilters();
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
                query = query.Where(r =>
                    (r.RecipeName ?? string.Empty).ToLower().Contains(searchText) ||
                    (r.Description ?? string.Empty).ToLower().Contains(searchText) ||
                    (r.Category?.CategoryName ?? string.Empty).ToLower().Contains(searchText));
            }

            if (cmbSort.SelectedIndex == 1)
            {
                query = query.OrderBy(r => r.CookingTime);
            }
            else if (cmbSort.SelectedIndex == 2)
            {
                query = query.OrderByDescending(r => r.CookingTime);
            }

            return query.ToArray();
        }

        private void ApplyFilters()
        {
            var recipes = GetFilteredRecipes();
            lvRecipes.ItemsSource = recipes;
            icRecipes.ItemsSource = recipes;
            tbCount.Text = $"Найдено: {recipes.Length}";
        }

        private void FilterChanged(object sender, RoutedEventArgs e) => ApplyFilters();

        private void ShowList_Click(object sender, RoutedEventArgs e)
        {
            lvRecipes.Visibility = Visibility.Visible;
            icRecipes.Visibility = Visibility.Collapsed;
        }

        private void ShowTiles_Click(object sender, RoutedEventArgs e)
        {
            lvRecipes.Visibility = Visibility.Collapsed;
            icRecipes.Visibility = Visibility.Visible;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new AddEditRecipePage(null));
        }

        private void Fav_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new FavoritesPage());
        }

        private void lvRecipes_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lvRecipes.SelectedItem is Recipes recipe)
            {
                NavigationService?.Navigate(new AddEditRecipePage(recipe));
            }
        }
    }
}
