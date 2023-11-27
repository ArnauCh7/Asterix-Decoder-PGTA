using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms
{
    public partial class formHome : Form
    {
        public formHome()
        {
            InitializeComponent();
        }
        bool AboutClicked = false; //Tracks if the About us button has been clicked already

        private void formHome_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;

            //Set the Pictures and labels from the About Us invisible
            picArnau.Visible = false;
            picLucas.Visible = false;
            picLucia.Visible = false;
            picPau.Visible = false;
            picSara.Visible = false;
            lbSara.Visible = false;
            lbArnau.Visible = false;
            lbLucas.Visible = false;
            lbLucia.Visible = false;
            lbPau.Visible = false;
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            //Each time the button is clicked all the info will show or dissappear

            if (AboutClicked)
            {
                AboutClicked = false;

                picArnau.Visible = false;
                picLucas.Visible = false;
                picLucia.Visible = false;
                picPau.Visible = false;
                lbArnau.Visible = false;
                lbLucas.Visible = false;
                lbLucia.Visible = false;
                lbPau.Visible = false;
                picSara.Visible = false;
                lbSara.Visible = false;

            }
            else
            {
                AboutClicked = true;

                picArnau.Visible = true;
                picLucas.Visible = true;
                picLucia.Visible = true;
                picPau.Visible = true;
                lbArnau.Visible = true;
                lbLucas.Visible = true;
                lbLucia.Visible = true;
                lbPau.Visible = true;
                picSara.Visible = true;
                lbSara.Visible = true;
            }

        }
    }
}
