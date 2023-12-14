using IronXL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using proyecto;
using Project2;
using System.Runtime.CompilerServices;

namespace WinForms
{
    public partial class P3 : Form
    {
        public static P3 p3Instance;
        public DataTable dt;
        public List<Aircraft> aircraftList;
        
        public P3()
        {
            InitializeComponent();
            p3Instance = this;
        }

        private void P3_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void buttonProject3_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog(); //open dialog to choose file
            if (file.ShowDialog() == DialogResult.OK) //if there is a file chosen by the user
            {
                string fileExt = Path.GetExtension(file.FileName); //get the file extension
                if (fileExt.CompareTo(".xls") == 0 || fileExt.CompareTo(".xlsx") == 0)
                {
                    try
                    {
                        this.dt = ReadExcel(file.FileName); //read excel file
                        dataGridView.Visible = true;
                        dataGridView.DataSource = dt;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Please choose .xls or .xlsx file only.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error); //custom messageBox to show error
                }
            }

            this.aircraftList = ConvertDataTableToAircraftList(dt, "Indicativo", "TipoAeronave", "Estela", "PistaDesp", "ProcDesp", "HoraDespegue");
            
        }

        /// <summary>
        /// this method will read the excel file and copy its data into a datatable
        /// </summary>
        /// <param name="fileName">name of the file</param>
        /// <returns>DataTable</returns>
        private DataTable ReadExcel(string fileName)
        {
            WorkBook workbook = WorkBook.Load(fileName);
            //// Work with a single WorkSheet.
            ////you can pass static sheet name like Sheet1 to get that sheet
            ////WorkSheet sheet = workbook.GetWorkSheet("Sheet1");
            //You can also use workbook.DefaultWorkSheet to get default in case you want to get first sheet only
            WorkSheet sheet = workbook.DefaultWorkSheet;
            //Convert the worksheet to System.Data.DataTable
            //Boolean parameter sets the first row as column names of your table.
            return sheet.ToDataTable(true);
        }

        static List<Aircraft> ConvertDataTableToAircraftList(DataTable dataTable, string IDcolumn, string modelcolumn, string estelaColumn, string pistacolumn, string SIDcolumn, string horaDespcolumn)
        {
            List<Aircraft> aircraftList = new List<Aircraft>();

            // Verificar si la columna existe en la DataTable
            if (dataTable.Columns.Contains(IDcolumn) && dataTable.Columns.Contains(modelcolumn) && dataTable.Columns.Contains(estelaColumn) && dataTable.Columns.Contains(SIDcolumn) && dataTable.Columns.Contains(pistacolumn))
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    // Obtener el valor de las columnas del excel
                    string indicativoValue = Convert.ToString(row[IDcolumn]);
                    string modelValue = Convert.ToString(row[modelcolumn]);
                    string estelaValue = Convert.ToString(row[estelaColumn]);
                    string pistavalue = Convert.ToString(row[pistacolumn]);
                    string SIDvalue = Convert.ToString(row[SIDcolumn]);

                    //Variable para almacenar el resultado de la conversión
                    DateTime horaDespValue;
                    if (DateTime.TryParseExact(Convert.ToString(row[horaDespcolumn]), "MM/dd/yyyy H:mm:ss", null, System.Globalization.DateTimeStyles.None, out horaDespValue))
                    {
                        // La conversión fue exitosa, 'horaDespValue' contiene el objeto DateTime
                        Console.WriteLine($"Fecha y hora convertidas: {horaDespValue}");
                    }
                    else
                    {
                        // La conversión falló, manejar el caso según sea necesario
                        Console.WriteLine("Error al convertir la fecha y hora.");
                    }
                    // Crear un nuevo objeto Aircraft y asignar el valor de AircraftID
                    Aircraft aircraft = new Aircraft();
                    aircraft.AircraftID = indicativoValue;
                    aircraft.AircraftModel = modelValue;
                    aircraft.Estela = estelaValue;
                    aircraft.SID = SIDvalue;
                    aircraft.PistaDesp = pistavalue;
                    aircraft.horaDesp = horaDespValue;

                    // Agregar el objeto Aircraft a la lista
                    aircraftList.Add(aircraft);
                }
            }
            
            return aircraftList;
        }
    }

}
