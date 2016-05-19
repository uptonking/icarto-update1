namespace iCarto
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.indexGroupBox = new System.Windows.Forms.GroupBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.mainGroupBox = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.indexGroupBox.SuspendLayout();
            this.mainGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // indexGroupBox
            // 
            this.indexGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.indexGroupBox.Controls.Add(this.button6);
            this.indexGroupBox.Controls.Add(this.button5);
            this.indexGroupBox.Controls.Add(this.button4);
            this.indexGroupBox.Controls.Add(this.button3);
            this.indexGroupBox.Controls.Add(this.button1);
            this.indexGroupBox.Location = new System.Drawing.Point(0, 29);
            this.indexGroupBox.Margin = new System.Windows.Forms.Padding(0);
            this.indexGroupBox.Name = "indexGroupBox";
            this.indexGroupBox.Padding = new System.Windows.Forms.Padding(0);
            this.indexGroupBox.Size = new System.Drawing.Size(784, 435);
            this.indexGroupBox.TabIndex = 1;
            this.indexGroupBox.TabStop = false;
            this.indexGroupBox.Text = "indexGroupbox";
            this.indexGroupBox.Paint += new System.Windows.Forms.PaintEventHandler(this.removeGroupBoxBorder_Paint);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(341, 181);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 4;
            this.button6.Text = "Middle";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(0, 407);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 3;
            this.button5.Text = "BottomLeft";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(709, 407);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 2;
            this.button4.Text = "BottomRight";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(709, 16);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 1;
            this.button3.Text = "UpperRight";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "UpperLeft";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.swapBtnClick);
            // 
            // mainGroupBox
            // 
            this.mainGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.mainGroupBox.Controls.Add(this.button2);
            this.mainGroupBox.Location = new System.Drawing.Point(-800, 29);
            this.mainGroupBox.Name = "mainGroupBox";
            this.mainGroupBox.Size = new System.Drawing.Size(800, 430);
            this.mainGroupBox.TabIndex = 2;
            this.mainGroupBox.TabStop = false;
            this.mainGroupBox.Text = "mainGroupBox";
            this.mainGroupBox.Paint += new System.Windows.Forms.PaintEventHandler(this.removeGroupBoxBorder_Paint);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(118, 193);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.swapBtnClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 464);
            this.Controls.Add(this.mainGroupBox);
            this.Controls.Add(this.indexGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "MainForm";
            this.Title = "Form1";
            this.Controls.SetChildIndex(this.indexGroupBox, 0);
            this.Controls.SetChildIndex(this.mainGroupBox, 0);
            this.indexGroupBox.ResumeLayout(false);
            this.mainGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox indexGroupBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox mainGroupBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;


    }
}

