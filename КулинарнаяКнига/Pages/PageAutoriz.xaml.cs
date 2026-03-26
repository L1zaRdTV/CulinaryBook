using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using КулинарнаяКнига.AppData;

namespace КулинарнаяКнига.Pages
{
    public partial class PageAutoriz : Page
    {
        public PageAutoriz()
        {
            InitializeComponent();
            TextLogin.Focus();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            var login = TextLogin.Text.Trim();
            var password = TextPassword.Password;

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Введите логин и пароль.", "Вход", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            try
            {
                var user = AppConnect.model0db.Authors.FirstOrDefault(x => x.Login == login && x.Password == password);
                if (user == null)
                {
                    MessageBox.Show("Пользователь не найден.", "Вход", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                AppFrame.framemain.Navigate(new PageOutput());
            }
            catch (Exception ex)
            {
                MessageBox.Show(DbErrorHelper.ToUserMessage(ex), "Ошибка входа", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.framemain.Navigate(new PageReg());
        }
    }
}
