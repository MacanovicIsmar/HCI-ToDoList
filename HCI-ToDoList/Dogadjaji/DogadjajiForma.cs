using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HCI_ToDoList.MyContext.Konekcija;
using System.IO;
using System.Configuration;
using System.Collections;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Controls;
using HCI_ToDoList.Entity_Class;

namespace HCI_ToDoList.Dogadjaji
{
    public partial class DogadjajiForma : Form
    {
        
        DataTable dt = new DataTable();
        object[,] listeMjeseci;
        int pos = 0;
        string[] liste_dan;
        int _dan;
        int _mjesec;
        int _godina;
        ConnectionTobase konekcija = Connect.DB;
        //ismar 
        public int trenutniprofilId;
        public int Trenutnimjesec;
        public int TrenutnaGodina;
        bool eventactive = false;

        public DogadjajiForma()
        {
            InitializeComponent();
            dateEvent.Format = DateTimePickerFormat.Custom;
            dateEvent.CustomFormat = "dd/MM/yyyy";
            _dan = DateTime.Today.Day;
            _mjesec = DateTime.Today.Month;
            _godina = DateTime.Today.Year;
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("dateEve", typeof(DateTime));
            dt.Columns.Add("event", typeof(string));

            
            trenutniprofilId = konekcija.trenutniprofil.FirstOrDefault().Profil_Id;
            Trenutnimjesec = DateTime.Now.Month;
            TrenutnaGodina = DateTime.Now.Year;
        
            load_Ismar();
            load_listIsmar();
            loadcomboboxes();
            DogadjajiForma_Load();
            //mjesec.Click += new EventHandler(mjesec_SelectedIndexChanged_1);
        }

		
		private void loadcomboboxes()
		{




            liste_dan = new string[7] { "Ponedeljak", "Utorak", "Srijeda", "Cetvrtak", "Petak", "Subota", "Nedelja" };

            listeMjeseci = new object[12, 2] { { 1, "Januar" }, { 2, "Februar" }, { 3, "Mart" }, { 4, "April" }, { 5, "Maj" }, { 6, "Juni" }, { 7, "Juli" }, { 8, "Avgust" }, { 9, "Septembar" }, { 10, "Oktobar" }, { 11, "Novembar" }, { 12, "Decembar" } };
            //sto ce dvodimenzionalni za listu mjeseci tipa object? 

            groupBox1.Hide();





            for (int i = 0; i < listeMjeseci.Length / 2; i++)//dodavanje mjeseci u combo box mjeseci 
                mjesec.Items.Add("       " + listeMjeseci[i, 1]);
            if (Trenutnimjesec > 1) //indeksiranje posa zbog nekog razloga?
                pos = Trenutnimjesec - 1;
            else
                pos = 0;


           
            


            //unosenje godina u godine combobox
            for (int i = 0; i < 5; i++)
                godine.Items.Add(DateTime.Today.Year + i - 2); //uzima se trenutna godina dvije predhodne i dvije buduce

            //postavlja selektovani indeks comboboxa na trenutni mjesec 
            for (int i = 0; i < 12; i++)
            {
                if ((int)listeMjeseci[i, 0] == Trenutnimjesec) //drugi indeks je 0 da bi uzeo intove is matrice
                {
                    mjesec.SelectedIndex =mjesec.FindString("       " + (string)listeMjeseci[i, 1]); //drugi indeks je 1 da bi se uzeli stringovi iz matrice
                }
            }
            //postavljanje selektovane godine kod godine combo box
            godine.SelectedIndex = godine.FindString(TrenutnaGodina.ToString());
            eventactive = true;



        }

        private void load_listIsmar()
		{
            
        }

		private void load_Ismar()
		{
            //ako nije selektovan profil izadi iz forme
            if (trenutniprofilId == 0)
            {

                return;

            }

            Form ovaforma = this;

            Pan_događajiLista.Controls.Clear(); //ovo je rijesilo problem






            System.Windows.Forms.Label naslov = new System.Windows.Forms.Label();
            naslov.Name = "naslov";
            naslov.Size = new Size(596, 42);
            naslov.Location = new Point(0, 0);
            naslov.BackColor = Color.DarkGray;
            naslov.Text = "Događaji " + konekcija.Profil.Where(X => X.ID_Profil.Equals(trenutniprofilId)).FirstOrDefault().NazivProfila;
            naslov.Font = new Font(naslov.Font.Name, 20, naslov.Font.Style, naslov.Font.Unit);
            naslov.TextAlign = ContentAlignment.MiddleCenter;

            ovaforma.Controls.Add(naslov);


           


           
        }

		private void panel1_Paint(object sender, PaintEventArgs e)
        {

        } //prazan event

        private void displayEvent_TextChanged(object sender, EventArgs e)
        {

        } //prazan event

        private void DogadjajiForma_Load()
        {


            






          

            //prikazuje mjesec i datum u onom panelu 
            Prikaz(mjesec.Text, godine.Text);


            //pos sluzi da odluci da li se vide strijelice ili ne 
            if (pos == 0)
            {
                leftgodina.Visible = false;
                leftmjesec.Visible = false;
            }
            if (pos == 11)
            {
                desnomjesec.Visible = false;
                Desnogodina.Visible = false;
            }


            //ne dovrsena funkcija ?
            this.getDataFromDatabase();



            for (int i = 0; i < 12; i++)
            {
                if ((int)listeMjeseci[i, 0] == Trenutnimjesec)
                {
                    //proslijeđivanje broja mjeseca i int godine 
                    KalendarMjeseci((int)listeMjeseci[i, 0], TrenutnaGodina);
                }
            }
        }
        private void getDataFromDatabase() //ne dovrsena funkcija 
        {
           
            
        }
        private void Prikaz(int m, int a)
        {
            for (int i = 0; i < 12; i++)
            {
                if ((int)listeMjeseci[i, 0] == m)
                {
                    maDate.Text = listeMjeseci[i, 1].ToString() + " " + a.ToString();
                    KalendarMjeseci(m, a);
                }
            }

        } // ne koristena funkcija 

        private void Prikaz(string m, string a)
        {
            maDate.Text = m + " " + a.ToString();
        }

        private void mjesec_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Prikaz(mjesec.SelectedItem.ToString(), godine.Text);
            for (int i = 0; i < 12; i++)
            {
                if (listeMjeseci[i, 1] == mjesec.SelectedItem)
                {
                    this.KalendarMjeseci((int)listeMjeseci[i, 0], int.Parse(godine.Text));
                    pos = i;
                    _mjesec = (int)listeMjeseci[i, 0];
                    if (pos == 0) firstMonth();
                    if (pos == 11) lastMonth();
                }
            }
            this.dateTimePicker();
        }

        private void godina_SelectedIndexChanged(object sender, EventArgs e)
        {
            _godina = int.Parse(godine.SelectedItem.ToString());
            this.KalendarMjeseci(_mjesec, _godina);
            this.Prikaz(mjesec.Text, godine.Text);
            this.dateTimePicker();
        }

        private void dateEvent_ValueChanged(object sender, EventArgs e)
        {
            _dan = dateEvent.Value.Day;
            _mjesec = dateEvent.Value.Month;
            _godina = dateEvent.Value.Year;
            this.Prikaz(listeMjeseci[_mjesec - 1, 1].ToString(), _godina.ToString());
            mjesec.Text = listeMjeseci[_mjesec - 1, 1].ToString();
            godine.Text = _godina.ToString();
        }

        
        private void label1_Click(object sender, EventArgs e)
        {
            pos = 0;
            mjesec.Text = listeMjeseci[pos, 1].ToString();
            firstMonth();
        }

        private void firstMonth()
        {
            leftgodina.Visible = false;
            leftmjesec.Visible = false;
            desnomjesec.Visible = true;
            Desnogodina.Visible = true;
        }

        private void betweenFistandLastMonth()
        {
            leftgodina.Visible = true;
            leftmjesec.Visible = true;
            desnomjesec.Visible = true;
            Desnogodina.Visible = true;
        }

        private void lastMonth()
        {
            leftgodina.Visible = true;
            leftmjesec.Visible = true;
            desnomjesec.Visible = false;
            Desnogodina.Visible = false;
        }
        
        private void label2_Click(object sender, EventArgs e)
        {
            pos--;
            if (pos > 0)
            {
                Prikaz(listeMjeseci[pos, 1].ToString(), godine.Text);
                mjesec.Text = listeMjeseci[pos, 1].ToString();
                betweenFistandLastMonth();
            }
            else
            {
                pos = 0;
                Prikaz(listeMjeseci[pos, 1].ToString(), godine.Text);
                mjesec.Text = listeMjeseci[pos, 1].ToString();
                firstMonth();
            }
        }
       
        private void label4_Click(object sender, EventArgs e)
        {
            pos++;
            if (pos < 11)
            {
                Prikaz(listeMjeseci[pos, 1].ToString(), godine.Text);
                mjesec.Text = listeMjeseci[pos, 1].ToString();
                betweenFistandLastMonth();
            }
            else
            {
                pos = 11;
                Prikaz(listeMjeseci[pos, 1].ToString(), godine.Text);
                mjesec.Text = listeMjeseci[pos, 1].ToString();
                lastMonth();
            }
        }
       
        private void label5_Click(object sender, EventArgs e)
        {
            pos = 11;
            mjesec.Text = listeMjeseci[pos, 1].ToString();
            lastMonth();
        }


        private void KalendarMjeseci(int m, int a)
        {
            //vraca broj dana u mjesecu
            int nbliste_dani = DateTime.DaysInMonth(a, m);

            //datum od prvog dana u mjesecu
            DateTime date = DateTime.Parse(1 + "/" + m.ToString() + "/" + a.ToString());
            int index = 0;
            int Sedmica = 0;
            bool pronaci = false;

			string[,] dnevnired = new string[7, 8]; //uredu 6 sedmica i 7 dana  

            DateTime myDT = new DateTime(date.Year, int.Parse(m.ToString()), 1, new JulianCalendar());
            myDT = myDT.AddDays(-13);

           
            // dok je indeks manji od broj dana 


            //dnevni red experiment 
           


            for (int i = 0; i < 8; i++)
            {
                if (i != 0)
                {
                    dnevnired[0, i] = liste_dan[i - 1];
                }
                else
                {
                    dnevnired[0, i] = "";
                
                }

            }




            Sedmica = Sedmica + 1;




            while (index < nbliste_dani)
            {

                
                //kolona 1 red 1,2,3,4,5,6,7  indeksiranje sedmica  u tabeli kalendara 
                dnevnired[Sedmica, 0] = (Sedmica).ToString();

                //ismarov kod 





                

                //ostatak tabele 
                for (int i = 1; i < 8; i++)
                {
                    if ((int)myDT.DayOfWeek == i || ( (int)myDT.DayOfWeek == 0 && i==7))//pravilno redanje sedmice u datumu
                    {
                        string dalipostojievent = pronadievent(myDT);


                        myDT=myDT.AddDays(1);

                        if (pronaci == false) //
                        {
                            index++;
                            //sedmica 0 dan 1
                            // drugo polje u tabeli       1          +         valjda naziv dogadaja ili datum ili predhodni datum
                            dnevnired[Sedmica, i] = index.ToString() + " " +dalipostojievent +dogadjaj(DateTime.Parse(index + "/" + m.ToString() + "/" + a.ToString()));
                            pronaci = true;
                            continue;
                        }
                        else if (pronaci == false)
                        {
                            dnevnired[Sedmica, i] = index.ToString() + "" ;
                            continue;
                        }


						if (index < nbliste_dani)
						{
							index++;
							// sedmica 0 dan 2
							// polje u kalendaru  =   2  +   valjda naziv dogadaja ili datum ili predhodni datum
							dnevnired[Sedmica, i] = index.ToString() + " " + dalipostojievent + dogadjaj(stringtodate.Stringtodatum($"{index}.{m.ToString()}.{a.ToString()}.0.0.0"));
							//;
						}
						else //prazno polje
							dnevnired[Sedmica, i] = "";
					}
                    else
                    {
                        dnevnired[Sedmica, i] = "";

                    }
				}
                Sedmica++;
            }

            chargerDataGrid(dnevnired, Sedmica,m,a);
        }

		private string pronadievent(DateTime myDT)
		{
            string datumzapretragu = myDT.Day.ToString("D2") + "." + myDT.Month.ToString("D2") + "." + myDT.Year;

            DogadajiTabela dogadaj = konekcija.Dogadaji.FirstOrDefault(X => X.DatumDogađaja.Contains(datumzapretragu));
            if (dogadaj != null)
            {
                return "event";

            }
            return "";
             
            
            



		}

		private string dogadjaj(DateTime date) //funkcija je kompleksna   //vraca string datuma koji se trazi
        {
            string str = "";
            bool first = true;
            this.getDataFromDatabase();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //pronalazi događaj u tabeli
                if (String.Format("{0:d}", date) == String.Format("{0:d}", (DateTime)dt.Rows[i][1]))
                {
                    if (first)
                    {
                        first = false;
                        str += "        " + String.Format("{0:t}", (DateTime)dt.Rows[i][1]) + ((char)13) + dt.Rows[i][2] + "\r\n";
                    }
                    else
                        str += ((char)13) + "-----------------------" + "\r\n" + "          " + String.Format("{0:t}", (DateTime)dt.Rows[i][1]) + "\r\n" + dt.Rows[i][2] + "\r\n";

                }
            }
            return str;
        }

        private void chargerDataGrid(string[,] data, int nbline,int mjesecint,int godinaint)
        {
            DataTable tab = new DataTable();
            tab.Columns.Add(new DataColumn());
            tab.Columns.Add(new DataColumn());
            tab.Columns.Add(new DataColumn());
            tab.Columns.Add(new DataColumn());
            tab.Columns.Add(new DataColumn());
            tab.Columns.Add(new DataColumn());
            tab.Columns.Add(new DataColumn());
            tab.Columns.Add(new DataColumn());

            //maDataGrid.DataSource = null;
            maDataGrid.Rows.Clear();
            //maDataGrid.Width = 30;
            

            for (int i = 0; i < nbline; i++)
            {
                maDataGrid.Rows.Add(data[i, 0], data[i, 1], data[i, 2], data[i, 3], data[i, 4], data[i, 5], data[i, 6], data[i, 7]);
                //Ismar
                if (i == 0)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        maDataGrid.Rows[i].Cells[j].Style.BackColor = Color.Transparent;
                    }
                }
            }

            //namjesti velicinu celija 
            foreach (var a in maDataGrid.Columns)
            {
                ((DataGridViewTextBoxColumn)a).Width = 75;





            }
            //ismar kod
            //namjesti indekse sedmice
            maDataGrid.Columns[0].Width = 25;
            //namjesti imena sedmice 
            maDataGrid.Rows[0].Height = 25;

            





            maDataGrid.Rows[0].Cells[0].Selected = false;

            //ismar kod za danasni dan
            int danasnjidan = DateTime.Now.Day;


            for (int i = 1; i < maDataGrid.Rows.Count; i++)
            {
                for (int j = 1; j < maDataGrid.Columns.Count; j++)
                {
                    string[] t = data[i, j].Split(' ');
                    DateTime date = new DateTime();

                    if (t[0] != "")
                    {
                        for (int m = 0; m < 12; m++)
                        {

                            if (mjesec.Text.Equals(listeMjeseci[m, 1]))
                            {
                                //date = DateTime.Parse(t[0].Trim() + "/" + listeMjeseci[m, 0] + "/" + godine.Text);
                                date = stringtodate.Stringtodatum2(t[0].Trim(), listeMjeseci[m, 0].ToString(), godine.Text);
                                continue;
                            }
                        }

                    }

                    if (DateTime.Compare(date, new DateTime(_godina, _mjesec, _dan)) == 0)
                        maDataGrid.Rows[i].Cells[j].Selected = true;

                    if (!data[i, j].Equals(""))
                        maDataGrid.Rows[i].Cells[j].Style.BackColor = Color.GreenYellow;

                    if (data[i, j].Length > 3)
                        maDataGrid.Rows[i].Cells[j].Style.Alignment = DataGridViewContentAlignment.TopLeft;

                    //ismar kod dodan 

                    //dan u kalendaru
                    string dan = data[i, j].Split(' ')[0]; //uzima string 

                    //if (dan != string.Empty && dan.Length == 2)
                    //{
                    //    dan = dan.Substring(0, 2);
                    //}

                    if (dan != string.Empty && dan.Length == 1)
                    {
                        int convertdan = int.Parse(dan);

                        dan = convertdan.ToString("D2");


                    }


                    //danasnji dan u dvocifremon formatu 
                    string dandanas = danasnjidan.ToString("D2");


                    if (dan==dandanas && Trenutnimjesec==mjesecint &&TrenutnaGodina==godinaint)
                        maDataGrid.Rows[i].Cells[j].Style.BackColor = Color.Orange;

                   
                }
            }
            //int mjesecint2 = mjesec.SelectedIndex + 1;
            //string godinestr = godine.SelectedItem.ToString();

            //stavidatumnalabel(mjesecint2.ToString(), godinestr);







        }

        private void addEvent_Click(object sender, EventArgs e)
        {
            if (txtEvent.Text != "" & txtEvent.Text != "Event : ")
            {

                try
                {
                  
                    string[] time = timeEvent.Text.Split(':');
                    int hour = 0;
                    int minute = 0;
                    if (time[0] != "  " && time[1] != "  ")
                    {
                        hour = int.Parse(time[0]);
                        minute = int.Parse(time[1]);
                    }
                    DateTime date = new DateTime(dateEvent.Value.Year, dateEvent.Value.Month, dateEvent.Value.Day, hour, minute, 0);
                   
                    this.KalendarMjeseci(_mjesec, _godina);
                    txtEvent.Text = "Event : ";
                    timeEvent.Text = "";
                  

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.StackTrace);
                }
            }
        }

        private void dateTimePicker()
        {
            dateEvent.Value = new DateTime(_godina, _mjesec, _dan);
        }

        private void maDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            
            //odvojen kod
            string[] value = maDataGrid.CurrentCell.Value.ToString().Split();
            _dan = int.Parse(value[0]);
            displayEvent.Text = "Event(s) : \r\n" + this.dogadjaj(new DateTime(_godina, _mjesec, _dan));
            this.dateTimePicker();
            this.KalendarMjeseci(_mjesec, _godina);
            //odvojen kod
            
            





        }

		private void maDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void Subota_Click(object sender, EventArgs e)
		{

		}

		private void Petak_Click(object sender, EventArgs e)
		{

		}

        private void addEvent_Click_1(object sender, EventArgs e)
        {

        }



      

		private void maDataGrid_SelectionChanged(object sender, EventArgs e)
		{
            if (maDataGrid.CurrentCell == null)
            {
                return;
            }
            if (maDataGrid.CurrentCell.RowIndex == 0)
            {

                maDataGrid.CurrentCell = null;

            }
       
        }

		private void mjesec_SelectedIndexChanged_1(object sender, EventArgs e)
		{
           


           
            

        }

		private void mjesec_SelectionChangeCommitted(object sender, EventArgs e)
		{
            if (mjesec.Text != (string)listeMjeseci[Trenutnimjesec - 1, 1])
            {

                //System.Windows.Forms.ComboBox senderComboBox = (System.Windows.Forms.ComboBox)sender;

               int selektovanmjesec = (int)listeMjeseci[mjesec.SelectedIndex, 0]; //drugi indeks je 1 da bi se uzeli stringovi iz matrice
               int selektovanagodina = int.Parse(godine.Text);



                //load_listIsmar();
                KalendarMjeseci(selektovanmjesec, selektovanagodina);
                //prikazuje mjesec i datum u onom panelu 
                Prikaz((string)listeMjeseci[mjesec.SelectedIndex, 1], selektovanagodina.ToString());



            }
        }

		private void godine_SelectionChangeCommitted(object sender, EventArgs e)
		{
            
        }

		private void godine_SelectedIndexChanged(object sender, EventArgs e)
		{

            if (eventactive == true)
            {
                //System.Windows.Forms.ComboBox senderComboBox = (System.Windows.Forms.ComboBox)sender;
                maDataGrid.Rows.Clear();
                int selektovanagodina = int.Parse(godine.Text); //drugi indeks je 1 da bi se uzeli stringovi iz matrice
                int selektovanimjesec = (int)listeMjeseci[mjesec.SelectedIndex, 0];
                string godinastring = godine.Text;

                maDataGrid.DataSource = null;
                maDataGrid.Rows.Clear();
                //load_listIsmar();
                KalendarMjeseci(selektovanimjesec, selektovanagodina);
                //prikazuje mjesec i datum u onom panelu 
                Prikaz((string)listeMjeseci[mjesec.SelectedIndex, 1], godinastring);

            }



        }

		private void leftgodina_Click(object sender, EventArgs e)
		{
            if (godine.SelectedIndex == 0)
            {
                return;
            }

            godine.SelectedIndex = godine.SelectedIndex - 1;



		}

		private void leftmjesec_Click(object sender, EventArgs e)
		{
            if (mjesec.SelectedIndex == 0)
            {
                if (godine.SelectedIndex == 0)
                {
                    return;
                }
                eventactive = false;
                godine.SelectedIndex = godine.SelectedIndex - 1;
                eventactive = true;

                Loadcompletemjesec(11);
                return;
            }

            Loadcompletemjesec(mjesec.SelectedIndex - 1);
           



        }

		private void desnomjesec_Click(object sender, EventArgs e)
		{
            if (mjesec.SelectedIndex == 11)
            {
                if (godine.SelectedIndex == 0)
                {
                    return;
                }
                eventactive = false;
				godine.SelectedIndex = godine.SelectedIndex + 1;
                eventactive = true;
				Loadcompletemjesec(0);
                    return;
            }


            Loadcompletemjesec(mjesec.SelectedIndex + 1);

          

        }

		private void Desnogodina_Click(object sender, EventArgs e)
		{
            if (godine.SelectedIndex == 4)
            {
                return;
            }

            godine.SelectedIndex = godine.SelectedIndex + 1;


        }
      
        void Loadcompletemjesec(int index)
        {

            mjesec.SelectedIndex = index;
            int selektovanmjesec = (int)listeMjeseci[mjesec.SelectedIndex, 0]; //drugi indeks je 1 da bi se uzeli stringovi iz matrice
            int selektovanagodina = int.Parse(godine.Text);



            //load_listIsmar();
            KalendarMjeseci(selektovanmjesec, selektovanagodina);
            //prikazuje mjesec i datum u onom panelu 
            Prikaz((string)listeMjeseci[mjesec.SelectedIndex, 1], selektovanagodina.ToString());




        } //loadise kalendar prilikom koristenja strelica

		private void maDataGrid_CellClick_1(object sender, DataGridViewCellEventArgs e)
		{
            //MessageBox.Show(maDataGrid.SelectedCells[0].Value.ToString());

            int mjesecint = mjesec.SelectedIndex + 1;
            string godinestr = godine.SelectedItem.ToString();

            stavidatumnalabel(mjesecint.ToString("D2"), godinestr);

            


        }

        void stavidatumnalabel(string mjesec,string godina)
        {

            string dan = maDataGrid.SelectedCells[0].Value.ToString();
            if (dan.Length > 2)
            {
                dan = dan.Substring(0, 2);
            }
            int danint = int.Parse(dan);
            dan = danint.ToString("D2");



            LB_datumdogađaja.Text = dan + "."+mjesec+"."+godina;

            Pan_događajiLista.Controls.Clear();
            DogadjajiPanel form = new DogadjajiPanel(LB_datumdogađaja.Text);
            form.TopLevel = false;
            Pan_događajiLista.Controls.Add(form);
            form.Dock = DockStyle.Fill;
            form.Show();




        }

		private void mjesec_SelectedIndexChanged_2(object sender, EventArgs e)
		{

		}
	}
}

