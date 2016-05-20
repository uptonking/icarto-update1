using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Transitions;
using iCarto.common.icontrols;
using System.Drawing.Text;
using System.Collections;
using iCarto.common.utils;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.SystemUI;
using ContextMenu;
using ESRI.ArcGIS.Carto;

namespace iCarto
{
    public partial class MainForm : CustomTitleBarForm
    {
        private ITOCControl2 m_tocControl;
        private IMapControl3 m_mapControl;
        private IToolbarMenu m_menuMap;
        private IToolbarMenu m_menuLayer;

        public MainForm()
        {
            InitializeComponent();



            //设置字体
            configureFonts();
        }

        private void swapBtnClick(object sender, EventArgs e)
        {
            uiSwap();
        }

        private void removeGroupBoxBorder_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
        }


        public void configureFonts()
        {
            //准备带改变的Labels
            List<Label> labelsList = new List<Label>();
            labelsList.Add(logoLabel);
            labelsList.Add(usrNameLabel);
            labelsList.Add(naviIndustryLabel);
            labelsList.Add(naviHotMapsLabel);
            labelsList.Add(naviLatestMapsLabel);

            //加载本地字体
            FontFamily ff = new CustomFontsManager().loadFonts();

            //修改Lables
            foreach (var item in labelsList)
            {
                item.Font = new Font(ff, item.Font.Size);
            }

            searchTextBox.Font = new Font(ff, searchTextBox.Font.Size);

        }

        /// <summary>
        /// Called when the "Swap" button is pressed.
        /// </summary>
        private void uiSwap()
        {
            // We swap over the group-boxes that show the "Bounce" and 
            // "Throw and Catch" transitions. The active one is animated 
            // left off the screen and the inactive one is animated right
            // onto the screen...

            // We work out which box is currently on screen and
            // which is off screen...
            Control ctrlOnScreen, ctrlOffScreen;
            if (indexGroupBox.Left == 0)
            {
                ctrlOnScreen = indexGroupBox;
                ctrlOffScreen = mainGroupBox;
            }
            else
            {
                ctrlOnScreen = mainGroupBox;
                ctrlOffScreen = indexGroupBox;
            }
            ctrlOnScreen.SendToBack();
            ctrlOffScreen.BringToFront();

            // We create a transition to animate the two boxes simultaneously. One is
            // animated onto the screen, the other off the screen.

            // The ease-in-ease-out transition acclerates the rate of change for the 
            // first half of the animation, and decelerates during the second half.

            Transition t = new Transition(new TransitionType_EaseInEaseOut(200));
            t.add(ctrlOnScreen, "Left", -1 * ctrlOnScreen.Width);
            t.add(ctrlOffScreen, "Left", 0);
            t.run();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            uiSwap();
        }

        private void back2IndexBtn_Click(object sender, EventArgs e)
        {
            uiSwap();
        }


        //加载右键菜单
        private void MainForm_Load(object sender, EventArgs e)
        {
            m_tocControl = (ITOCControl2)mainAxTOCControl.Object;
            m_mapControl = (IMapControl3)mainAxMapControl.Object;

            //Set buddy control
            m_tocControl.SetBuddyControl(m_mapControl);
            mainAxToolbarControl.SetBuddyControl(m_mapControl);

            //Add pre-defined control commands to the ToolbarControl
            mainAxToolbarControl.AddItem("esriControls.ControlsSelectFeaturesTool", -1, 0, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
            mainAxToolbarControl.AddToolbarDef("esriControls.ControlsMapNavigationToolbar", 0, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
            mainAxToolbarControl.AddItem("esriControls.ControlsOpenDocCommand", -1, 0, false, 0, esriCommandStyles.esriCommandStyleIconOnly);

            //Add custom commands to the map menu
            m_menuMap = new ToolbarMenuClass();
            m_menuMap.AddItem(new LayerVisibility(), 1, 0, false, esriCommandStyles.esriCommandStyleTextOnly);
            m_menuMap.AddItem(new LayerVisibility(), 2, 1, false, esriCommandStyles.esriCommandStyleTextOnly);
            //Add pre-defined menu to the map menu as a sub menu 
            m_menuMap.AddSubMenu("esriControls.ControlsFeatureSelectionMenu", 2, true);
            //Add custom commands to the map menu
            m_menuLayer = new ToolbarMenuClass();
            m_menuLayer.AddItem(new RemoveLayer(), -1, 0, false, esriCommandStyles.esriCommandStyleTextOnly);
            m_menuLayer.AddItem(new ScaleThresholds(), 1, 1, true, esriCommandStyles.esriCommandStyleTextOnly);
            m_menuLayer.AddItem(new ScaleThresholds(), 2, 2, false, esriCommandStyles.esriCommandStyleTextOnly);
            m_menuLayer.AddItem(new ScaleThresholds(), 3, 3, false, esriCommandStyles.esriCommandStyleTextOnly);
            m_menuLayer.AddItem(new LayerSelectable(), 1, 4, true, esriCommandStyles.esriCommandStyleTextOnly);
            m_menuLayer.AddItem(new LayerSelectable(), 2, 5, false, esriCommandStyles.esriCommandStyleTextOnly);
            m_menuLayer.AddItem(new ZoomToLayer(), -1, 6, true, esriCommandStyles.esriCommandStyleTextOnly);

            //Set the hook of each menu
            m_menuLayer.SetHook(m_mapControl);
            m_menuMap.SetHook(m_mapControl);
        }


        private void mainAxTOCControl_OnMouseDown(object sender, ITOCControlEvents_OnMouseDownEvent e)
        {
            if (e.button != 2) return;

            esriTOCControlItem item = esriTOCControlItem.esriTOCControlItemNone;
            IBasicMap map = null; ILayer layer = null;
            object other = null; object index = null;

            //Determine what kind of item is selected
            m_tocControl.HitTest(e.x, e.y, ref item, ref map, ref layer, ref other, ref index);

            //Ensure the item gets selected 
            if (item == esriTOCControlItem.esriTOCControlItemMap)
                m_tocControl.SelectItem(map, null);
            else
                m_tocControl.SelectItem(layer, null);

            //Set the layer into the CustomProperty (this is used by the custom layer commands)			
            m_mapControl.CustomProperty = layer;

            //Popup the correct context menu
            if (item == esriTOCControlItem.esriTOCControlItemMap) m_menuMap.PopupMenu(e.x, e.y, m_tocControl.hWnd);
            if (item == esriTOCControlItem.esriTOCControlItemLayer) m_menuLayer.PopupMenu(e.x, e.y, m_tocControl.hWnd);

        }

    }
}