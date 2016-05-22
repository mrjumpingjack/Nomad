using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MonoGame;
using MonoGame.Utilities;
using OpenTK.Input;



namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Thread thread;
        private void Form1_Load(object sender, EventArgs e)
        {
            thread = new Thread(gp);
            if (thread.ThreadState != ThreadState.Running)
            {
                thread.Start();
            }
        }

        void gp()
        {
            int i = 0;
       
            while (true)
            {
                if (GamePad.GetState(0).IsConnected==true)
                {
                    if (GamePad.GetState(0).Buttons.A == OpenTK.Input.ButtonState.Pressed)
                    {
                        Console.WriteLine(i);
                        i++;
                    }
                }
                else
                {
                    Console.WriteLine("NO GP");
                }
            }
        }


    }
}
