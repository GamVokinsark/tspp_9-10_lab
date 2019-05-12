using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Windows;

namespace Aviadispetcher
{
    class DBUtils
    {
        public static void OpenDbFile(List<Flight> fList)
        {
            try
            {
                //рядок з'єднання з БД
                string connStr = "Server=37.46.247.230;port=3306;Database=aviadispetcher;User Id=root;password=xrxrxrxrxrxrxrxrxrxr;";
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
                    fList.Add(new Flight((string)reader["number"], (string)reader["city"], ((TimeSpan)reader["depature_time"]).ToString(),
                                ((int)reader["free_seats"]).ToString()));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show((ex.Message + char.ConvertFromUtf32(13)
                        + char.ConvertFromUtf32(13) + "Для завантаження файлу " +
                        "виконайте команду Файл-Завантажити"), "Помилка",
                        MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
       
    }
}
