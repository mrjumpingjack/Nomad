using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using RaspberryPiDotNet;
using Kingsland.PiFaceSharp;
using Kingsland.PiFaceSharp.Spi;
using System.Diagnostics;
using System.Timers;

public class UDPListener
{
    private const int listenPort = 11000;

    static double button_a;
    static double button_b;
    static double button_y;
    static double button_x;
    static double dpad_up;
    static double dpad_down;
    static double dpad_right;
    static double dpad_left;
    static decimal r_stick_x;
    static decimal r_stick_y;
    static decimal l_stick_x;
    static decimal l_stick_y;
    static double r_stick_click;
    static double l_stick_click;
    static double r_trigger;
    static double l_trigger;
    static double r_schulter;
    static double l_schulter;
    static double big;
    static double select;
    static double start;

    static bool direct_controll = true;

    //static Thread get_input = new Thread(input);
    static Thread messen_ = new Thread(messen);

    public static int Main()
    {

        bool done = false;
        UdpClient listener = new UdpClient(listenPort);
        IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, listenPort);


        //get_input.Start();

        messen_.Start();


        byte[] receive_byte_array;
        try
        {
            int[] res_data = new int[20];

            for (int i = 0; i < res_data.Length; i++)
            {
                res_data[i] = 0;
            }

            //string received_data = "0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0;0";
            while (!done)
            {
                //Console.WriteLine("Waiting for broadcast");
                receive_byte_array = listener.Receive(ref groupEP);
                //Console.WriteLine("Received a broadcast from {0}", groupEP.ToString());
                //Console.WriteLine("data follows \n{0}\n\n", received_data);
                x(Encoding.ASCII.GetString(receive_byte_array, 0, receive_byte_array.Length));
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
        return 0;
    }

    static bool synced = false;


    //public static void input()
    //{
    //    Console.WriteLine("input running");
    //    var piface = new PiFaceDevice();
    //    while (true)
    //    {
    //        if (Console.ReadLine() == "ende" || Convert.ToInt32(big) == 1)
    //        {
    //            for (byte pin = 0; pin < 8; pin++)
    //            {
    //                var state = false;
    //                piface.SetOutputPinState(pin, state);
    //                piface.SetInputPinState(pin, state);
    //            }

    //        }

    //        if (piface.GetInputPinState(0))
    //        {
    //            piface.SetOutputPinState(0, true);
    //        }
    //        else
    //        {
    //            piface.SetOutputPinState(0, false);
    //        }

    //        if (piface.GetInputPinState(1))
    //        {
    //            piface.SetOutputPinState(1, true);
    //        }
    //        else
    //        {
    //            piface.SetOutputPinState(1, false);
    //        }

    //        if (piface.GetInputPinState(2))
    //        {
    //            piface.SetOutputPinState(2, true);
    //        }
    //        else
    //        {
    //            piface.SetOutputPinState(2, false);
    //        }

    //        if (piface.GetInputPinState(3))
    //        {
    //            piface.SetOutputPinState(3, true);
    //        }
    //        else
    //        {
    //            piface.SetOutputPinState(3, false);
    //        }
    //    }
    //}

    static string sync_ip;
    static string highjack;

    public static void x(string received_data)
    {
        if (synced == false)
        {
            sync_ip = received_data.Split(new char[] { ';' })[0];
            highjack = received_data.Split(new char[] { ';' })[1];
        }
        else
        {
            #region input

            var piface = new PiFaceDevice();


            button_a = Convert.ToDouble(received_data.Split(new char[] { ';' })[0]);
            button_b = Convert.ToDouble(received_data.Split(new char[] { ';' })[1]);
            button_y = Convert.ToDouble(received_data.Split(new char[] { ';' })[2]);
            button_x = Convert.ToDouble(received_data.Split(new char[] { ';' })[3]);
            dpad_up = Convert.ToDouble(received_data.Split(new char[] { ';' })[4]);
            dpad_down = Convert.ToDouble(received_data.Split(new char[] { ';' })[5]);
            dpad_right = Convert.ToDouble(received_data.Split(new char[] { ';' })[6]);
            dpad_left = Convert.ToDouble(received_data.Split(new char[] { ';' })[7]);
            r_schulter = Convert.ToDouble(received_data.Split(new char[] { ';' })[8]);
            l_schulter = Convert.ToDouble(received_data.Split(new char[] { ';' })[9]);

            r_stick_x = Convert.ToDecimal(received_data.Split(new char[] { ';' })[10]);
            r_stick_y = Convert.ToDecimal(received_data.Split(new char[] { ';' })[11]);

            l_stick_x = Convert.ToDecimal(received_data.Split(new char[] { ';' })[12]);
            l_stick_y = Convert.ToDecimal(received_data.Split(new char[] { ';' })[13]);

            r_stick_click = Convert.ToDouble(received_data.Split(new char[] { ';' })[14]);
            l_stick_click = Convert.ToDouble(received_data.Split(new char[] { ';' })[15]);
            l_trigger = Convert.ToDouble(received_data.Split(new char[] { ';' })[16]);
            r_trigger = Convert.ToDouble(received_data.Split(new char[] { ';' })[17]);

            big = Convert.ToDouble(received_data.Split(new char[] { ';' })[18]);
            select = Convert.ToDouble(received_data.Split(new char[] { ';' })[19]);
            start = Convert.ToDouble(received_data.Split(new char[] { ';' })[20]);


            #endregion input



            #region gas


            if (Convert.ToInt32(r_trigger) == 0)
            {
                piface.SetOutputPinState(0, false);
            }
            else
            {
                piface.SetOutputPinState(0, true);
            }

            if (Convert.ToInt32(l_trigger) == 0)
            {
                piface.SetOutputPinState(1, false);
            }
            else
            {
                piface.SetOutputPinState(1, true);
            }

            #endregion gas

            #region lenken

            if (Convert.ToInt32(l_stick_x) == 0)
            {
                piface.SetOutputPinState(3, false);
                piface.SetOutputPinState(2, false);
            }

            if (Convert.ToInt32(l_stick_x) > 0)
            {
                piface.SetOutputPinState(2, true);
                piface.SetOutputPinState(3, false);
            }
            else
            {
                piface.SetOutputPinState(2, false);
            }

            if (Convert.ToInt32(l_stick_x) < 0)
            {
                piface.SetOutputPinState(3, true);
                piface.SetOutputPinState(2, false);
            }
            else
            {
                piface.SetOutputPinState(3, false);
            }


            #endregion lenken

            #region Licht

            if (Convert.ToInt32(button_a) == 1)
            {
                piface.SetOutputPinState(5, true);
            }

            if (Convert.ToInt32(button_y) == 1)
            {
                var state_l = true;
                for (var j = 0; j < 50; j++)
                {
                    piface.SetOutputPinState(5, state_l);
                    System.Threading.Thread.Sleep(25);
                    state_l = !state_l;
                }
            }
            if (Convert.ToInt32(button_x) == 1)
            {
                piface.SetOutputPinState(5, true);
                piface.SetOutputPinState(6, true);

            }


            #endregion Licht


            if (Convert.ToInt32(start) == 1)
            {
                for (byte pin = 0; pin < 8; pin++)
                {
                    var state = true;
                    for (var i = 0; i < 50; i++)
                    {
                        piface.SetOutputPinState(pin, state);
                        System.Threading.Thread.Sleep(25);
                        state = !state;
                    }
                }
            }

        }
    }

    static UcSensor sensor_front = new UcSensor(5, 0);
    static UcSensor sensor_back = new UcSensor(5, 1);
    static UcSensor sensor_left = new UcSensor(5, 2);
    static UcSensor sensor_right = new UcSensor(5, 3);


    static double abstand_front = 0;
    static double abstand_back = 0;
    static double abstand_left = 0;
    static double abstand_right = 0;


    static void messen()
    {

        abstand_front = sensor_front.GetDistance();
        abstand_back = sensor_back.GetDistance();
        abstand_left = sensor_left.GetDistance();
        abstand_right = sensor_right.GetDistance();

    }




    public static void send_info()
    {
        IPAddress send_to_address = IPAddress.Parse(sync_ip);



    }

    class UcSensor
    {


        byte triggerpin;
        byte echopin;


        public UcSensor(int TriggerPin, int EchoPin)
        {
            triggerpin = Convert.ToByte(TriggerPin);
            echopin = Convert.ToByte(EchoPin);

        }

        public double GetDistance()
        {
            var piface = new PiFaceDevice();

            ManualResetEvent mre = new ManualResetEvent(false);
            mre.WaitOne(500);
            Stopwatch pulseLength = new Stopwatch();

            //Send pulse

            piface.SetOutputPinState(triggerpin, true);
            mre.WaitOne(TimeSpan.FromMilliseconds(0.01));
            piface.SetOutputPinState(triggerpin, false);



            //Recieve pusle
            while (piface.GetInputPinState(echopin) == false)
            {
            }
            pulseLength.Start();


            while (piface.GetInputPinState(echopin) == true)
            {
            }
            pulseLength.Stop();

            //Calculating distance
            TimeSpan timeBetween = pulseLength.Elapsed;
            Debug.WriteLine(timeBetween.ToString());
            double distance = timeBetween.TotalSeconds * 17000;

            return distance;
        }

    }

}

