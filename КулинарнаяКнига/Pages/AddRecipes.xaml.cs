using System;
using System.Collections.Generic;
using System.IO;
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
using КулинарнаяКнига.AppData;

namespace КулинарнаяКнига.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddRecipes.xaml
    /// </summary>
    public partial class AddRecipes : Page
    {
        public Recipes recipes = new Recipes();

        public AddRecipes()
        {
            InitializeComponent();
            Fill();
        }

        private void Fill()
        {
            throw new NotImplementedException();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            if (string.IsNullOrWhiteSpace(recipes.RecipeName))
            {
                sb.Append("добавтье название!\\n");
            }
            if (sb.Length > 0)
            {
                MessageBox.Show(sb.ToString());
            }
            else
            {
                string messag = "Изменения сохарнены!";
                if (recipes.RecipeID == 0)
                {
                    recipes.CategoryID = AppData.AppConnect.model0db.Categories.FirstOrDefault(x => x.CategoryName == CategoryCombo.Text).CategoryID;
                    recipes.AuthorID = AppData.AppConnect.model0db.Authors.FirstOrDefault(x => x.AuthorName == AuthorCombo.Text).AuthorID;

                    AppConnect.model0db.Recipes.Add(recipes);
                    messag = "запись добавлена";
                }

                try
                {
                    AppConnect.model0db.SaveChanges();
                    MessageBox.Show(messag);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ggg_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.framemain.Navigate(new PageOutput());
        }

        private void zagruzimage_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.Filter = "Image Files |*.jpg;*.jpeg;*.png;*.bmp;*.gif|All Files|*.*";
            dialog.Title = "Выберите изображения";
            if (dialog.ShowDialog() == true)
            {
                try
                {
                    string photoName = System.IO.Path.GetFileName(dialog.FileName);

                    string imagesDirectory = System.IO.Path.Combine(
                        AppDomain.CurrentDomain.BaseDirectory,
                        "..\\\\.\\\\Images\\\\");

                    if (!Directory.Exists(imagesDirectory))
                    {
                        Directory.CreateDirectory(imagesDirectory);
                    }

                    string destinationPath = System.IO.Path.Combine(imagesDirectory, photoName);

                    File.Copy(dialog.FileName, destinationPath, true);

                    recipes.image = photoName;
                    RecipeNamePhoto.Text = photoName;

                    LoadImageToPictureBox(destinationPath);
                    MessageBox.Show("Изображение загруженно " + photoName,
                        "успех",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке изображения: {ex.Message}",
                        "Ошибка",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Изображение не выбрано.", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void LoadImageToPictureBox(string imagePath)
        {
            if (File.Exists(imagePath))
            {
                try
                {
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.UriSource = new Uri(imagePath);
                    bitmap.EndInit();


                    RecipeImage.Source = bitmap;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при отображении изображения: {ex.Message}");
                }

            }
        }
       

        private void SelectImage_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.Filter = "Image Files |*.jpg;*.jpeg;*.png;*.bmp;*.gif|All Files|*.*";
            dialog.Title = "Выберите изображения";
            if (dialog.ShowDialog() == true)
            {
                try
                {
                    string photoName = System.IO.Path.GetFileName(dialog.FileName);

                    string imagesDirectory = System.IO.Path.Combine(
                        AppDomain.CurrentDomain.BaseDirectory,
                        "..\\\\.\\\\Images\\\\");

                    if (!Directory.Exists(imagesDirectory))
                    {
                        Directory.CreateDirectory(imagesDirectory);
                    }

                    string destinationPath = System.IO.Path.Combine(imagesDirectory, photoName);

                    File.Copy(dialog.FileName, destinationPath, true);

                    recipes.image = photoName;
                    RecipeNamePhoto.Text = photoName;

                    LoadImageToPictureBox(destinationPath);
                    MessageBox.Show("Изображение загруженно " + photoName,
                        "успех",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке изображения: {ex.Message}",
                        "Ошибка",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Изображение не выбрано.", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    } 
}
