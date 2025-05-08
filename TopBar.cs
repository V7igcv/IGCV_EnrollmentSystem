using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EDP_WinProject102;

namespace EDP_WinProject102
{
    public partial class TopBar : UserControl
    {
        public TopBar()
        {
            InitializeComponent();

            this.Load += TopBar_Load;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            dateTime.Text = DateTime.Now.ToString("dddd, MMMM dd yyyy - hh:mm:ss tt");
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void TopBar_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Session.FirstName))
            {
                label3.Text = Session.FirstName;
            }
            else
            {
                label3.Text = "Admin"; // default/fallback
            }

            // Start the date/time updater if needed
            timer1.Start();
        }
    }
}
