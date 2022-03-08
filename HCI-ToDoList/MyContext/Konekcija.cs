using HCI_ToDoList.Entity_Class;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_ToDoList.MyContext
{
	//test
	public class Konekcija
	{
		public class ConnectionTobase : DbContext
		{

			public ConnectionTobase() : base("PutanjaDoBaze")
			{







			}

			public DbSet<Profil_Tabela> Profil { get; set; }

			public DbSet<GlavneObavezeTabela> GlavneObaveze { get; set; }

			public DbSet<DnevneObavezeTabela> DnevneObaveze { get; set; }

			public DbSet<SedmicneObavezeTabela> SedmicneObaveze { get; set; }

			public DbSet<DogadajiTabela> Dogadaji { get; set; }

			public DbSet<PodsjetniciTabela> Podsjetnici { get; set; }

			public DbSet<StatistikaTabela> Statistika { get; set; }

			public DbSet<Trenutniprofil> trenutniprofil { get; set; }

			public DbSet<SedmicneGrupa> SedmicneGrupa { get; set; }
			public DbSet<DnevneGrupa> DnevneGrupa { get; set; }

			public DbSet<SortiranjeTabela> Sortiranjetabela { get; set; }

			public DbSet<GlavneGrupa> GlavneGrupa { get; set; }

			










		}
		public class Connect
		{
			public static ConnectionTobase DB { get; } = new ConnectionTobase();




		}
	}
}
