using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace surveillance.Teile
{
    class directcontrol_panzer
    {
        public void drive()
        {
            while (true)
            {
                if (Program.datamng.thread_is_active_drive_with_Direct)
                {
                    Console.WriteLine("thread_is_active_drive_with_Direct ist nun aktiv");
                    if (Program.datamng.antriebsart == surveillance.Teile.Datenmanager.Antriebsart.Lenkachse)
                    {
                        Program.directcontroll_lenkachse.x();
                    }
                    else if (Program.datamng.antriebsart == surveillance.Teile.Datenmanager.Antriebsart.Panzer)
                    {
                        Program.directcontroll_panzer.x();
                    }
                }
                Thread.Sleep(100);
            }
        }
    }
}
