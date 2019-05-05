using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Aviadispetcher
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        
        public LoginWindow()
        {
            InitializeComponent();
        }

        private int LogCheck()
        {
            if (logTextBox.Text == "Користувач" &&
                passwordTextBox.Text == "111")
                return 1;
            else if (logTextBox.Text == "Редактор" &&
                passwordTextBox.Text == "222")
                return 2;
            else
                MessageBox.Show("Неправильно введено логін або пароль! Повторіть знову.", "Помилка");
            return 0;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.logUser = LogCheck();
            if (MainWindow.logUser > 0)
            {
                MainWindow mW = new MainWindow();
                mW.Show();
                Close();
            }
        }
    }
}
