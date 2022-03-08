using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_ToDoList.Entity_Class
{
	[Table("PodsjetniciTabela")]

	public class PodsjetniciTabela
	{
		[Key]
		public int Podsjetnici_Id { get; set; }

    	public virtual Profil_Tabela Profil { get; set; }

		public string Naslov { get; set; }

		public string Opis { get; set; }

		public string Tag { get; set; }

		public string DatumKreiranja { get; set; }

		public string Arhiva { get; set; }
	}
}
