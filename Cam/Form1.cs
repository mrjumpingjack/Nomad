using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ozeki.Media.IPCamera;
using Ozeki.Media.IPCamera.Rtsp;
using Ozeki.Media.IPCamera.Server;
using Ozeki.Media.MediaHandlers;
using Ozeki.VoIP.PBX.Authentication;
using Ozeki.Media.Video.Controls;

namespace Cam
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        MyServer _server = new MyServer();

        VideoViewerWF vw = new VideoViewerWF();

        private void Form1_Load(object sender, EventArgs e)
        {


           


            //_server.Start();
            //_server.SetListenAddress("192.168.0.11", 8554);
            //_server.ClientCountChange += new EventHandler(server_ClientCountChange);
            //Console.WriteLine("Started");
            //Console.Read();




        }

        void server_ClientCountChange(object sender, EventArgs e)
        {
            _server.ConnectedClients.ForEach(x => Console.WriteLine(x.TransportInfo.RemoteEndPoint.ToString()));
        }
    }



    public class MyServer : CameraServer
    {
        private MediaConnector _connector;
        private IIPCamera _camera;
        private ICameraClient _client;

        public string IpAddress { get; set; }
        public int Port { get; set; }

        public event EventHandler ClientCountChange;

        public MyServer()
        {
            _connector = new MediaConnector();
            _camera = IPCameraFactory.GetCamera("192.168.0.132:8554",null,null);

            if (_camera != null)
                _camera.Start();
        }


        protected override void OnClientConnected(ICameraClient client)
        {
            _client = client;
            _connector.Connect(_camera.AudioChannel, _client.AudioChannel);
            _connector.Connect(_camera.VideoChannel, _client.VideoChannel);

            var handler = ClientCountChange;
            if (handler != null)
                handler(null, new EventArgs());

            base.OnClientConnected(_client);
        }

        protected override void OnClientDisconnected(ICameraClient client)
        {
            _connector.Disconnect(_camera.AudioChannel, _client.AudioChannel);
            _connector.Disconnect(_camera.VideoChannel, _client.VideoChannel);
            _connector.Dispose();

            var handler = ClientCountChange;
            if (handler != null)
                handler(null, new EventArgs());

            base.OnClientDisconnected(client);
        }
    }
}
