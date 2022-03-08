using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_ToDoList.DodajObavezu
{
	public static class Validacija
	{
		public static string poruka;
		
		
		public static bool validirajtext(string text,string poruka_)
		{
			if (string.IsNullOrWhiteSpace(text))
			{

				poruka = poruka_;
				return false;
				



			}
			else
			{
				
				return true;

			}



		}

		public static bool validirajtext(string text)
		{
			if (string.IsNullOrWhiteSpace(text))
			{

				
				return false;


				

			}
			else
			{

				return true;

			}
		}
	}
}
