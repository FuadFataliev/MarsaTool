using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Spreadsheet;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schedule.Campaign
{
    internal class Campaign
    {
        //const string RateCard = "Rate_Card";
        SLDocument sheet;
        string inFile;
        string channelName;
        List<Data> rowData;

        int readFrom;
        int readTo;
        int writeFrom;
        char[] separators;

        public void GetSettings(decimal readFrom, decimal readTo, string inFile)
        {
            this.readFrom = Convert.ToInt32(readFrom);
            this.readTo = Convert.ToInt32(readTo);

            if (this.readTo == 0)
                this.readTo = Int32.MaxValue;

            this.inFile = inFile;
        }

        public void Process()
        {
            ReadData();

            AnalyzeCampaign();
            AnalyzeDescription();
            AnalyzeChannel();

            sheet.SaveAs(System.IO.Path.GetDirectoryName(inFile) + "\\new_" + System.IO.Path.GetFileName(inFile));
        }

        void ReadData()
        {
            //var app = new Excel.Application(); //создаём приложение Excel
            sheet = new SLDocument(inFile); //создаём приложение Excel
            try
            {
                //var wb = app.Workbooks.Open(inFile); //открываем наш файл           
                //var sheet = wb.Worksheets[1]; //или так xlSht = xlWB.ActiveSheet //активный лист

                
                var stats = sheet.GetWorksheetStatistics();

                rowData = new List<Data>(stats.EndRowIndex);

                int row = readFrom;
                string brand;
                string campaign;
                string model;
                string description;
                string channel;

                while (true)
                {
                    brand = sheet.GetCellValueAsString(row, 4).Trim(); //sheet.Cells[row, 1].Text.Trim();

                    if (string.IsNullOrWhiteSpace(brand) || row > readTo)
                        break;

                    campaign = sheet.GetCellValueAsString(row, 5).Trim();
                    model = sheet.GetCellValueAsString(row, 6).Trim();
                    description = sheet.GetCellValueAsString(row, 7).Trim();
                    channel = sheet.GetCellValueAsString(row, 8).Trim();

                    rowData.Add(new Data(row, brand, campaign, model, description, channel));

                    row++;
                }
            }
            finally
            {
                //sheet.Dispose();
                //app.Quit();
                //System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
            }
        }

        void AnalyzeCampaign()
        {
            try
            {
                SLStyle style = sheet.CreateStyle();
                //style.SetPatternFill(PatternValues.Solid, )
                style.Fill.SetPattern(PatternValues.Solid, System.Drawing.Color.Red, System.Drawing.Color.Red);

                foreach (var row in rowData.Where(d => d.Brand + "/" + d.Model != d.Campaign).Select(d => d.Row))
                    //sheet.SetRowStyle(row, style);
                    //sheet.cell`
                    sheet.SetCellStyle(row, 1, style);
            }
            catch
            {
                //MessageBox.Show($"Ошибка в строке {line + readFrom}: {data}", "Ошибка разбора!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        void AnalyzeDescription()
        {
            try
            {
                SLStyle style = sheet.CreateStyle();
                style.Fill.SetPattern(PatternValues.Solid, System.Drawing.Color.Green, System.Drawing.Color.Green);

                //rowData.GroupBy(d => )

                var descriptions = rowData.Select(d => new { d.Campaign, d.Description }).Distinct()
                    .GroupBy(d => d.Description).Where(group => group.Count() > 1)
                    .Select(group => group.Key).ToArray();

                
                foreach (var row in rowData.Where(d => descriptions.Contains(d.Description)).Select(d => d.Row))
                    sheet.SetCellStyle(row, 2, style);
            }
            catch
            {
                //MessageBox.Show($"Ошибка в строке {line + readFrom}: {data}", "Ошибка разбора!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        void AnalyzeChannel()
        {
            try
            {
                SLStyle style = sheet.CreateStyle();
                style.Fill.SetPattern(PatternValues.Solid, System.Drawing.Color.Blue, System.Drawing.Color.Blue);

                //rowData.GroupBy(d => )

                var grouppedData = rowData.GroupBy(d => d.Campaign)
                    .Where(group => group.Select(d => d.Description).Distinct().Count() > 1)
                    .Where(group => group.Select(d => d.Description).GroupBy(g => g).Where(g => g.Count() == 1).Any());

                foreach (var group in grouppedData)
                    foreach (var data in group)
                    {
                        sheet.SetCellStyle(data.Row, 3, style);
                    }

/*                var descriptions = rowData.Select(d => new { d.Campaign, d.Description }).Distinct()
                    .GroupBy(d => d.Description).Where(group => group.Count() > 1)
                    .Select(group => group.Key).ToArray();d


                foreach (var row in rowData.Where(d => descriptions.Contains(d.Description)).Select(d => d.Row))
                    sheet.SetRowStyle(row, style);
*/            }
            catch
            {
                //MessageBox.Show($"Ошибка в строке {line + readFrom}: {data}", "Ошибка разбора!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
    }
    class Data
    {
        public int Row { get; set; }
        public string Brand { get; set; }
        public string Campaign { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public string Channel { get; set; }

        public Data(int row, string brand, string campaign, string model, string description, string channel)
        {
            Row = row;
            Brand = brand;
            Campaign = campaign;
            Model = model;
            Description = description;
            Channel = channel;
        }

        //public override string ToString() => $"Дни: <{Days}>, Время: <{Time}>, Цена: <{Price}>, Название: <{Name}>.";
    }
}
