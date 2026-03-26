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
using КулинарнаяКнига.AppData;

namespace КулинарнаяКнига.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageOutput.xaml
    /// </summary>
    public partial class PageOutput : Page
    {
        public PageOutput()
        {
            InitializeComponent();
            ListProducts.ItemsSource = AppConnect.model0db.Recipes.ToList();
            Fill();
        }

        public void Fill()
        {
            ComboSort.Items.Add("Время");
            ComboSort.Items.Add("По возрастанию времени приготовления");
            ComboSort.Items.Add("По убыванию времени приготовления");
            ComboSort.SelectedIndex = 0;
            ComboFilter.SelectedIndex = 0;
            var category = AppConnect.model0db.Categories;
            ComboFilter.Items.Add("Категория");
            foreach (var item in category)
            {
                ComboFilter.Items.Add(item.CategoryName);
            }
        }
        //public string CurrentPhoto
        //{
        //    get
        //    {
        //        if (String.IsNullOrEmpty(Image) || String.IsNullOrWhiteSpace(Image))
        //        {
        //            return @"/Images/empty.png";
        //        }
        //        else
        //        {
        //            return @"/Images/" + Image;
        //        }
        //    }
        //}

        Recipes[] RecipesList()
        {
            try
            {
                List<Recipes> recipes = AppConnect.model0db.Recipes.ToList();
                if (TextSearch != null)
                {
                    recipes = recipes.Where(x => x.RecipeName.ToLower().Contains(TextSearch.Text.ToLower())).ToList();
                }

                if (ComboFilter.SelectedIndex > 0)
                {
                    switch (ComboFilter.SelectedIndex)
                    {
                        case 1:
                            recipes = recipes.Where(x => x.CategoryID == 1).ToList();
                            break;
                        case 2:
                            recipes = recipes.Where(x => x.CategoryID == 2).ToList();
                            break;
                        case 3:
                            recipes = recipes.Where(x => x.CategoryID == 3).ToList();
                            break;
                        case 4:
                            recipes = recipes.Where(x => x.CategoryID == 4).ToList();
                            break;
                        case 5:
                            recipes = recipes.Where(x => x.CategoryID == 5).ToList();
                            break;
                        case 6:
                            recipes = recipes.Where(x => x.CategoryID == 6).ToList();
                            break;
                        case 7:
                            recipes = recipes.Where(x => x.CategoryID == 7).ToList();
                            break;
                        case 8:
                            recipes = recipes.Where(x => x.CategoryID == 8).ToList();
                            break;
                        case 9:
                            recipes = recipes.Where(x => x.CategoryID == 9).ToList();
                            break;
                        case 10:
                            recipes = recipes.Where(x => x.CategoryID == 10).ToList();
                            break;

                    }
                }
                if (ComboSort.SelectedIndex > 0)
                {
                    switch (ComboSort.SelectedIndex)
                    {
                        case 1:
                            recipes = recipes.OrderBy(x => x.CookingTime).ToList();
                            break;
                        case 2:
                            recipes = recipes.OrderByDescending(x => x.CookingTime).ToList();
                            break;
                    }
                }
                if (recipes.Count > 0)
                {
                    tbCounter.Text = "Найдено " + recipes.Count + " рец.";
                }
                else
                {
                    tbCounter.Text = "Не найдено";
                }
                return recipes.ToArray();
            }
            catch
            {
                MessageBox.Show("Повтори попытку позже");
                return null;
            }
        }

        private void ComboFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListProducts.ItemsSource = RecipesList();
        }

        private void ComboSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListProducts.ItemsSource = RecipesList();
        }

        private void TextSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListProducts.ItemsSource = RecipesList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.framemain.Navigate(new AddRecipes(null));
        }
    }
  
}

