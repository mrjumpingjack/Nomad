using RaspberryPiDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raspberry.IO.GeneralPurpose;
using Raspberry.IO.GeneralPurpose.Behaviors;
using System.Threading;
using System.Globalization;
using WiringPi;
using surveillance.Teile;
namespace surveillance.Teile
{
    public class Wiring_Pi
    {
        public void setup()
        {
            try
            {
                Init.WiringPiSetupGpio();

                WiringPi.GPIO.SoftPwm.Create(21, 13, 180);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR while stting up wiringpi");
            }

        }


    }
}
