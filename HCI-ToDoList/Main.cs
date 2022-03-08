using HCI_ToDoList.GlavneObaveze;
using HCI_ToDoList.Home;
using HCI_ToDoList.Sedmicne;
using HCI_ToDoList.MyContext;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HCI_ToDoList.MyContext.Konekcija;
using HCI_ToDoList.Dnevne;
using HCI_ToDoList.DodajObavezu;
using HCI_ToDoList.Dogadjaji;
using HCI_ToDoList.Podsjetnici;
using HCI_ToDoList.Fliter_forma;
using HCI_ToDoList.Statistika;
using HCI_ToDoList.Properties;
using HCI_ToDoList.Entity_Class;

namespace HCI_ToDoList
{
	public partial class Main : Form
	{
		ConnectionTobase konekcija = Connect.DB;
	
		
		
		
		public Main()
		{
			InitializeComponent();
			tabControl1.SelectedIndexChanged += new EventHandler(Tabs_SelectedIndexChanged);
			testload();

		}

		private void testload()
		{
			tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
			this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);

			 
			HomeForm form = new HomeForm();
			form.TopLevel = false;
			tabPage1.Controls.Add(form);
			form.Dock = DockStyle.Fill;
			form.Show();

			 

			
			







		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
		{
			Graphics g = e.Graphics;
			TabPage tp = tabControl1.TabPages[e.Index];

			StringFormat sf = new StringFormat();
			sf.Alignment = StringAlignment.Center;  //optional
			sf.LineAlignment = StringAlignment.Center;


			// This is the rectangle to draw "over" the tabpage title
			RectangleF headerRect = new RectangleF(e.Bounds.X, e.Bounds.Y + 2, e.Bounds.Width, e.Bounds.Height - 2);

			// This is the default colour to use for the non-selected tabs
			SolidBrush sb = new SolidBrush(Color.Silver);

			// This changes the colour if we're trying to draw the selected tabpage
			if (tabControl1.SelectedIndex == e.Index)
				sb.Color = Color.LightSkyBlue;

			// Colour the header of the current tabpage based on what we did above
			g.FillRectangle(sb, e.Bounds);

			//Remember to redraw the text - I'm always using black for title text
			g.DrawString(tp.Text, tabControl1.Font, new SolidBrush(Color.Black), headerRect, sf);
		}
		

		private void tabPage2_Click(object sender, EventArgs e)
		{

			



		}
		private void Tabs_SelectedIndexChanged(object sender, EventArgs e)
		{

			button2.Text = "Filtriraj";
			button2.Image = Resources.filled_filter_24;
			button2.TextAlign = ContentAlignment.MiddleCenter;

			if (tabControl1.SelectedTab == tabPage2)
			{
				tabPage2.Controls.Clear();
				GlavnaForm form = new GlavnaForm();
				form.TopLevel = false;
				tabPage2.Controls.Add(form);
				form.Dock = DockStyle.Fill;
				form.Show();




			}
			else if (tabControl1.SelectedTab == tabPage4)
			{
				tabPage4.Controls.Clear();
				SedmicneForm form = new SedmicneForm();
				form.TopLevel = false;
				tabPage4.Controls.Add(form);
				form.Dock = DockStyle.Fill;
				form.Show();
			}
			else if (tabControl1.SelectedTab == tabPage3)
			{
				tabPage3.Controls.Clear();
				DnevneFrom form = new DnevneFrom();
				form.TopLevel = false;
				tabPage3.Controls.Add(form);
				form.Dock = DockStyle.Fill;
				form.Show();
			}
			else if (tabControl1.SelectedTab == tabPage5)
			{

				button2.Text = "Obrisi Sve Dogadaje";
				button2.Image = Resources.Minus_sign_40;
				button2.TextAlign = ContentAlignment.MiddleRight;

				tabPage5.Controls.Clear();
				DogadjajiForma form = new DogadjajiForma();
				form.TopLevel = false;
				tabPage5.Controls.Add(form);
				form.Dock = DockStyle.Fill;
				form.Show();
			}
			else if (tabControl1.SelectedTab == tabPage6)
			{
				tabPage6.Controls.Clear();
				PodsjetniciForma form = new PodsjetniciForma();
				form.TopLevel = false;
				tabPage6.Controls.Add(form);
				form.Dock = DockStyle.Fill;
				form.Show();
			}
			else if (tabControl1.SelectedTab == tabPage1)
			{
				tabPage1.Controls.Clear();
				HomeForm form = new HomeForm();
				form.TopLevel = false;
				tabPage1.Controls.Add(form);
				form.Dock = DockStyle.Fill;
				form.Show();
			}

		}

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

		private void dodajButton_Click(object sender, EventArgs e)
		{


			if (tabControl1.SelectedTab == tabPage6)
			{
				tabControl1.SelectedTab.Controls.Clear();

				AddEditPodsjetnici formpod = new AddEditPodsjetnici();
				formpod.TopLevel = false;
				tabControl1.SelectedTab.Controls.Add(formpod);
				formpod.Dock = DockStyle.Fill;
				formpod.Show();
				return;



			}
			if (tabControl1.SelectedTab == tabPage5)
			{
				tabControl1.SelectedTab.Controls.Clear();
				DodajDogađajForma događajiform = new DodajDogađajForma();
				događajiform.TopLevel = false;
				tabControl1.SelectedTab.Controls.Add(događajiform);
				događajiform.Dock = DockStyle.Fill;
				događajiform.Show();
				return;



			}

			int vrsta = 0;

			if (tabControl1.SelectedTab == tabPage3)
			{
				vrsta = 2;



			}
			if (tabControl1.SelectedTab == tabPage4)
			{
				vrsta = 1;



			}








			tabControl1.SelectedTab.Controls.Clear();

			DodajEditForm form = new DodajEditForm(vrsta);
			form.TopLevel = false;
			tabControl1.SelectedTab.Controls.Add(form);
			form.Dock = DockStyle.Fill;
			form.Show();

			



		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (tabControl1.SelectedTab == tabPage4)
			{
				
				tabPage4.Controls.Clear();
				FiltrirajForma form = new FiltrirajForma("Sedmicne");
				form.TopLevel = false;
				tabPage4.Controls.Add(form);
				
				form.Dock = DockStyle.Fill;
				form.Show();




			}
			 if ( tabControl1.SelectedTab == tabPage3)
			{
				
				tabPage3.Controls.Clear();
				
				FiltrirajForma form = new FiltrirajForma("Dnevne");
				form.TopLevel = false;
				tabPage3.Controls.Add(form);
				
				form.Dock = DockStyle.Fill;
				form.Show();




			}

			if ( tabControl1.SelectedTab == tabPage2)
			{
				tabPage2.Controls.Clear();
				
				FiltrirajForma form = new FiltrirajForma("Glavne");
				form.TopLevel = false;
				
				tabPage2.Controls.Add(form);
				form.Dock = DockStyle.Fill;
				form.Show();




			}
			if (tabControl1.SelectedTab == tabPage6)
			{
				tabPage6.Controls.Clear();

				FilterPodsjetnici form = new FilterPodsjetnici();
				form.TopLevel = false;

				tabPage6.Controls.Add(form);
				form.Dock = DockStyle.Fill;
				form.Show();




			}
			if (tabControl1.SelectedTab == tabPage5)
			{
				int trenutniprofilid = konekcija.trenutniprofil.FirstOrDefault().Profil_Id;

				DogadjajiForma forma = tabPage5.Controls[0] as DogadjajiForma;

				Label datum = forma.Controls.Find("LB_datumdogađaja",true).FirstOrDefault() as Label;

				string datumstr = datum.Text;

				var dogadajibrisanje = konekcija.Dogadaji.AsQueryable();

				dogadajibrisanje = dogadajibrisanje.Where(X => X.Profil.ID_Profil == trenutniprofilid);

				dogadajibrisanje = dogadajibrisanje.Where(X => X.DatumDogađaja.Contains(datumstr));

				List<DogadajiTabela> list = dogadajibrisanje.ToList();

				if (list.Count== 0)
				{
					MessageBox.Show("nema dogadaja za brisati");
					return;
				}

				konekcija.Dogadaji.RemoveRange(list);

				konekcija.SaveChanges();

				MessageBox.Show("dogadaji za datum " + datumstr + " uspjesno obrisani");


				tabPage5.Controls.Clear();
				DogadjajiForma form = new DogadjajiForma();
				form.TopLevel = false;
				tabPage5.Controls.Add(form);
				form.Dock = DockStyle.Fill;
				form.Show();




			}



		}

		private void Statistka_Click(object sender, EventArgs e)
		{
			tabControl1.SelectedTab.Controls.Clear();

			
			StatistikaForm form = new StatistikaForm();
			form.TopLevel = false;
			tabControl1.SelectedTab.Controls.Add(form);
			form.Dock = DockStyle.Fill;
			form.Show();
		}

		private void tabPage4_Click(object sender, EventArgs e)
		{

		}
	}
}
