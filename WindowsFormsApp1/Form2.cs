using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using System.Globalization;
using System.IO;
using CsvHelper;
using GMap.NET.WindowsForms.Markers;




namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        private GMapControl gMapControl;

        public string filepath;
        public Form2()
        {
            InitializeComponent();
            filepath = @"D:\Programmi\Crud\Crud\bin\Debug\output.csv";
            // Inizializza la mappa
            gMapControl = new GMapControl();
            gMapControl1.Dock = DockStyle.Fill;
            gMapControl.MapProvider = GMapProviders.GoogleMap;
            gMapControl.BoundsOfMap = new GMap.NET.RectLatLng(46.24268488207179, 6.25001, 35.66134, 18.69151);
            gMapControl.Position = new PointLatLng(41.9028, 12.4964) ;
            gMapControl.Zoom = 15;
            Controls.Add(gMapControl);
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
          
            gMapControl1.Left = 10; // Posizione orizzontale
            gMapControl1.Top = 10;  // Posizione verticale
            gMapControl1.BringToFront(); // Porta il controllo GMapControl in primo piano






        }

        private void Form1_Load(object sender, EventArgs e)
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
                        var marker = new GMarkerGoogle(point, GMarkerGoogleType.green_small);

                        // Crea un overlay
                        GMapOverlay markersOverlay = new GMapOverlay("markers");

                        // Aggiungi il marker all'overlay
                        markersOverlay.Markers.Add(marker);

                        // Aggiungi l'overlay alla mappa
                        gMapControl.Overlays.Add(markersOverlay);
                    }
                }
            }
        }

        public class CSVDataPoint
        {
            public double Longitudine { get; set; }
            public double Latitudine { get; set; }
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {

        }

        private void gMapControl1_Load_1(object sender, EventArgs e)
        {
            // Carica i dati dal file CSV e visualizza i punti sulla mappa
            VisualizzaPuntiDaCSV();
        }
    }
}
