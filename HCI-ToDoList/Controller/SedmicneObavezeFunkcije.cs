using HCI_ToDoList.Dogadjaji;
using HCI_ToDoList.Entity_Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HCI_ToDoList.MyContext.Konekcija;

namespace HCI_ToDoList.Controller
{
	public class SedmicneObavezeFunkcije
	{

		public static ConnectionTobase konekcija = Connect.DB;




		public static void uncheckobaveze(int trenutniprofil)
		{
			
			string datumubazi = konekcija.Profil.Where(x => x.ID_Profil.Equals(trenutniprofil)).FirstOrDefault().Datumkrajasedmice;

			string danasnjidatum = DateTime.Today.ToString(format: "dd.MM.yyyy");
			if (datumubazi != danasnjidatum)
			{
				DateTime danasnjid = DateTime.Today;



				List<SedmicneObavezeTabela> lista = konekcija.SedmicneObaveze
					.Where(x => x.Profil.ID_Profil.Equals(trenutniprofil))
					.Where(X => X.Arhiva == "No")
					.ToList();




				//datum za kraj Sedmice 
				DayOfWeek currentDay = DateTime.Now.DayOfWeek;
				int daysTillendoftheweek = DayOfWeek.Saturday + 1 - currentDay;

				DateTime currentWeekendendDate = DateTime.Now.AddDays(daysTillendoftheweek);

				bool provjera = false;

				foreach (var a in lista)
				{
					if (danasnjid > stringtodate.Stringtodatum(a.DatumValidnosti))
					{
						a.Status = "NeZavrseno";
						a.DatumValidnosti = currentWeekendendDate.ToString(format: "dd.MM.yyyy");
						provjera = true;

					}



				}

				Profil_Tabela profil = konekcija.Profil.Where(x => x.ID_Profil.Equals(trenutniprofil)).FirstOrDefault();
				profil.Datumkrajasedmice = danasnjidatum;


				if(provjera==true)
				MessageBox.Show("Sedmica resetovana");

				konekcija.SaveChanges();



			}











		}






	}
}
