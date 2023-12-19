using proyecto;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MultiCAT6.Utils;
using System.Diagnostics;

namespace Project2
{


    public class FlightList
    {
        List<Flight> flights=new List<Flight>();
        List<Flight> flightsfiltered =new List<Flight>();

        public static DataTable GetDataTable(List<Flight> Vuelos)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("SAC", typeof(string));
            dt.Columns.Add("SIC", typeof(string));
            dt.Columns.Add("Time", typeof(string));
            dt.Columns.Add("LATITUDE", typeof(string));
            dt.Columns.Add("LONGITUDE", typeof(string));
            dt.Columns.Add("HEIGHT", typeof(string));
            dt.Columns.Add("TYP020", typeof(string));
            dt.Columns.Add("SIM020", typeof(string));
            dt.Columns.Add("RDP020", typeof(string));
            dt.Columns.Add("SPI020", typeof(string));
            dt.Columns.Add("RAB020", typeof(string));
            
            dt.Columns.Add("TST020", typeof(string));
            dt.Columns.Add("ERR020", typeof(string));
            dt.Columns.Add("ME020", typeof(string));
            dt.Columns.Add("XPP020", typeof(string));
            dt.Columns.Add("MI020", typeof(string));
            dt.Columns.Add("FOE/FRI020", typeof(string));
            
            dt.Columns.Add("ADSB#EP020", typeof(string));
            dt.Columns.Add("ADSB#VAL020", typeof(string));
            dt.Columns.Add("SCNEP", typeof(string));
            dt.Columns.Add("SCNVAL", typeof(string));
            dt.Columns.Add("PAIEP", typeof(string));
            dt.Columns.Add("PAIVAL", typeof(string));

            dt.Columns.Add("Measured_Position_in_Polar_Coordinates_RHO", typeof(string));
            dt.Columns.Add("Measured_Position_in_Polar_Coordinates_THETA", typeof(string));
            dt.Columns.Add("Flight_Level_Validation", typeof(string));
            dt.Columns.Add("Flight_Level_Garbed", typeof(string));
            dt.Columns.Add("Flight_Level_Value", typeof(string));
            dt.Columns.Add("FL_Correction", typeof(string));
            dt.Columns.Add("Mode_3A_V", typeof(string));
            dt.Columns.Add("Mode_3A_G", typeof(string));
            dt.Columns.Add("Mode_3A_L", typeof(string));
            dt.Columns.Add("Mode_3A_Reply", typeof(string));
            dt.Columns.Add("Aircraft_Address", typeof(string));
            dt.Columns.Add("Aircraft_ID", typeof(string));
            dt.Columns.Add("Track_Number", typeof(string));
            dt.Columns.Add("X_Component", typeof(string));
            dt.Columns.Add("Y_Component", typeof(string));
            dt.Columns.Add("GroundSpeed[kt]", typeof(string));
            dt.Columns.Add("Heading", typeof(string));
            dt.Columns.Add("Height_Measured_by_3D_Radar", typeof(string));
            dt.Columns.Add("Special_Purpose_Field", typeof(int));
            dt.Columns.Add("SRL", typeof(string));
            dt.Columns.Add("SSR", typeof(string));
            dt.Columns.Add("SAM", typeof(string));
            dt.Columns.Add("PRL", typeof(string));
            dt.Columns.Add("PAM", typeof(string));
            dt.Columns.Add("RPD", typeof(string));
            dt.Columns.Add("APD", typeof(string));
            dt.Columns.Add("MODE S", typeof(string));
            dt.Columns.Add("MCP_ALT", typeof(string));
            dt.Columns.Add("FMS_ALT", typeof(string));
            dt.Columns.Add("BP", typeof(string));
            dt.Columns.Add("VNAV", typeof(string));
            dt.Columns.Add("Status_MCP_FCU_Bits", typeof(string));
            dt.Columns.Add("ALTHOLD", typeof(string));
            dt.Columns.Add("APP", typeof(string));
            dt.Columns.Add("TARGETALT_STATUS", typeof(string));
            dt.Columns.Add("TARGETALT_SOURCE", typeof(string));
            dt.Columns.Add("RASTATUS", typeof(string));
            dt.Columns.Add("LEFT WING", typeof(string));
            dt.Columns.Add("RA", typeof(string));
            dt.Columns.Add("TTA", typeof(string));
            dt.Columns.Add("GS", typeof(string));
            dt.Columns.Add("TAR", typeof(string));
            dt.Columns.Add("TAS", typeof(string));
            dt.Columns.Add("HDG", typeof(string));
            dt.Columns.Add("IAS", typeof(string));
            dt.Columns.Add("MACH", typeof(string));
            dt.Columns.Add("BAR", typeof(string));
            dt.Columns.Add("IVV", typeof(string));
            dt.Columns.Add("CNF170", typeof(string));
            dt.Columns.Add("RAD170", typeof(string));
            dt.Columns.Add("DOU170", typeof(string));
            dt.Columns.Add("MAH170", typeof(string));
            dt.Columns.Add("CDM170", typeof(string));
            
            dt.Columns.Add("TRE170", typeof(string));
            dt.Columns.Add("GHO170", typeof(string));
            dt.Columns.Add("SUP170", typeof(string));
            dt.Columns.Add("TCC170", typeof(string));
            
            dt.Columns.Add("COM230", typeof(string));
            dt.Columns.Add("STAT230", typeof(string));
            dt.Columns.Add("SI230", typeof(string));
            dt.Columns.Add("MSSC230", typeof(string));
            dt.Columns.Add("ARC230", typeof(string));
            dt.Columns.Add("AIC230", typeof(string));
            dt.Columns.Add("B1A230", typeof(string));
            dt.Columns.Add("B1B_37/230", typeof(string));
            dt.Columns.Add("B1B_38/230", typeof(string));
            dt.Columns.Add("B1B_3940/230", typeof(string));



            if (Vuelos.Count > 0)
            {
                foreach (Flight vuelo in Vuelos)
                {
                    DataRow Fila = dt.NewRow();
                    Fila["SAC"] = vuelo.Data_Source_Identifier_SAC;
                    Fila["SIC"] = vuelo.Data_Source_Identifier_SIC;
                    Fila["Time"] = vuelo.Time_of_Day;
                    Fila["LONGITUDE"] = vuelo.Longitud;
                    Fila["LATITUDE"] = vuelo.Latitud;
                    Fila["HEIGHT"] = vuelo.Height;
                    Fila["TYP020"] = vuelo.Target_Report_Descriptor_TYP;
                    Fila["SIM020"] = vuelo.Target_Report_Descriptor_SIM;
                    Fila["RDP020"] = vuelo.Target_Report_Descriptor_RDP;
                    Fila["SPI020"] = vuelo.Target_Report_Descriptor_SPI;
                    Fila["RAB020"] = vuelo.Target_Report_Descriptor_RAB;

                    Fila["TST020"] = vuelo.Target_Report_Descriptor_TST;
                    Fila["ERR020"] = vuelo.Target_Report_Descriptor_ERR;
                    Fila["ME020"] = vuelo.Target_Report_Descriptor_ME;
                    Fila["XPP020"] = vuelo.Target_Report_Descriptor_XPP;
                    Fila["MI020"] = vuelo.Target_Report_Descriptor_MI;
                    Fila["FOE/FRI020"] = vuelo.Target_Report_Descriptor_FOEFRI;

                    Fila["ADSB#EP020"] = vuelo.Target_Report_Descriptor_ADSBEP;
                    Fila["ADSB#VAL020"] = vuelo.Target_Report_Descriptor_ADSBVAL;
                    Fila["SCNEP"] = vuelo.Target_Report_Descriptor_SCNEP;
                    Fila["SCNVAL"] = vuelo.Target_Report_Descriptor_SCNVAL;
                    Fila["PAIEP"] = vuelo.Target_Report_Descriptor_PAIEP;
                    Fila["PAIVAL"] = vuelo.Target_Report_Descriptor_PAIVAL;

                    Fila["Measured_Position_in_Polar_Coordinates_RHO"] = vuelo.Measured_Position_in_Polar_Coordinates_RHO;
                    Fila["Measured_Position_in_Polar_Coordinates_THETA"] = vuelo.Measured_Position_in_Polar_Coordinates_THETA;
                    Fila["Flight_Level_Validation"] = vuelo.Flight_Level_Validation;
                    Fila["Flight_Level_Garbed"] = vuelo.Flight_Level_Garbed;
                    Fila["Flight_Level_Value"] = vuelo.Flight_Level_Value;
                    Fila["FL_Correction"] = vuelo.Corrected_FL;
                    Fila["Mode_3A_V"] = vuelo.Mode_3A_V;
                    Fila["Mode_3A_G"] = vuelo.Mode_3A_G;
                    Fila["Mode_3A_L"] = vuelo.Mode_3A_L;
                    Fila["Mode_3A_Reply"] = vuelo.Mode_3A_Reply;
                    Fila["Aircraft_Address"] = vuelo.Aircraft_Address;
                    Fila["Aircraft_ID"] = vuelo.Aircraft_ID;
                    Fila["Track_Number"] = vuelo.Track_Number;
                    Fila["X_Component"] = vuelo.Calculated_Position_Cartesian_X;
                    Fila["Y_Component"] = vuelo.Calculated_Position_Cartesian_Y;
                    Fila["GroundSpeed[kt]"] = vuelo.Calculated_Track_Velocity_Polar_GroundSpeed;
                    Fila["Heading"] = vuelo.Calculated_Track_Velocity_Polar_Heading;
                    Fila["Height_Measured_by_3D_Radar"] = vuelo.Height_Measured_by_3D_Radar;
                    Fila["Special_Purpose_Field"] = vuelo.Special_Purpose_Field;
                    Fila["SRL"] = vuelo.SRL;
                    Fila["SSR"] = vuelo.SSR;
                    Fila["SAM"] = vuelo.SAM;
                    Fila["PRL"] = vuelo.PRL;
                    Fila["PAM"] = vuelo.PAM;
                    Fila["RPD"] = vuelo.RPD;
                    Fila["APD"] = vuelo.APD;
                    Fila["MODE S"] = vuelo.BDS_Number;
                    Fila["MCP_ALT"] = vuelo.Selected_Alt;
                    Fila["FMS_ALT"] = vuelo.Selected_Alt_FMS;
                    Fila["BP"] = vuelo.Barometric_Pressure;
                    Fila["VNAV"] = vuelo.VNAV_Mode;
                    Fila["Status_MCP_FCU_Bits"] = vuelo.Status_MCP_FCU_Bits;
                    Fila["ALTHOLD"] = vuelo.ALT_HOLD_MODE;
                    Fila["APP"] = vuelo.APPROACH_MODE;
                    Fila["TARGETALT_STATUS"] = vuelo.Status_Target_Alt_Bits;
                    Fila["TARGETALT_SOURCE"] = vuelo.Target_Alt_Source;
                    Fila["RASTATUS"] = vuelo.Status;
                    Fila["LEFT WING"] = vuelo.Left_Wing;
                    Fila["RA"] = vuelo.Roll_Angle_Value;
                    Fila["TTA"] = vuelo.True_Track_Angle;
                    Fila["GS"] = vuelo.Ground_Speed;
                    Fila["TAR"] = vuelo.Track_Angle_Rate;
                    Fila["TAS"] = vuelo.True_Airspeed;
                    Fila["HDG"] = vuelo.Magnetic_Heading;
                    Fila["IAS"] = vuelo.Indicated_AS;
                    Fila["MACH"] = vuelo.MACH;
                    Fila["BAR"] = vuelo.Barometric_Altitude_Rate;
                    Fila["IVV"] = vuelo.Inertial_Vertical_Velocity;
                    Fila["CNF170"] = vuelo.CNF;
                    Fila["RAD170"] = vuelo.RAD;
                    Fila["DOU170"] = vuelo.DOU;
                    Fila["MAH170"] = vuelo.MAH;
                    Fila["CDM170"] = vuelo.CDM;

                    Fila["TRE170"] = vuelo.TRE;
                    Fila["GHO170"] = vuelo.GHO;
                    Fila["SUP170"] = vuelo.SUP;
                    Fila["TCC170"] = vuelo.TCC;

                    Fila["COM230"] = vuelo.ACAS_Capability_COM;
                    Fila["STAT230"] = vuelo.ACAS_Capability_STAT;
                    Fila["SI230"] = vuelo.ACAS_Capability_SI;
                    Fila["MSSC230"] = vuelo.ACAS_Capability_MSSC;
                    Fila["ARC230"] = vuelo.ACAS_Capability_ARC;
                    Fila["AIC230"] = vuelo.ACAS_Capability_AIC;
                    Fila["B1A230"] = vuelo.ACAS_Capability_B1A;
                    Fila["B1B_37/230"] = vuelo.ACAS_Capability_B1B_37;
                    Fila["B1B_38/230"] = vuelo.ACAS_Capability_B1B_38;
                    Fila["B1B_3940/230"] = vuelo.ACAS_Capability_B1B_3940;
                    dt.Rows.Add( Fila );
                }
                
            }
                return dt;
        }


        public List<Flight> Set_Message_Values(List<List<byte[]>> DifferentMessagesDivided, List<BitArray> FspecList)
        {
            int MessagesLen = 0;

            foreach (BitArray fspec in FspecList)
            {
                int CounterForMessage = 0;
                Flight f = new Flight();
                List<byte[]> CurrentMessage = DifferentMessagesDivided[MessagesLen];
                if (fspec[0])
                {
                    f.Set_Data_Source_Identifier(CurrentMessage[CounterForMessage]);
                    CounterForMessage += 1;
                }
                else { f.Set_NA_DataSource(); }


                if (fspec[1])
                {
                    f.Set_Time_of_Day(CurrentMessage[CounterForMessage]);
                    CounterForMessage += 1;
                }
                else { f.Set_NA_TimeofDay(); }

                if (fspec[2])
                {
                    f.Set_Target_Report_Descriptor(CurrentMessage[CounterForMessage]);
                    CounterForMessage += 1;
                }
                else { f.Set_NA_TargetReport(); }


                if (fspec[3])
                {
                    f.Set_Measured_Position_in_Polar_Coordinates(CurrentMessage[CounterForMessage]);
                    CounterForMessage += 1;
                }
                else f.Set_NA_MeasuredPosition();


                if (fspec[4])
                {
                    f.Set_Aircraft_Mode_3A(CurrentMessage[CounterForMessage]);
                    CounterForMessage += 1;
                }
                else f.Set_NA_Mode3A();
                if (fspec[5])
                {
                    f.Set_Flight_Level(CurrentMessage[CounterForMessage]);
                    CounterForMessage += 1;
                }
                else f.Set_NA_FL();
                if (fspec[6])
                {
                    f.Set_Radar_Plot_Characteristics(CurrentMessage[CounterForMessage]);
                    CounterForMessage += 1;

                }
                else f.Set_NA_RadarPlot();


                if (fspec.Length > 8)
                {
                    if (fspec[8])
                    {
                        f.Set_Aircraft_Address(CurrentMessage[CounterForMessage]);
                        CounterForMessage += 1;
                    }
                    else f.Set_NA_AircraftAddress();
                    if (fspec[9])
                    {
                        f.Set_Aircraft_ID(CurrentMessage[CounterForMessage]);
                        CounterForMessage += 1;

                    }
                    else f.Set_NA_AircraftID();
                    if (fspec[10])
                    {
                        f.SetBDSRegisterData(CurrentMessage[CounterForMessage]);
                        CounterForMessage += 1;
                    }
                    else f.Set_NA_BDSRegisterData();
                    if (fspec[11])
                    {
                        f.Set_Track_Number(CurrentMessage[CounterForMessage]);
                        CounterForMessage += 1;
                    }
                    else f.Set_NA_Track_Number();
                    if (fspec[12])
                    {
                        f.Set_Calculated_Position_Cartesian(CurrentMessage[CounterForMessage]);
                        CounterForMessage += 1;
                    }
                    else f.Set_NA_CalculatedPosition();
                    if (fspec[13])
                    {
                        f.Set_Aircraft_Track_Velocity(CurrentMessage[CounterForMessage]);
                        CounterForMessage += 1;
                    }
                    else f.Set_NA_TrackVelocity();
                    if (fspec[14])
                    {
                        f.Set_Track_Status(CurrentMessage[CounterForMessage]);
                        CounterForMessage += 1;

                    }
                    else f.Set_NA_TrackStatus();

                    if (fspec.Length > 16)
                    {
                        if (fspec[20])
                        {
                            f.Set_Height_Measured(CurrentMessage[CounterForMessage]);
                            CounterForMessage += 1;
                        }
                        else f.Set_NA_Height_Measured();
                        if (fspec[22])
                        {
                            f.Set_Communications_ACAS_Capability(CurrentMessage[CounterForMessage]);
                            CounterForMessage += 1;
                        }
                        else f.Set_NA_Communications_ACAS_Capability();
                    }
                    else
                    {
                        f.Set_NA_Height_Measured();
                        f.Set_NA_Communications_ACAS_Capability();
                    }

                }
                else
                {
                    f.Set_NA_AircraftAddress();
                    f.Set_NA_BDSRegisterData();
                    f.Set_NA_CalculatedPosition();
                    f.Set_NA_AircraftID();
                    f.Set_NA_Track_Number();
                    f.Set_NA_TrackVelocity();
                    f.Set_NA_TrackStatus();

                }
                //Obtenemos el FL corregido en caso de que lo necesitamos

                if (f.Flight_Level_Value != "N/A")
                {
                    double h = Convert.ToDouble(f.Flight_Level_Value);
                    if (h < 60)
                    {
                        if (f.Barometric_Pressure != "N/A")
                        {
                            double Altitud_real = h*100 + (Convert.ToDouble(f.Barometric_Pressure) - 1013.25) * 30;
                            f.Corrected_FL = Convert.ToString(Altitud_real);
                        }
                        else f.Corrected_FL = Convert.ToString(h*100);
                    }
                }

                //Transformacion de Coordenadas
                f.Transformacion_Coordenadas();



                flights.Add(f);

                MessagesLen += 1;
            }
            return flights;
        }

        public List<Flight> ApplyGeographicFilter(List<Flight> flights)
        {
            List<Flight> flightsfiltered = new List<Flight>();

            foreach (Flight f in flights)
            {
                double latitude = Convert.ToDouble(f.Latitud);
                double longitude = Convert.ToDouble(f.Longitud);

                // Verificar las condiciones de filtrado
                if (latitude >= 40.9 && latitude <= 41.7 && longitude >= 1.5 && longitude <= 2.6)
                {
                    // Agregar el vuelo a la lista de vuelos filtrados
                    flightsfiltered.Add(f);
                }
            }

            return flightsfiltered;
        }

        public List<Flight> ApplyRequiredFilters(List<Flight> flights)
        {
            List<Flight> flightsfiltered = new List<Flight>();
            foreach (Flight f in flights)
            {
                if ((f.Target_Report_Descriptor_TYP== "ModeS Roll-Call +PSR") || (f.Target_Report_Descriptor_TYP == "Single ModeS Roll-Call")|| (f.Target_Report_Descriptor_TYP == "Single ModeS All-Call"))
                {
                    if (f.Mode_3A_Reply != "7777")
                    {
                        flightsfiltered.Add(f);
                    }
                    
                } 
                
            }
            return flightsfiltered;
        }

        public List<Flight> ApplyFlyingFilter(List<Flight> flights)
        {
            List<Flight> flightsfiltered = new List<Flight>();
            foreach (Flight f in flights)
            {
                if ((f.ACAS_Capability_STAT == "No alert, no SPI, aircraft airborne") || (f.Target_Report_Descriptor_TYP == "Alert, no SPI, aircraft airborne"))
                {
                    
                    flightsfiltered.Add(f);
                    
                }

            }
            return flightsfiltered;
        }
    }
}
