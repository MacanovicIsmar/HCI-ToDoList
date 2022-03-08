using HCI_ToDoList.Dnevne;
using HCI_ToDoList.Dogadjaji;
using HCI_ToDoList.Entity_Class;
using HCI_ToDoList.GlavneObaveze;
using HCI_ToDoList.Home;
using HCI_ToDoList.Properties;
using HCI_ToDoList.Sedmicne;
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

namespace HCI_ToDoList.DodajObavezu
{
	public partial class DodajEditForm : Form
	{
		ConnectionTobase konekcija = Connect.DB;
		static int trenutniprofil_Id;
		private int Obaveza_Id;
		public string v;
		public int vrsta;

		public DodajEditForm()
		{
			InitializeComponent();
			trenutniprofil_Id = konekcija.trenutniprofil.FirstOrDefault().Profil_Id;
			loadform();
			Obaveza_Id = 0;
			
		}

		public DodajEditForm(int Obaveza_Id, string v) :this()
		{
			this.Obaveza_Id = Obaveza_Id;
			this.v = v;
			
			loadform();
		}

		public DodajEditForm(int vrsta):this()
		{
			this.vrsta = vrsta;
			loadform();
		}

		private void loadform()
		{
			button1.Hide();
			List<string> Tip = new List<string> { "Glavne", "Sedmicne", "Dnevne" };


			Combobox_Vrstaobaveze.DataSource = Tip.ToList();
			Combobox_Vrstaobaveze.SelectedIndex = vrsta;

			if (vrsta == 1)
			{
				DayOfWeek currentDay = DateTime.Now.DayOfWeek;
				int daysTillendoftheweek = DayOfWeek.Saturday + 1 - currentDay;

				DateTime currentWeekendendDate = DateTime.Now.AddDays(daysTillendoftheweek);


				dateTimePicker1.Value = currentWeekendendDate;
				this.dateTimePicker1.Enabled = false;


			}
			else if (vrsta == 2)
			{

				this.dateTimePicker1.Enabled = false;
				dateTimePicker1.Value = DateTime.Now;


			}







			
			
			dateTimePicker1.Format = DateTimePickerFormat.Custom;
			// Display the date as "Mon 27 Feb 2012".  
			dateTimePicker1.CustomFormat = "dd.MM.yyyy";
			dateTimePicker1.Checked = true; //samo kod sedmicnih nema datuma

			

			//21.4.2021  da li editujemo
			if (v == "Sedmicne" && Obaveza_Id != 0)
			{
				    button1.Show();		
					SedmicneObavezeTabela obaveza = konekcija.SedmicneObaveze.Where(X => X.Sedmicne_Id == Obaveza_Id).FirstOrDefault();
				    ChecklboxLabel.Image = obaveza.Status == "Zavrseno" ? Resources.hciiconmini : null;
					Combobox_Vrstaobaveze.SelectedIndex = 1;
					Combobox_Vrstaobaveze.Enabled = false;
					textboxgrupa.Text = obaveza.Grupa.Naziv;
					textboxnaziv.Text = obaveza.NazivObaveze;
					RichtextboxDetalji.Text = obaveza.Opis;
					checboxarhiva.Image = obaveza.Arhiva == "Yes" ? Resources.hciiconmini : null;
				  
				    this.dateTimePicker1.Enabled = false;

				    DayOfWeek currentDay = DateTime.Now.DayOfWeek;
				    int daysTillendoftheweek = DayOfWeek.Saturday + 1 - currentDay;

				    DateTime currentWeekendendDate = DateTime.Now.AddDays(daysTillendoftheweek);


				    dateTimePicker1.Value = currentWeekendendDate;
				    this.dateTimePicker1.Enabled = false;

				




			}
			if (v == "Dnevne" && Obaveza_Id != 0)
			{
 
				    button1.Show();
				    DnevneObavezeTabela obaveza = konekcija.DnevneObaveze.Where(X => X.Dnevne_Id == Obaveza_Id).FirstOrDefault();
					ChecklboxLabel.Image = obaveza.Status == "Zavrseno"? 
					Resources.hciiconmini:null;				
					Combobox_Vrstaobaveze.SelectedIndex = 2;
					Combobox_Vrstaobaveze.Enabled = false;
					textboxgrupa.Text = obaveza.Grupa.Naziv;
					textboxnaziv.Text = obaveza.NazivObaveze;
					RichtextboxDetalji.Text = obaveza.Opis;
				checboxarhiva.Image = obaveza.Arhiva == "Yes" ? Resources.hciiconmini : null;





			}
			if (v == "Glavne" && Obaveza_Id != 0)
			{
				
				
					button1.Show();
					GlavneObavezeTabela obaveza = konekcija.GlavneObaveze.Where(X => X.ID_Glavne == Obaveza_Id).FirstOrDefault();

					if (obaveza.Status == "Zavrseno")
					{

						ChecklboxLabel.Image = Resources.hciiconmini;


					}
					else
					{

						ChecklboxLabel.Image = null;


					}


					Combobox_Vrstaobaveze.SelectedIndex = 0;
					Combobox_Vrstaobaveze.Enabled = false;
					textboxgrupa.Text = obaveza.Grupa.Naziv;
					textboxnaziv.Text = obaveza.NazivObaveze;
					RichtextboxDetalji.Text = obaveza.Opis;
					this.dateTimePicker1.Enabled = true;
					dateTimePicker1.Value = stringtodate.Stringtodatum(obaveza.DatumValidnosti);
				checboxarhiva.Image = obaveza.Arhiva == "Yes" ? Resources.hciiconmini : null;





			}

		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void ChecklboxLabel_Click(object sender, EventArgs e)
		{
			ChecklboxLabel.Image = ChecklboxLabel.Image == null ? Resources.hciiconmini : null;

		}

		private void Sacuvaj_Click(object sender, EventArgs e)
		{

			//validacija 
			if (Validacija.validirajtext(textboxnaziv.Text, "niste unjeli naziv obaveze") &&
			   Validacija.validirajtext(textboxgrupa.Text, "niste unjeli grupu obaveze")
				)
			{




			}
			else
			{

				MessageBox.Show(Validacija.poruka);
				return;
			}


			//SACUVAJ Sedmcine
			if (Combobox_Vrstaobaveze.SelectedItem.ToString() == "Sedmicne")
			{

				SacuvajSedmicne();
			
			
			}

			//sacuvaj glavne 
			if (Combobox_Vrstaobaveze.SelectedItem.ToString() == "Glavne")
			{
				SacuvajGlavne();
			
			}
			
			//sacuvaj Dnevne
			if (Combobox_Vrstaobaveze.SelectedItem.ToString() == "Dnevne")
			{

				Sacuvajdnevne();

			}

			












			}

		private void Sacuvajdnevne()
		{
			DnevneObavezeTabela dnevneObaveze; //= new DnevneObavezeTabela();

			if (Obaveza_Id != 0)
			{
				dnevneObaveze = konekcija.DnevneObaveze.Where(x => x.Dnevne_Id == Obaveza_Id).FirstOrDefault();
			}
			else
			{
				dnevneObaveze = new DnevneObavezeTabela();
			}


			
			
			dnevneObaveze.NazivObaveze = textboxnaziv.Text;		
			DnevneGrupa grupa = konekcija.DnevneGrupa.Where(X => X.Naziv == textboxgrupa.Text).FirstOrDefault();

				if (grupa == null)
				{

					grupa = new DnevneGrupa();
					grupa.Naziv = textboxgrupa.Text;
					grupa.Toggle = "-";
					konekcija.DnevneGrupa.Add(grupa);
					konekcija.SaveChanges();



				}

			dnevneObaveze.Grupa = grupa;


				dnevneObaveze.Opis =Validacija.validirajtext(RichtextboxDetalji.Text)? 
					RichtextboxDetalji.Text: "Nema opisa";

	
				dnevneObaveze.Status = ChecklboxLabel.Image == null? 
					"NeZavrseno": "Zavrseno";


			
			




			//dodamo datum obavezi 
			dnevneObaveze.DatumKreiranja = dateTimePicker1.Value.ToString(format: "dd.MM.yyyy");

			Profil_Tabela profil = konekcija.Profil.Where(X => X.ID_Profil == trenutniprofil_Id).FirstOrDefault();

			//dodamo krajni datum sedmice
			profil.DanasnjiDatum = dateTimePicker1.Value.ToString(format: "dd.MM.yyyy");



			dnevneObaveze.Profil = profil;
			dnevneObaveze.Arhiva = checboxarhiva.Image == null ?
					"No" : "Yes";
			string poruka = "uspjesno uredjena obaveza";
			if (Obaveza_Id == 0)
			{
				konekcija.DnevneObaveze.Add(dnevneObaveze);
				poruka = "uspjesno dodana obaveza";
				konekcija.SaveChanges();
				MessageBox.Show(poruka);
				Nazadnatab();
			}
			else
			{



				konekcija.SaveChanges();
				MessageBox.Show(poruka);


			}

			
		}

		private void Nazadnatab()
		{
			TabPage tab = ((TabPage)this.Parent);
			TabControl tabcontrol = tab.Parent as TabControl;

			if (tabcontrol.SelectedTab == tabcontrol.TabPages[0])
			{
				tab.Controls.Clear();
				HomeForm form = new HomeForm();
				form.TopLevel = false;
				tab.Controls.Add(form);
				form.Dock = DockStyle.Fill;
				form.Show();



			}
			if (tabcontrol.SelectedTab == tabcontrol.TabPages[1])
			{
				tab.Controls.Clear();
				GlavnaForm frm = new GlavnaForm();
				frm.TopLevel = false;
				tab.Controls.Add(frm);
				frm.Dock = DockStyle.Fill;
				frm.Show();



			}




			if (tabcontrol.SelectedTab == tabcontrol.TabPages[2])
			{
				tab.Controls.Clear();
				DnevneFrom frm = new DnevneFrom();
				frm.TopLevel = false;
				tab.Controls.Add(frm);
				frm.Dock = DockStyle.Fill;
				frm.Show();



			}

			if (tabcontrol.SelectedTab == tabcontrol.TabPages[3])
			{
				tab.Controls.Clear();
				SedmicneForm form = new SedmicneForm();
				form.TopLevel = false;
				tab.Controls.Add(form);
				form.Dock = DockStyle.Fill;
				form.Show();
			}
		}

		private void SacuvajGlavne()
		{

			//21.4.2021  obaveza
			GlavneObavezeTabela Glavnaobaveza;

			//21.4.2021  da li editujemo
			if (Obaveza_Id != 0)
			{
				Glavnaobaveza = konekcija.GlavneObaveze.Where(X => X.ID_Glavne == Obaveza_Id).FirstOrDefault();


			}
			else
			{
				Glavnaobaveza = new GlavneObavezeTabela();

			}
			Glavnaobaveza.NazivObaveze = textboxnaziv.Text;

			GlavneGrupa grupa = konekcija.GlavneGrupa.Where(X => X.Naziv == textboxgrupa.Text).FirstOrDefault();

			if (grupa == null)
			{

				grupa = new GlavneGrupa();
				grupa.Naziv = textboxgrupa.Text;
				grupa.Toggle = "-";
				konekcija.GlavneGrupa.Add(grupa);
				konekcija.SaveChanges();



			}

			Glavnaobaveza.Grupa = grupa;

			string testtext = RichtextboxDetalji.Text;


			Glavnaobaveza.Opis = Validacija.validirajtext(testtext) ==true?
				RichtextboxDetalji.Text:"Nema opisa";
			
				Glavnaobaveza.Status = ChecklboxLabel.Image == null?
					"NeZavrseno": "Zavrseno";

			Glavnaobaveza.Arhiva = checboxarhiva.Image == null ?
					"No" : "Yes";






			//dodamo datum obavezi 
			Glavnaobaveza.DatumValidnosti = dateTimePicker1.Value.ToString(format: "dd.MM.yyyy");

			Profil_Tabela profil = konekcija.Profil.Where(X => X.ID_Profil == trenutniprofil_Id).FirstOrDefault();

			//dodamo krajni datum sedmice
			profil.Datumkrajasedmice = dateTimePicker1.Value.ToString(format: "dd.MM.yyyy");


			Glavnaobaveza.Profiltabela = profil;
			//Glavnaobaveza.Arhiva = "No";

			string poruka = "uspjesno uredena obaveza";


			//21.4.2021  da li editujemo
			if (Obaveza_Id == 0)
			{
				konekcija.GlavneObaveze.Add(Glavnaobaveza);
				poruka = "uspjesno dodana obaveza";
				konekcija.SaveChanges();
				MessageBox.Show(poruka);
				Nazadnatab();
			}
			else
			{
				konekcija.SaveChanges();
				MessageBox.Show(poruka);


			}

			

		}

		private void SacuvajSedmicne()
		{
			SedmicneObavezeTabela Sedmicnaobaveza;

			//dodaj obavezu kod 
			if (Obaveza_Id == 0)
			{
				Sedmicnaobaveza = new SedmicneObavezeTabela();

			}
			else
			{
				Sedmicnaobaveza = konekcija.SedmicneObaveze.Where(X => X.Sedmicne_Id == Obaveza_Id).FirstOrDefault();

			}				
					//21.4.2021  obaveza
					
					
			Sedmicnaobaveza.NazivObaveze = textboxnaziv.Text;
		    SedmicneGrupa grupa = konekcija.SedmicneGrupa
			.Where(X => X.Naziv == textboxgrupa.Text).FirstOrDefault();
			if (grupa == null)
			{

				grupa = new SedmicneGrupa();
				grupa.Naziv = textboxgrupa.Text;
				grupa.Toggle = "-";
				konekcija.SedmicneGrupa.Add(grupa);
				konekcija.SaveChanges();



			}

			Sedmicnaobaveza.Grupa = grupa;
			//provjera da li ima opisa
			Sedmicnaobaveza.Opis = Validacija.validirajtext(RichtextboxDetalji.Text) == true ?
			RichtextboxDetalji.Text : "Nema opisa";

			//checkbox unos 
			Sedmicnaobaveza.Status = ChecklboxLabel.Image == null ?
			"NeZavrseno" : "Zavrseno";


			//dodamo datum obavezi 
			Sedmicnaobaveza.DatumValidnosti = dateTimePicker1.Value.ToString(format: "dd.MM.yyyy");

			Profil_Tabela profil = konekcija.Profil.Where(X => X.ID_Profil == trenutniprofil_Id).FirstOrDefault();

			


			Sedmicnaobaveza.Profil = profil;

					//checkbox unos 
			Sedmicnaobaveza.Arhiva = checboxarhiva.Image == null ?
						"No" : "Yes";

		   string poruka = "uspjesno uredena obaveza";






			//21.4.2021  da li editujemo
			if (Obaveza_Id == 0)
			{
				konekcija.SedmicneObaveze.Add(Sedmicnaobaveza);
				poruka = "uspjesno dodana obaveza";
				konekcija.SaveChanges();
				MessageBox.Show(poruka);
				Nazadnatab();
			}
			else
			{

				konekcija.SaveChanges();
				MessageBox.Show(poruka);


			}

					





				




			}

		

		private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
		{

		}

		private void Combobox_Vrstaobaveze_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (Combobox_Vrstaobaveze.SelectedItem.ToString() == "Sedmicne")
			{
				DayOfWeek currentDay = DateTime.Now.DayOfWeek;
				int daysTillendoftheweek = DayOfWeek.Saturday + 1 - currentDay;

				DateTime currentWeekendendDate = DateTime.Now.AddDays(daysTillendoftheweek);


				dateTimePicker1.Value = currentWeekendendDate;
				this.dateTimePicker1.Enabled = false;


			}
			else if (Combobox_Vrstaobaveze.SelectedItem.ToString() == "Dnevne")
			{

				this.dateTimePicker1.Enabled = false;
				dateTimePicker1.Value = DateTime.Now;

			}
			else
			{


				this.dateTimePicker1.Enabled = true;

			}
		}

		private void Nazad_Click(object sender, EventArgs e)
		{


			Nazadnatab();



			//tab.Controls.Clear();

			//if (sorttabela.Tip == "Sedmicne")
			//{


			//}
			//else if (sorttabela.Tip == "Dnevne")
			//{


			//}
			//else if (sorttabela.Tip == "Glavne")
			//{


			//}

















			//if (Combobox_Vrstaobaveze.SelectedItem.ToString() == "Sedmicne")
			//{
			//	//uzimamo ovaj tab
			//	TabPage ovajtab = ((TabPage)this.Parent);

			//	//ocistimo ovaj tab
			//	ovajtab.Controls.Clear();



			//	SedmicneForm form = new SedmicneForm();
			//	form.TopLevel = false;
			//	ovajtab.Controls.Add(form);
			//	form.Dock = DockStyle.Fill;
			//	form.Show();




			//}

			//if (Combobox_Vrstaobaveze.SelectedItem.ToString() == "Dnevne")
			//{
			//	//uzimamo ovaj tab
			//	TabPage ovajtab = ((TabPage)this.Parent);

			//	//ocistimo ovaj tab
			//	ovajtab.Controls.Clear();



			//	DnevneFrom form = new DnevneFrom();
			//	form.TopLevel = false;
			//	ovajtab.Controls.Add(form);
			//	form.Dock = DockStyle.Fill;
			//	form.Show();




			//}
		}

		private void label3_Click(object sender, EventArgs e)
		{

		}

		private void checboxarhiva_Click(object sender, EventArgs e)
		{
			checboxarhiva.Image = checboxarhiva.Image == null ? Resources.hciiconmini : null;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (v == "Sedmicne" && Obaveza_Id != 0)
			{

				SedmicneObavezeTabela obavezazaobrisati =
					konekcija.SedmicneObaveze
					.Where(X => X.Sedmicne_Id == Obaveza_Id).FirstOrDefault();

				konekcija.SedmicneObaveze.Remove(obavezazaobrisati);

				konekcija.SaveChanges();

				MessageBox.Show("obaveza uspjesno obrisana");

				//uzimamo ovaj tab
				TabPage ovajtab = ((TabPage)this.Parent);

				//ocistimo ovaj tab
				ovajtab.Controls.Clear();



				SedmicneForm form = new SedmicneForm();
				form.TopLevel = false;
				ovajtab.Controls.Add(form);
				form.Dock = DockStyle.Fill;
				form.Show();







			}

			if (v == "Glavne" && Obaveza_Id != 0)
			{

				var obavezazaobrisati =
					konekcija.GlavneObaveze.AsQueryable();

				GlavneObavezeTabela entity =
					obavezazaobrisati
					.Where(X => X.ID_Glavne == Obaveza_Id).FirstOrDefault();


				konekcija.GlavneObaveze.Remove(entity);

				konekcija.SaveChanges();

				MessageBox.Show("obaveza uspjesno obrisana");

				////uzimamo ovaj tab
				TabPage ovajtab = ((TabPage)this.Parent);

				////ocistimo ovaj tab
				ovajtab.Controls.Clear();



				Form form = new GlavnaForm();
				form.TopLevel = false;
				ovajtab.Controls.Add(form);
				form.Dock = DockStyle.Fill;
				form.Show();



			}
			if (v == "Dnevne" && Obaveza_Id != 0)
			{
				var obavezazaobrisati =
					konekcija.DnevneObaveze.AsQueryable();

				DnevneObavezeTabela entity =
					obavezazaobrisati
					.Where(X => X.Dnevne_Id == Obaveza_Id).FirstOrDefault();


				konekcija.DnevneObaveze.Remove(entity);

				konekcija.SaveChanges();

				MessageBox.Show("obaveza uspjesno obrisana");

				////uzimamo ovaj tab
				TabPage ovajtab = ((TabPage)this.Parent);

				////ocistimo ovaj tab
				ovajtab.Controls.Clear();



				Form form = new DnevneFrom();
				form.TopLevel = false;
				ovajtab.Controls.Add(form);
				form.Dock = DockStyle.Fill;
				form.Show();
			}
		}
	}
}
