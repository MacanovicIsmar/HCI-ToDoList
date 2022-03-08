
namespace HCI_ToDoList.Dogadjaji
{
    partial class DogadjajiForma
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
			this.maDataGrid = new System.Windows.Forms.DataGridView();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.displayEvent = new System.Windows.Forms.TextBox();
			this.addEvent = new System.Windows.Forms.Button();
			this.txtEvent = new System.Windows.Forms.TextBox();
			this.timeEvent = new System.Windows.Forms.MaskedTextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.dateEvent = new System.Windows.Forms.DateTimePicker();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.Desnogodina = new System.Windows.Forms.Label();
			this.desnomjesec = new System.Windows.Forms.Label();
			this.maDate = new System.Windows.Forms.Label();
			this.leftmjesec = new System.Windows.Forms.Label();
			this.leftgodina = new System.Windows.Forms.Label();
			this.godine = new System.Windows.Forms.ComboBox();
			this.mjesec = new System.Windows.Forms.ComboBox();
			this.Pan_događajiLista = new System.Windows.Forms.Panel();
			this.LB_datumdogađaja = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.maDataGrid)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// maDataGrid
			// 
			this.maDataGrid.AllowUserToAddRows = false;
			this.maDataGrid.AllowUserToResizeColumns = false;
			this.maDataGrid.AllowUserToResizeRows = false;
			this.maDataGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.maDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.maDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.maDataGrid.ColumnHeadersVisible = false;
			this.maDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
			dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.maDataGrid.DefaultCellStyle = dataGridViewCellStyle18;
			this.maDataGrid.Location = new System.Drawing.Point(1, 83);
			this.maDataGrid.MultiSelect = false;
			this.maDataGrid.Name = "maDataGrid";
			this.maDataGrid.RowHeadersVisible = false;
			this.maDataGrid.RowHeadersWidth = 10;
			this.maDataGrid.RowTemplate.Height = 50;
			this.maDataGrid.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.maDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.maDataGrid.Size = new System.Drawing.Size(552, 326);
			this.maDataGrid.TabIndex = 2;
			this.maDataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.maDataGrid_CellClick_1);
			this.maDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.maDataGrid_CellContentClick);
			this.maDataGrid.SelectionChanged += new System.EventHandler(this.maDataGrid_SelectionChanged);
			// 
			// Column1
			// 
			this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
			dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Column1.DefaultCellStyle = dataGridViewCellStyle10;
			this.Column1.HeaderText = "Column1";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			this.Column1.Width = 30;
			// 
			// Column2
			// 
			dataGridViewCellStyle11.BackColor = System.Drawing.Color.White;
			dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.Column2.DefaultCellStyle = dataGridViewCellStyle11;
			this.Column2.HeaderText = "Column2";
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			// 
			// Column3
			// 
			dataGridViewCellStyle12.NullValue = null;
			dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.Column3.DefaultCellStyle = dataGridViewCellStyle12;
			this.Column3.HeaderText = "Column3";
			this.Column3.Name = "Column3";
			this.Column3.ReadOnly = true;
			// 
			// Column4
			// 
			dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.Column4.DefaultCellStyle = dataGridViewCellStyle13;
			this.Column4.HeaderText = "Column4";
			this.Column4.Name = "Column4";
			this.Column4.ReadOnly = true;
			// 
			// Column5
			// 
			dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.Column5.DefaultCellStyle = dataGridViewCellStyle14;
			this.Column5.HeaderText = "Column5";
			this.Column5.Name = "Column5";
			this.Column5.ReadOnly = true;
			// 
			// Column6
			// 
			dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.Column6.DefaultCellStyle = dataGridViewCellStyle15;
			this.Column6.HeaderText = "Column6";
			this.Column6.Name = "Column6";
			this.Column6.ReadOnly = true;
			// 
			// Column7
			// 
			dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.Column7.DefaultCellStyle = dataGridViewCellStyle16;
			this.Column7.HeaderText = "Column7";
			this.Column7.Name = "Column7";
			this.Column7.ReadOnly = true;
			// 
			// Column8
			// 
			dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.Column8.DefaultCellStyle = dataGridViewCellStyle17;
			this.Column8.HeaderText = "Column8";
			this.Column8.Name = "Column8";
			this.Column8.ReadOnly = true;
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.Color.Transparent;
			this.groupBox1.Controls.Add(this.displayEvent);
			this.groupBox1.Controls.Add(this.addEvent);
			this.groupBox1.Controls.Add(this.txtEvent);
			this.groupBox1.Controls.Add(this.timeEvent);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.dateEvent);
			this.groupBox1.Location = new System.Drawing.Point(1, 614);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(583, 86);
			this.groupBox1.TabIndex = 11;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Events";
			// 
			// displayEvent
			// 
			this.displayEvent.Location = new System.Drawing.Point(416, 19);
			this.displayEvent.Multiline = true;
			this.displayEvent.Name = "displayEvent";
			this.displayEvent.ReadOnly = true;
			this.displayEvent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.displayEvent.Size = new System.Drawing.Size(134, 49);
			this.displayEvent.TabIndex = 8;
			this.displayEvent.TextChanged += new System.EventHandler(this.displayEvent_TextChanged);
			// 
			// addEvent
			// 
			this.addEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.addEvent.Location = new System.Drawing.Point(335, 19);
			this.addEvent.Name = "addEvent";
			this.addEvent.Size = new System.Drawing.Size(75, 49);
			this.addEvent.TabIndex = 7;
			this.addEvent.Text = "addEvent";
			this.addEvent.UseVisualStyleBackColor = true;
			this.addEvent.Click += new System.EventHandler(this.addEvent_Click_1);
			// 
			// txtEvent
			// 
			this.txtEvent.Location = new System.Drawing.Point(192, 19);
			this.txtEvent.Multiline = true;
			this.txtEvent.Name = "txtEvent";
			this.txtEvent.Size = new System.Drawing.Size(137, 49);
			this.txtEvent.TabIndex = 6;
			this.txtEvent.Text = "Event : ";
			// 
			// timeEvent
			// 
			this.timeEvent.Location = new System.Drawing.Point(83, 48);
			this.timeEvent.Mask = "00:00";
			this.timeEvent.Name = "timeEvent";
			this.timeEvent.Size = new System.Drawing.Size(103, 20);
			this.timeEvent.TabIndex = 5;
			this.timeEvent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.timeEvent.ValidatingType = typeof(System.DateTime);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(6, 51);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(69, 13);
			this.label7.TabIndex = 4;
			this.label7.Text = "Time event : ";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(8, 25);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(69, 13);
			this.label6.TabIndex = 2;
			this.label6.Text = "Date event : ";
			// 
			// dateEvent
			// 
			this.dateEvent.Location = new System.Drawing.Point(83, 19);
			this.dateEvent.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
			this.dateEvent.Name = "dateEvent";
			this.dateEvent.Size = new System.Drawing.Size(103, 20);
			this.dateEvent.TabIndex = 1;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Tan;
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Controls.Add(this.godine);
			this.panel1.Controls.Add(this.mjesec);
			this.panel1.Location = new System.Drawing.Point(1, 41);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(593, 36);
			this.panel1.TabIndex = 12;
			this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.panel2.Controls.Add(this.Desnogodina);
			this.panel2.Controls.Add(this.desnomjesec);
			this.panel2.Controls.Add(this.maDate);
			this.panel2.Controls.Add(this.leftmjesec);
			this.panel2.Controls.Add(this.leftgodina);
			this.panel2.Location = new System.Drawing.Point(171, 3);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(210, 30);
			this.panel2.TabIndex = 3;
			// 
			// Desnogodina
			// 
			this.Desnogodina.AutoSize = true;
			this.Desnogodina.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Desnogodina.Location = new System.Drawing.Point(180, 3);
			this.Desnogodina.Name = "Desnogodina";
			this.Desnogodina.Size = new System.Drawing.Size(27, 24);
			this.Desnogodina.TabIndex = 7;
			this.Desnogodina.Text = ">|";
			this.Desnogodina.Click += new System.EventHandler(this.Desnogodina_Click);
			// 
			// desnomjesec
			// 
			this.desnomjesec.AutoSize = true;
			this.desnomjesec.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.desnomjesec.Location = new System.Drawing.Point(159, 4);
			this.desnomjesec.Name = "desnomjesec";
			this.desnomjesec.Size = new System.Drawing.Size(22, 24);
			this.desnomjesec.TabIndex = 11;
			this.desnomjesec.Text = ">";
			this.desnomjesec.Click += new System.EventHandler(this.desnomjesec_Click);
			// 
			// maDate
			// 
			this.maDate.AutoSize = true;
			this.maDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.maDate.Location = new System.Drawing.Point(54, 6);
			this.maDate.Name = "maDate";
			this.maDate.Size = new System.Drawing.Size(99, 20);
			this.maDate.TabIndex = 10;
			this.maDate.Text = "Place Holder";
			// 
			// leftmjesec
			// 
			this.leftmjesec.AutoSize = true;
			this.leftmjesec.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.leftmjesec.Location = new System.Drawing.Point(27, 4);
			this.leftmjesec.Name = "leftmjesec";
			this.leftmjesec.Size = new System.Drawing.Size(22, 24);
			this.leftmjesec.TabIndex = 9;
			this.leftmjesec.Text = "<";
			this.leftmjesec.Click += new System.EventHandler(this.leftmjesec_Click);
			// 
			// leftgodina
			// 
			this.leftgodina.AutoSize = true;
			this.leftgodina.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.leftgodina.Location = new System.Drawing.Point(1, 4);
			this.leftgodina.Name = "leftgodina";
			this.leftgodina.Size = new System.Drawing.Size(27, 24);
			this.leftgodina.TabIndex = 8;
			this.leftgodina.Text = "|<";
			this.leftgodina.Click += new System.EventHandler(this.leftgodina_Click);
			// 
			// godine
			// 
			this.godine.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.godine.FormattingEnabled = true;
			this.godine.Location = new System.Drawing.Point(387, 1);
			this.godine.Name = "godine";
			this.godine.Size = new System.Drawing.Size(165, 32);
			this.godine.TabIndex = 1;
			this.godine.SelectedIndexChanged += new System.EventHandler(this.godine_SelectedIndexChanged);
			this.godine.SelectionChangeCommitted += new System.EventHandler(this.godine_SelectionChangeCommitted);
			// 
			// mjesec
			// 
			this.mjesec.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.mjesec.FormattingEnabled = true;
			this.mjesec.Location = new System.Drawing.Point(3, 1);
			this.mjesec.Name = "mjesec";
			this.mjesec.Size = new System.Drawing.Size(162, 32);
			this.mjesec.TabIndex = 0;
			this.mjesec.SelectedIndexChanged += new System.EventHandler(this.mjesec_SelectedIndexChanged_2);
			this.mjesec.SelectionChangeCommitted += new System.EventHandler(this.mjesec_SelectionChangeCommitted);
			// 
			// Pan_događajiLista
			// 
			this.Pan_događajiLista.AutoScroll = true;
			this.Pan_događajiLista.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Pan_događajiLista.Location = new System.Drawing.Point(12, 445);
			this.Pan_događajiLista.Name = "Pan_događajiLista";
			this.Pan_događajiLista.Size = new System.Drawing.Size(538, 163);
			this.Pan_događajiLista.TabIndex = 20;
			// 
			// LB_datumdogađaja
			// 
			this.LB_datumdogađaja.AutoSize = true;
			this.LB_datumdogađaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.LB_datumdogađaja.Location = new System.Drawing.Point(172, 412);
			this.LB_datumdogađaja.Name = "LB_datumdogađaja";
			this.LB_datumdogađaja.Size = new System.Drawing.Size(227, 26);
			this.LB_datumdogađaja.TabIndex = 21;
			this.LB_datumdogađaja.Text = "Datum nije selektovan";
			this.LB_datumdogađaja.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// DogadjajiForma
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(587, 787);
			this.Controls.Add(this.LB_datumdogađaja);
			this.Controls.Add(this.Pan_događajiLista);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.maDataGrid);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "DogadjajiForma";
			this.Text = "DogadjajiForma";
			((System.ComponentModel.ISupportInitialize)(this.maDataGrid)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView maDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox displayEvent;
        private System.Windows.Forms.Button addEvent;
        private System.Windows.Forms.TextBox txtEvent;
        private System.Windows.Forms.MaskedTextBox timeEvent;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateEvent;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label Desnogodina;
        private System.Windows.Forms.Label desnomjesec;
        private System.Windows.Forms.Label maDate;
        private System.Windows.Forms.Label leftmjesec;
        private System.Windows.Forms.Label leftgodina;
        private System.Windows.Forms.ComboBox godine;
        private System.Windows.Forms.ComboBox mjesec;
		private System.Windows.Forms.Panel Pan_događajiLista;
		private System.Windows.Forms.Label LB_datumdogađaja;
	}
}