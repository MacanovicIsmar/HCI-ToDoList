
namespace HCI_ToDoList.Dnevne
{
    partial class DnevneFrom
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
			this.label8 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label8
			// 
			this.label8.BackColor = System.Drawing.Color.DarkGray;
			this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label8.Location = new System.Drawing.Point(1, -12);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(596, 58);
			this.label8.TabIndex = 7;
			this.label8.Text = "Dnevne";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label8.Click += new System.EventHandler(this.label8_Click);
			// 
			// DnevneFrom
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(597, 545);
			this.Controls.Add(this.label8);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "DnevneFrom";
			this.Text = "DnevneFrom";
			this.Load += new System.EventHandler(this.DnevneFrom_Load);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label8;
    }
}