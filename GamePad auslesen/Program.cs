using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GamePad_auslesen
{
    class Program
    {
        static void Main(string[] args)
        {
            GamePadState gpstate = GamePad.GetState(0);
            while (true)
            {
                gpstate = GamePad.GetState(0);
                while (true)
                {

                    string b = (GamePad.GetState(0).ThumbSticks.Left.X/ 2).ToString("0.00");

                    
                    float a = (float)Convert.ToDouble(b)*100;

                    Console.WriteLine(a);
                }
            }
        }
    }
}
