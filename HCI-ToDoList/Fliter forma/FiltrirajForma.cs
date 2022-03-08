using HCI_ToDoList.Dnevne;
using HCI_ToDoList.Entity_Class;
using HCI_ToDoList.GlavneObaveze;
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

namespace HCI_ToDoList.Fliter_forma
{
	public partial class FiltrirajForma : Form
	{
		ConnectionTobase konekcija = Connect.DB;
		static public int profil_Id;
		 
		static public string sortirajpogrupi;
		static public SortiranjeTabela sorttabela;
		private string v;

		public FiltrirajForma()
		{
			InitializeComponent();
			profil_Id = konekcija.trenutniprofil.FirstOrDefault().Profil_Id;
			
			
			
			

		}

		public FiltrirajForma(string v):this()
		{
			this.v = v;

			sorttabela =
			konekcija.Sortiranjetabela
			.Where(X => X.Profil.ID_Profil == profil_Id)
			.Where(x => x.Tip == v )
			.FirstOrDefault();

			loadform();

		}

		private void loadform()
		{
            //SortiranjeTabela sorttabela =
            //konekcija.Sortiranjetabela
            //.Where(X => X.Profil.ID_Profil == profil_Id)
            //.Where(x => x.Tip == "Sedmicne" || x.Tip == "Dnevne" || x.Tip == "Glavne")
            //.FirstOrDefault();

            naslov.Text = sorttabela.Tip;

			string[] statusi = new string[6];
			List<Label> labeliyes = new List<Label>();
			List<Label> labelino = new List<Label>();

			statusi[0] = sorttabela.PoDatumu;
			statusi[1] = sorttabela.PoGrupi; //static
			statusi[2] = sorttabela.PoNazivu;
			statusi[3] = sorttabela.PrikazZavršenih;
			statusi[4] = sorttabela.PrikazArhive;
			statusi[5] = sorttabela.BrisanjeZavrsenih;

			labeliyes.Add(datum_yes);
			labeliyes.Add(grupe_yes);
			labeliyes.Add(Naziv_yes);
			labeliyes.Add(Zavrsene_yes);
			labeliyes.Add(Arhiva_yes);
			labeliyes.Add(izbrisi_yes);

			labelino.Add(datum_no);
			labelino.Add(grupe_no);
			labelino.Add(Naziv_No);
			labelino.Add(Zavrsene_No);
			labelino.Add(Arhiva_No);
			labelino.Add(izbrisi_No);



			for (int i = 0; i < 6; i++)
			{
				//prikaz sortianje datuma

				if (i == 0)
				{
					if (statusi[4] == "No" && (v == "Sedmicne" || v == "Dnevne"))
					{

						panel1.Hide();
					}
					else
					{
						panel1.Show();
					
					}

				
				}
				
				
											
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

		private void groupBox1_Enter(object sender, EventArgs e)
		{
			







		}

		private void grupe_yes_Click(object sender, EventArgs e)
		{
			

				sorttabela.PoGrupi = "Yes";
				konekcija.SaveChanges();



			
			loadform();




		}

		private void grupe_no_Click(object sender, EventArgs e)
		{
			

				sorttabela.PoGrupi = "No";
				konekcija.SaveChanges();



			
			loadform();
		}

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

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

        private void Zavrsene_yes_Click(object sender, EventArgs e)
        {
			

				sorttabela.PrikazZavršenih = "Yes";
				konekcija.SaveChanges();



			
			loadform();
		}

        private void Zavrsene_No_Click(object sender, EventArgs e)
        {
			

				sorttabela.PrikazZavršenih = "No";
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

			if (sorttabela.Tip == "Sedmicne")
			{

				SedmicneForm form = new SedmicneForm();
				form.TopLevel = false;
				tab.Controls.Add(form);
				form.Dock = DockStyle.Fill;
				form.Show();
			}
            else if (sorttabela.Tip == "Dnevne")
            {

                DnevneFrom frm = new DnevneFrom();
                frm.TopLevel = false;
                tab.Controls.Add(frm);
                frm.Dock = DockStyle.Fill;
                frm.Show();
            }
			else if (sorttabela.Tip == "Glavne")
			{

				GlavnaForm frm = new GlavnaForm();
				frm.TopLevel = false;
				tab.Controls.Add(frm);
				frm.Dock = DockStyle.Fill;
				frm.Show();
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

		private void izbrisi_yes_Click(object sender, EventArgs e)
		{
			sorttabela.BrisanjeZavrsenih = "Yes";
			konekcija.SaveChanges();


			loadform();
		}

		private void izbrisi_No_Click(object sender, EventArgs e)
		{
			sorttabela.BrisanjeZavrsenih = "No";
			konekcija.SaveChanges();


			loadform();
		}
	}
}
