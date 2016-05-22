using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beeptest
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {

                Console.Beep(600, 200);
                Console.Beep(500, 200);
                Console.Beep(400, 200);
                Console.Beep(300, 200);
                Console.Beep(200, 200);

            }

        }
    }
}
