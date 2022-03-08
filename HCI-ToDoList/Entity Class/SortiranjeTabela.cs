using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_ToDoList.Entity_Class
{

	[Table("SortiranjeTabela")]


	public class SortiranjeTabela
	{
		[Key]
		public int Sort_Id { get; set; }

		public string Tip { get; set; }

		public string PoDatumu { get; set; }

		public string PoGrupi { get; set; }

		public string PoNazivu { get; set; }

		public string PrikazZavršenih { get; set; }

		public string PrikazArhive { get; set; }

		public string BrisanjeZavrsenih { get; set; }

		public virtual Profil_Tabela Profil { get; set; }






	}
}
