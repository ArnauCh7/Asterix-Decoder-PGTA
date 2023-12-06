using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project2;
using proyecto;
using CsvHelper;

namespace WinForms
{
    public partial class formDisplay : Form
    {
        public DataTable originalDataTable;
        public DataTable filteredDataTable;
        public static formDisplay displayInstance;

        public formDisplay()
        {
            InitializeComponent();

            displayInstance = this;
        }


        private void formDisplay_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            btnFilterID.Enabled = false;
            btnClear.Enabled = false;
            btnClear.BackColor = Color.White;
            btnFilterID.BackColor = Color.White;
        }

        private void btnLoadGrid_Click(object sender, EventArgs e)
        {
            this.originalDataTable = formImport.importInstance.Datos;
            filteredDataTable = originalDataTable.Copy();
            advancedDataGridView1.DataSource = originalDataTable;
            advancedDataGridView1.EnableHeadersVisualStyles = false;
            advancedDataGridView1.ReadOnly = true;
            advancedDataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.CornflowerBlue;
            btnClear.Enabled = true;
            btnFilterID.Enabled = true;
            btnFilterID.BackColor = Color.CornflowerBlue;
            btnClear.BackColor = Color.CornflowerBlue;

        }

        private void btnFilterID_Click(object sender, EventArgs e)
        {

            // Get the filter text from the TextBoxes
            string filterText1 = searchID.Text;
            string filterText2 = searchSSR.Text;
            string initialTimeText = InitialTime.Text;
            string finalTimeText = FinalTime.Text;

            //Check if the tsxtBox for both time frames are full
            if (!string.IsNullOrWhiteSpace(initialTimeText) && !string.IsNullOrWhiteSpace(finalTimeText))
            {
                // Validate the input times
                if (!IsValidTime(initialTimeText, originalDataTable) || !IsValidTime(finalTimeText, originalDataTable))
                {
                    MessageBox.Show("Invalid time format. Please enter times in a valid format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }


            // Build the filter expression based on non-empty filter texts
            string filterExpression = "";

            if (!string.IsNullOrWhiteSpace(filterText1))
            {
                filterExpression += $"Aircraft_ID LIKE '%{filterText1}%' AND ";
                searchID.ReadOnly = true;
            }

            if (!string.IsNullOrWhiteSpace(filterText2))
            {
                filterExpression += $"Track_Number LIKE '%{filterText2}%' AND ";
                searchSSR.ReadOnly = true;
            }
            // Add the filter condition for the time interval
            if (!string.IsNullOrWhiteSpace(initialTimeText) && !string.IsNullOrWhiteSpace(finalTimeText))
            {
                // Assuming "TimeColumn" is the column name representing time in your DataTable
                filterExpression += $"Time >= '{initialTimeText}' AND Time <= '{finalTimeText}' AND ";
                InitialTime.ReadOnly = true;
                FinalTime.ReadOnly = true;
            }
            // Remove the trailing " AND " if present
            if (filterExpression.EndsWith(" AND "))
            {
                filterExpression = filterExpression.Substring(0, filterExpression.Length - 5);
            }

            // Apply the filter to the DataTable
            DataView dv = filteredDataTable.DefaultView;
            dv.RowFilter = filterExpression;


            // Create a copy of the filtered data
            filteredDataTable = dv.ToTable();

            // Update the DataGridView to reflect the filtered data
            advancedDataGridView1.DataSource = filteredDataTable;
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Restore the original data
            advancedDataGridView1.DataSource = originalDataTable;

            //Restore filtered DataTable
            filteredDataTable = originalDataTable.Copy();

            // Clear the text in the TextBoxes
            searchSSR.Text = "";
            searchID.Text = "";
            InitialTime.Text = "";
            FinalTime.Text = "";
            InitialTime.ReadOnly = false;
            FinalTime.ReadOnly = false;
            searchID.ReadOnly = false;
            searchSSR.ReadOnly = false;
        }

        private bool IsValidTime(string timeText, DataTable dataTable)
        {
            if (timeText.Length == 5)
            {
                timeText = timeText + ":00.000";
            }
            else if (timeText.Length == 8)
            {
                timeText = timeText + ".000";
            }
            else if (timeText.Length == 10)
            {
                timeText = timeText + "00";
            }
            else if (timeText.Length == 11)
            {
                timeText = timeText + "0";
            }
            return DateTime.TryParseExact(timeText, "HH:mm:ss.fff", null, System.Globalization.DateTimeStyles.None, out _);
        }

        private void expCSVbtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
            saveFileDialog.DefaultExt = "csv";
            saveFileDialog.AddExtension = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var csvPath = saveFileDialog.FileName;
                using (var streamWriter = new StreamWriter(csvPath))
                {
                    using (var CsvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
                    {
                        CsvWriter.Context.RegisterClassMap<FlightMap>();
                        CsvWriter.WriteRecords(formImport.importInstance.listaVuelos);
                    }
                }
            }
            else
            {
                MessageBox.Show($"No name or directory selected. Please insert a valid name or location", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
