using HCI_ToDoList.Controller;
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

namespace HCI_ToDoList.Sedmicne
{
	public partial class SedmicneForm : Form
	{
		ConnectionTobase konekcija = Connect.DB;
		static int trenutniprofilId;
		//static List<SedmicneObavezeTabela> taskovi=new List<SedmicneObavezeTabela>();
		public static SortiranjeTabela sorttabela;




		public SedmicneForm()
		{
			InitializeComponent();
			trenutniprofilId = konekcija.trenutniprofil.FirstOrDefault().Profil_Id;

			sorttabela =
			konekcija.Sortiranjetabela
			.Where(X => X.Profil.ID_Profil == trenutniprofilId)
			.Where(x => x.Tip == "Sedmicne")
			.FirstOrDefault();

			SedmicneObavezeFunkcije.uncheckobaveze(trenutniprofilId);



			//loadform2 += loadform;
			loadform(0);
			//loadform4();
		}



		void b_Click(object sender, EventArgs e)
		{


			Label checkbox = sender as Label;
			
			
			int scrollvalue = this.VerticalScroll.Value;

			

			//MessageBox.Show(((System.Windows.Forms.Label)sender).Name + " clicked");

			var Panel = ((Label)sender).Parent;

			object checboxlabel = Panel.Controls.Find("NaslovTaska", true).SingleOrDefault();

			//MessageBox.Show(((System.Windows.Forms.Label)checboxlabel).Text + " clicked");

			string nazivzapretragu = ((System.Windows.Forms.Label)checboxlabel).Text;

			SedmicneObavezeTabela task = konekcija.SedmicneObaveze
				.Where(X=>X.Profil.ID_Profil==trenutniprofilId)
				.ToList()
				.Where(X => X.NazivObaveze.Equals(nazivzapretragu))
				.FirstOrDefault();



			//pracenje statistike 

			//datum za pretragu
			string Datum= DateTime.Today.ToString(format:"dd.MM.yyyy");

			StatistikaTabela stats = konekcija.Statistika
				.Where(X => X.Profil.ID_Profil == trenutniprofilId)
				.Where(X => X.Datum.Equals(Datum))
				.Where(X => X.TipObaveze == "Sedmicne")
				.FirstOrDefault();

			if (stats == null)
			{

				stats = new StatistikaTabela();
				stats.Datum = Datum;
				stats.Profil = konekcija.Profil.Where(X=>X.ID_Profil==trenutniprofilId).FirstOrDefault();
				stats.TipObaveze = "Sedmicne";
				konekcija.Statistika.Add(stats);

			}

			//kraj pracanje statistike 



			if (task.Status == "Zavrseno")
			{

				task.Status = "NeZavrseno";

				//pracenje statistike 
				stats.BrojOdrađeniObaveza = stats.BrojOdrađeniObaveza != 0 ? --stats.BrojOdrađeniObaveza: stats.BrojOdrađeniObaveza;
				checkbox.Image = null;
				//kraj pracenja statistike

			}
			else
			{
				task.Status = "Zavrseno";
				stats.BrojOdrađeniObaveza++;
				if (sorttabela.BrisanjeZavrsenih == "Yes")
				{

					konekcija.SedmicneObaveze.Remove(task);
				
				
				
				}
				checkbox.Image = Resources.hciicon;



			}

			
			konekcija.SaveChanges();
			
			//loadform(scrollvalue);




			//var ta = Task.Delay(3000);
			//ta.Wait();

			


			//loadform();

		}



		private void loadform(int scrollvalue)
		{
			
			//ako nije selektovan profil izadi iz forme
			if (trenutniprofilId == 0)
			{

				return;
			
			}

			Form ovaforma = this;
			
			ovaforma.Controls.Clear(); //ovo je rijesilo problem


			
			


			Label naslov = new Label();
			naslov.Name = "naslov";
			naslov.Size = new Size(596, 42);
			naslov.Location = new Point(0, 0);
			naslov.BackColor = Color.DarkGray;
			naslov.Text = "Sedmicne "+ konekcija.Profil.Where(X=>X.ID_Profil.Equals(trenutniprofilId)).FirstOrDefault().NazivProfila;
			naslov.Font = new Font(naslov.Font.Name, 20, naslov.Font.Style, naslov.Font.Unit);
			naslov.TextAlign = ContentAlignment.MiddleCenter;

			ovaforma.Controls.Add(naslov);


			if (sorttabela.BrisanjeZavrsenih == "Yes")
			{

	List<SedmicneObavezeTabela> zavrseneSedmicne = konekcija.SedmicneObaveze.Where(X => X.Profil.ID_Profil == trenutniprofilId)
					.ToList().Where(X => X.Status == "Zavrseno").ToList();

				konekcija.SedmicneObaveze.RemoveRange(zavrseneSedmicne);
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
			var taskovi = new List<SedmicneObavezeTabela>();


			//uzimanje svih obaveza
			taskovi = konekcija.SedmicneObaveze.ToList();

			//uzimanje obaveza od profila 
			taskovi = taskovi.Where(X => X.Profil.ID_Profil.Equals(trenutniprofilId)).ToList();

			//uzimanje ne arhiviranih obaveza 
			if (sorttabela.PrikazArhive == "No")
			{
				taskovi = taskovi.Where(X => X.Arhiva == "No").ToList();
			}
			else
			{
				taskovi = taskovi.Where(X => X.Arhiva == "Yes").ToList();

			}

			if (sorttabela.PoNazivu == "Yes")
			{

				taskovi = taskovi.OrderBy(X => X.NazivObaveze).ToList();




			}
			if (sorttabela.PoDatumu == "Yes")
			{

				taskovi = taskovi
					  .OrderByDescending(X => stringtodate.Stringtodatum(X.DatumValidnosti))
					  .ToList();

			}
			if (sorttabela.PrikazZavršenih == "No")
			{

				taskovi = taskovi.Where(X => X.Status == "NeZavrseno").ToList();
			
			
			
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
				//label naslov Taska 

				var naslovtaska = new Label();
				naslovtaska.Name = "NaslovTaska";
				naslovtaska.AutoSize = true;
				naslovtaska.Location = new Point(99, 0);
				naslovtaska.Font = new Font(naslovtaska.Font, FontStyle.Bold);
				naslovtaska.Text = taskovi[t].NazivObaveze;
				naslovtaska.Size = new Size(68, 22);
				naslovtaska.Font = new Font(naslovtaska.Font.Name, 13, naslovtaska.Font.Style, naslovtaska.Font.Unit);


				//checkbox taska 

				var checkbox = new Label();
				checkbox.AutoSize = false;
				checkbox.Location = new Point(-1, -1);
				checkbox.Font = new Font(naslovtaska.Font, FontStyle.Bold);
				//checkbox.Font= new Font(naslovtaska.Font.Name, 13, naslovtaska.Font.Style, naslovtaska.Font.Unit);
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
				//kraj checkboxa


				//Description label  / Opis taska 
				var OpisTask = new Label();
				OpisTask.AutoSize = true;
				OpisTask.Location = new Point(100, 39);
				//naslovtaska.Font = new Font(naslovtaska.Font, FontStyle.Bold);
				OpisTask.Text = taskovi[t].Opis;
				OpisTask.Size = new Size(35, 13);
				//naslovtaska.Font = new Font(naslovtaska.Font.Name,9, naslovtaska.Font.Style, naslovtaska.Font.Unit);

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

				//panel je kontejener koji sadrzi 2 labela i checboxlabel
				var panel = new Panel();
				panel.Location = new Point(panX, katy + razmak);
				panel.Size = new Size(410, 98);
				panel.BorderStyle = BorderStyle.FixedSingle;
				panel.BackColor = Color.AliceBlue;
				panel.Controls.Add(naslovtaska); //index 1 ili 0
				panel.Controls.Add(checkbox);//index 1 ili 2
				panel.Controls.Add(OpisTask);//index 3 ili 4
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





			//vadimo sedmicne iz baze
			var grupe = konekcija.SedmicneObaveze.Where(X => X.Profil.ID_Profil == trenutniprofilId).ToList();



			//uzimamo samo grupe
			grupe = grupe.GroupBy(p => p.Grupa.Naziv)
			.Select(g => g.First())
			.ToList();


			//brojimo grupe
			int brojgrupa = grupe.Count();



			var taskovi = new List<SedmicneObavezeTabela>();


			taskovi = konekcija.SedmicneObaveze.ToList();


			taskovi = taskovi.Where(X => X.Profil.ID_Profil.Equals(trenutniprofilId)).ToList();

			








			foreach (var g in grupe)
			{

				


				var taskovi2 = taskovi.Where(K => K.Grupa.Naziv == g.Grupa.Naziv).ToList();
				//label grupe


				// sortiranje 
				//uzimanje ne arhiviranih obaveza ili arhiviranih
				if (sorttabela.PrikazArhive == "No")
				{
					taskovi2 = taskovi2.Where(X => X.Arhiva == "No").ToList();
				}
				else
				{
					taskovi2 = taskovi2.Where(X => X.Arhiva == "Yes").ToList();

				}



				if (sorttabela.PrikazZavršenih == "No")
				{

					taskovi2 = taskovi2.Where(X => X.Status == "NeZavrseno").ToList();



				}
				int brojtaskova = taskovi2.Count();
				//if (taskovi.Count == 0)
				//{

				//	continue;

				//}
				if (brojtaskova > 0 && taskovi2.Where(X=>X.Grupa.Naziv==g.Grupa.Naziv).ToList().Count>0)
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

					//uzimamo taskove grupe





					if (g.Grupa.Toggle == "-" || sorttabela.PoGrupi == "No")
					{
						Prikazitaskove(brojtaskova, taskovi2, ref panX, ref razmak, katy, g.Grupa.Naziv);


					}

				}





			}

			//scroll
			//ovaforma.VerticalScroll.Value = scrollvalue;











		}

		private void Prikazitaskove(int brojtaskova, List<SedmicneObavezeTabela> taskovi, ref int panX, ref int  razmak, int katy, string nazivgrupe)
		{
			taskovi = new List<SedmicneObavezeTabela>();


			taskovi = konekcija.SedmicneObaveze.ToList();


			taskovi = taskovi.Where(X => X.Profil.ID_Profil.Equals(trenutniprofilId)).ToList();

			//uzimanje ne arhiviranih obaveza ili arhiviranih
			if (sorttabela.PrikazArhive == "No")
			{
				taskovi = taskovi.Where(X => X.Arhiva == "No").ToList();
			}
			else
			{
				taskovi = taskovi.Where(X => X.Arhiva == "Yes").ToList();

			}




			taskovi = taskovi.Where(K => K.Grupa.Naziv == nazivgrupe).ToList();
			if (sorttabela.PoNazivu == "Yes")
			{

				taskovi = taskovi.OrderBy(X => X.NazivObaveze).ToList();




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
				//label naslov Taska 

				var naslovtaska = new Label();
				naslovtaska.Name = "NaslovTaska";
				naslovtaska.AutoSize = true;
				naslovtaska.Location = new Point(99, 0);
				naslovtaska.Font = new Font(naslovtaska.Font, FontStyle.Bold);
				naslovtaska.Text = taskovi[t].NazivObaveze;
				naslovtaska.Size = new Size(68, 22);
				naslovtaska.Font = new Font(naslovtaska.Font.Name, 13, naslovtaska.Font.Style, naslovtaska.Font.Unit);


				//checkbox taska 

				var checkbox = new Label();
				checkbox.AutoSize = false;
				checkbox.Location = new Point(-1, -1);
				checkbox.Font = new Font(naslovtaska.Font, FontStyle.Bold);
				//checkbox.Font= new Font(naslovtaska.Font.Name, 13, naslovtaska.Font.Style, naslovtaska.Font.Unit);
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
				//kraj checkboxa


				//Description label  / Opis taska 
				var OpisTask = new Label();
				OpisTask.AutoSize = true;
				OpisTask.Location = new Point(100, 39);
				//naslovtaska.Font = new Font(naslovtaska.Font, FontStyle.Bold);
				OpisTask.Text = taskovi[t].Opis;
				OpisTask.Size = new Size(35, 13);
				//naslovtaska.Font = new Font(naslovtaska.Font.Name,9, naslovtaska.Font.Style, naslovtaska.Font.Unit);


				//Datum Taska
				var datumtaska = new Label();
				datumtaska.AutoSize = true;
				datumtaska.Location = new Point(334, 73);
				DateTime datumvalidnosti= stringtodate.Stringtodatum(taskovi[t].DatumValidnosti); 
				datumtaska.Text = datumvalidnosti.ToString(format:"dd.MM.yyyy");

				var kopiraj = new Label();
				kopiraj.AutoSize = true;
				kopiraj.Location = new Point(350, 4);
				kopiraj.Text = "Kopiraj";
				kopiraj.Font = new Font(kopiraj.Font, FontStyle.Bold);
				kopiraj.Click += new EventHandler(KopirajClick);


				//panel je kontejener koji sadrzi 2 labela i checboxlabel
				var panel = new Panel();
				panel.Location = new Point(panX, katy + razmak);
				panel.Size = new Size(410, 98);
				panel.BorderStyle = BorderStyle.FixedSingle;
				panel.BackColor = Color.AliceBlue;
				panel.Controls.Add(naslovtaska); //index 1 ili 0
				panel.Controls.Add(checkbox);//index 1 ili 2
				panel.Controls.Add(OpisTask);//index 3 ili 4
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

			SedmicneGrupa grupa = konekcija.SedmicneGrupa.Where(X => X.Naziv == naziv).FirstOrDefault();

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

			var Panel = ((Panel)sender); //uzimamo ovaj panel

			//pronalazimo label sa naslovom u panelu
			object checboxlabel = Panel.Controls.Find("NaslovTaska", true).SingleOrDefault();

			//vadimo ime  is naslovnog panela
			string nazivzapretragu = ((System.Windows.Forms.Label)checboxlabel).Text;

			//vadimo task koristeci ime naslovnog taska 
			SedmicneObavezeTabela task = konekcija.SedmicneObaveze
				.Where(X => X.Profil.ID_Profil == trenutniprofilId)
				.ToList()
				.Where(X => X.NazivObaveze.Equals(nazivzapretragu))
				.FirstOrDefault();


			//uzimamo ovaj tab
			TabPage ovajtab = ((TabPage)this.Parent);

			//ocistimo ovaj tab
			ovajtab.Controls.Clear();

			//uzimamo dodaj edit formu stavljamu u nju obavezu  pa sve to postavljamo na tab 
			DodajEditForm form = new DodajEditForm(task.Sedmicne_Id,"Sedmicne");
			form.TopLevel = false;
			ovajtab.Controls.Add(form);
			form.Dock = DockStyle.Fill;
			form.Show();





			//MessageBox.Show("Panel kliknut");







		
		
		}

        private void SedmicneForm_Load(object sender, EventArgs e)
        {

        }

		private void KopirajClick(object sender, EventArgs e)
		{
			int scrollvalue = this.VerticalScroll.Value;

			Label kopiraj = sender as Label;

			var Panel = ((Panel)kopiraj.Parent);
			object checkboxlabel = Panel.Controls.Find("NaslovTaska", true).SingleOrDefault();
			string nazivzapretragu = ((System.Windows.Forms.Label)checkboxlabel).Text;
			SedmicneObavezeTabela task = konekcija.SedmicneObaveze.Where(x => x.Profil.ID_Profil == trenutniprofilId).ToList()
				.Where(x => x.NazivObaveze.Equals(nazivzapretragu)).FirstOrDefault();

			task.NazivObaveze = task.NazivObaveze + "(copy)";

			konekcija.SedmicneObaveze.Add(task);
			konekcija.SaveChanges();
			MessageBox.Show("obaveza kopirana");

			loadform(0);
		}

	}
}