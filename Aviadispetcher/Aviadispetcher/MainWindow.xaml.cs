﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Excel = Microsoft.Office.Interop.Excel;

namespace Aviadispetcher
{


    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Excel.Application exApp;
        Excel.Workbook exWorkbook;
        Excel.Worksheet exSheet;
        Excel.Range exRange;
        private int flightNum;
        private int flightCount;
        private bool flightAdd = false;
        public List<Flight> fList = new List<Flight>(85);
        public List<Flight> selectedCityList = new List<Flight>();
        public List<Flight> selectedCityTimeList = new List<Flight>();
        private DateTime timeFlight;
        public static int logUser;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ChangeFlightListData(int num)
        {
            if (num < 0 || num >= fList.Count)
                return;
            
            
            if (flightAdd)
            {
                flightCount = flightCount + 1;
                FlightListDG.Items.Add(fList[num]);
            }
            else
            {
                fList[num].City = cityFlightTextBox.Text;
                fList[num].Number = numFlightTextBox.Text;
                fList[num].Depature_time = timeFlightTextBox.Text;
                fList[num].Free_seats = freeSeatsTextBox.Text;
                FlightListDG.Items.RemoveAt(num);
                FlightListDG.Items.Insert(num, fList[num]);
            }
            
        }

        private void FillCityList()
        {
            if (fList.Count < 1)
                return;
            
            bool nameExist = false;
            cityList.Items.Add(fList[0].City);
            for (int i = 1; i < fList.Count; i++)
            {
                for (int j = 0; j < cityList.Items.Count; j++)
                    if (cityList.Items[j].ToString() == fList[i].City)
                    {
                        nameExist = true;
                        break;
                    }
                if (!nameExist)
                    cityList.Items.Add(fList[i].City);
                nameExist = false;
                cityList.SelectedIndex = 0;
            }
        }

        private void SaveData(List<Flight> slX, List<Flight> slXY)
        {
            if (slXY.Count > 0 || slX.Count > 0)
            {
                WordUtils writeToWord = new WordUtils();
                writeToWord.AddHeader();
                writeToWord.AddParagraphs("\n");
                if (slXY.Count == 0 && slX.Count > 0)
                {
                    writeToWord.AddParagraphs("Рейси по місту.");
                    writeToWord.AddTable(slX);
                }
                else if (slXY.Count > 0 && slX.Count == 0)
                {
                    writeToWord.AddParagraphs("Рейси по місту і часу.");
                    writeToWord.AddTable(slXY);
                }
                else if (slXY.Count > 0 && slX.Count > 0)
                {
                    writeToWord.AddParagraphs("Рейси по місту.");
                    writeToWord.AddTable(slX);
                    writeToWord.AddParagraphs("\n\n");
                    writeToWord.AddParagraphs("Рейси по місту і часу.");
                    writeToWord.AddTable(slXY);
                }

                writeToWord.Save();
                writeToWord.Close();
            }
            else
                MessageBox.Show("Немає даних для запису!", "Помилка");
        }

        private void LoadDataMenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FlightListDG.ItemsSource = null;
                FlightListDG.Items.Clear();
                fList.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + char.ConvertFromUtf32(13), 
                    "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            DBUtils.OpenDbFile(fList);
            //FlightListDG.ItemsSource = fList;
            foreach (Flight fl in fList)
                FlightListDG.Items.Add(fl);
            Width = 350;
        }

        private void InfoFlightForm_Loaded(object sender, RoutedEventArgs e)
        {
            OpenExcelDoc();
            if (logUser == 1)
            {
                mainMenu.Items.Remove(mainMenu.Items[1]);
            }
            else if (logUser == 2)
            {
                mainMenu.Items.Remove(mainMenu.Items[2]);
            }
            groupBox1.Visibility = Visibility.Hidden;
            groupBox2.Visibility = Visibility.Hidden;
            groupBox3.Visibility = Visibility.Hidden;
            Width = 310;
            Height = 290;
        }

        private void OpenExcelDoc()
        {
            try
            {
                exApp = new Excel.Application();
                string FilePath = System.Windows.Forms.Application.StartupPath;
                exWorkbook = exApp.Workbooks.Open(FilePath + "\\FlightsSchedule.xls");
                exApp.Quit();
            }
            catch (Exception ex)
            {
                if (exApp != null)
                    exApp.Quit();
                MessageBox.Show(ex.Message + "\n\r\n\r" + 
                    "Для завантаження файлу виконайте команду файл-Завантажити.", 
                    "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ReadExcelDoc()
        {
            try { exSheet = (Excel.Worksheet)exWorkbook.Worksheets.get_Item(1); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            int i = 0;
            do 
            {
                for (int j = 1; j < 5; j++)
                {
                    try { exRange = (Excel.Range)exSheet.Cells[i + 2, j]; }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                    switch (j)
                    {
                        case 1:
                            fList[i].Number = (string)exRange.Text;
                            break;
                        case 2:
                            fList[i].City = (string)exRange.Text;
                            break;
                        case 3:
                            fList[i].Depature_time = (string)exRange.Text;
                            break;
                        case 4:
                            fList[i].Free_seats = (string)exRange.Text;
                            break;
                        default:
                            break;
                    }
                }
            } while (exRange.Text != "");
            if(fList[i].Number != null)
                FlightListDG.Items.Add(fList[i]);
        }

        private void SelectXMenuItem_Click(object sender, RoutedEventArgs e)
        {
            groupBox1.Visibility = Visibility.Visible;
            Width = 500;
            Height = 290;
            cityList.Items.Clear();
            FillCityList();
            groupBox3.Visibility = Visibility.Hidden;
        }

        private void SelectXYMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (SelectXList.Items.Count > 0)
            {
                groupBox2.Visibility = Visibility.Visible;
                Width = 660;
                Height = 290;
                groupBox3.Visibility = Visibility.Hidden;
            }
            else
                MessageBox.Show("Недостатньо даних!" + char.ConvertFromUtf32(13) 
                    + "Спочатку потрібно виконати команду" + char.ConvertFromUtf32(13) 
                    + " Пошук - За містом призначення");
        }

        private void EditDataMenuItem_Click(object sender, RoutedEventArgs e)
        {
            changeDataButton.Content = "Змінити";
            groupBox1.Visibility = Visibility.Hidden;
            groupBox2.Visibility = Visibility.Hidden;
            groupBox3.Visibility = Visibility.Visible;
            Width = 350;
            Height = 510;
            flightAdd = false;
        }

        private void FlightList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (SelectXList.SelectedIndex < 0)
                return;
            Flight currFlight = new Flight();
            currFlight = fList[SelectXList.SelectedIndex];
            cityFlightTextBox.Text = currFlight.City;
            timeFlightTextBox.Text = ((currFlight.Depature_time.Length==4)?"0":"") 
                                                    + currFlight.Depature_time;
            numFlightTextBox.Text = currFlight.Number;
            freeSeatsTextBox.Text = currFlight.Free_seats;
            flightNum = SelectXList.SelectedIndex;
        }

        private void SaveDataMenuItem_Click(object sender, RoutedEventArgs e)
        {
            SaveDataButton_Click(null, null);
        }

        private void AddDataMenuItem_Click(object sender, RoutedEventArgs e)
        {
            changeDataButton.Content = "Додати";
            groupBox1.Visibility = Visibility.Hidden;
            groupBox2.Visibility = Visibility.Hidden;
            groupBox3.Visibility = Visibility.Visible;
            Width = 350;
            Height = 510;
            flightCount = SelectXList.Items.Count;
            flightAdd = true;
        }

        private void SaveDataButton_Click(object sender, RoutedEventArgs e)
        {
            if (groupBox1.Visibility == Visibility.Visible ||
            groupBox2.Visibility == Visibility.Visible)
                SaveData(selectedCityList, selectedCityTimeList);
                
            if (groupBox3.Visibility == Visibility.Visible)
                ChangeFlightListData(flightNum);
        }

        private void ChooseButton_Click(object sender, RoutedEventArgs e)
        {
            if (cityList.SelectedIndex < 0)
                return;
            selectedCityList = SelectX(Convert.ToString(cityList.Items[cityList.SelectedIndex]));
        }

        private List<Flight> SelectX(string selCity = "")
        {
            List<Flight> selectedCityList = new List<Flight>(10);
            SelectXList.Items.Clear();
            foreach (Flight fl in fList)
                if (fl.City == selCity)
                {
                    selectedCityList.Add(fl);
                    SelectXList.Items.Add(fl.Number + " " + fl.Depature_time);
                }
            return selectedCityList;
        }

        private void ChangeDataButton_Click(object sender, RoutedEventArgs e)
        {
            if (flightAdd)
            {
                fList.Add(new Flight(numFlightTextBox.Text,
                                cityFlightTextBox.Text,
                                timeFlightTextBox.Text + ":00",
                                freeSeatsTextBox.Text));
                ChangeFlightListData(fList.Count - 1);
            }
            else
            {
                int index = -1;
                foreach (Flight fl in fList)
                    if (fl.Number == numFlightTextBox.Text)
                        index = fList.IndexOf(fl);
                if (index == -1)
                    return;
                fList[index].Number = numFlightTextBox.Text;
                fList[index].City = cityFlightTextBox.Text;
                fList[index].Depature_time = timeFlightTextBox.Text + ":00";
                fList[index].Free_seats = freeSeatsTextBox.Text;
                ChangeFlightListData(index);
            }
        }

        private void ChooseYButton_Click(object sender, RoutedEventArgs e)
        {
            if (!DateTime.TryParse(sTime.Text, out timeFlight))
                return;
            selectedCityTimeList = SelectXY(timeFlight);
        }

        private List<Flight> SelectXY(DateTime timeFlight)
        {
            List<Flight> selectedCityTimeList = new List<Flight>(10);
            selectXYList.Items.Clear();
            DateTime tempTime;
            
            foreach (Flight fl in selectedCityList)
            {
                if (!DateTime.TryParse(fl.Depature_time, out tempTime))
                    return null;
                if (timeFlight.TimeOfDay <= tempTime.TimeOfDay)
                {
                    selectedCityTimeList.Add(fl);
                    selectXYList.Items.Add(fl.Depature_time + " Місць: " + fl.Free_seats);
                }
            }
            return selectedCityTimeList;
        }
    }
}
