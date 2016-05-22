using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiringPi;
using surveillance.Teile;

namespace surveillance.Teile
{
    class extra_gpio_func
    {
        public void setup()
        {
            try
            {
                for (int ps = 0; ps < Program.datamng.pinstatus.Length; ps++)
                {
                    Program.datamng.pinstatus[ps] = 0;
                    Console.WriteLine(Program.datamng.pinstatus[ps]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR WHILE SETTING UP SPECOMMS");
            }

        }

        public void toogle(int pin)
        {
            try
            {

                if (Program.datamng.pinstatus[pin] == 0)
                {
                    WiringPi.GPIO.digitalWrite(pin, 1);
                    Program.datamng.pinstatus[pin] = 1;
                }
                else
                {
                    WiringPi.GPIO.digitalWrite(pin, 0);
                    Program.datamng.pinstatus[pin] = 0;
                }


                Console.WriteLine("Pin " + pin + ":" + Program.datamng.pinstatus[pin]);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR WHILE TOOGLING PINS IN SPECOMM");
            }
        }

        public void toogle_relay(int pin)
        {
            try
            {

                if (Program.datamng.pinstatus[pin] == 0)
                {
                    WiringPi.GPIO.pinMode(pin, 1);
                    Program.datamng.pinstatus[pin] = 1;
                    Console.WriteLine("Pin " + (pin + 1) + ":" + Program.datamng.pinstatus[pin]);
                }
                else
                {
                    WiringPi.GPIO.pinMode(pin, 0);
                    Program.datamng.pinstatus[pin] = 0;
                    Console.WriteLine("Pin " + (pin+1) + ":" + Program.datamng.pinstatus[pin]);
                }


               
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR WHILE TOOGLING PINS IN SPECOMM");
            }
        }


    }
}
