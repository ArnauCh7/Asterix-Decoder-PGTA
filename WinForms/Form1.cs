using System;
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



namespace WinForms
{
    public partial class Form1 : Form
    {
        formDisplay display;
        formImport import;
        formSimulation simulation;
        formHome Home;
        formHelp help;
        P3 p3;
        DataTable dt;
        List<Flight> flights;
        public Form1()
        {
            InitializeComponent();
            mdiProp();
        }

        private void mdiProp()
        {
            this.SetBevel(false);
            Controls.OfType<MdiClient>().FirstOrDefault().BackColor = System.Drawing.Color.FromArgb(232, 234, 237);
        }

        bool sidebarExpand = false;

        private void sideButton_Click_1(object sender, EventArgs e)
        {
            sidebarTransition.Start();
        }

        private void sidebarTransition_Tick_1(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sidebar.Width -= 5;
                if (sidebar.Width <= 40)
                {
                    sidebarExpand = false;
                    sidebarTransition.Stop();

                    pnDisplay.Width = sidebar.Width;
                    pnImport.Width = sidebar.Width;
                    pnSim.Width = sidebar.Width;
                    pnHome.Width = sidebar.Width;
                }
            }
            else
            {
                sidebar.Width += 5;
                if (sidebar.Width >= 274)
                {
                    sidebarExpand = true;
                    sidebarTransition.Stop();

                    pnDisplay.Width = sidebar.Width;
                    pnImport.Width = sidebar.Width;
                    pnSim.Width = sidebar.Width;
                    pnHome.Width = sidebar.Width;

                }
            }
        }

        private void DisplayButton_Click(object sender, EventArgs e)
        {

            if (display == null)
            {
                if (import != null)
                {
                    if (import.Loaded)
                    {
                        display = new formDisplay();
                        display.FormClosed += Display_FormClosed;
                        display.MdiParent = this;
                        display.Dock = DockStyle.Fill;
                        display.Show();
                    }
                    else
                    {
                        MessageBox.Show($"An error occurred: Asterix file not Loaded. Please upload a file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show($"An error occurred: Asterix file not Loaded. Please upload a file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }



            }
            else
            {
                display.Activate();
            }
        }

        private void Display_FormClosed(object? sender, FormClosedEventArgs e)
        {
            display = null;
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            if (import == null)
            {
                import = new formImport();
                import.FormClosed += Import_FormClosed;
                import.MdiParent = this;
                import.Dock = DockStyle.Fill;
                import.Show();

            }
            else { import.Activate(); }
        }

        private void Import_FormClosed(object? sender, FormClosedEventArgs e)
        {
            import = null;

        }

        private void SimulationButton_Click(object sender, EventArgs e)
        {
            if (simulation == null)
            {
                if (import != null)
                {
                    if (import.Loaded)
                    {
                        simulation = new formSimulation();
                        simulation.FormClosed += Simulation_FormClosed;
                        simulation.MdiParent = this;
                        simulation.Dock = DockStyle.Fill;
                        simulation.Show();
                    }
                    else
                    {
                        MessageBox.Show($"An error occurred: Asterix file not Loaded. Please upload a file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show($"An error occurred: Asterix file not Loaded. Please upload a file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else { simulation.Activate(); }
        }

        private void Simulation_FormClosed(object? sender, FormClosedEventArgs e)
        {
            simulation = null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Home = new formHome();
            Home.MdiParent = this;
            Home.Dock = DockStyle.Fill;
            Home.Show();
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            if (Home == null)
            {
                Home = new formHome();
                Home.FormClosed += Home_FormClosed;
                Home.MdiParent = this;
                Home.Dock = DockStyle.Fill;
                Home.Show();
            }
            else { Home.Activate(); }
        }

        private void Home_FormClosed(object? sender, FormClosedEventArgs e)
        {
            Home = null;
        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            if (help == null)
            {
                help = new formHelp();
                help.FormClosed += Help_FormClosed;
                help.MdiParent = this;
                help.Dock = DockStyle.Fill;
                help.Show();
            }
            else { help.Activate(); }
        }

        private void Help_FormClosed(object? sender, FormClosedEventArgs e)
        {
            help = null;
        }

        private void P3Button_Click(object sender, EventArgs e)
        {
            if (p3 == null)
            {
                    
                p3 = new P3();
                p3.FormClosed += P3_FormClosed; ;
                p3.MdiParent = this;
                p3.Dock = DockStyle.Fill;
                p3.Show();
                    
            }
            else
            {
                p3.Activate();
            }
        }

        private void P3_FormClosed(object? sender, FormClosedEventArgs e)
        {
            p3 = null;
        }
    }
}