using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_controll
{
    public partial class customlabel : UserControl
    {
        public customlabel()
        {
            InitializeComponent();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            label1.Text = textBox1.Text;
        }

        private void customlabel_DoubleClick(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            textBox1.Focus();
        }

        private void label1_DoubleClick(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            textBox1.Focus();
        }

        private void customlabel_Leave(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            label1.Text = textBox1.Text;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                label1.Focus();
            }
        }

    }
}
