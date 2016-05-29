using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace surveillance
{
    class directcontrol_tank
    {
        public void drive()
        {
            while (true)
            {
                if (Program.datamng.thread_is_active_drive_with_Direct)
                {
                    Console.WriteLine("thread_is_active_drive_with_Direct is now activ");
                    if (Program.datamng.steeringmode == Datenmanager.Steeringmode.steeringaxis)
                    {
                        Program.directcontroll_lenkachse.x();
                    }
                    else if (Program.datamng.steeringmode == Datenmanager.Steeringmode.Tank)
                    {
                        Program.directcontroll_panzer.x();
                    }
                }
                Thread.Sleep(100);
            }
        }

        public void x()
        {
            try
            {
                Console.WriteLine("DIRECTCONTROLL_Tank ON");
                while (true)
                {
                    if (Program.datamng.Signal_2 == 1 && Program.datamng.Signal_1 == 1)
                    {
                        Program.datamng.drive.forwards();
                    }

                    if (Program.datamng.Signal_2 == 0 && Program.datamng.Signal_1 == 0)
                    {
                        Program.datamng.drive.stopp();
                    }

                    if (Program.datamng.Signal_2 == -1 && Program.datamng.Signal_1 == -1)
                    {
                        Program.datamng.drive.backwards();
                    }

                    if (Program.datamng.Signal_2 == 1 && Program.datamng.Signal_1 == -1)
                    {
                        Program.datamng.drive.turn_right();
                    }

                    if (Program.datamng.Signal_2 == -1 && Program.datamng.Signal_1 == 1)
                    {

                        Program.datamng.drive.turn_left();
                    }
                    Thread.Sleep(100);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("ERROR WHILE DIRECTCONTROLL_Tank");
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }
        }


    }
}
