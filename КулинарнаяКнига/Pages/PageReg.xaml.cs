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

            try
            {
                if (AppConnect.model0db.Authors.Any(x => x.Login == TextLogin.Text.Trim()))
                {
                    MessageBox.Show("Такой логин уже занят.", "Регистрация", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(DbErrorHelper.ToUserMessage(ex), "Ошибка проверки логина", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var user = new Authors
            {
                AuthorName = TextName.Text.Trim(),
                Login = TextLogin.Text.Trim(),
                Password = TextPass.Password,
                ByDay = Bid.SelectedDate.Value,
                Email = string.Empty,
                Telefon = string.Empty,
                Stoge = 0
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
                MessageBox.Show($"Не удалось создать пользователя: {DbErrorHelper.ToUserMessage(ex)}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.framemain.GoBack();
        }
    }
}
