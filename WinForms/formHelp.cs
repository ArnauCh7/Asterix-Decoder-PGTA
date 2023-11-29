using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms
{
    public partial class formHelp : Form
    {
        public formHelp()
        {
            InitializeComponent();
            InitializeComponent();
            
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void formHelp_Load(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            
            richTextBox1.AppendText("**Help**\n\n");

            richTextBox1.AppendText("**Navigation:**\n");
            richTextBox1.AppendText("- To expand the column displaying button names, click on the top button labeled \"Help.\"\n\n");

            richTextBox1.AppendText("**Import File:**\n");
            richTextBox1.AppendText("1. Click on \"Import File\" to access the Asterix file decoding section.\n");
            richTextBox1.AppendText("2. In the Import section, click \"Import\" to upload the Asterix file you want to decode.\n\n");

            richTextBox1.AppendText("**Display Section:**\n");
            richTextBox1.AppendText("1. Navigate to the \"Display\" section.\n");
            richTextBox1.AppendText("2. Click \"Load Grid\" to display the table of decoded data.\n");
            richTextBox1.AppendText("3. Filter data by ID track number or time interval for a more focused view.\n");
            richTextBox1.AppendText("4. Export decoded data to a CSV file by clicking \"Export CSV.\"\n\n");

            richTextBox1.AppendText("**Simulation Section:**\n");
            richTextBox1.AppendText("1. Move to the \"Simulation\" section.\n");
            richTextBox1.AppendText("2. Play or stop the simulation using the designated buttons.\n");
            richTextBox1.AppendText("3. Restart the simulation at any point.\n");
            richTextBox1.AppendText("4. Adjust the simulation speed with the \"+\" and \"-\" buttons in the right-bottom corner.\n\n");

            richTextBox1.AppendText("**Export Trajectories to KML:**\n");
            richTextBox1.AppendText("- To see the full trajectories of aircraft, click \"Download to KML\" in the bottom center.\n");
            richTextBox1.AppendText("- Select a name and directory to download the KML file.\n");
            richTextBox1.AppendText("- Open the KML file in Google Earth for a visual representation of the aircraft trajectories.\n\n");

            richTextBox1.AppendText("*Note: Ensure that you follow the import sequence before exploring the \"Display\" or \"Simulation\" sections for accurate and meaningful results.*");
        }
    }
}
