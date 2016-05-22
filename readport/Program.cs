using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace readport
{
    class Program
    {
        static void Main(string[] args)
        {///dev/ttyACM0
            //SerialPort port2 = new SerialPort("/dev/arduino", 115200, Parity.None, 8, StopBits.One);
            //port2.Open();
            //string sonic_indata;

              Regex sonicdata_regex = new Regex("^%Sonic%,0=([0-9]|[0-9][0-9]|1[0-9][0-9]|2[0-9][0-9]),1=([0-9]|[0-9][0-9]|1[0-9][0-9]|2[0-9][0-9]),2=([0-9]|[0-9][0-9]|1[0-9][0-9]|2[0-9][0-9]),3=([0-9]|[0-9][0-9]|1[0-9][0-9]|2[0-9][0-9]),([1-9]|[1-9][0-9]|[1-9][0-9][0-9]|[1-9][0-9][0-9][0-9]|[1-9][0-9][0-9][0-9][0-9]|[1-9][0-9][0-9][0-9][0-9][0-9]|[1-9][0-9][0-9][0-9][0-9][0-9][0-9]),%SONIC%$");

            string data = "%Sonic%,0=132,1=0,2=0,3=0,337201,%SONIC%";

            string[] parts = data.Split(',');

            string time = parts[parts.Length - 1];
            int[] Sensoren = new int[4];
            if (sonicdata_regex.IsMatch(data) == true)
            {
                for (int i = 1; i < parts.Length - 2; i++)
                {
                    //Console.WriteLine(parts[i]);
                    //.Split('=')[1]

                    Sensoren[i - 1] = Convert.ToInt32(parts[i].Split('=')[1]);
                }

            }

            //while (true)
            //{
            //    Thread.Sleep(200);
            //    //Console.WriteLine("READ sonic");
            //    sonic_indata = port2.ReadLine();
            //    Console.WriteLine(sonic_indata);
            //    //port2.WriteLine("hello");

            //}
        }
    }
}
