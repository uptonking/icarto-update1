using iCarto.common.icontrols;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.indexGroupBox = new System.Windows.Forms.GroupBox();
            this.cornerTagLabel = new iCarto.common.icontrols.OrientedTextLabel();
            this.cornerTagPicbox = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.mainGroupBox = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.indexGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cornerTagPicbox)).BeginInit();
            this.mainGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // indexGroupBox
            // 
            this.indexGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.indexGroupBox.Controls.Add(this.cornerTagLabel);
            this.indexGroupBox.Controls.Add(this.cornerTagPicbox);
            this.indexGroupBox.Controls.Add(this.button1);
            this.indexGroupBox.Location = new System.Drawing.Point(0, 29);
            this.indexGroupBox.Margin = new System.Windows.Forms.Padding(0);
            this.indexGroupBox.Name = "indexGroupBox";
            this.indexGroupBox.Padding = new System.Windows.Forms.Padding(0);
            this.indexGroupBox.Size = new System.Drawing.Size(1280, 680);
            this.indexGroupBox.TabIndex = 1;
            this.indexGroupBox.TabStop = false;
            this.indexGroupBox.Text = "indexGroupbox";
            this.indexGroupBox.Paint += new System.Windows.Forms.PaintEventHandler(this.removeGroupBoxBorder_Paint);
            // 
            // cornerTagLabel
            // 
            this.cornerTagLabel.BackColor = System.Drawing.Color.Transparent;
            this.cornerTagLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cornerTagLabel.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cornerTagLabel.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.cornerTagLabel.Location = new System.Drawing.Point(0, -7);
            this.cornerTagLabel.Margin = new System.Windows.Forms.Padding(0);
            this.cornerTagLabel.Name = "cornerTagLabel";
            this.cornerTagLabel.RotationAngle = -45D;
            this.cornerTagLabel.Size = new System.Drawing.Size(84, 84);
            this.cornerTagLabel.TabIndex = 3;
            this.cornerTagLabel.Text = "最新足迹热力图";
            this.cornerTagLabel.TextDirection = iCarto.common.icontrols.Direction.Clockwise;
            this.cornerTagLabel.TextOrientation = iCarto.common.icontrols.Orientation.Rotate;
            // 
            // cornerTagPicbox
            // 
            this.cornerTagPicbox.Image = ((System.Drawing.Image)(resources.GetObject("cornerTagPicbox.Image")));
            this.cornerTagPicbox.Location = new System.Drawing.Point(0, 0);
            this.cornerTagPicbox.Margin = new System.Windows.Forms.Padding(0);
            this.cornerTagPicbox.Name = "cornerTagPicbox";
            this.cornerTagPicbox.Size = new System.Drawing.Size(79, 79);
            this.cornerTagPicbox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.cornerTagPicbox.TabIndex = 1;
            this.cornerTagPicbox.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(383, 193);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "UpperLeft";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.swapBtnClick);
            // 
            // mainGroupBox
            // 
            this.mainGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.mainGroupBox.Controls.Add(this.button2);
            this.mainGroupBox.Location = new System.Drawing.Point(-1280, 29);
            this.mainGroupBox.Name = "mainGroupBox";
            this.mainGroupBox.Size = new System.Drawing.Size(1280, 680);
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
            this.ClientSize = new System.Drawing.Size(1264, 704);
            this.Controls.Add(this.mainGroupBox);
            this.Controls.Add(this.indexGroupBox);
            this.Name = "MainForm";
            this.Title = "iCarto 快速制图";
            this.Controls.SetChildIndex(this.indexGroupBox, 0);
            this.Controls.SetChildIndex(this.mainGroupBox, 0);
            this.indexGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cornerTagPicbox)).EndInit();
            this.mainGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox indexGroupBox;
        private System.Windows.Forms.GroupBox mainGroupBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox cornerTagPicbox;
        private System.Windows.Forms.Button button1;
        private OrientedTextLabel cornerTagLabel;

    }
}

