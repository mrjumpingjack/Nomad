using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;

using System.Threading;
using System.Text.RegularExpressions;
using RaspberryPiDotNet;
using Kingsland.PiFaceSharp.Spi;
class Program
{
    static GamePadState gamepadState;
    
    private const int listenPort = 11000;

    static double button_a;
    static double button_b;
    static double button_y;
    static double button_x;
    static double dpad_up;
    static double dpad_down;
    static double dpad_right;
    static double dpad_left;
    static decimal r_stick_x;
    static decimal r_stick_y;
    static decimal l_stick_x;
    static decimal l_stick_y;
    static double r_stick_click;
    static double l_stick_click;
    static double r_trigger;
    static double l_trigger;
    static double r_schulter;
    static double l_schulter;
    static double big;
    static double select;
    static double start;

    public static int Main()
    {

        Console.WriteLine("running");
        var piface = new PiFaceDevice();

       



        while (true)
        {
            try
            {
                gamepadState = GamePad.GetState(PlayerIndex.One);


                if (gamepadState.Buttons.A == ButtonState.Pressed)
                {
                    Console.WriteLine("a");
                }


                #region commands


                if (gamepadState.Buttons.BigButton == ButtonState.Pressed)
                {
                    big = 1;
                }
                else
                {
                    big = 0;
                }

                if (gamepadState.Buttons.Back == ButtonState.Pressed)
                {
                    select = 1;
                }
                else
                {
                    select = 0;
                }

                if (gamepadState.Buttons.Start == ButtonState.Pressed)
                {
                    start = 1;
                }
                else
                {
                    start = 0;
                }




                if (gamepadState.Buttons.A == ButtonState.Pressed)
                {
                    button_a = 1;
                }
                else
                {
                    button_a = 0;
                }

                if (gamepadState.Buttons.B == ButtonState.Pressed)
                {
                    button_b = 1;
                }
                else
                {
                    button_b = 0;
                }

                if (gamepadState.Buttons.Y == ButtonState.Pressed)
                {
                    button_y = 1;
                }
                else
                {
                    button_y = 0;
                }

                if (gamepadState.Buttons.X == ButtonState.Pressed)
                {
                    button_x = 1;
                }
                else
                {
                    button_x = 0;
                }
                if (gamepadState.DPad.Down == ButtonState.Pressed)
                {
                    dpad_down = 1;
                }
                else
                {
                    dpad_down = 0;
                }

                if (gamepadState.DPad.Up == ButtonState.Pressed)
                {
                    dpad_up = 1;
                }
                else
                {
                    dpad_up = 0;
                }

                if (gamepadState.DPad.Right == ButtonState.Pressed)
                {
                    dpad_right = 1;
                }
                else
                {
                    dpad_right = 0;
                }

                if (gamepadState.DPad.Left == ButtonState.Pressed)
                {
                    dpad_left = 1;
                }
                else
                {
                    dpad_left = 0;
                }

                if (gamepadState.Buttons.RightStick == ButtonState.Pressed)
                {
                    r_stick_click = 1;
                }
                else
                {
                    r_stick_click = 0;
                }

                if (gamepadState.Buttons.LeftStick == ButtonState.Pressed)
                {
                    l_stick_click = 1;
                }
                else
                {
                    l_stick_click = 0;
                }

                if (gamepadState.Buttons.LeftShoulder == ButtonState.Pressed)
                {
                    l_schulter = 1;
                }
                else
                {
                    l_schulter = 0;
                }

                if (gamepadState.Buttons.RightShoulder == ButtonState.Pressed)
                {
                    r_schulter = 1;
                }
                else
                {
                    r_schulter = 0;
                }

                r_trigger = Convert.ToInt32(gamepadState.Triggers.Right);
                l_trigger = Convert.ToInt32(gamepadState.Triggers.Left);

                r_stick_y = Convert.ToInt32(gamepadState.ThumbSticks.Right.Y);
                r_stick_x = Convert.ToInt32(gamepadState.ThumbSticks.Right.X);

                l_stick_y = Convert.ToInt32(gamepadState.ThumbSticks.Left.Y);
                l_stick_x = Convert.ToInt32(gamepadState.ThumbSticks.Left.X);




                #endregion commands

                int licht = 0;



                bool licht_brennt = false;
                bool arp = false;
                int dauerlicht = 1;


               Console.WriteLine(piface.GetInputPinState(1));




                #region gas
                

                if (Convert.ToInt32(r_trigger) == 0)
                {
                    piface.SetOutputPinState(0, false);
                }
                else
                {
                    piface.SetOutputPinState(0, true);
                }

                if (Convert.ToInt32(l_trigger) == 0)
                {
                    piface.SetOutputPinState(1, false);
                }
                else
                {
                    piface.SetOutputPinState(1, true);
                }

                #endregion gas

                #region lenken

                if (Convert.ToInt32(l_stick_x) == 0)
                {
                    piface.SetOutputPinState(3, false);
                    piface.SetOutputPinState(2, false);
                }

                if (Convert.ToInt32(l_stick_x) > 0)
                {
                    piface.SetOutputPinState(2, true);
                    piface.SetOutputPinState(3, false);
                }
                else
                {
                    piface.SetOutputPinState(2, false);
                }

                if (Convert.ToInt32(l_stick_x) < 0)
                {
                    piface.SetOutputPinState(3, true);
                    piface.SetOutputPinState(2, false);
                }
                else
                {
                    piface.SetOutputPinState(3, false);
                }


                #endregion lenken

                #region Licht

                if (Convert.ToInt32(button_a) == 1)
                {
                    piface.SetOutputPinState(5, true);
                }

                if (Convert.ToInt32(button_y) == 1)
                {
                    var state_l = true;
                    for (var j = 0; j < 50; j++)
                    {
                        piface.SetOutputPinState(5, state_l);
                        System.Threading.Thread.Sleep(25);
                        state_l = !state_l;
                    }
                }
                if (Convert.ToInt32(button_x) == 1)
                {
                    piface.SetOutputPinState(5, true);
                    piface.SetOutputPinState(6, true);

                }


                #endregion Licht


                if (Convert.ToInt32(start) == 1)
                {
                    for (byte pin = 0; pin < 8; pin++)
                    {
                        var state = true;
                        for (var i = 0; i < 50; i++)
                        {
                            piface.SetOutputPinState(pin, state);
                            System.Threading.Thread.Sleep(25);
                            state = !state;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }
    }
}
