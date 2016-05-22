using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raspberry.IO.GeneralPurpose;
using System.Threading;
using WiringPi;
using System.IO.Ports;

namespace rpwd
{
    class Program
    {

        
        static void Main(string[] args)
        {
            SerialPort port1;




            port1 = new SerialPort(Console.ReadLine(), 115200, Parity.None, 8, StopBits.One);


            port1.Open();


            while (true)
            {
                try
                {
                    if (port1.IsOpen)
                    {
                        Console.WriteLine(port1.ReadLine());
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }
           
        }
    }
}
