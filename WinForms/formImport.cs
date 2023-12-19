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
using GMap.NET.Internals;



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
            loadingtextbox.Visible = false;
            progressBar1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadingtextbox.Visible = true;
            uploadedLabel.Visible = false;
            likeImage.Visible = false;
            progressBar1.Visible = false;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                loadingtextbox.Visible = true;
                progressBar1.Visible = true;
                progressBar1.Value = 0;
                //Abrir y leer el archivo
                Data fileData = new Data();
                progressBar1.Value = 10;
                Flight Flights = new Flight();
                loadingtextbox.Visible = true;
                FlightList ListaVuelos = new FlightList();
                
                AsterixFile newfile = new AsterixFile(openFileDialog1.FileName);
                loadingtextbox.Visible = true;
                List<List<byte[]>> dataFields = fileData.SortData(Flights, newfile);
                progressBar1.Value = 20;
                List<BitArray> FspecList = fileData.GetFspecList();
                progressBar1.Value = 40;
                loadingtextbox.Visible = true;
                List<Flight> Vuelos = ListaVuelos.Set_Message_Values(dataFields, FspecList);
                progressBar1.Value = 60;
                loadingtextbox.Visible = true;
                Vuelos= ListaVuelos.ApplyGeographicFilter(Vuelos);
                Vuelos = ListaVuelos.ApplyRequiredFilters(Vuelos);
                this.listaVuelos = Vuelos;
                this.Datos = FlightList.GetDataTable(listaVuelos);
                progressBar1.Value = 80;
                uploadedLabel.Visible = true;
                likeImage.Visible = true;
                loadingtextbox.Visible = true;

               
                this.Aviones = Aircraft.OrganizeFlights(Vuelos);
                this.Loaded = true;
                progressBar1.Value = 100;

                //KMLExporter.ExportToKML(Aviones, "flights2.kml");
                loadingtextbox.Visible = true;
            }
            else
            {
                loadingtextbox.Visible = false;
                MessageBox.Show("Please select a valid file (*.ast)");
            }
        }
    }
}
