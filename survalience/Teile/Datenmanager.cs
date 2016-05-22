using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WiringPi;

namespace surveillance.Teile
{
    class Datenmanager
    {

        public enum Antriebsart
        {
            Lenkachse,
            Panzer
        };

        public Antriebsart antriebsart = new Antriebsart();

        public Wiring_Pi wp = new Wiring_Pi();





        public int refreshtime = 5;

        public int last_update_from_sonic = 0;


        public List<Sensor> Sensoren = new List<Sensor>();
        public List<GPSpoint> route = new List<GPSpoint>();

        public string targetPoint_arg = "Confirm";



        public int next_way_point = 0;

        public string sonic = "";
        public string compass = "";
        public string gps = "";




        public GPSpoint targetpoint = new GPSpoint(0.0, 0.0);

        
        public GPSpoint quopoint = new GPSpoint(0.0, 0.0);

        public DateTime qoupoint_changed;



        public double Orientation=0.0;

        public bool end_now = false;

        public int cam_status_quo = 0;

        public float Temperatur = 0;

        public float X = 0f;
        public float Y = 0f;
        public float Z = 0f;



        public int magmet_readcount = 0;
        public int sonic_readcount = 0;
        public int heading_readcount = 0;
        public int axes_readcount = 0;
        public int temp_readcount = 0;
        public int gps_readcount = 0;




        public int[] pinstatus = new int[41];



        public bool thread_is_active_drive_with_AI = false;
        public bool thread_is_active_drive_with_Lokal = false;
        public bool thread_is_active_drive_with_Direct = false;


        private int[] _specialcomms;

        public int[] specialcomms
        {
            get
            {
                return _specialcomms;
            }

            set
            {

                _specialcomms = value;
                OnSpecialcommschanged();
            }
        }





        protected virtual void OnSpecialcommschanged()
        {
            //A
            if (specialcomms[0] == 1)
            {
                Program.egpiofunc.toogle_relay(19);
            }
            else
            {

            }

            //B
            if (specialcomms[1] == 1)
            {
                Program.egpiofunc.toogle_relay(26);
            }
            else
            {

            }

            //X
            if (specialcomms[2] == 1)
            {
                Program.egpiofunc.toogle_relay(18);
            }
            else
            {

            }

            ////Y
            //if (specialcomms[3] == 1)
            //{
            //    Program.egpiofunc.toogle(35);
            //}
            //else
            //{

            //}
            ////Down
            //if (specialcomms[4] == 1)
            //{
            //    Program.egpiofunc.toogle(12);
            //}
            //else
            //{

            //}
            ////Up
            //if (specialcomms[5] == 1)
            //{
            //    Program.egpiofunc.toogle(25);
            //}
            //else
            //{

            //}
            ////Left
            //if (specialcomms[6] == 1)
            //{
            //    Program.egpiofunc.toogle(16);
            //}
            //else
            //{
                
            //}

            ////Right
            //if (specialcomms[7] == 1)
            //{
            //    Program.egpiofunc.toogle(20);
            //}
            //else
            //{

            //}

            ////Start
            //if (specialcomms[8] == 1)
            //{
            //    Program.egpiofunc.toogle(24);
            //}
            //else
            //{

            //}

            ////Back
            //if (specialcomms[9] == 1)
            //{
            //    Program.egpiofunc.toogle(23);
            //}
            //else
            //{

            //}

            ////Big
            //if (specialcomms[10] == 1)
            //{
            //    Program.egpiofunc.toogle(31);
            //}
            //else
            //{

            //}
        }







      

        private string _COM = "";
        //public event System.EventHandler COMChanged;
        //public event System.EventHandler CAMChanged;

        protected virtual void OnCOMChanged()
        {
            Console.WriteLine("AI STATUS: " + Program.drive_with_AI.ThreadState);
            Console.WriteLine("LOCAL STATUS: " + Program.drive_with_LOCAL.ThreadState);
            Console.WriteLine("DIRECT STATUS: " + Program.drive_with_DIRECT.ThreadState);


            #region DIRECT
            if (COM.Split(',')[1] == "DIRECT")
            {
                Console.WriteLine("DIRECT sets up...");



                thread_is_active_drive_with_AI = false;
                thread_is_active_drive_with_Lokal = false;
                thread_is_active_drive_with_Direct = true;




               
            }

            #endregion DIRECT

            #region LOCAL
            if (COM.Split(',')[1] == "LOCAL")
            {

                Console.WriteLine("LOCAL sets up...");


                thread_is_active_drive_with_AI = false;
                thread_is_active_drive_with_Lokal = true;
                thread_is_active_drive_with_Direct = false;
                

            }

            #endregion LOCAL

            #region AI

            if (COM.Split(',')[1] == "AI")
            {
                Console.WriteLine("AI sets up...");

                thread_is_active_drive_with_AI = true;
                thread_is_active_drive_with_Lokal = false;
                thread_is_active_drive_with_Direct = false;
              
            }

            #endregion AI
            #region IDLE

            if (COM.Split(',')[1] == "IDLE")
            {

                thread_is_active_drive_with_AI = false;
                thread_is_active_drive_with_Lokal = false;
                thread_is_active_drive_with_Direct = false;

                Console.WriteLine("IDLE");

                
            }

        }
        #endregion IDLE

        public string COM
        {
            get
            {
                return _COM;
            }

            set
            {

                _COM = value;
                OnCOMChanged();
            }
        }


        //private int _CAM = 90;
        //protected virtual void OnCAMChanged()
        //{
        //    try
        //    {
        //        Program.auto_arduino.send_cam_data(Convert.ToString(_CAM));
        //    }
        //    catch (Exception ex)
        //    {
                
        //    }
        //}
        //public int CAM
        //{
        //    get
        //    {
        //        return _CAM;
        //    }

        //    set
        //    {

        //        _CAM = value;
        //        OnCAMChanged();
        //    }
        //}


        public int Signal_1 = 0;
        public int Signal_2 = 13;

        public int AI_rechte_achse = 0;
        public int AI_linke_achse = 0;

        public int max_distance = 50;
        public int dis_approach = 10;
        public double angle_approach = 5;


        public void setup()
        {
            if (antriebsart == Antriebsart.Lenkachse)
            {
                antrieb.setup("LA");
                Console.WriteLine("Antriebsart: Lenkachse");
            }
            else if (antriebsart == Antriebsart.Panzer)
            {
                antrieb.setup("P");
                Console.WriteLine("Antriebsart: Panzer");
            }


            
         

            Sensoren.Add(new Sensor("Vorn_Links"));   //0
            Sensoren.Add(new Sensor("Vorn"));         //1
            Sensoren.Add(new Sensor("Vorn_Rechts"));  //2

            Sensoren.Add(new Sensor("Hinen_Rechts")); //3
            Sensoren.Add(new Sensor("Hinten"));       //4
            Sensoren.Add(new Sensor("Hinten_Links")); //5

        }



        public Antrieb antrieb = new Antrieb();





        public bool bye = false;
    }
}




  