using HCI_ToDoList.DodajObavezu;
using HCI_ToDoList.Dogadjaji;
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

namespace HCI_ToDoList.GlavneObaveze
{
	public partial class GlavnaForm : Form
	{
		ConnectionTobase konekcija = Connect.DB;
		static int trenutniprofilId;
		public static SortiranjeTabela sorttabela;


		public GlavnaForm()
		{
			InitializeComponent();
			trenutniprofilId = konekcija.trenutniprofil.FirstOrDefault().Profil_Id;
			sorttabela =
			konekcija.Sortiranjetabela
			.Where(X => X.Profil.ID_Profil == trenutniprofilId)
			.Where(x => x.Tip == "Glavne")
			.FirstOrDefault();
			loadform(0);

		}

		void b_Click(object sender, EventArgs e)
		{

			int scrollvalue = this.VerticalScroll.Value;

			//MessageBox.Show(((System.Windows.Forms.Label)sender).Name + " clicked");

			var Panel = ((Label)sender).Parent;

			object checboxlabel = Panel.Controls.Find("NaslovTaska", true).SingleOrDefault();

			//MessageBox.Show(((System.Windows.Forms.Label)checboxlabel).Text + " clicked");

			string nazivzapretragu = ((System.Windows.Forms.Label)checboxlabel).Text;

			GlavneObavezeTabela task = konekcija.GlavneObaveze.Where(x=>x.Profiltabela.ID_Profil==trenutniprofilId).ToList()
				.Where(X => X.NazivObaveze.Equals(nazivzapretragu)).FirstOrDefault();

			//quary
			string datum = DateTime.Today.ToString(format: "dd.MM.yyyy");


			var statistikapodatak = konekcija.Statistika.AsQueryable();

			statistikapodatak = statistikapodatak.Where(X => X.Profil.ID_Profil == trenutniprofilId);

			statistikapodatak = statistikapodatak.Where(X => X.Datum.Contains(datum));

			statistikapodatak= statistikapodatak.Where(X => X.TipObaveze== "Glavne");

			StatistikaTabela entitiy = statistikapodatak.FirstOrDefault(); 



			if (entitiy == null)
			{

				entitiy = new StatistikaTabela();
				//stats.Datum = Datum;
				entitiy.Profil = konekcija.Profil.Where(X => X.ID_Profil == trenutniprofilId).FirstOrDefault();
				entitiy.TipObaveze = "Glavne";
				entitiy.Datum = datum;
				konekcija.Statistika.Add(entitiy);

			}

			if (task.Status == "Zavrseno")
			{

				task.Status = "NeZavrseno";
				entitiy.BrojOdrađeniObaveza = entitiy.BrojOdrađeniObaveza != 0 ? --entitiy.BrojOdrađeniObaveza : entitiy.BrojOdrađeniObaveza;
			}
			else
			{
				task.Status = "Zavrseno";
				entitiy.BrojOdrađeniObaveza++;
                if (sorttabela.BrisanjeZavrsenih == "Yes")
                {
					konekcija.GlavneObaveze.Remove(task);
                }
			}
			konekcija.SaveChanges();
			loadform(scrollvalue);


		}



		private void loadform(int scrollvalue)
		{
			if (trenutniprofilId == 0)
			{

				return;

			}

			Form ovaforma = this;

			ovaforma.Controls.Clear(); 





			Label naslov = new Label();
			naslov.Name = "naslov";
			naslov.Size = new Size(596, 42);
			naslov.Location = new Point(0, 0);
			naslov.BackColor = Color.DarkGray;
			naslov.Text = "Glavne " + konekcija.Profil.Where(X => X.ID_Profil.Equals(trenutniprofilId)).FirstOrDefault().NazivProfila;
			naslov.Font = new Font(naslov.Font.Name, 20, naslov.Font.Style, naslov.Font.Unit);
			naslov.TextAlign = ContentAlignment.MiddleCenter;

			ovaforma.Controls.Add(naslov);
            if (sorttabela.BrisanjeZavrsenih == "Yes")
            {
				List<GlavneObavezeTabela> zavrseneGlavne = konekcija.GlavneObaveze.Where(x => x.Profiltabela.ID_Profil == trenutniprofilId).ToList()
					.Where(x => x.Status == "Zavrseno").ToList();
				konekcija.GlavneObaveze.RemoveRange(zavrseneGlavne);
				konekcija.SaveChanges();
            }
            if (sorttabela.PoGrupi == "Yes")
            {
				loadsorrpogrupi();
            }
            else
            {
				loadnormal();
            }
			

			



			

			
			
			


		}

		private void loadnormal()
		{
			var taskovi = new List<GlavneObavezeTabela>();


			taskovi = konekcija.GlavneObaveze.ToList();


			taskovi = taskovi.Where(X => X.Profiltabela.ID_Profil.Equals(trenutniprofilId)).ToList();

			if (sorttabela.PoDatumu == "Yes")
			{

				taskovi = taskovi
					  .OrderByDescending(X => stringtodate.Stringtodatum(X.DatumValidnosti))
					  .ToList();

			}




			if (sorttabela.PoNazivu == "Yes")
			{
				taskovi = taskovi.OrderBy(x => x.NazivObaveze).ToList();
			}
            if (sorttabela.PrikazZavršenih == "No")
            {
				taskovi = taskovi.Where(x => x.Status == "NeZavrseno").ToList();

            }
			if (sorttabela.PrikazArhive == "No")
			{
				taskovi = taskovi.Where(x => x.Arhiva == "No").ToList();
			}
			else
			{
				taskovi = taskovi.Where(x => x.Arhiva == "Yes").ToList();
			}

			int razmak = 0;
			int katx = 35;
			int katy = 67;


			int panX = 85;
			int panY = 119;
			int razmakpanel = 0;
			int brojtaskova = taskovi.Count();
			for (int t = 0; t < brojtaskova; t++)
			{

				var naslovtaska = new Label();
				naslovtaska.Name = "NaslovTaska";
				naslovtaska.AutoSize = true;
				naslovtaska.Location = new Point(99, 0);
				naslovtaska.Font = new Font(naslovtaska.Font, FontStyle.Bold);
				naslovtaska.Text = taskovi[t].NazivObaveze;
				naslovtaska.Size = new Size(68, 22);
				naslovtaska.Font = new Font(naslovtaska.Font.Name, 13, naslovtaska.Font.Style, naslovtaska.Font.Unit);
				naslovtaska.Click += new EventHandler(panelclickzaedit);

				var checkbox = new Label();
				checkbox.AutoSize = false;
				checkbox.Location = new Point(-1, -1);
				checkbox.Font = new Font(naslovtaska.Font, FontStyle.Bold);
				checkbox.Size = new Size(94, 98);
				checkbox.BackColor = Color.White;
				checkbox.BorderStyle = BorderStyle.FixedSingle;
				checkbox.Click += new EventHandler(b_Click);

				if (taskovi[t].Status == "Zavrseno")
				{

					checkbox.Image = Resources.hciicon;

				}
				else
				{
					checkbox.Image = null;
				}
				var OpisTask = new Label();
				OpisTask.AutoSize = true;
				OpisTask.Location = new Point(100, 39);
				OpisTask.Text = PomocneFunkcije.stringwithrows(taskovi[t].Opis, 40);
				OpisTask.Size = new Size(35, 13);
				OpisTask.Click += new EventHandler(panelclickzaedit);

				var datumtaska = new Label();
				datumtaska.AutoSize = true;
				datumtaska.Location = new Point(334, 73);
				DateTime datumvalidnosti = stringtodate.Stringtodatum(taskovi[t].DatumValidnosti);
				datumtaska.Text = datumvalidnosti.ToString(format: "dd.MM.yyyy");

				var kopiraj = new Label();
				kopiraj.AutoSize = true;
				kopiraj.Location = new Point(350, 4);
				kopiraj.Text = "Kopiraj";
				kopiraj.Font = new Font(kopiraj.Font, FontStyle.Bold);
				kopiraj.Click += new EventHandler(KopirajClick);

				var panel = new Panel();
				panel.Location = new Point(panX, katy + razmak);
				panel.Size = new Size(410, 98);
				panel.BorderStyle = BorderStyle.FixedSingle;
				panel.BackColor = Color.AliceBlue;
				panel.Controls.Add(naslovtaska);
				panel.Controls.Add(checkbox);
				panel.Controls.Add(OpisTask);
				panel.Controls.Add(datumtaska);
				panel.Controls.Add(kopiraj);
				panel.Click += new EventHandler(panelclickzaedit);
				this.Controls.Add(panel);
				razmak += (98 + 10);
			}
		}

        private void loadsorrpogrupi()
        {
			int razmak = 0;
			int katx = 35;
			int katy = 67;


			int panX = 85;
			//int panY = 119;
			//int razmakpanel = 0;
			var grupe = konekcija.GlavneObaveze.Where(X => X.Profiltabela.ID_Profil == trenutniprofilId).ToList();


			grupe = grupe.GroupBy(p => p.Grupa.Naziv)
			.Select(g => g.First())
			.ToList();

			int brojgrupa = grupe.Count();
			var taskovi = new List<GlavneObavezeTabela>();


			taskovi = konekcija.GlavneObaveze.ToList();


			taskovi = taskovi.Where(X => X.Profiltabela.ID_Profil.Equals(trenutniprofilId)).ToList();
			foreach (var g in grupe)
			{
				var taskovi2 = taskovi.Where(K => K.Grupa.Naziv == g.Grupa.Naziv).ToList();

				if (sorttabela.PrikazArhive == "No")
				{
					taskovi2 = taskovi2.Where(x => x.Arhiva == "No").ToList();
				}
				else
				{
					taskovi2 = taskovi2.Where(x => x.Arhiva == "Yes").ToList();
				}
				if (sorttabela.PrikazZavršenih == "No")
				{
					taskovi2 = taskovi2.Where(x => x.Status == "NeZavrseno").ToList();
				}

				int brojtaskova = taskovi2.Count;


				if (brojtaskova>0 && taskovi2.Where(x=>x.Grupa.Naziv==g.Grupa.Naziv).ToList().Count>0)
				{
					var KategorijaName = new Label();
					KategorijaName.BackColor = Color.Transparent;
					KategorijaName.Name = g.Grupa.Naziv;
					KategorijaName.AutoSize = true;
					KategorijaName.Location = new Point(katx, katy + razmak);
					KategorijaName.Font = new Font(KategorijaName.Font, FontStyle.Bold);
					KategorijaName.Text = g.Grupa.Naziv + $"({g.Grupa.Toggle})";
					KategorijaName.Size = new Size(171, 39);
					KategorijaName.Font = new Font(KategorijaName.Font.Name, 25, KategorijaName.Font.Style, KategorijaName.Font.Unit);
					KategorijaName.Click += new EventHandler(Group_click);
					this.Controls.Add(KategorijaName);


					razmak += (39 + 10);
				}

				if (g.Grupa.Toggle == "-" || sorttabela.PoGrupi=="No")
				{
					Prikazitaskove(brojtaskova, taskovi2, ref panX, ref razmak, katy, g.Grupa.Naziv);


				}

			}


		}

		private void Prikazitaskove(int brojtaskova, List<GlavneObavezeTabela> taskovi, ref int panX, ref int razmak, int katy, string nazivgrupe)
		{
			//taskovi = new List<GlavneObavezeTabela>();


			//taskovi = konekcija.GlavneObaveze.ToList();


			//taskovi = taskovi.Where(X => X.Profiltabela.ID_Profil.Equals(trenutniprofilId)).ToList();
          
			//taskovi = taskovi.Where(K => K.Grupa.Naziv == nazivgrupe).ToList();
            if (sorttabela.PoNazivu == "Yes")
            {
				taskovi = taskovi.OrderBy(x => x.NazivObaveze).ToList();
            }

			if (sorttabela.PoDatumu == "Yes")
			{

				taskovi = taskovi
					  .OrderByDescending(X => stringtodate.Stringtodatum(X.DatumValidnosti))
					  .ToList();

			}
			brojtaskova = taskovi.Count();


			for (int t = 0; t < brojtaskova; t++)
			{

				var naslovtaska = new Label();
				naslovtaska.Name = "NaslovTaska";
				naslovtaska.AutoSize = true;
				naslovtaska.Location = new Point(99, 0);
				naslovtaska.Font = new Font(naslovtaska.Font, FontStyle.Bold);
				naslovtaska.Text = taskovi[t].NazivObaveze;
				naslovtaska.Size = new Size(68, 22);
				naslovtaska.Font = new Font(naslovtaska.Font.Name, 13, naslovtaska.Font.Style, naslovtaska.Font.Unit);
				naslovtaska.Click += new EventHandler(panelclickzaedit);

				var checkbox = new Label();
				checkbox.AutoSize = false;
				checkbox.Location = new Point(-1, -1);
				checkbox.Font = new Font(naslovtaska.Font, FontStyle.Bold);
				checkbox.Size = new Size(94, 98);
				checkbox.BackColor = Color.White;
				checkbox.BorderStyle = BorderStyle.FixedSingle;
				checkbox.Click += new EventHandler(b_Click);

				if (taskovi[t].Status == "Zavrseno")
				{

					checkbox.Image = Resources.hciicon;

				}
				else
				{
					checkbox.Image = null;
				}
				var OpisTask = new Label();
				OpisTask.AutoSize = true;
				OpisTask.Location = new Point(100, 39);
				OpisTask.Text = PomocneFunkcije.stringwithrows(taskovi[t].Opis, 40);
				OpisTask.Click += new EventHandler(panelclickzaedit);



				//+ taskovi[t].Opis.Substring(10, 20);
				OpisTask.Size = new Size(35, 13);

				//var datumtaska = new Label();
				//datumtaska.AutoSize = true;
				//datumtaska.Location = new Point(334, 73);
				//DateTime datumvalidnosti = stringtodate.Stringtodatum(taskovi[t].DatumValidnosti);
				//datumtaska.Text = datumvalidnosti.ToString(format: "dd.MM.yyyy");

				var datumtaska = new Label();
				datumtaska.AutoSize = true;
				datumtaska.Location = new Point(334, 73);
				DateTime datumvalidnosti = stringtodate.Stringtodatum(taskovi[t].DatumValidnosti);
				datumtaska.Text = datumvalidnosti.ToString(format: "dd.MM.yyyy");

				var kopiraj = new Label();
				kopiraj.AutoSize = true;
				kopiraj.Location = new Point(350, 4);
				kopiraj.Text = "Kopiraj";
				kopiraj.Font= new Font(kopiraj.Font, FontStyle.Bold);
				kopiraj.Click += new EventHandler(KopirajClick);



				var panel = new Panel();
				panel.Location = new Point(panX, katy + razmak);
				panel.Size = new Size(410, 98);
				panel.BorderStyle = BorderStyle.FixedSingle;
				panel.BackColor = Color.AliceBlue;
				panel.Controls.Add(naslovtaska); 
				panel.Controls.Add(checkbox);
				panel.Controls.Add(OpisTask);
				panel.Controls.Add(datumtaska);
				panel.Controls.Add(kopiraj);
				panel.Click += new EventHandler(panelclickzaedit);
				this.Controls.Add(panel);
				razmak += (98 + 10);



			}
		}

		void Group_click(object sender, EventArgs e)
		{
			int scrollvalue = this.VerticalScroll.Value;
			string naziv = ((System.Windows.Forms.Label)sender).Name;

			GlavneGrupa grupa = konekcija.GlavneGrupa.Where(X => X.Naziv == naziv).FirstOrDefault();

			if (grupa.Toggle == "+")
			{

				grupa.Toggle = "-";



			}
			else
			{

				grupa.Toggle = "+";

			}
			konekcija.SaveChanges();

			loadform(scrollvalue);



		}
		void panelclickzaedit(object sender, EventArgs e)
		{
			int scrollvalue = this.VerticalScroll.Value;
			Panel Panel;

			if (sender is Label)
			{
				Label lab = sender as Label;
				Panel = ((Panel)lab.Parent);

			}
			else
			{
				Panel = ((Panel)sender);

			}

			
			object checkboxlabel = Panel.Controls.Find("NaslovTaska", true).SingleOrDefault();
			string nazivzapretragu = ((System.Windows.Forms.Label)checkboxlabel).Text;
			GlavneObavezeTabela task = konekcija.GlavneObaveze.Where(x => x.Profiltabela.ID_Profil == trenutniprofilId).ToList()
				.Where(x => x.NazivObaveze.Equals(nazivzapretragu)).FirstOrDefault();
			TabPage ovajtab = ((TabPage)this.Parent);
			ovajtab.Controls.Clear();
			DodajEditForm form = new DodajEditForm(task.ID_Glavne,"Glavne");
			form.TopLevel = false;
			ovajtab.Controls.Add(form);
			form.Dock = DockStyle.Fill;
			form.Show();
		}
		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void myCheckBox1_CheckedChanged(object sender, EventArgs e)
		{

		}

		private void myCheckBox1_CheckedChanged_1(object sender, EventArgs e)
		{

		}

		private void label1_Click_1(object sender, EventArgs e)
		{

		}

		private void label3_Click(object sender, EventArgs e)
		{

		}

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

		void KopirajClick(object sender, EventArgs e)
		{
			int scrollvalue = this.VerticalScroll.Value;

			Label kopiraj = sender as Label;

			var Panel = ((Panel)kopiraj.Parent);
			object checkboxlabel = Panel.Controls.Find("NaslovTaska", true).SingleOrDefault();
			string nazivzapretragu = ((System.Windows.Forms.Label)checkboxlabel).Text;
			GlavneObavezeTabela task = konekcija.GlavneObaveze.Where(x => x.Profiltabela.ID_Profil == trenutniprofilId).ToList()
				.Where(x => x.NazivObaveze.Equals(nazivzapretragu)).FirstOrDefault();

			task.NazivObaveze = task.NazivObaveze + "(copy)";

			konekcija.GlavneObaveze.Add(task);
			konekcija.SaveChanges();
			MessageBox.Show("obaveza kopirana");

			loadform(0);


		}

	}
}
