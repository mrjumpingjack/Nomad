using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using surveillance.Teile;

namespace surveillance
{
    class Auto_Arduino
    {
        //Regex sonicdata_regex = new Regex(@"/^%Sonic%,0=([0-9]|[0-9][0-9]|1[0-9][0-9]|2[0-9][0-9]),1=([0-9]|[0-9][0-9]|1[0-9][0-9]|2[0-9][0-9]),2=([0-9]|[0-9][0-9]|1[0-9][0-9]|2[0-9][0-9]),3=([0-9]|[0-9][0-9]|1[0-9][0-9]|2[0-9][0-9]),([1-9]|[1-9][0-9]|[1-9][0-9][0-9]|[1-9][0-9][0-9][0-9]|[1-9][0-9][0-9][0-9][0-9]|[1-9][0-9][0-9][0-9][0-9][0-9]|[1-9][0-9][0-9][0-9][0-9][0-9][0-9]),%SONIC%$/gm");

        //String old_sonicdata = "";

        SerialPort port1;

        String indata;
        Thread read_data_arduino;


        public bool is_activ = false;

        public void setup()
        {
            try
            {
                String portaddresse = "/dev/ttyACM0";
                port1 = new SerialPort(portaddresse, 115200, Parity.None, 8, StopBits.One);

                read_data_arduino = new Thread(read_data_from_arduino);
                
                port1.Open();


                while(!port1.IsOpen)

                {
                    if (portaddresse == "/dev/ttyACM0")
                    {
                        portaddresse = "/dev/ttyACM1";
                    }
                    else
                    {
                        portaddresse = "/dev/ttyACM0";
                    }

                    port1.Open();
                    Console.WriteLine("Connecting to arduino...");

                    Thread.Sleep(100);
                }


                read_data_arduino.Start();


                is_activ = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR while est. connection to arduino: " + ex.Message);
            }
        }


        

        private void read_data_from_arduino()
        {
            // Console.WriteLine("Hello");



            while (true)
            {
                try
                {
                    indata = port1.ReadLine();

                   // Console.WriteLine("DATA FROM ARDUINO " +indata);

                    if (indata.Length > 5)
                    {
                        
                       

                        if (indata.StartsWith("$GPGGA%"))
                        {
                            Program.datamng.gps_readcount++;
                            dealwithgeodata(indata);
                        }

                        if (indata.StartsWith("%SONIC%"))
                        {
                            Program.datamng.sonic_readcount++;
                            dealwithsonicdata(indata);
                        }

                        if (indata.StartsWith("%HEADING%"))
                        {
                            Program.datamng.heading_readcount++;
                            dealwithcompassdata(indata);
                        }

                        if (indata.StartsWith("%AXES%"))
                        {
                            Program.datamng.axes_readcount++;
                            dealwithmagnometerdata(indata);
                        }

                        if (indata.StartsWith("%TEMP%"))
                        {
                            Program.datamng.temp_readcount++;
                            dealwithtempdata(indata);
                        }
                    }
                    //Thread.Sleep(200);
                }

                catch (Exception ex)
                {
                    Console.WriteLine("READ_DATA_ERROR: " + ex.Message);
                    continue;
                }
            }
        }

        void dealwithtempdata(string data)
        {
            data = data.Substring(7, data.Length - 7);

            data = RemoveWhitespace(data);


            Program.datamng.Temperatur = (float)Convert.ToDouble(data);

        }

        string RemoveWhitespace(string input)
        {
            return new string(input.ToCharArray()
                .Where(c => !Char.IsWhiteSpace(c))
                .ToArray());
        }



        private void dealwithmagnometerdata(string indata)
        {
            
            float X = 0f;
            float Y = 0f;
            float Z = 0f;

            Program.datamng.X = (float)Convert.ToDouble(indata.Split(new char[] { ',' })[1]);
            Program.datamng.Y = (float)Convert.ToDouble(indata.Split(new char[] { ',' })[2]);
            Program.datamng.Z = (float)Convert.ToDouble(indata.Split(new char[] { ',' })[3]);
        }

        private void dealwithgeodata(string data)
        {
            try
            {
                //$GPGGA,hhmmss.ss,llll.ll,a,yyyyy.yy,a,x,xx,x.x,x.x,M,x.x,M,x.x,xxxx*hh
                //$GPGLL,5219.90552,N,00912.87947,E,213601.00,A,A*65
                string[] parts = data.Split(new char[] { ',' });
                //Console.WriteLine(data);
                if (parts[1].Length > 0 && parts[3].Length > 0)
                {
                    Program.datamng.quopoint = new GPSpoint(double.Parse(parts[1], System.Globalization.CultureInfo.InvariantCulture), double.Parse(parts[3], System.Globalization.CultureInfo.InvariantCulture));
                    Program.datamng.qoupoint_changed = DateTime.Now;

                }


                
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("GEO ERROR WITH: " + data);
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }

        }

        private void dealwithsonicdata(string data)
        {
            string time = "";
            try
            {
                data = data.Replace(Environment.NewLine, "");

                //Console.WriteLine(data);

                Program.datamng.sonic = data;

                List<string> processed_data = new List<string>();

                foreach (string dat in data.Split(','))
                {
                    processed_data.Add(dat);
                }

                processed_data.RemoveAt(0);

                processed_data.RemoveAt(processed_data.Count - 1);
                processed_data.RemoveAt(processed_data.Count - 1);

                for (int i = 0; i < processed_data.Count; i++)
                {
                    //Console.WriteLine(processed_data[i]);
                    Program.datamng.Sensoren[i].abstand = Convert.ToInt32(processed_data[i].Substring(2, processed_data[i].Length - 2));

                }




            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("SONIC ERROR WITH: " + data);
                Console.WriteLine(time);
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }
        }

        private void dealwithcompassdata(string data)
        {
            try
            {
                string[] parts = data.Split(',');

                Program.datamng.Orientation = double.Parse(parts[1], System.Globalization.CultureInfo.InvariantCulture);
                //Console.WriteLine(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("COMPASS ERROR WITH: " + data);
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }
        }

     
        //public void send_cam_data(string data)
        //{
        //    try
        //    {
        //        if (port1.IsOpen == false)
        //        {
        //            port1.Open();
        //        }
        //        send_data_to_arduino("CAM," + Convert.ToString(data));
        //        Console.WriteLine("SENING CAM VALUE :" + Convert.ToString(data));

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine();
        //        Console.WriteLine("ERROR WITH SENING CAM: " + data);
        //        Console.WriteLine(ex.Message);
        //        Console.WriteLine();
        //    }
        //}


        public void send_data_to_arduino(string data)
        {
            try
            {
                port1.WriteLine(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("ERROR WHILE SENDING DATA TO ARDUINO: " + data);
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }
        }
    }
}
