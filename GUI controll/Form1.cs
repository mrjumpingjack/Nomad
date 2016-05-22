using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;


using System.Text.RegularExpressions;
using System.Threading;
using GMap.NET.WindowsForms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms.Markers;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;

using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System.Globalization;




namespace GUI_controll
{
    public partial class Form1 : Form
    {
        #region ini

        GMapOverlay overlayOne;

        private const int listenPort = 11000;

        GMapRoute activeroute;
        PointLatLng last_car_point;
        PointLatLng clicked_point;
        PointLatLng local_targetpoint;


        IPAddress ipAd = IPAddress.Parse("192.168.0.11");
        TcpListener myList;
        Socket socket;

        int[] distances = new int[4];
        bool center_on_new_point = false;

        bool geo_isready = true;
        bool sonic_isready = true;
        bool compass_isready = true;
        bool antrieb_isready = true;
        bool route_isready = true;
        bool axes_isready = true;
        bool temp_isready = true;


        Thread th_background;


        bool connected = false;

        Compass compass = new Compass();

        static string new_comands;
        static string old_comands;


        GamePadState gamepadState;
        Einstellungen einstellungen = new Einstellungen();

        string lenkmodus;
        List<CheckBox> cbl = new List<CheckBox>();


        bool bgrisrunning = false;
        specomms sc = new specomms();





        #endregion ini

        public Form1()
        {
            InitializeComponent();

            this.Load += new EventHandler(Form1_Load);



        }

        [DllImport("USER32.DLL")]

        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        [DllImport("USER32.dll")]

        private static extern bool MoveWindow(IntPtr hwnd, int x, int y, int cx, int cy, bool repaint);


        Thread get_specomms_thread;

        bool setup_finnished = false;


        private void Form1_Load(object sender, EventArgs e)
        {
            if (setup_finnished == false)
            {
                btn_manuel.Enabled = false;
                rb_autopilot.Enabled = false;
                rb_directcontrol.Enabled = false;
                rb_idle.Enabled = false;
                rb_lokalcontrol.Enabled = false;


                einstellungen.load_settings();

                cbl = einstellungen.cbl;
                lenkmodus = einstellungen.lenkmodus;


                webKitBrowser1.Navigate("http://192.168.0.10/html/");

                get_specomms_thread = new Thread(send_sepc_comms);
                get_specomms_thread.Start();

                setup_finnished = true;
            }

        }



        public string add_to_listbox(string text)
        {
            if (this.InvokeRequired)
            { // Wenn Invoke nötig ist, ...
                // dann rufen wir die Methode selbst per Invoke auf
                return (string)this.Invoke((Func<string, string>)add_to_listbox, text);
                // hier ist immer ein return (oder alternativ ein else) erforderlich.
                // Es verhindert, dass der folgende Code im Worker-Thread ausgeführt wird.
            }
            // eigentliche Zugriffe; laufen jetzt auf jeden Fall im GUI-Thread


            //return cancelCheckBox.Checked; // lesender Zugriff
            return text;
        }






        string old_comms = "";

        public void send_sepc_comms()
        {
            while (true)
            {
                try
                {
                    string[] result = get_special_commands().Select(x => x.ToString()).ToArray();

                    string senddata_data = "SC,";
                    foreach (string sc in result)
                    {
                        senddata_data = senddata_data + sc + ",";
                    }
                    senddata_data = senddata_data.Substring(0, senddata_data.Length - 1);

                    if (old_comms != senddata_data)
                    {
                        send_data(senddata_data);

                        old_comms = senddata_data;

                        Console.WriteLine(senddata_data);
                        senddata_data = "";

                    }
                    Thread.Sleep(500);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR while send_specomms");
                }
            }
        }




        int[] get_special_commands()
        {
            int[] comm = new int[11];

            gamepadState = GamePad.GetState(PlayerIndex.One);


            if (gamepadState.Buttons.A == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
            {
                comm[0] = 1;
            }
            else
            {
                comm[0] = 0;
            }

            if (gamepadState.Buttons.B == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
            {
                comm[1] = 1;
            }
            else
            {
                comm[1] = 0;
            }

            if (gamepadState.Buttons.X == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
            {
                comm[2] = 1;
            }
            else
            {
                comm[2] = 0;
            }

            if (gamepadState.Buttons.Y == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
            {
                comm[3] = 1;
            }
            else
            {
                comm[3] = 0;
            }



            if (gamepadState.DPad.Down == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
            {
                comm[4] = 1;
            }
            else
            {
                comm[4] = 0;
            }
            if (gamepadState.DPad.Up == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
            {
                comm[5] = 1;
            }
            else
            {
                comm[5] = 0;
            }
            if (gamepadState.DPad.Left == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
            {
                comm[6] = 1;
            }
            else
            {
                comm[6] = 0;
            }
            if (gamepadState.DPad.Right == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
            {
                comm[7] = 1;
            }
            else
            {
                comm[7] = 0;
            }

            if (gamepadState.Buttons.Start == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
            {
                comm[8] = 1;
            }
            else
            {
                comm[8] = 0;
            }

            if (gamepadState.Buttons.Back == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
            {
                comm[9] = 1;
            }
            else
            {
                comm[9] = 0;
            }

            if (gamepadState.Buttons.BigButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
            {
                comm[10] = 1;
            }
            else
            {
                comm[10] = 0;
            }






            return comm;

        }

























        public void send_data(string data)
        {
            try
            {
                if (!object.Equals(socket, null))
                {
                    if (socket.IsBound)
                    {
                        verlaufGUIaccess(data);
                        ASCIIEncoding asen = new ASCIIEncoding();
                        socket.Send(asen.GetBytes(data));
                        string ass = "Send: " + data;
                        add_to_listbox(ass);
                        //listBox2.Items.Add("Send: " + data);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("while sending data: " + ex.Message);
            }
        }

        //liest Gamepadeingaben aus

        private void button2_Click(object sender, EventArgs e)
        {
            //socket.Close();
            // myList.Stop();
            if (socket != null)
            {
                if (socket.IsBound)
                {
                    socket.Disconnect(true);
                }
                else
                {
                    MessageBox.Show("Es besteht keine Verbinndung");
                }

                l_status.Text = "offline";
            }
            else
            {
                MessageBox.Show("Es besteht keine Verbinndung");
            }
        }



        private void mapexplr_Load_1(object sender, EventArgs e)
        {

            mapexplr.SetPositionByKeywords("Stadthagen, Teichstraße 57");

            mapexplr.MapProvider = GMapProviders.GoogleMap;
            mapexplr.MinZoom = 3;
            mapexplr.MaxZoom = 20;
            mapexplr.Zoom = 19;
            mapexplr.Manager.Mode = AccessMode.ServerAndCache;
            mapexplr.DragButton = MouseButtons.Left;

            overlayOne = new GMapOverlay("OverlayOne");

            overlayOne.Markers.Add(new GMap.NET.WindowsForms.Markers.GMarkerCross(new PointLatLng(36.657403, 10.327148)));

            mapexplr.Overlays.Add(overlayOne);
        }

        //void add_point(double Lat, double Lng)
        //{
        //    mapexplr.Overlays.Remove(overlayOne);
        //    GMarkerCross marker = new GMap.NET.WindowsForms.Markers.GMarkerCross(new PointLatLng(Lat, Lng));
        //    marker.Size = new System.Drawing.Size(2, 2);
        //    overlayOne.Markers.Add(marker);
        //    mapexplr.Overlays.Add(overlayOne);

        //    if (center_on_new_point)
        //    {
        //        mapexplr.Position = marker.Position;
        //        mapexplr.Zoom = 19;
        //    }

        //}

        void add_point(double Lat, double Lng, GMarkerGoogleType style, string tag)
        {
            mapexplr.Overlays.Remove(overlayOne);
            GMarkerGoogle marker = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(new PointLatLng(Lat, Lng), style);

            if (style == GMarkerGoogleType.pink)
            {

            }

            marker.Tag = tag;
            overlayOne.Markers.Add(marker);
            mapexplr.Overlays.Add(overlayOne);

            if (center_on_new_point)
            {
                mapexplr.Position = marker.Position;
                mapexplr.Zoom = 19;
            }

        }


        private void Form1_Shown(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisY.Maximum = 3000;
            chart1.ChartAreas[0].AxisY.Minimum = -3000;
        }



        public string verlaufGUIaccess(string text)
        {
            if (this.InvokeRequired)
            { // Wenn Invoke nötig ist, ...
                // dann rufen wir die Methode selbst per Invoke auf
                return (string)this.Invoke((Func<string, string>)verlaufGUIaccess, text);
                // hier ist immer ein return (oder alternativ ein else) erforderlich.
                // Es verhindert, dass der folgende Code im Worker-Thread ausgeführt wird.
            }
            // eigentliche Zugriffe; laufen jetzt auf jeden Fall im GUI-Thread
            listBox2.Items.Add(DateTime.Now + ": " + text); // schreibender Zugriff
            if (checkBox1.Checked)
            {
                listBox2.SelectedIndex = listBox2.Items.Count - 1;
                listBox2.SelectedIndex = -1;
            }

            //return cancelCheckBox.Checked; // lesender Zugriff
            return text;
        }


        public string showMSGBox(string text, string caption, MessageBoxIcon icon, MessageBoxButtons buttons)
        {
            try
            {
                if (this.InvokeRequired)
                { // Wenn Invoke nötig ist, ...
                    // dann rufen wir die Methode selbst per Invoke auf
                    return (string)this.Invoke((Func<string, string>)verlaufGUIaccess, text);
                    // hier ist immer ein return (oder alternativ ein else) erforderlich.
                    // Es verhindert, dass der folgende Code im Worker-Thread ausgeführt wird.
                }
                // eigentliche Zugriffe; laufen jetzt auf jeden Fall im GUI-Thread
                MessageBox.Show(this, text, caption, buttons, icon);

                //return cancelCheckBox.Checked; // lesender Zugriff
                return text;
            }
            catch (Exception ex)
            {
                return text;
            }
        }


        public string setantriebGUI(string text)
        {
            if (this.InvokeRequired)
            { // Wenn Invoke nötig ist, ...
                // dann rufen wir die Methode selbst per Invoke auf
                return (string)this.Invoke((Func<string, string>)verlaufGUIaccess, text);
                // hier ist immer ein return (oder alternativ ein else) erforderlich.
                // Es verhindert, dass der folgende Code im Worker-Thread ausgeführt wird.
            }
            // eigentliche Zugriffe; laufen jetzt auf jeden Fall im GUI-Thread
            vScrollBar1.Value = Convert.ToInt32(text.Split(',')[0]) * 100;
            vScrollBar2.Value = Convert.ToInt32(text.Split(',')[1]) * 100;

            //return cancelCheckBox.Checked; // lesender Zugriff
            return text;
        }

        public string settemplabel(string text)
        {
            if (this.InvokeRequired)
            { // Wenn Invoke nötig ist, ...
                // dann rufen wir die Methode selbst per Invoke auf
                return (string)this.Invoke((Func<string, string>)settemplabel, text);
                // hier ist immer ein return (oder alternativ ein else) erforderlich.
                // Es verhindert, dass der folgende Code im Worker-Thread ausgeführt wird.
            }
            // eigentliche Zugriffe; laufen jetzt auf jeden Fall im GUI-Thread
            l_temp.Text = text;

            //return cancelCheckBox.Checked; // lesender Zugriff
            return text;
        }


        public double[] setmagmet(double[] i_data)
        {
            if (this.InvokeRequired)
            { // Wenn Invoke nötig ist, ...
                // dann rufen wir die Methode selbst per Invoke auf
                return (double[])this.Invoke((Func<double[], double[]>)setmagmet, i_data);
                // hier ist immer ein return (oder alternativ ein else) erforderlich.
                // Es verhindert, dass der folgende Code im Worker-Thread ausgeführt wird.
            }
            // eigentliche Zugriffe; laufen jetzt auf jeden Fall im GUI-Thread


            chart1.Series["Series1"].Points.DataBindY(i_data);
            //chart1.Series["Series1"].Points[1].SetValueY(i_data[1]);
            //chart1.Series["Series1"].Points[2].SetValueY(i_data[2]);
            chart1.Refresh();

            //return cancelCheckBox.Checked; // lesender Zugriff
            return i_data;
        }




        public PointLatLng addpointtomap(PointLatLng point)
        {
            if (this.InvokeRequired)
            {
                return (PointLatLng)this.Invoke((Func<PointLatLng, PointLatLng>)addpointtomap, point);
            }

            add_point(point.Lat, point.Lng, GMarkerGoogleType.blue_dot, "HERE I AM");
            label12.Text = "Last point: " + point;
            return point;
        }

        public PointLatLng confirm_target_point(PointLatLng point)
        {
            if (this.InvokeRequired)
            {
                return (PointLatLng)this.Invoke((Func<PointLatLng, PointLatLng>)confirm_target_point, point);
            }

            for (int i = 0; i < overlayOne.Markers.Count; i++)
            {
                if (overlayOne.Markers[i].Tag == "TARGET")
                {
                    overlayOne.Markers.RemoveAt(i);
                }
            }

            add_point(point.Lat, point.Lng, GMarkerGoogleType.green, "TARGET");
            //label12.Text = "Last point: " + point;
            return point;
        }


        public PointLatLng show_next_route_point(PointLatLng point)
        {
            if (this.InvokeRequired)
            {
                return (PointLatLng)this.Invoke((Func<PointLatLng, PointLatLng>)show_next_route_point, point);
            }

            for (int i = 0; i < overlayOne.Markers.Count; i++)
            {
                if (overlayOne.Markers[i].Tag == "TARGET")
                {
                    overlayOne.Markers.RemoveAt(i);
                }
            }

            add_point(point.Lat, point.Lng, GMarkerGoogleType.pink, "TARGET");
            //label12.Text = "Last point: " + point;
            return point;
        }




        public int[] set_distance_gui(int[] dis)
        {
            try
            {
                int error_value = -1;

                if (this.InvokeRequired)
                { // Wenn Invoke nötig ist, ...
                    // dann rufen wir die Methode selbst per Invoke auf
                    return (int[])this.Invoke((Func<int[], int[]>)set_distance_gui, dis);
                    // hier ist immer ein return (oder alternativ ein else) erforderlich.
                    // Es verhindert, dass der folgende Code im Worker-Thread ausgeführt wird.
                }
                // eigentliche Zugriffe; laufen jetzt auf jeden Fall im GUI-Thread
                if (dis[0] > error_value)
                {
                    if (dis[0] == 0)
                    {
                        tb_left_vorn.Value = tb_left_vorn.Maximum;
                    }
                    else
                    {
                        tb_left_vorn.Value = dis[0];
                    }
                }
                else
                {
                    l_left_vorn.Text = "ERROR";
                }

                if (dis[1] > error_value)
                {
                    if (dis[1] == 0)
                    {
                        tb_front.Value = tb_front.Maximum;
                    }
                    else
                    {
                        tb_front.Value = dis[1];
                    }
                }
                else
                {
                    l_front.Text = "ERROR";
                }

                if (dis[2] > error_value)
                {
                    if (dis[2] == 0)
                    {
                        tb_right_vorn.Value = tb_right_vorn.Maximum;
                    }
                    else
                    {
                        tb_right_vorn.Value = dis[2];
                    }
                }
                else
                {
                    l_right_vorn.Text = "ERROR";
                }

                if (dis[3] > error_value)
                {
                    if (dis[3] == 0)
                    {
                        tb_right_hinten.Value = tb_right_hinten.Maximum;
                    }
                    else
                    {
                        tb_right_hinten.Value = dis[3];
                    }
                }
                else
                {
                    l_right_hinten.Text = "ERROR";
                }

                if (dis[4] > error_value)
                {
                    if (dis[4] == 0)
                    {
                        tb_back.Value = tb_back.Minimum;
                    }
                    else
                    {
                        tb_back.Value = -dis[4];
                    }
                }
                else
                {
                    l_back.Text = "ERROR";
                }

                if (dis[5] > error_value)
                {
                    if (dis[5] == 0)
                    {
                        tb_left_hinten.Value = tb_left_hinten.Maximum;
                    }
                    else
                    {
                        tb_left_hinten.Value = dis[5];
                    }
                }
                else
                {
                    l_left_hinten.Text = "ERROR";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR while updating GUI: " + ex.Message);
            }

            //return cancelCheckBox.Checked; // lesender Zugriff
            return dis;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {

                if (myList == null)
                {
                    myList = new TcpListener(ipAd, 8070);
                    myList.Start();
                }

                Console.WriteLine("The server is running at port 8070...");
                Console.WriteLine("The local End point is  :" + myList.LocalEndpoint);
                Console.WriteLine("Waiting for a connection.....");

                bool pending = myList.Pending();


                while (!pending)
                {
                    Application.DoEvents();
                    progressBar1.Style = ProgressBarStyle.Marquee;
                    pending = myList.Pending();

                    UseWaitCursor = true;



                }

                progressBar1.Style = ProgressBarStyle.Blocks;

                UseWaitCursor = false;

                if (pending)
                {
                    socket = myList.AcceptSocket();
                }
                else
                {
                    MessageBox.Show("Es konnte kein Vehicle gefunden werden. Prüfen Sie ob das Vehicle eine Verbinndung angefordert hat", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (socket.IsBound)
                {
                    connected = true;
                    Console.WriteLine("Connection accepted from " + socket.RemoteEndPoint);

                    // l_connceted_to.Text = "Connection accepted from " + socket.RemoteEndPoint;
                    verlaufGUIaccess("Connection accepted from " + socket.RemoteEndPoint);

                    l_status.Text = "connected to: " + socket.RemoteEndPoint;



                    rb_autopilot.Enabled = true;
                    rb_directcontrol.Enabled = true;
                    rb_idle.Enabled = true;
                    rb_lokalcontrol.Enabled = true;
                    btn_manuel.Enabled = true;


                    //get_specomms_thread.Start();




                    send_idle();
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("While esteblishing connection: " + ex.Message);
            }

            try
            {




                th_background = new Thread(background);

                th_background.Start();



                pictureBox12.Image = Compass.DrawCompass(0, 0, 80, 0, 80, pictureBox12.Size);





            }
            catch (Exception ex)
            {
                Console.WriteLine("While calling Background thread: " + ex.Message);
            }


            // MessageBox.Show("connected to: " + socket.RemoteEndPoint);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            send_data(comboBox1.Text);

        }

        private void background()
        {


            byte[] b;
            int k;
            string text;

            while (true)
            {
                try
                {
                    text = "";
                    if (myList == null)
                    {
                        myList = new TcpListener(ipAd, 8070);
                        myList.Start();
                    }
                    if (connected)
                    {
                        b = new byte[1024];
                        k = socket.Receive(b);
                        Console.WriteLine("Recieved...");
                        for (int i = 0; i < k; i++)
                        {
                            text = text + Convert.ToChar(b[i]);
                        }


                        Console.WriteLine(text);

                        if (text.StartsWith("%GPS%"))
                        {
                            Console.WriteLine("Recieved GPS: " + text);
                            if (geo_isready)
                            {
                                geo_isready = false;
                                dealwithgeodata(text);
                                //Thread.Sleep(100);
                                geo_isready = true;
                            }
                        }

                        if (text.StartsWith("%SONIC%"))
                        {
                            Console.WriteLine("Recieved SONIC: " + text);
                            if (sonic_isready)
                            {
                                sonic_isready = false;
                                dealwithsonicdata(text);
                                //Thread.Sleep(100);
                                sonic_isready = true;
                            }
                        }

                        if (text.StartsWith("%COMPASS%"))
                        {
                            Console.WriteLine("Recieved COMPASS: " + text);
                            if (compass_isready)
                            {
                                compass_isready = false;
                                dealwithcompassdata(text);
                                // Thread.Sleep(100);
                                compass_isready = true;
                            }
                        }

                        if (text.StartsWith("%ANTRIEB%"))
                        {
                            Console.WriteLine("Recieved ANTRIEB: " + text);
                            if (antrieb_isready)
                            {
                                antrieb_isready = false;
                                dealwithantriebdata(text);
                                // Thread.Sleep(100);
                                antrieb_isready = true;
                            }
                        }

                        if (text.StartsWith("%ROUTE%"))
                        {
                            Console.WriteLine("Recieved ROUTE: " + text);
                            if (route_isready)
                            {
                                route_isready = false;
                                dealwithroutedata(text);
                                // Thread.Sleep(100);
                                route_isready = true;
                            }
                        }

                        if (text.StartsWith("%AXES%"))
                        {
                            Console.WriteLine("Recieved AXIS: " + text);
                            if (axes_isready)
                            {
                                axes_isready = false;
                                dealwithaxesdata(text);
                                // Thread.Sleep(100);
                                axes_isready = true;
                            }


                        }

                        if (text.StartsWith("%TEMP%"))
                        {
                            Console.WriteLine("Recieved TEMP: " + text);
                            if (temp_isready)
                            {
                                temp_isready = false;
                                dealwithtempdata(text);
                                // Thread.Sleep(100);
                                temp_isready = true;
                            }


                        }

                    }


                }
                catch (Exception ex)
                {

                    Console.WriteLine("Backgroundthread: " + ex.Message, "ERROR", MessageBoxIcon.Error, MessageBoxButtons.OK);
                    continue;
                }
            }

        }




        float temp_correction = -3.9f;




        void dealwithtempdata(string data)
        {

            NumberFormatInfo provider = new NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";

            data = data.Substring(6, data.Length - 6);

            float f_data = (float)Convert.ToDouble(data, provider);

            f_data = f_data + temp_correction;
            settemplabel(Convert.ToString(f_data));

            verlaufGUIaccess(data);

            if (f_data > 50)
            {

                Console.Beep(600, 200);
                Console.Beep(500, 200);
                Console.Beep(400, 200);
                Console.Beep(300, 200);
                Console.Beep(200, 200);

            }


        }

        string RemoveWhitespace(string input)
        {
            return new string(input.ToCharArray()
                .Where(c => !Char.IsWhiteSpace(c))
                .ToArray());
        }


        void dealwithantriebdata(string data)
        {
            setantriebGUI(data);
            verlaufGUIaccess(data);
        }

        void dealwithroutedata(string data)
        {
            data = data.Substring(7, data.Length - 7);

            string point = data.Split(',')[0];
            string arg = data.Split(',')[1];



            if (arg == "Confirm")
            {
                PointLatLng target_auto = new PointLatLng(double.Parse(point.Split(';')[0], System.Globalization.CultureInfo.InvariantCulture), double.Parse(point.Split(';')[1], System.Globalization.CultureInfo.InvariantCulture));

                if (Math.Round(local_targetpoint.Lat, 10) == Math.Round(target_auto.Lat, 10) && Math.Round(local_targetpoint.Lng, 10) == Math.Round(target_auto.Lng, 10))
                {
                    for (int i = 0; i < overlayOne.Markers.Count; i++)
                    {
                        if (overlayOne.Markers[i].Tag == "TARGET")
                        {
                            confirm_target_point(overlayOne.Markers[i].Position);
                        }
                    }
                }
            }

            if (arg == "Route")
            {
                PointLatLng target_auto = new PointLatLng(double.Parse(point.Split(';')[0], System.Globalization.CultureInfo.InvariantCulture), double.Parse(point.Split(';')[1], System.Globalization.CultureInfo.InvariantCulture));

                show_next_route_point(target_auto);
            }
        }


        void dealwithsonicdata(string data)
        {
            //0=6;1=10;2=151;3=7;



            if (data.Length > 10)
            {
                data = data.Substring(data.IndexOf('%') + 1, data.Length - (data.IndexOf(':') + 2));




                int[] data_ = new int[8];

                for (int i = 1; i < data.Split(',').Length - 2; i++)
                {
                    try
                    {
                        string ass = data.Split(',')[i];
                        ass = ass.Substring(ass.IndexOf('=') + 1, ass.Length - (ass.IndexOf('=') + 1));





                        data_[i - 1] = Convert.ToInt32(ass);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("SONIC ERROR: " + ex.Message + ":" + data);
                        continue;
                    }
                }

                set_distance_gui(data_);
                verlaufGUIaccess(data);
            }


        }

        private void dealwithgeodata(string data)
        {
            try
            {
                //$GPGLL,4916.45,N,12311.12,W,225444,A
                data = data.Substring(5, data.Length - 5);

                data = Grad_Dezimalminuten_to_Grad_Minuten_Sekunden(data);

                string lat = data.Split(',')[0];
                string lng = data.Split(',')[1];

                last_car_point = new PointLatLng(double.Parse(lat, System.Globalization.CultureInfo.InvariantCulture), double.Parse(lng, System.Globalization.CultureInfo.InvariantCulture));
                addpointtomap(last_car_point);
                verlaufGUIaccess("CAR is here: " + lat + "," + lng);
            }
            catch (Exception ex)
            {
                Console.WriteLine("GEO ERROR WITH :" + data);
                Console.WriteLine("GEO ERROR :" + ex.Message);
            }
        }

        static double oriantation = 0;
        private void dealwithcompassdata(String data)
        {
            try
            {
                oriantation = double.Parse(data.Substring(9, data.Length - 9), System.Globalization.CultureInfo.InvariantCulture);
                pictureBox12.Image = Compass.DrawCompass(oriantation, 0, 80, 0, 80, pictureBox12.Size);

                rotate_map((float)oriantation);

                verlaufGUIaccess("CAR is facing: " + Convert.ToString(oriantation));
            }
            catch (Exception ex)
            {
                Console.WriteLine("COMPASS ERROR: " + ex.Message);
            }
        }

        //"%AXES%0,0,0"


        double[] standart_stellung = new double[3];




        void dealwithaxesdata(string data)
        {
            Console.WriteLine("AXES: " + data);

            try
            {
                //int[]data_= Array.ConvertAll(data.Split(new char[] { ',' }), s => int.Parse(s));



                data = data.Substring(6, data.Length - 6);

                string[] data_ = data.Split(new char[] { ',' });
                double[] i_data = new double[3];

                for (int i = 0; i < data_.Length; i++)
                {
                    i_data[i] = Convert.ToDouble(data_[i]);
                }

                if (standart_stellung[0] == 0)
                {
                    standart_stellung[0] = i_data[0];
                    standart_stellung[1] = i_data[1];
                    standart_stellung[2] = i_data[2];
                }


                for (int id = 0; id < 3; id++)
                {
                    i_data[id] = Math.Abs(standart_stellung[id] - i_data[id]);

                    if (i_data[id] < standart_stellung[id])
                    {
                        i_data[id] = i_data[id] * -1;
                    }


                    setmagmet(i_data);

                    if (Math.Abs(i_data[id]) > 2000)
                    {
                        if (akustischeWarnungenToolStripMenuItem.Checked)
                        {
                            Console.Beep(500, 1000);
                            Console.Beep(1000, 1000);

                            Console.Beep(500, 1000);
                            Console.Beep(1000, 1000);

                            Console.Beep(500, 1000);
                            Console.Beep(1000, 1000);
                        }
                    }

                    verlaufGUIaccess(data);
                }






            }
            catch (Exception ex)
            {
                Console.WriteLine("AXES ERROR: " + ex.Message);
            }
        }



        public float rotate_map(float value)
        {
            if (this.InvokeRequired)
            { // Wenn Invoke nötig ist, ...
                // dann rufen wir die Methode selbst per Invoke auf
                return (float)this.Invoke((Func<float, float>)rotate_map, value);
                // hier ist immer ein return (oder alternativ ein else) erforderlich.
                // Es verhindert, dass der folgende Code im Worker-Thread ausgeführt wird.
            }
            // eigentliche Zugriffe; laufen jetzt auf jeden Fall im GUI-Thread
            mapexplr.Bearing = value;


            //return cancelCheckBox.Checked; // lesender Zugriff
            return value;
        }






        private string Grad_Dezimalminuten_to_Grad_Minuten_Sekunden(string data)
        {
            String output = "";

            string lat = "";
            string lng = "";

            string lat_m = "";
            string lng_m = "";

            string lat_s = "";
            string lng_s = "";

            string[] data_ = data.Split(',');

            double lat_s_d = 0.0;
            double lng_s_d = 0.0;

            lat_s = data_[0].Substring(data_[0].Length - 8, 7);
            lng_s = data_[1].Substring(data_[1].Length - 8, 7);

            lat_m = data_[0].Substring(0, data_[0].Length - (lat_s.Length + 1));
            lng_m = data_[1].Substring(0, data_[1].Length - (lng_s.Length + 1));

            while (lng_m.StartsWith("0"))
            {
                lng_m = lng_m.Substring(1, lng_m.Length - 1);
            }

            lat_s_d = Convert.ToDouble(lat_s) / 60;
            lng_s_d = Convert.ToDouble(lng_s) / 60;

            lat = lat_m + "." + Convert.ToString(Convert.ToDouble(lat_s) / 60);
            lng = lng_m + "." + Convert.ToString(Convert.ToDouble(lng_s) / 60);

            lat = lat.Replace(",", string.Empty);
            lng = lng.Replace(",", string.Empty);

            output = lat + "," + lng;

            return output;
        }

        private string Grad_Minuten_Sekunden_to_Grad_Dezimalminuten(string data)
        {
            String output = "";

            string lat = "";
            string lng = "";

            string lat_m = "";
            string lng_m = "";

            string lat_s = "";
            string lng_s = "";

            string[] data_ = data.Split(',');

            double lat_s_d = 0.0;
            double lng_s_d = 0.0;

            lat_s = data_[1].Substring(data_[1].Length - 8, 7);
            lng_s = data_[3].Substring(data_[3].Length - 8, 7);

            lat_m = data_[1].Substring(0, data_[1].Length - (lat_s.Length + 1));
            lng_m = data_[3].Substring(0, data_[3].Length - (lng_s.Length + 1));

            while (lng_m.StartsWith("0"))
            {
                lng_m = lng_m.Substring(1, lng_m.Length - 1);
            }

            lat_s_d = Convert.ToDouble(lat_s) * 60;
            lng_s_d = Convert.ToDouble(lng_s) * 60;

            lat = lat_m + "." + Convert.ToString(Convert.ToDouble(lat_s) / 60);
            lng = lng_m + "." + Convert.ToString(Convert.ToDouble(lng_s) / 60);

            lat = lat.Replace(",", string.Empty);
            lng = lng.Replace(",", string.Empty);

            output = lat + "," + lng;

            return output;
        }


        #region  GUI

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {



        }

        private void dfghjklToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapexplr.MapProvider = GMapProviders.OpenStreetMap;
        }

        private void googleMapsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapexplr.MapProvider = GMapProviders.GoogleMap;
        }

        private void googleMapsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            mapexplr.MapProvider = GMapProviders.GoogleSatelliteMap;
        }

        private void mapexplr_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                menuStrip2.Location = e.Location;
                menuStrip2.Visible = true;

                clicked_point = mapexplr.FromLocalToLatLng(e.X, e.Y);
            }
            else//left or middle click
            {
                //do something here
            }
        }

        private void addToRouteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuStrip2.Visible = false;

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "TXT|*.txt";
            saveFileDialog1.Title = "Save an Image File";
            if (activeroute == null)
            {

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    activeroute = new GMapRoute(saveFileDialog1.FileName);


                    mapexplr.Overlays.Remove(overlayOne);
                    overlayOne.Routes.Remove(activeroute);

                    listBox1.Items.Add(clicked_point);
                    activeroute.Points.Add(clicked_point);

                    overlayOne.Routes.Add(activeroute);
                    mapexplr.Overlays.Add(overlayOne);
                }

            }
            else
            {
                mapexplr.Overlays.Remove(overlayOne);
                overlayOne.Routes.Remove(activeroute);

                listBox1.Items.Add(clicked_point);
                activeroute.Points.Add(clicked_point);

                overlayOne.Routes.Add(activeroute);
                mapexplr.Overlays.Add(overlayOne);

            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (listBox1.SelectedIndex > 0)
            //{
            //    mapexplr.Overlays.Remove(overlayOne);

            //    overlayOne.Markers[last_index].Size = new Size(2, 2);
            //    overlayOne.Markers[listBox1.SelectedIndex].Size = new Size(2, 2);

            //    last_index = listBox1.SelectedIndex;

            //    mapexplr.Overlays.Add(overlayOne);
            //}
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            overlayOne.Routes.Remove(activeroute);

            activeroute.Points.RemoveAt(listBox1.SelectedIndex);
            listBox1.Items.Remove(listBox1.SelectedItem);
            if (listBox1.Items.Count > 0)
            {
                listBox1.SelectedIndex = 0;
            }
            overlayOne.Routes.Add(activeroute);
        }

        private void mapexplr_Click(object sender, EventArgs e)
        {
            menuStrip2.Visible = false;
        }

        private void ladenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(ofd.FileName);
                string data = sr.ReadToEnd();
                activeroute = new GMapRoute(ofd.FileName);


                string[] points = data.Split('\r');

                string lat = "";
                string lng = "";

                foreach (string dat in points)
                {
                    if (dat.Length > 4)
                    {
                        lat = dat.Split(';')[0];
                        lng = dat.Split(';')[1];
                        PointLatLng point = new PointLatLng(double.Parse(lat, System.Globalization.CultureInfo.InvariantCulture), double.Parse(lng, System.Globalization.CultureInfo.InvariantCulture));
                        activeroute.Points.Add(point);
                        listBox1.Items.Add(point);
                    }
                }




            }
        }

        private void speichernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //{Lat=52
            //3318070279308
            //Lng=9
            //2140531539917}



            if (activeroute != null)
            {
                StreamWriter sw = new StreamWriter(activeroute.Name);


                string data_towrite = "";
                foreach (PointLatLng position in listBox1.Items)
                {
                    string[] pos_teile = Convert.ToString(position).Split(',');

                    pos_teile[0] = pos_teile[0].Substring(5, pos_teile[0].Length - 5);

                    pos_teile[2] = pos_teile[2].Substring(5, pos_teile[2].Length - 5);
                    pos_teile[3] = pos_teile[3].Substring(0, pos_teile[3].Length - 1);

                    data_towrite = data_towrite + pos_teile[0] + "." + pos_teile[1] + ";" + pos_teile[2] + "." + pos_teile[3] + Environment.NewLine;
                }
                sw.Write(data_towrite);
                sw.Close();
            }
            else
            {
                MessageBox.Show("Die aktuelle Route ist leer");
            }
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapexplr.SetPositionByKeywords("Stadthagen, Teichstraße 57");
            mapexplr.Zoom = 19;
        }

        private void carToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapexplr.Position = last_car_point;
        }

        private void carToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            if (carToolStripMenuItem.Checked)
            {
                center_on_new_point = true;
            }
            else
            {
                center_on_new_point = false;
            }
        }

        private void driveToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            send_data("GOTO:" + Convert.ToString(clicked_point.Lat).Replace(',', '.') + ";" + Convert.ToString(clicked_point.Lng).Replace(',', '.'));

            for (int i = 0; i < overlayOne.Markers.Count; i++)
            {
                if (overlayOne.Markers[i].Tag == "TARGET")
                {
                    overlayOne.Markers.RemoveAt(i);
                }
            }


            add_point(clicked_point.Lat, clicked_point.Lng, GMarkerGoogleType.yellow, "TARGET");


            local_targetpoint = clicked_point;

            menuStrip2.Visible = false;

        }

        private void tb_front_ValueChanged(object sender, EventArgs e)
        {
            l_front.Text = Convert.ToString(tb_front.Value);
            if (tb_front.Value <= 20)
            {
                tb_front.BackColor = System.Drawing.Color.Yellow;
                if (tb_front.Value <= 10)
                {
                    tb_front.BackColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                tb_front.BackColor = System.Drawing.Color.Green;
            }

        }

        private void tb_left_ValueChanged(object sender, EventArgs e)
        {
            l_left_vorn.Text = Convert.ToString(tb_left_vorn.Value);
            if (tb_left_vorn.Value <= 20)
            {
                tb_left_vorn.BackColor = System.Drawing.Color.Yellow;
                if (tb_left_vorn.Value <= 10)
                {
                    tb_left_vorn.BackColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                tb_left_vorn.BackColor = System.Drawing.Color.Green;
            }
        }

        private void tb_right_ValueChanged(object sender, EventArgs e)
        {
            l_right_vorn.Text = Convert.ToString(tb_right_vorn.Value);
            if (tb_right_vorn.Value <= 20)
            {
                tb_right_vorn.BackColor = System.Drawing.Color.Yellow;
                if (tb_right_vorn.Value <= 10)
                {
                    tb_right_vorn.BackColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                tb_right_vorn.BackColor = System.Drawing.Color.Green;
            }
        }

        private void tb_back_ValueChanged(object sender, EventArgs e)
        {
            l_back.Text = Convert.ToString(tb_back.Value);


            if (tb_back.Value >= -20)
            {
                tb_back.BackColor = System.Drawing.Color.Yellow;
                if (tb_back.Value >= -10)
                {
                    tb_back.BackColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                tb_back.BackColor = System.Drawing.Color.Green;
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void folgeRouteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String data = "";
            if (activeroute != null)
            {
                if (activeroute.LocalPoints.Count == 0)
                {
                    foreach (PointLatLng point in activeroute.Points)
                    {

                        data = data += point.Lat + ";" + point.Lng + "|";
                    }
                    data = data.Replace(',', '.');

                    send_data("ROUTE:" + data);
                }
                else
                {
                    MessageBox.Show("Die aktuelle Route ist leer");
                }
            }
            else
            {
                MessageBox.Show("Die aktuelle Route ist leer");
            }
        }



        private void tb_right_hinten_ValueChanged(object sender, EventArgs e)
        {
            l_right_hinten.Text = Convert.ToString(tb_right_hinten.Value);
            if (tb_right_hinten.Value <= 20)
            {
                tb_right_hinten.BackColor = System.Drawing.Color.Yellow;
                if (tb_right_hinten.Value <= 10)
                {
                    tb_right_hinten.BackColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                tb_right_hinten.BackColor = System.Drawing.Color.Green;
            }
        }

        private void tb_left_hinten_ValueChanged(object sender, EventArgs e)
        {
            l_left_hinten.Text = Convert.ToString(tb_left_hinten.Value);
            if (tb_left_hinten.Value <= 20)
            {
                tb_left_hinten.BackColor = System.Drawing.Color.Yellow;
                if (tb_left_hinten.Value <= 10)
                {
                    tb_left_hinten.BackColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                tb_left_hinten.BackColor = System.Drawing.Color.Green;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            pictureBox12.Image = Compass.DrawCompass(oriantation, 0, 80, 0, 80, pictureBox12.Size);
        }

        private void mapexplr_Leave(object sender, EventArgs e)
        {
            menuStrip2.Visible = false;
        }


        #endregion GUI


        bool direct_control = false;
        Thread send_direct_coms;




        private void send_coms_directly()
        {
            while (true)
            {
                if (einstellungen.lenkmodus == "Panzer")
                {
                    new_comands = get_panzer_comands();
                }
                else
                {
                    new_comands = get_lenkachsen_comands();
                }
                Console.WriteLine();

                if ((old_comands != new_comands) && new_comands != "")
                {
                    send_data("DIRECT," + new_comands);
                    old_comands = new_comands;
                }
                Thread.Sleep(100);
            }
        }

        private string get_lenkachsen_comands()
        {
            string comands = "";
            try
            {
                gamepadState = GamePad.GetState(PlayerIndex.One);

                if (gamepadState.IsConnected == true)
                {
                    string signal_1 = "0";
                    //string signal_2 = "0";


                    if (Convert.ToInt32(gamepadState.Triggers.Right) == 0 && Convert.ToInt32(gamepadState.Triggers.Left) == 0)
                    {
                        signal_1 = "0";
                    }

                    if (Convert.ToInt32(gamepadState.Triggers.Right) == 1 && Convert.ToInt32(gamepadState.Triggers.Left) == 0)
                    {
                        signal_1 = "1";
                    }

                    if (Convert.ToInt32(gamepadState.Triggers.Right) == 0 && Convert.ToInt32(gamepadState.Triggers.Left) == 1)
                    {
                        signal_1 = "-1";
                    }


                    //comands = Convert.ToString(signal_1+","+Convert.ToString(Convert.ToInt32(gamepadState.ThumbSticks.Left.X)));
                    string b = (GamePad.GetState(0).ThumbSticks.Left.X / 2).ToString("0.00");
                    float a = (float)Convert.ToDouble(b) * 100;


                    comands = Convert.ToString(signal_1 + "," + Convert.ToString(a));


                    return comands;
                }
                return "no comand";
            }
            catch (Exception ex)
            {
                Console.WriteLine("GET COMM: " + ex.Message);
                return "no comand";
            }
        }

        string get_panzer_comands()
        {
            Console.WriteLine("READ PANZERCOMMANDS");
            string comands = "";
            try
            {
                gamepadState = GamePad.GetState(PlayerIndex.One);

                if (gamepadState.IsConnected == true)
                {
                    if (gamepadState.Triggers.Right >= 1.0f &&
                        gamepadState.Triggers.Left >= 1.0f &&
                        gamepadState.Buttons.RightShoulder == Microsoft.Xna.Framework.Input.ButtonState.Pressed &&
                        gamepadState.Buttons.LeftShoulder == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
                    {
                        comands = "0,0";
                        return comands;
                    }

                    if (gamepadState.Triggers.Right >= 1.0f &&
                        gamepadState.Triggers.Left <= 1.0f &&
                        gamepadState.Buttons.RightShoulder == Microsoft.Xna.Framework.Input.ButtonState.Released &&
                        gamepadState.Buttons.LeftShoulder == Microsoft.Xna.Framework.Input.ButtonState.Released)
                    {
                        Console.WriteLine("LOCALCONTROLL: Forwards");
                        comands = "1,1";
                        return comands;
                    }

                    if (gamepadState.Triggers.Right <= 1.0f &&
                        gamepadState.Triggers.Left >= 1.0f &&
                        gamepadState.Buttons.RightShoulder == Microsoft.Xna.Framework.Input.ButtonState.Released &&
                        gamepadState.Buttons.LeftShoulder == Microsoft.Xna.Framework.Input.ButtonState.Released)
                    {
                        Console.WriteLine("LOCALCONTROLL: Backwards");
                        comands = "-1,-1";
                        return comands;
                    }

                    if (gamepadState.Triggers.Right <= 1.0f &&
                        gamepadState.Triggers.Left <= 1.0f &&
                        gamepadState.Buttons.RightShoulder == Microsoft.Xna.Framework.Input.ButtonState.Pressed &&
                        gamepadState.Buttons.LeftShoulder == Microsoft.Xna.Framework.Input.ButtonState.Released)
                    {
                        Console.WriteLine("LOCALCONTROLL: Right");
                        comands = "-1,1";
                        return comands;
                    }

                    if (gamepadState.Triggers.Right <= 1.0f &&
                        gamepadState.Triggers.Left <= 1.0f &&
                        gamepadState.Buttons.RightShoulder == Microsoft.Xna.Framework.Input.ButtonState.Released &&
                        gamepadState.Buttons.LeftShoulder == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
                    {
                        Console.WriteLine("LOCALCONTROLL: Left");
                        comands = "1,-1";
                        return comands;
                    }

                    if (gamepadState.Triggers.Right <= 1.0f &&
                        gamepadState.Triggers.Left <= 1.0f &&
                        gamepadState.Buttons.RightShoulder == Microsoft.Xna.Framework.Input.ButtonState.Released &&
                        gamepadState.Buttons.LeftShoulder == Microsoft.Xna.Framework.Input.ButtonState.Released)
                    {
                        comands = "0,0";
                        return comands;
                    }

                    return comands;

                }
                else
                {
                    comands = "";
                    return comands;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("GET COMM: " + ex.Message);
                return "no comand";
            }
        }














        private void hScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            send_data("CAM," + Convert.ToString(hsb_cam.Value));
        }

        private void rb_idle_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_idle.Checked)
            {
                send_idle();
            }
        }

        private void rb_directcontrol_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_directcontrol.Checked)
            {
                select_direct();
            }
        }

        private void rb_autopilot_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_autopilot.Checked)
            {
                send_AI();
            }
        }

        private void rb_lokalcontrol_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_lokalcontrol.Checked)
            {
                send_local();
            }
        }



        private void send_local()
        {
            send_data("COMM,LOCAL");
            send_direct_coms.Abort();
            direct_control = false;
        }

        private void send_idle()
        {
            send_data("COMM,IDLE");
            if (send_direct_coms != null)
            {
                send_direct_coms.Abort();
            }
            direct_control = false;
        }

        private void select_direct()
        {
            //if (!object.ReferenceEquals(socket, null))
            //{
            gamepadState = GamePad.GetState(PlayerIndex.One);
            if (gamepadState.IsConnected)
            {
                l_GamePadStatus.Text = "GamePad is online";
            }
            else
            {
                l_GamePadStatus.Text = "GamePad is offline";
            }
            send_data("COMM,DIRECT");
            send_direct_coms = new Thread(send_coms_directly);
            send_direct_coms.Start();
            direct_control = true;
            //}
            //else
            //{
            //    MessageBox.Show("Es besteht keine Verbinndung zu einem Vehicle", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //}
        }

        private void send_AI()
        {
            send_data("COMM,AI");
            if (send_direct_coms != null)
            {
                send_direct_coms.Abort();
            }
            direct_control = false;
        }

        private void einstellungenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            einstellungen.Show();
        }



        private void aktuelleStellungAlsStandartSetzenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            standart_stellung[0] = chart1.Series["Series1"].Points[0].YValues[0];
            standart_stellung[1] = chart1.Series["Series1"].Points[1].YValues[0];
            standart_stellung[2] = chart1.Series["Series1"].Points[2].YValues[0];
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            webKitBrowser1.Navigate(toolStripTextBox1.Text);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!object.Equals(socket, null))
            {
                if (socket.IsBound)
                {
                    send_data("bye");
                }
            }

            if (!object.Equals(myList, null))
            {
                myList.Stop();
            }
            if (!object.Equals(th_background, null))
            {
                th_background.Abort();
            }

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!object.Equals(socket, null))
            {
                if (socket.IsBound)
                {
                    send_data("bye");
                }
            }

            if (!object.Equals(myList, null))
            {
                myList.Stop();
            }
            if (!object.Equals(th_background, null))
            {
                th_background.Abort();
            }

            this.Close();
        }

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }


    }
}
 