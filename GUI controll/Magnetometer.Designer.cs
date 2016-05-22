namespace GUI_controll
{
    partial class Magnetometer
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.background1 = new System.Windows.Forms.Panel();
            this.vp1 = new System.Windows.Forms.Panel();
            this.background2 = new System.Windows.Forms.Panel();
            this.vp2 = new System.Windows.Forms.Panel();
            this.background3 = new System.Windows.Forms.Panel();
            this.vp3 = new System.Windows.Forms.Panel();
            this.background1.SuspendLayout();
            this.background2.SuspendLayout();
            this.background3.SuspendLayout();
            this.SuspendLayout();
            // 
            // background1
            // 
            this.background1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.background1.Controls.Add(this.vp1);
            this.background1.Location = new System.Drawing.Point(0, 0);
            this.background1.Name = "background1";
            this.background1.Size = new System.Drawing.Size(100, 200);
            this.background1.TabIndex = 0;
            // 
            // vp1
            // 
            this.vp1.BackColor = System.Drawing.Color.Red;
            this.vp1.Location = new System.Drawing.Point(0, 82);
            this.vp1.Name = "vp1";
            this.vp1.Size = new System.Drawing.Size(100, 100);
            this.vp1.TabIndex = 1;
            // 
            // background2
            // 
            this.background2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.background2.Controls.Add(this.vp2);
            this.background2.Location = new System.Drawing.Point(101, 0);
            this.background2.Name = "background2";
            this.background2.Size = new System.Drawing.Size(100, 200);
            this.background2.TabIndex = 1;
            // 
            // vp2
            // 
            this.vp2.BackColor = System.Drawing.Color.Lime;
            this.vp2.Location = new System.Drawing.Point(0, 82);
            this.vp2.Name = "vp2";
            this.vp2.Size = new System.Drawing.Size(100, 100);
            this.vp2.TabIndex = 1;
            // 
            // background3
            // 
            this.background3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.background3.Controls.Add(this.vp3);
            this.background3.Location = new System.Drawing.Point(201, 0);
            this.background3.Name = "background3";
            this.background3.Size = new System.Drawing.Size(100, 200);
            this.background3.TabIndex = 1;
            // 
            // vp3
            // 
            this.vp3.BackColor = System.Drawing.Color.Blue;
            this.vp3.Location = new System.Drawing.Point(0, 82);
            this.vp3.Name = "vp3";
            this.vp3.Size = new System.Drawing.Size(100, 100);
            this.vp3.TabIndex = 1;
            // 
            // Magnetometer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.background2);
            this.Controls.Add(this.background3);
            this.Controls.Add(this.background1);
            this.Name = "Magnetometer";
            this.Size = new System.Drawing.Size(300, 200);
            this.Load += new System.EventHandler(this.Magnetometer_Load);
            this.Resize += new System.EventHandler(this.Magnetometer_Resize);
            this.background1.ResumeLayout(false);
            this.background2.ResumeLayout(false);
            this.background3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel background1;
        private System.Windows.Forms.Panel background2;
        private System.Windows.Forms.Panel background3;
        private System.Windows.Forms.Panel vp1;
        private System.Windows.Forms.Panel vp2;
        private System.Windows.Forms.Panel vp3;
    }
}
