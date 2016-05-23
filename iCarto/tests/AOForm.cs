using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iCarto.tests
{
    public partial class AOForm : Form
    {
        public AOForm()
        {
            InitializeComponent();

            //MapControl显示shapefile
            string lhkRailFilePath = @"C:\Users\Yao\Documents\Visual Studio 2012\Projects\iCarto\iCarto\res\data\lhk铁路线shapefile\";
            string lhkRailFileName = @"grailn";
            mainAxMapControl.AddShapeFile(lhkRailFilePath, lhkRailFileName);



        }

        private void formatPainterBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello,B**ches");
        }
    }
}
