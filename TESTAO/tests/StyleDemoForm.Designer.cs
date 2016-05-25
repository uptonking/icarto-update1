namespace TESTAO
{
    partial class StyleDemoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StyleDemoForm));
            this.headerPanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.catalogPanel = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.showServerStyleBtn = new System.Windows.Forms.Button();
            this.showStylePanel = new System.Windows.Forms.Panel();
            this.dividerP1 = new System.Windows.Forms.Panel();
            this.mapPainterPanel = new System.Windows.Forms.Panel();
            this.axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.catalogPanel.SuspendLayout();
            this.showStylePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.Transparent;
            this.headerPanel.Controls.Add(this.pictureBox1);
            this.headerPanel.Controls.Add(this.label1);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(784, 48);
            this.headerPanel.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TESTAO.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(37, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 16F);
            this.label1.Location = new System.Drawing.Point(97, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "AE符号样式Demo";
            // 
            // catalogPanel
            // 
            this.catalogPanel.Controls.Add(this.dividerP1);
            this.catalogPanel.Controls.Add(this.button2);
            this.catalogPanel.Controls.Add(this.showServerStyleBtn);
            this.catalogPanel.Location = new System.Drawing.Point(0, 48);
            this.catalogPanel.Name = "catalogPanel";
            this.catalogPanel.Size = new System.Drawing.Size(200, 393);
            this.catalogPanel.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft YaHei", 10F);
            this.button2.Location = new System.Drawing.Point(12, 97);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(172, 48);
            this.button2.TabIndex = 1;
            this.button2.Text = "2.使用格式刷";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // showServerStyleBtn
            // 
            this.showServerStyleBtn.FlatAppearance.BorderSize = 0;
            this.showServerStyleBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showServerStyleBtn.Font = new System.Drawing.Font("Microsoft YaHei", 10F);
            this.showServerStyleBtn.Location = new System.Drawing.Point(12, 30);
            this.showServerStyleBtn.Name = "showServerStyleBtn";
            this.showServerStyleBtn.Size = new System.Drawing.Size(172, 48);
            this.showServerStyleBtn.TabIndex = 0;
            this.showServerStyleBtn.Text = "1.读取.StyleServer文件";
            this.showServerStyleBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.showServerStyleBtn.UseVisualStyleBackColor = true;
            // 
            // showStylePanel
            // 
            this.showStylePanel.Controls.Add(this.axMapControl1);
            this.showStylePanel.Location = new System.Drawing.Point(200, 48);
            this.showStylePanel.Name = "showStylePanel";
            this.showStylePanel.Size = new System.Drawing.Size(584, 393);
            this.showStylePanel.TabIndex = 2;
            // 
            // dividerP1
            // 
            this.dividerP1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(140)))));
            this.dividerP1.Location = new System.Drawing.Point(190, 0);
            this.dividerP1.Name = "dividerP1";
            this.dividerP1.Size = new System.Drawing.Size(10, 393);
            this.dividerP1.TabIndex = 2;
            // 
            // mapPainterPanel
            // 
            this.mapPainterPanel.Location = new System.Drawing.Point(200, 48);
            this.mapPainterPanel.Margin = new System.Windows.Forms.Padding(0);
            this.mapPainterPanel.Name = "mapPainterPanel";
            this.mapPainterPanel.Size = new System.Drawing.Size(600, 393);
            this.mapPainterPanel.TabIndex = 3;
            // 
            // axMapControl1
            // 
            this.axMapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axMapControl1.Location = new System.Drawing.Point(0, 0);
            this.axMapControl1.Margin = new System.Windows.Forms.Padding(0);
            this.axMapControl1.Name = "axMapControl1";
            this.axMapControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl1.OcxState")));
            this.axMapControl1.Size = new System.Drawing.Size(584, 393);
            this.axMapControl1.TabIndex = 0;
            // 
            // StyleDemoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(784, 441);
            this.Controls.Add(this.headerPanel);
            this.Controls.Add(this.showStylePanel);
            this.Controls.Add(this.mapPainterPanel);
            this.Controls.Add(this.catalogPanel);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "StyleDemoForm";
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.catalogPanel.ResumeLayout(false);
            this.showStylePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel catalogPanel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button showServerStyleBtn;
        private System.Windows.Forms.Panel showStylePanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel dividerP1;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl1;
        private System.Windows.Forms.Panel mapPainterPanel;
    }
}

