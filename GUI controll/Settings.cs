using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace GUI_controll
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        public List<CheckBox> cbl = new List<CheckBox>();
        public String steeringmode = "Tank";


        public int[] redcolor_values = new int[6];
        public int[] yellowcolor_values = new int[6];
        public int[] greencolor_values = new int[6];


        private void get_values()
        {
            yellowcolor_values[0] = Convert.ToInt32(y_front.Text);
            yellowcolor_values[1] = Convert.ToInt32(y_right.Text);
            yellowcolor_values[2] = Convert.ToInt32(y_right_rear.Text);
            yellowcolor_values[3] = Convert.ToInt32(y_rear.Text);
            yellowcolor_values[4] = Convert.ToInt32(y_left_rear.Text);
            yellowcolor_values[5] = Convert.ToInt32(y_left.Text);

            redcolor_values[0] = Convert.ToInt32(r_front.Text);
            redcolor_values[1] = Convert.ToInt32(r_right.Text);
            redcolor_values[2] = Convert.ToInt32(r_right_rear.Text);
            redcolor_values[3] = Convert.ToInt32(r_rear.Text);
            redcolor_values[4] = Convert.ToInt32(r_left_rear.Text);
            redcolor_values[5] = Convert.ToInt32(r_left.Text);
        }


        private void set_values()
        {
            y_front.Text = Convert.ToString(yellowcolor_values[0]);
            y_right.Text = Convert.ToString(yellowcolor_values[1]);
            y_right_rear.Text = Convert.ToString(yellowcolor_values[2]);
            y_rear.Text = Convert.ToString(yellowcolor_values[3]);
            y_left_rear.Text = Convert.ToString(yellowcolor_values[4]);
            y_left.Text = Convert.ToString(yellowcolor_values[5]);

            r_front.Text = Convert.ToString(redcolor_values[0]);
            r_right.Text = Convert.ToString(redcolor_values[1]);
            r_right_rear.Text = Convert.ToString(redcolor_values[2]);
            r_rear.Text = Convert.ToString(redcolor_values[3]);
            r_left_rear.Text = Convert.ToString(redcolor_values[4]);
            r_left.Text = Convert.ToString(redcolor_values[5]);
        }



        private void SerializeDataSet(string steering)
        {

            XElement Settings =
             new XElement("defaultsettings",
                     new XElement("Steering", steering),
                     new XElement("Sensors",
                         new XElement("S_0", S0.CheckState),
                         new XElement("S_1", S1.CheckState),
                         new XElement("S_2", S2.CheckState),
                         new XElement("S_3", S3.CheckState),
                         new XElement("S_4", S4.CheckState),
                         new XElement("S_5", S5.CheckState)
                         ),
                    new XElement("yellow_values",
                         new XElement("S_0", yellowcolor_values[0]),
                         new XElement("S_1", yellowcolor_values[1]),
                         new XElement("S_2", yellowcolor_values[2]),
                         new XElement("S_3", yellowcolor_values[3]),
                         new XElement("S_4", yellowcolor_values[4]),
                         new XElement("S_5", yellowcolor_values[5])
                         ),
                    new XElement("red_values",
                         new XElement("S_0", redcolor_values[0]),
                         new XElement("S_1", redcolor_values[1]),
                         new XElement("S_2", redcolor_values[2]),
                         new XElement("S_3", redcolor_values[3]),
                         new XElement("S_4", redcolor_values[4]),
                         new XElement("S_5", redcolor_values[5])
                         )

                     );

            Console.WriteLine(Settings);

            StreamWriter sr = new StreamWriter("Settings.xml");
            sr.Write(Settings);
            sr.Close();






        }



        private void Settings_Shown(object sender, EventArgs e)
        {
            load_settings();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void load_settings()
        {
            if (File.Exists("Settings.xml"))
            {
                cbl.Clear();
                cbl.Add(S0);
                cbl.Add(S1);
                cbl.Add(S2);
                cbl.Add(S3);
                cbl.Add(S4);
                cbl.Add(S5);

                XmlReader Reader = XmlReader.Create("Settings.xml");
                Reader.Read();
                Reader.ReadStartElement("defaultsettings");


                Reader.ReadStartElement("Steering");

                if (Reader.ReadString() == "Tank")
                {
                    steeringmode = "Tank";
                    rb_tank.Checked = true;
                }
                else
                {
                    steeringmode = "Steeringaxis";
                    rb_steeringaxis.Checked = true;
                }


                //  Reader.Read();
                Reader.ReadEndElement();

                Reader.ReadStartElement("Sensors");
                Reader.Read();
                for (int i = 0; i <= 5; i++)
                {

                    Reader.ReadStartElement("S_" + i);
                    if (Reader.ReadString() == "Checked")
                    {
                        Console.WriteLine("S_" + i + " Checked");
                        cbl[i].Checked = true;
                    }
                    else
                    {

                        Console.WriteLine("S_" + i + " UnChecked");

                    }
                    Reader.Read();
                }
                Reader.ReadEndElement();

                Reader.ReadStartElement("yellow_values");
                /// Reader.Read();
                for (int i = 0; i <= 5; i++)
                {
                    Reader.Read();
                    string value = Reader.ReadString();

                    //Reader.ReadElementContentAsInt("S_" + i);


                    Console.WriteLine("S_" + i + " yellow: " + value);
                    yellowcolor_values[i] = Convert.ToInt32(value);


                    Reader.Read();
                }
                Reader.ReadEndElement();


                Reader.ReadStartElement("red_values");
                Reader.Read();
                for (int i = 0; i <= 5; i++)
                {
                    Reader.Read();
                    string value = Reader.ReadString();

                    //Reader.ReadElementContentAsInt("S_" + i);


                    Console.WriteLine("S_" + i + " red: " + value);
                    redcolor_values[i] = Convert.ToInt32(value);


                    Reader.Read();
                }



                //Console.Write(Reader.ReadString());


                Reader.ReadEndElement();
                Reader.Close();

                set_values();

            }
            else
            {
                Console.WriteLine("No settings file.");
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Settings_Load(object sender, EventArgs e)
        {

        }

        private void ok_Click(object sender, EventArgs e)
        {
            get_values();

            if (rb_tank.Checked)
            {
                SerializeDataSet("Tank");
            }
            else
            {
                SerializeDataSet("Steeringaxis");
            }
            this.Close();

        }

        private void y_front_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            y_front.Text = "30";
            y_right.Text = "30";
            y_right_rear.Text = "30";
            y_rear.Text = "30";
            y_left_rear.Text = "30";
            y_left.Text = "30";

            r_front.Text = "10";
            r_right.Text = "10";
            r_right_rear.Text = "10";
            r_rear.Text = "10";
            r_left_rear.Text = "10";
            r_left.Text = "10";
        }
    }
}