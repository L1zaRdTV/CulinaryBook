using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using КулинарнаяКнига.AppData;
using КулинарнаяКнига.Pages;

namespace КулинарнаяКнига.Pages
{
    public partial class PageAutoriz : Page
    {
        public PageAutoriz()
        {
            InitializeComponent();
            TextLogin.Focus(); // Автофокус
        }

        private void Button_Click(object sender, RoutedEventArgs e)  // ← "Войти"
        {
            PerformLogin();
        }

        private void Regist_Click(object sender, RoutedEventArgs e)  // ← "Regist"
        {
            AppFrame.framemain.Navigate(new PageReg());
        }

        private void PerformLogin()
        {
            try
            {
                if (!ValidateInput())
                    return;

                IsEnabled = false;
                var cursor = Mouse.OverrideCursor;
                Mouse.OverrideCursor = Cursors.Wait;

                // Синхронный запрос к БД
                var user = AppConnect.model0db.Authors
                    .FirstOrDefault(x => x.Login == TextLogin.Text
                                      && x.Password == TextPassword.Password);

                if (user == null)
                {
                    ShowError("Пользователь не найден");
                    TextLogin.Focus();
                    TextLogin.SelectAll();
                    return;
                }

                ShowSuccess($"Добро пожаловать, {user.Login}!");

                // Замена Task.Delay на простой цикл (1.5 сек)
                System.Threading.Thread.Sleep(1500);

                AppFrame.framemain.Navigate(new PageOutput());
            }
            catch (Exception ex)
            {
                ShowCriticalError(ex);
            }
            finally
            {
                IsEnabled = true;
                Mouse.OverrideCursor = null;
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(TextLogin.Text))
            {
                ShowError("Введите логин");
                TextLogin.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(TextPassword.Password))
            {
                ShowError("Введите пароль");
                TextPassword.Focus();
                return false;
            }
            return true;
        }

        #region UI Helpers
        private void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void ShowSuccess(string message)
        {
            MessageBox.Show(message, "Успешная авторизация", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ShowCriticalError(Exception ex)
        {
            MessageBox.Show($"Произошла ошибка: {ex.Message}", "Критическая ошибка",
                MessageBoxButton.OK, MessageBoxImage.Error);
        }
        #endregion
    }
}
