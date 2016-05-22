#region using
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Kingsland.PiFaceSharp;
using Kingsland.PiFaceSharp.Spi;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Globalization;
using System.Timers;
using Kingsland.PiFaceSharp.PinControllers;
using surveillance.Teile;
using WiringPi;
using Raspberry.IO.GeneralPurpose;
using Raspberry.IO.GeneralPurpose.Behaviors;


#endregion using
namespace surveillance
{
    class Program
    {
        static public Datenmanager datamng = new Datenmanager();


        static Thread send_data_to_pc = new Thread(senddata);
        static public Thread drive_with_AI;
        static public Thread drive_with_DIRECT;
        static public Thread drive_with_LOCAL;

        static public PC_Auto pc_auto = new PC_Auto();
        static public Auto_Arduino auto_arduino = new Auto_Arduino();

        static DateTime last_send_time = DateTime.Now;


        static public Panzer_AI panzer_ai = new Panzer_AI();
        static public Lenkachsen_AI lenkachsen_ai = new Lenkachsen_AI();

        static public extra_gpio_func egpiofunc = new extra_gpio_func();


        static public directcontroll_Panzer directcontroll_panzer = new directcontroll_Panzer();
        static public directcontroll_Lenkachse directcontroll_lenkachse = new directcontroll_Lenkachse();

        static private string host;

        //public static PC_Auto pc_auto = new PC_Auto();

        static void Main(string[] args)
        {


            //try
            //{
                #region start

                if (args.Length > 0)
                    host = args[0];

                datamng.setup();
                Thread.Sleep(500);


                Console.WriteLine("1: SETTING UP ARDUINO <-> RASPBERRY");
                Auto_Arduino auto_arduino = new Auto_Arduino();
                auto_arduino.setup();

                while (!auto_arduino.is_activ)
                {
                    Console.WriteLine("try to start arduino...");
                    auto_arduino.setup();
                    Thread.Sleep(500);
                }

                Console.WriteLine("DONE");
                Console.WriteLine();

                Console.WriteLine("2: IP CONFIG");
                if (String.IsNullOrEmpty(host))
                {
                    host = "192.168.0.11";
                }

                Console.WriteLine("IP: " + host);

                Console.WriteLine("DONE");
                Console.WriteLine();

                Console.WriteLine("3: WIRINGPI");

                Program.datamng.wp.setup();

                Console.WriteLine("DONE");
                Console.WriteLine();

                Console.WriteLine("4: SPECOMMS");
                egpiofunc.setup();
                Console.WriteLine("DONE");
                Console.WriteLine();


                Console.WriteLine("5: THREAD STARTS");
                artificial_intelligence artiintell = new artificial_intelligence();
                directcontrol_panzer drctrl = new directcontrol_panzer();
                localcontroll localcontroll = new localcontroll();

                drive_with_AI = new Thread(artiintell.drive);
                drive_with_DIRECT = new Thread(drctrl.drive);
                drive_with_LOCAL = new Thread(localcontroll.local_con);

                Console.WriteLine("DONE");
                Console.WriteLine();
                Console.WriteLine("6: CONNECT TO HOST PC");


                pc_auto.connect_to_PC(host);

                Thread.Sleep(500);


                Console.WriteLine("DONE");
                Console.WriteLine();

                Console.WriteLine("7: SENDING DATA TO PC STARTED");
                send_data_to_pc.Start();

                Console.WriteLine("DONE");
                Console.WriteLine();





                Console.WriteLine("8: ACTIVATING THRAEDS");

                //drive_with_AI.Start();
                drive_with_DIRECT.Start();
                //drive_with_LOCAL.Start();

                Thread.Sleep(1000);

                Console.WriteLine("AI STATUS: " + Program.drive_with_AI.ThreadState);
                Console.WriteLine("LOCAL STATUS: " + Program.drive_with_LOCAL.ThreadState);
                Console.WriteLine("DIRECT STATUS: " + Program.drive_with_DIRECT.ThreadState);

                Console.WriteLine("DONE");
                Console.WriteLine();




                #endregion start






            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("MAINERROR:" + ex.Message + "..." + ex.Data + ".." + ex.InnerException);

            //}
        }

        private static void senddata()
        {
            try
            {
               
                while (true)
                {
                    if (DateTime.Now > last_send_time.AddSeconds(datamng.refreshtime))
                    {
                       

                        pc_auto.check_and_send_data();
                        last_send_time = DateTime.Now;




                    }
                    Thread.Sleep(100);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("ERROR WHILE SENDING DATA");
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }
        }


        private static void read_config_file()
        {
            if (File.Exists("config.ini"))
            {
                StreamReader sr = new StreamReader("config.ini");
                String text = sr.ReadToEnd();
                Dictionary<string,string> attributes = new Dictionary<String,String>();

                foreach (string row in text.Split(new char[]{'\r','\n'}))
               {
                    String key= text.Split('=')[0];
                    String value= text.Split('=')[1];
                    if(!attributes.Keys.Contains(key))
                    {
                        attributes.Add(key, value);
                    }
                }

                if (attributes["Antriebsmodus"] == "Lenkachse")
                {
                    datamng.antriebsart = surveillance.Teile.Datenmanager.Antriebsart.Lenkachse;
                }
                if (attributes["Antriebsmodus"] == "Panzer")
                {
                    datamng.antriebsart = surveillance.Teile.Datenmanager.Antriebsart.Panzer;
                }
            }

        }


    }
}