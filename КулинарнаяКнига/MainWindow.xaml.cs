using System.Windows;
using КулинарнаяКнига.AppData;
using КулинарнаяКнига.Pages;

namespace КулинарнаяКнига
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AppConnect.model0db = new CulinaryBookEntities();
            AppFrame.framemain = Mainframe;
            Mainframe.Navigate(new PageAutoriz());
        }
    }
}
