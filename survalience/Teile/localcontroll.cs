using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MonoGame;
using MonoGame.Utilities;
using OpenTK.Input;

namespace surveillance
{
    class localcontroll
    {
        //Das Steuern des Fahrzeuges mit dem GamePad direkt am Fahrzeug ohne PC.

        public void local_con()
        {
            try
            {
                if (Program.datamng.thread_is_active_drive_with_Lokal)
                {
                    Console.WriteLine("thread_is_active_drive_with_Direct ist nun aktiv");
                    GamePadState gpstate = GamePad.GetState(0);




                    //Antrieb antrieb = new Antrieb();

                    Console.WriteLine("LOCALCONTROLL ON");

                    while (true)
                    {


                        if (GamePad.GetState(0).IsConnected == true)
                        {
                            if (GamePad.GetState(0).Triggers.Right > 1.0f &&
                                GamePad.GetState(0).Triggers.Left < 1.0f &&
                                GamePad.GetState(0).Buttons.RightShoulder == ButtonState.Released &&
                                GamePad.GetState(0).Buttons.LeftShoulder == ButtonState.Released)
                            {
                                Console.WriteLine("LOCALCONTROLL: Forwards");
                                Program.datamng.antrieb.forwards();
                            }

                            if (GamePad.GetState(0).Triggers.Right < 1.0f &&
                                GamePad.GetState(0).Triggers.Left > 1.0f &&
                                GamePad.GetState(0).Buttons.RightShoulder == ButtonState.Released &&
                                GamePad.GetState(0).Buttons.LeftShoulder == ButtonState.Released)
                            {
                                Console.WriteLine("LOCALCONTROLL: Backwards");
                                Program.datamng.antrieb.backwards();
                            }

                            if (GamePad.GetState(0).Triggers.Right < 1.0f &&
                                GamePad.GetState(0).Triggers.Left < 1.0f &&
                                GamePad.GetState(0).Buttons.RightShoulder == ButtonState.Pressed &&
                                GamePad.GetState(0).Buttons.LeftShoulder == ButtonState.Released)
                            {
                                Console.WriteLine("LOCALCONTROLL: Right");
                                Program.datamng.antrieb.turn_right();
                            }

                            if (GamePad.GetState(0).Triggers.Right < 1.0f &&
                                GamePad.GetState(0).Triggers.Left < 1.0f &&
                                GamePad.GetState(0).Buttons.RightShoulder == ButtonState.Released &&
                                GamePad.GetState(0).Buttons.LeftShoulder == ButtonState.Pressed)
                            {
                                Console.WriteLine("LOCALCONTROLL: Left");
                                Program.datamng.antrieb.turn_left();
                            }

                            if (GamePad.GetState(0).Triggers.Right < 1.0f &&
                                GamePad.GetState(0).Triggers.Left < 1.0f &&
                                GamePad.GetState(0).Buttons.RightShoulder == ButtonState.Released &&
                                GamePad.GetState(0).Buttons.LeftShoulder == ButtonState.Released)
                            {
                                Program.datamng.antrieb.stopp();
                            }

                            //Console.WriteLine("r_t " + GamePad.GetState(0).Triggers.Right);
                            //Console.WriteLine("l_t " + GamePad.GetState(0).Triggers.Left);
                            //Console.WriteLine("r_s " + GamePad.GetState(0).ThumbSticks.Right);
                            //Console.WriteLine("l_s " + GamePad.GetState(0).ThumbSticks.Left);




                        }
                        else
                        {
                            Console.WriteLine("LOCALCONTROLL: No GamePad detected!");

                        }

                        Thread.Sleep(100);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine("ERROR WHILE USING LOCALCONTROLL");
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }
        }
        
    }
}
