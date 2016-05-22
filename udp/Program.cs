using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System.Threading;
using System.Text.RegularExpressions;
class Program
{
    static GamePadState gamepadState;

    static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.White;
           
            IPAddress send_to_address = IPAddress.Parse("127.0.0.1");
            Boolean done = false;
            Boolean exception_thrown = false;
            bool startup = true;
            #region comments
            // Create a socket object. This is the fundamental device used to network
            // communications. When creating this object we specify:
            // Internetwork: We use the internet communications protocol
            // Dgram: We use datagrams or broadcast to everyone rather than send to
            // a specific listener
            // UDP: the messages are to be formated as user datagram protocal.
            // The last two seem to be a bit redundant.
            #endregion
            Socket sending_socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram,
            ProtocolType.Udp);
            #region comments
            // create an address object and populate it with the IP address that we will use
            // in sending at data to. This particular address ends in 255 meaning we will send
            // to all devices whose address begins with 192.168.2.
            // However, objects of class IPAddress have other properties. In particular, the
            // property AddressFamily. Does this constructor examine the IP address being
            // passed in, determine that this is IPv4 and set the field. If so, the notes
            // in the help file should say so.
            #endregion
            gamepadState = GamePad.GetState(PlayerIndex.One);
            if (!gamepadState.IsConnected)
            {
                Console.WriteLine("!::::::::::::::::::::::::::::::::::::!\n\r!::::::GamePad is not connected::::::!\n\r!::::::::::::::::::::::::::::::::::::!\n\r\n\r");
            }
            
                Console.WriteLine("Enter 1 for IPAddress or 2 for hostname");
                int input;
                string input_s = Console.ReadLine();

                while (!(input_s == "1" | input_s == "2"))
                {

                    Console.WriteLine("!WRONG FORMAT! \r\nEnter 1 for IPAddress or 2 for hostname");
                    input_s = Console.ReadLine();
                }


                input = Convert.ToInt32(input_s);


                
               


                switch (input)
                {
                    case 1:
                        Console.WriteLine("Enter IPAddress");
                        String ip = Console.ReadLine();


                        Regex rgx = new Regex(@"^(?:[0-9]{1,3}\.){3}[0-9]{1,3}$");


                        while (!(rgx.IsMatch(ip)))
                        {

                            Console.WriteLine("!WRONG FORMAT! \r\nEnter IPAddress");
                            ip = Console.ReadLine();
                        }


                        
                        send_to_address = IPAddress.Parse(ip);
                        break;
                    case 2:
                        Console.WriteLine("Enter hostname");
                        String hostname = Console.ReadLine();
                        IPAddress[] ipaddress = Dns.GetHostAddresses(hostname);
                        break;
                    default:
                        Console.WriteLine("Empty or wrong input, ip set to localhost");
                        Console.Read();
                        break;
                }

           



            #region comments
            // IPEndPoint appears (to me) to be a class defining the first or final data
            // object in the process of sending or receiving a communications packet. It
            // holds the address to send to or receive from and the port to be used. We create
            // this one using the address just built in the previous line, and adding in the
            // port number. As this will be a broadcase message, I don't know what role the
            // port number plays in this.
            #endregion
            IPEndPoint sending_end_point = new IPEndPoint(send_to_address, 11000);
            #region comments
            // The below three lines of code will not work. They appear to load
            // the variable broadcast_string witha broadcast address. But that
            // address causes an exception when performing the send.
            //
            //string broadcast_string = IPAddress.Broadcast.ToString();
            //Console.WriteLine("broadcast_string contains {0}", broadcast_string);
            //send_to_address = IPAddress.Parse(broadcast_string);
            #endregion
            bool isold = false;
            string oldcommands = "0;0;0;0;0;0;0;0;0;0;0,0;0,0;0;0;0;0";

            if (startup == true)
            {
                string startupmessage = "sending to address: " + sending_end_point.Address + " port: "+sending_end_point.Port;
                byte[] send_buffer = Encoding.ASCII.GetBytes(startupmessage);

                startup = false;
            }







            while (!done)
            {


                string new_comands = get_comands();

                if (new_comands != oldcommands)
                {
                    oldcommands = new_comands;
                    byte[] send_buffer = Encoding.ASCII.GetBytes(new_comands);
                    Console.Beep();
                    isold = false;

                    // Remind the user of where this is going.
                    Console.WriteLine();
                    Console.WriteLine("sending to address: {0} port: {1}",sending_end_point.Address,sending_end_point.Port);
                    Console.WriteLine();
                    Console.WriteLine();
                    try
                    {
                        sending_socket.SendTo(send_buffer, sending_end_point);

                    }
                    catch (Exception send_exception)
                    {
                        exception_thrown = true;
                        Console.WriteLine(" Exception {0}", send_exception.Message);
                        Console.WriteLine();
                    }
                    if (exception_thrown == false)
                    {
                        Console.WriteLine(new_comands);
                    }
                    else
                    {
                        exception_thrown = false;
                        Console.WriteLine("The exception indicates the message was not sent.");
                    }
                }
                else
                {
                    if (isold == false)
                    {
                        isold = true;
                        Console.WriteLine("No new data...Expecting Input");
                        
                    }
                }
                //}
            } // end of while (!done)
        
    }


    static string get_comands()
    {

        string comands;
        try
        {
            gamepadState = GamePad.GetState(PlayerIndex.One);
            

            String button_a;
            String button_b;
            String button_y;
            String button_x;

            String dpad_up;
            String dpad_down;
            String dpad_right;
            String dpad_left;

            String r_stick_x;
            String l_stick_x;
            String r_stick_y;
            String l_stick_y;

            String r_stick_click;
            String l_stick_click;


            String r_trigger;
            String l_trigger;

            String r_schulter;
            String l_schulter;

            String big;
            String select;
            String start;

            if (gamepadState.Buttons.BigButton == ButtonState.Pressed)
            {
                big = "1";
            }
            else
            {
                big = "0";
            }

            if (gamepadState.Buttons.Back == ButtonState.Pressed)
            {
                select = "1";
            }
            else
            {
                select = "0";
            }

            if (gamepadState.Buttons.Start == ButtonState.Pressed)
            {
                start = "1";
            }
            else
            {
                start = "0";
            }


          
            
            if (gamepadState.Buttons.A == ButtonState.Pressed)
            {
                button_a = "1";
            }
            else
            {
                button_a = "0";
            }

            if (gamepadState.Buttons.B == ButtonState.Pressed)
            {
                button_b = "1";
            }
            else
            {
                button_b = "0";
            }

            if (gamepadState.Buttons.Y == ButtonState.Pressed)
            {
                button_y = "1";
            }
            else
            {
                button_y = "0";
            }

            if (gamepadState.Buttons.X == ButtonState.Pressed)
            {
                button_x = "1";
            }
            else
            {
                button_x = "0";
            }
            if (gamepadState.DPad.Down == ButtonState.Pressed)
            {
                dpad_down = "1";
            }
            else
            {
                dpad_down = "0";
            }

            if (gamepadState.DPad.Up == ButtonState.Pressed)
            {
                dpad_up = "1";
            }
            else
            {
                dpad_up = "0";
            }

            if (gamepadState.DPad.Right == ButtonState.Pressed)
            {
                dpad_right = "1";
            }
            else
            {
                dpad_right = "0";
            }

            if (gamepadState.DPad.Left == ButtonState.Pressed)
            {
                dpad_left = "1";
            }
            else
            {
                dpad_left = "0";
            }

            if (gamepadState.Buttons.RightStick == ButtonState.Pressed)
            {
                r_stick_click = "1";
            }
            else
            {
                r_stick_click = "0";
            }

            if (gamepadState.Buttons.LeftStick == ButtonState.Pressed)
            {
                l_stick_click = "1";
            }
            else
            {
                l_stick_click = "0";
            }

            if (gamepadState.Buttons.LeftShoulder == ButtonState.Pressed)
            {
                l_schulter = "1";
            }
            else
            {
                l_schulter = "0";
            }

            if (gamepadState.Buttons.RightShoulder == ButtonState.Pressed)
            {
                r_schulter = "1";
            }
            else
            {
                r_schulter = "0";
            }

            r_trigger = Convert.ToString(gamepadState.Triggers.Right);
            l_trigger = Convert.ToString(gamepadState.Triggers.Left);

            r_stick_y = Convert.ToString(gamepadState.ThumbSticks.Right.Y);
            r_stick_x = Convert.ToString(gamepadState.ThumbSticks.Right.X);

            l_stick_y = Convert.ToString(gamepadState.ThumbSticks.Left.Y);
            l_stick_x = Convert.ToString(gamepadState.ThumbSticks.Left.X);

            comands =
               button_a + ";" +         //0
               button_b + ";" +         //1
               button_y + ";" +         //2
               button_x + ";" +         //3
               dpad_up + ";" +          //4
               dpad_down + ";" +        //5
               dpad_right + ";" +       //6
               dpad_left + ";" +        //7
               r_schulter + ";" +       //8
               l_schulter + ";" +       //9

               r_stick_x + ";" +        //10
               r_stick_y + ";" +        //11
               l_stick_x + ";" +        //12
               l_stick_y + ";" +        //13


               r_stick_click + ";" +    //14
               l_stick_click + ";" +    //15
               l_trigger + ";" +        //16
               r_trigger + ";" +        //17

               big + ";" +              //18
               select + ";" +           //19
               start;                   //20


            return comands;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return "no comand";
        }
    }

}// end of class Program
