using surveillance.Teile;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace surveillance
{
    class PC_Auto
    {

        IPAddress[] addresslist;
        static TcpClient tcpclnt = new TcpClient();
        static Stream stm;
        byte[] databyte;


        string to_senddata_gps = "";
        string to_senddata_sonic = "";
        string to_senddata_compass = "";
        string to_senddata_antrieb = "";
        string to_senddata_route = "";
        string to_senddata_magnetometer = "";
        string to_senddata_temperatur = "";

        string old_data_gps = "";
        string old_data_sonic = "";
        string old_data_compass = "";
        string old_data_antrieb = "";
        string old_data_route = "";
        string old_data_magnetometer = "";
        string old_data_temperatur = "";

        List<string> to_send_data = new List<string>();

        List<string> COMM = new List<string>();
        List<string> CAM = new List<string>();


        Thread read_PC_data;

        public void connect_to_PC(string host)
        {
            try
            {




                read_PC_data = new Thread(read_data_PC);


                string hostname = "brunshomenet.dyndns.info";





                if (!String.IsNullOrEmpty(host))
                {
                    hostname = host;
                }
                else
                {
                    Console.WriteLine("IP of server?");
                    hostname = Console.ReadLine();
                }


                addresslist = Dns.GetHostAddresses(hostname);

                foreach (IPAddress theaddress in addresslist)
                {
                    Console.WriteLine(theaddress.ToString());
                }

                Console.WriteLine("Connecting.....");
                tcpclnt.Connect(addresslist, 8070);
                Console.WriteLine("Connected");
                stm = tcpclnt.GetStream();
                string a = "FUCK FUCK FUCK";
                byte[] ba = new byte[a.Length];
                for (int i = 0; i < a.Length; i++)
                {
                    ba[i] = Convert.ToByte(a[i]);
                }

                stm.Write(ba, 0, ba.Length);
                read_PC_data.Start();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("ERROR while establishing connection :" + ex.Message);
                //Console.WriteLine("MAIN_ERROR: " + ex.Message);

            }
        }


        public void check_and_send_data()
        {
            try
            {
                to_senddata_gps = Convert.ToString(Program.datamng.quopoint.lat) + "," + Convert.ToString(Program.datamng.quopoint.lng);
                to_senddata_sonic = Program.datamng.sonic;
                to_senddata_compass = Convert.ToString(Program.datamng.Orientation);
                to_senddata_antrieb = Convert.ToString(Program.datamng.AI_linke_achse + "," + Program.datamng.AI_rechte_achse);
                to_senddata_route = Convert.ToString(Program.datamng.targetpoint.lat + ";" + Program.datamng.targetpoint.lng) + "," + Program.datamng.targetPoint_arg;

                to_senddata_magnetometer = Convert.ToString(Program.datamng.X + "," + Program.datamng.Y + "," + Program.datamng.Z);
                to_senddata_temperatur = Convert.ToString(Program.datamng.Temperatur);



                Console.WriteLine(Program.datamng.gps_readcount+" GPS: " + to_senddata_gps);
                Console.WriteLine(Program.datamng.sonic_readcount+" Sonic: " + to_senddata_sonic);
                Console.WriteLine(Program.datamng.heading_readcount + " Heading: " + to_senddata_compass);
                Console.WriteLine(Program.datamng.magmet_readcount + " Magnetomenter: " + to_senddata_magnetometer);
                Console.WriteLine(Program.datamng.temp_readcount+" Temperatur: " + to_senddata_temperatur);

                Console.WriteLine("Antrieb: " + to_senddata_antrieb);
                Console.WriteLine("Route: " + to_senddata_route);


                
                to_send_data.Clear();

                //to_send_data.Add("TIME: " + DateTime.Now);

                if (to_senddata_gps != old_data_gps)
                {
                    // Console.WriteLine("SEND_gps:" + to_senddata_gps);
                    to_send_data.Add("%GPS%" + to_senddata_gps);
                    old_data_gps = to_senddata_gps;
                }

                if (to_senddata_sonic != old_data_sonic)
                {
                    //  Console.WriteLine("SEND_sonic:" + to_senddata_sonic);
                    to_send_data.Add("%SONIC%" + to_senddata_sonic);
                    old_data_sonic = to_senddata_sonic;
                }

                if (to_senddata_compass != old_data_compass)
                {
                    // Console.WriteLine("SEND_compass:" + to_senddata_compass);
                    to_send_data.Add("%COMPASS%" + to_senddata_compass);
                    old_data_compass = to_senddata_compass;
                }

                if (to_senddata_antrieb != old_data_antrieb)
                {
                   // Console.WriteLine("SEND antrieb:" + to_senddata_antrieb);
                    to_send_data.Add("%ANTRIEB%" + to_senddata_antrieb);
                    old_data_antrieb = to_senddata_antrieb;
                }

                if (to_senddata_route != old_data_route)
                {
                   // Console.WriteLine("SEND route:" + to_senddata_route);
                    to_send_data.Add("%ROUTE%" + to_senddata_route);
                    old_data_route = to_senddata_route;
                }

                if (to_senddata_magnetometer != old_data_magnetometer)
                {
                    //Console.WriteLine("SEND magnetometer:" + to_senddata_magnetometer);
                    to_send_data.Add("%AXES%" + to_senddata_magnetometer);
                    old_data_magnetometer = to_senddata_magnetometer;
                }

                if (to_senddata_temperatur != old_data_temperatur)
                {
                    //Console.WriteLine("SEND temperatur:" + to_senddata_temperatur);
                    to_send_data.Add("%TEMP%" + to_senddata_temperatur);
                    old_data_temperatur = to_senddata_temperatur;
                }

                send_data(to_send_data);

            }
            catch (Exception ex)
            {
                throw new NotImplementedException("ERROR while checking data: " + ex.Message);
                //Console.WriteLine("SEND_TH_ERROR: " + ex.Message);
            }
        }



        bool ready = true;
        public void send_data(List<string> data)
        {
            Console.WriteLine("SENDING DATA...");
            try
            {

                if (tcpclnt.Connected == true)
                {
                    //Console.WriteLine("ONLINE");
                    foreach (string s in data)
                    {
                        if (ready)
                        {
                            ready = false;
                            //Console.WriteLine(s);
                            databyte = new byte[s.Length];

                            for (int i = 0; i < databyte.Length; i++)
                            {
                                databyte[i] = Convert.ToByte(s[i]);
                            }

                            stm.Write(databyte, 0, databyte.Length);


                            // Console.WriteLine("SENED " + s);
                            ready = true;
                        }
                        Thread.Sleep(200);
                    }
                }
                else
                {
                    Console.WriteLine("OFFLINE");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR while sending data to PC: " + ex.Message);

            }
        }

        public void read_data_PC()
        {


            string recived = "";
            while (true)
            {
                try
                {
                    //if (string.IsNullOrEmpty(recived))
                    //{



                    recived = "";
                    byte[] bb = new byte[1000];
                    int k = stm.Read(bb, 0, 100);

                    for (int i = 0; i < k; i++)
                    {
                        recived = recived + Convert.ToChar(bb[i]);
                    }

                    if (recived.StartsWith("GOTO:"))
                    {
                        Console.WriteLine(recived);
                        recived = recived.Substring(5, recived.Length - 5);

                        Program.datamng.targetpoint = new GPSpoint(Convert.ToDouble(recived.Split(';')[0]), Convert.ToDouble(recived.Split(';')[1]));
                        Program.datamng.targetPoint_arg = "Confirm";
                        Console.WriteLine("NEW TARGET: " + Program.datamng.targetpoint.lat + "," + Program.datamng.targetpoint.lng);
                    }

                    if (recived.StartsWith("ROUTE:"))
                    {
                        Program.datamng.route.Clear();
                        // Console.WriteLine(recived);
                        recived = recived.Substring(6, recived.Length - 6);
                        int index = 0;

                        foreach (string point in recived.Split('|'))
                        {
                            if (point.Length > 0)
                            {
                                Program.datamng.route.Add(new GPSpoint(double.Parse(point.Split(';')[0], System.Globalization.CultureInfo.InvariantCulture), double.Parse(point.Split(';')[1], System.Globalization.CultureInfo.InvariantCulture)));
                                index++;

                                Console.WriteLine(index + ":" + point);
                            }
                        }

                        Console.WriteLine("NEW TARGET POINT: " + Convert.ToString(Program.datamng.route[0].lat) + "," + Convert.ToString(Program.datamng.route[0].lng));


                        Program.datamng.targetpoint = new GPSpoint(Program.datamng.route[0].lat, Program.datamng.route[0].lng);
                        Program.datamng.targetPoint_arg = "Route";


                    }

                    if (recived.StartsWith("COMM"))
                    {
                        Program.datamng.COM = recived;
                    }

                    if (recived.StartsWith("SC"))
                    {

                        //   SC,0,0,0,0,0,0,0,0,0,0,0


                        recived = recived.Substring(3, recived.Length - 3);
                        //Console.WriteLine("weniger 3: " + recived);

                        Program.datamng.specialcomms = Array.ConvertAll(recived.Split(new char[] { ',' }), s => int.Parse(s));

                        //Console.WriteLine(recived);



                    }



                    if (recived.StartsWith("DIRECT"))
                    {
                        //Console.WriteLine(recived);



                        if (recived != "DIRECT,no comand")
                        {
                            //Console.WriteLine("r:" + recived);


                            if (Program.datamng.antriebsart == Datenmanager.Antriebsart.Panzer)
                            {
                                if (Program.datamng.Signal_1 != Convert.ToInt32(recived.Split(',')[1]))
                                {
                                    Program.datamng.Signal_1 = Convert.ToInt32(recived.Split(',')[1]);
                                }
                                if (Program.datamng.Signal_2 != Convert.ToInt32(recived.Split(',')[2]))
                                {
                                    Program.datamng.Signal_2 = Convert.ToInt32(recived.Split(',')[2]);
                                }
                            }
                            else
                            {
                                Program.datamng.Signal_1 = Convert.ToInt32(recived.Split(',')[1]);
                                Program.datamng.Signal_2 = Convert.ToInt32(recived.Split(',')[2]);
                            }
                        }
                    }

                    if (recived.Contains("bye"))
                    {
                        System.Environment.Exit(1);
                    }


                    //if (recived.StartsWith("CAM"))
                    //{
                    //    Program.datamng.CAM = Convert.ToInt32(recived.Split(',')[1]);
                    //}







                    //}



                    //Console.WriteLine("recived: " + recived);

                    //recived = "";


                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR while reciving data from PC: " + ex.Message + " DATA: " + recived);
                    continue;
                }
            }



            //Program.drive_with_AI.Abort();
            //Program.drive_with_DIRECT.Abort();
            //Program.drive_with_LOCAL.Abort();


        }
    }
}
