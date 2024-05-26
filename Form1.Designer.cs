
namespace MarsaTool
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.openExcel = new System.Windows.Forms.OpenFileDialog();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.bProcess = new System.Windows.Forms.Button();
			this.tbFilePath = new System.Windows.Forms.TextBox();
			this.bOpenFile = new System.Windows.Forms.Button();
			this.tbSeparators = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.tbChanelName = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.nWriteFrom = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.nReadTo = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.nReadFrom = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.bProcessCampaign = new System.Windows.Forms.Button();
			this.tbCampaignFile = new System.Windows.Forms.TextBox();
			this.bChooseCampaign = new System.Windows.Forms.Button();
			this.nCampaignReadTo = new System.Windows.Forms.NumericUpDown();
			this.label9 = new System.Windows.Forms.Label();
			this.nCampaignReadFrom = new System.Windows.Forms.NumericUpDown();
			this.label10 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nWriteFrom)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nReadTo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nReadFrom)).BeginInit();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nCampaignReadTo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nCampaignReadFrom)).BeginInit();
			this.SuspendLayout();
			// 
			// openExcel
			// 
			this.openExcel.FileName = "openFileDialog1";
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.Color.DarkGray;
			this.groupBox1.Controls.Add(this.bProcess);
			this.groupBox1.Controls.Add(this.tbFilePath);
			this.groupBox1.Controls.Add(this.bOpenFile);
			this.groupBox1.Controls.Add(this.tbSeparators);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.tbChanelName);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.nWriteFrom);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.nReadTo);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.nReadFrom);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(492, 136);
			this.groupBox1.TabIndex = 14;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Расписание";
			// 
			// bProcess
			// 
			this.bProcess.Location = new System.Drawing.Point(394, 99);
			this.bProcess.Name = "bProcess";
			this.bProcess.Size = new System.Drawing.Size(81, 23);
			this.bProcess.TabIndex = 8;
			this.bProcess.Text = "Обработать";
			this.bProcess.UseVisualStyleBackColor = true;
			this.bProcess.Click += new System.EventHandler(this.bProcess_Click);
			// 
			// tbFilePath
			// 
			this.tbFilePath.Location = new System.Drawing.Point(120, 99);
			this.tbFilePath.Name = "tbFilePath";
			this.tbFilePath.ReadOnly = true;
			this.tbFilePath.Size = new System.Drawing.Size(264, 20);
			this.tbFilePath.TabIndex = 7;
			// 
			// bOpenFile
			// 
			this.bOpenFile.Location = new System.Drawing.Point(20, 97);
			this.bOpenFile.Name = "bOpenFile";
			this.bOpenFile.Size = new System.Drawing.Size(93, 23);
			this.bOpenFile.TabIndex = 6;
			this.bOpenFile.Text = "Выбрать файл";
			this.bOpenFile.UseVisualStyleBackColor = true;
			this.bOpenFile.Click += new System.EventHandler(this.bOpenFile_Click);
			// 
			// tbSeparators
			// 
			this.tbSeparators.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tbSeparators.Location = new System.Drawing.Point(390, 23);
			this.tbSeparators.Name = "tbSeparators";
			this.tbSeparators.Size = new System.Drawing.Size(85, 29);
			this.tbSeparators.TabIndex = 4;
			this.tbSeparators.Text = "/,.\\";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(311, 31);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(73, 13);
			this.label5.TabIndex = 29;
			this.label5.Text = "Разделители";
			// 
			// tbChanelName
			// 
			this.tbChanelName.Location = new System.Drawing.Point(266, 58);
			this.tbChanelName.Name = "tbChanelName";
			this.tbChanelName.Size = new System.Drawing.Size(209, 20);
			this.tbChanelName.TabIndex = 5;
			this.tbChanelName.Text = "Rate_Card";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(164, 61);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(96, 13);
			this.label4.TabIndex = 28;
			this.label4.Text = "Название канала";
			// 
			// nWriteFrom
			// 
			this.nWriteFrom.Location = new System.Drawing.Point(248, 29);
			this.nWriteFrom.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nWriteFrom.Name = "nWriteFrom";
			this.nWriteFrom.Size = new System.Drawing.Size(44, 20);
			this.nWriteFrom.TabIndex = 3;
			this.nWriteFrom.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(164, 31);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(78, 13);
			this.label3.TabIndex = 27;
			this.label3.Text = "Записывать с";
			// 
			// nReadTo
			// 
			this.nReadTo.Location = new System.Drawing.Point(81, 59);
			this.nReadTo.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.nReadTo.Name = "nReadTo";
			this.nReadTo.Size = new System.Drawing.Size(44, 20);
			this.nReadTo.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(17, 61);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(58, 13);
			this.label2.TabIndex = 26;
			this.label2.Text = "Читать по";
			// 
			// nReadFrom
			// 
			this.nReadFrom.Location = new System.Drawing.Point(81, 29);
			this.nReadFrom.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.nReadFrom.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nReadFrom.Name = "nReadFrom";
			this.nReadFrom.Size = new System.Drawing.Size(44, 20);
			this.nReadFrom.TabIndex = 1;
			this.nReadFrom.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(17, 31);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(52, 13);
			this.label1.TabIndex = 25;
			this.label1.Text = "Читать с";
			// 
			// groupBox2
			// 
			this.groupBox2.BackColor = System.Drawing.Color.DarkGray;
			this.groupBox2.Controls.Add(this.bProcessCampaign);
			this.groupBox2.Controls.Add(this.tbCampaignFile);
			this.groupBox2.Controls.Add(this.bChooseCampaign);
			this.groupBox2.Controls.Add(this.nCampaignReadTo);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.nCampaignReadFrom);
			this.groupBox2.Controls.Add(this.label10);
			this.groupBox2.Location = new System.Drawing.Point(12, 185);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(492, 136);
			this.groupBox2.TabIndex = 30;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Проверки";
			// 
			// bProcessCampaign
			// 
			this.bProcessCampaign.Location = new System.Drawing.Point(394, 92);
			this.bProcessCampaign.Name = "bProcessCampaign";
			this.bProcessCampaign.Size = new System.Drawing.Size(81, 23);
			this.bProcessCampaign.TabIndex = 13;
			this.bProcessCampaign.Text = "Проверить";
			this.bProcessCampaign.UseVisualStyleBackColor = true;
			this.bProcessCampaign.Click += new System.EventHandler(this.bProcessCampaign_Click);
			// 
			// tbCampaignFile
			// 
			this.tbCampaignFile.Location = new System.Drawing.Point(120, 92);
			this.tbCampaignFile.Name = "tbCampaignFile";
			this.tbCampaignFile.ReadOnly = true;
			this.tbCampaignFile.Size = new System.Drawing.Size(264, 20);
			this.tbCampaignFile.TabIndex = 12;
			// 
			// bChooseCampaign
			// 
			this.bChooseCampaign.Location = new System.Drawing.Point(20, 90);
			this.bChooseCampaign.Name = "bChooseCampaign";
			this.bChooseCampaign.Size = new System.Drawing.Size(93, 23);
			this.bChooseCampaign.TabIndex = 11;
			this.bChooseCampaign.Text = "Выбрать файл";
			this.bChooseCampaign.UseVisualStyleBackColor = true;
			this.bChooseCampaign.Click += new System.EventHandler(this.bChooseCampaign_Click);
			// 
			// nCampaignReadTo
			// 
			this.nCampaignReadTo.Location = new System.Drawing.Point(81, 52);
			this.nCampaignReadTo.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.nCampaignReadTo.Name = "nCampaignReadTo";
			this.nCampaignReadTo.Size = new System.Drawing.Size(44, 20);
			this.nCampaignReadTo.TabIndex = 10;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(17, 54);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(58, 13);
			this.label9.TabIndex = 17;
			this.label9.Text = "Читать по";
			// 
			// nCampaignReadFrom
			// 
			this.nCampaignReadFrom.Location = new System.Drawing.Point(81, 22);
			this.nCampaignReadFrom.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.nCampaignReadFrom.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nCampaignReadFrom.Name = "nCampaignReadFrom";
			this.nCampaignReadFrom.Size = new System.Drawing.Size(44, 20);
			this.nCampaignReadFrom.TabIndex = 9;
			this.nCampaignReadFrom.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(17, 24);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(52, 13);
			this.label10.TabIndex = 14;
			this.label10.Text = "Читать с";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(516, 330);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nWriteFrom)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nReadTo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nReadFrom)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nCampaignReadTo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nCampaignReadFrom)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.OpenFileDialog openExcel;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button bProcess;
		private System.Windows.Forms.TextBox tbFilePath;
		private System.Windows.Forms.Button bOpenFile;
		private System.Windows.Forms.TextBox tbSeparators;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox tbChanelName;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown nWriteFrom;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown nReadTo;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown nReadFrom;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button bProcessCampaign;
		private System.Windows.Forms.TextBox tbCampaignFile;
		private System.Windows.Forms.Button bChooseCampaign;
		private System.Windows.Forms.NumericUpDown nCampaignReadTo;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.NumericUpDown nCampaignReadFrom;
		private System.Windows.Forms.Label label10;
	}
}

