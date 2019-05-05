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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Aviadispetcher
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int flightNum;
        int flightCount;
        bool flightAdd = false;
        public List<Flight> fList = new List<Flight>(85);

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ChangeFlightListData(int num)
        {
            if (num < 0 || num >= fList.Count)
                return;
            fList[num].City = cityFlightTextBox.Text;
            fList[num].Number = numFlightTextBox.Text;
            fList[num].DepatureTime = timeFlightTextBox.Text;
            fList[num].FreeSeats = freeSeatsTextBox.Text;

            if (flightAdd)
            {
                flightCount = flightCount + 1;
                SelectXList.Items.Add(String.Format("{0,-8} {1,-12} {2,8}",
                    fList[num].Number, fList[num].City, fList[num].DepatureTime));
            }
            else
                SelectXList.Items[num] = String.Format("{0,-8} {1,-12} {2,8}",
                    fList[num].Number, fList[num].City, fList[num].DepatureTime);
        }

        private void FillCityList()
        {
            if (fList.Count < 1)
                return;
            bool nameExist = false;
            cityList.Items.Add(fList[0].City);
            for (int i = 1; i < flightCount; i++)
            {

            }
        }

        private void LoadDataMenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FlightListDG.ItemsSource = null;
                fList.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + char.ConvertFromUtf32(13), 
                    "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            DBUtils.OpenDbFile(fList);
            FlightListDG.ItemsSource = fList;
        }

        private void InfoFlightForm_Loaded(object sender, RoutedEventArgs e)
        {
            //OpenExcelDoc();
            groupBox1.Visibility = Visibility.Hidden;
            //groupBox2.Visibility = Visibility.Hidden;
            groupBox3.Visibility = Visibility.Hidden;
        }

        private void SelectXMenuItem_Click(object sender, RoutedEventArgs e)
        {
            groupBox1.Visibility = Visibility.Visible;
            Width = 380;
            Height = 290;
            FillCityList();
            groupBox3.Visibility = Visibility.Hidden;
        }

        private void SelectXYMenuItem_Click(object sender, RoutedEventArgs e)
        {
            /*if (selectedXList.Items.Count > 0)
            {
                groupBox2.Visibility.Visible;
                Width = 560;
                Height = 290;
                groupBox3.Visibility = Visibility.Hidden;
            }
            else
            {
                MessageBox.Show("Недостатньо даних!" + char.ConvertFromUtf32(13) + "Спочатку потрібно виконати команду" + char.ConvertFromUtf32(13) + " Пошук - За містом призначення");
            }*/
        }

        private void EditDataMenuItem_Click(object sender, RoutedEventArgs e)
        {
            groupBox3.Visibility = Visibility.Visible;
            Width = 220;
            Height = 380;
            flightAdd = false;
        }

        private void FlightList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (SelectXList.SelectedIndex < 0)
                return;
            Flight currFlight = new Flight();
            currFlight = fList[SelectXList.SelectedIndex];
            cityFlightTextBox.Text = currFlight.City;
            timeFlightTextBox.Text = ((currFlight.DepatureTime.Length==4)?"0":"") 
                                                    + currFlight.DepatureTime;
            numFlightTextBox.Text = currFlight.Number;
            freeSeatsTextBox.Text = currFlight.FreeSeats;
            flightNum = SelectXList.SelectedIndex;
        }

        private void SaveDataMenuItem_Click(object sender, RoutedEventArgs e)
        {
            /*if (groupBox1.Visibility == Visibility.Visible ||
            groupBox2.Visibility == Visibility.Visible)
                SaveDataButton_Click(null, null);
                */
            if (groupBox3.Visibility == Visibility.Visible)
                ; // Code to rewrite .sql file.
            
        }

        private void AddDataMenuItem_Click(object sender, RoutedEventArgs e)
        {
            groupBox3.Visibility = Visibility.Visible;
            Width = 220;
            Height = 380;
            flightCount = SelectXList.Items.Count;
            flightAdd = true;
        }

        private void SaveDataButton_Click(object sender, RoutedEventArgs e)
        {
            /*if (groupBox1.Visibility == Visibility.Visible ||
            groupBox2.Visibility == Visibility.Visible)
                WordUtils.WriteData(selectedCityList, senderlectedCityTimeList);
                */
            if (groupBox3.Visibility == Visibility.Visible)
                ChangeFlightListData(flightNum);
        }
    }
}
