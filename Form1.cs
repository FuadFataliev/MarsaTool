using System;
using System.Windows.Forms;

namespace MarsaTool
{
	public partial class Form1 : Form
    {
        const string RateCard = "Rate_Card";
        public Form1()
        {
            InitializeComponent();
        }

       
        private void bOpenFile_Click(object sender, EventArgs e)
        {
            if (openExcel.ShowDialog() != DialogResult.OK)
                return;

            tbFilePath.Text = openExcel.FileName;
        }

        private void bProcess_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    if (string.IsNullOrWhiteSpace(tbChanelName.Text))
                        tbChanelName.Text = RateCard;

                    var pl = new PriceList();
                    pl.GetSettings(nReadFrom.Value, nReadTo.Value, nWriteFrom.Value, 
                        tbSeparators.Text, tbFilePath.Text.Trim(), tbChanelName.Text.Trim());

                    pl.Process();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void bProcessCampaign_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    var c = new CampaignLibre.Campaign();
                    c.GetSettings(nCampaignReadFrom.Value, nCampaignReadTo.Value,
                        tbCampaignFile.Text.Trim());

                    c.Process();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void bChooseCampaign_Click(object sender, EventArgs e)
        {
            if (openExcel.ShowDialog() != DialogResult.OK)
                return;

            tbCampaignFile.Text = openExcel.FileName;
        }
    }
}
