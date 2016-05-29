using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace surveillance
{
    class artificial_intelligence
    {

        public  void drive()
        {
            while (true)
            {
                if (Program.datamng.thread_is_active_drive_with_AI)
                {
                    Console.WriteLine("thread_is_active_drive_with_AI ist nun aktiv");
                    if (Program.datamng.steeringmode == Datenmanager.Steeringmode.steeringaxis)
                    {
                        Program.lenkachsen_ai.moves();
                    }
                    else if (Program.datamng.steeringmode == Datenmanager.Steeringmode.Tank)
                    {
                        Program.panzer_ai.moves();
                    }
                }
                Thread.Sleep(100);
            }
        }
    }
}
