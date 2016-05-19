using iCarto.common.icontrols;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Transitions;

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

            Transition t = new Transition(new TransitionType_EaseInEaseOut(500));
            t.add(ctrlOnScreen, "Left", -1 * ctrlOnScreen.Width);
            t.add(ctrlOffScreen, "Left", 0);
            t.run();
        }

    }
}