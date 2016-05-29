//using Kingsland.PiFaceSharp.Spi;
using RaspberryPiDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raspberry.IO.GeneralPurpose;
using Raspberry.IO.GeneralPurpose.Behaviors;
using System.Threading;
using System.Globalization;
using WiringPi;



namespace surveillance
{
    public class Drive
    {
        #region old
        //byte right_forwards = 0;
        //byte right_backwards = 1;

        //byte left_forwards = 2;
        //byte left_backwards = 3;

        // GPIOMem Kanal_1;
        // GPIOMem Kanal_2;
        
        // GPIOMem Kanal_3;
        // GPIOMem Kanal_4;


        // String antriebs_a = "";

        // public void setup(String antriebsart)
        // {
        //     antriebs_a = antriebsart;

        //     Kanal_1 = new GPIOMem(GPIOPins.V2_GPIO_11);
        //     Kanal_2 = new GPIOMem(GPIOPins.V2_GPIO_09);

        //     Kanal_3 = new GPIOMem(GPIOPins.V2_GPIO_08);
        //     Kanal_4 = new GPIOMem(GPIOPins.V2_GPIO_25);


        // }


        //public void forwards()
        //{
        //    if (antriebs_a == "P")
        //    {
        //        Kanal_3.Write(true);
        //        Kanal_1.Write(true);

        //        Kanal_4.Write(false);
        //        Kanal_2.Write(false);

        //        Program.datamng.AI_linke_achse = 1;
        //        Program.datamng.AI_rechte_achse = 1;
        //    }
        //    else if (antriebs_a == "SA")
        //    {
        //        Kanal_3.Write(false);
        //        Kanal_4.Write(false);

        //        Kanal_1.Write(true);
        //        Kanal_2.Write(false);
        //    }


        //    //piface.SetOutputPinState(left_forwards, true);
        //    //piface.SetOutputPinState(left_backwards, false);

        //    //piface.SetOutputPinState(right_forwards, true);
        //    //piface.SetOutputPinState(right_backwards, false);

          
        //}

        //public void backwards()
        //{
        //    if (antriebs_a == "P")
        //    {

        //    Kanal_4.Write(true);
        //    Kanal_2.Write(true);

        //    Kanal_3.Write(false);
        //    Kanal_1.Write(false);

        //    Program.datamng.AI_linke_achse = -1;
        //    Program.datamng.AI_rechte_achse = -1;

        //    }
        //    else if (antriebs_a == "SA")
        //    {
        //        Kanal_3.Write(false);
        //        Kanal_4.Write(false);

        //        Kanal_1.Write(false);
        //        Kanal_2.Write(true);
        //    }

        ////    piface.SetOutputPinState(left_forwards, false);
        ////    piface.SetOutputPinState(left_backwards, true);

        ////    piface.SetOutputPinState(right_forwards, false);
        ////    piface.SetOutputPinState(right_backwards, true);
        //}

        //public void stopp()
        //{


        //    Kanal_3.Write(false);
        //    Kanal_1.Write(false);


        //    Kanal_4.Write(false);
        //    Kanal_2.Write(false);

        //    Program.datamng.AI_linke_achse = 0;
        //    Program.datamng.AI_rechte_achse = 0;
        //}

        //public void turn_right()
        //{
        //    if (antriebs_a == "P")
        //    {
        //        Kanal_3.Write(true);
        //        Kanal_1.Write(false);


        //        Kanal_4.Write(false);
        //        Kanal_2.Write(true);

        //        Program.datamng.AI_linke_achse = 1;
        //        Program.datamng.AI_rechte_achse = -1;

        //    }
        //    else if (antriebs_a == "SA")
        //    {
        //        Kanal_3.Write(false);
        //        Kanal_4.Write(true);

        //        Kanal_1.Write(false);
        //        Kanal_2.Write(false);
        //    }



           

        //    //piface.SetOutputPinState(left_forwards, true);
        //    //piface.SetOutputPinState(left_backwards, false);

        //    //piface.SetOutputPinState(right_forwards, false);
        //    //piface.SetOutputPinState(right_backwards, true);
        //}

        //public void turn_left()
        //{

        //    Kanal_3.Write(false);
        //    Kanal_1.Write(true);


        //    Kanal_4.Write(true);
        //    Kanal_2.Write(false);

        //    Program.datamng.AI_linke_achse = -1;
        //    Program.datamng.AI_rechte_achse = 1;

        //    //piface.SetOutputPinState(left_forwards, false);
        //    //piface.SetOutputPinState(left_backwards, true);

        //    //piface.SetOutputPinState(right_forwards, true);
        //    //piface.SetOutputPinState(right_backwards, false);
        //}
        #endregion old


        
        //schub
         OutputPinConfiguration pin3 = ConnectorPin.P1Pin11.Output();
         OutputPinConfiguration pin4 = ConnectorPin.P1Pin13.Output();

         OutputPinConfiguration pin1 = ConnectorPin.P1Pin05.Output();
         OutputPinConfiguration pin2 = ConnectorPin.P1Pin03.Output();

         GpioConnection connection;


       



         int pinstate_1 = 0;
         int pinstate_2 = 0;
         int pinstate_3 = 0;
         int pinstate_4 = 0;




         //int actual_poss = 0;

         static int old_poss = 0;

         int turn_value = 50;

         string mode;

         static int pin = 21;

         int i = 0;

         public void setup(string mode_)
         {
             try
             {
                 mode = mode_;
                 Console.WriteLine("Drive reports: Mode: " + mode_);


                 connection = new GpioConnection(pin1);
                 connection.Add(pin2);
                 connection.Add(pin3);
                 connection.Add(pin4);

                 Console.WriteLine("GPIO connection is up...");


                 if (connection.IsOpened)
                 {
                     Console.WriteLine("Drive reports: GPIO connected");
                     string pins = "";

                     foreach (ConnectedPin p in connection.Pins)
                     {
                         pins = pins + ":" + p.Configuration.Pin;
                     }
                     Console.WriteLine("Connected pins:" + pins);
                 }

                 ////Init.WiringPiSetupGpio();

                 ////WiringPi.GPIO.SoftPwm.Create(pin,13, 180);




                 //Console.WriteLine("WiringPI is up");
             }
             catch (Exception ex)
             {
                 Console.WriteLine("ERROR while GPIO connection was set up");
             }

         }



         public void forwards()
         {
             if (mode == "SA")
             {
                 accalerate(1);
                 Console.WriteLine("SA forwards");
             }
             else
             {
                 accalerate(3);
             }
        }

         public void backwards()
        {
            if (mode == "SA")
            {
                accalerate(-1);
            }
            else
            {
                accalerate(-3);
            }
        }

         public void stopp()
        {
            if (mode == "SA")
            {
                accalerate(0);
            }
            else
            {
                accalerate(4);
            }
        }

         public void turn_left()
         {
             if (mode == "SA")
             {
                 alt_turn(turn_value);
             }
             else
             {
                 accalerate(5);
             }

            
         }

         public void turn_right()
         {
             if (mode == "SA")
             {
                 alt_turn(-turn_value);
             }
             else
             {
                 accalerate(6);
             }
         }


      




          public void alt_turn(Int32 new_poss)
         {
             try
             {
                // Console.WriteLine("alt_turn new pos: " + new_poss);


                 if (new_poss == 0)
                 {
                     WiringPi.GPIO.SoftPwm.Write(pin, Convert.ToInt32(13));
                 }
                 else
                 {
                     if (new_poss > 0)
                     {
                         if (new_poss >= 16)
                         {
                             if (new_poss >= 32)
                             {
                                 WiringPi.GPIO.SoftPwm.Write(pin, Convert.ToInt32(16));
                             }
                             else
                             {
                                 WiringPi.GPIO.SoftPwm.Write(pin, Convert.ToInt32(15));
                             }
                         }
                         else
                         {
                             WiringPi.GPIO.SoftPwm.Write(pin, Convert.ToInt32(14));
                         }
                     }
                     else
                     {

                         if (new_poss <= -16)
                         {
                             if (new_poss <= -32)
                             {
                                 WiringPi.GPIO.SoftPwm.Write(pin, Convert.ToInt32(10));
                             }
                             else
                             {
                                 WiringPi.GPIO.SoftPwm.Write(pin, Convert.ToInt32(11));
                             }
                         }
                         else
                         {
                             WiringPi.GPIO.SoftPwm.Write(pin, Convert.ToInt32(12));
                         }

                     }
                 }


                 //Console.WriteLine(new_poss);






                 old_poss = new_poss;
                 //Console.WriteLine(old_poss + "->" + new_poss);

                 Thread.Sleep(100);
                 //}
             }
             catch (Exception ex)
             {
                 Console.WriteLine("While turning: " + ex.Message);
                 //Console.WriteLine("ERRORDATA: " + data);
             }

         }

         private void accalerate(int casenummber)
        {
          
            switch (casenummber)
            {
                    //steering axis
                case 0:
                    set_pin(pin3, 0, pinstate_3);
                    set_pin(pin4, 0, pinstate_4);
                    pinstate_3 = 0;
                    pinstate_4 = 0;
                    break;
                case 1:
                   // Console.WriteLine("Acc is in prog +...");
                    set_pin(pin3, 0, pinstate_3);
                    set_pin(pin4, 1, pinstate_4);
                    pinstate_3 = 0;
                    pinstate_4 = 1;
                    break;
                case -1:

                  //  Console.WriteLine("Acc is in prog -...");
                    set_pin(pin3, 1, pinstate_3);
                    set_pin(pin4, 0, pinstate_4);
                    pinstate_3 = 1;
                    pinstate_4 = 0;
                    break;



                    //TANK

                case 3:
                    set_pin(pin1, 1, pinstate_1);
                    set_pin(pin2, 1, pinstate_2);

                    set_pin(pin3, 0, pinstate_3);
                    set_pin(pin4, 0, pinstate_4);

                    pinstate_1 = 1;
                    pinstate_2 = 1;

                    pinstate_3 = 0;
                    pinstate_4 = 0;
                    break;

                case -3:
                    set_pin(pin1, 0, pinstate_1);
                    set_pin(pin2, 0, pinstate_2);

                    set_pin(pin3, 1, pinstate_3);
                    set_pin(pin4, 1, pinstate_4);

                    pinstate_1 = 0;
                    pinstate_2 = 0;

                    pinstate_3 = 1;
                    pinstate_4 = 1;
                    break;

                case 4:
                    set_pin(pin1, 0, pinstate_1);
                    set_pin(pin2, 0, pinstate_2);

                    set_pin(pin3, 0, pinstate_3);
                    set_pin(pin4, 0, pinstate_4);

                    pinstate_1 = 0;
                    pinstate_2 = 0;

                    pinstate_3 = 0;
                    pinstate_4 = 0;
                    break;

                case 5:
                    set_pin(pin1, 1, pinstate_1);
                    set_pin(pin2, 0, pinstate_2);

                    set_pin(pin3, 1, pinstate_3);
                    set_pin(pin4, 0, pinstate_4);

                    pinstate_1 = 1;
                    pinstate_2 = 0;

                    pinstate_3 = 1;
                    pinstate_4 = 0;
                    break;


                case 6:
                    set_pin(pin1, 0, pinstate_1);
                    set_pin(pin2, 1, pinstate_2);

                    set_pin(pin3, 0, pinstate_3);
                    set_pin(pin4, 1, pinstate_4);

                    pinstate_1 = 0;
                    pinstate_2 = 1;

                    pinstate_3 = 0;
                    pinstate_4 = 1;
                    break;
            }
        }

         private void set_pin(OutputPinConfiguration pin, int state_to_be, int pinstate)
        {
            if (pinstate != state_to_be)
            {
                connection.Toggle(pin);
            }
        }

    }
}
