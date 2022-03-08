
namespace HCI_ToDoList
{
	partial class Main
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
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.tabPage5 = new System.Windows.Forms.TabPage();
			this.tabPage6 = new System.Windows.Forms.TabPage();
			this.Statistkabutton = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.dodajButton = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.tabControl1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Controls.Add(this.tabPage4);
			this.tabControl1.Controls.Add(this.tabPage5);
			this.tabControl1.Controls.Add(this.tabPage6);
			this.tabControl1.ItemSize = new System.Drawing.Size(103, 40);
			this.tabControl1.Location = new System.Drawing.Point(-1, 1);
			this.tabControl1.MaximumSize = new System.Drawing.Size(1000, 1000);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(629, 632);
			this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.BackColor = System.Drawing.Color.Transparent;
			this.tabPage1.CausesValidation = false;
			this.tabPage1.Cursor = System.Windows.Forms.Cursors.Default;
			this.tabPage1.Location = new System.Drawing.Point(4, 44);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(621, 584);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Home";
			this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
			// 
			// tabPage2
			// 
			this.tabPage2.Location = new System.Drawing.Point(4, 44);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(621, 584);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Glavne";
			this.tabPage2.UseVisualStyleBackColor = true;
			this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
			// 
			// tabPage3
			// 
			this.tabPage3.Location = new System.Drawing.Point(4, 44);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(621, 584);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Dnevne";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// tabPage4
			// 
			this.tabPage4.Location = new System.Drawing.Point(4, 44);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage4.Size = new System.Drawing.Size(621, 584);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "Sedmicne";
			this.tabPage4.UseVisualStyleBackColor = true;
			this.tabPage4.Click += new System.EventHandler(this.tabPage4_Click);
			// 
			// tabPage5
			// 
			this.tabPage5.Location = new System.Drawing.Point(4, 44);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage5.Size = new System.Drawing.Size(621, 584);
			this.tabPage5.TabIndex = 4;
			this.tabPage5.Text = "Dogadaji";
			this.tabPage5.UseVisualStyleBackColor = true;
			// 
			// tabPage6
			// 
			this.tabPage6.Location = new System.Drawing.Point(4, 44);
			this.tabPage6.Name = "tabPage6";
			this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage6.Size = new System.Drawing.Size(621, 584);
			this.tabPage6.TabIndex = 5;
			this.tabPage6.Text = "Podsjetnici";
			this.tabPage6.UseVisualStyleBackColor = true;
			// 
			// Statistkabutton
			// 
			this.Statistkabutton.Image = global::HCI_ToDoList.Properties.Resources.output_onlinepngtools__1_;
			this.Statistkabutton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Statistkabutton.Location = new System.Drawing.Point(315, 635);
			this.Statistkabutton.Name = "Statistkabutton";
			this.Statistkabutton.Size = new System.Drawing.Size(150, 35);
			this.Statistkabutton.TabIndex = 2;
			this.Statistkabutton.Text = "Statistika";
			this.Statistkabutton.UseVisualStyleBackColor = true;
			this.Statistkabutton.Click += new System.EventHandler(this.Statistka_Click);
			// 
			// button2
			// 
			this.button2.Image = global::HCI_ToDoList.Properties.Resources.filled_filter_24;
			this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button2.Location = new System.Drawing.Point(159, 635);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(150, 35);
			this.button2.TabIndex = 3;
			this.button2.Text = "Filtriraj";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// dodajButton
			// 
			this.dodajButton.Image = global::HCI_ToDoList.Properties.Resources.output_onlinepngtools;
			this.dodajButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.dodajButton.Location = new System.Drawing.Point(3, 635);
			this.dodajButton.Name = "dodajButton";
			this.dodajButton.Size = new System.Drawing.Size(150, 35);
			this.dodajButton.TabIndex = 2;
			this.dodajButton.Text = "Dodaj";
			this.dodajButton.UseVisualStyleBackColor = true;
			this.dodajButton.Click += new System.EventHandler(this.dodajButton_Click);
			// 
			// button1
			// 
			this.button1.Image = global::HCI_ToDoList.Properties.Resources.output_onlinepngtools__2_;
			this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button1.Location = new System.Drawing.Point(471, 635);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(150, 35);
			this.button1.TabIndex = 1;
			this.button1.Text = "Zatvori";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(624, 670);
			this.Controls.Add(this.Statistkabutton);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.dodajButton);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.tabControl1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Main";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "                                                                                 " +
    "         To-Do-List";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.tabControl1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.TabPage tabPage5;
		private System.Windows.Forms.TabPage tabPage6;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button dodajButton;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button Statistkabutton;
	}
}

