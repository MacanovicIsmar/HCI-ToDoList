using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HCI_ToDoList.Entity_Class
{

	[Table("Trenutniprofil")]

	public class Trenutniprofil
	{
		public int Id { get; set; }

		public int Profil_Id { get; set; }


	}
}
