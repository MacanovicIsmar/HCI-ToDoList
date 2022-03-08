using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_ToDoList.Entity_Class
{

	[Table("SedmicneGrupa")]


	public class SedmicneGrupa
	{
		[Key]

		public int Grupa_Id { get; set; }

		public string Naziv { get; set; }

		public string Toggle { get; set; }





	}
}
