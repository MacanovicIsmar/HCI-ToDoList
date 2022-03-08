
namespace HCI_ToDoList.Statistika
{
	partial class StatistikaForm
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
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.sqLiteCommand1 = new System.Data.SQLite.SQLiteCommand();
			this.Tip = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.Profil_La = new System.Windows.Forms.Label();
			this.Le_Glavne = new System.Windows.Forms.Label();
			this.Le_Dnevne = new System.Windows.Forms.Label();
			this.Le_Sedmicne = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
			this.SuspendLayout();
			// 
			// chart1
			// 
			this.chart1.BackColor = System.Drawing.Color.Transparent;
			this.chart1.BorderlineColor = System.Drawing.Color.Transparent;
			this.chart1.BorderSkin.BackColor = System.Drawing.Color.Transparent;
			this.chart1.BorderSkin.BorderColor = System.Drawing.Color.Transparent;
			chartArea2.AxisX.LineColor = System.Drawing.Color.Transparent;
			chartArea2.AxisX.MajorGrid.Enabled = false;
			chartArea2.AxisY.MajorGrid.Enabled = false;
			chartArea2.BackColor = System.Drawing.Color.Transparent;
			chartArea2.BorderColor = System.Drawing.Color.WhiteSmoke;
			chartArea2.BorderWidth = 0;
			chartArea2.Name = "ChartArea1";
			this.chart1.ChartAreas.Add(chartArea2);
			legend2.Enabled = false;
			legend2.Name = "Legend1";
			this.chart1.Legends.Add(legend2);
			this.chart1.Location = new System.Drawing.Point(28, 78);
			this.chart1.Name = "chart1";
			this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
			series2.BackSecondaryColor = System.Drawing.Color.Transparent;
			series2.ChartArea = "ChartArea1";
			series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			series2.LabelBackColor = System.Drawing.Color.Transparent;
			series2.LabelBorderColor = System.Drawing.Color.Transparent;
			series2.Legend = "Legend1";
			series2.Name = "Series1";
			series2.ShadowColor = System.Drawing.Color.Gray;
			this.chart1.Series.Add(series2);
			this.chart1.Size = new System.Drawing.Size(528, 338);
			this.chart1.TabIndex = 0;
			this.chart1.Text = "chart1";
			this.chart1.Click += new System.EventHandler(this.chart1_Click);
			// 
			// sqLiteCommand1
			// 
			this.sqLiteCommand1.CommandText = null;
			// 
			// Tip
			// 
			this.Tip.FormattingEnabled = true;
			this.Tip.Location = new System.Drawing.Point(203, 25);
			this.Tip.Name = "Tip";
			this.Tip.Size = new System.Drawing.Size(121, 21);
			this.Tip.TabIndex = 1;
			this.Tip.SelectedIndexChanged += new System.EventHandler(this.Tip_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label1.Location = new System.Drawing.Point(89, 49);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(379, 24);
			this.label1.TabIndex = 2;
			this.label1.Text = "Statistika uradenih obaveza u zadnjih 5 dana";
			// 
			// Profil_La
			// 
			this.Profil_La.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Profil_La.Font = new System.Drawing.Font("Microsoft Sans Serif", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Profil_La.Location = new System.Drawing.Point(42, 447);
			this.Profil_La.Name = "Profil_La";
			this.Profil_La.Size = new System.Drawing.Size(493, 39);
			this.Profil_La.TabIndex = 3;
			this.Profil_La.Text = "label2";
			// 
			// Le_Glavne
			// 
			this.Le_Glavne.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Le_Glavne.Font = new System.Drawing.Font("Microsoft Sans Serif", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Le_Glavne.Location = new System.Drawing.Point(42, 500);
			this.Le_Glavne.Name = "Le_Glavne";
			this.Le_Glavne.Size = new System.Drawing.Size(493, 130);
			this.Le_Glavne.TabIndex = 4;
			this.Le_Glavne.Text = "label2";
			// 
			// Le_Dnevne
			// 
			this.Le_Dnevne.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Le_Dnevne.Font = new System.Drawing.Font("Microsoft Sans Serif", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Le_Dnevne.Location = new System.Drawing.Point(42, 648);
			this.Le_Dnevne.Name = "Le_Dnevne";
			this.Le_Dnevne.Size = new System.Drawing.Size(493, 130);
			this.Le_Dnevne.TabIndex = 5;
			this.Le_Dnevne.Text = "label2";
			this.Le_Dnevne.Click += new System.EventHandler(this.Le_Dnevne_Click);
			// 
			// Le_Sedmicne
			// 
			this.Le_Sedmicne.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Le_Sedmicne.Font = new System.Drawing.Font("Microsoft Sans Serif", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Le_Sedmicne.Location = new System.Drawing.Point(42, 793);
			this.Le_Sedmicne.Name = "Le_Sedmicne";
			this.Le_Sedmicne.Size = new System.Drawing.Size(493, 130);
			this.Le_Sedmicne.TabIndex = 6;
			this.Le_Sedmicne.Text = "label2";
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.button1.Location = new System.Drawing.Point(496, 25);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(39, 32);
			this.button1.TabIndex = 7;
			this.button1.Text = "X";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// StatistikaForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.ClientSize = new System.Drawing.Size(581, 1044);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.Le_Sedmicne);
			this.Controls.Add(this.Le_Dnevne);
			this.Controls.Add(this.Le_Glavne);
			this.Controls.Add(this.Profil_La);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.Tip);
			this.Controls.Add(this.chart1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "StatistikaForm";
			this.Text = "Statistika";
			((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
		private System.Data.SQLite.SQLiteCommand sqLiteCommand1;
		private System.Windows.Forms.ComboBox Tip;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label Profil_La;
		private System.Windows.Forms.Label Le_Glavne;
		private System.Windows.Forms.Label Le_Dnevne;
		private System.Windows.Forms.Label Le_Sedmicne;
		private System.Windows.Forms.Button button1;
	}
}