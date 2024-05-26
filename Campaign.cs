using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace MarsaTool.Campaign
{
	internal class Campaign
    {
        Excel.Application app;
        Excel.Workbook wb;
        dynamic sheet;
        string inFile;
        List<Data> rowData;

        int readFrom;
        int readTo;

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
			try
			{
                app = new Excel.Application(); //создаём приложение Excel
                wb = app.Workbooks.Open(inFile); //открываем наш файл           
                sheet = wb.Worksheets[1]; //или так xlSht = xlWB.ActiveSheet //активный лист

                ReadData();

                AnalyzeCampaign();
                AnalyzeDescription();
                AnalyzeChannel();

                var outFile = System.IO.Path.GetDirectoryName(inFile) +
                    $"\\{DateTime.Now:yy_MM_dd_HH_mm_ss}_" + System.IO.Path.GetFileName(inFile);

                sheet.SaveAs(outFile);
            }
            catch (Exception ex)
			{
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
			finally
			{
                sheet?.Dispose();
                app?.Quit();

                if (app != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
            }
        }

        void ReadData()
        {
            int row = readFrom;
            try
            {
                rowData = new List<Data>(sheet.UsedRange.Rows.Count);

                string brand;
                string campaign;
                string model;
                string description;
                string channel;

                while (true)
                {
                    brand = sheet.Cells[row, 4].Text().Trim();

                    if (string.IsNullOrWhiteSpace(brand) || row > readTo)
                        break;

                    campaign = sheet.Cells[row, 5].Text().Trim();
                    model = sheet.Cells[row, 6].Text().Trim();
                    description = sheet.Cells[row, 7].Text().Trim();
                    channel = sheet.Cells[row, 8].Text().Trim();

                    rowData.Add(new Data(row, brand, campaign, model, description, channel));

                    row++;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка чтения в строке {row}", ex);
            }
        }

        void AnalyzeCampaign()
        {
            try
            {
                var color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);

                foreach (var row in rowData.Where(d => d.Brand + "/" + d.Model != d.Campaign).Select(d => d.Row))
                    sheet.Cells[row, 1].Interior.Color = color;
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка провеки названий!", ex);
            }
        }

        void AnalyzeDescription()
        {
            try
            {
                var color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Green);

                var descriptions = rowData.Select(d => new { d.Campaign, d.Description }).Distinct()
                    .GroupBy(d => d.Description).Where(group => group.Count() > 1)
                    .Select(group => group.Key).ToArray();
                
                foreach (var row in rowData.Where(d => descriptions.Contains(d.Description)).Select(d => d.Row))
                    sheet.Cells[row, 2].Interior.Color = color;
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка проверки роликов в разных компаниях!", ex);
            }
        }

        void AnalyzeChannel()
        {
            try
            {
                var color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Blue);

                var rows = rowData.GroupBy(d => d.Campaign)
                    .Where(group => group.GroupBy(d => d.Description).Where(g => g.Count() > 1).Any())
                    .SelectMany(g => g.GroupBy(d => d.Description).Where(s => s.Count() == 1).Select(s => s.Single().Row));

                foreach (var row in rows)
                    sheet.Cells[row, 3].Interior.Color = color;
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка проверки единичных роликов!", ex);
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
    }
}
