using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace surveillance
{
    class directcontroll_Panzer
    {


        public void x()
        {
            try
            {
                Console.WriteLine("DIRECTCONTROLL_Panzer ON");
                while (true)
                {
                    if (Program.datamng.Signal_2 == 1 && Program.datamng.Signal_1 == 1)
                    {
                        Program.datamng.antrieb.forwards();
                    }

                    if (Program.datamng.Signal_2 == 0 && Program.datamng.Signal_1 == 0)
                    {
                        Program.datamng.antrieb.stopp();
                    }

                    if (Program.datamng.Signal_2 == -1 && Program.datamng.Signal_1 == -1)
                    {
                        Program.datamng.antrieb.backwards();
                    }

                    if (Program.datamng.Signal_2 == 1 && Program.datamng.Signal_1 == -1)
                    {
                        Program.datamng.antrieb.turn_right();
                    }

                    if (Program.datamng.Signal_2 == -1 && Program.datamng.Signal_1 == 1)
                    {

                        Program.datamng.antrieb.turn_left();
                    }
                    Thread.Sleep(100);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("ERROR WHILE DIRECTCONTROLL_Panzer");
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }
        }
    }
}