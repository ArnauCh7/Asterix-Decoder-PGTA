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
using System.Data.Common;
using GMap.NET.MapProviders;
using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinForms
{
    public partial class P3 : Form
    {
        public static P3 p3Instance;
        public DataTable dt_flights;
        public DataTable dt_reactors;
        public List<Aircraft> aircraftList;
        public List<Aircraft> List06R;
        public List<Aircraft> List24L;
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
            
            
            string fileExt = Path.GetExtension("Excelp3\\2305_02_dep_lebl.xlsx"); //get the file extension
            string fileExt2 = Path.GetExtension("Excelp3\\Tabla_Clasificacion_aeronaves.xlsx"); //extension de la tabla de performance
            if (fileExt.CompareTo(".xls") == 0 || fileExt.CompareTo(".xlsx") == 0 || fileExt2.CompareTo(".xls") == 0 || fileExt2.CompareTo(".xlsx") == 0)
            {
                /*try
                {*/
                    this.dt_flights = ReadExcel("Excelp3\\2305_02_dep_lebl.xlsx"); //read excel file
                    this.dt_reactors = ReadExcel("Excelp3\\Tabla_Clasificacion_aeronaves.xlsx"); //leer la tabla de clasificacion segun reactor performance
                    dataGridView.Visible = true;
                    dataGridView.DataSource = dt_reactors;
                    this.aircraftList = ConvertDataTableToAircraftList(dt_flights, dt_reactors, "Indicativo", "TipoAeronave", "Estela", "PistaDesp", "ProcDesp", "HoraDespegue");
                    this.aircraftList = FilterList(formImport.importInstance.Aviones, this.aircraftList);
                    this.List06R = SepararListas(aircraftList).Item1;
                    this.List24L = SepararListas(aircraftList).Item2;

                List<int> posiciones1 = SimmultaneousMessages(List24L[93], List24L[94]).Item1;
                List<int> posiciones2 = SimmultaneousMessages(List24L[93], List24L[94]).Item2;
                /*}
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }*/
            }
            else
            {
                MessageBox.Show("Please choose .xls or .xlsx file only.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error); //custom messageBox to show error
            }
            
            
        }

        /// <summary>
        /// this method will read the excel file and copy its data into a datatable
        /// </summary>
        /// <param name="fileName">name of the file</param>
        /// <returns>DataTable</returns>
        private DataTable ReadExcel(string fileName)
        {
            WorkBook workbook = WorkBook.Load(fileName);
            
            WorkSheet sheet = workbook.DefaultWorkSheet;
            //Convert the worksheet to System.Data.DataTable
            //Boolean parameter sets the first row as column names of your table.
            return sheet.ToDataTable(true);
        }

        static List<Aircraft> ConvertDataTableToAircraftList(DataTable dataTable, DataTable reactorTable, string IDcolumn, string modelcolumn, string estelaColumn, string pistacolumn, string SIDcolumn, string horaDespcolumn)
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

                    for(int i = 0; i < reactorTable.Columns.Count; i++)
                    {
                        string columnName = reactorTable.Columns[i].ColumnName;

                        foreach (DataRow reactorrow in reactorTable.Rows)
                        {
                            string modelcheck = Convert.ToString(reactorrow[columnName]);
                            if (modelcheck == aircraft.AircraftModel)
                            {
                                aircraft.reactorType = columnName;
                            }
                            else
                            {
                                aircraft.reactorType = "R"; //Asumimos que si no esta en la tabla es R
                            }
                        }
                    }
                    // Agregar el objeto Aircraft a la lista
                    aircraftList.Add(aircraft);
                }
            }
            return aircraftList;
        }


        static double CalculateDistance(double u1, double v1, double u2, double v2)
        {
            double distance = Math.Sqrt(Math.Pow(u2 - u1, 2) + Math.Pow(v2 - v1, 2));
            return distance;
        }
        
        
        static List<Aircraft> FilterList(List<Aircraft> listaAsterixVolando, List<Aircraft> listafiltrada)
        {

            foreach (Aircraft air in listafiltrada)
            {
                
                //Copiar los datos decodificados de solamente los despegues a la lista creada con la info del excel de despegues
                foreach(Aircraft plane in listaAsterixVolando)
                {
                    if(air.AircraftID == plane.AircraftID.Trim())
                    {
                        air.LatitudeList = plane.LatitudeList;
                        air.LongitudeList = plane.LongitudeList;
                        air.Time = plane.Time;
                        air.TAS = plane.TAS;
                        air.IAS = plane.IAS;
                        air.GS = plane.GS;
                        air.FL_ft = plane.FL_ft;
                        air.UList = plane.UList;
                        air.VList = plane.VList;
                        air.statList = plane.statList;
                    }
                }

                int count = 0;
                //eliminar todos los datos de las posiciones, tiempos etc que existan de antes que el avion esté en el aire
                foreach(string status in air.statList)
                {
                    if (status.Split(',')[2].Trim() == "aircraft on ground")
                    {
                        count++;
                    }
                }

                if(count != 0)
                {
                    air.LongitudeList.RemoveRange(0, count);
                    air.LatitudeList.RemoveRange(0, count);
                    air.UList.RemoveRange(0, count);
                    air.VList.RemoveRange(0, count);
                    air.Time.RemoveRange(0, count);
                    air.FL_ft.RemoveRange(0, count);
                    air.GS.RemoveRange(0, count);
                    air.TAS.RemoveRange(0, count);
                    air.IAS.RemoveRange(0, count);
                    air.statList.RemoveRange(0, count);
                }
                

            }

            return listafiltrada;
        }


        static (List<Aircraft>, List<Aircraft> ) SepararListas(List<Aircraft> listToSeparate)
        {
            List<Aircraft> lista06R = new List<Aircraft>();
            List<Aircraft> lista24L = new List<Aircraft>();

            foreach(Aircraft air in listToSeparate)
            {
                if(air.PistaDesp == "LEBL-06R")
                {
                    lista06R.Add(air);
                }
                else if(air.PistaDesp == "LEBL-24L")
                {
                    lista24L.Add(air);
                }
            }

            return (lista06R, lista24L);

        }


        static (List<int>, List<int> ) SimmultaneousMessages(Aircraft first, Aircraft second)
        {
            List<int> timedMessagesPosition_1 = new List<int>();
            List<int> timedMessagesPosition_2 = new List<int>();

            foreach (string time in first.Time)
            {
                string time1secs = time.Substring(0, time.Length - 4);
                foreach (string time2 in second.Time)
                {
                    string time2secs = time2.Substring(0, time2.Length - 4);
                    if (time2secs == time1secs)
                    {
                        int firstIndex = first.Time.IndexOf(time);
                        int secondIndex = second.Time.IndexOf(time2);

                        timedMessagesPosition_1.Add(firstIndex);
                        timedMessagesPosition_2.Add(secondIndex);
                    }
                }
            }
            
            return (timedMessagesPosition_1, timedMessagesPosition_2);

        }
        
        static (bool, int) CheckTrailDistance(List<int> first, List<int> second)
        {
            bool overall = false;
            int collisions = 0;





            return (overall, collisions);
        }



        
    }

}
