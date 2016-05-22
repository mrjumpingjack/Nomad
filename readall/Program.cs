using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace readall
{
    class Program
    {
        static void Main(string[] args)
        {

            SerialPort port = new SerialPort("/dev/ttyAMA0", 9600, Parity.None, 8, StopBits.One);
            port.Open();

            while (true)
            {
                Thread.Sleep(200);

                Console.WriteLine(port.Read());

            }

        }
    }
}
