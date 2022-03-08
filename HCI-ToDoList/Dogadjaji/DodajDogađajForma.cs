using HCI_ToDoList.DodajObavezu;
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
	public partial class DodajDogađajForma : Form
	{
		ConnectionTobase konekcija = Connect.DB;
		static int trenutniprofilId;
		private int Obaveza_Id;
	

		//Dodaj Dogadaj
		public DodajDogađajForma()
		{
			InitializeComponent();
			trenutniprofilId = konekcija.trenutniprofil.FirstOrDefault().Profil_Id;
			loadform();
			Obaveza_Id = 0;
		}
		//edit Dogadaj
		public DodajDogađajForma(int Obaveza_Id):this()
		{
			this.Obaveza_Id = Obaveza_Id;		
			loadform();

		}




		private void loadform()
		{
			Form ovaforma = this;
			//ovaforma.Controls.Clear();

			Label naslov = new Label();
			naslov.Name = "naslov";
			naslov.Size = new Size(596, 42);
			naslov.Location = new Point(0, 0);
			naslov.BackColor = Color.DarkGray;
			naslov.Text = "Dodaj Dogadaj " +"Profil: " + konekcija.Profil.Where(x => x.ID_Profil.Equals(trenutniprofilId)).FirstOrDefault().NazivProfila;
			naslov.Font = new Font(naslov.Font.Name, 20, naslov.Font.Style, naslov.Font.Unit);
			naslov.TextAlign = ContentAlignment.MiddleCenter;
			ovaforma.Controls.Add(naslov);


			button1.Hide();
			

			this.dateTimePicker1.Enabled = true;
			dateTimePicker1.Value = DateTime.Today;
			dateTimePicker1.Format = DateTimePickerFormat.Custom;		
			dateTimePicker1.CustomFormat = "dd.MM.yyyy";

			if (Obaveza_Id != 0)
			{
				button1.Show();
				DogadajiTabela obaveza = konekcija.Dogadaji.Where(X => X.Događaji_Id == Obaveza_Id).FirstOrDefault();
				ChecklboxLabel.Image = obaveza.Status == "Zavrseno" ? Resources.hciiconmini : null;			
				textboxnaziv.Text = obaveza.NazivObaveze;
				RichtextboxDetalji.Text = obaveza.Opis;
				dateTimePicker1.Value = stringtodate.Stringtodatum(obaveza.DatumDogađaja);
			}
		}

		private void ChecklboxLabel_Click(object sender, EventArgs e)
		{
			ChecklboxLabel.Image = ChecklboxLabel.Image == null ? Resources.hciiconmini : null;
		}

		private void Sacuvaj_Click(object sender, EventArgs e)
		{
			//validacija 
			if (!Validacija.validirajtext(textboxnaziv.Text, "niste unjeli naziv obaveze"))
			{
				MessageBox.Show(Validacija.poruka);
				return;
			}

			DogadajiTabela Dogadaj;

			//dodaj obavezu kod 
			if (Obaveza_Id == 0)
			{
				Dogadaj = new DogadajiTabela();

			}
			else
			{
				Dogadaj = konekcija.Dogadaji.Where(X => X.Događaji_Id == Obaveza_Id).FirstOrDefault();

			}
			//21.4.2021  obaveza


			Dogadaj.NazivObaveze = textboxnaziv.Text;
			
			

			
			//provjera da li ima opisa
			Dogadaj.Opis = Validacija.validirajtext(RichtextboxDetalji.Text) == true ?
			RichtextboxDetalji.Text : "Nema opisa";

			//checkbox unos 
			Dogadaj.Status = ChecklboxLabel.Image == null ?
			"NeZavrseno" : "Zavrseno";


			//dodamo datum obavezi 
			Dogadaj.DatumDogađaja = dateTimePicker1.Value.ToString(format: "dd.MM.yyyy");

			Profil_Tabela profil = konekcija.Profil.Where(X => X.ID_Profil == trenutniprofilId).FirstOrDefault();

			


			Dogadaj.Profil = profil;

			
			string poruka = "uspjesno uredena obaveza";






			//21.4.2021  da li editujemo
			if (Obaveza_Id == 0)
			{
				konekcija.Dogadaji.Add(Dogadaj);
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

			if (tabcontrol.SelectedTab == tabcontrol.TabPages[4])
			{
				tab.Controls.Clear();
				DogadjajiForma form = new DogadjajiForma();
				form.TopLevel = false;
				tab.Controls.Add(form);
				form.Dock = DockStyle.Fill;
				form.Show();



			}
			
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (Obaveza_Id != 0)
			{

				DogadajiTabela obavezazaobrisati =
					konekcija.Dogadaji
					.Where(X => X.Događaji_Id == Obaveza_Id).FirstOrDefault();

				konekcija.Dogadaji.Remove(obavezazaobrisati);

				konekcija.SaveChanges();

				MessageBox.Show("obaveza uspjesno obrisana");

				//uzimamo ovaj tab
				TabPage ovajtab = ((TabPage)this.Parent);

				//ocistimo ovaj tab
				ovajtab.Controls.Clear();



				DogadjajiForma form = new DogadjajiForma();
				form.TopLevel = false;
				ovajtab.Controls.Add(form);
				form.Dock = DockStyle.Fill;
				form.Show();







			}
		}

		private void Nazad_Click(object sender, EventArgs e)
		{
			Nazadnatab();
		}
	}
}
