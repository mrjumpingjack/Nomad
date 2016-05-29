using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace surveillance
{
    class directcontroll_steering_axis
    {
        

        public void x()
        {
            try
            {
                Console.WriteLine("DIRECTCONTROLL_STEERING_AXIS ON");
                while (true)
                {
                    if (Program.datamng.Signal_1 == 1)
                    {
                        Console.WriteLine("DRCRL forwards");
                        Program.datamng.drive.forwards();
                    }

                    if (Program.datamng.Signal_1 == 0 )
                    {
                        Program.datamng.drive.stopp();
                    }

                    if (Program.datamng.Signal_1 == -1)
                    {
                        Console.WriteLine("DRCRL backwards");
                        Program.datamng.drive.backwards();
                    }


                    Program.datamng.drive.alt_turn(Program.datamng.Signal_2);
                    



                    Thread.Sleep(100);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("ERROR WHILE DIRECTCONTROLL_STEERING_AXIS");
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }
        }
    }
}