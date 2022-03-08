using HCI_ToDoList.Properties;
using HCI_ToDoList.Entity_Class;
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
using HCI_ToDoList.DodajObavezu;
using HCI_ToDoList.Dogadjaji;
using HCI_ToDoList.GlavneObaveze;

namespace HCI_ToDoList.Dnevne
{
	public partial class DnevneFrom : Form
	{
		ConnectionTobase konekcija = Connect.DB;
		static int trenutniprofilId;
		public static SortiranjeTabela sorttabela;
		public DnevneFrom()
		{
			InitializeComponent();
			trenutniprofilId = konekcija.trenutniprofil.FirstOrDefault().Profil_Id;
			sorttabela =
			konekcija.Sortiranjetabela
			.Where(X => X.Profil.ID_Profil == trenutniprofilId)
			.Where(x => x.Tip == "Dnevne")
			.FirstOrDefault();
			loadform(0);
		}
		void b_click(object sender, EventArgs e)
		{
			Label checkbox = sender as Label;

			int scrollValue = this.VerticalScroll.Value;
			//MessageBox.Show(((System.Windows.Forms.Label)sender).Name + " clicked");
			var Panel = ((Label)sender).Parent;
			object checboxlabel = Panel.Controls.Find("NaslovTaska", true).SingleOrDefault();
			//MessageBox.Show(((System.Windows.Forms.Label)checboxlabel).Text + " clicked");
			string nazivzapretragu = ((System.Windows.Forms.Label)checboxlabel).Text;
			DnevneObavezeTabela task = konekcija.DnevneObaveze.Where(x=>x.Profil.ID_Profil==trenutniprofilId).ToList()
				.Where(x => x.NazivObaveze.Equals(nazivzapretragu)).FirstOrDefault();
			string Datum = DateTime.Today.ToString(format: "dd.MM.yyyy");

			
			StatistikaTabela stats = konekcija.Statistika
				.Where(X => X.Profil.ID_Profil == trenutniprofilId)
				.Where(X => X.Datum.Equals(Datum))
				.Where(X => X.TipObaveze=="Dnevne")
				.FirstOrDefault();

			if (stats == null)
			{

				stats = new StatistikaTabela();
				stats.Datum = Datum;
				stats.Profil = konekcija.Profil.Where(X => X.ID_Profil == trenutniprofilId).FirstOrDefault();
				stats.TipObaveze = "Dnevne";
				konekcija.Statistika.Add(stats);

			}
			if (task.Status == "Zavrseno")
			{
				task.Status = "NeZavrseno";
				stats.BrojOdrađeniObaveza = stats.BrojOdrađeniObaveza != 0 ? --stats.BrojOdrađeniObaveza : stats.BrojOdrađeniObaveza;
				checkbox.Image = null;
			}
			else
			{
				task.Status = "Zavrseno";
				stats.BrojOdrađeniObaveza++;
                if (sorttabela.BrisanjeZavrsenih == "Yes")
                {
					konekcija.DnevneObaveze.Remove(task);
                }
				checkbox.Image = Resources.hciicon;
			}
			

			
			
			


			konekcija.SaveChanges();

			//loadform(scrollValue);
		}
		private void loadform(int scrollValue)
		{
			if (trenutniprofilId == 0)
			{
				return;
			}

			string datumubazi = konekcija.Profil.Where(x => x.ID_Profil.Equals(trenutniprofilId)).FirstOrDefault().DanasnjiDatum;

			string danasnjidatum = DateTime.Today.ToString(format:"dd.MM.yyyy");
			if (datumubazi!=danasnjidatum)
			{

				uncheckobaveze(danasnjidatum);
			
			}






			Form ovaforma = this;
			ovaforma.Controls.Clear();

			Label naslov = new Label();
			naslov.Name = "naslov";
			naslov.Size = new Size(596, 42);
			naslov.Location = new Point(0, 0);
			naslov.BackColor = Color.DarkGray;
			naslov.Text = "Dnevne " + konekcija.Profil.Where(x => x.ID_Profil.Equals(trenutniprofilId)).FirstOrDefault().NazivProfila;
			naslov.Font = new Font(naslov.Font.Name, 20, naslov.Font.Style, naslov.Font.Unit);
			naslov.TextAlign = ContentAlignment.MiddleCenter;
			ovaforma.Controls.Add(naslov);
            if (sorttabela.BrisanjeZavrsenih == "Yes")
            {
				List<DnevneObavezeTabela> zavrsneDnevne = konekcija.DnevneObaveze.Where(x => x.Profil.ID_Profil == trenutniprofilId)
					.ToList().Where(x => x.Status == "Zavrseno").ToList();
				konekcija.DnevneObaveze.RemoveRange(zavrsneDnevne);
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

		private void uncheckobaveze(string danasnjidatum)
		{
			List<DnevneObavezeTabela> lista = konekcija.DnevneObaveze
				.Where(x => x.Profil.ID_Profil.Equals(trenutniprofilId))
				.Where(X=>X.Arhiva=="No")
				.ToList();

			foreach (var a in lista)
			{
				a.Status = "NeZavrseno";

			}

			Profil_Tabela profil = konekcija.Profil.Where(x => x.ID_Profil.Equals(trenutniprofilId)).FirstOrDefault();

			profil.DanasnjiDatum = danasnjidatum;

			MessageBox.Show("Dan resetovan");

			konekcija.SaveChanges();
			
				






		}

		private void loadnormal()
        {
			var taskovi = new List<DnevneObavezeTabela>();
			taskovi = konekcija.DnevneObaveze.ToList();
			taskovi = taskovi.Where(x => x.Profil.ID_Profil.Equals(trenutniprofilId)).ToList();




            if (sorttabela.PrikazArhive == "No")
            {
				taskovi = taskovi.Where(x => x.Arhiva == "No").ToList();
            }
            else
            {
				taskovi = taskovi.Where(x => x.Arhiva == "Yes").ToList();
            }
            if (sorttabela.PoNazivu == "Yes")
            {
				taskovi = taskovi.OrderBy(x => x.NazivObaveze).ToList();
            }
			if (sorttabela.PoDatumu == "Yes")
			{

				taskovi = taskovi
					  .OrderByDescending(X => stringtodate.Stringtodatum(X.DatumKreiranja))
					  .ToList();

			}

			if (sorttabela.PrikazZavršenih == "No")
            {
				taskovi = taskovi.Where(x => x.Status == "NeZavrseno").ToList();
            }

			//if (sorttabela.PoDatumu == "Yes")
			//{ 
			
			//taskovi= taskovi.Where(x => x.DatumAktivnosti == "NeZavrseno").ToList();

			//}


			int razmak = 0;
			int katx = 35;
			int katy = 67;


			int panX = 85;
			int panY = 119;
			int razmakpanel = 0;
			int brojtaskova = taskovi.Count();
			for(int t = 0; t < brojtaskova; t++)
            {
				var naslovtaska = new Label();
				naslovtaska.Name = "NaslovTaska";
				naslovtaska.AutoSize = true;
				naslovtaska.Location = new Point(99, 0);
				naslovtaska.Font = new Font(naslovtaska.Font, FontStyle.Bold);
				naslovtaska.Text = taskovi[t].NazivObaveze;
				naslovtaska.Size = new Size(68, 22);
				naslovtaska.Font = new Font(naslovtaska.Font.Name, 13, naslovtaska.Font.Style, naslovtaska.Font.Unit);
				naslovtaska.Click += new EventHandler(nasloveditclick);

				var checkbox = new Label();
				checkbox.AutoSize = false;
				checkbox.Location = new Point(-1, -1);
				checkbox.Font = new Font(naslovtaska.Font, FontStyle.Bold);
				checkbox.Size = new Size(94, 98);
				checkbox.BackColor = Color.White;
				checkbox.BorderStyle = BorderStyle.FixedSingle;
				checkbox.Click += new EventHandler(b_click);
				

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
				OpisTask.Text = PomocneFunkcije.stringwithrows(taskovi[t].Opis,40);
				OpisTask.Size = new Size(35, 13);
				OpisTask.Click += new EventHandler(panelclickzaedit);

				var datumtaska = new Label();
				datumtaska.AutoSize = true;
				datumtaska.Location = new Point(334, 73);
				DateTime datumvalidnosti = stringtodate.Stringtodatum(taskovi[t].DatumKreiranja);
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
			var grupe = konekcija.DnevneObaveze.Where(x => x.Profil.ID_Profil == trenutniprofilId).ToList();

			grupe = grupe.GroupBy(p => p.Grupa.Naziv)
			.Select(k => k.First())
			.ToList();



			int brojgrupa = grupe.Count();
			//var taskovi = new List<DnevneObavezeTabela>();
			var taskovi = konekcija.DnevneObaveze.AsQueryable();
			taskovi = taskovi.Where(x => x.Profil.ID_Profil.Equals(trenutniprofilId));

			foreach (var g in grupe)
			{

				List<DnevneObavezeTabela> taskovi2 = taskovi.Where(k => k.Grupa.Naziv == g.Grupa.Naziv).ToList();
				
				

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
					Prikazitaskove(brojtaskova, taskovi2, ref panX,  ref razmak, katy, g.Grupa.Naziv);
				}
			}
			//ovaforma.VerticalScroll.Value = scrollValue;
		}

        private void Prikazitaskove(int brojtaskova, List<DnevneObavezeTabela> taskovi, ref int panX,  ref int razmak, int katy, string nazivgrupe)
		{
			//taskovi = new List<DnevneObavezeTabela>();
			//taskovi = konekcija.DnevneObaveze.ToList();
			//taskovi = taskovi.Where(x => x.Profil.ID_Profil.Equals(trenutniprofilId)).ToList();
			
            if (sorttabela.PrikazArhive == "No")
            {
				taskovi = taskovi.Where(x => x.Arhiva == "No").ToList();
            }
            else
            {
				taskovi = taskovi.Where(x => x.Arhiva == "Yes").ToList();
            }
			taskovi = taskovi.Where(k => k.Grupa.Naziv == nazivgrupe).ToList();
			if (sorttabela.PoNazivu == "Yes")
            {
				taskovi = taskovi.OrderBy(x => x.NazivObaveze).ToList();
            }
			if (sorttabela.PoDatumu == "Yes")
			{

				taskovi = taskovi
					  .OrderByDescending(X => stringtodate.Stringtodatum(X.DatumKreiranja))
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
				naslovtaska.Click += new EventHandler(nasloveditclick);

				var checkbox = new Label();
				checkbox.AutoSize = false;
				checkbox.Location = new Point(-1, -1);
				checkbox.Font = new Font(naslovtaska.Font, FontStyle.Bold);
				checkbox.Size = new Size(94, 98);
				checkbox.BackColor = Color.White;
				checkbox.BorderStyle = BorderStyle.FixedSingle;
				checkbox.Click += new EventHandler(b_click);

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
				DateTime datumvalidnosti = stringtodate.Stringtodatum(taskovi[t].DatumKreiranja);
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

		private void nasloveditclick(object sender, EventArgs e)
		{
			object checkboxlabel = sender;
			string nazivzapretragu = ((System.Windows.Forms.Label)checkboxlabel).Text;
			DnevneObavezeTabela task = konekcija.DnevneObaveze.Where(x => x.Profil.ID_Profil == trenutniprofilId).ToList()
				.Where(x => x.NazivObaveze.Equals(nazivzapretragu)).FirstOrDefault();
			TabPage ovajtab = ((TabPage)this.Parent);
			ovajtab.Controls.Clear();
			DodajEditForm form = new DodajEditForm(task.Dnevne_Id, "Dnevne");
			form.TopLevel = false;
			ovajtab.Controls.Add(form);
			form.Dock = DockStyle.Fill;
			form.Show();
		}

		void Group_click(object sender,EventArgs e)
        {
			int scrollvalue = this.VerticalScroll.Value;
			string naziv = ((System.Windows.Forms.Label)sender).Name;
			DnevneGrupa grupa = konekcija.DnevneGrupa.Where(x => x.Naziv == naziv).FirstOrDefault();
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
		void panelclickzaedit(object sender,EventArgs e)
        {
			var obj= this.Parent;


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
			DnevneObavezeTabela task = konekcija.DnevneObaveze.Where(x => x.Profil.ID_Profil == trenutniprofilId).ToList()
				.Where(x => x.NazivObaveze.Equals(nazivzapretragu)).FirstOrDefault();
			TabPage ovajtab = ((TabPage)this.Parent);
			ovajtab.Controls.Clear();
			DodajEditForm form = new DodajEditForm(task.Dnevne_Id,"Dnevne");
			form.TopLevel = false;
			ovajtab.Controls.Add(form);
			form.Dock = DockStyle.Fill;
			form.Show();
        }
		
		private void KopirajClick(object sender, EventArgs e)
		{
			int scrollvalue = this.VerticalScroll.Value;

			Label kopiraj = sender as Label;

			var Panel = ((Panel)kopiraj.Parent);
			object checkboxlabel = Panel.Controls.Find("NaslovTaska", true).SingleOrDefault();
			string nazivzapretragu = ((System.Windows.Forms.Label)checkboxlabel).Text;
			DnevneObavezeTabela task = konekcija.DnevneObaveze.Where(x => x.Profil.ID_Profil == trenutniprofilId).ToList()
				.Where(x => x.NazivObaveze.Equals(nazivzapretragu)).FirstOrDefault();

			task.NazivObaveze = task.NazivObaveze + "(copy)";

			konekcija.DnevneObaveze.Add(task);
			konekcija.SaveChanges();
			MessageBox.Show("obaveza kopirana");

			loadform(0);
		}


		private void DnevneFrom_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
