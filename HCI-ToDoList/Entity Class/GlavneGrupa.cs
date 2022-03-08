using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_ToDoList.Entity_Class
{
    [Table("GlavneGrupa")]
    public class GlavneGrupa
    {
        [Key]

        public int GlavneGrupaId { get; set; }

        public string Naziv { get; set; }

        public string Toggle { get; set; }
    }
}
