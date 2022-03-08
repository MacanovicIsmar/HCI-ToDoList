using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HCI_ToDoList.Dogadjaji
{
    public class stringtodate
    {

        static public DateTime Stringtodatum2(string day,string month,string year)
        {

            DateTime DatumD = new DateTime(int.Parse(year), int.Parse(month), int.Parse(day));

            return DatumD;






        }



        static public DateTime Stringtodatum(string datum)
        {
            string[] TEXT = new string[6];
            int a = 0;

            for (int i = 0; i < datum.Length; i++)
            {
                if (!datum[i].ToString().Equals(".") && !datum[i].ToString().Equals(" ") && !datum[i].ToString().Equals(":"))
                {

                    TEXT[a] += datum[i];





                }
                else
                {
                    a++;



                }

            }


            for (int i = 3; i <6 ; i++)
            {
                if (TEXT[i] == null)
                {
                    TEXT[i] = "0";
                
                }
            
            
            }



            //assigns year, month, day, hour, min, seconds
            DateTime DatumD = new DateTime(int.Parse(TEXT[2]), int.Parse(TEXT[1]), int.Parse(TEXT[0]),
                int.Parse(TEXT[3]), int.Parse(TEXT[4]), int.Parse(TEXT[5]));

            return DatumD;





        }

        static public string datumtostring(DateTime Datum)
        {


            return $"{Datum.Day}.{Datum.Month}.{Datum.Year} " +
                $"{Datum.Hour}:{Datum.Minute}:{Datum.Second}";

        }










    }
}
