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
            this.leftPanel = new System.Windows.Forms.Panel();
            this.symPickerPanel = new System.Windows.Forms.Panel();
            this.pred = new System.Windows.Forms.PictureBox();
            this.pgreen = new System.Windows.Forms.PictureBox();
            this.tvPanel = new System.Windows.Forms.Panel();
            this.tvStyleNode = new System.Windows.Forms.TreeView();
            this.dividerP1 = new System.Windows.Forms.Panel();
            this.startMapPainterBtn = new System.Windows.Forms.Button();
            this.showServerStyleBtn = new System.Windows.Forms.Button();
            this.showStylePanel = new System.Windows.Forms.Panel();
            this.lvSymbolView = new System.Windows.Forms.ListView();
            this.axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.mapPainterPanel = new System.Windows.Forms.Panel();
            this.headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.leftPanel.SuspendLayout();
            this.symPickerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pred)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pgreen)).BeginInit();
            this.tvPanel.SuspendLayout();
            this.showStylePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            this.mapPainterPanel.SuspendLayout();
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
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
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
            // leftPanel
            // 
            this.leftPanel.Controls.Add(this.symPickerPanel);
            this.leftPanel.Controls.Add(this.tvPanel);
            this.leftPanel.Controls.Add(this.dividerP1);
            this.leftPanel.Controls.Add(this.startMapPainterBtn);
            this.leftPanel.Controls.Add(this.showServerStyleBtn);
            this.leftPanel.Location = new System.Drawing.Point(0, 48);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(200, 393);
            this.leftPanel.TabIndex = 1;
            // 
            // symPickerPanel
            // 
            this.symPickerPanel.Controls.Add(this.pred);
            this.symPickerPanel.Controls.Add(this.pgreen);
            this.symPickerPanel.Location = new System.Drawing.Point(0, 100);
            this.symPickerPanel.Name = "symPickerPanel";
            this.symPickerPanel.Size = new System.Drawing.Size(190, 300);
            this.symPickerPanel.TabIndex = 4;
            // 
            // pred
            // 
            this.pred.Image = global::TESTAO.Properties.Resources.pred;
            this.pred.Location = new System.Drawing.Point(24, 125);
            this.pred.Name = "pred";
            this.pred.Size = new System.Drawing.Size(36, 36);
            this.pred.TabIndex = 1;
            this.pred.TabStop = false;
            this.pred.Click += new System.EventHandler(this.pred_Click);
            // 
            // pgreen
            // 
            this.pgreen.Image = global::TESTAO.Properties.Resources.pgreen;
            this.pgreen.Location = new System.Drawing.Point(24, 66);
            this.pgreen.Name = "pgreen";
            this.pgreen.Size = new System.Drawing.Size(36, 36);
            this.pgreen.TabIndex = 0;
            this.pgreen.TabStop = false;
            this.pgreen.Click += new System.EventHandler(this.pgreen_Click);
            // 
            // tvPanel
            // 
            this.tvPanel.Controls.Add(this.tvStyleNode);
            this.tvPanel.Location = new System.Drawing.Point(0, 100);
            this.tvPanel.Name = "tvPanel";
            this.tvPanel.Size = new System.Drawing.Size(190, 300);
            this.tvPanel.TabIndex = 3;
            // 
            // tvStyleNode
            // 
            this.tvStyleNode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tvStyleNode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvStyleNode.Location = new System.Drawing.Point(0, 0);
            this.tvStyleNode.Name = "tvStyleNode";
            this.tvStyleNode.Size = new System.Drawing.Size(190, 300);
            this.tvStyleNode.TabIndex = 0;
            this.tvStyleNode.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvStyleNode_AfterSelect);
            // 
            // dividerP1
            // 
            this.dividerP1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(180)))), ((int)(((byte)(160)))));
            this.dividerP1.Location = new System.Drawing.Point(190, 0);
            this.dividerP1.Name = "dividerP1";
            this.dividerP1.Size = new System.Drawing.Size(10, 393);
            this.dividerP1.TabIndex = 2;
            // 
            // startMapPainterBtn
            // 
            this.startMapPainterBtn.BackColor = System.Drawing.Color.Transparent;
            this.startMapPainterBtn.FlatAppearance.BorderSize = 0;
            this.startMapPainterBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startMapPainterBtn.Font = new System.Drawing.Font("Microsoft YaHei", 10F);
            this.startMapPainterBtn.Location = new System.Drawing.Point(12, 54);
            this.startMapPainterBtn.Name = "startMapPainterBtn";
            this.startMapPainterBtn.Size = new System.Drawing.Size(172, 48);
            this.startMapPainterBtn.TabIndex = 1;
            this.startMapPainterBtn.Text = "2.使用格式刷";
            this.startMapPainterBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.startMapPainterBtn.UseVisualStyleBackColor = false;
            this.startMapPainterBtn.Click += new System.EventHandler(this.startMapPainterBtn_Click);
            // 
            // showServerStyleBtn
            // 
            this.showServerStyleBtn.BackColor = System.Drawing.Color.Transparent;
            this.showServerStyleBtn.FlatAppearance.BorderSize = 0;
            this.showServerStyleBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showServerStyleBtn.Font = new System.Drawing.Font("Microsoft YaHei", 10F);
            this.showServerStyleBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(112)))), ((int)(((byte)(67)))));
            this.showServerStyleBtn.Location = new System.Drawing.Point(12, 9);
            this.showServerStyleBtn.Name = "showServerStyleBtn";
            this.showServerStyleBtn.Size = new System.Drawing.Size(172, 48);
            this.showServerStyleBtn.TabIndex = 0;
            this.showServerStyleBtn.Text = "1.读取.StyleServer文件";
            this.showServerStyleBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.showServerStyleBtn.UseVisualStyleBackColor = false;
            this.showServerStyleBtn.Click += new System.EventHandler(this.showServerStyleBtn_Click);
            // 
            // showStylePanel
            // 
            this.showStylePanel.Controls.Add(this.lvSymbolView);
            this.showStylePanel.Location = new System.Drawing.Point(800, 48);
            this.showStylePanel.Name = "showStylePanel";
            this.showStylePanel.Size = new System.Drawing.Size(584, 393);
            this.showStylePanel.TabIndex = 2;
            // 
            // lvSymbolView
            // 
            this.lvSymbolView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSymbolView.Location = new System.Drawing.Point(0, 0);
            this.lvSymbolView.Name = "lvSymbolView";
            this.lvSymbolView.Size = new System.Drawing.Size(584, 393);
            this.lvSymbolView.TabIndex = 0;
            this.lvSymbolView.UseCompatibleStateImageBehavior = false;
            // 
            // axMapControl1
            // 
            this.axMapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axMapControl1.Location = new System.Drawing.Point(0, 0);
            this.axMapControl1.Margin = new System.Windows.Forms.Padding(0);
            this.axMapControl1.Name = "axMapControl1";
            this.axMapControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl1.OcxState")));
            this.axMapControl1.Size = new System.Drawing.Size(600, 393);
            this.axMapControl1.TabIndex = 0;
            this.axMapControl1.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.axMapControl1_OnMouseDown);
            // 
            // mapPainterPanel
            // 
            this.mapPainterPanel.Controls.Add(this.axMapControl1);
            this.mapPainterPanel.Location = new System.Drawing.Point(200, 48);
            this.mapPainterPanel.Margin = new System.Windows.Forms.Padding(0);
            this.mapPainterPanel.Name = "mapPainterPanel";
            this.mapPainterPanel.Size = new System.Drawing.Size(600, 393);
            this.mapPainterPanel.TabIndex = 3;
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
            this.Controls.Add(this.leftPanel);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "StyleDemoForm";
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.leftPanel.ResumeLayout(false);
            this.symPickerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pred)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pgreen)).EndInit();
            this.tvPanel.ResumeLayout(false);
            this.showStylePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).EndInit();
            this.mapPainterPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.Button startMapPainterBtn;
        private System.Windows.Forms.Button showServerStyleBtn;
        private System.Windows.Forms.Panel showStylePanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel dividerP1;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl1;
        private System.Windows.Forms.Panel mapPainterPanel;
        private System.Windows.Forms.Panel tvPanel;
        private System.Windows.Forms.TreeView tvStyleNode;
        private System.Windows.Forms.ListView lvSymbolView;
        private System.Windows.Forms.Panel symPickerPanel;
        private System.Windows.Forms.PictureBox pgreen;
        private System.Windows.Forms.PictureBox pred;
    }
}

