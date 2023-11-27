using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project2;
using proyecto;
using System;
using System.IO;
using System.Formats.Asn1;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;



namespace WinForms
{
    public partial class formImport : Form
    {
        public List<Flight> listaVuelos;
        public static formImport importInstance;
        public List<Aircraft> Aviones;
        public bool Loaded = false;
        public DataTable Datos;
        //public PictureBox likePicture;
        //public Label uclabel;

        public List<Flight> GetFlightList()
        {

            return this.listaVuelos;
        }

        public formImport()
        {
            InitializeComponent();
            importInstance = this;
            //uclabel = uploadedLabel;
            //likePicture = likeImage;
        }

        private void formImport_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            likeImage.Visible = false;
            uploadedLabel.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            uploadedLabel.Visible = false;
            likeImage.Visible = false;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Abrir y leer el archivo
                Data fileData = new Data();
                Flight Flights = new Flight();
                FlightList ListaVuelos = new FlightList();
                AsterixFile newfile = new AsterixFile(openFileDialog1.FileName);

                List<List<byte[]>> dataFields = fileData.SortData(Flights, newfile);

                List<BitArray> FspecList = fileData.GetFspecList();
                progressBar1.Value = 50;
                List<Flight> Vuelos = ListaVuelos.Set_Message_Values(dataFields, FspecList);



                this.listaVuelos = Vuelos;
                this.Datos = FlightList.GetDataTable(listaVuelos);

                uploadedLabel.Visible = true;
                likeImage.Visible = true;

                //List<Flight> Volando = new List<Flight>();
                //Volando.Add(Vuelos[0]);
                //Volando.Add(Vuelos[1]);
                //Volando.Add(Vuelos[2]);

                this.Aviones = Aircraft.OrganizeFlights(Vuelos);
                this.Loaded = true;
                progressBar1.Value = 100;
                //KMLExporter.ExportToKML(Aviones, "flights2.kml");
            }
            else
            {
                MessageBox.Show("Please select a valid file (*.ast)");
            }
        }
    }
}
