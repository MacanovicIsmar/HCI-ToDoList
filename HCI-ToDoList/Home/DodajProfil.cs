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

namespace HCI_ToDoList.Home
{
	public partial class DodajProfil : Form
	{

		ConnectionTobase konekcija = Connect.DB;
		public static Profil_Tabela TrenutniProfil;
		public static string v;


		public DodajProfil(string v_)
		{
			InitializeComponent();
			v = v_;
			int Id = konekcija.trenutniprofil.FirstOrDefault().Profil_Id;
			TrenutniProfil = konekcija.Profil.Where(X => X.ID_Profil == Id).FirstOrDefault();
			Load();

		}

		private void Load()
		{

			if (v == "Dodaj")
			{

				groupBox1.Text = "Dodaj Profil";
				textBox1.Text = "Profil";

			}
			else
			{
				groupBox1.Text = "Uredi profil";
				textBox1.Text = TrenutniProfil.NazivProfila;


			}

			



		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{

			if (v == "Dodaj")
			{


				string text = textBox1.Text;


				if (string.IsNullOrWhiteSpace(text))
				{

					MessageBox.Show("niste unjeli naziv");
					return;


				}

				Profil_Tabela profil = konekcija.Profil.Where(X => X.NazivProfila == text).FirstOrDefault();

				if (profil != null)
				{

					MessageBox.Show("profil vec postoji");
					return;

				}

				profil = new Profil_Tabela();
				profil.NazivProfila = text;

				//ovo nije bitno
				profil.Password = "text";

				profil.Username = "text";

				konekcija.Profil.Add(profil);


				SortiranjeTabela sortuaprofilpostavke = new SortiranjeTabela();

				sortuaprofilpostavke.BrisanjeZavrsenih = "No";
				sortuaprofilpostavke.PoDatumu = "-";
				sortuaprofilpostavke.PoGrupi = "Yes";
				sortuaprofilpostavke.PoNazivu = "No";
				sortuaprofilpostavke.PrikazArhive = "No";
				sortuaprofilpostavke.PrikazZavršenih = "Yes";
				sortuaprofilpostavke.Profil = profil;
				sortuaprofilpostavke.Tip = "Sedmicne";

				konekcija.Sortiranjetabela.Add(sortuaprofilpostavke);
				konekcija.SaveChanges();

				//postavke  sortiranje  Dnevnih Obaveza 
				sortuaprofilpostavke.Tip = "Dnevne";
				sortuaprofilpostavke.PoDatumu = "No";

				konekcija.Sortiranjetabela.Add(sortuaprofilpostavke);
				konekcija.SaveChanges();

				//postavke sortiranje  glavnih obaveza
				sortuaprofilpostavke.Tip = "Glavne";
				sortuaprofilpostavke.PoDatumu = "No";

				konekcija.Sortiranjetabela.Add(sortuaprofilpostavke);
				konekcija.SaveChanges();

				//postavke  sortianje  podsjetnika 
				sortuaprofilpostavke.BrisanjeZavrsenih = "-";
				sortuaprofilpostavke.PoDatumu = "No";
				sortuaprofilpostavke.PoGrupi = "-";
				sortuaprofilpostavke.PoNazivu = "No";
				sortuaprofilpostavke.PrikazArhive = "No";
				sortuaprofilpostavke.PrikazZavršenih = "-";
				sortuaprofilpostavke.Profil = profil;
				sortuaprofilpostavke.Tip = "Podsjetnik";

				konekcija.Sortiranjetabela.Add(sortuaprofilpostavke);
				konekcija.SaveChanges();

				MessageBox.Show($"uspjesno dodan {profil.NazivProfila} ");

				this.Close();

			}
			else
			{

				TrenutniProfil.NazivProfila = textBox1.Text;

				konekcija.SaveChanges();

				MessageBox.Show($"Ime uspjesno promjenjeno");

				this.Close();
			
			
			
			
			
			}













		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
