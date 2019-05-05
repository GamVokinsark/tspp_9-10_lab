using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;
//using System.Windows.Forms;
using System.Windows;
//...

namespace Aviadispetcher
{
    class DBUtils
    {

        public static void OpenDbFile(List<Flight> fList)
        {
            try
            {
                //рядок з'єднання з БД
                string connStr = "Server = localhost; Database = aviadispetcher; Uid = root; Pwd = ;";
                MySqlConnection conn = new MySqlConnection(connStr);
                MySqlCommand command = new MySqlCommand();
                //запис вибору даних із БД
                string commandString = "SELECT * FROM rozklad;";
                command.CommandText = commandString;
                command.Connection = conn;
                //читання відповіді сервера
                MySqlDataReader reader;
                command.Connection.Open();
                reader = command.ExecuteReader();
                //запис зчитаних даних у масив та список для виведення на екран
                int i = 0;
                while (reader.Read())
                {
                    //формувати запис про рейс, зчитаного із БД
                    fList.Add(new Flight((string)reader["Number"], (string)reader["City"], (string)reader["DepatureTime"],
                                (string)reader["FreeSeats"]));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show((ex.Message + char.ConvertFromUtf32(13)
                        + char.ConvertFromUtf32(13) + "Для завантаження файлу" +
                        "виконайте команду Файл-Завантажити"), "Помилка",
                        MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
       
    }
}
