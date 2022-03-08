using HCI_ToDoList.Entity_Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using static HCI_ToDoList.MyContext.Konekcija;

namespace HCI_ToDoList.Home
{
	public partial class HomeForm : Form
	{
		ConnectionTobase konekcija = Connect.DB;
		static Label naslov = new Label();
		static int profil_Id;

		public HomeForm()
		{
			InitializeComponent();
			loadform();
		}
		private void loadform()
		{
			//this.Controls.Clear();

			//uzmi id trenutnog profila
			profil_Id = konekcija.trenutniprofil.FirstOrDefault().Profil_Id;

			//naslov home taba
			
			naslov.Name = "naslov";
			naslov.Size = new Size(596, 42);
			naslov.Location = new Point(0, 0);
			naslov.BackColor = Color.DarkGray;
			naslov.Text = "Sedmicne";
			naslov.Font = new Font(naslov.Font.Name, 20, naslov.Font.Style, naslov.Font.Unit);
			naslov.TextAlign = ContentAlignment.MiddleCenter;
			this.Controls.Add(naslov);



			List<Profil_Tabela> listaprofila = konekcija.Profil.ToList();


			Profil_Tabela prazanprofil = new Profil_Tabela();
			prazanprofil.ID_Profil = 0;
			prazanprofil.NazivProfila = "nije selektovan";

			listaprofila.Add(prazanprofil);




			if (profil_Id == 0)
			{

				naslov.Text = "Profil:" + "Profil nije selektovan";
				listBox1.DataSource = listaprofila.ToList();
				listBox1.DisplayMember = "NazivProfila";
				listBox1.SelectedIndex = listaprofila.Count() - 1;

			}
			else
			{
				string nazivprofila = konekcija.Profil.Where(X => X.ID_Profil.Equals(profil_Id)).FirstOrDefault().NazivProfila;

				naslov.Text = "Profil:" + nazivprofila;
				listBox1.DataSource = listaprofila.ToList();
				listBox1.DisplayMember = "NazivProfila";
				listBox1.SelectedItem = konekcija.Profil.Where(X => X.ID_Profil == profil_Id).FirstOrDefault();
				

			}


			



			
			
			
			
			
			
			
			
			
			
			
			//label2.Text = "Obaveza:" + konekcija.GlavneObaveze.FirstOrDefault().NazivObaveze;
			//label3.Text = "Status:" + konekcija.GlavneObaveze.FirstOrDefault().Status;
			//label4.Text = "dnevnaobaveza:" + konekcija.DnevneObaveze.FirstOrDefault().NazivObaveze;
			//label5.Text = "SedmicneObaveze:" + konekcija.SedmicneObaveze.FirstOrDefault().NazivObaveze;
			//label6.Text = "podsjetnik:  " + konekcija.Podsjetnici.FirstOrDefault().Opis;
			//label7.Text = "Događaj: " + konekcija.Dogadaji.FirstOrDefault().NazivObaveze;
			//label8.Text = "broj obavljenih obaveza:: " + konekcija.Statistika.FirstOrDefault().BrojOdrađeniObaveza;
			//label9.Text = "broj profila :" + konekcija.trenutniprofil.FirstOrDefault().Profil_Id;
		}

		private void label6_Click(object sender, EventArgs e)
		{

		}

        private void HomeForm_Load(object sender, EventArgs e)
        {

        }

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			
			
			



		}

		private void listBox1_Click(object sender, EventArgs e)
		{
			Trenutniprofil trenutniprofil = konekcija.trenutniprofil.FirstOrDefault();

			trenutniprofil.Profil_Id = (listBox1.SelectedItem as Profil_Tabela).ID_Profil;
			
			konekcija.SaveChanges();

			profil_Id = konekcija.trenutniprofil.FirstOrDefault().Profil_Id;
			if (profil_Id == 0)
			{

				naslov.Text = "Profil:" + "Nema profila";


			}
			else
			{

				naslov.Text = "Profil:" + konekcija.Profil.Where(X => X.ID_Profil.Equals(profil_Id)).FirstOrDefault().NazivProfila;


			}

				

			//loadform();

		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			Form forma = new DodajProfil("Dodaj");
			forma.ShowDialog();
			loadform();

		}

		private void button3_Click(object sender, EventArgs e)
		{

			string naziv = konekcija.Profil.Where(X => X.ID_Profil.Equals(profil_Id)).FirstOrDefault().NazivProfila;


			DialogResult dialogResult = MessageBox.Show("Da li zelite izbrisati profil "+naziv, "brisanje pofila", MessageBoxButtons.YesNo);
			if (dialogResult == DialogResult.Yes)
			{
				obrisiprofil();				
				
				
				//do something
			}
			else if (dialogResult == DialogResult.No)
			{
				//do something else
			}







		}

		private void obrisiprofil()
		{
			//brisanje sortiranih postavki
			List<SortiranjeTabela> lista = new List<SortiranjeTabela>();
			lista = konekcija.Sortiranjetabela.Where(X => X.Profil.ID_Profil == profil_Id).ToList();
			konekcija.Sortiranjetabela.RemoveRange(lista);

			//brisanje glavnih 
			List<GlavneObavezeTabela> listaglavnih = new List<GlavneObavezeTabela>();
			listaglavnih = konekcija.GlavneObaveze.Where(X => X.Profiltabela.ID_Profil == profil_Id).ToList();
			konekcija.GlavneObaveze.RemoveRange(listaglavnih);

			//brisanje dnevnih 
			List<DnevneObavezeTabela> listadnevnih = new List<DnevneObavezeTabela>();
			listadnevnih = konekcija.DnevneObaveze.Where(X => X.Profil.ID_Profil == profil_Id).ToList();
			konekcija.DnevneObaveze.RemoveRange(listadnevnih);

			//brisanje sedmicnih
			List<SedmicneObavezeTabela> listasedmicnih = new List<SedmicneObavezeTabela>();
			listasedmicnih = konekcija.SedmicneObaveze.Where(X => X.Profil.ID_Profil == profil_Id).ToList();
			konekcija.SedmicneObaveze.RemoveRange(listasedmicnih);

			//brisanje događaja
			List<DogadajiTabela> listadoagadaja = new List<DogadajiTabela>();
			listadoagadaja = konekcija.Dogadaji.Where(X => X.Profil.ID_Profil == profil_Id).ToList();
			konekcija.Dogadaji.RemoveRange(listadoagadaja);

			//brisanje podsjetnika 
			List<PodsjetniciTabela> listapodjsetnika = new List<PodsjetniciTabela>();
			listapodjsetnika = konekcija.Podsjetnici.Where(X => X.Profil.ID_Profil == profil_Id).ToList();
			konekcija.Podsjetnici.RemoveRange(listapodjsetnika);

			//brisanje profila
			Profil_Tabela profil = konekcija.Profil.Where(X => X.ID_Profil == profil_Id).FirstOrDefault();

			konekcija.trenutniprofil.FirstOrDefault().Profil_Id = 0;

			konekcija.Profil.Remove(profil);

			konekcija.SaveChanges();

			loadform();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Form forma = new DodajProfil("Uredi");
			forma.ShowDialog();
			loadform();
		}
	}
}
