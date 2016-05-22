using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms.Integration;
using System.Windows.Forms;
using System.ComponentModel;
using System.Windows.Forms.Design;
using System.Windows;
using System.ComponentModel.Design.Serialization;
using System.Windows.Markup;

namespace WindowsFormsControlLibrary1
{
    [Designer("System.Windows.Forms.Design.ControlDesigner, System.Design")]
    [DesignerSerializer("System.ComponentModel.Design.Serialization.TypeCodeDomSerializer , System.Design", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design")]
    public class tiltedslider_WinformsHost : System.Windows.Forms.Integration.ElementHost
    {
        protected tiltedslider m_WPFComboBoxWithGrid = new tiltedslider();

        public tiltedslider_WinformsHost()
        {
            base.Child = m_WPFComboBoxWithGrid;
        }

        public int Value
        {
            get
            {
                return m_WPFComboBoxWithGrid.Value;
            }
            set
            {
                m_WPFComboBoxWithGrid.Value = value;
            }
        }

     
    }
}
