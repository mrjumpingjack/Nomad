using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Threading;

namespace newsender
{
    class Program
    {




        static void Main(string[] args)
        {

            GamePadState gpstate = GamePad.GetState(0);


            TcpListener server = null;
            try
            {
                // Set the TcpListener on port 13000.
                Int32 port = 13000;
                Console.WriteLine("my IP?");
                IPAddress localAddr = IPAddress.Parse(Console.ReadLine());
                //IPAddress localAddr = IPAddress.Parse("192.168.0.11");
                // TcpListener server = new TcpListener(port);
                server = new TcpListener(localAddr, port);

                // Start listening for client requests.
                server.Start();

                // Buffer for reading data
                Byte[] bytes = new Byte[256];
                //String data = null;

                // Enter the listening loop.
                while (true)
                {
                    Console.Write("Waiting for a connection... ");

                    // Perform a blocking call to accept requests.
                    // You could also user server.AcceptSocket() here.
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Connected!");

                    //data = null;

                    // Get a stream object for reading and writing
                    NetworkStream stream = client.GetStream();

                    int i;

                    // Loop to receive all the data sent by the client.
                    //while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    //{
                    //    // Translate data bytes to a ASCII string.
                    //    data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                    //    Console.WriteLine("Received: {0}", data);

                    //    // Process the data sent by the client.
                    //    data = data.ToUpper();

                    byte[] msg;

                    //    // Send back a response.
                    //    stream.Write(msg, 0, msg.Length);
                    //    Console.WriteLine("Sent: {0}", data);

                    string writendata = "0:0;0;0";
                    string writendataold = "";


                    float is_null = 0;

                    int trans_count = 0;
                    while (writendata != "bye")
                    {
                        // Console.WriteLine("Say:");




                        string b = (GamePad.GetState(0).ThumbSticks.Left.X / 2).ToString("0.00");


                        float a = (float)Convert.ToDouble(b) * 100;




                        writendata =
                            Convert.ToString(Convert.ToInt32(GamePad.GetState(0).Triggers.Right)) + ";" +
                            Convert.ToString(Convert.ToInt32(GamePad.GetState(0).Triggers.Left)) + ";" +
                            Convert.ToString(a) + "|";

                        is_null = a;

                        if (writendata != writendataold)
                        {
                            writendataold = writendata;

                            msg = System.Text.Encoding.ASCII.GetBytes(trans_count + ":" + writendata);
                            Console.WriteLine(writendata + " (" + msg.Length + ")" + " (" + trans_count + ")");


                            stream.Write(msg, 0, msg.Length);



                        }
                    }


                    //}

                    // Shutdown and end connection
                    client.Close();
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                // Stop listening for new clients.
                server.Stop();
            }


            Console.WriteLine("\nHit enter to continue...");
            Console.Read();
        }




    }
}
