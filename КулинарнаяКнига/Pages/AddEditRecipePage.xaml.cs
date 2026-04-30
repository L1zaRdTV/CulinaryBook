using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using КулинарнаяКнига.ApplicationData;
using КулинарнаяКнига.AppData;

namespace КулинарнаяКнига.Pages
{
    public partial class AddEditRecipePage : Page
    {
        private readonly Recipes _recipe;
        private List<RecipeImages> _images = new List<RecipeImages>();
        private int _currentIndex;

        public AddEditRecipePage(Recipes recipe)
        {
            InitializeComponent();

            _recipe = recipe ?? new Recipes();
            DataContext = _recipe;

            cmbCategory.ItemsSource = AppConnect.model01.Categories.OrderBy(c => c.CategoryName).ToList();
            cmbAuthor.ItemsSource = AppConnect.model01.Authors.OrderBy(a => a.AuthorName).ToList();

            if (recipe != null)
            {
                cmbCategory.SelectedItem = AppConnect.model01.Categories.FirstOrDefault(x => x.CategoryID == recipe.CategoryID);
                cmbAuthor.SelectedItem = AppConnect.model01.Authors.FirstOrDefault(x => x.AuthorID == recipe.AuthorID);
                _images = AppConnect.model01.RecipeImages.Where(x => x.RecipeID == recipe.RecipeID).ToList();
            }

            LoadCurrentImage();
        }

        private void LoadCurrentImage()
        {
            if (_images.Count == 0)
            {
                PhotoImage.Source = null;
                recipeNamePhoto.Text = "Изображение не выбрано";
                return;
            }

            try
            {
                var imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..", _images[_currentIndex].ImagePath);
                if (!File.Exists(imagePath))
                {
                    return;
                }

                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.UriSource = new Uri(imagePath, UriKind.Absolute);
                bitmap.EndInit();
                bitmap.Freeze();

                PhotoImage.Source = bitmap;
                recipeNamePhoto.Text = Path.GetFileName(imagePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Prev_Click(object sender, RoutedEventArgs e)
        {
            if (_images.Count == 0)
            {
                return;
            }

            _currentIndex = (_currentIndex - 1 + _images.Count) % _images.Count;
            LoadCurrentImage();
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (_images.Count == 0)
            {
                return;
            }

            _currentIndex = (_currentIndex + 1) % _images.Count;
            LoadCurrentImage();
        }

        private void Upload_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() != true)
            {
                return;
            }

            var imageDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..", "Images");
            Directory.CreateDirectory(imageDirectory);

            var fileName = Path.GetFileName(dialog.FileName);
            var destination = Path.Combine(imageDirectory, fileName);
            File.Copy(dialog.FileName, destination, true);

            _images.Add(new RecipeImages
            {
                RecipeID = _recipe.RecipeID,
                ImagePath = $"Images\\{fileName}"
            });

            _currentIndex = _images.Count - 1;
            LoadCurrentImage();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_recipe.RecipeName))
            {
                MessageBox.Show("Название обязательно");
                return;
            }

            if (cmbCategory.SelectedItem is Categories category)
            {
                _recipe.CategoryID = category.CategoryID;
            }

            if (cmbAuthor.SelectedItem is Authors author)
            {
                _recipe.AuthorID = author.AuthorID;
            }

            try
            {
                if (_recipe.RecipeID == 0)
                {
                    AppConnect.model01.Recipes.Add(_recipe);
                }

                AppConnect.model01.SaveChanges();

                foreach (var image in _images.Where(x => x.ImageID == 0))
                {
                    image.RecipeID = _recipe.RecipeID;
                    AppConnect.model01.RecipeImages.Add(image);
                }

                AppConnect.model01.SaveChanges();
                NavigationService?.Navigate(new RecipesPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Steps_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new CookingStepsPage(_recipe));
        }
    }
}
