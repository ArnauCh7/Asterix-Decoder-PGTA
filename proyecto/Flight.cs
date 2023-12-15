using CsvHelper.Configuration;
using MultiCAT6.Utils;
using Project2;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;


namespace proyecto
{

    public class FlightMap : ClassMap<Flight>
    {
        public FlightMap()
        {

            Map(f => f.Data_Source_Identifier_SAC).Name("Data_Source_Identifier_SAC");
            Map(f => f.Data_Source_Identifier_SIC).Name("Data_Source_Identifier_SIC");
            Map(f => f.Time_of_Day).Name("Time_of_Day");

            Map(f => f.Latitud).Name("LATITUDE");
            Map(f => f.Longitud).Name("LONGITUDE");
            Map(f => f.Height).Name("Height");

            Map(f => f.Target_Report_Descriptor_TYP).Name("Target_Report_Descriptor_TYP");
            Map(f => f.Target_Report_Descriptor_SIM).Name("Target_Report_Descriptor_SIM");
            Map(f => f.Target_Report_Descriptor_RDP).Name("Target_Report_Descriptor_RDP");
            Map(f => f.Target_Report_Descriptor_SPI).Name("Target_Report_Descriptor_SPI");
            Map(f => f.Target_Report_Descriptor_RAB).Name("Target_Report_Descriptor_RAB");
            Map(f => f.Target_Report_Descriptor_FX).Name("Target_Report_Descriptor_FX");
            Map(f => f.Target_Report_Descriptor_TST).Name("Target_Report_Descriptor_TST");
            Map(f => f.Target_Report_Descriptor_ERR).Name("Target_Report_Descriptor_ERR");
            Map(f => f.Target_Report_Descriptor_ME).Name("Target_Report_Descriptor_ME");

            Map(f => f.Target_Report_Descriptor_XPP).Name("Target_Report_Descriptor_XPP");
            Map(f => f.Target_Report_Descriptor_MI).Name("Target_Report_Descriptor_MI");
            Map(f => f.Target_Report_Descriptor_FOEFRI).Name("Target_Report_Descriptor_FOEFRI");
            Map(f => f.Target_Report_Descriptor_FX2).Name("Target_Report_Descriptor_FX2");
            Map(f => f.Target_Report_Descriptor_ADSBEP).Name("Target_Report_Descriptor_ADSBEP");
            Map(f => f.Target_Report_Descriptor_ADSBVAL).Name("Target_Report_Descriptor_ADSBVAL");
            Map(f => f.Target_Report_Descriptor_SCNEP).Name("Target_Report_Descriptor_SCNEP");
            Map(f => f.Target_Report_Descriptor_SCNVAL).Name("Target_Report_Descriptor_SCNVAL");
            Map(f => f.Target_Report_Descriptor_PAIEP).Name("Target_Report_Descriptor_PAIEP");
            Map(f => f.Target_Report_Descriptor_PAIVAL).Name("Target_Report_Descriptor_PAIVAL");
            Map(f => f.Target_Report_Descriptor_FX3).Name("Target_Report_Descriptor_FX3");

            Map(f => f.Measured_Position_in_Polar_Coordinates_RHO).Name("Measured_Position_in_Polar_Coordinates_RHO");
            Map(f => f.Measured_Position_in_Polar_Coordinates_THETA).Name("Measured_Position_in_Polar_Coordinates_THETA");

            Map(f => f.Mode_3A_V).Name("Mode_3A_V");
            Map(f => f.Mode_3A_G).Name("Mode_3A_G");
            Map(f => f.Mode_3A_L).Name("Mode_3A_L");
            Map(f => f.Mode_3A_Reply).Name("Mode_3A_Reply");

            Map(f => f.Flight_Level_Validation).Name("Flight_Level_Validation");
            Map(f => f.Flight_Level_Garbed).Name("Flight_Level_Garbed");
            Map(f => f.Flight_Level_Value).Name("Flight_Level_Value");
            Map(f => f.Corrected_FL).Name("Corrected_FL");
            // Funciones para Data Item I048/130, Radar Plot Characteristics
            Map(f => f.SRL).Name("SRL");
            Map(f => f.SSR).Name("SSR");
            Map(f => f.SAM).Name("SAM");
            Map(f => f.PRL).Name("PRL");
            Map(f => f.PAM).Name("PAM");
            Map(f => f.RPD).Name("RPD");
            Map(f => f.APD).Name("APD");

            Map(f => f.Aircraft_Address).Name("Aircraft_Address");

            Map(f => f.Aircraft_ID).Name("Aircraft_ID");


            // Funciones Data Item /250, Mode S MB datas
            Map(f => f.BDS_Number).Name("BDS_Number");

            // 4,0
            Map(f => f.Selected_Alt).Name("Selected_Alt");
            Map(f => f.Selected_Alt_FMS).Name("Selected_Alt_FMS");
            Map(f => f.Barometric_Pressure).Name("Barometric_Pressure");
            Map(f => f.VNAV_Mode).Name("VNAV_Mode");
            Map(f => f.Status_MCP_FCU_Bits).Name("Status_MCP_FCU_Bits");
            Map(f => f.ALT_HOLD_MODE).Name("ALT_HOLD_MODE");
            Map(f => f.APPROACH_MODE).Name("APPROACH_MODE");
            Map(f => f.Status_Target_Alt_Bits).Name("Status_Target_Alt_Bits");
            Map(f => f.Target_Alt_Source).Name("Target_Alt_Source");

            // 5,0
            Map(f => f.Status).Name("Status");
            Map(f => f.Left_Wing).Name("Left_Wing");
            Map(f => f.Roll_Angle_Value).Name("Roll_Angle_Value");
            Map(f => f.True_Track_Angle).Name("True_Track_Angle");
            Map(f => f.Ground_Speed).Name("Ground_Speed");
            Map(f => f.Track_Angle_Rate).Name("Track_Angle_Rate");
            Map(f => f.True_Airspeed).Name("True_Airspeed");

            // 6,0
            Map(f => f.Magnetic_Heading).Name("Magnetic_Heading");
            Map(f => f.Indicated_AS).Name("Indicated_AS");
            Map(f => f.MACH).Name("MACH");
            Map(f => f.Barometric_Altitude_Rate).Name("Barometric_Altitude_Rate");
            Map(f => f.Inertial_Vertical_Velocity).Name("Inertial_Vertical_Velocity");


            Map(f => f.Track_Number).Name("Track_Number");

            // Funciones de Calculated Position
            Map(f => f.Calculated_Position_Cartesian_X).Name("Calculated_Position_Cartesian_X");
            Map(f => f.Calculated_Position_Cartesian_Y).Name("Calculated_Position_Cartesian_Y");

            // Funciones de Track Velocity
            Map(f => f.Calculated_Track_Velocity_Polar_GroundSpeed).Name("Calculated_Track_Velocity_Polar_GroundSpeed");
            Map(f => f.Calculated_Track_Velocity_Polar_Heading).Name("Calculated_Track_Velocity_Polar_Heading");


            // Funciones Track Status
            Map(f => f.CNF).Name("CNF");
            Map(f => f.RAD).Name("RAD");
            Map(f => f.DOU).Name("DOU");
            Map(f => f.MAH).Name("MAH");
            Map(f => f.CDM).Name("CDM");
            Map(f => f.FX).Name("FX");
            Map(f => f.TRE).Name("TRE");
            Map(f => f.GHO).Name("GHO");
            Map(f => f.SUP).Name("SUP");
            Map(f => f.TCC).Name("TCC");
            Map(f => f.FX2).Name("FX2");


            Map(f => f.Height_Measured_by_3D_Radar).Name("Height_Measured_by_3D_Radar");

            //Funciones Data Item I048/230, Communications/ACAS Capability and Flight Status
            Map(f => f.ACAS_Capability_COM).Name("ACAS_Capability_COM");
            Map(f => f.ACAS_Capability_STAT).Name("ACAS_Capability_STAT");
            Map(f => f.ACAS_Capability_SI).Name("ACAS_Capability_SI");
            Map(f => f.ACAS_Capability_MSSC).Name("ACAS_Capability_MSSC");
            Map(f => f.ACAS_Capability_ARC).Name("ACAS_Capability_ARC");
            Map(f => f.ACAS_Capability_AIC).Name("ACAS_Capability_AIC");
            Map(f => f.ACAS_Capability_B1A).Name("ACAS_Capability_B1A");
            Map(f => f.ACAS_Capability_B1B_37).Name("ACAS_Capability_B1B_37");
            Map(f => f.ACAS_Capability_B1B_38).Name("ACAS_Capability_B1B_38");
            Map(f => f.ACAS_Capability_B1B_3940).Name("ACAS_Capability_B1B_3940");


        }
    }
    public class Flight
    {
        //Funciones a hacer cada uno (son 19/3= 6 por cabeza y si alguien lo acaba y tiene tiempo que haga la que sobra)
        //Funciones para Lucas
        //// Funciones del Data_Source_Identifier



        public string Data_Source_Identifier_SAC = "";
        public string Data_Source_Identifier_SIC = "";

        public string Time_of_Day = "";



        //// Funciones del Target_Report_Descriptor
        string TYP = "";
        string FOEFRI = "";


        public string Target_Report_Descriptor_TYP = "";
        public string Target_Report_Descriptor_SIM = "";
        public string Target_Report_Descriptor_RDP = "";
        public string Target_Report_Descriptor_SPI = "";
        public string Target_Report_Descriptor_RAB = "";
        public string Target_Report_Descriptor_FX = "";
        public string Target_Report_Descriptor_TST = "";
        public string Target_Report_Descriptor_ERR = "";
        public string Target_Report_Descriptor_ME = "";
        public string Target_Report_Descriptor_XPP = "";
        public string Target_Report_Descriptor_MI = "";
        public string Target_Report_Descriptor_FOEFRI = "";
        public string Target_Report_Descriptor_FX2 = "";
        public string Target_Report_Descriptor_ADSBEP = "";
        public string Target_Report_Descriptor_ADSBVAL = "";
        public string Target_Report_Descriptor_SCNEP = "";
        public string Target_Report_Descriptor_SCNVAL = "";
        public string Target_Report_Descriptor_PAIEP = "";
        public string Target_Report_Descriptor_PAIVAL = "";
        public string Target_Report_Descriptor_FX3 = "";


        // Funciones para la Position in polar Coordinates
        public string Measured_Position_in_Polar_Coordinates_RHO = "";
        public string Measured_Position_in_Polar_Coordinates_THETA = "";

        //Funciones para Geodesic
        public string Latitud = "";
        public string Longitud = "";
        public string Height = "";

        // FUnciones para Estereographic
        public string U = "";
        public string V = "";
        public string H = "";
        // Funciones para el FL
        public string Flight_Level_Validation = "";
        public string Flight_Level_Garbed = "";
        public string Flight_Level_Value = "";


        public string Corrected_FL = "";
        // Funciones para el Mode-3/A
        public string Mode_3A_V = "";
        public string Mode_3A_G = "";
        public string Mode_3A_L = "";
        public string Mode_3A_Reply = "";

        //Aircraft_Address; // En teoria hay que ponerlo para todas los FX
        public string Aircraft_Address = "";

        // ID
        public string Aircraft_ID = "";
        List<string> Separated_letters = new List<string>();
        private Dictionary<string, string> decoder = new Dictionary<string, string>
        {
        {"010000", "P"},
        {"100000", " "},
        {"110000", "0"},
        {"000001", "A"},
        {"000010", "B"},
        {"000011", "C"},
        {"000100", "D"},
        {"000101", "E"},
        {"000110", "F"},
        {"000111", "G"},
        {"001000", "H"},
        {"001001", "I"},
        {"001010", "J"},
        {"001011", "K"},
        {"001100", "L"},
        {"001101", "M"},
        {"001110", "N"},
        {"001111", "O"},

        {"010001", "Q"},
        {"010010", "R"},
        {"010011", "S"},
        {"010100", "T"},
        {"010101", "U"},
        {"010110", "V"},
        {"010111", "W"},
        {"011000", "X"},
        {"011001", "Y"},
        {"011010", "Z"},


        {"110001", "1"},
        {"110010", "2"},
        {"110011", "3"},
        {"110100", "4"},
        {"110101", "5"},
        {"110110", "6"},
        {"110111", "7"},
        {"111000", "8"},
        {"111001", "9"},
        };


        public string Decode_ID(bool b1, bool b2, bool b3, bool b4, bool b5, bool b6)
        {
            string key = ConvertBoolArrayToString(new bool[] { b1, b2, b3, b4, b5, b6 });

            if (decoder.ContainsKey(key))
            {
                return decoder[key];
            }
            else
            {
                throw new ArgumentException("Invalid bool combination.");
            }
        }

        private string ConvertBoolArrayToString(bool[] boolArray)
        {
            if (boolArray.Length != 6)
            {
                throw new ArgumentException("Input array must contain 6 bools.");
            }

            return string.Join("", boolArray.Select(b => b ? "1" : "0"));
        }


        /// <summary>
        /// Aircraft ID ,I048/240
        /// </summary>
        /// <param name="Aircraft_ID_bytes"></param>
        public void Set_Aircraft_ID(byte[] Aircraft_ID_bytes)
        {

            BitArray Bit_Aircraft_ID = ChangeFormat(Aircraft_ID_bytes);  //new BitArray(Aircraft_ID_bytes);

            Separated_letters.Clear();
            string Joined_ID;

            for (int i = 0; i < 8; i++)
            {

                bool b1 = Bit_Aircraft_ID.Get(42 - (6 * i));
                bool b2 = Bit_Aircraft_ID.Get(43 - (6 * i));
                bool b3 = Bit_Aircraft_ID.Get(44 - (6 * i));
                bool b4 = Bit_Aircraft_ID.Get(45 - (6 * i));
                bool b5 = Bit_Aircraft_ID.Get(46 - (6 * i));
                bool b6 = Bit_Aircraft_ID.Get(47 - (6 * i));

                try
                {
                    string decodedLetter = Decode_ID(b1, b2, b3, b4, b5, b6);
                    Separated_letters.Add(decodedLetter);

                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

            }
            Separated_letters.Reverse();
            Joined_ID = string.Join("", Separated_letters);
            Aircraft_ID = Joined_ID;

        }





        public string Track_Number = "";


        // Funciones de Calculated Position
        public string Calculated_Position_Cartesian_X = "";
        public string Calculated_Position_Cartesian_Y = "";

        // Funciones de Track Velocity
        public string Calculated_Track_Velocity_Polar_GroundSpeed = "";
        public string Calculated_Track_Velocity_Polar_Heading = "";

        public string Height_Measured_by_3D_Radar = "";
        public int Special_Purpose_Field;




        //Funciones para Data Item I048/130, Radar Plot Characteristics
        public string SRL = "";
        public string SSR = "";
        public string SAM = "";
        public string PRL = "";
        public string PAM = "";
        public string RPD = "";
        public string APD = "";

        // Funciones Data Item /250, Mode S MB datas
        public string BDS_Number = "";

        // 4,0
        public string Selected_Alt = "";
        public string Selected_Alt_FMS = "";
        public string Barometric_Pressure = "";
        public string VNAV_Mode = "";
        public string Status_MCP_FCU_Bits = "";
        public string ALT_HOLD_MODE = "";
        public string APPROACH_MODE = "";
        public string Status_Target_Alt_Bits = "";
        public string Target_Alt_Source = "";

        // 5,0
        public string Status = "";
        public string Left_Wing = "";
        public string Roll_Angle_Value = "";
        public string True_Track_Angle = "";
        public string Ground_Speed = "";
        public string Track_Angle_Rate = "";
        public string True_Airspeed = "";

        // 6,0
        public string Magnetic_Heading = "";
        public string Indicated_AS = "";
        public string MACH = "";
        public string Barometric_Altitude_Rate = "";
        public string Inertial_Vertical_Velocity = "";

        // Funciones Track Status
        public string CNF = "";
        public string RAD = "";
        public string DOU = "";
        public string MAH = "";
        public string CDM = "";
        public string FX = "";
        public string TRE = "";
        public string GHO = "";
        public string SUP = "";
        public string TCC = "";
        public string FX2 = "";

        //Funciones Data Item I048/230, Communications/ACAS Capability and Flight Status
        public string ACAS_Capability_COM = "";
        public string ACAS_Capability_STAT = "";
        public string ACAS_Capability_SI = "";
        public string ACAS_Capability_MSSC = "";

        public string ACAS_Capability_ARC = "";
        public string ACAS_Capability_AIC = "";
        public string ACAS_Capability_B1A = "";
        public string ACAS_Capability_B1B_37 = "";
        public string ACAS_Capability_B1B_38 = "";
        public string ACAS_Capability_B1B_3940 = "";
        /// <summary>
        /// Track Status, I048/170
        /// </summary>
        /// <param name="Track_Status_Bytes"></param>
        public void Set_Track_Status(byte[] Track_Status_Bytes)
        {

            BitArray bitArray_First_Part = new BitArray(new byte[] { Track_Status_Bytes[0] });

            bitArray_First_Part.Length = 8;


            if (bitArray_First_Part[7])
            {
                CNF = "Tentative Track";
            }
            else
                CNF = "Confirmed Track";


            if (bitArray_First_Part[6] && bitArray_First_Part[5])
            {
                RAD = "Invalid";
            }
            else if (bitArray_First_Part[6] == false && bitArray_First_Part[5])
            {
                RAD = "PSR Track";
            }
            else if (bitArray_First_Part[6] && bitArray_First_Part[5] == false)
            {
                RAD = "SSR/Mode S Track";
            }
            else if (bitArray_First_Part[6] == false && bitArray_First_Part[5] == false)
            {
                RAD = "Combined Track";
            }

            if (bitArray_First_Part[4])
            {
                DOU = "Low confidence in plot to track association";
            }
            else
                DOU = "Normal confidence";


            if (bitArray_First_Part[3])
            {
                MAH = "Horizontal man. sensed";
            }
            else
                MAH = "No horizontal man.sensed";



            if (bitArray_First_Part[2] && bitArray_First_Part[1])
            {
                CDM = "Unknown";
            }
            if (bitArray_First_Part[2] == false && bitArray_First_Part[1])
            {
                CDM = "Climbing";
            }
            if (bitArray_First_Part[2] && bitArray_First_Part[1] == false)
            {
                CDM = "Descending";
            }
            if (bitArray_First_Part[2] == false && bitArray_First_Part[1] == false)
            {
                CDM = "Maintaining";
            }

            if ((bitArray_First_Part[0]))
            {
                FX = "Extension into first extent";
                BitArray bitArray_First_Extent = new BitArray(new byte[] { Track_Status_Bytes[1] });

                Reverse(bitArray_First_Extent);


                if (bitArray_First_Extent[7])
                    TRE = "End of track lifetime(last report for this track)";
                else
                    TRE = "Track still alive";

                if ((bitArray_First_Extent[6]))
                    GHO = "Ghost target track";
                else
                    GHO = "True target track";

                if ((bitArray_First_Extent[5]))
                    SUP = "Yes";
                else
                    SUP = "No";

                if ((bitArray_First_Extent[4]))
                    TCC = "Slant range correction and a suitable\r\nprojection technique are used to track in a\r\n2D.reference plane, tangential to the earth\r\nmodel at the Radar Site co-ordinates.\r\n";
                else
                    TCC = "Tracking performed in so-called 'Radar\r\nPlane', i.e. neither slant range correction nor\r\nstereographical projection was applied.\r\n";

                if ((bitArray_First_Extent[0]))
                    FX2 = "Extension into second extent";
                else
                    FX2 = "End of Data Item";
            }
            else
            {
                FX = "End of Data Item";
                TRE = "N/A";
                GHO = "N/A";
                SUP = "N/A";
                TCC = "N/A";
                FX = "N/A";
            }
        }


        /// <summary>
        /// Sets the ACAS (Aircraft Collision Avoidance System) Communications Capability based on the input bytes.I048/230
        /// </summary>
        /// <param name="ACAS_Capability_Bytes">An array of bytes representing ACAS capability.</param>
        public void Set_Communications_ACAS_Capability(byte[] ACAS_Capability_Bytes)
        {
            BitArray bitArray_ACAS = ChangeFormat(ACAS_Capability_Bytes);//new BitArray(ACAS_Capability_Bytes);
            Reverse(bitArray_ACAS);

            int COM_Value = GetIntFromBitArray(bitArray_ACAS, 14, 16);
            if (COM_Value == 0)
            {
                ACAS_Capability_COM = "No communications capability (surveillance only)";
            }
            else if (COM_Value == 1)
            {
                ACAS_Capability_COM = "Comm. A and Comm. B capability";
            }
            else if (COM_Value == 2)
            {
                ACAS_Capability_COM = "Comm. A, Comm. B and Uplink ELM";
            }
            else if (COM_Value == 3)
            {
                ACAS_Capability_COM = "Comm. A, Comm. B, Uplink ELM and Downlink ELM";
            }
            else if (COM_Value == 4)
            {
                ACAS_Capability_COM = "Level 5 Transponder capability";
            }
            else
                ACAS_Capability_COM = "Not Assigned";

            int STAT_Value = GetIntFromBitArray(bitArray_ACAS, 11, 13);
            if (STAT_Value == 0)
            {
                ACAS_Capability_STAT = "No alert, no SPI, aircraft airborne";
            }
            else if (STAT_Value == 1)
            {
                ACAS_Capability_STAT = "No alert, no SPI, aircraft on ground";
            }
            else if (STAT_Value == 2)
            {
                ACAS_Capability_STAT = "Alert, no SPI, aircraft airborne";
            }
            else if (STAT_Value == 3)
            {
                ACAS_Capability_STAT = "Alert, no SPI, aircraft on ground";
            }
            else if (STAT_Value == 4)
            {
                ACAS_Capability_STAT = "Level 5 Transponder capability";
            }
            else if (STAT_Value == 5)
                ACAS_Capability_STAT = "No alert, SPI, aircraft airborne or on ground";
            else if (STAT_Value == 6)
                ACAS_Capability_STAT = "Not Assigned";
            else if (STAT_Value == 7)
                ACAS_Capability_STAT = "Unknown";


            if (bitArray_ACAS[9])
                ACAS_Capability_SI = "II-Code Capable";
            else
                ACAS_Capability_SI = "SI-Code Capable";


            if (bitArray_ACAS[7])
                ACAS_Capability_MSSC = "Yes";
            else
                ACAS_Capability_MSSC = "No";

            if (bitArray_ACAS[6])
                ACAS_Capability_ARC = "25ft Resolution";
            else
                ACAS_Capability_ARC = "100ft Resolution";

            if (bitArray_ACAS[5])
                ACAS_Capability_AIC = "Yes";
            else
                ACAS_Capability_AIC = "No";



            /// Bit 16 shall be set to ONE (1) to indicate that ACAS is operational and set to ZERO(0) to indicate that ACAS has failed or is on standby

            if (bitArray_ACAS[4])
                ACAS_Capability_B1A = "ACAS is Operational";
            else
                ACAS_Capability_B1A = "ACcas has failed or is on standby";



            if (bitArray_ACAS[3])
                ACAS_Capability_B1B_37 = "capability of hybrid surveillance";
            else
                ACAS_Capability_B1B_37 = "No capability of hybrid surveillance";

            if (bitArray_ACAS[2])
                ACAS_Capability_B1B_38 = "ACAS is generating both TAs and RAs";
            else
                ACAS_Capability_B1B_38 = "ACAS is only generating TAs ";


            if (bitArray_ACAS[1] && bitArray_ACAS[0])
                ACAS_Capability_B1B_3940 = "Reserved for future versions ";

            else if (bitArray_ACAS[1] && bitArray_ACAS[0] == false)
                ACAS_Capability_B1B_3940 = "RTCA DO-185A";

            else if (bitArray_ACAS[1] == false && bitArray_ACAS[0])
                ACAS_Capability_B1B_3940 = "RTCA DO-185B";

            else if (bitArray_ACAS[1] == false && bitArray_ACAS[0] == false)
                ACAS_Capability_B1B_3940 = "RTCA DO-185";


        }


        /// <summary>
        /// Data Source Identifier I048/010
        /// </summary>
        /// <param name="Data_Source_ID_Bytes"></param>
        public void Set_Data_Source_Identifier(byte[] Data_Source_ID_Bytes)
        {

            Data_Source_Identifier_SAC = Convert.ToString(Data_Source_ID_Bytes[0]);



            Data_Source_Identifier_SIC = Convert.ToString(Data_Source_ID_Bytes[1]);
        }
        /// <summary>
        /// Time of the Day, I048/140
        /// </summary>
        /// <param name="Data_Source_ID_Bytes"></param>
        public void Set_Time_of_Day(byte[] Data_Source_ID_Bytes)
        {
            BitArray Data_Source_ID_Bits = ChangeFormat(Data_Source_ID_Bytes);
            Reverse(Data_Source_ID_Bits);
            double decimalValue = Convert.ToDouble(GetIntFromBitArray(Data_Source_ID_Bits, 1, 24)) / 128.0;  //Value in seconds from 00:00


            string time = TimeSpan.FromSeconds(decimalValue).ToString(@"hh\:mm\:ss\.fff");
            Time_of_Day = time;

        }

        /// <summary>
        /// Target Report Descriptor I048/020
        /// </summary>
        /// <param name="Target_Report_Descriptor_Bytes"></param>
        public void Set_Target_Report_Descriptor(byte[] Target_Report_Descriptor_Bytes)
        {
            BitArray bitArray_FirstPart = new BitArray(new byte[] { Target_Report_Descriptor_Bytes[0] });
            //Reverse(bitArray_FirstPart);

            //TYP

            if (bitArray_FirstPart[7] == false && bitArray_FirstPart[6] == false && bitArray_FirstPart[5] == false)
            {
                TYP = "No detection";
            }
            else if (bitArray_FirstPart[7] == false && bitArray_FirstPart[6] == false && bitArray_FirstPart[5] == true)
            {
                TYP = "Single PSR detection";
            }
            else if (bitArray_FirstPart[7] == false && bitArray_FirstPart[6] == true && bitArray_FirstPart[5] == false)
            {
                TYP = "Single SSR detection";
            }
            else if (bitArray_FirstPart[7] == false && bitArray_FirstPart[6] == true && bitArray_FirstPart[5] == true)
            {
                TYP = "SSR + PSR detection";
            }
            else if (bitArray_FirstPart[7] == true && bitArray_FirstPart[6] == false && bitArray_FirstPart[5] == false)
            {
                TYP = "Single ModeS All-Call";
            }
            else if (bitArray_FirstPart[7] == true && bitArray_FirstPart[6] == false && bitArray_FirstPart[5] == true)
            {
                TYP = "Single ModeS Roll-Call";
            }
            else if (bitArray_FirstPart[7] == true && bitArray_FirstPart[6] == true && bitArray_FirstPart[5] == false)
            {
                TYP = "ModeS All-Call + PSR";
            }
            else if (bitArray_FirstPart[7] == true && bitArray_FirstPart[6] == true && bitArray_FirstPart[5] == true)
            {
                TYP = "ModeS Roll-Call +PSR";
            }

            Target_Report_Descriptor_TYP = TYP;
            // SIM
            String SIM;
            if (bitArray_FirstPart[4])
            {
                SIM = "Simulated target report";
            }
            else
                SIM = "Actual target report";

            Target_Report_Descriptor_SIM = SIM;

            //RDP
            String RDP;
            if (bitArray_FirstPart[3])
            {
                RDP = "Report from RDP Chain 2";
            }
            else
                RDP = "Report from RDP Chain 1";

            Target_Report_Descriptor_RDP = RDP;


            //SPI
            String SPI;
            if (bitArray_FirstPart[2])
            {
                SPI = "Special Position Identification";
            }
            else
                SPI = "Absence of SPI";

            Target_Report_Descriptor_SPI = SPI;

            //RAB
            String RAB;
            if (bitArray_FirstPart[1])
            {
                RAB = "Report from field monitor (fixed transponder)";
            }
            else
                RAB = "Report from aircraft transponder";

            Target_Report_Descriptor_RAB = RAB;

            //FX
            string FX;
            if (bitArray_FirstPart[0])
            {
                FX = "Extension into first extent";
                Target_Report_Descriptor_FX = FX;

                BitArray bitArray_FirstExtension = new BitArray(new byte[] { Target_Report_Descriptor_Bytes[1] });
                Reverse(bitArray_FirstExtension);


                // TST
                string TST;
                if (bitArray_FirstExtension[7])
                {
                    TST = "Test target report";
                }
                else
                    TST = "Real target report";

                Target_Report_Descriptor_TST = TST;

                //ERR
                string ERR;
                if (bitArray_FirstExtension[6])
                {
                    ERR = "Extended Range present";
                }
                else
                    ERR = "No Extended Range";

                Target_Report_Descriptor_ERR = ERR;

                //XPP
                string XPP;
                if (bitArray_FirstExtension[5])
                {
                    XPP = "X-Pulse present";
                }
                else
                    XPP = "No X-Pulse present";

                Target_Report_Descriptor_XPP = XPP;
                //ME
                string ME;
                if (bitArray_FirstExtension[4])
                {
                    ME = "Military emergency";
                }
                else
                    ME = "No Military emergency";

                Target_Report_Descriptor_ME = ME;

                //MI
                string MI;
                if (bitArray_FirstExtension[3])
                {
                    MI = "Military Identification";
                }
                else
                    MI = "No Military Identification";


                Target_Report_Descriptor_MI = MI;

                // FOE/FRI

                if (bitArray_FirstExtension[2] && bitArray_FirstExtension[1])
                {
                    FOEFRI = "No reply";
                }
                else if (bitArray_FirstExtension[2] && bitArray_FirstExtension[1] == false)
                    FOEFRI = "Unknown target";
                else if (bitArray_FirstExtension[2] == false && bitArray_FirstExtension[1] == false)
                    FOEFRI = "No Mode 4 interrogation";
                else if (bitArray_FirstExtension[2] == false && bitArray_FirstExtension[1])
                    FOEFRI = "Friendly target";

                Target_Report_Descriptor_FOEFRI = FOEFRI;

                //FX
                string FX2;
                if (bitArray_FirstExtension[0])
                {
                    FX2 = "Extension into next extent";
                    Target_Report_Descriptor_FX2 = FX2;
                    BitArray bitArray_SecondExtension = new BitArray(new byte[] { Target_Report_Descriptor_Bytes[1] });
                    Reverse(bitArray_SecondExtension);

                    //ADSBEP
                    string ADSBEP;
                    if (bitArray_SecondExtension[7])
                    {
                        ADSBEP = "ADSB populated";

                    }
                    else
                        ADSBEP = "ADSB not populated";
                    Target_Report_Descriptor_ADSBEP = ADSBEP;

                    //ADSBVAL
                    string ADSBVAL;
                    if (bitArray_SecondExtension[6])
                    {
                        ADSBVAL = "Information available";

                    }
                    else
                        ADSBVAL = "Information not available";

                    Target_Report_Descriptor_ADSBVAL = ADSBVAL;

                    //SCN EP
                    string SCNEP;
                    if (bitArray_SecondExtension[5])
                    {
                        SCNEP = "SCN Populated";

                    }
                    else
                        SCNEP = "SCN not populated";

                    Target_Report_Descriptor_SCNEP = SCNEP;
                    //SCN VAL
                    string SCNVAL;
                    if (bitArray_SecondExtension[4])
                    {
                        SCNVAL = "Surveillance Cluster Network Information Available";

                    }
                    else
                        SCNVAL = "Surveillance Cluster Network Information not available";

                    Target_Report_Descriptor_SCNVAL = SCNVAL;
                    //`PAI EP
                    string PAIEP;
                    if (bitArray_SecondExtension[3])
                    {
                        PAIEP = "PAI Populated";

                    }
                    else
                        PAIEP = "PAI not populated";

                    Target_Report_Descriptor_PAIEP = PAIEP;

                    //SCN VAL
                    string PAIVAL;
                    if (bitArray_SecondExtension[2])
                    {
                        PAIVAL = "Passive Acquisition Interface Information Available";

                    }
                    else
                        PAIVAL = "Passive Acquisition Interface Information not available";

                    Target_Report_Descriptor_PAIVAL = PAIVAL;

                    // FX3
                    string FX3;
                    if (bitArray_SecondExtension[0])
                    {
                        FX3 = "Extension into next extent";
                        Target_Report_Descriptor_FX3 = FX3;
                    }
                    else
                    {
                        FX3 = "End of Data Item";
                        Target_Report_Descriptor_FX3 = FX3;
                    }







                }
                else
                {
                    FX2 = "End of Data Item";
                    Target_Report_Descriptor_FX2 = FX2;
                    Target_Report_Descriptor_ADSBEP = "N/A";
                    Target_Report_Descriptor_ADSBVAL = "N/A";
                    Target_Report_Descriptor_SCNEP = "N/A";
                    Target_Report_Descriptor_SCNVAL = "N/A";
                    Target_Report_Descriptor_PAIEP = "N/A";
                    Target_Report_Descriptor_PAIVAL = "N/A";
                    Target_Report_Descriptor_FX3 = "N/A";

                }




            }
            else
            {
                FX = "End of Data Item";
                Target_Report_Descriptor_FX = FX;
                Target_Report_Descriptor_FX2 = "N/A";
                Target_Report_Descriptor_ADSBEP = "N/A";
                Target_Report_Descriptor_ADSBVAL = "N/A";
                Target_Report_Descriptor_SCNEP = "N/A";
                Target_Report_Descriptor_SCNVAL = "N/A";
                Target_Report_Descriptor_PAIEP = "N/A";
                Target_Report_Descriptor_PAIVAL = "N/A";
                Target_Report_Descriptor_FX3 = "N/A";
                Target_Report_Descriptor_XPP = "N/A";
                Target_Report_Descriptor_ME = "N/A";
                Target_Report_Descriptor_MI = "N/A";
                Target_Report_Descriptor_FOEFRI = "N/A";
                Target_Report_Descriptor_TST = "N/A";
                Target_Report_Descriptor_ERR = "N/A";
            }




        }


        /// <summary>
        /// Measured Position in Slant Polar Coordinates, I048/040
        /// </summary>
        /// <param name="Measured_Position_in_Polar_Coordinates_bytes"></param>
        public void Set_Measured_Position_in_Polar_Coordinates(byte[] Measured_Position_in_Polar_Coordinates_bytes)
        {
            BitArray bitArray_Measured_Position = ChangeFormat(Measured_Position_in_Polar_Coordinates_bytes); //new BitArray(Measured_Position_in_Polar_Coordinates_bytes);
            Reverse(bitArray_Measured_Position);
            float Decimal_Rho = GetIntFromBitArray(bitArray_Measured_Position, 17, 32);
            float Decimal_Theta = GetIntFromBitArray(bitArray_Measured_Position, 1, 16);

            double Rho_Value = Decimal_Rho / 256;
            double Theta_Value = 360 * Decimal_Theta / (Math.Pow(2, 16));

            Measured_Position_in_Polar_Coordinates_RHO = Convert.ToString(Rho_Value);
            Measured_Position_in_Polar_Coordinates_THETA = Convert.ToString(Theta_Value);




        }



        /// <summary>
        /// Flight Level in Binary Representation,I048/090
        /// </summary>
        /// <param name="FL_bytes"></param>
        public void Set_Flight_Level(byte[] FL_bytes)
        {
            BitArray bitarray_Flight_Level = ChangeFormat(FL_bytes);//new BitArray(FL_bytes);
            Reverse(bitarray_Flight_Level);

            if (bitarray_Flight_Level[15])
            {

                Flight_Level_Validation = "Code not Validated";
            }
            else
                Flight_Level_Validation = "Code Validated";

            if (bitarray_Flight_Level[14])
            {

                Flight_Level_Garbed = "Garbled Code";
            }
            else
                Flight_Level_Garbed = "Default";

            BitArray bitarray_FL = SelectRangeFromBitArray(bitarray_Flight_Level, 0, 13);
            Reverse(bitarray_FL);
            double value = BitArrayToDecimalTwosComplement(bitarray_FL) / 4.0;
            Flight_Level_Value = Convert.ToString(value);


        }



        /// <summary>
        /// Aircraft Address,I048/220
        /// </summary>
        /// <param name="Aircraft_Address_Bytes"></param>
        /// <exception cref="ArgumentException"></exception>
        public void Set_Aircraft_Address(byte[] Aircraft_Address_Bytes)
        {
            BitArray Aircraft_Addres_Bits = ChangeFormat(Aircraft_Address_Bytes);
            byte[] Reversed_Aircraft_Address_Bytes = BitArrayToByteArray(Aircraft_Addres_Bits);
            // Make sure the input byte array is exactly 3 bytes (24 bits).
            if (Reversed_Aircraft_Address_Bytes.Length != 3)
            {
                throw new ArgumentException("Input byte array must be 3 bytes (24 bits) long.");
            }

            // Convert the byte array to a hexadecimal string.
            string hexString = BitConverter.ToString(Reversed_Aircraft_Address_Bytes).Replace("-", "");

            // The hexString variable now contains the hexadecimal representation.
            Aircraft_Address = hexString;
        }





        private byte[] BitArrayToByteArray(BitArray bitArray)
        {
            int numBytes = (bitArray.Length + 7) / 8;
            byte[] byteArray = new byte[numBytes];

            for (int i = 0; i < numBytes; i++)
            {
                int byteValue = 0;
                for (int j = 0; j < 8; j++)
                {
                    int bitIndex = i * 8 + j;
                    if (bitIndex < bitArray.Length && bitArray[bitIndex])
                    {
                        byteValue |= (1 << (7 - j));
                    }
                }
                byteArray[i] = (byte)byteValue;
            }

            return byteArray;
        }



        /// <summary>
        /// Mode-3/A Code in Octal Representation,I048/070
        /// </summary>
        /// <param name="Aircraft_mode_3a"></param>
        public void Set_Aircraft_Mode_3A(byte[] Aircraft_mode_3a)
        {
            BitArray bitarray_Aircraft_Mode_3A = ChangeFormat(Aircraft_mode_3a);   //new BitArray(Aircraft_mode_3a);
            Reverse(bitarray_Aircraft_Mode_3A);

            if (bitarray_Aircraft_Mode_3A[15])
                Mode_3A_V = "Code not validated";
            else
                Mode_3A_V = "Code  validated";

            if (bitarray_Aircraft_Mode_3A[14])
                Mode_3A_G = "Garbled Code";
            else
                Mode_3A_G = "Default";

            if (bitarray_Aircraft_Mode_3A[13])
                Mode_3A_L = "Mode-3/A code not extracted during the last scan";
            else
                Mode_3A_L = "Mode-3/A code derived from the reply of the transponder";

            //Falta los valores en OCTAL

            int firstdigit = GetIntFromBitArray(bitarray_Aircraft_Mode_3A, 10, 12);
            int secondgiti = GetIntFromBitArray(bitarray_Aircraft_Mode_3A, 7, 9);
            int thirddigit = GetIntFromBitArray(bitarray_Aircraft_Mode_3A, 4, 6);
            int fourthdigit = GetIntFromBitArray(bitarray_Aircraft_Mode_3A, 1, 3);
            string code = Convert.ToString(firstdigit) + Convert.ToString(secondgiti) + Convert.ToString(thirddigit) + Convert.ToString(fourthdigit);
            Mode_3A_Reply = code;
        }




        /// <summary>
        /// Track Number I048/161
        /// </summary>
        /// <param name="Aircraft_Track_number_bytes"></param>
        public void Set_Track_Number(byte[] Aircraft_Track_number_bytes)
        {
            BitArray Bits_Track_number = ChangeFormat(Aircraft_Track_number_bytes);//new BitArray(Aircraft_Track_number_bytes)
            Reverse(Bits_Track_number);
            int value = GetIntFromBitArray(Bits_Track_number, 1, 12);
            Track_Number = Convert.ToString(value);
        }



        /// <summary>
        /// Calculated Position in Cartesian Coordinates,I048/042
        /// </summary>
        /// 
        /// <param name="Aircraft_Calculated_Position_bytes"></param>
        public void Set_Calculated_Position_Cartesian(byte[] Aircraft_Calculated_Position_bytes)
        {
            BitArray Bits_Calculated_Position = ChangeFormat(Aircraft_Calculated_Position_bytes);//new BitArray(Aircraft_Calculated_Position_bytes);
            Reverse(Bits_Calculated_Position);
            double X_comp = GetIntFromBitArray(Bits_Calculated_Position, 17, 32) / 128;
            double Y_comp = GetIntFromBitArray(Bits_Calculated_Position, 1, 16) / 128;
            Calculated_Position_Cartesian_X = Convert.ToString(X_comp);
            Calculated_Position_Cartesian_Y = Convert.ToString(Y_comp);
        }




        /// <summary>
        /// Calculated Track Velocity in Polar Representation.I048/200
        /// </summary>
        /// <param name="Aircraft_Track_Velocity_Bytes"></param>
        public void Set_Aircraft_Track_Velocity(byte[] Aircraft_Track_Velocity_Bytes)
        {
            BitArray Bits_Aircraft_Track_Velocity = ChangeFormat(Aircraft_Track_Velocity_Bytes); //new BitArray(Aircraft_Track_Velocity_Bytes);
            Reverse(Bits_Aircraft_Track_Velocity);
            Calculated_Track_Velocity_Polar_GroundSpeed = Convert.ToString(GetIntFromBitArray(Bits_Aircraft_Track_Velocity, 17, 32) * 0.22);//Math.Pow(2, -14)*7200/2);
            Calculated_Track_Velocity_Polar_Heading = Convert.ToString(GetIntFromBitArray(Bits_Aircraft_Track_Velocity, 1, 16) * 360 * Math.Pow(2, -16));
        }


        /// <summary>
        /// Height Measured by 3D Radar,I048/110
        /// </summary>
        /// <param name="Height_Measured_Bytes"></param>
        public void Set_Height_Measured(byte[] Height_Measured_Bytes)
        {
            BitArray Bits_Height_Measured = ChangeFormat(Height_Measured_Bytes);//new BitArray(Height_Measured_Bytes);
            double value = GetIntFromBitArray(Bits_Height_Measured, 1, 14) * 25;
            Height_Measured_by_3D_Radar = Convert.ToString(value);

        }


        /// <summary>
        /// Radar Plot Characteristics,I048/130
        /// </summary>
        /// <param name="Radar_Plot_Characteristics_"></param>
        public void Set_Radar_Plot_Characteristics(byte[] Radar_Plot_Characteristics_)
        {

            BitArray Bits_Radar = ChangeFormat(Radar_Plot_Characteristics_); //new BitArray(Radar_Plot_Characteristics_);
            Reverse(Bits_Radar);

            double SRl_value;
            double SRR_Value;
            int messagecount = 1;
            int message_type = 8;
            int Superior_RAnge;
            int Inferior_Range;
            for (int i = Bits_Radar.Length; i > Bits_Radar.Length - 7; i--)
            {

                bool Estado_Subfield = Bits_Radar[i - 1];
                if (Estado_Subfield)
                {


                    // Obtenemos los limites superiores e inferiores del octeto correspondiente (Varia segun van avanzando los mesnajes)
                    Superior_RAnge = Bits_Radar.Length - 8 * messagecount;
                    Inferior_Range = 1 + (Bits_Radar.Length - 8 * (messagecount + 1));

                    // Si es SRL
                    if (message_type == 8)
                    {
                        SRl_value = GetIntFromBitArray(Bits_Radar, Inferior_Range, Superior_RAnge) * 2 * 360 / Math.Pow(2, 14);
                        SRL = Convert.ToString(SRl_value);
                    }
                    // Si es SSR
                    if (message_type == 7)
                    {
                        SRR_Value = GetIntFromBitArray(Bits_Radar, Inferior_Range, Superior_RAnge);
                        SSR = Convert.ToString(SRR_Value);
                    }

                    //Si es SAM
                    if (message_type == 6)
                    {
                        BitArray SAM_Array = new BitArray(new byte[] { Radar_Plot_Characteristics_[3] });
                        Reverse(SAM_Array);
                        int amplitudeValue = BitArrayToDecimalTwosComplement(SAM_Array);
                        SAM = Convert.ToString(amplitudeValue);



                    }
                    // Si es PRL
                    if (message_type == 5)
                    {
                        double PRL_Value = GetIntFromBitArray(Bits_Radar, Inferior_Range, Superior_RAnge) * 360 / Math.Pow(2, 13);
                        PRL = Convert.ToString(PRL_Value);
                    }
                    // Si es PAM
                    if (message_type == 4)
                    {
                        // Check the sign bit (bit 8)
                        bool isNegative = Bits_Radar[Superior_RAnge - 1] == true;

                        // Initialize the amplitude value to 0
                        int amplitudeValue = 0;

                        // Convert the remaining bits (bit 7 to bit 1) to decimal
                        for (int l = Superior_RAnge - 1; l >= Inferior_Range - 1; l--)
                        {
                            amplitudeValue <<= 1;
                            if (Bits_Radar[l] == true)
                            {
                                amplitudeValue |= 1;
                            }
                        }

                        // If it's negative, apply two's complement
                        if (isNegative)
                        {
                            amplitudeValue = -((1 << 7) - amplitudeValue);
                        }
                        PAM = Convert.ToString(amplitudeValue);
                    }
                    // Si es RPD
                    if (message_type == 3)
                    {
                        // Check the sign bit (bit 8)
                        bool isNegative = Bits_Radar[Superior_RAnge - 1] == true;

                        // Initialize the range difference value to 0
                        double rangeDifference = 0;

                        // Convert the remaining bits (bit 7 to bit 1) to decimal
                        for (int l = Superior_RAnge - 1; l >= Inferior_Range - 1; l--)
                        {
                            rangeDifference *= 2.0; // Multiply by 2 to simulate the << 1 operation
                            if (Bits_Radar[l] == true)
                            {
                                rangeDifference += 1;
                            }
                        }

                        // If it's negative, apply two's complement
                        if (isNegative)
                        {
                            rangeDifference = -((1 << 7) - rangeDifference);
                        }

                        // Convert to the actual range difference (with LSB)
                        double lsb = 1.0 / 256.0;


                        double RDP = rangeDifference * lsb;

                        RPD = Convert.ToString(RDP);

                    }

                    // Si es APD
                    if (message_type == 2)
                    {
                        // Check the sign bit (bit 8)
                        bool isNegative = Bits_Radar[Superior_RAnge - 1] == true;

                        // Initialize the azimuth difference value to 0
                        double azimuthDifference = 0;

                        // Convert the remaining bits (bit 7 to bit 1) to decimal
                        for (int l = 6; l >= 0; l--)
                        {
                            azimuthDifference *= 2.0; // Multiply by 2 to simulate the << 1 operation
                            if (Bits_Radar[l] == true)
                            {
                                azimuthDifference += 1;
                            }
                        }

                        // If it's negative, apply two's complement
                        if (isNegative)
                        {
                            azimuthDifference = -((1 << 7) - azimuthDifference);
                        }

                        // Convert to the actual azimuth difference (with LSB)
                        double lsb = 360.0 / Math.Pow(2, 14);
                        double APD_value = azimuthDifference * lsb;

                        APD = Convert.ToString(APD_value);
                    }



                    message_type -= 1;
                    messagecount += 1;
                }
                //If the subfield is not avaiable It is added in the list as N/A
                else
                {

                    if (message_type == 8)
                        SRL = "N/A";
                    if (message_type == 7)
                    {
                        SSR = "N/A";
                    }
                    if (message_type == 6)
                    {
                        SAM = "N/A";
                    }

                    if (message_type == 5)
                    {
                        PRL = "N/A";
                    }

                    if (message_type == 4)
                    {
                        PAM = "N/A";
                    }

                    if (message_type == 3)
                    {
                        RPD = "N/A";
                    }

                    if (message_type == 2)
                    {
                        APD = "N/A";
                    }


                    message_type -= 1;
                }






            }

        }








        /// <summary>
        /// BDS DATA REGISTER, Mode S MB Data. I048/250
        /// </summary>
        /// <param name="BDSRegisterData"></param>
        public void SetBDSRegisterData(byte[] BDSRegisterData)
        {

            int Message_Number = GetRepetitionNumber(BDSRegisterData);
            bool FourUsed = false;
            bool FiveUsed = false;
            bool SixUsed = false;
            string Messages_types = "";

            for (int i = 1; i <= Message_Number; i++)
            {
                string BDSAddress = GetBDSAddress(BDSRegisterData, i - 1);
                Messages_types = Messages_types + " " + BDSAddress;
                byte[] SelectedRange = GetSelectedRange(BDSRegisterData, i - 1);
                BitArray BDSDataOctets = ChangeFormat(SelectedRange);//new BitArray(SelectedRange);
                Reverse(BDSDataOctets);

                if (BDSAddress == "4,0")
                {
                    HandleMessageType4(BDSDataOctets);
                    FourUsed = true;
                }
                else if (BDSAddress == "5,0")
                {
                    HandleMessageType5(BDSDataOctets);
                    FiveUsed = true;
                }
                else if (BDSAddress == "6,0")
                {
                    HandleMessageType6(BDSDataOctets);
                    SixUsed = true;
                }
            }
            BDS_Number = Messages_types;
            FillMissingValues(FourUsed, FiveUsed, SixUsed);
        }

        private void FillMissingValues(bool FourUsed, bool FiveUsed, bool SixUsed)
        {
            if (!FourUsed)
            {
                // Fill in N/A values for type 4
                Selected_Alt = "N/A";
                Selected_Alt_FMS = "N/A";
                Barometric_Pressure = "N/A";
                VNAV_Mode = "N/A";
                Status_MCP_FCU_Bits = "N/A";
                ALT_HOLD_MODE = "N/A";
                APPROACH_MODE = "N/A";
                Status_Target_Alt_Bits = "N/A";
                Target_Alt_Source = "N/A";
            }
            if (!FiveUsed)
            {
                // Fill in N/A values for type 5
                Status = "N/A";
                Left_Wing = "N/A";
                Roll_Angle_Value = "N/A";
                True_Track_Angle = "N/A";
                Ground_Speed = "N/A";
                Track_Angle_Rate = "N/A";
                True_Airspeed = "N/A";
            }
            if (!SixUsed)
            {
                // Fill in N/A values for type 6
                Magnetic_Heading = "N/A";
                Indicated_AS = "N/A";
                MACH = "N/A";
                Barometric_Altitude_Rate = "N/A";
                Inertial_Vertical_Velocity = "N/A";
            }



        }

        private void HandleMessageType4(BitArray BDS_Data_Octets)
        {
            // Handle type 4 messages
            Selected_Alt = Convert.ToString(GetIntFromBitArray(BDS_Data_Octets, 44, 55) * 16);
            Selected_Alt_FMS = Convert.ToString(GetIntFromBitArray(BDS_Data_Octets, 31, 42) * 16);
            Barometric_Pressure = Convert.ToString((GetIntFromBitArray(BDS_Data_Octets, 18, 29) * 0.1) + 800);

            if (BDS_Data_Octets[8])
                Status_MCP_FCU_Bits = "Mode information deliberately provided";
            else
                Status_MCP_FCU_Bits = " No mode information provided";


            if (BDS_Data_Octets[7])
                VNAV_Mode = "Active";
            else
                VNAV_Mode = "Not Active";

            if (BDS_Data_Octets[6])
                ALT_HOLD_MODE = "Active";
            else
                ALT_HOLD_MODE = "Not Active";

            if (BDS_Data_Octets[5])
                APPROACH_MODE = "Active";
            else
                APPROACH_MODE = "Not Active";


            if (BDS_Data_Octets[2])
                Status_Target_Alt_Bits = "Source information deliberately provided";
            else
                Status_Target_Alt_Bits = "No source information provided";



            //TARGET ALT SOURCE
            if (BDS_Data_Octets[1] && BDS_Data_Octets[0])
                Target_Alt_Source = "FMS selected altitude";

            if (BDS_Data_Octets[1] && BDS_Data_Octets[0] == false)
                Target_Alt_Source = "FCU/MCP selected altitude";

            if (BDS_Data_Octets[1] == false && BDS_Data_Octets[0])
                Target_Alt_Source = "Aircraft altitude";

            if (BDS_Data_Octets[1] == false && BDS_Data_Octets[0] == false)
                Target_Alt_Source = "Unknown";
        }

        private void HandleMessageType5(BitArray BDS_Data_Octets)
        {
            // Handle type 5 messages
            // STATUS
            if (BDS_Data_Octets[55])
            {
                Status = "Latitude,Longitud and FOM are Valid";
            }
            else
                Status = "Latitude,Longitud and FOM are NOT Valid";

            // LEFT WING
            if (BDS_Data_Octets[54])
            {
                Left_Wing = "Left Wing Down";
            }
            else
                Left_Wing = "Left Wing UP";
            // ROll Angle

            //bool[] Roll_Angle_Data = {BDS_Data_Octets[53], BDS_Data_Octets[52], BDS_Data_Octets[51], BDS_Data_Octets[50], BDS_Data_Octets[49], BDS_Data_Octets[48], BDS_Data_Octets[47], BDS_Data_Octets[46], BDS_Data_Octets[45] };// Lo ordenamos donde el MSB esta mas a la derecha

            BitArray arrais = SelectRangeFromBitArray(BDS_Data_Octets, 45, 53);

            // source,source-index,dest,dest-index,count
            Reverse(arrais);
            int decimalValue = BitArrayToDecimalTwosComplement(arrais);
            double Roll_Angle_Value_int = decimalValue * 45.0 / 256;
            Roll_Angle_Value = Convert.ToString(Roll_Angle_Value_int);

            // TRUE TRACK ANGLE
            bool[] True_Track_Data = { BDS_Data_Octets[43], BDS_Data_Octets[42], BDS_Data_Octets[41], BDS_Data_Octets[40], BDS_Data_Octets[39], BDS_Data_Octets[38], BDS_Data_Octets[37], BDS_Data_Octets[36], BDS_Data_Octets[35], BDS_Data_Octets[34] };// Lo ordenamos donde el MSB esta mas a la derecha
            BitArray bitArray_True_Track_Data = SelectRangeFromBitArray(BDS_Data_Octets, 33, 43);
            Reverse(bitArray_True_Track_Data);
            double Valor_Decimal = BitArrayToDecimalTwosComplement(bitArray_True_Track_Data) * 90.0 / 512;

            True_Track_Angle = Convert.ToString(Valor_Decimal);

            //GROUND SPEED de la posicion  32 a 24
            BitArray GS = SelectRangeFromBitArray(BDS_Data_Octets, 22, 31);
            double valor_GS = GetIntFromBitArray(GS, 1, 10) * 1024.0 / 512;
            Ground_Speed = Convert.ToString(valor_GS);

            //TRACK ANGLE RATE

            bool[] Track_Angle_Data = { BDS_Data_Octets[22], BDS_Data_Octets[21], BDS_Data_Octets[20], BDS_Data_Octets[19], BDS_Data_Octets[18], BDS_Data_Octets[17], BDS_Data_Octets[16], BDS_Data_Octets[15], BDS_Data_Octets[14], BDS_Data_Octets[13] };// Lo ordenamos donde el MSB esta mas a la derecha
            BitArray bitArray_Track_Angle_Data = SelectRangeFromBitArray(BDS_Data_Octets, 12, 22);
            //Reverse(bitArray_Track_Angle_Data);
            double Valor = BitArrayToDecimalTwosComplement(bitArray_Track_Angle_Data) * 8.0 / 256;
            Track_Angle_Rate = Convert.ToString(Valor);

            //TRUE AIRSPEED
            int valor_AS = GetIntFromBitArray(BDS_Data_Octets, 1, 10) * 2;
            True_Airspeed = Convert.ToString(valor_AS);

        }

        private void HandleMessageType6(BitArray BDS_Data_Octets)
        {
            // Handle type 6 messages
            // MAGNETIC HEADING 54-45
            bool[] Magnetic_Heading_Data = { BDS_Data_Octets[54], BDS_Data_Octets[53], BDS_Data_Octets[52], BDS_Data_Octets[51], BDS_Data_Octets[50], BDS_Data_Octets[49], BDS_Data_Octets[48], BDS_Data_Octets[47], BDS_Data_Octets[46], BDS_Data_Octets[45] };// Lo ordenamos donde el MSB esta mas a la derecha
            BitArray bitArray = SelectRangeFromBitArray(BDS_Data_Octets, 44, 54);
            Reverse(bitArray);
            int decimalValue = BitArrayToDecimalTwosComplement(bitArray);
            double Magnetic_Heading_int = decimalValue * 90.0 / 512;
            Magnetic_Heading = Convert.ToString(Magnetic_Heading_int);



            // IAS 44-35
            bool[] IAS_data = { BDS_Data_Octets[44], BDS_Data_Octets[43], BDS_Data_Octets[42], BDS_Data_Octets[41], BDS_Data_Octets[40], BDS_Data_Octets[39], BDS_Data_Octets[38], BDS_Data_Octets[37], BDS_Data_Octets[36], BDS_Data_Octets[35] };// Lo ordenamos donde el MSB esta mas a la derecha
            BitArray DData = SelectRangeFromBitArray(BDS_Data_Octets, 33, 42);

            int IAS_Value = GetIntFromBitArray(DData, 1, 10);
            Indicated_AS = Convert.ToString(IAS_Value);

            // MACH posicion 32-25
            bitArray = SelectRangeFromBitArray(BDS_Data_Octets, 22, 31);
            double MACH_Value = GetIntFromBitArray(bitArray, 1, 9) * 2.048 / 512;
            MACH = Convert.ToString(MACH_Value);

            // Barometric Altitude Rate 23-14
            bool[] Barometric_Altitude_Data = { BDS_Data_Octets[20], BDS_Data_Octets[19], BDS_Data_Octets[18], BDS_Data_Octets[17], BDS_Data_Octets[16], BDS_Data_Octets[15], BDS_Data_Octets[14], BDS_Data_Octets[13], BDS_Data_Octets[12], BDS_Data_Octets[11] };// Lo ordenamos donde el MSB esta mas a la derecha
            bitArray = SelectRangeFromBitArray(BDS_Data_Octets, 11, 20);
            Reverse(bitArray);
            decimalValue = BitArrayToDecimalTwosComplement(bitArray);

            int Barometric_Altitude_Data_int = decimalValue * 8192 / 256;
            Barometric_Altitude_Rate = Convert.ToString(Barometric_Altitude_Data_int);

            //INERTIAL VERTICAL VELOCITY

            bool[] Inertial_Vertical_Velocity_data = { BDS_Data_Octets[9], BDS_Data_Octets[8], BDS_Data_Octets[7], BDS_Data_Octets[6], BDS_Data_Octets[5], BDS_Data_Octets[4], BDS_Data_Octets[3], BDS_Data_Octets[2], BDS_Data_Octets[1], BDS_Data_Octets[0] };// Lo ordenamos donde el MSB esta mas a la derecha
            bitArray = SelectRangeFromBitArray(BDS_Data_Octets, 0, 9);
            Reverse(bitArray);
            decimalValue = BitArrayToDecimalTwosComplement(bitArray);
            int Inertial_Vertical_Velocity_data_int = decimalValue * 8192 / 256;
            Inertial_Vertical_Velocity = Convert.ToString(Inertial_Vertical_Velocity_data_int);
        }

        private string GetBDSAddress(byte[] BDS_Register_Data, int index)
        {

            // Implement logic to extract BDS address
            BitArray BDS_Address_Octet = new BitArray(new byte[] { BDS_Register_Data[(index * 8) + 8] });


            int BDS1 = GetIntFromBitArray(BDS_Address_Octet, 5, 8);
            int BDS2 = GetIntFromBitArray(BDS_Address_Octet, 1, 4);
            string BDS_Address = Convert.ToString(BDS1) + "," + Convert.ToString(BDS2);

            return BDS_Address;
        }

        private byte[] GetSelectedRange(byte[] BDS_Register_Data, int i)
        {
            // Implement logic to extract selected range
            byte[] Selected_Range = new byte[7];
            /// Hay que tener mucho cuidado con los indices de + 7 +6 etc , los he cambiado y puede que vayan mal
            Selected_Range[0] = BDS_Register_Data[(i * 8) + 1];
            Selected_Range[1] = BDS_Register_Data[(i * 8) + 2];
            Selected_Range[2] = BDS_Register_Data[(i * 8) + 3];
            Selected_Range[3] = BDS_Register_Data[(i * 8) + 4];
            Selected_Range[4] = BDS_Register_Data[(i * 8) + 5];
            Selected_Range[5] = BDS_Register_Data[(i * 8) + 6];
            Selected_Range[6] = BDS_Register_Data[(i * 8) + 7];

            return Selected_Range;
        }

        private int GetRepetitionNumber(byte[] BDS_Register_Data)
        {
            int Message_Number = (BDS_Register_Data.Length - 1) / 8;

            return Message_Number;


        }




        static int GetIntFromBitArray(BitArray bitArray, int bit_start, int bit_end)
        {
            int value = 0;
            int n = 0;
            for (int i = bit_start - 1; i < bit_end; i++)
            {
                if (bitArray[i])
                    value += Convert.ToInt32(Math.Pow(2, n));
                n++;
            }


            return value;
        }

        static int BitArrayToDecimalTwosComplement(BitArray bitArray)
        {
            int decimalValue = 0;
            int sign = bitArray[0] ? -1 : 1;
            int bitValue = 1;
            int invertedValue = 0;

            for (int i = bitArray.Length - 1; i >= 1; i--)
            {
                invertedValue += bitArray[i] ? 0 : bitValue;
                decimalValue += bitArray[i] ? bitValue : 0;
                bitValue <<= 1;
            }

            if (sign == -1)
            {
                decimalValue = -(invertedValue + 1);
            }

            return decimalValue;
        }

        public void Set_NA_DataSource()
        {
            Data_Source_Identifier_SAC = "N/A";
            Data_Source_Identifier_SIC = "N/A";
        }


        public void Set_NA_TimeofDay()
        {
            Time_of_Day = "N/A";

        }

        public void Set_NA_TargetReport()
        {
            Time_of_Day = "N/A";
            Target_Report_Descriptor_ADSBEP = "N/A";
            Target_Report_Descriptor_ADSBVAL = "N/A";
            Target_Report_Descriptor_ERR = "N/A";
            Target_Report_Descriptor_FOEFRI = "N/A";
            Target_Report_Descriptor_FX = "N/A";
            Target_Report_Descriptor_FX2 = "N/A";
            Target_Report_Descriptor_FX3 = "N/A";
            Target_Report_Descriptor_ME = "N/A";
            Target_Report_Descriptor_MI = "N/A";
            Target_Report_Descriptor_PAIEP = "N/A";
            Target_Report_Descriptor_PAIVAL = "N/A";
            Target_Report_Descriptor_RAB = "N/A";
            Target_Report_Descriptor_RDP = "N/A";
            Target_Report_Descriptor_SCNEP = "N/A";
            Target_Report_Descriptor_SCNVAL = "N/A";
            Target_Report_Descriptor_SIM = "N/A";
            Target_Report_Descriptor_SPI = "N/A";
            Target_Report_Descriptor_TST = "N/A";
            Target_Report_Descriptor_TYP = "N/A";
            Target_Report_Descriptor_XPP = "N/A";




        }

        public void Set_NA_MeasuredPosition()
        {
            Measured_Position_in_Polar_Coordinates_RHO = "N/A";
            Measured_Position_in_Polar_Coordinates_THETA = "N/A";
        }

        public void Set_NA_Mode3A()
        {
            Mode_3A_G = "N/A";
            Mode_3A_L = "N/A";
            Mode_3A_Reply = "N/A";
            Mode_3A_V = "N/A";
        }

        public void Set_NA_FL()
        {
            Flight_Level_Garbed = "N/A";
            Flight_Level_Validation = "N/A";
            Flight_Level_Value = "N/A";
        }

        public void Set_NA_RadarPlot()
        {
            SRL = "N/A";
            SSR = "N/A";
            SAM = "N/A";
            PRL = "N/A";
            PAM = "N/A";
            RPD = "N/A";
            APD = "N/A";
        }

        public void Set_NA_AircraftAddress()
        {
            Aircraft_Address = "N/A";
        }

        public void Set_NA_AircraftID()
        {
            Aircraft_ID = "N/A";
        }

        public void Set_NA_BDSRegisterData()
        {
            Selected_Alt = "N/A";
            Selected_Alt_FMS = "N/A";
            Barometric_Pressure = "N/A";
            VNAV_Mode = "N/A";
            Status_MCP_FCU_Bits = "N/A";
            ALT_HOLD_MODE = "N/A";
            APPROACH_MODE = "N/A";
            Status_Target_Alt_Bits = "N/A";
            Target_Alt_Source = "N/A";
            Status = "N/A";
            Left_Wing = "N/A";
            Roll_Angle_Value = "N/A";
            True_Track_Angle = "N/A";
            Ground_Speed = "N/A";
            Track_Angle_Rate = "N/A";
            True_Airspeed = "N/A";
            Magnetic_Heading = "N/A";
            Indicated_AS = "N/A";
            MACH = "N/A";
            Barometric_Altitude_Rate = "N/A";
            Inertial_Vertical_Velocity = "N/A";
            BDS_Number = "N/A";
        }

        public void Set_NA_Track_Number()
        {
            Track_Number = "N/A";
        }

        public void Set_NA_CalculatedPosition()
        {
            Calculated_Position_Cartesian_X = "N/A";
            Calculated_Position_Cartesian_Y = "N/A";
        }

        public void Set_NA_TrackVelocity()
        {
            Calculated_Track_Velocity_Polar_GroundSpeed = "N/A";
            Calculated_Track_Velocity_Polar_Heading = "N/A";
        }

        public void Set_NA_TrackStatus()
        {
            RAD = "N/A";
            DOU = "N/A";
            MAH = "N/A";
            CDM = "N/A";
            FX = "N/A";
            TRE = "N/A";
            GHO = "N/A";
            SUP = "N/A";
            TCC = "N/A";
            FX2 = "N/A";
        }

        public void Set_NA_Height_Measured()
        {
            Height_Measured_by_3D_Radar = "N/A";
        }

        public void Set_NA_Communications_ACAS_Capability()
        {
            ACAS_Capability_AIC = "N/A";
            ACAS_Capability_ARC = "N/A";
            ACAS_Capability_B1A = "N/A";
            ACAS_Capability_B1B_37 = "N/A";
            ACAS_Capability_B1B_38 = "N/A";
            ACAS_Capability_B1B_3940 = "N/A";
            ACAS_Capability_COM = "N/A";
            ACAS_Capability_MSSC = "N/A";
            ACAS_Capability_SI = "N/A";
            ACAS_Capability_STAT = "N/A";
        }


        public void Set_Message_Values(List<List<byte[]>> DifferentMessagesDivided, List<BitArray> FspecList)
        {
            int MessagesLen = 0;

            foreach (BitArray fspec in FspecList)
            {
                int CounterForMessage = 0;
                List<byte[]> CurrentMessage = DifferentMessagesDivided[MessagesLen];
                if (fspec[0])
                {
                    Set_Data_Source_Identifier(CurrentMessage[CounterForMessage]);
                    CounterForMessage += 1;
                }
                else { Set_NA_DataSource(); }


                if (fspec[1])
                {
                    Set_Time_of_Day(CurrentMessage[CounterForMessage]);
                    CounterForMessage += 1;
                }
                else { Set_NA_TimeofDay(); }

                if (fspec[2])
                {
                    Set_Target_Report_Descriptor(CurrentMessage[CounterForMessage]);
                    CounterForMessage += 1;
                }
                else { Set_NA_TargetReport(); }


                if (fspec[3])
                {
                    Set_Measured_Position_in_Polar_Coordinates(CurrentMessage[CounterForMessage]);
                    CounterForMessage += 1;
                }
                else Set_NA_MeasuredPosition();


                if (fspec[4])
                {
                    Set_Aircraft_Mode_3A(CurrentMessage[CounterForMessage]);
                    CounterForMessage += 1;
                }
                else Set_NA_Mode3A();
                if (fspec[5])
                {
                    Set_Flight_Level(CurrentMessage[CounterForMessage]);
                    CounterForMessage += 1;
                }
                else Set_NA_FL();
                if (fspec[6])
                {
                    Set_Radar_Plot_Characteristics(CurrentMessage[CounterForMessage]);
                    CounterForMessage += 1;

                }
                else Set_NA_RadarPlot();


                if (fspec.Length > 8)
                {
                    if (fspec[8])
                    {
                        Set_Aircraft_Address(CurrentMessage[CounterForMessage]);
                        CounterForMessage += 1;
                    }
                    else Set_NA_AircraftAddress();
                    if (fspec[9])
                    {
                        Set_Aircraft_ID(CurrentMessage[CounterForMessage]);
                        CounterForMessage += 1;

                    }
                    else Set_NA_AircraftID();
                    if (fspec[10])
                    {
                        SetBDSRegisterData(CurrentMessage[CounterForMessage]);
                        CounterForMessage += 1;
                    }
                    else Set_NA_BDSRegisterData();
                    if (fspec[11])
                    {
                        Set_Track_Number(CurrentMessage[CounterForMessage]);
                        CounterForMessage += 1;
                    }
                    else Set_NA_Track_Number();
                    if (fspec[12])
                    {
                        Set_Calculated_Position_Cartesian(CurrentMessage[CounterForMessage]);
                        CounterForMessage += 1;
                    }
                    else Set_NA_CalculatedPosition();
                    if (fspec[13])
                    {
                        Set_Aircraft_Track_Velocity(CurrentMessage[CounterForMessage]);
                        CounterForMessage += 1;
                    }
                    else Set_NA_TrackVelocity();
                    if (fspec[14])
                    {
                        Set_Track_Status(CurrentMessage[CounterForMessage]);
                        CounterForMessage += 1;

                    }
                    else Set_NA_TrackStatus();

                    if (fspec.Length > 16)
                    {
                        if (fspec[20])
                        {
                            Set_Height_Measured(CurrentMessage[CounterForMessage]);
                            CounterForMessage += 1;
                        }
                        else Set_NA_Height_Measured();
                        if (fspec[22])
                        {
                            Set_Communications_ACAS_Capability(CurrentMessage[CounterForMessage]);
                            CounterForMessage += 1;
                        }
                        else Set_NA_Communications_ACAS_Capability();
                    }
                    else
                    {
                        Set_NA_Height_Measured();
                        Set_NA_Communications_ACAS_Capability();
                    }

                }
                else
                {
                    Set_NA_AircraftAddress();
                    Set_NA_BDSRegisterData();
                    Set_NA_CalculatedPosition();
                    Set_NA_AircraftID();
                    Set_NA_Track_Number();
                    Set_NA_TrackVelocity();
                    Set_NA_TrackStatus();

                }
                double h = Convert.ToDouble(Flight_Level_Value);
                if (h < 60)
                {
                    if (Barometric_Pressure != "N/A")
                    {
                        double Altitud_real = h + (Convert.ToDouble(Barometric_Pressure) - 1013.25) * 30;
                        Corrected_FL = Convert.ToString(Altitud_real);
                    }
                    else
                    {
                        Corrected_FL = "N/A";
                    }
                }


                MessagesLen += 1;
            }
        }

        /// <summary>
        /// Puts 2 BitArrays together in a 1 dimentional array
        /// </summary>
        /// <param name="first">BitArray that goes first</param>
        /// <param name="second">BitArray that goes behind the first one</param>
        /// <returns></returns>

        static BitArray ConcatenateBitArrays(BitArray first, BitArray second)
        {
            int length = first.Length + second.Length;
            BitArray result = new BitArray(length);

            for (int i = 0; i < first.Length; i++)
            {
                result[i] = first[i];
            }

            for (int i = 0; i < second.Length; i++)
            {
                result[i + first.Length] = second[i];
            }

            return result;
        }


        /// <summary>
        /// Reverses the input Bitarray
        /// </summary>
        /// <param name="array"></param>
        static void Reverse(BitArray array)
        {
            int length = array.Length;
            int mid = (length / 2);

            for (int i = 0; i < mid; i++)
            {
                bool bit = array[i];
                array[i] = array[length - i - 1];
                array[length - i - 1] = bit;
            }
        }

        public int GetLenghtofMessages()
        {
            int lenghtofMessages = Data_Source_Identifier_SAC.Count();
            return lenghtofMessages;
        }
        static BitArray ChangeFormat(byte[] data)
        {

            BitArray AllBits = new BitArray(new byte[] { data[0] });
            Reverse(AllBits);
            int j = 1;
            while (j < data.Length)
            {
                BitArray SavedBitarray = new BitArray(new byte[] { data[j] });
                Reverse(SavedBitarray);
                AllBits = ConcatenateBitArrays(AllBits, SavedBitarray);
                j++;
            }
            return AllBits;
        }

        public BitArray SelectRangeFromBitArray(BitArray array, int inicio, int final)
        {
            // Define the range you want to copy
            int startIndex = inicio;
            int endIndex = final;

            // Calculate the length of the range
            int length = endIndex - startIndex + 1;

            // Create a fresh BitArray to store the selected range
            BitArray selectedBitArray = new BitArray(length);

            // Copy the range from the original BitArray to the selected BitArray
            for (int i = 0; i < length; i++)
            {
                selectedBitArray[i] = array[startIndex + i];
            }
            return selectedBitArray;
        }

        public void Transformacion_Coordenadas()
        {
            GeoUtils GeoUtils = new GeoUtils();
            double Height_m;
            double height_radar_tang = 3438.954;
            double Lat_deg_tang = 41.065656 * GeoUtils.DEGS2RADS;
            double Lon_deg_tang = 1.413301 * GeoUtils.DEGS2RADS;
            CoordinatesWGS84 system_center_tang = new CoordinatesWGS84(Lat_deg_tang, Lon_deg_tang, height_radar_tang);
            GeoUtils.setCenterProjection(system_center_tang);
            if (Flight_Level_Value != "N/A")
            {
                if (Corrected_FL != "")
                {
                    Height_m = Convert.ToDouble(Corrected_FL) * 0.3048;
                }
                else Height_m = Convert.ToDouble(Flight_Level_Value) * 100 * 0.3048;

            }
            else
            {
                Height_m = 0;

            }
            CoordinatesWGS84 RadarCoordinates = new CoordinatesWGS84((0.720833), (0.036688));
            double RHO_m = Convert.ToDouble(this.Measured_Position_in_Polar_Coordinates_RHO) * 1852;
            double Radius_WGS84 = 6371000;
            double Radar_Height = 25.25;

            double Elevation_radians = Math.Asin((2 * Radius_WGS84 * (Height_m - Radar_Height) + Math.Pow(Height_m, 2) - Math.Pow(Radar_Height, 2) - Math.Pow(RHO_m, 2)) / (2 * RHO_m * (Radius_WGS84 + Radar_Height)));
            double THETA_Radians = Convert.ToDouble(Measured_Position_in_Polar_Coordinates_THETA) * (Math.PI / 180);
            CoordinatesPolar Radar_Spherical_Coordinates = new CoordinatesPolar(RHO_m, THETA_Radians, Elevation_radians);
            CoordinatesXYZ Radar_Cartesian_Coordinates = GeoUtils.change_radar_spherical2radar_cartesian(Radar_Spherical_Coordinates);

            CoordinatesXYZ Geocentric_Coordinates = GeoUtils.change_radar_cartesian2geocentric(RadarCoordinates, Radar_Cartesian_Coordinates);

            CoordinatesXYZ System_Cartesian_Coordinates = GeoUtils.change_geocentric2system_cartesian(Geocentric_Coordinates);
            CoordinatesUVH System_Stereographic = GeoUtils.change_system_cartesian2stereographic(System_Cartesian_Coordinates);
            CoordinatesWGS84 WGS84_Coordinates = GeoUtils.change_geocentric2geodesic(Geocentric_Coordinates);
            this.Latitud = Convert.ToString(WGS84_Coordinates.Lat * 180 / Math.PI);
            this.Longitud = Convert.ToString(WGS84_Coordinates.Lon * 180 / Math.PI);
            this.Height = Convert.ToString(WGS84_Coordinates.Height);

            this.U = Convert.ToString(GeoUtils.METERS2NM * System_Stereographic.U);
            this.V = Convert.ToString(GeoUtils.METERS2NM * System_Stereographic.V);
            this.H = Convert.ToString(GeoUtils.METERS2NM * System_Stereographic.Height);

        }

    }
}




