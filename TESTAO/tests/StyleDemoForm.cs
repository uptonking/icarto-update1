using ESRI.ArcGIS.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TESTAO
{
    public partial class StyleDemoForm : Form
    {
        private IMapControl3 m_mapControl = null;


        public StyleDemoForm()
        {
            InitializeComponent();

            //get the MapControl
            m_mapControl = (IMapControl3)axMapControl1.Object;

            initBasemap();
        }

        public void initBasemap()
        {

            string path = System.Windows.Forms.Application.StartupPath + @"../../../";
                System.IO.Directory.SetCurrentDirectory(path);
                string mapPath = System.IO.Directory.GetCurrentDirectory() + @"\res\data\testmxd.mxd";

                m_mapControl.LoadMxFile(mapPath);
        }

        private void showServerStyleBtn_Click(object sender, EventArgs e)
        {
            showStylePanel.Left = 200;
            mapPainterPanel.Left = 800;
        }

        private void startMapPainter_Click(object sender, EventArgs e)
        {
            mapPainterPanel.Left = 200;
            showStylePanel.Left = 800;
        }
    }
}