using HCI_ToDoList.Entity_Class;
using HCI_ToDoList.Properties;
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

namespace HCI_ToDoList.Dogadjaji
{
	public partial class DogadjajiPanel : Form
	{
		ConnectionTobase konekcija = Connect.DB;
		public string Text;
		public int trenutniprofilId;


		public DogadjajiPanel()
		{
			InitializeComponent();
		}

		public DogadjajiPanel(string text):this()
		{
			Text = text;
			trenutniprofilId = konekcija.trenutniprofil.FirstOrDefault().Profil_Id;
			loadnormal();
			
		}

		private void loadnormal()
		{
			Form ovaforma = this;

			ovaforma.Controls.Clear(); //ovo je rijesilo problem


			////uzimanje svih obaveza
			var dogadaji = konekcija.Dogadaji.AsQueryable();

			////uzimanje obaveza od profila 
			dogadaji = dogadaji.Where(X => X.Profil.ID_Profil.Equals(trenutniprofilId));


			dogadaji = dogadaji.OrderBy(X => X.NazivObaveze);

			//trazenje obaveza tog datuma 
			var list = dogadaji.Where(X => X.DatumDogađaja.Contains(Text)).ToList();




			int panX = 66;
			int panY = 23;
			int razmakpanel = 10;

			int brojtaskova = list.Count();


			for (int t = 0; t < brojtaskova; t++)
			{
				//	//label naslov Taska 

				var naslovtaska = new Label();
				naslovtaska.Name = "NaslovTaska";
				naslovtaska.AutoSize = true;
				naslovtaska.Location = new Point(99, 0);
				naslovtaska.Font = new Font(naslovtaska.Font, FontStyle.Bold);
				naslovtaska.Text = list[t].NazivObaveze;
				naslovtaska.Size = new Size(58, 22);
				naslovtaska.Font = new Font(naslovtaska.Font.Name, 13, naslovtaska.Font.Style, naslovtaska.Font.Unit);


				//	//checkbox taska 

				var checkbox = new Label();
				checkbox.AutoSize = false;
				checkbox.Location = new Point(-1, -1);
				checkbox.Font = new Font(naslovtaska.Font, FontStyle.Bold);
				//checkbox.Font= new Font(naslovtaska.Font.Name, 13, naslovtaska.Font.Style, naslovtaska.Font.Unit);
				checkbox.Size = new Size(94, 98);
				checkbox.BackColor = Color.White;
				checkbox.BorderStyle = BorderStyle.FixedSingle;
				checkbox.Click += new EventHandler(b_Click);

				if (list[t].Status == "Zavrseno")
				{

					checkbox.Image = Resources.hciicon;

				}
				else
				{
					checkbox.Image = null;
				}
				//	//kraj checkboxa


				//	//Description label  / Opis taska 
				var OpisTask = new Label();
				OpisTask.AutoSize = true;
				OpisTask.Location = new Point(100, 39);
				OpisTask.Text = list[t].Opis;
				OpisTask.Size = new Size(35, 13);




				//	//panel je kontejener koji sadrzi 2 labela i checboxlabel
				var panel = new Panel();
				panel.Location = new Point(panX, panY + razmakpanel);
				panel.Size = new Size(391, 98);
				panel.BorderStyle = BorderStyle.FixedSingle;
				panel.BackColor = Color.AliceBlue;
				panel.Controls.Add(naslovtaska); //index 1 ili 0
				panel.Controls.Add(checkbox);//index 1 ili 2
				panel.Controls.Add(OpisTask);//index 3 ili 4
				panel.Click += new EventHandler(panelclickzaedit);
				this.Controls.Add(panel);
				razmakpanel += (98 + 10);
















			}
		}

		private void panelclickzaedit(object sender, EventArgs e)
		{
			//int scrollvalue = this.VerticalScroll.Value;

			var Panel = ((Panel)sender); //uzimamo ovaj panel

			////pronalazimo label sa naslovom u panelu
			object checboxlabel = Panel.Controls.Find("NaslovTaska", true).SingleOrDefault();

			////vadimo ime  iz naslovnog panela
			string nazivzapretragu = ((System.Windows.Forms.Label)checboxlabel).Text;

			////vadimo task koristeci ime naslovnog taska 
			///
			var dogadaj = konekcija.Dogadaji.AsQueryable();

			dogadaj = dogadaj.Where(X => X.Profil.ID_Profil == trenutniprofilId);

			dogadaj = dogadaj.Where(X => X.NazivObaveze.Equals(nazivzapretragu));

			DogadajiTabela entity = dogadaj.FirstOrDefault();



			////uzimamo ovaj tab
			TabPage ovajtab = ((TabPage)this.Parent.Parent.Parent);

			////ocistimo ovaj tab
			ovajtab.Controls.Clear();

			////uzimamo dodaj edit formu stavljamu u nju obavezu  pa sve to postavljamo na tab 
			DodajDogađajForma form = new DodajDogađajForma(entity.Događaji_Id);
			form.TopLevel = false;
			ovajtab.Controls.Add(form);
			form.Dock = DockStyle.Fill;
			form.Show();

		}

		private void b_Click(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}
	}
}
