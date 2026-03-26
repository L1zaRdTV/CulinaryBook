using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using КулинарнаяКнига.AppData;

namespace КулинарнаяКнига.Pages
{
    public partial class AddRecipes : Page
    {
        private readonly Recipes recipes = new Recipes();

        public AddRecipes()
        {
            InitializeComponent();
            Fill();
        }

        private void Fill()
        {
            CategoryCombo.ItemsSource = AppConnect.model0db.Categories
                .OrderBy(x => x.CategoryName)
                .Select(x => x.CategoryName)
                .ToList();

            AuthorCombo.ItemsSource = AppConnect.model0db.Authors
                .OrderBy(x => x.AuthorName)
                .Select(x => x.AuthorName)
                .ToList();

            CategoryCombo.SelectedIndex = CategoryCombo.Items.Count > 0 ? 0 : -1;
            AuthorCombo.SelectedIndex = AuthorCombo.Items.Count > 0 ? 0 : -1;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(RecipeNameText.Text))
                errors.AppendLine("Добавьте название рецепта.");

            if (string.IsNullOrWhiteSpace(DescriptionText.Text))
                errors.AppendLine("Добавьте описание рецепта.");

            if (!int.TryParse(CookingTimeText.Text, out var cookingTime) || cookingTime <= 0)
                errors.AppendLine("Укажите корректное время приготовления.");

            if (CategoryCombo.SelectedItem == null)
                errors.AppendLine("Выберите категорию.");

            if (AuthorCombo.SelectedItem == null)
                errors.AppendLine("Выберите автора.");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Проверьте данные", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var category = AppConnect.model0db.Categories.FirstOrDefault(x => x.CategoryName == CategoryCombo.Text);
            var author = AppConnect.model0db.Authors.FirstOrDefault(x => x.AuthorName == AuthorCombo.Text);
            if (category == null || author == null)
            {
                MessageBox.Show("Не удалось определить категорию или автора.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            recipes.RecipeName = RecipeNameText.Text.Trim();
            recipes.Description = DescriptionText.Text.Trim();
            recipes.CookingTime = cookingTime;
            recipes.CategoryID = category.CategoryID;
            recipes.AuthorID = author.AuthorID;

            AppConnect.model0db.Recipes.Add(recipes);

            try
            {
                AppConnect.model0db.SaveChanges();
                MessageBox.Show("Рецепт сохранён.", "Готово", MessageBoxButton.OK, MessageBoxImage.Information);
                AppFrame.framemain.Navigate(new PageOutput());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ggg_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.framemain.Navigate(new PageOutput());
        }

        private void SelectImage_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "Image Files |*.jpg;*.jpeg;*.png;*.bmp;*.gif|All Files|*.*",
                Title = "Выберите изображение"
            };

            if (dialog.ShowDialog() != true)
                return;

            try
            {
                var photoName = Path.GetFileName(dialog.FileName);
                var imagesDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\.\\Images\\");

                if (!Directory.Exists(imagesDirectory))
                    Directory.CreateDirectory(imagesDirectory);

                var destinationPath = Path.Combine(imagesDirectory, photoName);
                File.Copy(dialog.FileName, destinationPath, true);

                recipes.image = photoName;
                RecipeNamePhoto.Text = photoName;
                LoadImage(destinationPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке изображения: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoadImage(string imagePath)
        {
            if (!File.Exists(imagePath))
                return;

            var bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.UriSource = new Uri(imagePath);
            bitmap.EndInit();
            RecipeImage.Source = bitmap;
        }
    }
}
