namespace iCarto.common.icontrols
{
    partial class TagForm
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
            this.cornerTag = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.cornerTag)).BeginInit();
            this.SuspendLayout();
            // 
            // cornerTag
            // 
            this.cornerTag.Image = global::iCarto.Properties.Resources.CornerTag;
            this.cornerTag.Location = new System.Drawing.Point(0, 0);
            this.cornerTag.Margin = new System.Windows.Forms.Padding(0);
            this.cornerTag.Name = "cornerTag";
            this.cornerTag.Size = new System.Drawing.Size(128, 128);
            this.cornerTag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cornerTag.TabIndex = 0;
            this.cornerTag.TabStop = false;
            // 
            // TagForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 320);
            this.Controls.Add(this.cornerTag);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TagForm";
            this.Text = "TagForm";
            ((System.ComponentModel.ISupportInitialize)(this.cornerTag)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox cornerTag;
    }
}