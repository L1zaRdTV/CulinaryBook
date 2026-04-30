using System.Linq;
using System.Windows;
using System.Windows.Controls;
using КулинарнаяКнига.ApplicationData;

namespace КулинарнаяКнига.Pages
{
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            var user = AppConnect.model01.Authors
                .FirstOrDefault(x => x.Login == tbLogin.Text && x.Password == pbPassword.Password);

            if (user == null)
            {
                MessageBox.Show("Неверные данные");
                return;
            }

            AppConnect.AuthorID = user.AuthorID;
            NavigationService?.Navigate(new RecipesPage());
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new RegisterPage());
        }
    }
}
