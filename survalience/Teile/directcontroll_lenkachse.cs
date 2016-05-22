using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace surveillance
{
    class directcontroll_Lenkachse
    {
        

        public void x()
        {
            try
            {
                Console.WriteLine("DIRECTCONTROLL_Lenkachse ON");
                while (true)
                {
                    if (Program.datamng.Signal_1 == 1)
                    {
                        Console.WriteLine("DRCRL forwards");
                        Program.datamng.antrieb.forwards();
                    }

                    if (Program.datamng.Signal_1 == 0 )
                    {
                        Program.datamng.antrieb.stopp();
                    }

                    if (Program.datamng.Signal_1 == -1)
                    {
                        Console.WriteLine("DRCRL backwards");
                        Program.datamng.antrieb.backwards();
                    }


                    Program.datamng.antrieb.alt_turn(Program.datamng.Signal_2);
                    



                    Thread.Sleep(100);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("ERROR WHILE DIRECTCONTROLL_Lenkachse");
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }
        }
    }
}