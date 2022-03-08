
namespace HCI_ToDoList.DodajObavezu
{
	partial class DodajEditForm
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
			this.label1 = new System.Windows.Forms.Label();
			this.ChecklboxLabel = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textboxgrupa = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textboxnaziv = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.RichtextboxDetalji = new System.Windows.Forms.RichTextBox();
			this.Nazad = new System.Windows.Forms.Button();
			this.Combobox_Vrstaobaveze = new System.Windows.Forms.ComboBox();
			this.vrstaobaveze_label = new System.Windows.Forms.Label();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.Datum = new System.Windows.Forms.Label();
			this.Arhiva = new System.Windows.Forms.Label();
			this.checboxarhiva = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.Sacuvaj = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label1.Location = new System.Drawing.Point(104, 106);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(126, 31);
			this.label1.TabIndex = 0;
			this.label1.Text = "Izvrsena:";
			// 
			// ChecklboxLabel
			// 
			this.ChecklboxLabel.BackColor = System.Drawing.Color.White;
			this.ChecklboxLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ChecklboxLabel.Location = new System.Drawing.Point(236, 106);
			this.ChecklboxLabel.Name = "ChecklboxLabel";
			this.ChecklboxLabel.Size = new System.Drawing.Size(38, 38);
			this.ChecklboxLabel.TabIndex = 3;
			this.ChecklboxLabel.Click += new System.EventHandler(this.ChecklboxLabel_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label2.Location = new System.Drawing.Point(104, 165);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(89, 31);
			this.label2.TabIndex = 4;
			this.label2.Text = "Grupa";
			// 
			// textboxgrupa
			// 
			this.textboxgrupa.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.textboxgrupa.Location = new System.Drawing.Point(110, 208);
			this.textboxgrupa.Name = "textboxgrupa";
			this.textboxgrupa.Size = new System.Drawing.Size(353, 38);
			this.textboxgrupa.TabIndex = 5;
			this.textboxgrupa.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label4.Location = new System.Drawing.Point(104, 262);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(83, 31);
			this.label4.TabIndex = 6;
			this.label4.Text = "Naziv";
			// 
			// textboxnaziv
			// 
			this.textboxnaziv.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.textboxnaziv.Location = new System.Drawing.Point(110, 307);
			this.textboxnaziv.Name = "textboxnaziv";
			this.textboxnaziv.Size = new System.Drawing.Size(353, 38);
			this.textboxnaziv.TabIndex = 7;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label5.Location = new System.Drawing.Point(104, 358);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(90, 31);
			this.label5.TabIndex = 8;
			this.label5.Text = "Detalji";
			// 
			// RichtextboxDetalji
			// 
			this.RichtextboxDetalji.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.RichtextboxDetalji.Location = new System.Drawing.Point(110, 403);
			this.RichtextboxDetalji.Name = "RichtextboxDetalji";
			this.RichtextboxDetalji.Size = new System.Drawing.Size(353, 96);
			this.RichtextboxDetalji.TabIndex = 9;
			this.RichtextboxDetalji.Text = "";
			// 
			// Nazad
			// 
			this.Nazad.Image = global::HCI_ToDoList.Properties.Resources.output_onlinepngtools__2_;
			this.Nazad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Nazad.Location = new System.Drawing.Point(343, 515);
			this.Nazad.Name = "Nazad";
			this.Nazad.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
			this.Nazad.Size = new System.Drawing.Size(120, 36);
			this.Nazad.TabIndex = 11;
			this.Nazad.Text = "Nazad";
			this.Nazad.UseVisualStyleBackColor = true;
			this.Nazad.Click += new System.EventHandler(this.Nazad_Click);
			// 
			// Combobox_Vrstaobaveze
			// 
			this.Combobox_Vrstaobaveze.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Combobox_Vrstaobaveze.FormattingEnabled = true;
			this.Combobox_Vrstaobaveze.Location = new System.Drawing.Point(110, 42);
			this.Combobox_Vrstaobaveze.Name = "Combobox_Vrstaobaveze";
			this.Combobox_Vrstaobaveze.Size = new System.Drawing.Size(164, 39);
			this.Combobox_Vrstaobaveze.TabIndex = 12;
			this.Combobox_Vrstaobaveze.SelectedIndexChanged += new System.EventHandler(this.Combobox_Vrstaobaveze_SelectedIndexChanged);
			// 
			// vrstaobaveze_label
			// 
			this.vrstaobaveze_label.AutoSize = true;
			this.vrstaobaveze_label.BackColor = System.Drawing.Color.Transparent;
			this.vrstaobaveze_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.vrstaobaveze_label.Location = new System.Drawing.Point(107, 22);
			this.vrstaobaveze_label.Name = "vrstaobaveze_label";
			this.vrstaobaveze_label.Size = new System.Drawing.Size(106, 17);
			this.vrstaobaveze_label.TabIndex = 13;
			this.vrstaobaveze_label.Text = "Vrsta Obaveze:";
			this.vrstaobaveze_label.Click += new System.EventHandler(this.label3_Click);
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.dateTimePicker1.Location = new System.Drawing.Point(313, 42);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(151, 38);
			this.dateTimePicker1.TabIndex = 14;
			this.dateTimePicker1.Value = new System.DateTime(2021, 4, 15, 0, 0, 0, 0);
			this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
			// 
			// Datum
			// 
			this.Datum.AutoSize = true;
			this.Datum.BackColor = System.Drawing.Color.Transparent;
			this.Datum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Datum.Location = new System.Drawing.Point(310, 22);
			this.Datum.Name = "Datum";
			this.Datum.Size = new System.Drawing.Size(110, 17);
			this.Datum.TabIndex = 15;
			this.Datum.Text = "Datum Obaveze";
			// 
			// Arhiva
			// 
			this.Arhiva.AutoSize = true;
			this.Arhiva.BackColor = System.Drawing.Color.Transparent;
			this.Arhiva.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Arhiva.Location = new System.Drawing.Point(320, 106);
			this.Arhiva.Name = "Arhiva";
			this.Arhiva.Size = new System.Drawing.Size(99, 31);
			this.Arhiva.TabIndex = 16;
			this.Arhiva.Text = "Arhiva:";
			// 
			// checboxarhiva
			// 
			this.checboxarhiva.BackColor = System.Drawing.Color.White;
			this.checboxarhiva.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.checboxarhiva.Location = new System.Drawing.Point(425, 106);
			this.checboxarhiva.Name = "checboxarhiva";
			this.checboxarhiva.Size = new System.Drawing.Size(38, 38);
			this.checboxarhiva.TabIndex = 17;
			this.checboxarhiva.Click += new System.EventHandler(this.checboxarhiva_Click);
			// 
			// button1
			// 
			this.button1.Image = global::HCI_ToDoList.Properties.Resources.Minus_sign_40;
			this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button1.Location = new System.Drawing.Point(230, 515);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(107, 36);
			this.button1.TabIndex = 18;
			this.button1.Text = "Obrisi";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// Sacuvaj
			// 
			this.Sacuvaj.Image = global::HCI_ToDoList.Properties.Resources.saveicon2_mini;
			this.Sacuvaj.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Sacuvaj.Location = new System.Drawing.Point(110, 515);
			this.Sacuvaj.Name = "Sacuvaj";
			this.Sacuvaj.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
			this.Sacuvaj.Size = new System.Drawing.Size(114, 36);
			this.Sacuvaj.TabIndex = 10;
			this.Sacuvaj.Text = "Sacuvaj";
			this.Sacuvaj.UseVisualStyleBackColor = true;
			this.Sacuvaj.Click += new System.EventHandler(this.Sacuvaj_Click);
			// 
			// DodajEditForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(557, 586);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.checboxarhiva);
			this.Controls.Add(this.Arhiva);
			this.Controls.Add(this.Datum);
			this.Controls.Add(this.dateTimePicker1);
			this.Controls.Add(this.vrstaobaveze_label);
			this.Controls.Add(this.Combobox_Vrstaobaveze);
			this.Controls.Add(this.Nazad);
			this.Controls.Add(this.Sacuvaj);
			this.Controls.Add(this.RichtextboxDetalji);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.textboxnaziv);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.textboxgrupa);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.ChecklboxLabel);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "DodajEditForm";
			this.Text = "DodajEditForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label ChecklboxLabel;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textboxgrupa;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textboxnaziv;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.RichTextBox RichtextboxDetalji;
		private System.Windows.Forms.Button Sacuvaj;
		private System.Windows.Forms.Button Nazad;
		private System.Windows.Forms.ComboBox Combobox_Vrstaobaveze;
		private System.Windows.Forms.Label vrstaobaveze_label;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.Label Datum;
		private System.Windows.Forms.Label Arhiva;
		private System.Windows.Forms.Label checboxarhiva;
		private System.Windows.Forms.Button button1;
	}
}