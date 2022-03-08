using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HCI_ToDoList.Entity_Class
{

	[Table("Profil Tabela")]


	public class Profil_Tabela
	{
		[Key]
		public int ID_Profil { get; set; }
		
		public string NazivProfila { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string DanasnjiDatum { get; set; }
		public string Datumkrajasedmice { get; set; }




	}
}
