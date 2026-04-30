using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using КулинарнаяКнига.AppData;
using КулинарнаяКнига.ApplicationData;

namespace КулинарнаяКнига.Pages
{
    public partial class AddRecipes : Page
    {
        private readonly Recipes _editableRecipe;
        private readonly bool _isEditMode;

        public AddRecipes(Recipes recipe = null)
        {
            InitializeComponent();
            _isEditMode = recipe != null;
            _editableRecipe = recipe ?? new Recipes();
            Fill();
            FillRecipeData();
        }

        private void Fill()
        {
            try
            {
                CategoryCombo.ItemsSource = AppConnect.model01.Categories
                    .OrderBy(x => x.CategoryName)
                    .Select(x => x.CategoryName)
                    .ToList();

                AuthorCombo.ItemsSource = AppConnect.model01.Authors
                    .OrderBy(x => x.AuthorName)
                    .Select(x => x.AuthorName)
                    .ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(DbErrorHelper.ToUserMessage(ex), "Ошибка загрузки данных", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (!_isEditMode)
            {
                CategoryCombo.SelectedIndex = CategoryCombo.Items.Count > 0 ? 0 : -1;
                AuthorCombo.SelectedIndex = AuthorCombo.Items.Count > 0 ? 0 : -1;
            }
        }

        private void FillRecipeData()
        {
            if (_isEditMode)
            {
                PageTitleText.Text = "Редактирование рецепта";
                SaveButton.Content = "Обновить";

                RecipeNameText.Text = _editableRecipe.RecipeName;
                DescriptionText.Text = _editableRecipe.Description;
                CookingTimeText.Text = _editableRecipe.CookingTime?.ToString() ?? string.Empty;

                var categoryName = _editableRecipe.Category?.CategoryName
                                   ?? AppConnect.model01.Categories
                                       .Where(x => x.CategoryID == _editableRecipe.CategoryID)
                                       .Select(x => x.CategoryName)
                                       .FirstOrDefault();

                var authorName = _editableRecipe.Author?.AuthorName
                                 ?? AppConnect.model01.Authors
                                     .Where(x => x.AuthorID == _editableRecipe.AuthorID)
                                     .Select(x => x.AuthorName)
                                     .FirstOrDefault();

                CategoryCombo.SelectedItem = categoryName;
                AuthorCombo.SelectedItem = authorName;
                RecipeNamePhoto.Text = _editableRecipe.image;

                if (!string.IsNullOrWhiteSpace(_editableRecipe.image))
                {
                    var imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\.\\Images\\", _editableRecipe.image);
                    LoadImage(imagePath);
                }
            }
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

            Authors author;
            Categories category;
            try
            {
                category = AppConnect.model01.Categories.FirstOrDefault(x => x.CategoryName == CategoryCombo.Text);
                author = AppConnect.model01.Authors.FirstOrDefault(x => x.AuthorName == AuthorCombo.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(DbErrorHelper.ToUserMessage(ex), "Ошибка чтения данных", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (category == null || author == null)
            {
                MessageBox.Show("Не удалось определить категорию или автора.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            _editableRecipe.RecipeName = RecipeNameText.Text.Trim();
            _editableRecipe.Description = DescriptionText.Text.Trim();
            _editableRecipe.CookingTime = cookingTime;
            _editableRecipe.CategoryID = category.CategoryID;
            _editableRecipe.AuthorID = author.AuthorID;

            if (!_isEditMode)
            {
                AppConnect.model01.Recipes.Add(_editableRecipe);
            }

            try
            {
                AppConnect.model01.SaveChanges();
                MessageBox.Show(_isEditMode ? "Рецепт обновлён." : "Рецепт сохранён.", "Готово", MessageBoxButton.OK, MessageBoxImage.Information);
                AppFrame.framemain.Navigate(new PageOutput());
            }
            catch (Exception ex)
            {
                MessageBox.Show(DbErrorHelper.ToUserMessage(ex), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
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

                _editableRecipe.image = photoName;
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
