using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using System.Threading;

namespace KOO_kon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private string Grad_Dezimalminuten_to_Grad_Minuten_Sekunden(string data)
        {
            String output = "";

            string lat = "";
            string lng = "";

            string lat_m = "";
            string lng_m = "";

            string lat_s = "";
            string lng_s = "";

            string[] data_ = data.Split(',');

            double lat_s_d = 0.0;
            double lng_s_d = 0.0;

            lat_s = data_[0].Substring(data_[0].Length - 8, 7);
            lng_s = data_[1].Substring(data_[1].Length - 8, 7);

            lat_m = data_[0].Substring(0, data_[0].Length - (lat_s.Length + 1));
            lng_m = data_[1].Substring(0, data_[1].Length - (lng_s.Length + 1));

            while (lng_m.StartsWith("0"))
            {
                lng_m = lng_m.Substring(1, lng_m.Length - 1);
            }

            lat_s_d = Convert.ToDouble(lat_s) / 60;
            lng_s_d = Convert.ToDouble(lng_s) / 60;

            lat = lat_m + "." + Convert.ToString(Convert.ToDouble(lat_s) / 60);
            lng = lng_m + "." + Convert.ToString(Convert.ToDouble(lng_s) / 60);

            lat = lat.Replace(",", string.Empty);
            lng = lng.Replace(",", string.Empty);

            output = lat + "," + lng;

            return output;
        }

        private string Grad_Minuten_Sekunden_to_Grad_Dezimalminuten(string data)
        {
            String output = "";

            string lat = "";
            string lng = "";

            string lat_m = "";
            string lng_m = "";

            string lat_s = "";
            string lng_s = "";

            string[] data_ = data.Split(',');

            double lat_s_d = 0.0;
            double lng_s_d = 0.0;

            lat_s = data_[1].Substring(data_[1].Length - 8, 7);
            lng_s = data_[3].Substring(data_[3].Length - 8, 7);

            lat_m = data_[1].Substring(0, data_[1].Length - (lat_s.Length + 1));
            lng_m = data_[3].Substring(0, data_[3].Length - (lng_s.Length + 1));

            while (lng_m.StartsWith("0"))
            {
                lng_m = lng_m.Substring(1, lng_m.Length - 1);
            }

            lat_s_d = Convert.ToDouble(lat_s) * 60;
            lng_s_d = Convert.ToDouble(lng_s) * 60;

            lat = lat_m + "." + Convert.ToString(Convert.ToDouble(lat_s) / 60);
            lng = lng_m + "." + Convert.ToString(Convert.ToDouble(lng_s) / 60);

            lat = lat.Replace(",", string.Empty);
            lng = lng.Replace(",", string.Empty);

            output = lat + "," + lng;

            return output;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string data=textBox1.Text+","+textBox2.Text;
           string output= Grad_Dezimalminuten_to_Grad_Minuten_Sekunden(data);
           textBox3.Text = output.Split(',')[0];
           textBox4.Text = output.Split(',')[1];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string data = textBox1.Text + "," + textBox2.Text;
            string output = Grad_Dezimalminuten_to_Grad_Minuten_Sekunden(data);
            textBox1.Text = output.Split(',')[0];
            textBox2.Text = output.Split(',')[1];
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
        GMapOverlay overlayOne;

        private void button3_Click(object sender, EventArgs e)
        {
            overlayOne.Markers.Add(new GMap.NET.WindowsForms.Markers.GMarkerCross(new PointLatLng(double.Parse(textBox1.Text, System.Globalization.CultureInfo.InvariantCulture), double.Parse(textBox2.Text, System.Globalization.CultureInfo.InvariantCulture))));
            gMapControl1.Overlays.Add(overlayOne);
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {
        
            //initialisation de notre map
           gMapControl1.SetPositionByKeywords("Stadthagen, Teichstraße 57");
           
           gMapControl1.MapProvider = GMapProviders.OpenStreetMap;
           gMapControl1.MinZoom = 3;
           gMapControl1.MaxZoom = 20;
           gMapControl1.Zoom = 19;
           gMapControl1.Manager.Mode = AccessMode.ServerAndCache;
           gMapControl1.DragButton = MouseButtons.Left;
            //ajout des overlay
            overlayOne = new GMapOverlay("OverlayOne");
            //ajout de Markers
            // overlayOne.Markers.Add(new GMap.NET.WindowsForms.Markers.GMarkerCross(new PointLatLng(36.657403, 10.327148)));
            //ajout de overlay à la map
            //gMapControl1.Overlays.Add(overlayOne);
        
        }


        static public void Tick(Object stateInfo)
        {
            Console.WriteLine("Tick: {0}", DateTime.Now.ToString("h:mm:ss"));
        }

      
        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
