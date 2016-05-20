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

namespace iCarto
{
    public partial class MainForm : CustomTitleBarForm
    {
        public MainForm()
        {
            InitializeComponent();
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
            PrivateFontCollection pfc = new PrivateFontCollection();
            string fontPath = @"C:\Users\Yao\Documents\Visual Studio 2012\Projects\iCarto\iCarto\res\fonts\SourceHanSansSC-Regular.ttf";

            try
            {

                pfc.AddFontFile(fontPath);//字体的路径及名字 
                Font f1 = new Font(pfc.Families[0], 14);
                label1.Font = f1;


            }
            catch (Exception)
            {

                MessageBox.Show("字体不存在或加载失败\n程序将以默认字体显示", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

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

    }
}