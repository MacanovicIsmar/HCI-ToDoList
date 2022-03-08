using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_ToDoList.Entity_Class
{
	[Table("DnevneObavezeTabela")]


	public class DnevneObavezeTabela
	{
		[Key]
		public int Dnevne_Id { get; set; }

		public virtual Profil_Tabela Profil { get; set;}

		public virtual DnevneGrupa Grupa { get; set; }
		public string NazivObaveze { get; set; }

		public string GrupaObaveze { get; set; }

		public string Opis { get; set; }

		public string Status { get; set; }

		public string DatumKreiranja { get; set; }

		public string DatumAktivnosti { get; set; }

		public string Arhiva { get; set;}


	}
}
