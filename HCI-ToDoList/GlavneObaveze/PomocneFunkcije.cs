using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HCI_ToDoList.GlavneObaveze
{
	public class PomocneFunkcije
	{
		static public string stringwithrows(string text,int duzina)
		{
			int rows =text.Length / duzina;
			string textreturn=" ";
			int index = 0;


			if (text.Length < duzina)
				return text;





			for (int i = 0; i < rows; i++)
			{								
					textreturn += $"{text.Substring(index, duzina)} \n ";
					////textreturn += " \n";
					index += duzina;				
			}

			if (text.Length % duzina != 0)
			{
				textreturn += text.Substring(index, text.Length % duzina);

			}



			return textreturn;



		}


		static public string stringwithrowsLabel(string text, int duzina)
		{
			int rows = text.Length / duzina;
			string textreturn = " ";
			int index = 0;


			if (text.Length < duzina)
				return text;





			for (int i = 0; i < rows; i++)
			{
				textreturn += $"{text.Substring(index, duzina)} \n ";
				////textreturn += " \n";
				index += duzina;
			}

			if (text.Length % duzina != 0)
			{
				textreturn += text.Substring(index, text.Length % duzina);

			}



			return textreturn;



		}


		static public int provjeriText(string text, int lokacija)
		{

			int broj = lokacija;
			int ukupnaduzin = text.Length;


			

			//da li je lokacija razlicita od praznogmjesta
			if (text[lokacija].ToString() != " ")
			{
				//da li je na kraju reda
				if ((lokacija + 1) != ukupnaduzin)
				{
					//da li ima slovo u slijedecem redu
					if (text[lokacija + 1].ToString() != " ")
					{
						//vrati lokaciju nazad 
						while (text[lokacija].ToString() != " ")
						{
							lokacija--;

						}


					}
					else
					{


						lokacija++;

					}
				}
				else
				{

					return lokacija;

				}



			
			}

			





			return lokacija;
		
		
		
		}



	}
}
