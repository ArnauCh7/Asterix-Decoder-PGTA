using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET.WindowsForms;
using System.Diagnostics;
using GMap.NET;
using GMap.NET.WindowsForms.Markers;
using Project2;
using System.Globalization;
using System.Web;
using Microsoft.VisualBasic.FileIO;

namespace WinForms
{
    public partial class formSimulation : Form
    {
        //Data variables for simulation source information
        public static formSimulation simulationInstance;
        public DataTable tabla;
        GMap.NET.WindowsForms.GMapControl gmap;
        public List<Aircraft> aircraftList;
        public List<List<string[]>> ListSorted;
        int indexSorted = 0;
        List<List<GMarkerGoogle>> ListSortedMarkers = new List<List<GMarkerGoogle>>();
        GMapOverlay markerOverlay;



        //Time Variables for simulation controllability
        bool started = false; //tells if the simulation is running or not
        int h, m, s; //hours minutes and seconds of the suimulation
        private string startTimeString; //starting hour of the simulation hh:mm:ss
        private string endTimeString; //ending hour of the simulation hh:mm:ss
        int speed;// int to see at what speed is the simulation going
        //private DateTime startTime;
        //private DateTime endTime;
        bool timeSet = false;
        int totalSecondsmax;
        int totalSecondsmin;
        int secondsInterval;



        public formSimulation()
        {
            InitializeComponent();
            simulationInstance = this;
        }

        //System.Diagnostics.Stopwatch Stopwatch = new System.Diagnostics.Stopwatch();
        private void formSimulation_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            // Set up GMapControl properties
            gMapControl1.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            gMapControl1.Position = new GMap.NET.PointLatLng(41.2974, 2.0833); // El Prat Airport, BCN
            gMapControl1.Zoom = 8;

            speed = 1;

            SetTimeInterval();

            this.ListSorted = GroupByTime(tabla);
            // Create a marker overlay
            this.markerOverlay = new GMapOverlay("markers");

        }
        private void picBoxPlayPause_Click(object sender, EventArgs e)
        {
            if (started)
            {
                picBoxPlayPause.Image = Image.FromFile("pictures\\play.png");
                timer.Stop();
                //this.Stopwatch.Stop();
                started = false;
            }
            else
            {
                if (this.timeSet)
                {
                    picBoxPlayPause.Image = Image.FromFile("pictures\\pause.png");
                    timer.Start();
                    //this.Stopwatch.Start();
                    started = true;
                }
            }

        }

        private void timer_Tick(object sender, EventArgs e)
        {

            s++;
            if (s == 60)
            {
                s = 0;
                m += 1;
            }
            if (m == 60)
            {
                m = 0;
                h += 1;
            }
            string labeltext = string.Format("{0}:{1}:{2}", h.ToString().PadLeft(2, '0'), m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'));
            
            timeLabel.Text = labeltext;
            List<GMarkerGoogle> markers2remove = new List<GMarkerGoogle>();
            foreach (string[] second in ListSorted[indexSorted])
            {
                //Take the Lat, Long, Heading and Callsign of the aircraft to diplay the marker on the map
                GMarkerGoogle marker = AddMarkerToMap(Convert.ToDouble(second[0]), Convert.ToDouble(second[1]), second[2], Convert.ToDouble(second[4]), second[5]);
                markers2remove.Add(marker);


            }
            gMapControl1.Refresh();
            ListSortedMarkers.Add(markers2remove);
            //When 4 seconds have passed since the time started we begin to remove the previous aircraft markers
            if (indexSorted >= 4)
            {
                foreach (GMarkerGoogle marker in ListSortedMarkers[indexSorted - 4])
                {
                    markerOverlay.Markers.Remove(marker);
                }
            }
            indexSorted++;
            if (labeltext == endTimeString)
            {
                timer.Stop();
                timeLabel.Text = "End of simulation";

            }

        }

        private void picBoxRestart_Click(object sender, EventArgs e)
        {
            if (this.timeSet)
            {
                timer.Stop();
                //this.Stopwatch.Reset();
                //timeLabel.Text = startTime.ToString(@"hh\:mm\:ss\.fff");

                //Set the hour min and sec variables at start time
                this.h = Convert.ToInt32(startTimeString.Split(':')[0]);
                this.m = Convert.ToInt32(startTimeString.Split(":")[1]);
                this.s = Convert.ToInt32(startTimeString.Split(":")[2]);

                //Set the timerLabel to teh start hour
                timeLabel.Text = startTimeString;

                //Restart the plotlist index
                indexSorted = 0;
                picBoxPlayPause.Image = Image.FromFile("pictures\\play.png");
                started = false;
                // Clear all overlays (and markers) from the GMapControl
                ListSortedMarkers.Clear();
                gMapControl1.Overlays.Clear();
                markerOverlay.Clear();


            }
        }


        /// <summary>
        /// Sets the strings for the startTime and endTime, sets the hour, minute and second variable to the start hour
        /// </summary>
        void SetTimeInterval()
        {
            try
            {
                if (formImport.importInstance != null && formImport.importInstance.Datos != null && formImport.importInstance != null && formImport.importInstance.Aviones != null)
                {
                    this.tabla = formImport.importInstance.Datos;
                    this.aircraftList = formImport.importInstance.Aviones;

                    // Check if the DataTable has rows before computing min and max times
                    if (tabla.Rows.Count > 0)
                    {
                        // Get the minimum and maximum times from the DataTable (assuming TimeColumn is in string format with milliseconds)
                        string minTimeString = (string)tabla.Compute("MIN(Time)", "");
                        string maxTimeString = (string)tabla.Compute("MAX(Time)", "");

                        //Remove the .fff part of the string of time
                        minTimeString = minTimeString.Remove(minTimeString.Length - 4);
                        maxTimeString = maxTimeString.Remove(maxTimeString.Length - 4);

                        // Parse the string times to DateTime format with milliseconds
                        DateTime minTime = DateTime.ParseExact(minTimeString, "HH:mm:ss", null);
                        DateTime maxTime = DateTime.ParseExact(maxTimeString, "HH:mm:ss", null);


                        //Set the hour min and sec variables at start time
                        this.h = Convert.ToInt32(minTimeString.Split(':')[0]);
                        this.m = Convert.ToInt32(minTimeString.Split(":")[1]);
                        this.s = Convert.ToInt32(minTimeString.Split(":")[2]);

                        // Set start and end times
                        this.startTimeString = minTimeString;
                        this.endTimeString = maxTimeString;

                        this.totalSecondsmin = (int)minTime.TimeOfDay.TotalSeconds;
                        this.totalSecondsmax = (int)maxTime.TimeOfDay.TotalSeconds;
                        this.secondsInterval = (totalSecondsmax - totalSecondsmin) + 1;

                        this.timeSet = true;
                    }
                    else
                    {
                        // Handle the case where the DataTable is empty
                        MessageBox.Show("The DataTable is empty. No minimum and maximum times available.");

                        this.timeSet = false;
                    }
                }
                else
                {
                    // Handle the case where the DataTable is empty
                    MessageBox.Show("The DataTable is empty. No minimum and maximum times available.");
                    this.timeSet = false;
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.timeSet = false;
            }


        }

        private GMarkerGoogle AddMarkerToMap(double lat, double lon, string title, double heading, string track)
        {
            Bitmap icon = (Bitmap)System.Drawing.Image.FromFile("pictures\\avion2.png");
            // Create a marker at the specified location
            GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(lat - 0.0005, lon), RotateImage(icon, (float)(heading - 90)));



            // Add the overlay to the map control
            gMapControl1.Overlays.Add(markerOverlay); //thanks to rdoubleui :D

            markerOverlay.Markers.Add(marker);


            // Optionally, add a tooltip to the marker
            marker.ToolTip = new GMap.NET.WindowsForms.ToolTips.GMapRoundedToolTip(marker);
            marker.ToolTipText = $"{title}\n{track}";
            return marker;
        }

        private void increaseSpeedBtn_Click(object sender, EventArgs e)
        {
            if (speed == 1)
            {
                timer.Interval = 500;
                speed = 2;
                speedLabel.Text = "x2";
            }
            else if (speed == 2)
            {
                timer.Interval = 250;
                speed = 3;
                speedLabel.Text = "x4";
            }

        }

        private void decreaseSpeedBtn_Click(object sender, EventArgs e)
        {
            if (speed == 3)
            {
                timer.Interval = 500;
                speed = 2;
                speedLabel.Text = "x2";
            }
            else if (speed == 2)
            {
                timer.Interval = 1000;
                speed = 1;
                speedLabel.Text = "x1";
            }

        }

        static List<List<string[]>> GroupByTime(DataTable dataTable)
        {
            var groupedData = dataTable.AsEnumerable()
                .GroupBy(row =>
                {
                    // Get the "Time" string without milliseconds
                    string timeStringWithoutMilliseconds = row["Time"].ToString().Split('.')[0];
                    // Parse the "Time" string into a DateTime object
                    DateTime time = DateTime.ParseExact(timeStringWithoutMilliseconds, "HH:mm:ss", CultureInfo.InvariantCulture);
                    // Get the total seconds since midnight
                    int totalSeconds = (int)time.TimeOfDay.TotalSeconds;

                    return totalSeconds;
                })
                .Select(group =>
                    group.Select(row => new string[]
                    {
                    row["LATITUDE"].ToString(),
                    row["LONGITUDE"].ToString(),
                    row["Aircraft_ID"].ToString(),
                    row["Time"].ToString(),
                    row["Heading"].ToString(),
                    row["Track_Number"].ToString()
                    }).ToList()
                )
                .ToList();

            return groupedData;
        }
        public static Bitmap RotateImage(Bitmap originalImage, float angle)
        {
            // Create a new empty bitmap to hold the rotated image
            Bitmap rotatedImage = new Bitmap(originalImage.Width, originalImage.Height);

            // Set the resolution of the rotated image to match the original image
            rotatedImage.SetResolution(originalImage.HorizontalResolution, originalImage.VerticalResolution);

            // Create a Graphics object to manipulate the image
            using (Graphics g = Graphics.FromImage(rotatedImage))
            {
                // Set the rotation point at the center of the image
                g.TranslateTransform(originalImage.Width / 2, originalImage.Height / 2);

                // Rotate the image by the specified angle
                g.RotateTransform(angle);

                // Reset the rotation point to the upper-left corner of the image
                g.TranslateTransform(-originalImage.Width / 2, -originalImage.Height / 2);

                // Draw the rotated image onto the new bitmap
                g.DrawImage(originalImage, new Point(0, 0));
            }

            return rotatedImage;
        }


        /// <summary>
        /// Button to download KML file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnKML_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "KML files (*.kml)|*.kml";
            saveFileDialog.DefaultExt = "kml";
            saveFileDialog.AddExtension = true;

            DialogResult result = saveFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                var kmlpath = saveFileDialog.FileName;
                List<Aircraft> Aviones = formImport.importInstance.Aviones;
                KMLExporter.ExportToKML(Aviones, kmlpath);
            }
            else
            {
                MessageBox.Show("Something went wrong :(");
            }
        }
    }
}
