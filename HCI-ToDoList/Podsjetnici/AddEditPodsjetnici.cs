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

namespace HCI_ToDoList.Podsjetnici
{
	public partial class AddEditPodsjetnici : Form
	{
		ConnectionTobase konekcija = Connect.DB;
		public int trenutniprofil_Id;
		private int Podsjetnik_Id;
	

		public AddEditPodsjetnici()
		{
			InitializeComponent();
			LoadForm();
			trenutniprofil_Id = konekcija.trenutniprofil.FirstOrDefault().Profil_Id;



		}

		public AddEditPodsjetnici(int Podsjetnik_Id) : this()
		{
			this.Podsjetnik_Id = Podsjetnik_Id;
			LoadEditform();



		}

		private void LoadEditform()
		{
			PodsjetniciTabela podsjetnik = konekcija.Podsjetnici
				.FirstOrDefault(X => X.Podsjetnici_Id == Podsjetnik_Id);

			checboxarhiva.Show();
			Arhiva.Show();
			button1.Show();

			checboxarhiva.Image = podsjetnik.Arhiva == "Yes" ?
			Resources.hciiconmini : null;
			textboxnaziv.Text = podsjetnik.Naslov;
			RichtextboxDetalji.Text = podsjetnik.Opis;
			

















		}

		private void LoadForm()
		{
			checboxarhiva.Hide();
			Arhiva.Hide();
			button1.Hide();







			
		}

		private void Sacuvaj_Click(object sender, EventArgs e)
		{
			
			if (!Validacija.validirajtext(textboxnaziv.Text))
			{

				MessageBox.Show("niste unjeli naziv");
			
			
			}


			PodsjetniciTabela Podsjetnik;

			if (Podsjetnik_Id == 0)
			{

				Podsjetnik = new PodsjetniciTabela();
				Podsjetnik.Arhiva = "No";

			}
			else
			{

				Podsjetnik = konekcija.Podsjetnici.Find(Podsjetnik_Id);
				Podsjetnik.Arhiva = checboxarhiva.Image == null ?
					"No" : "Yes";

			}

			//unosenje atributa 
			Podsjetnik.Naslov = textboxnaziv.Text;
			Podsjetnik.Opis = Validacija.validirajtext(RichtextboxDetalji.Text) == true ?
			RichtextboxDetalji.Text : "Nema Opisa";
			Podsjetnik.DatumKreiranja = DateTime.Now.ToString(format: "dd.MM.yyyy");
			Podsjetnik.Profil = konekcija.Profil.Where(X => X.ID_Profil == trenutniprofil_Id).FirstOrDefault();
			
			




			if (Podsjetnik_Id == 0)
			{

				konekcija.Podsjetnici.Add(Podsjetnik);
				konekcija.SaveChanges();
				MessageBox.Show("note uspjesno dodan");
				nazadtab();

			}
			else
			{

				konekcija.SaveChanges();
				MessageBox.Show("EditUspjesan");
			}










		}

		private void nazadtab()
		{
			TabPage tab = ((TabPage)this.Parent);
			TabControl tabcontrol = tab.Parent as TabControl;

			if (tabcontrol.SelectedTab == tabcontrol.TabPages[5])
			{
				tab.Controls.Clear();
				PodsjetniciForma form = new PodsjetniciForma();
				form.TopLevel = false;
				tab.Controls.Add(form);
				form.Dock = DockStyle.Fill;
				form.Show();



			}
			
		}

		private void checboxarhiva_Click(object sender, EventArgs e)
		{
			checboxarhiva.Image = checboxarhiva.Image == null ?
			 Resources.hciiconmini:null;
		}

		private void Nazad_Click(object sender, EventArgs e)
		{
			TabPage tab = ((TabPage)this.Parent);
			TabControl tabcontrol = tab.Parent as TabControl;

			if (tabcontrol.SelectedTab == tabcontrol.TabPages[5])
			{
				tab.Controls.Clear();
				PodsjetniciForma form = new PodsjetniciForma();
				form.TopLevel = false;
				tab.Controls.Add(form);
				form.Dock = DockStyle.Fill;
				form.Show();
			}
		}
	}
}
