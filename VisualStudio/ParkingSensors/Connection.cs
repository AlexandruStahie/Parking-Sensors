using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParkingSensors
{
    public partial class Connection : Form
    {
        public Connection()
        {
            InitializeComponent();
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            Status stat = new Status();

            stat.Show();
            this.Hide();

            stat.connectionReference = this;
            stat.Connect(textBox1.Text.ToString());
        }
    }
}
