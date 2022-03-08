using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using RadioButton = System.Windows.Forms.RadioButton;

namespace HCI_ToDoList.Pomocne_klase
{
    class MyRadioButton : RadioButton

    {

        public MyRadioButton()

            : base()

        {

        }

        protected override void OnPaint(PaintEventArgs pevent)

        {

            if (this.AutoSize)

            {

                base.OnPaint(pevent);

            }

            else

            {

                pevent.Graphics.FillRectangle(new SolidBrush(this.BackColor), this.ClientRectangle);

                int contentHeight = this.Height - (this.Padding.Top + this.Padding.Bottom);

                Rectangle radioRectangle = new Rectangle(new Point(this.Padding.Left, this.Padding.Top), new Size(contentHeight, contentHeight));

                ControlPaint.DrawRadioButton(pevent.Graphics,

                    radioRectangle,

                    (this.FlatStyle == FlatStyle.Flat ? ButtonState.Flat : ButtonState.Normal) | (this.Checked ? ButtonState.Checked : ButtonState.Normal));

                StringFormat stringFormat = new StringFormat();

                stringFormat.LineAlignment = (int)(this.TextAlign & (ContentAlignment.MiddleCenter | ContentAlignment.MiddleLeft | ContentAlignment.MiddleRight)) != 0 ? StringAlignment.Center : (int)(this.TextAlign & (ContentAlignment.TopCenter | ContentAlignment.TopLeft | ContentAlignment.TopRight)) != 0 ? StringAlignment.Near : StringAlignment.Far;

                stringFormat.Alignment = (int)(this.TextAlign & (ContentAlignment.MiddleCenter | ContentAlignment.TopCenter | ContentAlignment.BottomCenter)) != 0 ? StringAlignment.Center : (int)(this.TextAlign & (ContentAlignment.BottomLeft | ContentAlignment.TopLeft | ContentAlignment.MiddleLeft)) != 0 ? StringAlignment.Near : StringAlignment.Far;

                stringFormat.HotkeyPrefix = this.UseMnemonic ? (this.ShowKeyboardCues ? System.Drawing.Text.HotkeyPrefix.Show : System.Drawing.Text.HotkeyPrefix.Hide) : System.Drawing.Text.HotkeyPrefix.None;

                pevent.Graphics.DrawString(this.Text,

                    this.Font,

                    new SolidBrush(this.ForeColor),

                    new RectangleF(contentHeight, this.Padding.Top, this.Width - contentHeight - this.Padding.Left - this.Padding.Right, contentHeight),

                    stringFormat);

            }

        }

    }
}
