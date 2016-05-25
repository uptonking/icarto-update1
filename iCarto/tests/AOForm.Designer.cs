namespace iCarto.tests
{
    partial class AOForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AOForm));
            this.mapSplitContainer = new System.Windows.Forms.SplitContainer();
            this.mainAxTOCControl = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.mainAxMapControl = new ESRI.ArcGIS.Controls.AxMapControl();
            this.formatPainterBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.mainAxToolbarControl = new ESRI.ArcGIS.Controls.AxToolbarControl();
            ((System.ComponentModel.ISupportInitialize)(this.mapSplitContainer)).BeginInit();
            this.mapSplitContainer.Panel1.SuspendLayout();
            this.mapSplitContainer.Panel2.SuspendLayout();
            this.mapSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainAxTOCControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainAxMapControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainAxToolbarControl)).BeginInit();
            this.SuspendLayout();
            // 
            // mapSplitContainer
            // 
            this.mapSplitContainer.Location = new System.Drawing.Point(0, 36);
            this.mapSplitContainer.Name = "mapSplitContainer";
            // 
            // mapSplitContainer.Panel1
            // 
            this.mapSplitContainer.Panel1.Controls.Add(this.mainAxTOCControl);
            // 
            // mapSplitContainer.Panel2
            // 
            this.mapSplitContainer.Panel2.Controls.Add(this.mainAxMapControl);
            this.mapSplitContainer.Size = new System.Drawing.Size(624, 413);
            this.mapSplitContainer.SplitterDistance = 208;
            this.mapSplitContainer.TabIndex = 1;
            // 
            // mainAxTOCControl
            // 
            this.mainAxTOCControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainAxTOCControl.Location = new System.Drawing.Point(0, 0);
            this.mainAxTOCControl.Name = "mainAxTOCControl";
            this.mainAxTOCControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mainAxTOCControl.OcxState")));
            this.mainAxTOCControl.Size = new System.Drawing.Size(208, 413);
            this.mainAxTOCControl.TabIndex = 0;
            // 
            // mainAxMapControl
            // 
            this.mainAxMapControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainAxMapControl.Location = new System.Drawing.Point(0, 0);
            this.mainAxMapControl.Name = "mainAxMapControl";
            this.mainAxMapControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mainAxMapControl.OcxState")));
            this.mainAxMapControl.Size = new System.Drawing.Size(412, 413);
            this.mainAxMapControl.TabIndex = 0;
            // 
            // formatPainterBtn
            // 
            this.formatPainterBtn.Location = new System.Drawing.Point(413, 7);
            this.formatPainterBtn.Name = "formatPainterBtn";
            this.formatPainterBtn.Size = new System.Drawing.Size(75, 23);
            this.formatPainterBtn.TabIndex = 2;
            this.formatPainterBtn.Text = "格式刷";
            this.formatPainterBtn.UseVisualStyleBackColor = true;
            this.formatPainterBtn.Click += new System.EventHandler(this.formatPainterBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::iCarto.Properties.Resources.esriCartographyMarker_61_White;
            this.pictureBox1.Location = new System.Drawing.Point(657, 36);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // mainAxToolbarControl
            // 
            this.mainAxToolbarControl.Location = new System.Drawing.Point(0, 0);
            this.mainAxToolbarControl.Margin = new System.Windows.Forms.Padding(0);
            this.mainAxToolbarControl.Name = "mainAxToolbarControl";
            this.mainAxToolbarControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mainAxToolbarControl.OcxState")));
            this.mainAxToolbarControl.Size = new System.Drawing.Size(280, 28);
            this.mainAxToolbarControl.TabIndex = 0;
            // 
            // AOForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 441);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.formatPainterBtn);
            this.Controls.Add(this.mapSplitContainer);
            this.Controls.Add(this.mainAxToolbarControl);
            this.Name = "AOForm";
            this.Text = "Style样式测试";
            this.mapSplitContainer.Panel1.ResumeLayout(false);
            this.mapSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mapSplitContainer)).EndInit();
            this.mapSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainAxTOCControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainAxMapControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainAxToolbarControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer mapSplitContainer;
        private ESRI.ArcGIS.Controls.AxTOCControl mainAxTOCControl;
        private ESRI.ArcGIS.Controls.AxMapControl mainAxMapControl;
        private ESRI.ArcGIS.Controls.AxToolbarControl mainAxToolbarControl;
        private System.Windows.Forms.Button formatPainterBtn;
        private System.Windows.Forms.PictureBox pictureBox1;

    }
}