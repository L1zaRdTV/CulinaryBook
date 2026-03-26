using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using КулинарнаяКнига.AppData;

namespace КулинарнаяКнига.Pages
{
    public partial class PageReg : Page
    {
        public PageReg()
        {
            InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextName.Text)
                || string.IsNullOrWhiteSpace(TextLogin.Text)
                || string.IsNullOrWhiteSpace(TextPass.Password)
                || string.IsNullOrWhiteSpace(TextPassV.Password)
                || !Bid.SelectedDate.HasValue)
            {
                MessageBox.Show("Заполните обязательные поля.", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (TextPass.Password != TextPassV.Password)
            {
                MessageBox.Show("Пароли не совпадают.", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (AppConnect.model0db.Authors.Any(x => x.Login == TextLogin.Text.Trim()))
            {
                MessageBox.Show("Такой логин уже занят.", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var user = new Authors
            {
                AuthorName = TextName.Text.Trim(),
                Login = TextLogin.Text.Trim(),
                Password = TextPass.Password,
                Biday = Bid.SelectedDate.Value,
                Email = string.Empty,
                Phone = string.Empty,
                Stazh = 0
            };

            try
            {
                AppConnect.model0db.Authors.Add(user);
                AppConnect.model0db.SaveChanges();
                MessageBox.Show("Аккаунт создан.", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Information);
                AppFrame.framemain.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось создать пользователя: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.framemain.GoBack();
        }
    }
}
