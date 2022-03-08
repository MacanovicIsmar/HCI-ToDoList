using HCI_ToDoList.Dnevne;
using HCI_ToDoList.Dogadjaji;
using HCI_ToDoList.Entity_Class;
using HCI_ToDoList.GlavneObaveze;
using HCI_ToDoList.Home;
using HCI_ToDoList.Podsjetnici;
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
using System.Windows.Forms.DataVisualization.Charting;
using static HCI_ToDoList.MyContext.Konekcija;

namespace HCI_ToDoList.Statistika
{
	public partial class StatistikaForm : Form
	{
		ConnectionTobase konekcija = Connect.DB;
		static public int profil_Id;


		public StatistikaForm()
		{
			InitializeComponent();
			profil_Id = konekcija.trenutniprofil.FirstOrDefault().Profil_Id;
			loadform();
		}

		private void loadform()
		{
			string[] tipoviobaveza = new string[]
			{
			"nije Selektovano",
			"Glavne",
			"Dnevne",
			"Sedmicne",


			};

			Tip.DataSource = tipoviobaveza;
			Tip.SelectedIndex = 0;


			string odabir = Tip.SelectedItem.ToString();




			LoadhChart(odabir);
			loadstats();




			





		}

		private void loadstats()
		{

			string nazivprofila=konekcija.Profil.Where(x=>x.ID_Profil==profil_Id).FirstOrDefault().NazivProfila;

			var statistika = konekcija.Statistika.AsQueryable();
			var glavni = konekcija.GlavneObaveze.Where(X => X.Profiltabela.ID_Profil == profil_Id).AsQueryable();
			var dnevni = konekcija.DnevneObaveze.Where(X => X.Profil.ID_Profil == profil_Id).AsQueryable();
			var sedmicne = konekcija.SedmicneObaveze.Where(X => X.Profil.ID_Profil == profil_Id).AsQueryable();

			int uradeniglavnih;
			int uradenidnevnih;
			int uradenisedmicni;
			//glavne
			List<StatistikaTabela> lista = statistika
				.Where(X => X.TipObaveze == "Glavne")
				.Where(X => X.Profil.ID_Profil == profil_Id).ToList();


			if (lista.Count()!=0)
			{
				uradeniglavnih = statistika
				.Where(X => X.TipObaveze == "Glavne")
				.Where(X => X.Profil.ID_Profil == profil_Id)
				.Sum(X => X.BrojOdrađeniObaveza);

			}
			else
			{
				uradeniglavnih = 0;


			}

			//dnevne
			lista = statistika
				.Where(X => X.TipObaveze == "Dnevne")
				.Where(X => X.Profil.ID_Profil == profil_Id).ToList();


			if (lista.Count() != 0)
			{
				uradenidnevnih = statistika
				.Where(X => X.TipObaveze == "Dnevne")
				.Where(X => X.Profil.ID_Profil == profil_Id)
				.Sum(X => X.BrojOdrađeniObaveza);

			}
			else
			{
				uradenidnevnih = 0;


			}

			//sedmicne
			lista = statistika
				.Where(X => X.TipObaveze == "Sedmicne")
				.Where(X => X.Profil.ID_Profil == profil_Id).ToList();


			if (lista.Count() != 0)
			{
				uradenisedmicni = statistika
				.Where(X => X.TipObaveze == "Sedmicne")
				.Where(X => X.Profil.ID_Profil == profil_Id)
				.Sum(X => X.BrojOdrađeniObaveza);

			}
			else
			{
				uradenisedmicni = 0;


			}


			
			int arhiviranih_glavni = glavni.Where(X => X.Arhiva == "Yes").Count();
			int arhiviranih_dnevni= dnevni.Where(X => X.Arhiva == "Yes").Count(); 
			int arhiviranih_sedmicni=sedmicne.Where(X => X.Arhiva == "Yes").Count(); 
			int ukupno_glavni=glavni.Count();
			int ukupno_dnevni=dnevni.Count();
			int ukupno_sedmicni=sedmicne.Count();


			Profil_La.Text ="Profil :" + nazivprofila;

			Le_Glavne.Text = "Glavne--\n" + "BrojOdradenih : " + uradeniglavnih + "\nBrojArhiviranih : " + arhiviranih_glavni +
				"\nUkupnoObaveza : " + ukupno_glavni;

			Le_Dnevne.Text = "Dnevne--" + "\nBrojOdradenih : " + uradenidnevnih + "\nBrojArhiviranih : " + arhiviranih_dnevni +
				"\nUkupnoObaveza : " + ukupno_dnevni;

			Le_Sedmicne.Text = "Sedmicne--" + "\nBrojOdradenih : " + uradenisedmicni + "\nBrojArhiviranih : " + arhiviranih_sedmicni +
				"\nUkupnoObaveza : " + ukupno_sedmicni;






		}

		private void LoadhChart(string odabir)
		{
			//uzimamo datume zadnjih 5 dana
			

			DateTime[] last5Days = Enumerable.Range(0, 5)
		   .Select(i => DateTime.Now.Date.AddDays(-i))
		   .ToArray();


			Series brojodrađenigobaveza = new Series();
			brojodrađenigobaveza.XValueType = ChartValueType.DateTime;
			brojodrađenigobaveza.IsXValueIndexed = false;



			for (int i = 0; i < 5; i++)
			{
				StatistikaTabela paket;
				//pravimo string za pretragu
				string pretraga = last5Days[i].ToString(format: "dd.MM.yyyy");

				if (odabir == "nije Selektovano")
				{
					//gledamo u bazi da li postoji podatak sa tim datomo
					paket = konekcija.Statistika
						.Where(X => X.Profil.ID_Profil == profil_Id)
						.Where(X => X.Datum == pretraga)
						.FirstOrDefault();
				}
				else
				{
					paket = konekcija.Statistika
						   .Where(X => X.Profil.ID_Profil == profil_Id)
						   .Where(X => X.TipObaveze == odabir)
						   .Where(X => X.Datum == pretraga)
						   .FirstOrDefault();



				}

				//ako ne dodajemo 0
				if (paket == null)
				{



					brojodrađenigobaveza.Points.AddXY(last5Days[i], 0);



				}
				//ako da dodamo broj iz podataka
				else
				{

					brojodrađenigobaveza.Points.AddXY(last5Days[i], paket.BrojOdrađeniObaveza);



				}






			}


			chart1.Series[0] = brojodrađenigobaveza;
			chart1.ChartAreas[0].AxisX.LabelStyle.IsEndLabelVisible = false;
			//chart1.Series[0].Label[0]
			//chart1.Series[0].Points.RemoveAt(4);
			chart1.ResetAutoValues();





		}

		private void chart1_Click(object sender, EventArgs e)
		{

		}

		private void Tip_SelectedIndexChanged(object sender, EventArgs e)
		{


			string odabir = Tip.SelectedItem.ToString();


			LoadhChart(odabir);



		}

		private void Le_Dnevne_Click(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
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
			if (tabcontrol.SelectedTab == tabcontrol.TabPages[4])
			{
				tab.Controls.Clear();
				DogadjajiForma form = new DogadjajiForma();
				form.TopLevel = false;
				tab.Controls.Add(form);
				form.Dock = DockStyle.Fill;
				form.Show();
			}

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
