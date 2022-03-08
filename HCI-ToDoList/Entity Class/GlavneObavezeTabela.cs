using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_ToDoList.Entity_Class
{

	[Table("GlavneObavezeTabela")]

	public class GlavneObavezeTabela
	{
		[Key]
		public int ID_Glavne { get; set; }

		//public int ProfilTabela_Id { get; set; }

		public string NazivObaveze { get; set; }

		public string GrupaObaveza { get; set; }

		public string Opis { get; set; }

		public string Status { get; set; }

		public string DatumValidnosti { get; set; }

		public virtual Profil_Tabela Profiltabela { get; set; }
		public virtual GlavneGrupa Grupa { get; set; }

		public string Arhiva { get; set;}

	}
}
