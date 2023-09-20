using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using DLL_ripasso;

using System.IO;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using System.Globalization;
using CsvHelper;
using GMap.NET.WindowsForms.Markers;
namespace Crud
{
    public partial class Form1 : Form
    {
        public string filepath = @"output.csv";
        Class1 class1 = new Class1();
        public string file;
        public int scelta;
        public string[] nomecampi = { "Comune", "Provincia", "Regione", "Nome", "Anno inserimento", " Data e ora inserimento", " Identificatore in OpenStreetMap", "Longitudine", "Latitudine", "Mio valore","Cancellazione","Indice" };
        //array che contiene i nomi dei campi
        public bool fatto=false;
       
        public Form1()
        {
            InitializeComponent();
            listView1.View = View.Details;      //dati organizzati in colonne
            for (int i = 0; i < nomecampi.Length; i++)
            {
                listView1.Columns.Add(nomecampi[i],150);        //crezione delle colonne
                
            }
            scelta = 0;
            // Carica i dati dal file CSV e visualizza i punti sulla mappa
            VisualizzaPuntiDaCSV();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            gMapControl1.MapProvider = GoogleMapProvider.Instance;
            //get tiles from server only
            gMapControl1.Manager.Mode = AccessMode.ServerOnly;
            //not use proxy
            GMapProvider.WebProxy = null;
            //center map on moscow
            gMapControl1.Position = new PointLatLng(41.8919300, 12.5113300);
            gMapControl1.ShowCenter = false;
            //zoom min/max; default both = 2
            gMapControl1.MinZoom = 1;
            gMapControl1.MaxZoom = 20;
            //set zoom
            gMapControl1.Zoom = 5;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           


        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

      

       


        private void button7_Click(object sender, EventArgs e)
        {
            
            
            
            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

            
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {


            bool fatt = false;

            // Controlla se fatto è già true, se sì, mostra un messaggio e esci
            if (fatt)
            {
                MessageBox.Show("La funzione può essere eseguita una sola volta");
            }
            else
            {
                class1.Add();
                fatt = true;
            }
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {


        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void apriFileNellaCartellaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string folderPath = @"D:\Programmi\Crud\Crud\";

            if (System.IO.Directory.Exists(folderPath))
            {
                OpenFolder(folderPath);
            }
            else
            {
                Console.WriteLine("La cartella specificata non esiste");
            }
        }
        static void OpenFolder(string folderPath)
        {
            try
            {
                Process.Start("explorer.exe", folderPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Si è verificato un errore durante l'apertura della cartella: {ex.Message}");
            }
        }

        private void dimensioneFissaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fatto == false)
            {
                fatto = true;
                class1.Standart();
            }
            else
            {
                MessageBox.Show("La funzione é giá stata eseguita");
            }
        }

        private void chiudiProgrammaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void guna2DateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton1_Click_1(object sender, EventArgs e)
        {
            string[][] data = class1.Stampacampi();
            foreach (var rowData in data)
            {
                var item = new ListViewItem(rowData);
                listView1.Items.Add(item);
            }
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            if (guna2CheckBox1.Checked)
            {
                scelta = 1;
            }
            else if (guna2CheckBox2.Checked)
            {
                scelta = 2;
            }
            else if (guna2CheckBox1.Checked && guna2CheckBox2.Checked)
            {
                scelta = 3;
            }

            List<string[]> risultatiList = class1.Ricerca(guna2TextBox1.Text, guna2TextBox2.Text, scelta);

            // Converti la lista in una matrice di stringhe
            string[][] risultati = risultatiList.ToArray();

            // Pulisci la ListView prima di aggiungere nuovi dati
            listView1.Items.Clear();

            // Aggiungi i dati alla ListView
            foreach (string[] riga in risultati)
            {

                var item = new ListViewItem(riga);
                listView1.Items.Add(item);

            }


        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2CheckBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            string c = guna2TextBox3.Text;
            string p = guna2TextBox4.Text;
            string r = guna2TextBox5.Text;
            string n = guna2TextBox6.Text;
            string a = guna2TextBox7.Text;
            string i = guna2TextBox8.Text;
            string l = guna2TextBox9.Text;
            string la = guna2TextBox10.Text;
            string v = guna2TextBox11.Text;
            string d = guna2TextBox12.Text;
            class1.AggiuntaRecord(c, p, r, n, a, d, i, l, la, v);
        }
       
       

        private void gMapControl1_Load_1(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton4_Click_1(object sender, EventArgs e)
        {
           
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {
            
        }
        public void VisualizzaPuntiDaCSV()
        {
            using (var reader = new StreamReader(filepath))
            {
                using (var csv = new CsvReader(reader, new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = "," // Imposta il separatore su punto e virgola
                }))
                {
                    var records = csv.GetRecords<CSVDataPoint>(); // Assicurati che CSVDataPoint sia la classe corretta per i tuoi dati CSV

                    foreach (var record in records)
                    {
                        var point = new PointLatLng(record.Latitudine, record.Longitudine);
                        var marker = new GMarkerGoogle(point, GMarkerGoogleType.gray_small);

                        // Crea un overlay
                        GMapOverlay markersOverlay = new GMapOverlay("markers");

                        // Aggiungi il marker all'overlay
                        markersOverlay.Markers.Add(marker);

                        // Aggiungi l'overlay alla mappa
                        gMapControl1.Overlays.Add(markersOverlay);
                    }
                }
            }
        }
        public class CSVDataPoint //funzione che prende i valori di longitudine e di latitudine dal file csv
        {
            public double Longitudine { get; set; }
            public double Latitudine { get; set; }
        }

        private void mioValoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fatto == false)
            {
                fatto = true;
                class1.Add();
            }
            else
            {
                MessageBox.Show("La funzione é giá stata eseguita");
            }
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
        }

        private void guna2CircleButton1_Click_1(object sender, EventArgs e)
        {
            listView1.Items.Clear();
        }

        private void campiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"il file csv contiene {class1.Contatore().ToString()} campi ");
        }

        private void lunghezzaSingoliCampiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] lunghezze = class1.Lunghezzacampi();
            for (int i = 0; i < lunghezze.Length; i++)
            {
                MessageBox.Show($"Campo {nomecampi[i]}: {lunghezze[i]}");
            }
        }

        private void lunghezzaMassimaRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"La lunghezza massima di un record é di {class1.Lunghezza().ToString()}");
        }

        private void guna2GradientButton4_Click_2(object sender, EventArgs e)
        {
            string c = guna2TextBox3.Text;
            string p = guna2TextBox4.Text;
            string r = guna2TextBox5.Text;
            string n = guna2TextBox6.Text;
            string a = guna2TextBox7.Text;
            string i = guna2TextBox8.Text;
            string l = guna2TextBox9.Text;
            string la = guna2TextBox10.Text;
            string v = guna2TextBox11.Text;
            string d = guna2TextBox12.Text;
            class1.Modifica(int.Parse(guna2TextBox13.Text), c, p, r, n, a, i, l, la, v, d);
        }
    }
}
