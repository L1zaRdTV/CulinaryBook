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
    /// Логика взаимодействия для PageReg.xaml
    /// </summary>
    public partial class PageReg : Page
    {
        public PageReg()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (AppConnect.model0db.Authors.Count(x => x.Login == TextLogin.Text) > 0)
                {
                    MessageBox.Show("Пользователь с таким логином уже есть!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                if(String.IsNullOrEmpty(TextLogin.Text) || String.IsNullOrEmpty(TextName.Text) || String.IsNullOrEmpty(TextPass.Password) ||
                    String.IsNullOrWhiteSpace(TextPassV.Password) || String.IsNullOrWhiteSpace(TextName.Text) || String.IsNullOrWhiteSpace(TextLogin.Text) ||
                    String.IsNullOrWhiteSpace(TextMail.Text) || String.IsNullOrWhiteSpace(TextNum.Text) || String.IsNullOrWhiteSpace(Stag.Text) || !Bid.SelectedDate.HasValue)
                {
                    MessageBox.Show("Не заполнены все поля!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                if (!int.TryParse(Stag.Text, out int workExperience) || workExperience < 0)
                {
                    MessageBox.Show("Стаж должен быть целым неотрицательным числом.", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                
                Authors userobj = new Authors()
                {
                    Login = TextLogin.Text,
                    AuthorName = TextName.Text,
                    Password = TextPass.Password,
                    Biday = Bid.SelectedDate.Value,
                    Stazh = workExperience,
                    Email = TextMail.Text,
                    Phone = TextNum.Text
                };
                AppConnect.model0db.Authors.Add(userobj);
                AppConnect.model0db.SaveChanges();
                MessageBox.Show("Данные успешно добавлены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                AppData.AppFrame.framemain.GoBack();
            }
            catch
            {
                MessageBox.Show("Ошибка при добавлении данных!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AppFrame.framemain.GoBack();
        }

        private void TextPass_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (TextPass.Password != TextPassV.Password)
            {
                RegAppliy.IsEnabled = false;
                TextPassV.Background = Brushes.LightCoral;
                TextPassV.BorderBrush = Brushes.Red;
            }
            else
            {
                RegAppliy.IsEnabled = true;
                TextPassV.Background = Brushes.LightGreen;
                TextPassV.BorderBrush = Brushes.Green;
            }
        }

        private void TextPassV_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (TextPass.Password != TextPassV.Password)
            {
                RegAppliy.IsEnabled = false;
                TextPassV.Background = Brushes.LightCoral;
                TextPassV.BorderBrush = Brushes.Red;
            }
            else
            {
                RegAppliy.IsEnabled = true;
                TextPassV.Background = Brushes.LightGreen;
                TextPassV.BorderBrush = Brushes.Green;
            }
        }
    }
}
