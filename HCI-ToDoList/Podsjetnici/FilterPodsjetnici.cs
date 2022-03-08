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

namespace HCI_ToDoList.Podsjetnici
{
	public partial class FilterPodsjetnici : Form
	{
		ConnectionTobase konekcija = Connect.DB;
		static public int profil_Id;

		//static public string sortirajpogrupi;
		static public SortiranjeTabela sorttabela;
		//private string v;

		public FilterPodsjetnici()
		{
			InitializeComponent();
			profil_Id = konekcija.trenutniprofil.FirstOrDefault().Profil_Id;

			sorttabela =
	        konekcija.Sortiranjetabela
	        .Where(X => X.Profil.ID_Profil == profil_Id)
	        .Where(x => x.Tip == "Podsjetnik")
	        .FirstOrDefault();

			loadform();

		}

		private void loadform()
		{
			naslov.Text = sorttabela.Tip;

			string[] statusi = new string[3];
			List<Label> labeliyes = new List<Label>();
			List<Label> labelino = new List<Label>();

			statusi[0] = sorttabela.PoDatumu;
			statusi[1] = sorttabela.PoNazivu;
			statusi[2] = sorttabela.PrikazArhive;


			labeliyes.Add(datum_yes);			
			labeliyes.Add(Naziv_yes);			
			labeliyes.Add(Arhiva_yes);
			

			labelino.Add(datum_no);			
			labelino.Add(Naziv_No);			
			labelino.Add(Arhiva_No);
			



			for (int i = 0; i < 3; i++)
			{
				//prikaz sortianje datuma


				if (statusi[i] == "Yes")
				{
					labeliyes[i].BackColor = Color.DodgerBlue;
					labelino[i].BackColor = Color.Transparent;
					labelino[i].BorderStyle = BorderStyle.None;



				}
				else if (statusi[i] == "No")
				{
					labeliyes[i].BackColor = Color.Transparent;
					labelino[i].BackColor = Color.DodgerBlue;
					labeliyes[i].BorderStyle = BorderStyle.None;
				}
				else
				{
					labeliyes[i].BackColor = Color.Transparent;
					labelino[i].BackColor = Color.Transparent;
					labeliyes[i].BorderStyle = BorderStyle.None;
					labelino[i].BorderStyle = BorderStyle.None;
					labeliyes[i].ForeColor = Color.Gray;
					labelino[i].ForeColor = Color.Gray;
				}


				//prikaz sortianje grupe
			}



		}

		private void datum_yes_Click(object sender, EventArgs e)
		{
			sorttabela.PoDatumu = "Yes";
			sorttabela.PoNazivu = "No";
			konekcija.SaveChanges();


			loadform();
		}

		private void datum_no_Click(object sender, EventArgs e)
		{
			sorttabela.PoDatumu = "No";
			konekcija.SaveChanges();


			loadform();
		}

		private void Naziv_yes_Click(object sender, EventArgs e)
		{
			sorttabela.PoNazivu = "Yes";
			sorttabela.PoDatumu = "No";
			konekcija.SaveChanges();
			loadform();
		}

		private void Naziv_No_Click(object sender, EventArgs e)
		{
			sorttabela.PoNazivu = "No";
			konekcija.SaveChanges();
			loadform();
		}

		private void Arhiva_yes_Click(object sender, EventArgs e)
		{
			sorttabela.PrikazArhive = "Yes";
			konekcija.SaveChanges();
			loadform();
		}

		private void Arhiva_No_Click(object sender, EventArgs e)
		{
			sorttabela.PrikazArhive = "No";
			konekcija.SaveChanges();
			loadform();
		}

		private void nazadbutton_Click(object sender, EventArgs e)
		{
			TabPage tab = ((TabPage)this.Parent);


			tab.Controls.Clear();

			

				PodsjetniciForma form = new PodsjetniciForma();
				form.TopLevel = false;
				tab.Controls.Add(form);
				form.Dock = DockStyle.Fill;
				form.Show();
			
			


		}
	}
}




