using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_controll
{
    public partial class Magnetometer : UserControl
    {
        public Magnetometer()
        {
            InitializeComponent();
        }
        List<Control> bars = new List<Control>();


        int max_value = 100;
        int min_value = -100;


        int value1 = 10;
        int value2 = 10;
        int value3 = 10;


        private void Magnetometer_Resize(object sender, EventArgs e)
        {

            background1.Location = new Point(0, 0);
            background2.Location = new Point(this.Width / 3, 0);
            background3.Location = new Point((this.Width - this.Width / 3), 0);


            background1.Width = this.Width / 3;
            background2.Width = this.Width / 3;
            background3.Width = this.Width / 3;


            background1.Height = this.Height;
            background2.Height = this.Height;
            background3.Height = this.Height;



            vp1.Width = background1.Width;
            vp2.Width = background2.Width;
            vp3.Width = background3.Width;

            int resolution = max_value / vp1.Height;




            vp1.Height = value1 * resolution;
            vp2.Height = value2 * resolution;
            vp3.Height = value3 * resolution;





            
        }

        public void set_values(int v1,int v2, int v3)
        {


        }


        private void set_bars(int bar,int value)
        {
            if (value < 0)
            {
                bars[bar].Size = new Size(bars[bar].Size.Width, value);
            }
            else
            {

                bars[bar].Size = new Size(bars[bar].Size.Width, value);
            }
        }

        private void Magnetometer_Load(object sender, EventArgs e)
        {
            bars.Add(vp1);
            bars.Add(vp2);
            bars.Add(vp3);

        }

    }
}
