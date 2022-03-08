using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_ToDoList.Entity_Class
{
	[Table("SedmicneObavezeTabela")]

	public class SedmicneObavezeTabela
	{
		[Key]
		public int Sedmicne_Id { get; set; }

		public virtual Profil_Tabela Profil { get; set;}

		public virtual SedmicneGrupa Grupa { get; set; }

		public string NazivObaveze { get; set; }

		public string GrupaObaveze { get; set; }

		public string Opis { get; set; }

		public string Status { get; set; }

		public string DatumValidnosti { get; set; }

		public int BrojSedmice { get; set; }

		public string Arhiva { get; set;}
	}
}
