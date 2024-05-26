using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;

namespace Schedule
{
    public class PriceList
    {
        //const string RateCard = "Rate_Card";
        string inFile;
        string channelName;
        List<Data> rawData;
        List<List<Data>> dailyData;

        int readFrom;
        int readTo;
        int writeFrom;
        char[] separators;

        public void GetSettings(decimal readFrom, decimal readTo, decimal writeFrom, string separators, string inFile, string channelName)
        {
            this.readFrom = Convert.ToInt32(readFrom);
            this.readTo = Convert.ToInt32(readTo);

            if (this.readTo == 0)
                this.readTo = Int32.MaxValue;

            this.writeFrom = Convert.ToInt32(writeFrom);

            this.separators = separators.Replace(" ", string.Empty).Trim().ToArray();

            this.inFile = inFile;
            this.channelName = channelName;
        }

        public void Process()
        {
            ReadData();
            ParseData();
            SaveData();
        }

        void ReadData()
        {
            var app = new Excel.Application(); //создаём приложение Excel
            try
            {
                var wb = app.Workbooks.Open(inFile); //открываем наш файл           
                var sheet = wb.Worksheets[1]; //или так xlSht = xlWB.ActiveSheet //активный лист

                rawData = new List<Data>(288);

                int row = readFrom;
                string days;
                string time;
                string price;
                string name;
                while (true)
                {
                    days = sheet.Cells[row, 1].Text.Trim();

                    if (string.IsNullOrWhiteSpace(days) || row > readTo)
                        break;

                    time = sheet.Cells[row, 2].Text.Trim();
                    name = sheet.Cells[row, 3].Text.Trim();
                    price = sheet.Cells[row, 4].Text.Trim();

                    rawData.Add(new Data(days, time, price, name));

                    row++;
                }
            }
            finally
            {
                app.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
            }
        }

        void ParseData()
        {
            dailyData = new List<List<Data>>(7);

            for (int i = 0; i < 7; i++)
                dailyData.Add(new List<Data>(rawData.Count));

            Data data = null;
            int line = 0;
            try
            {
                for (; line < rawData.Count; line++)
                {
                    data = rawData[line];

                    foreach (var day in data.Days.Split(separators))
                        dailyData[int.Parse(day) - 1].Add(new Data(day, data.Time, data.Price, data.Name));
                }
            }
            catch
            {
                MessageBox.Show($"Ошибка в строке {line + readFrom}: {data}", "Ошибка разбора!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

        }

        void SaveData()
        {
            bool success = false;
            string outFile = "";
            var app = new Excel.Application(); //создаём приложение Excel

            try
            {
                //var template = Path.GetDirectoryName(inFile) + "\\template.xlsx";

                var wb = app.Workbooks.Open(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\template.xlsx");
                var sheet = wb.Worksheets[1];

                int row;
                int p;
                string time;

                TimeSpan min5 = TimeSpan.FromMinutes(5);
                TimeSpan hour24 = TimeSpan.FromHours(24);
                TimeSpan from;
                TimeSpan to;

                var times = new Dictionary<string, int>(288);

                for (int i = 0; i < 7; i++)
                    foreach (var data in dailyData[i])
                    {
                        try
                        {
                            time = data.Time;
                            p = time.IndexOf('-');
                            from = TimeSpan.Parse(time.Substring(0, p).Trim());
                            to = TimeSpan.Parse(time.Substring(p + 1).Trim());

                            if (from > to)
                                to += hour24;

                            while (from < to)
                            {
                                row = (from.Hours * 60 + from.Minutes) / 5 - 24;

                                if (row < 0)
                                    row += 288;

                                row += writeFrom;

                                sheet.Cells[row, 3 + i] = data.Price;

                                from += min5;

                                row++;
                            }
                        }
                        catch
                        {
                            MessageBox.Show($"Ошибка в дне {i + 1} : {data}", "Ошибка записи!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            throw;
                        }
                    }

                outFile = Path.GetDirectoryName(inFile) + $"\\{channelName}_{DateTime.Now:yy_MM_dd_HH_mm_ss}.xlsx";
                wb.SaveAs(outFile);
                success = true;
            }
            finally
            {
                //app.Visible = true;
                app.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
            }

            if (success)
            {
                MessageBox.Show($"Расписание сохранено в файл {outFile}", "Файл сохранен", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //tbChanelName.Text = RateCard;
            }
        }
    }
    class Data
    {
        public string Days { get; set; }
        public string Time { get; set; }
        public string Price { get; set; }
        public string Name { get; set; }

        public Data(string days, string time, string price, string name)
        {
            Days = days;
            Time = time;
            Price = price;
            Name = name;
        }

        public override string ToString() => $"Дни: <{Days}>, Время: <{Time}>, Цена: <{Price}>, Название: <{Name}>.";
    }
}
