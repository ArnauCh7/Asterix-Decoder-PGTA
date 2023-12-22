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
using System.Diagnostics;
using OfficeOpenXml;
using System.IO;
using Microsoft.VisualBasic.ApplicationServices;
using System.Globalization;



namespace WinForms
{
    public partial class P3 : Form
    {
        
        public static P3 p3Instance;
        public DataTable dt_flights;
        public DataTable dt_reactors;
        public DataTable dt_misma24L;
        public DataTable dt_misma06R;
        public List<Aircraft> aircraftList;
        public List<Aircraft> List06R;
        public List<Aircraft> List24L;

        ///////////////24L////////////////
        public List<bool> listaCumplimientosEstela24L;
        public List<int> listaColisionesEstela24L;
        public List<bool> listaCumplimientosRadar24L;
        public List<int> listaColisionesRadar24L;
        public List<bool> listaCumplimientosLoA24L;
        public List<int> listaColisionesLoA24L;
        public List<string[]> listnames24L;
        public List<List<Double>>Distancias24L;

        ////////////////06R///////////////
        public List<bool> listaCumplimientosEstela06R;
        public List<int> listaColisionesEstela06R;
        public List<bool> listaCumplimientosRadar06R;
        public List<int> listaColisionesRadar06R;
        public List<bool> listaCumplimientosLoA06R;
        public List<int> listaColisionesLoA06R;
        public List<string[]> listnames06R;
        public List<List<Double>> Distancias06R;
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

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "xlsx files (*.xlsx)|*.xlsx";
            saveFileDialog.DefaultExt = "xlsx";
            saveFileDialog.AddExtension = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var xlsxPath = saveFileDialog.FileName;
                string fileExt = Path.GetExtension("Excelp3\\2305_02_dep_lebl.xlsx"); //get the file extension
                string fileExt2 = Path.GetExtension("Excelp3\\Tabla_Clasificacion_aeronaves.xlsx"); //extension de la tabla de performance
                string fileExt3 = Path.GetExtension("Excelp3\\Tabla_misma_SID_06R.xlsx");
                string fileExt4 = Path.GetExtension("Excelp3\\Tabla_misma_SID_24L.xlsx");

                if (fileExt.CompareTo(".xls") == 0 || fileExt.CompareTo(".xlsx") == 0 || fileExt2.CompareTo(".xls") == 0 || fileExt2.CompareTo(".xlsx") == 0 || fileExt3.CompareTo(".xls") == 0 || fileExt3.CompareTo(".xlsx") == 0 || fileExt4.CompareTo(".xls") == 0 || fileExt4.CompareTo(".xlsx") == 0)
                {
                    /*try
                    {*/
                    this.dt_flights = ReadExcel("Excelp3\\2305_02_dep_lebl.xlsx"); //read excel file
                    this.dt_reactors = ReadExcel("Excelp3\\Tabla_Clasificacion_aeronaves.xlsx"); //leer la tabla de clasificacion segun reactor performance
                    this.dt_misma06R = ReadExcel("Excelp3\\Tabla_misma_SID_06R.xlsx");//Leer tabla de misma SID de la 06R
                    this.dt_misma24L = ReadExcel("Excelp3\\Tabla_misma_SID_24L.xlsx");//Lerr tabla de la misma SID de la 24L


                    this.aircraftList = ConvertDataTableToAircraftList(dt_flights, dt_reactors, "Indicativo", "TipoAeronave", "Estela", "PistaDesp", "ProcDesp", "HoraDespegue");
                    this.aircraftList = FilterList(formImport.importInstance.Aviones, this.aircraftList);
                    this.List06R = SepararListas(aircraftList).Item1;
                    this.List24L = SepararListas(aircraftList).Item2;


                    /////////////////24L/////////////////////
                    this.listaCumplimientosEstela24L = new List<bool>();
                    this.listaColisionesEstela24L = new List<int>();

                    this.listaCumplimientosRadar24L = new List<bool>();
                    this.listaColisionesRadar24L = new List<int>();

                    this.listaCumplimientosLoA24L = new List<bool>();
                    this.listaColisionesLoA24L = new List<int>();
                    this.Distancias24L = new List<List<double>>();

                    /////////////////06R/////////////////////
                    this.listaCumplimientosEstela06R = new List<bool>();
                    this.listaColisionesEstela06R = new List<int>();

                    this.listaCumplimientosRadar06R = new List<bool>();
                    this.listaColisionesRadar06R = new List<int>();

                    this.listaCumplimientosLoA06R = new List<bool>();
                    this.listaColisionesLoA06R = new List<int>();
                    this.Distancias06R = new List<List<double>>();

                    ///////////////////24L//////////////////
                    listnames24L = new List<string[]>();
                    int totalColisonesRadar24L = 0;
                    int totalColisonesEstela24L = 0;
                    int totalColisonesLoA24L = 0;

                    //////////////////06R///////////////////
                    listnames06R = new List<string[]>();
                    int totalColisonesRadar06R = 0;
                    int totalColisonesEstela06R = 0;
                    int totalColisonesLoA06R = 0;


                    /////////////////////////////////////////////////////// 24L /////////////////////////////////////////////////////////////////////

                    if (List24L.Count != 0)
                    {
                        for (int i = 0; i < List24L.Count - 1; i++)
                        {
                            if (List24L[i].Time.Count != 0)
                            {
                                List<int> posiciones1 = SimmultaneousMessages(List24L[i], List24L[i + 1]).Item1;
                                List<int> posiciones2 = SimmultaneousMessages(List24L[i], List24L[i + 1]).Item2;
                                Aircraft primero = List24L[i];
                                Aircraft segundo = List24L[i + 1];

                                List<double> listaDistanciasMensajes = CalculateTimedMessageDistances(posiciones1, posiciones2, primero, segundo);

                                bool cumplimientoEstela = CumplimientoEstela(listaDistanciasMensajes, primero, segundo).Item1;
                                int colisionesEstela = CumplimientoEstela(listaDistanciasMensajes, primero, segundo).Item2;

                                bool cumplimientoRadar = CumplimientoRadar(listaDistanciasMensajes).Item1;
                                int colisionesRadar = CumplimientoRadar(listaDistanciasMensajes).Item2;

                                bool cumplimientoLoA = CumplimientoLoA(listaDistanciasMensajes, primero, segundo, this.dt_misma24L, this.dt_misma06R).Item1;
                                int colisionesLoA = CumplimientoLoA(listaDistanciasMensajes, primero, segundo, this.dt_misma24L, this.dt_misma06R).Item2;

                                this.listaCumplimientosEstela24L.Add(cumplimientoEstela);
                                this.listaColisionesEstela24L.Add(colisionesEstela);

                                this.listaCumplimientosRadar24L.Add(cumplimientoRadar);
                                this.listaColisionesRadar24L.Add(colisionesRadar);

                                this.listaCumplimientosLoA24L.Add(cumplimientoLoA);
                                this.listaColisionesLoA24L.Add(colisionesLoA);

                                string[] nombres = { List24L[i].AircraftID, List24L[i + 1].AircraftID };
                                listnames24L.Add(nombres);

                                if (!cumplimientoEstela)
                                {
                                    totalColisonesEstela24L++;
                                }
                                if (!cumplimientoRadar)
                                {
                                    totalColisonesRadar24L++;
                                }
                                if (!cumplimientoLoA)
                                {
                                    totalColisonesLoA24L++;
                                }

                                Distancias24L.Add(listaDistanciasMensajes);
                            }

                        }

                    }

                    /////////////////////////////////////////////////////// 06R /////////////////////////////////////////////////////////////////////
                    if (List06R.Count != 0)
                    {
                        for (int i = 0; i < List06R.Count - 1; i++)
                        {
                            if (List06R[i].Time.Count != 0)
                            {
                                List<int> posiciones1 = SimmultaneousMessages(List06R[i], List06R[i + 1]).Item1;
                                List<int> posiciones2 = SimmultaneousMessages(List06R[i], List06R[i + 1]).Item2;
                                Aircraft primero = List06R[i];
                                Aircraft segundo = List06R[i + 1];

                                List<double> listaDistanciasMensajes = CalculateTimedMessageDistances(posiciones1, posiciones2, primero, segundo);

                                bool cumplimientoEstela = CumplimientoEstela(listaDistanciasMensajes, primero, segundo).Item1;
                                int colisionesEstela = CumplimientoEstela(listaDistanciasMensajes, primero, segundo).Item2;

                                bool cumplimientoRadar = CumplimientoRadar(listaDistanciasMensajes).Item1;
                                int colisionesRadar = CumplimientoRadar(listaDistanciasMensajes).Item2;

                                bool cumplimientoLoA = CumplimientoLoA(listaDistanciasMensajes, primero, segundo, this.dt_misma24L, this.dt_misma06R).Item1;
                                int colisionesLoA = CumplimientoLoA(listaDistanciasMensajes, primero, segundo, this.dt_misma24L, this.dt_misma06R).Item2;

                                this.listaCumplimientosEstela06R.Add(cumplimientoEstela);
                                this.listaColisionesEstela06R.Add(colisionesEstela);

                                this.listaCumplimientosRadar06R.Add(cumplimientoRadar);
                                this.listaColisionesRadar06R.Add(colisionesRadar);

                                this.listaCumplimientosLoA06R.Add(cumplimientoLoA);
                                this.listaColisionesLoA06R.Add(colisionesLoA);

                                string[] nombres = { List06R[i].AircraftID, List06R[i + 1].AircraftID };
                                listnames06R.Add(nombres);

                                if (!cumplimientoEstela)
                                {
                                    totalColisonesEstela06R++;
                                }
                                if (!cumplimientoRadar)
                                {
                                    totalColisonesRadar06R++;
                                }
                                if (!cumplimientoLoA)
                                {
                                    totalColisonesLoA06R++;
                                }

                                Distancias06R.Add(listaDistanciasMensajes);
                            }

                        }

                    }

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


                string rutaarchivo = xlsxPath;

                CrearArchivoExcel(rutaarchivo, listnames24L, List24L, Distancias24L, listaCumplimientosLoA24L, listaColisionesLoA24L, listaCumplimientosRadar24L, listaColisionesRadar24L, listaCumplimientosEstela24L, listaColisionesEstela24L, listnames06R, List06R, Distancias06R, listaCumplimientosLoA06R, listaColisionesLoA06R, listaCumplimientosRadar06R, listaColisionesRadar06R, listaCumplimientosEstela06R, listaColisionesEstela06R);

            }
            else
            {
                MessageBox.Show($"No name or directory selected. Please insert a valid name or location", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    for (int i = 0; i < reactorTable.Columns.Count; i++)
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

        /// <summary>
        /// Calcula la distancia entre 2 puntos dadas sus coordenadas estereograficas proyectadas en el plano correcto
        /// </summary>
        /// <param name="u1"></param>
        /// <param name="v1"></param>
        /// <param name="u2"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        static double CalculateDistance(double u1, double v1, double u2, double v2)
        {
            double distance = Math.Sqrt(Math.Pow(u2 - u1, 2) + Math.Pow(v2 - v1, 2));
            return distance;
        }

        /// <summary>
        /// Filtra las listas de vuelo por Callsign de los despegues y por aviones que esten en el aire
        /// </summary>
        /// <param name="listaAsterixVolando"></param>
        /// <param name="listafiltrada"></param>
        /// <returns></returns>
        static List<Aircraft> FilterList(List<Aircraft> listaAsterixVolando, List<Aircraft> listafiltrada)
        {

            foreach (Aircraft air in listafiltrada)
            {

                //Copiar los datos decodificados de solamente los despegues a la lista creada con la info del excel de despegues
                foreach (Aircraft plane in listaAsterixVolando)
                {
                    if (air.AircraftID == plane.AircraftID.Trim())
                    {
                        if (air.PistaDesp != "LEBL-24R")
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

                }

                int count = 0;
                //eliminar todos los datos de las posiciones, tiempos etc que existan de antes que el avion esté en el aire
                foreach (string status in air.statList)
                {
                    if (status.Split(',')[2].Trim() == "aircraft on ground")
                    {
                        count++;
                    }
                }

                if (count != 0)
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

                foreach (string latitude in air.LatitudeList)
                {
                    int index = air.LatitudeList.IndexOf(latitude);
                    string longitude = air.LongitudeList[index];

                    double latitude1 = Convert.ToDouble(latitude);
                    double longitude1 = Convert.ToDouble(longitude);
                    // Verificar las condiciones de filtrado
                    if (latitude1 >= 40.9 && latitude1 <= 41.7 && longitude1 >= 1.5 && longitude1 <= 2.6)
                    {

                    }
                    else
                    {
                        air.LongitudeList.RemoveAt(index);
                        air.LatitudeList.RemoveAt(index);
                        air.UList.RemoveAt(index);
                        air.VList.RemoveAt(index);
                        air.Time.RemoveAt(index);
                        air.FL_ft.RemoveAt(index);
                        air.GS.RemoveAt(index);
                        air.TAS.RemoveAt(index);
                        air.IAS.RemoveRange(0, count);
                        air.statList.RemoveAt(index);
                    }

                }




            }

            return listafiltrada;
        }


        /// <summary>
        /// Separa los aviones segun por que pista despeguen
        /// </summary>
        /// <param name="listToSeparate"></param>
        /// <returns></returns>
        static (List<Aircraft>, List<Aircraft>) SepararListas(List<Aircraft> listToSeparate)
        {
            List<Aircraft> lista06R = new List<Aircraft>();
            List<Aircraft> lista24L = new List<Aircraft>();

            foreach (Aircraft air in listToSeparate)
            {
                if (air.PistaDesp == "LEBL-06R")
                {
                    lista06R.Add(air);
                }
                else if (air.PistaDesp == "LEBL-24L")
                {
                    lista24L.Add(air);
                }
            }

            return (lista06R, lista24L);

        }

        /// <summary>
        /// Mira que mensajes se envian al mismo tiempo dados dos aviones y da las posiciones de los vectores del tiempo
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        static (List<int>, List<int>) SimmultaneousMessages(Aircraft first, Aircraft second)
        {
            List<int> timedMessagesPosition_1 = new List<int>();
            List<int> timedMessagesPosition_2 = new List<int>();

            foreach (string time in first.Time)
            {
                DateTime timeparsed1 = DateTime.ParseExact(time, "HH:mm:ss.fff", null);
                foreach (string time2 in second.Time)
                {
                    DateTime timeparsed2 = DateTime.ParseExact(time2, "HH:mm:ss.fff", null);
                    TimeSpan diferencia = timeparsed1 - timeparsed2;
                    if (Math.Abs(diferencia.TotalSeconds) <= 2)
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


        /// <summary>
        /// Dadas las posiciones de los vectores calcula las distancias entre las coodrenadas de los aviones cuando se encuantran en los puntos donde han enviado
        /// los mensajes al mismo tiempo y las guarda en una lista
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="primero"></param>
        /// <param name="segundo"></param>
        /// <returns></returns>
        static List<double> CalculateTimedMessageDistances(List<int> positionlistfirst, List<int> positionlistsecond, Aircraft primero, Aircraft segundo)
        {
            List<double> listaDistancias = new List<double>();

            foreach (int i in positionlistfirst)
            {
                int j = positionlistsecond[positionlistfirst.IndexOf(i)];

                double distance = CalculateDistance(Convert.ToDouble(primero.UList[i]), Convert.ToDouble(primero.VList[i]), Convert.ToDouble(segundo.UList[j]), Convert.ToDouble(segundo.VList[j]));

                listaDistancias.Add(distance);
            }

            return listaDistancias;
        }



        /// <summary>
        /// Mira si entre 2 vuelos se cumple la distancia radar y devuelve si se cumple y en cuantos mensajes se incumple
        /// </summary>
        /// <param name="listaDistancias"></param>
        /// <returns></returns>
        static (bool, int) CumplimientoRadar(List<double> listaDistancias)
        {
            bool cumplimiento = true;
            int colisiones = 0;

            foreach (double dist in listaDistancias)
            {

                if (dist < 3)
                {
                    colisiones++;
                    cumplimiento = false;

                }

            }


            return (cumplimiento, colisiones);
        }




        /// <summary>
        /// Mira si entre los 2 vuelos se cumple la distancia en los momentos donde han enviado el mensaje al mismo tiempo segun los criterios de estela
        /// y guarda el numero de incumplimientos
        /// </summary>
        /// <param name="listaDistancias"></param>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        static (bool, int) CumplimientoEstela(List<double> listaDistancias, Aircraft first, Aircraft second)
        {
            bool cumplimiento = true;
            int colisiones = 0;

            foreach (double dist in listaDistancias)
            {

                if (first.Estela == "Super Pesada")
                {
                    if (second.Estela == "Pesada" && dist < 6)
                    {
                        colisiones++;
                        cumplimiento = false;
                    }
                    else if (second.Estela == "Media" && dist < 7)
                    {
                        colisiones++;
                        cumplimiento = false;
                    }
                    else if (second.Estela == "Ligera" && dist < 8)
                    {
                        colisiones++;
                        cumplimiento = false;
                    }
                }
                else if (first.Estela == "Pesada")
                {
                    if (second.Estela == "Pesada" && dist < 4)
                    {
                        colisiones++;
                        cumplimiento = false;
                    }
                    else if (second.Estela == "Media" && dist < 5)
                    {
                        colisiones++;
                        cumplimiento = false;
                    }
                    else if (second.Estela == "Ligera" && dist < 6)
                    {
                        colisiones++;
                        cumplimiento = false;
                    }
                }
                else if (first.Estela == "Media")
                {
                    if (second.Estela == "Ligera" && dist < 5)
                    {
                        colisiones++;
                        cumplimiento = false;
                    }
                    /*else if(second.Estela == "Media" && dist < 3)
                    {
                        colisiones++;
                        cumplimiento = false;
                    }
                    else if (second.Estela == "Pesada" && dist < 3)
                    {
                        colisiones++;
                        cumplimiento = false;
                    }*/
                }
                /*else if (first.Estela == "Ligera")
                {
                    if(second.Estela == "Ligera" && dist < 3)
                    {
                        colisiones++;
                        cumplimiento = false;
                    }
                    else if( second.Estela == "Media" && dist < 3)
                    {
                        colisiones++;
                        cumplimiento = false;
                    }
                    else if ( second.Estela == "Pesada" && dist < 3)
                    {
                        colisiones++;
                        cumplimiento = false;
                    }
                }*/
            }


            return (cumplimiento, colisiones);
        }


        /// <summary>
        /// Mira si se cumplen las distancias
        /// </summary>
        /// <param name="listaDistancias"></param>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="dt_24L"></param>
        /// <param name="dt_06R"></param>
        /// <returns></returns>
        static (bool, int) CumplimientoLoA(List<double> listaDistancias, Aircraft first, Aircraft second, DataTable dt_24L, DataTable dt_06R)
        {
            bool cumplimiento = true;
            int colisiones = 0;

            foreach (double dist in listaDistancias)
            {
                if (first.PistaDesp == "LEBL-24L")
                {


                    if (first.reactorType == "HP")//HP/////////////////////////////////////////////////////////////////
                    {
                        if (second.reactorType == "HP")
                        {
                            if (EstaEnColumna(dt_24L, "Misma_SID_G1", first.SID) && EstaEnColumna(dt_24L, "Misma_SID_G1", second.SID) && dist < 5)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (EstaEnColumna(dt_24L, "Misma_SID_G2", first.SID) && EstaEnColumna(dt_24L, "Misma_SID_G2", second.SID) && dist < 5)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (EstaEnColumna(dt_24L, "Misma_SID_G3", first.SID) && EstaEnColumna(dt_24L, "Misma_SID_G3", second.SID) && dist < 5)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (dist < 3)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                        else if (second.reactorType == "R")
                        {
                            if (EstaEnColumna(dt_24L, "Misma_SID_G1", first.SID) && EstaEnColumna(dt_24L, "Misma_SID_G1", second.SID) && dist < 5)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (EstaEnColumna(dt_24L, "Misma_SID_G2", first.SID) && EstaEnColumna(dt_24L, "Misma_SID_G2", second.SID) && dist < 5)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (EstaEnColumna(dt_24L, "Misma_SID_G3", first.SID) && EstaEnColumna(dt_24L, "Misma_SID_G3", second.SID) && dist < 5)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (dist < 3)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                        else if (second.reactorType == "LP")
                        {
                            if (EstaEnColumna(dt_24L, "Misma_SID_G1", first.SID) && EstaEnColumna(dt_24L, "Misma_SID_G1", second.SID) && dist < 5)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (EstaEnColumna(dt_24L, "Misma_SID_G2", first.SID) && EstaEnColumna(dt_24L, "Misma_SID_G2", second.SID) && dist < 5)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (EstaEnColumna(dt_24L, "Misma_SID_G3", first.SID) && EstaEnColumna(dt_24L, "Misma_SID_G3", second.SID) && dist < 5)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (dist < 3)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                        else if (second.reactorType == "NR+")
                        {
                            if (dist < 3)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                        else if (second.reactorType == "NR-")
                        {
                            if (dist < 3)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                        else if (second.reactorType == "NR")
                        {
                            if (dist < 3)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                    }
                    else if (first.reactorType == "R")//R////////////////////////////////////////////////////////////////////////////////////////
                    {
                        if (second.reactorType == "HP")
                        {
                            if (EstaEnColumna(dt_24L, "Misma_SID_G1", first.SID) && EstaEnColumna(dt_24L, "Misma_SID_G1", second.SID) && dist < 7)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (EstaEnColumna(dt_24L, "Misma_SID_G2", first.SID) && EstaEnColumna(dt_24L, "Misma_SID_G2", second.SID) && dist < 7)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (EstaEnColumna(dt_24L, "Misma_SID_G3", first.SID) && EstaEnColumna(dt_24L, "Misma_SID_G3", second.SID) && dist < 7)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (dist < 5)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                        else if (second.reactorType == "R")
                        {
                            if (EstaEnColumna(dt_24L, "Misma_SID_G1", first.SID) && EstaEnColumna(dt_24L, "Misma_SID_G1", second.SID) && dist < 5)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (EstaEnColumna(dt_24L, "Misma_SID_G2", first.SID) && EstaEnColumna(dt_24L, "Misma_SID_G2", second.SID) && dist < 5)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (EstaEnColumna(dt_24L, "Misma_SID_G3", first.SID) && EstaEnColumna(dt_24L, "Misma_SID_G3", second.SID) && dist < 5)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (dist < 3)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                        else if (second.reactorType == "LP")
                        {
                            if (EstaEnColumna(dt_24L, "Misma_SID_G1", first.SID) && EstaEnColumna(dt_24L, "Misma_SID_G1", second.SID) && dist < 5)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (EstaEnColumna(dt_24L, "Misma_SID_G2", first.SID) && EstaEnColumna(dt_24L, "Misma_SID_G2", second.SID) && dist < 5)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (EstaEnColumna(dt_24L, "Misma_SID_G3", first.SID) && EstaEnColumna(dt_24L, "Misma_SID_G3", second.SID) && dist < 5)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (dist < 3)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                        else if (second.reactorType == "NR+")
                        {
                            if (dist < 3)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                        else if (second.reactorType == "NR-")
                        {
                            if (dist < 3)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                        else if (second.reactorType == "NR")
                        {
                            if (dist < 3)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                    }
                    else if (first.reactorType == "LP")//LP /////////////////////////////////////////////////////////////////////////////////////
                    {
                        if (second.reactorType == "HP")
                        {
                            if (EstaEnColumna(dt_24L, "Misma_SID_G1", first.SID) && EstaEnColumna(dt_24L, "Misma_SID_G1", second.SID) && dist < 8)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (EstaEnColumna(dt_24L, "Misma_SID_G2", first.SID) && EstaEnColumna(dt_24L, "Misma_SID_G2", second.SID) && dist < 8)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (EstaEnColumna(dt_24L, "Misma_SID_G3", first.SID) && EstaEnColumna(dt_24L, "Misma_SID_G3", second.SID) && dist < 8)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (dist < 6)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                        else if (second.reactorType == "R")
                        {
                            if (EstaEnColumna(dt_24L, "Misma_SID_G1", first.SID) && EstaEnColumna(dt_24L, "Misma_SID_G1", second.SID) && dist < 6)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (EstaEnColumna(dt_24L, "Misma_SID_G2", first.SID) && EstaEnColumna(dt_24L, "Misma_SID_G2", second.SID) && dist < 6)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (EstaEnColumna(dt_24L, "Misma_SID_G3", first.SID) && EstaEnColumna(dt_24L, "Misma_SID_G3", second.SID) && dist < 6)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (dist < 4)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                        else if (second.reactorType == "LP")
                        {
                            if (EstaEnColumna(dt_24L, "Misma_SID_G1", first.SID) && EstaEnColumna(dt_24L, "Misma_SID_G1", second.SID) && dist < 5)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (EstaEnColumna(dt_24L, "Misma_SID_G2", first.SID) && EstaEnColumna(dt_24L, "Misma_SID_G2", second.SID) && dist < 5)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (EstaEnColumna(dt_24L, "Misma_SID_G3", first.SID) && EstaEnColumna(dt_24L, "Misma_SID_G3", second.SID) && dist < 5)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (first.SID != second.SID && dist < 3)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                        else if (second.reactorType == "NR+")
                        {
                            if (dist < 3)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                        else if (second.reactorType == "NR-")
                        {
                            if (dist < 3)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                        else if (second.reactorType == "NR")
                        {
                            if (dist < 3)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                    }
                    else if (first.reactorType == "NR+")//NR+///////////////////////////////////////////////////////////////////////////////////////////////
                    {
                        if (second.reactorType == "HP")
                        {
                            if (EstaEnColumna(dt_24L, "Misma_SID_G1", first.SID) && EstaEnColumna(dt_24L, "Misma_SID_G1", second.SID) && dist < 11)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (EstaEnColumna(dt_24L, "Misma_SID_G2", first.SID) && EstaEnColumna(dt_24L, "Misma_SID_G2", second.SID) && dist < 11)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (EstaEnColumna(dt_24L, "Misma_SID_G3", first.SID) && EstaEnColumna(dt_24L, "Misma_SID_G3", second.SID) && dist < 11)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (first.SID != second.SID && dist < 8)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                        else if (second.reactorType == "R")
                        {
                            if (EstaEnColumna(dt_24L, "Misma_SID_G1", first.SID) && EstaEnColumna(dt_24L, "Misma_SID_G1", second.SID) && dist < 9)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (EstaEnColumna(dt_24L, "Misma_SID_G2", first.SID) && EstaEnColumna(dt_24L, "Misma_SID_G2", second.SID) && dist < 9)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (EstaEnColumna(dt_24L, "Misma_SID_G3", first.SID) && EstaEnColumna(dt_24L, "Misma_SID_G3", second.SID) && dist < 9)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (first.SID != second.SID && dist < 6)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                        else if (second.reactorType == "LP")
                        {
                            if (EstaEnColumna(dt_24L, "Misma_SID_G1", first.SID) && EstaEnColumna(dt_24L, "Misma_SID_G1", second.SID) && dist < 9)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (EstaEnColumna(dt_24L, "Misma_SID_G2", first.SID) && EstaEnColumna(dt_24L, "Misma_SID_G2", second.SID) && dist < 9)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (EstaEnColumna(dt_24L, "Misma_SID_G3", first.SID) && EstaEnColumna(dt_24L, "Misma_SID_G3", second.SID) && dist < 9)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (first.SID != second.SID && dist < 6)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                        else if (second.reactorType == "NR+")
                        {
                            if (EstaEnColumna(dt_24L, "Misma_SID_G1", first.SID) && EstaEnColumna(dt_24L, "Misma_SID_G1", second.SID) && dist < 5)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (EstaEnColumna(dt_24L, "Misma_SID_G2", first.SID) && EstaEnColumna(dt_24L, "Misma_SID_G2", second.SID) && dist < 5)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (EstaEnColumna(dt_24L, "Misma_SID_G3", first.SID) && EstaEnColumna(dt_24L, "Misma_SID_G3", second.SID) && dist < 5)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (first.SID != second.SID && dist < 3)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                        else if (second.reactorType == "NR-")
                        {
                            if (dist < 3)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                        else if (second.reactorType == "NR")
                        {
                            if (dist < 3)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                    }
                    else if (first.reactorType == "NR-")//NR-////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    {
                        if (second.reactorType == "HP")
                        {
                            if (dist < 9)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                        else if (second.reactorType == "R")
                        {
                            if (dist < 9)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                        else if (second.reactorType == "LP")
                        {
                            if (dist < 9)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                        else if (second.reactorType == "NR+")
                        {
                            if (EstaEnColumna(dt_24L, "Misma_SID_G1", first.SID) && EstaEnColumna(dt_24L, "Misma_SID_G1", second.SID) && dist < 9)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (EstaEnColumna(dt_24L, "Misma_SID_G2", first.SID) && EstaEnColumna(dt_24L, "Misma_SID_G2", second.SID) && dist < 9)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (EstaEnColumna(dt_24L, "Misma_SID_G3", first.SID) && EstaEnColumna(dt_24L, "Misma_SID_G3", second.SID) && dist < 9)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (first.SID != second.SID && dist < 6)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                        else if (second.reactorType == "NR-")
                        {
                            if (EstaEnColumna(dt_24L, "Misma_SID_G1", first.SID) && EstaEnColumna(dt_24L, "Misma_SID_G1", second.SID) && dist < 5)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (EstaEnColumna(dt_24L, "Misma_SID_G2", first.SID) && EstaEnColumna(dt_24L, "Misma_SID_G2", second.SID) && dist < 5)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (EstaEnColumna(dt_24L, "Misma_SID_G3", first.SID) && EstaEnColumna(dt_24L, "Misma_SID_G3", second.SID) && dist < 5)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (first.SID != second.SID && dist < 3)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                        else if (second.reactorType == "NR")
                        {
                            if (dist < 3)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                    }
                    else if (first.reactorType == "NR")//NR////////////////////////////////////////////////////////////////////////////////
                    {
                        if (second.reactorType == "HP")
                        {
                            if (dist < 9)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                        else if (second.reactorType == "R")
                        {
                            if (dist < 9)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                        else if (second.reactorType == "LP")
                        {
                            if (dist < 9)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                        else if (second.reactorType == "NR+")
                        {
                            if (dist < 9)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                        else if (second.reactorType == "NR-")
                        {
                            if (dist < 9)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                        else if (second.reactorType == "NR")
                        {
                            if (EstaEnColumna(dt_24L, "Misma_SID_G1", first.SID) && EstaEnColumna(dt_24L, "Misma_SID_G1", second.SID) && dist < 5)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (EstaEnColumna(dt_24L, "Misma_SID_G2", first.SID) && EstaEnColumna(dt_24L, "Misma_SID_G2", second.SID) && dist < 5)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (EstaEnColumna(dt_24L, "Misma_SID_G3", first.SID) && EstaEnColumna(dt_24L, "Misma_SID_G3", second.SID) && dist < 5)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (first.SID != second.SID && dist < 3)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                    }
                }
                else if (first.PistaDesp == "LEBL-06R")
                {
                    if (first.reactorType == "HP")//HP/////////////////////////////////////////////////////////////////
                    {
                        if (second.reactorType == "HP")
                        {
                            if (EstaEnColumna(dt_06R, "Misma_SID_G1", first.SID) && EstaEnColumna(dt_06R, "Misma_SID_G1", second.SID) && dist < 5)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (EstaEnColumna(dt_06R, "Misma_SID_G2", first.SID) && EstaEnColumna(dt_06R, "Misma_SID_G2", second.SID) && dist < 5)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (EstaEnColumna(dt_06R, "Misma_SID_G3", first.SID) && EstaEnColumna(dt_06R, "Misma_SID_G3", second.SID) && dist < 5)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (dist < 3)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                        else if (second.reactorType == "R")
                        {
                            if (EstaEnColumna(dt_06R, "Misma_SID_G1", first.SID) && EstaEnColumna(dt_06R, "Misma_SID_G1", second.SID) && dist < 5)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (EstaEnColumna(dt_06R, "Misma_SID_G2", first.SID) && EstaEnColumna(dt_06R, "Misma_SID_G2", second.SID) && dist < 5)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (EstaEnColumna(dt_06R, "Misma_SID_G3", first.SID) && EstaEnColumna(dt_06R, "Misma_SID_G3", second.SID) && dist < 5)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (dist < 3)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                        else if (second.reactorType == "LP")
                        {
                            if (EstaEnColumna(dt_06R, "Misma_SID_G1", first.SID) && EstaEnColumna(dt_06R, "Misma_SID_G1", second.SID) && dist < 5)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (EstaEnColumna(dt_06R, "Misma_SID_G2", first.SID) && EstaEnColumna(dt_06R, "Misma_SID_G2", second.SID) && dist < 5)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (EstaEnColumna(dt_06R, "Misma_SID_G3", first.SID) && EstaEnColumna(dt_06R, "Misma_SID_G3", second.SID) && dist < 5)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (dist < 3)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                        else if (second.reactorType == "NR+")
                        {
                            if (dist < 3)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                        else if (second.reactorType == "NR-")
                        {
                            if (dist < 3)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                        else if (second.reactorType == "NR")
                        {
                            if (dist < 3)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                    }
                    else if (first.reactorType == "R")//R////////////////////////////////////////////////////////////////////////////////////////
                    {
                        if (second.reactorType == "HP")
                        {
                            if (EstaEnColumna(dt_06R, "Misma_SID_G1", first.SID) && EstaEnColumna(dt_06R, "Misma_SID_G1", second.SID) && dist < 7)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (EstaEnColumna(dt_06R, "Misma_SID_G2", first.SID) && EstaEnColumna(dt_06R, "Misma_SID_G2", second.SID) && dist < 7)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (EstaEnColumna(dt_06R, "Misma_SID_G3", first.SID) && EstaEnColumna(dt_06R, "Misma_SID_G3", second.SID) && dist < 7)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (dist < 5)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                        else if (second.reactorType == "R")
                        {
                            if (EstaEnColumna(dt_06R, "Misma_SID_G1", first.SID) && EstaEnColumna(dt_06R, "Misma_SID_G1", second.SID) && dist < 5)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (EstaEnColumna(dt_06R, "Misma_SID_G2", first.SID) && EstaEnColumna(dt_06R, "Misma_SID_G2", second.SID) && dist < 5)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (EstaEnColumna(dt_06R, "Misma_SID_G3", first.SID) && EstaEnColumna(dt_06R, "Misma_SID_G3", second.SID) && dist < 5)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (dist < 3)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                        else if (second.reactorType == "LP")
                        {
                            if (EstaEnColumna(dt_06R, "Misma_SID_G1", first.SID) && EstaEnColumna(dt_06R, "Misma_SID_G1", second.SID) && dist < 5)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (EstaEnColumna(dt_06R, "Misma_SID_G2", first.SID) && EstaEnColumna(dt_06R, "Misma_SID_G2", second.SID) && dist < 5)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (EstaEnColumna(dt_06R, "Misma_SID_G3", first.SID) && EstaEnColumna(dt_06R, "Misma_SID_G3", second.SID) && dist < 5)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (dist < 3)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                        else if (second.reactorType == "NR+")
                        {
                            if (dist < 3)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                        else if (second.reactorType == "NR-")
                        {
                            if (dist < 3)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                        else if (second.reactorType == "NR")
                        {
                            if (dist < 3)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                    }
                    else if (first.reactorType == "LP")//LP /////////////////////////////////////////////////////////////////////////////////////
                    {
                        if (second.reactorType == "HP")
                        {
                            if (EstaEnColumna(dt_06R, "Misma_SID_G1", first.SID) && EstaEnColumna(dt_06R, "Misma_SID_G1", second.SID) && dist < 8)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (EstaEnColumna(dt_06R, "Misma_SID_G2", first.SID) && EstaEnColumna(dt_06R, "Misma_SID_G2", second.SID) && dist < 8)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (EstaEnColumna(dt_06R, "Misma_SID_G3", first.SID) && EstaEnColumna(dt_06R, "Misma_SID_G3", second.SID) && dist < 8)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (dist < 6)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                        else if (second.reactorType == "R")
                        {
                            if (EstaEnColumna(dt_06R, "Misma_SID_G1", first.SID) && EstaEnColumna(dt_06R, "Misma_SID_G1", second.SID) && dist < 6)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (EstaEnColumna(dt_06R, "Misma_SID_G2", first.SID) && EstaEnColumna(dt_06R, "Misma_SID_G2", second.SID) && dist < 6)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (EstaEnColumna(dt_06R, "Misma_SID_G3", first.SID) && EstaEnColumna(dt_06R, "Misma_SID_G3", second.SID) && dist < 6)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (dist < 4)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                        else if (second.reactorType == "LP")
                        {
                            if (EstaEnColumna(dt_06R, "Misma_SID_G1", first.SID) && EstaEnColumna(dt_06R, "Misma_SID_G1", second.SID) && dist < 5)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (EstaEnColumna(dt_06R, "Misma_SID_G2", first.SID) && EstaEnColumna(dt_06R, "Misma_SID_G2", second.SID) && dist < 5)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (EstaEnColumna(dt_06R, "Misma_SID_G3", first.SID) && EstaEnColumna(dt_06R, "Misma_SID_G3", second.SID) && dist < 5)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (first.SID != second.SID && dist < 3)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                        else if (second.reactorType == "NR+")
                        {
                            if (dist < 3)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                        else if (second.reactorType == "NR-")
                        {
                            if (dist < 3)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                        else if (second.reactorType == "NR")
                        {
                            if (dist < 3)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                    }
                    else if (first.reactorType == "NR+")//NR+///////////////////////////////////////////////////////////////////////////////////////////////
                    {
                        if (second.reactorType == "HP")
                        {
                            if (EstaEnColumna(dt_06R, "Misma_SID_G1", first.SID) && EstaEnColumna(dt_06R, "Misma_SID_G1", second.SID) && dist < 11)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (EstaEnColumna(dt_06R, "Misma_SID_G2", first.SID) && EstaEnColumna(dt_06R, "Misma_SID_G2", second.SID) && dist < 11)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (EstaEnColumna(dt_06R, "Misma_SID_G3", first.SID) && EstaEnColumna(dt_06R, "Misma_SID_G3", second.SID) && dist < 11)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (first.SID != second.SID && dist < 8)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                        else if (second.reactorType == "R")
                        {
                            if (EstaEnColumna(dt_06R, "Misma_SID_G1", first.SID) && EstaEnColumna(dt_06R, "Misma_SID_G1", second.SID) && dist < 9)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (EstaEnColumna(dt_06R, "Misma_SID_G2", first.SID) && EstaEnColumna(dt_06R, "Misma_SID_G2", second.SID) && dist < 9)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (EstaEnColumna(dt_06R, "Misma_SID_G3", first.SID) && EstaEnColumna(dt_06R, "Misma_SID_G3", second.SID) && dist < 9)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (first.SID != second.SID && dist < 6)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                        else if (second.reactorType == "LP")
                        {
                            if (EstaEnColumna(dt_06R, "Misma_SID_G1", first.SID) && EstaEnColumna(dt_06R, "Misma_SID_G1", second.SID) && dist < 9)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (EstaEnColumna(dt_06R, "Misma_SID_G2", first.SID) && EstaEnColumna(dt_06R, "Misma_SID_G2", second.SID) && dist < 9)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (EstaEnColumna(dt_06R, "Misma_SID_G3", first.SID) && EstaEnColumna(dt_06R, "Misma_SID_G3", second.SID) && dist < 9)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (first.SID != second.SID && dist < 6)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                        else if (second.reactorType == "NR+")
                        {
                            if (EstaEnColumna(dt_06R, "Misma_SID_G1", first.SID) && EstaEnColumna(dt_06R, "Misma_SID_G1", second.SID) && dist < 5)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (EstaEnColumna(dt_06R, "Misma_SID_G2", first.SID) && EstaEnColumna(dt_06R, "Misma_SID_G2", second.SID) && dist < 5)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (EstaEnColumna(dt_06R, "Misma_SID_G3", first.SID) && EstaEnColumna(dt_06R, "Misma_SID_G3", second.SID) && dist < 5)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (first.SID != second.SID && dist < 3)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                        else if (second.reactorType == "NR-")
                        {
                            if (dist < 3)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                        else if (second.reactorType == "NR")
                        {
                            if (dist < 3)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                    }
                    else if (first.reactorType == "NR-")//NR-////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    {
                        if (second.reactorType == "HP")
                        {
                            if (dist < 9)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                        else if (second.reactorType == "R")
                        {
                            if (dist < 9)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                        else if (second.reactorType == "LP")
                        {
                            if (dist < 9)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                        else if (second.reactorType == "NR+")
                        {
                            if (EstaEnColumna(dt_06R, "Misma_SID_G1", first.SID) && EstaEnColumna(dt_06R, "Misma_SID_G1", second.SID) && dist < 9)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (EstaEnColumna(dt_06R, "Misma_SID_G2", first.SID) && EstaEnColumna(dt_06R, "Misma_SID_G2", second.SID) && dist < 9)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (EstaEnColumna(dt_06R, "Misma_SID_G3", first.SID) && EstaEnColumna(dt_06R, "Misma_SID_G3", second.SID) && dist < 9)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (first.SID != second.SID && dist < 6)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                        else if (second.reactorType == "NR-")
                        {
                            if (EstaEnColumna(dt_06R, "Misma_SID_G1", first.SID) && EstaEnColumna(dt_06R, "Misma_SID_G1", second.SID) && dist < 5)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (EstaEnColumna(dt_06R, "Misma_SID_G2", first.SID) && EstaEnColumna(dt_06R, "Misma_SID_G2", second.SID) && dist < 5)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (EstaEnColumna(dt_06R, "Misma_SID_G3", first.SID) && EstaEnColumna(dt_06R, "Misma_SID_G3", second.SID) && dist < 5)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (first.SID != second.SID && dist < 3)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                        else if (second.reactorType == "NR")
                        {
                            if (dist < 3)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                    }
                    else if (first.reactorType == "NR")//NR////////////////////////////////////////////////////////////////////////////////
                    {
                        if (second.reactorType == "HP")
                        {
                            if (dist < 9)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                        else if (second.reactorType == "R")
                        {
                            if (dist < 9)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                        else if (second.reactorType == "LP")
                        {
                            if (dist < 9)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                        else if (second.reactorType == "NR+")
                        {
                            if (dist < 9)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                        else if (second.reactorType == "NR-")
                        {
                            if (dist < 9)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                        else if (second.reactorType == "NR")
                        {
                            if (EstaEnColumna(dt_06R, "Misma_SID_G1", first.SID) && EstaEnColumna(dt_06R, "Misma_SID_G1", second.SID) && dist < 5)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (EstaEnColumna(dt_06R, "Misma_SID_G2", first.SID) && EstaEnColumna(dt_06R, "Misma_SID_G2", second.SID) && dist < 5)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (EstaEnColumna(dt_06R, "Misma_SID_G3", first.SID) && EstaEnColumna(dt_06R, "Misma_SID_G3", second.SID) && dist < 5)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                            else if (first.SID != second.SID && dist < 3)
                            {
                                colisiones++;
                                cumplimiento = false;
                            }
                        }
                    }
                }



            }


            return (cumplimiento, colisiones);
        }


        static bool EstaEnColumna(DataTable dataTable, string nombreColumna, string cadenaBuscada)
        {
            if (cadenaBuscada[cadenaBuscada.Length - 1] == 'Q')
            {
                char[] caracteres = cadenaBuscada.ToCharArray();
                caracteres[cadenaBuscada.Length - 2] = '-';
                cadenaBuscada = new string(caracteres);
            }
            else if (cadenaBuscada[cadenaBuscada.Length - 1] == 'R')
            {
                char[] caracteres = cadenaBuscada.ToCharArray();
                caracteres[cadenaBuscada.Length - 2] = '-';
                cadenaBuscada = new string(caracteres);
            }

            // Utilizar LINQ para verificar si la cadena está en la columna
            return dataTable.AsEnumerable()
                            .Any(row => row.Field<string>(nombreColumna) == cadenaBuscada);
        }

        static void CrearArchivoExcel(string rutaArchivo, List<String[]>AircraftsID24L, List<Aircraft> Aviones24L, List<List<Double>>Distancias24L,List<bool> listaCumplimientosLoA24L, List<int> listaColisionesLoA24L, List<bool> listaCumplimientosRadar24L, List<int> listaColisionesRadar24L, List<bool> listaCumplimientosEstela24L, List<int> listaColisionesEstela24L,List<String[]> AircraftsID06R,List<Aircraft> Aviones06R, List<List<Double>> Distancias06R, List<bool> listaCumplimientosLoA06R, List<int> listaColisionesLoA06R, List<bool> listaCumplimientosRadar06R, List<int> listaColisionesRadar06R, List<bool> listaCumplimientosEstela06R, List<int> listaColisionesEstela06R)
        {
            OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            // Crear un nuevo archivo Excel
            using (var paquete = new ExcelPackage())
            {
                // Agregar una hoja al archivo
                var hoja = paquete.Workbook.Worksheets.Add("Hoja1");

                // Agregar los encabezados proporcionados
                hoja.Cells["A1"].Value = "RUNWAY 24 L";
                hoja.Cells["A2"].Value = "Aircraft 1";
                hoja.Cells["G2"].Value = "Aircraft 2";
                hoja.Cells["M2"].Value = "Tipos de incumplimiento";
                hoja.Cells["Q2"].Value = "Nº INCUMPLIMIENTOS";

                // Configurar los encabezados de las columnas
                string[] encabezadosColumnas = {
                 "Modelo", "Callsign", "Tipo Estela", "SID", "Dep Time UTC", "Track Number",
                 "Modelo", "Callsign", "Tipo Estela", "SID", "Dep Time UTC", "Track Number",
                 "ESTELA", "RADAR", "LoA", "ESTELA", "RADAR", "LoA" 
                };
                                                                       

                for (int i = 0; i < encabezadosColumnas.Length; i++)
                {
                    hoja.Cells[3, i + 1].Value = encabezadosColumnas[i];
                }


                //Insertar datos 
                int row = 0;
                for (int i = 0; i < AircraftsID24L.Count(); i = i + 1)
                {
                    string ID1= AircraftsID24L[i][0].ToString();
                    string ID2 = AircraftsID24L[i][1].ToString();
                    Aircraft Avion1 = FindAircraftById(Aviones24L, ID1);
                    Aircraft Avion2= FindAircraftById(Aviones24L, ID2);
                    hoja.Cells[row + 4, 1].Value = Avion1.AircraftModel;
                    hoja.Cells[row + 4, 2].Value = Avion1.AircraftID;
                    hoja.Cells[row + 4, 3].Value = Avion1.Estela;
                    hoja.Cells[row + 4, 4].Value = Avion1.SID;
                    hoja.Cells[row + 4, 5].Value = Avion1.horaDesp;
                    hoja.Cells[row + 4, 6].Value = Avion1.TrackNumber;

                    hoja.Cells[row + 4, 7].Value = Avion2.AircraftModel;
                    hoja.Cells[row + 4, 8].Value = Avion2.AircraftID;
                    hoja.Cells[row + 4, 9].Value = Avion2.Estela;
                    hoja.Cells[row + 4, 10].Value = Avion2.SID;
                    hoja.Cells[row + 4, 11].Value = Avion2.horaDesp;
                    hoja.Cells[row + 4, 12].Value = Avion2.TrackNumber;


                    hoja.Cells[row + 4, 13].Value = listaCumplimientosEstela24L[row];
                    hoja.Cells[row + 4, 14].Value = listaCumplimientosRadar24L[row];
                    hoja.Cells[row + 4, 15].Value = listaCumplimientosLoA24L[row];

                    hoja.Cells[row + 4, 16].Value = listaColisionesEstela24L[row];
                    hoja.Cells[row + 4, 17].Value = listaColisionesRadar24L[row];
                    hoja.Cells[row + 4, 18].Value = listaColisionesLoA24L[row];
                    if (Distancias24L[row].Any())
                    {
                        hoja.Cells[row + 4, 19].Value = Distancias24L[row].Max();
                        hoja.Cells[row + 4, 20].Value = Distancias24L[row].Min();
                        hoja.Cells[row + 4, 21].Value = Distancias24L[row].Average();
                        hoja.Cells[row + 4, 22].Value = CalcularVarianzaYDesviacionEstandar(Distancias24L[row]).Varianza;
                        hoja.Cells[row + 4, 23].Value = CalcularVarianzaYDesviacionEstandar(Distancias24L[row]).DesviacionEstandar;
                    }
                    else
                    {
                        // Manejar el caso en el que la secuencia está vacía
                        hoja.Cells[row + 4, 19].Value = null; // o algún valor predeterminado
                        hoja.Cells[row + 4, 20].Value = null;
                        hoja.Cells[row + 4, 21].Value = null;
                    }


                    row++;
                }


                // Agregar los encabezados proporcionados
                hoja.Cells[row+6,1].Value = "RUNWAY 06R";
                hoja.Cells[row+7,1].Value = "Aircraft 1";
                hoja.Cells[row+7,7].Value = "Aircraft 2";
                hoja.Cells[row+7,13].Value = "Tipos de incumplimiento";
                hoja.Cells[row+7,17].Value = "Nº INCUMPLIMIENTOS";

                for (int i = 0; i < encabezadosColumnas.Length; i++)
                {
                    hoja.Cells[row+8, i + 1].Value = encabezadosColumnas[i];
                }
                // Insertar datos 06R
                int fila = 0;

                for (int i = 0; i < AircraftsID06R.Count(); i = i + 1)
                {
                    string ID1 = AircraftsID06R[i][0].ToString();
                    string ID2 = AircraftsID06R[i][1].ToString();
                    Aircraft Avion1 = FindAircraftById(Aviones06R, ID1);
                    Aircraft Avion2 = FindAircraftById(Aviones06R, ID2);
                    hoja.Cells[row + 10 + fila, 1].Value = Avion1.AircraftModel;
                    hoja.Cells[row + 10 + fila, 2].Value = Avion1.AircraftID;
                    hoja.Cells[row + 10 + fila, 3].Value = Avion1.Estela;
                    hoja.Cells[row + 10 + fila, 4].Value = Avion1.SID;
                    hoja.Cells[row + 10 + fila, 5].Value = Avion1.horaDesp;
                    hoja.Cells[row + 10 + fila, 6].Value = Avion1.TrackNumber;

                    hoja.Cells[row + 10 + fila, 7].Value = Avion2.AircraftModel;
                    hoja.Cells[row + 10 + fila, 8].Value = Avion2.AircraftID;
                    hoja.Cells[row + 10 + fila, 9].Value = Avion2.Estela;
                    hoja.Cells[row + 10 + fila, 10].Value = Avion2.SID;
                    hoja.Cells[row + 10 + fila, 11].Value = Avion2.horaDesp;
                    hoja.Cells[row + 10 + fila, 12].Value = Avion2.TrackNumber;


                    hoja.Cells[row + 10 + fila, 13].Value = listaCumplimientosEstela06R[i];
                    hoja.Cells[row + 10 + fila, 14].Value = listaCumplimientosRadar06R[i];
                    hoja.Cells[row + 10 + fila, 15].Value = listaCumplimientosLoA06R[i];

                    hoja.Cells[row + 10 + fila, 16].Value = listaColisionesEstela06R[i];
                    hoja.Cells[row + 10 + fila, 17].Value = listaColisionesRadar06R[i];
                    hoja.Cells[row + 10 + fila, 18].Value = listaColisionesLoA06R[i];

                    hoja.Cells[row + 10 + fila, 19].Value = Distancias06R[i].Max();
                    hoja.Cells[row + 10 + fila, 20].Value = Distancias06R[i].Min();
                    hoja.Cells[row + 10 + fila, 21].Value = Distancias06R[i].Average();
                    hoja.Cells[row + 10 + fila, 22].Value = CalcularVarianzaYDesviacionEstandar(Distancias06R[i]).Varianza;
                    hoja.Cells[row + 10 + fila, 23].Value = CalcularVarianzaYDesviacionEstandar(Distancias06R[i]).DesviacionEstandar;
                    fila++;
                }


                // Guardar el archivo Excel en disco
                FileInfo fileInfo = new FileInfo(rutaArchivo);
                paquete.SaveAs(fileInfo);
            }
        }
        static Aircraft FindAircraftById(List<Aircraft> aircraftList, string aircraftId)
        {
            return aircraftList.FirstOrDefault(aircraft => aircraft.AircraftID == aircraftId);
        }

        static (double Varianza, double DesviacionEstandar) CalcularVarianzaYDesviacionEstandar(List<double> datos)
        {
            if (datos.Count < 2)
            {
                throw new ArgumentException("La lista debe contener al menos dos elementos para calcular la varianza y la desviación estándar.");
            }

            // Calcula la media
            double media = datos.Average();

            // Calcula la suma de los cuadrados de las diferencias entre cada dato y la media
            double sumaCuadradosDiferencias = datos.Sum(dato => Math.Pow(dato - media, 2));

            // Calcula la varianza
            double varianza = sumaCuadradosDiferencias / (datos.Count - 1);

            // Calcula la desviación estándar como la raíz cuadrada de la varianza
            double desviacionEstandar = Math.Sqrt(varianza);

            return (varianza, desviacionEstandar);
        }
    }

}
