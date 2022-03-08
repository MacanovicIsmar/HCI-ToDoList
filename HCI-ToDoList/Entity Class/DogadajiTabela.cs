using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_ToDoList.Entity_Class
{
	[Table("DogadajiTabela")]


	public class DogadajiTabela
	{
		[Key]

		public int Događaji_Id { get; set; }

		public virtual Profil_Tabela Profil { get; set; }

		public string NazivObaveze { get; set; }

		public string DatumDogađaja { get; set; }

		public string Ponavljanje { get; set; }

		public string Status { get; set; }

		public string Opis { get; set;}

	}
}
