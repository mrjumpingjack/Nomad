using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kingsland.PiFaceSharp;
using RaspberryPiDotNet;
using Kingsland.PiFaceSharp.Spi;
using System.Threading;
using Kingsland.PiFaceSharp.PinControllers;
namespace piface
{
    class Program
    {
        static void Main(string[] args)
        {




            // get reference to default piface device
            var piface = new PiFaceDevice();

            Console.WriteLine(piface.DeviceName);


            for (int i = 0; i < 7; i++)
            {
                piface.SetOutputPinState((byte)i,true);
                Thread.Sleep(1000);
                piface.SetOutputPinState((byte)i, false);
                Thread.Sleep(1000);
            }



        }
    }
}
