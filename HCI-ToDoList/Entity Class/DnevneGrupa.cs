using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_ToDoList.Entity_Class
{
   
		[Table("DnevneGrupa")]


		public class DnevneGrupa
		{
			[Key]

			public int DnevneGrupaId { get; set; }

			public string Naziv { get; set; }

			public string Toggle { get; set; }

		}
	}

