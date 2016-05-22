using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaspberryPiDotNet;
using System.Threading;
using Raspberry.IO.GeneralPurpose;
using Raspberry.IO.GeneralPurpose.Behaviors;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using WiringPi;

//using Microsoft.Xna.Framework.Input;
//using Microsoft.Xna.Framework;

namespace Newmotorcontroler
{
    class Program
    {

        //schub
        static OutputPinConfiguration pin3 = ConnectorPin.P1Pin11.Output();
        static OutputPinConfiguration pin4 = ConnectorPin.P1Pin13.Output();


        static GpioConnection connection = new GpioConnection(pin3);

        static int pinstate_3 = 0;
        static int pinstate_4 = 0;



        static string data = "0:0;0;0";



        static int actual_poss = 0;
        static int max_poss = 500;

        static int pin = 21;

        static int i = 0;

        static void Main(string[] args)
        {
            connection.Add(pin4);
            Console.WriteLine("Host IP?");
            string host = Console.ReadLine();

            Thread do_steering = new Thread(steer);

            Init.WiringPiSetupGpio();

            WiringPi.GPIO.SoftPwm.Create(pin, 90, 180);


            do_steering.Start();

            Connect(host);


            
            

         












        }

        static void Connect(String server)
        {
            try
            {

                Int32 port = 13000;
                TcpClient client = new TcpClient(server, port);
                Byte[] s_data;
                NetworkStream stream = client.GetStream();
                String responseData = String.Empty;
                while (responseData != "bye")
                {
                    try
                    {
                        s_data = new Byte[100];
                        Int32 bytes = stream.Read(s_data, 0, s_data.Length);
                        responseData = System.Text.Encoding.ASCII.GetString(s_data, 0, bytes);
                        Thread.Sleep(10);

                        data = responseData;

                        data = data.Split(new char[] { '|' })[0];
                        Console.WriteLine(data);
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine("While reciving: " + ex.Message);
                        Console.WriteLine(responseData);
                        responseData = String.Empty;
                        //turn(0);
                        continue;
                    }

                    //Thread.Sleep(100);
                }
                // Close everything.
                stream.Close();
                client.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e);
            }
            Console.WriteLine("\n Press Enter to continue...");
            Console.Read();
        }



        static string odata = "";



        private static void steer()
        {
            Console.WriteLine("steering set up");
            Int32 steeringvalue = 0;
            int triggerr = 0;
            int triggerl = 0;

            while (data != "bye")
            {
                try
                {

                    lock (data)
                    {
                        if (data != "" && odata!=data)
                        {
                            odata = data;
                            int transcount = Convert.ToInt32(data.Split(new char[] { ':' })[0]);

                            string mata = data.Split(new char[] { ':' })[1];



                            triggerr = Convert.ToInt32(mata.Split(new char[] { ';' })[0]);
                            Console.WriteLine("rt: " + triggerr);

                            triggerl = Convert.ToInt32(mata.Split(new char[] { ';' })[1]);
                            Console.WriteLine("lt: " + triggerl);

                            steeringvalue = Convert.ToInt32(mata.Split(new char[] { ';' })[2]);
                            Console.WriteLine("steering: " + steeringvalue);



                            if (triggerr == 0 &&
                                triggerl == 0)
                            {
                                accalerate(0);


                            }

                            if (triggerr == 1 &&
                                triggerl == 0)
                            {
                                accalerate(2);

                            }

                            if (triggerr == 0 &&
                                triggerl == 1)
                            {
                                accalerate(1);

                            }



                            alt_turn(steeringvalue);





                        }
                    }
                }


                catch (Exception ex)
                {

                    Console.WriteLine("While steering: " + ex.Message);
                    Console.WriteLine("ERRORDATA: " + data);
                    data = String.Empty;
                    //turn(0);
                    continue;
                }

                //Thread.Sleep(100);
            }
        }




        public static IGpioConnectionDriver driver = GpioConnectionSettings.DefaultDriver;






        static int old_poss = 0;

        static public void alt_turn(Int32 new_poss)
        {
            try
            {



                if (new_poss == 0)
                {
                    WiringPi.GPIO.SoftPwm.Write(pin, Convert.ToInt32(13));
                }
                else
                {
                    if (new_poss > 0)
                    {
                        if (new_poss >= 16)
                        {
                            if (new_poss >= 32)
                            {
                                WiringPi.GPIO.SoftPwm.Write(pin, Convert.ToInt32(16));
                            }
                            else
                            {
                                WiringPi.GPIO.SoftPwm.Write(pin, Convert.ToInt32(15));
                            }
                        }
                        else
                        {
                            WiringPi.GPIO.SoftPwm.Write(pin, Convert.ToInt32(14));
                        }
                    }
                    else
                    {

                        if (new_poss <= -16)
                        {
                            if (new_poss <= -32)
                            {
                                WiringPi.GPIO.SoftPwm.Write(pin, Convert.ToInt32(10));
                            }
                            else
                            {
                                WiringPi.GPIO.SoftPwm.Write(pin, Convert.ToInt32(11));
                            }
                        }
                        else
                        {
                            WiringPi.GPIO.SoftPwm.Write(pin, Convert.ToInt32(12));
                        }

                    }
                }


                Console.WriteLine(new_poss);






                old_poss = new_poss;
                //Console.WriteLine(old_poss + "->" + new_poss);

                Thread.Sleep(100);
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine("While turning: " + ex.Message);
                Console.WriteLine("ERRORDATA: " + data);
            }

        }









        static private void accalerate(int amount)
        {
            try
            {
                switch (amount)
                {
                    case 0:
                        set_pin(pin3, 0, pinstate_3);
                        set_pin(pin4, 0, pinstate_4);
                        pinstate_3 = 0;
                        pinstate_4 = 0;
                        break;

                    case 1:
                        set_pin(pin3, 1, pinstate_3);
                        set_pin(pin4, 0, pinstate_4);
                        pinstate_3 = 1;
                        pinstate_4 = 0;
                        break;

                    case 2:
                        set_pin(pin3, 0, pinstate_3);
                        set_pin(pin4, 1, pinstate_4);
                        pinstate_3 = 0;
                        pinstate_4 = 1;
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("While accalerating: " + ex.Message);
                Console.WriteLine("ERRORDATA: " + data);
                Console.WriteLine("AMOUNT: " + amount);


            }
        }








        static private void set_pin(OutputPinConfiguration pin, int state_to_be, int pinstate)
        {
            if (pinstate != state_to_be)
            {
                connection.Toggle(pin);
            }
        }

    }
}