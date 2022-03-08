using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_ToDoList.Entity_Class
{
	[Table("StatistikaTabela")]

	public class StatistikaTabela
	{

		[Key]
		public int Statistika_Id { get; set; }

		public virtual Profil_Tabela Profil { get; set; }

		public int BrojOdrađeniObaveza { get; set; }

		public string Datum { get; set; }

		public string TipObaveze { get; set; }

		public string DatumSedmice { get; set; }
	}
}
