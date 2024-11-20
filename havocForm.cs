using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace Havoc__Copy_That
{
    public partial class havocForm : Form
    {
        public havocForm()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(1);
            if (progressBar1.Value < 50)
                splashLabel.Text = "Initializing..." + progressBar1.Value.ToString() + "%";
            if (progressBar1.Value >= 50)
                splashLabel.Text = "Loading Settings..." + progressBar1.Value.ToString() + "%";
            if (progressBar1.Value >= 75)
                splashLabel.Text = "Loading Program..." + progressBar1.Value.ToString() + "%";
            if (progressBar1.Value == 100)
            {
                timer1.Stop();

                new mainForm().Show();

                this.Hide();
            }
        }
    }
}
