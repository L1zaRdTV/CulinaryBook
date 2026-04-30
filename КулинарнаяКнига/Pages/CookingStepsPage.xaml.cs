using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using КулинарнаяКнига.AppData;
using КулинарнаяКнига.ApplicationData;

namespace КулинарнаяКнига.Pages
{
    public partial class CookingStepsPage : Page
    {
        private readonly Recipes _recipe;

        public CookingStepsPage(Recipes recipe)
        {
            InitializeComponent();
            _recipe = recipe;
            LoadSteps();
        }

        private void LoadSteps()
        {
            try
            {
                var steps = AppConnect.model01.CookingSteps
                    .Where(x => x.RecipeID == _recipe.RecipeID)
                    .OrderBy(x => x.StepNumber)
                    .ToList();

                listSteps.ItemsSource = steps;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки шагов: {ex.Message}");
                listSteps.ItemsSource = null;
            }
        }

        private void btnAddStep_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStep.Text))
            {
                return;
            }

            try
            {
                var maxStep = AppConnect.model01.CookingSteps
                    .Where(x => x.RecipeID == _recipe.RecipeID)
                    .Select(x => (int?)x.StepNumber)
                    .Max() ?? 0;

                var step = new CookingSteps
                {
                    RecipeID = _recipe.RecipeID,
                    StepNumber = maxStep + 1,
                    StepDescription = txtStep.Text.Trim()
                };

                AppConnect.model01.CookingSteps.Add(step);
                AppConnect.model01.SaveChanges();
                txtStep.Clear();
                LoadSteps();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка добавления шага: {ex.Message}");
            }
        }

        private void btnDeleteStep_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Удалить этот шаг?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result != MessageBoxResult.Yes)
            {
                return;
            }

            try
            {
                var button = sender as Button;
                var step = button?.DataContext as CookingSteps;
                if (step == null)
                {
                    return;
                }

                var stepToRemove = AppConnect.model01.CookingSteps.FirstOrDefault(x => x.StepID == step.StepID);
                if (stepToRemove == null)
                {
                    return;
                }

                AppConnect.model01.CookingSteps.Remove(stepToRemove);
                AppConnect.model01.SaveChanges();

                var orderedSteps = AppConnect.model01.CookingSteps
                    .Where(x => x.RecipeID == _recipe.RecipeID)
                    .OrderBy(x => x.StepNumber)
                    .ToList();

                int num = 1;
                foreach (var item in orderedSteps)
                {
                    item.StepNumber = num++;
                }

                AppConnect.model01.SaveChanges();
                LoadSteps();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка удаления шага: {ex.Message}");
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService != null && NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
            else
            {
                NavigationService?.Navigate(new RecipesPage());
            }
        }
    }
}
