using HCI_ToDoList.Dogadjaji;
using HCI_ToDoList.Entity_Class;
using HCI_ToDoList.GlavneObaveze;
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
	public partial class PodsjetniciForma : Form
	{
		ConnectionTobase konekcija = Connect.DB;
		public int Profile_Id;
		public SortiranjeTabela sorttabela;



		public PodsjetniciForma()
		{
			InitializeComponent();
			Profile_Id = konekcija.trenutniprofil.FirstOrDefault().Profil_Id;
			sorttabela = konekcija.Sortiranjetabela
				.Where(X => X.Profil.ID_Profil == Profile_Id)
				.Where(X => X.Tip == "Podsjetnik")
				.FirstOrDefault();
			    



			LoadForm();
		}

		private void LoadForm()
		{
			Form ovaforma = this;

			ovaforma.Controls.Clear(); //ovo je rijesilo problem

			Label naslov = new Label();
			naslov.Name = "naslov";
			naslov.Size = new Size(596, 42);
			naslov.Location = new Point(0, 0);
			naslov.BackColor = Color.DarkGray;
			naslov.Text = "Podsjetnici";
			naslov.Font = new Font(naslov.Font.Name, 20, naslov.Font.Style, naslov.Font.Unit);
			naslov.TextAlign = ContentAlignment.MiddleCenter;

			ovaforma.Controls.Add(naslov);

			int razmaky = 0;
			int razmakX = 0;
			

			int panX = 12;
			int panY = 56;


			var podsjetnici = konekcija.Podsjetnici
				.Where(X => X.Profil.ID_Profil == Profile_Id)
				.ToList();

			//sortiranje  ovdje 
			if (sorttabela.PoDatumu == "Yes")
			{

				podsjetnici = podsjetnici
					  .OrderByDescending(X => stringtodate.Stringtodatum(X.DatumKreiranja))
					  .ToList();
			
			}
			if (sorttabela.PoNazivu == "Yes")
			{
				podsjetnici = podsjetnici
						.OrderBy(X => X.Naslov)
						.ToList();
			
			
			
			}
			if (sorttabela.PrikazArhive == "No")
			{
				podsjetnici = podsjetnici
					   .Where(X => X.Arhiva == "No")
					   .ToList();


			}
			else
			{
				podsjetnici = podsjetnici
						   .Where(X => X.Arhiva == "Yes")
						   .ToList();



			}






			//brojimo grupe
			int brojpodsjetnika = podsjetnici.Count();

			int redovi = brojpodsjetnika / 3;

			int visak = brojpodsjetnika % 3;
			if (visak != 0)
			{
				redovi++;
			
			}
			int index = 0;

			for (int r=0; r<redovi;r++)
			{

				for (int k = 0; k < 3; k++)
				{
					if (index < brojpodsjetnika)
					{


						//label naslov Taska 
						var naslovpodsjetnika = new Label();
						naslovpodsjetnika.Name = "NaslovPodsjetnika";
						naslovpodsjetnika.AutoSize = false;
						naslovpodsjetnika.Location = new Point(3, 0);
						naslovpodsjetnika.Font = new Font(naslovpodsjetnika.Font, FontStyle.Bold);
						naslovpodsjetnika.Text = podsjetnici[index].Naslov;
						naslovpodsjetnika.Size = new Size(167, 25);
						naslovpodsjetnika.Font = new Font(naslovpodsjetnika.Font.Name, 13, naslovpodsjetnika.Font.Style, naslovpodsjetnika.Font.Unit);
						naslovpodsjetnika.TextAlign = ContentAlignment.MiddleCenter;
						//naslovpodsjetnika.BorderStyle = BorderStyle.FixedSingle;
						naslovpodsjetnika.BackColor = Color.Transparent;

						






					
						//datum label
						var DatumLabel = new Label();
						DatumLabel.Name = "Datum Podsjetnika";
						DatumLabel.AutoSize = false;
						DatumLabel.Location = new Point(3,123);
						DatumLabel.Text = podsjetnici[index].DatumKreiranja;
						DatumLabel.Size = new Size(167, 22);
						//Textpodsjetnika.Font = new Font(naslovpodsjetnika.Font.Name, 8, naslovpodsjetnika.Font.Style, naslovpodsjetnika.Font.Unit);
						//DatumLabel.BorderStyle = BorderStyle.FixedSingle;
						DatumLabel.BackColor = Color.Transparent;




						//panel je kontejener koji sadrzi 2 labela 
						var panel = new Panel();
						panel.Location = new Point(panX + razmakX, panY + razmaky);
						panel.Size = new Size(178, 139);
						//panel.BorderStyle = BorderStyle.FixedSingle;
						panel.BackColor = Color.AliceBlue;
						panel.BackgroundImage = Resources.Noteforhci;
						panel.Controls.Add(naslovpodsjetnika); //index 1 ili 0
						//index 1 ili 2
						panel.Controls.Add(DatumLabel);

						bool ostatak = false;
						//int rowspacestart = 0;
						int rowspace = 20;
						int stringduzina = 20;
						int rows = podsjetnici[index].Opis.Length / stringduzina;
						int X = 12;
						int Y = 39;
						int Start = 0;

						if (podsjetnici[index].Opis.Length % stringduzina != 0)
						{
							rows++;
							ostatak = true;
						}

						////textreturn += " \n";
						int end = 0;
						int i = 0;
						int ukupnaduzina = podsjetnici[index].Opis.Length;
						while (Start!= podsjetnici[index].Opis.Length-1)
						{
							//if (i == rows - 1 && ostatak == true)
							//{
							//	stringduzina = podsjetnici[index].Opis.Length % stringduzina;
							//}
							//else
							//{



							//}
							if (podsjetnici[index].Opis.Length < stringduzina)
							{
								

								end = podsjetnici[index].Opis.Length-1;
							}
							else
							{
								end = Start + stringduzina>ukupnaduzina? ukupnaduzina-1: Start + stringduzina;
								end = PomocneFunkcije.provjeriText(podsjetnici[index].Opis, end);
							}


							int lastchar = 0;
							if (end == ukupnaduzina - 1)
							{

								lastchar++;
							}

							string text = podsjetnici[index].Opis.Substring(Start, end - Start + lastchar);

							if (text[0].ToString() == " ")
							{
								text = text.Substring(1);
							
							}

							//label text Taska 
							var Textpodsjetnika = new Label();
							Textpodsjetnika.Name = "Textpodsjetnika";
							Textpodsjetnika.AutoSize = false;
							Textpodsjetnika.Location = new Point(X, Y);
							Textpodsjetnika.Text = text.Replace("\n"," ");
							Textpodsjetnika.Size = new Size(167, 22);
							Textpodsjetnika.Font = new Font(naslovpodsjetnika.Font.Name, 8, naslovpodsjetnika.Font.Style, naslovpodsjetnika.Font.Unit);
							//Textpodsjetnika.BorderStyle = BorderStyle.FixedSingle;
							Textpodsjetnika.BackColor = Color.Transparent;
							Textpodsjetnika.Click += new EventHandler(Podsjetnikclicked);
							Textpodsjetnika.TextAlign = ContentAlignment.BottomLeft;							
	         			    Start = end;
							


							
							Y = Y + rowspace;
							//rowspacestart += rowspace;
							panel.Controls.Add(Textpodsjetnika);
							i++;
						}






						this.Controls.Add(panel);
						razmakX += (178 + 10);

						index++;
					}
				}
				razmakX = 0;
				razmaky += (139 + 30);





			}




		}

		void Podsjetnikclicked(object sender, EventArgs e)
		{
			var label = ((Label)sender);

			Panel Panel = label.Parent as Panel;


			object naslov = Panel.Controls.Find("NaslovPodsjetnika", true).SingleOrDefault();


			string nazivzapretragu= ((System.Windows.Forms.Label)naslov).Text;

			PodsjetniciTabela podsjetnik = konekcija.Podsjetnici
				.Where(X => X.Profil.ID_Profil == Profile_Id)
				.Where(X => X.Naslov == nazivzapretragu)
				.FirstOrDefault();

			TabPage ovajtab = ((TabPage)this.Parent);
			ovajtab.Controls.Clear();
			 AddEditPodsjetnici editpod = new AddEditPodsjetnici(podsjetnik.Podsjetnici_Id);
			editpod.TopLevel = false;
			ovajtab.Controls.Add(editpod);
			editpod.Dock = DockStyle.Fill;
			editpod.Show();


		}











		//void panelclickzaedit(object sender, EventArgs e)
		//{
		//	int scrollvalue = this.VerticalScroll.Value;
		//	var Panel = ((Panel)sender);
		//	object checkboxlabel = Panel.Controls.Find("NaslovTaska", true).SingleOrDefault();
		//	string nazivzapretragu = ((System.Windows.Forms.Label)checkboxlabel).Text;
		//	GlavneObavezeTabela task = konekcija.GlavneObaveze.Where(x => x.Profiltabela.ID_Profil == trenutniprofilId).ToList()
		//		.Where(x => x.NazivObaveze.Equals(nazivzapretragu)).FirstOrDefault();
		//	TabPage ovajtab = ((TabPage)this.Parent);
		//	ovajtab.Controls.Clear();
		//	DodajEditForm form = new DodajEditForm(task.ID_Glavne, "Glavne");
		//	form.TopLevel = false;
		//	ovajtab.Controls.Add(form);
		//	form.Dock = DockStyle.Fill;
		//	form.Show();
		//}



	}
}
