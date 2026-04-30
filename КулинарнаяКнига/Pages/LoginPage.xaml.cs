using System.Linq;using System.Windows;using System.Windows.Controls;using КулинарнаяКнига.ApplicationData;
namespace КулинарнаяКнига.Pages{public partial class LoginPage:Page{public LoginPage(){InitializeComponent();}
private void Login_Click(object s,RoutedEventArgs e){var u=AppConnect.model01.Authors.FirstOrDefault(x=>x.Login==tbLogin.Text&&x.Password==pbPassword.Password);if(u==null){MessageBox.Show("Неверные данные");return;}AppConnect.AuthorID=u.AuthorID;NavigationService?.Navigate(new RecipesPage());}
private void Register_Click(object s,RoutedEventArgs e){NavigationService?.Navigate(new RegisterPage());}}}
