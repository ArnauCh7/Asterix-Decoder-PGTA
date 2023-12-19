using MultiCAT6.Utils;
using proyecto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace Project2
{
    public class Aircraft
    {
        public string AircraftID { get; set; }
        
        public string  TrackNumber { get; set; }
        public string AircraftModel {  get; set; }

        public string Estela {  get; set; }

        public string PistaDesp {  get; set; }

        public string SID { get; set; }

        public DateTime horaDesp { get; set; }

        public string reactorType { get; set; }

        public List<string> LatitudeList { get; set; } = new List<string>();
        public List<string> LongitudeList { get; set; } = new List<string>();

        public List<string> UList { get; set; } = new List<string>();
        public List<string> VList { get; set; } = new List<string>();


        public List<string> Time { get; set; } = new List<string>();

        public List<string> FL_ft { get; set; } = new List<string>();
        public List<string> GS { get; set; } = new List<string>();
        public List<string> TAS { get; set; } = new List<string>();

        public List<string> IAS { get; set; } = new List<string>();

        public List<string> statList { get; set; } = new List<string>();

        public List<CoordinatesWGS84> Coordinates { get; set; }=new List<CoordinatesWGS84>();




        /// <summary>
        /// Filters the Flight list by Aiorcraft ID creating a class for each one of them where its atributes are 
        /// lists with all the information provided by the messages of that Aircraft. If the ID is not given,, thus 
        /// it is "N/A", the class will be created based on Track number of said message.
        /// </summary>
        /// <param name="flights"></param>
        /// <returns></returns>
        static public List<Aircraft> OrganizeFlights(List<Flight> flights)
        {
            List<Aircraft> aircraftList = new List<Aircraft>();

            foreach (var flight in flights)
            {
                if (flight.Aircraft_ID == "N/A")
                {
                    // Manejar el caso especial para Aircraft_ID "N/A"
                    var existingAircraftWithTrackNumber = aircraftList.Find(a => a.AircraftID == flight.Track_Number && a.TrackNumber==flight.Track_Number);

                    if (existingAircraftWithTrackNumber != null)
                    {
                        // Agregar valores a la clase existente
                        existingAircraftWithTrackNumber.GS.Add(flight.Ground_Speed);
                        existingAircraftWithTrackNumber.LatitudeList.Add(flight.Latitud);
                        existingAircraftWithTrackNumber.LongitudeList.Add(flight.Longitud);
                        existingAircraftWithTrackNumber.UList.Add(flight.U);
                        existingAircraftWithTrackNumber.VList.Add(flight.V);
                        string stat = flight.ACAS_Capability_STAT;
                        existingAircraftWithTrackNumber.statList.Add(stat);
                        if (flight.Flight_Level_Value == "N/A")
                            existingAircraftWithTrackNumber.FL_ft.Add(existingAircraftWithTrackNumber.FL_ft.Last()); //Si no tenemos el punto extrapolamos al anterior
                        else if (Convert.ToDouble(flight.Flight_Level_Value) <= 60)
                        {
                            existingAircraftWithTrackNumber.FL_ft.Add(flight.Corrected_FL);

                        }
                        else existingAircraftWithTrackNumber.FL_ft.Add(Convert.ToString(Convert.ToDouble(flight.Flight_Level_Value) * 100));
                        existingAircraftWithTrackNumber.Time.Add(flight.Time_of_Day);
                        existingAircraftWithTrackNumber.TAS.Add(flight.True_Airspeed);
                        existingAircraftWithTrackNumber.IAS.Add(flight.Indicated_AS);
                    }
                    else
                    {
                        string Height;
                        if (flight.Flight_Level_Value == "N/A")
                            Height = Convert.ToString(18.23); //HE puesto 17.5 de pruebas luego hanria que cambiarlo
                        else if (Convert.ToDouble(flight.Flight_Level_Value) <= 60)
                        {
                            Height = flight.Corrected_FL;

                        }
                        else Height = Convert.ToString(Convert.ToDouble(flight.Flight_Level_Value) * 100);
                        var newAircraft = new Aircraft
                        {
                            AircraftID = flight.Track_Number,
                            TrackNumber= flight.Track_Number,
                            GS = { flight.Ground_Speed },
                            LatitudeList = { flight.Latitud },
                            LongitudeList = { flight.Longitud },
                            UList = {flight.U},
                            VList = {flight.V},
                            statList = { flight.ACAS_Capability_STAT},
                            TAS = { flight.True_Airspeed },
                            IAS = { flight.Indicated_AS },
                            Time = { flight.Time_of_Day },

                            FL_ft = { Height }
                        };

                        aircraftList.Add(newAircraft);
                    }
                }
                else
                {
                    // Manejar el caso normal para Aircraft_ID diferente de "N/A"
                    var existingAircraft = aircraftList.Find(a => a.AircraftID == flight.Aircraft_ID && a.TrackNumber==flight.Track_Number);
                    
                    if (existingAircraft != null)
                    {
                        // Agregar valores a la clase existente
                        existingAircraft.GS.Add(flight.Ground_Speed);
                        existingAircraft.LatitudeList.Add(flight.Latitud);
                        existingAircraft.LongitudeList.Add(flight.Longitud);
                        existingAircraft.UList.Add(flight.U);
                        existingAircraft.VList.Add(flight.V);
                        string stat = flight.ACAS_Capability_STAT;
                        existingAircraft.statList.Add(stat);
                        if (flight.Flight_Level_Value == "N/A")
                            existingAircraft.FL_ft.Add(existingAircraft.FL_ft.Last()); //Si no tenemos el punto extrapolamos al anterior
                        else if (Convert.ToDouble(flight.Flight_Level_Value) <= 60)
                        {
                            existingAircraft.FL_ft.Add(flight.Corrected_FL);

                        }
                        else existingAircraft.FL_ft.Add(Convert.ToString(Convert.ToDouble(flight.Flight_Level_Value) * 100));
                        existingAircraft.Time.Add(flight.Time_of_Day);
                        existingAircraft.TAS.Add(flight.True_Airspeed);
                        existingAircraft.IAS.Add(flight.Indicated_AS);
                    }
                    else
                    {
                        string Height;
                        if (flight.Flight_Level_Value == "N/A")
                            Height = Convert.ToString(18.23); //HE puesto 17.5 de pruebas luego hanria que cambiarlo
                        else if (Convert.ToDouble(flight.Flight_Level_Value) <= 60)
                        {
                            Height = flight.Corrected_FL;

                        }
                        else Height = Convert.ToString(Convert.ToDouble(flight.Flight_Level_Value) * 100);
                        var newAircraft = new Aircraft
                        {
                            AircraftID = flight.Aircraft_ID,
                            TrackNumber = flight.Track_Number,
                            GS = { flight.Ground_Speed },
                            LatitudeList = { flight.Latitud },
                            LongitudeList = { flight.Longitud },
                            UList = {flight.U},
                            VList = {flight.V},
                            statList = { flight.ACAS_Capability_STAT },
                            TAS = { flight.True_Airspeed },
                            IAS = { flight.Indicated_AS },
                            Time = { flight.Time_of_Day },

                            FL_ft = { Height }
                        };

                        aircraftList.Add(newAircraft);
                    }
                }
            }

            return aircraftList;
        }

    }

    
    public class KMLExporter
    {
        /// <summary>
        /// Creates KML file
        /// </summary>
        /// <param name="aircraftList"></param>
        /// <param name="filePath"></param>
        public static void ExportToKML(List<Aircraft> aircraftList, string filePath)
        {
            StringBuilder kmlContent = new StringBuilder();

            // KML header
            kmlContent.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            kmlContent.AppendLine("<kml xmlns=\"http://www.opengis.net/kml/2.2\">");
            kmlContent.AppendLine("  <Document>");
            kmlContent.AppendLine("    <Folder>");
            kmlContent.AppendLine($"      <name>{"PRUEBA"}</name>");


            // Iterate through each aircraft and create KML Placemark for its 3D route
            foreach (var aircraft in aircraftList)
            {

                if (aircraft.LatitudeList.Count() > 1)
                {
                    kmlContent.AppendLine("      <Placemark>");
                    kmlContent.AppendLine($"      <name>{aircraft.AircraftID.Replace(',', '.')}</name>");
                    kmlContent.AppendLine("        <description> Route description for this aircraft </description>");

                    kmlContent.AppendLine("        <LineString>");
                    kmlContent.AppendLine("         <tessellate>1</tessellate>");

                    // Specify the altitude mode (clampToGround or absolute)
                    kmlContent.AppendLine("<altitudeMode>absolute</altitudeMode>");


                    // Add coordinates with altitude for each point in the route
                    string altitude_meter;
                    for (int i = 0; i < aircraft.LatitudeList.Count; i++)
                    {
                        if (aircraft.FL_ft[i] != "")
                        {
                            altitude_meter = Convert.ToString(Convert.ToDouble(aircraft.FL_ft[i]) * 0.3048).Replace(',', '.');
                        }
                        else
                        {
                            if (i != 0)
                            {
                                int index = 1;
                                while (true)
                                {
                                    if (aircraft.FL_ft[i - index] == "")
                                    {
                                        index++;
                                    }
                                    else
                                    {
                                        altitude_meter = Convert.ToString(Convert.ToDouble(aircraft.FL_ft[i - index]) * 0.3048).Replace(',', '.');
                                        break;
                                    }

                                }
                            }
                            else
                            {
                                altitude_meter = Convert.ToString(Convert.ToDouble(aircraft.FL_ft[i + 1]) * 0.3048).Replace(',', '.');
                            }
                           
                            
                            
                        }

                        if (i == aircraft.LatitudeList.Count - 1)
                        {
                            kmlContent.AppendLine($"{aircraft.LongitudeList[i].Replace(',', '.')},{aircraft.LatitudeList[i].Replace(',', '.')},{altitude_meter}</coordinates>");
                        }
                        else if (i == 0)
                        {
                            kmlContent.AppendLine($"          <coordinates>{aircraft.LongitudeList[i].Replace(',', '.')},{aircraft.LatitudeList[i].Replace(',', '.')},{altitude_meter}");
                        }
                        else
                        {
                            kmlContent.AppendLine($"{aircraft.LongitudeList[i].Replace(',', '.')},{aircraft.LatitudeList[i].Replace(',', '.')},{altitude_meter}");
                        }


                    }


                    kmlContent.AppendLine("        </LineString>");
                    kmlContent.AppendLine("      </Placemark>");
                }

            }

            // KML footer
            kmlContent.AppendLine("    </Folder>");
            kmlContent.AppendLine("  </Document>");

            kmlContent.AppendLine("</kml>");

            // Write the KML content to the specified file
            File.WriteAllText(filePath, kmlContent.ToString());

        }
    }





}
