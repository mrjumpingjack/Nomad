using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WiringPi;

namespace wpt
{
    class Program
    {
        static void Main(string[] args)
        {

            Init.WiringPiSetupGpio();



            WiringPi.GPIO.pinMode(19, 1);
            WiringPi.GPIO.pinMode(26, 1);

            Thread.Sleep(100);
            WiringPi.GPIO.pinMode(19, 0);
            WiringPi.GPIO.pinMode(26, 1);

            Thread.Sleep(100);
            WiringPi.GPIO.pinMode(19, 1);
            WiringPi.GPIO.pinMode(26, 0);

            Thread.Sleep(100);
            WiringPi.GPIO.pinMode(19, 1);
            WiringPi.GPIO.pinMode(26, 1);

            Thread.Sleep(100);
            WiringPi.GPIO.pinMode(19, 0);
            WiringPi.GPIO.pinMode(26, 0);

            //WiringPi.GPIO.digitalWrite(19, 1);
            //WiringPi.GPIO.digitalWrite(26, 1);

            //Thread.Sleep(100);

            //WiringPi.GPIO.digitalWrite(19, 0);
            //WiringPi.GPIO.digitalWrite(26, 0);

            Thread.Sleep(100);
        }
    }
}
