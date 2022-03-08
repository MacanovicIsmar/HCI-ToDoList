
namespace HCI_ToDoList.Home
{
	partial class HomeForm
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
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 20;
			this.listBox1.Location = new System.Drawing.Point(221, 93);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(154, 104);
			this.listBox1.TabIndex = 9;
			this.listBox1.Click += new System.EventHandler(this.listBox1_Click);
			this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
			// 
			// button3
			// 
			this.button3.BackColor = System.Drawing.Color.Gainsboro;
			this.button3.Image = global::HCI_ToDoList.Properties.Resources.Minus_sign_40;
			this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button3.Location = new System.Drawing.Point(221, 291);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(154, 38);
			this.button3.TabIndex = 12;
			this.button3.Text = "Obrisi Profil";
			this.button3.UseVisualStyleBackColor = false;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.Color.Gainsboro;
			this.button2.Image = global::HCI_ToDoList.Properties.Resources.Hci_Edit_Icon;
			this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button2.Location = new System.Drawing.Point(221, 247);
			this.button2.Name = "button2";
			this.button2.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
			this.button2.Size = new System.Drawing.Size(154, 38);
			this.button2.TabIndex = 11;
			this.button2.Text = "Preimenuj Profil";
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.Gainsboro;
			this.button1.Image = global::HCI_ToDoList.Properties.Resources.output_onlinepngtools;
			this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button1.Location = new System.Drawing.Point(221, 203);
			this.button1.Name = "button1";
			this.button1.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
			this.button1.Size = new System.Drawing.Size(154, 38);
			this.button1.TabIndex = 10;
			this.button1.Text = "Dodaj Profil";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// HomeForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(602, 450);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.listBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "HomeForm";
			this.Text = "Home";
			this.Load += new System.EventHandler(this.HomeForm_Load);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
	}
}