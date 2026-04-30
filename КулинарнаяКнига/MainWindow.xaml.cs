using System.Windows;
using КулинарнаяКнига.ApplicationData;
using КулинарнаяКнига.Pages;

namespace КулинарнаяКнига
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AppConnect.model01 = new CulinaryBookEntities();
            AppFrame.frmMain = FrmMain;
            FrmMain.Navigate(new LoginPage());
        }
    }
}
