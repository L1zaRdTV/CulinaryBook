using System;
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
            try
            {
                AppConnect.model0db = new CulinaryBookEntities();
                AppConnect.model0db.Database.Connection.Open();
                AppConnect.model0db.Database.Connection.Close();

                AppFrame.framemain = Mainframe;
                Mainframe.Navigate(new PageAutoriz());
            }
            catch (Exception ex)
            {
                MessageBox.Show(DbErrorHelper.ToUserMessage(ex), "Ошибка подключения к БД", MessageBoxButton.OK, MessageBoxImage.Error);
                Close();
            }
        }
    }
}
