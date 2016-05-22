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
    public partial class Einstellungen : Form
    {
        public Einstellungen()
        {
            InitializeComponent();
        }

        public List<CheckBox> cbl = new List<CheckBox>();
        public String lenkmodus = "Panzer";




        private void Einstellungen_Load(object sender, EventArgs e)
        {

        }

        private void SerializeDataSet(string lenkung)
        {

            XElement Einstellungen =
             new XElement("Standarteinsteillungen",
                     new XElement("Lenkung", lenkung),
                     new XElement("Sensoren",
                         new XElement("S_1", S1.CheckState),
                         new XElement("S_2", S2.CheckState),
                         new XElement("S_3", S3.CheckState),
                         new XElement("S_4", S4.CheckState),
                         new XElement("S_5", S5.CheckState),
                         new XElement("S_6", S6.CheckState),
                         new XElement("S_7", S7.CheckState),
                         new XElement("S_8", S8.CheckState),
                         new XElement("S_9", S9.CheckState),
                         new XElement("S_10", S10.CheckState),
                         new XElement("S_11", S11.CheckState),
                         new XElement("S_12", S12.CheckState),
                         new XElement("S_13", S13.CheckState),
                         new XElement("S_14", S14.CheckState),
                         new XElement("S_15", S15.CheckState),
                         new XElement("S_16", S16.CheckState)

        )
    );
            Console.WriteLine(Einstellungen);

            StreamWriter sr = new StreamWriter("Settings.xml");
            sr.Write(Einstellungen);
            sr.Close();






        }

        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (rb_panzer.Checked)
            {
                SerializeDataSet("Panzer");
            }
            else
            {
                SerializeDataSet("Lenkachse");
            }
            this.Close();
        }

        private void Einstellungen_Shown(object sender, EventArgs e)
        {

            load_settings();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void load_settings()
        {
            cbl.Add(S1);
            cbl.Add(S2);
            cbl.Add(S3);
            cbl.Add(S4);
            cbl.Add(S5);
            cbl.Add(S6);
            cbl.Add(S7);
            cbl.Add(S8);
            cbl.Add(S9);
            cbl.Add(S10);
            cbl.Add(S11);
            cbl.Add(S12);
            cbl.Add(S13);
            cbl.Add(S14);
            cbl.Add(S15);
            cbl.Add(S16);

            XmlReader Reader = XmlReader.Create("settings.xml");
            Reader.Read();
            Reader.ReadStartElement("Standarteinsteillungen");


            Reader.ReadStartElement("Lenkung");

            if (Reader.ReadString() == "Panzer")
            {
                lenkmodus = "Panzer";
                rb_panzer.Checked = true;
            }
            else
            {
                lenkmodus = "Lenkachse";
                rb_lenkachse.Checked = true;
            }


            Reader.Read();

            Reader.ReadStartElement("Sensoren");
            Reader.Read();
            for (int i = 1; i <= 16; i++)
            {

                Reader.ReadStartElement("S_" + i);
                if (Reader.ReadString() == "Checked")
                {
                    Console.Write("S_" + i + " Checked");
                    cbl[i - 1].Checked = true;
                }
                else
                {

                    Console.Write("S_" + i + " UnChecked");

                }
                Reader.Read();
            }





            Console.Write(Reader.ReadString());


            Reader.ReadEndElement();
            Reader.Close();
        }


    }


}