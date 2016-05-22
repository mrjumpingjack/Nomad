using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WindowsFormsControlLibrary1
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class tiltedslider : UserControl
    {
        public tiltedslider()
        {
            InitializeComponent();


            this.DataContext = this;
        }
         public int Value 
        {
            get
            {
               return Convert.ToInt32(slider.Value);
            }
            set
            {
                slider.Value = Convert.ToDouble(value);
            }
        } 
       
    }


    }
