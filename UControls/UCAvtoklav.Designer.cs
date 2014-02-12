namespace PolvakServer.UControls
{
    partial class UCAvtoklav
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCAvtoklav));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.l_tShirt_low = new System.Windows.Forms.Label();
            this.l_tShirt_high = new System.Windows.Forms.Label();
            this.l_fume = new System.Windows.Forms.Label();
            this.l_tApparat = new System.Windows.Forms.Label();
            this.l_pApparat = new System.Windows.Forms.Label();
            this.urovenBar = new DevExpress.XtraEditors.ProgressBarControl();
            this.lUroven = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.urovenBar.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(804, 642);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // l_tShirt_low
            // 
            this.l_tShirt_low.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.l_tShirt_low.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_tShirt_low.ForeColor = System.Drawing.Color.White;
            this.l_tShirt_low.Location = new System.Drawing.Point(643, 527);
            this.l_tShirt_low.Name = "l_tShirt_low";
            this.l_tShirt_low.Size = new System.Drawing.Size(152, 49);
            this.l_tShirt_low.TabIndex = 11;
            this.l_tShirt_low.Text = "0 *C";
            this.l_tShirt_low.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // l_tShirt_high
            // 
            this.l_tShirt_high.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.l_tShirt_high.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_tShirt_high.ForeColor = System.Drawing.Color.White;
            this.l_tShirt_high.Location = new System.Drawing.Point(631, 41);
            this.l_tShirt_high.Name = "l_tShirt_high";
            this.l_tShirt_high.Size = new System.Drawing.Size(153, 50);
            this.l_tShirt_high.TabIndex = 10;
            this.l_tShirt_high.Text = "0 *C";
            this.l_tShirt_high.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // l_fume
            // 
            this.l_fume.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.l_fume.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_fume.ForeColor = System.Drawing.Color.White;
            this.l_fume.Location = new System.Drawing.Point(98, 219);
            this.l_fume.Name = "l_fume";
            this.l_fume.Size = new System.Drawing.Size(154, 53);
            this.l_fume.TabIndex = 9;
            this.l_fume.Text = "0 *C";
            this.l_fume.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // l_tApparat
            // 
            this.l_tApparat.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.l_tApparat.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_tApparat.ForeColor = System.Drawing.Color.White;
            this.l_tApparat.Location = new System.Drawing.Point(97, 90);
            this.l_tApparat.Name = "l_tApparat";
            this.l_tApparat.Size = new System.Drawing.Size(155, 51);
            this.l_tApparat.TabIndex = 8;
            this.l_tApparat.Text = "0 *C";
            this.l_tApparat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // l_pApparat
            // 
            this.l_pApparat.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.l_pApparat.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_pApparat.ForeColor = System.Drawing.Color.White;
            this.l_pApparat.Location = new System.Drawing.Point(97, 26);
            this.l_pApparat.Name = "l_pApparat";
            this.l_pApparat.Size = new System.Drawing.Size(155, 52);
            this.l_pApparat.TabIndex = 7;
            this.l_pApparat.Text = "0 bar";
            this.l_pApparat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // urovenBar
            // 
            this.urovenBar.Location = new System.Drawing.Point(372, 156);
            this.urovenBar.Name = "urovenBar";
            this.urovenBar.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.urovenBar.Properties.ProgressKind = DevExpress.XtraEditors.Controls.ProgressKind.Vertical;
            this.urovenBar.Size = new System.Drawing.Size(33, 411);
            this.urovenBar.TabIndex = 12;
            // 
            // lUroven
            // 
            this.lUroven.BackColor = System.Drawing.Color.White;
            this.lUroven.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lUroven.Location = new System.Drawing.Point(411, 518);
            this.lUroven.Name = "lUroven";
            this.lUroven.Size = new System.Drawing.Size(148, 49);
            this.lUroven.TabIndex = 13;
            this.lUroven.Text = "<0.0m>";
            this.lUroven.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UCAvtoklav
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lUroven);
            this.Controls.Add(this.urovenBar);
            this.Controls.Add(this.l_tShirt_low);
            this.Controls.Add(this.l_tShirt_high);
            this.Controls.Add(this.l_fume);
            this.Controls.Add(this.l_tApparat);
            this.Controls.Add(this.l_pApparat);
            this.Controls.Add(this.pictureBox1);
            this.Name = "UCAvtoklav";
            this.Size = new System.Drawing.Size(804, 642);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.urovenBar.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraEditors.ProgressBarControl urovenBar;
        private System.Windows.Forms.Label lUroven;
        private System.Windows.Forms.Label l_tShirt_low;
        private System.Windows.Forms.Label l_tShirt_high;
        private System.Windows.Forms.Label l_fume;
        private System.Windows.Forms.Label l_tApparat;
        private System.Windows.Forms.Label l_pApparat;
    }
}
