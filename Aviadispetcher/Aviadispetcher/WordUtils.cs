using System;
using System.Collections.Generic;
using Microsoft.Office.Interop.Word;
using F = System.Windows.Forms;


namespace Aviadispetcher
{
    class WordUtils
    {
        private Application app;
        private Document document;
        private object missing = System.Reflection.Missing.Value;

        /// <summary>
        /// Конструктор для ініціалізації.
        /// </summary>
        public WordUtils()
        {
            app = new Application();
            //app.ShowAnimation = false;
            app.Visible = false;
            document = app.Documents.Add(ref missing,
                                ref missing, ref missing, ref missing);
        }

        /// <summary>
        /// Додає заголовок файлу.
        /// </summary>
        public void AddHeader()
        {
            var pText1 = document.Paragraphs.Add();
            pText1.Range.Text = "Звіт";
            pText1.Range.Bold = 1;
            pText1.Range.Font.Size = 20;
            pText1.Format.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            pText1.Range.InsertParagraphAfter();
        }

        /// <summary>
        /// Додає абзац 
        /// </summary>
        public void AddParagraphs(String text)
        {
            var pText = document.Paragraphs.Add();
            pText.Range.Text = text;
            pText.Range.Bold = 0;
            pText.Range.Font.Size = 14;
            pText.Range.Font.Name = "Times New Roman";
            pText.Format.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
            pText.Range.InsertParagraphAfter();
        }

        /// <summary>
        /// Генерує заголовок таблиці.
        /// </summary>
        private void AddStringToColmn(Cell cell, String text)
        {
            cell.Range.Text = text;
            cell.Range.Font.Bold = 1;
            //other format properties goes here  
            cell.Range.Font.Name = "verdana";
            cell.Range.Font.Size = 14;
            //cell.Range.Font.ColorIndex = WdColorIndex.wdGray25;                              
            cell.Shading.BackgroundPatternColor = WdColor.wdColorGray25;
            //Center alignment for the Header cells  
            cell.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
        }

        /// <summary>
        /// Генерує таблицю з даними про абітурієнтів.
        /// </summary>
        public void AddTable(List<Flight> result)
        {
            Paragraph para = document.Content.Paragraphs.Add(ref missing);
            Table firstTable = document.Tables.Add(para.Range, (int)result.Count + 1, 3, ref missing, ref missing);

        String[] Coulmn = new String[] { "Номер", "Місто", "Час", "Вільні місця" };

            firstTable.Borders.Enable = 1;
            foreach (Row row in firstTable.Rows)
            {
                foreach (Cell cell in row.Cells)
                {
                    //Header row  
                    if (cell.RowIndex == 1)
                    {
                        switch (cell.ColumnIndex)
                        {
                            case 1:
                                AddStringToColmn(cell, Coulmn[0]);
                                break;
                            case 2:
                                AddStringToColmn(cell, Coulmn[1]);
                                break;
                            case 3:
                                AddStringToColmn(cell, Coulmn[2]);
                                break;
                            case 4:
                                AddStringToColmn(cell, Coulmn[3]);
                                break;
                        }

                    }
                    //Data row  
                    else
                    {
                        switch (cell.ColumnIndex)
                        {
                            case 1:
                                cell.Range.Text = result[cell.RowIndex - 2].Number;
                                break;
                            case 2:
                                cell.Range.Text = result[cell.RowIndex - 2].City;
                                break;
                            case 3:
                                cell.Range.Text = result[cell.RowIndex - 2].Depature_time;
                                break;
                            case 4:
                                cell.Range.Text = result[cell.RowIndex - 2].Free_seats;
                                break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Зберігає Word файл до обраної папки.
        /// </summary>
        public void Save()
        {
            F.SaveFileDialog dlg = new F.SaveFileDialog
            {
                FileName = "Zvit", // Default file name
                DefaultExt = ".doc", // Default file extension
                Filter = "Text documents (.doc)|*.doc" // Filter files by extension
            };
            dlg.ShowDialog();
            if (dlg.FileName != "Zvit")
            {
                document.SaveAs(@dlg.FileName);
                //F.MessageBox.Show(dlg.FileName, "Помилка");
            }
        }

        /// <summary>
        /// Закриває Word програму.
        /// </summary>
        public void Close()
        {
            document.Close(WdSaveOptions.wdDoNotSaveChanges);
            app.Quit();
        }
    }

}
