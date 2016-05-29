namespace GUI_controll
{
    partial class Settings
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
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb_steeringaxis = new System.Windows.Forms.RadioButton();
            this.rb_tank = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.S0 = new System.Windows.Forms.CheckBox();
            this.S1 = new System.Windows.Forms.CheckBox();
            this.S5 = new System.Windows.Forms.CheckBox();
            this.S3 = new System.Windows.Forms.CheckBox();
            this.S4 = new System.Windows.Forms.CheckBox();
            this.S2 = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.r_front = new System.Windows.Forms.TextBox();
            this.y_front = new System.Windows.Forms.TextBox();
            this.y_rear = new System.Windows.Forms.TextBox();
            this.r_rear = new System.Windows.Forms.TextBox();
            this.y_right = new System.Windows.Forms.TextBox();
            this.r_right = new System.Windows.Forms.TextBox();
            this.y_right_rear = new System.Windows.Forms.TextBox();
            this.r_right_rear = new System.Windows.Forms.TextBox();
            this.y_left_rear = new System.Windows.Forms.TextBox();
            this.r_left_rear = new System.Windows.Forms.TextBox();
            this.y_left = new System.Windows.Forms.TextBox();
            this.r_left = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_cancel
            // 
            this.btn_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cancel.Location = new System.Drawing.Point(232, 588);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 0;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ok.Location = new System.Drawing.Point(323, 588);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 1;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb_steeringaxis);
            this.groupBox1.Controls.Add(this.rb_tank);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(137, 90);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Steering";
            // 
            // rb_steeringaxis
            // 
            this.rb_steeringaxis.AutoSize = true;
            this.rb_steeringaxis.Location = new System.Drawing.Point(16, 58);
            this.rb_steeringaxis.Name = "rb_steeringaxis";
            this.rb_steeringaxis.Size = new System.Drawing.Size(85, 17);
            this.rb_steeringaxis.TabIndex = 4;
            this.rb_steeringaxis.TabStop = true;
            this.rb_steeringaxis.Text = "Steering axis";
            this.rb_steeringaxis.UseVisualStyleBackColor = true;
            // 
            // rb_tank
            // 
            this.rb_tank.AutoSize = true;
            this.rb_tank.Location = new System.Drawing.Point(16, 35);
            this.rb_tank.Name = "rb_tank";
            this.rb_tank.Size = new System.Drawing.Size(50, 17);
            this.rb_tank.TabIndex = 3;
            this.rb_tank.TabStop = true;
            this.rb_tank.Text = "Tank";
            this.rb_tank.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GrayText;
            this.panel1.Location = new System.Drawing.Point(143, 113);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(95, 166);
            this.panel1.TabIndex = 3;
            // 
            // S0
            // 
            this.S0.AutoSize = true;
            this.S0.Location = new System.Drawing.Point(183, 93);
            this.S0.Name = "S0";
            this.S0.Size = new System.Drawing.Size(15, 14);
            this.S0.TabIndex = 4;
            this.S0.UseVisualStyleBackColor = true;
            // 
            // S1
            // 
            this.S1.AutoSize = true;
            this.S1.Location = new System.Drawing.Point(244, 113);
            this.S1.Name = "S1";
            this.S1.Size = new System.Drawing.Size(15, 14);
            this.S1.TabIndex = 5;
            this.S1.UseVisualStyleBackColor = true;
            // 
            // S5
            // 
            this.S5.AutoSize = true;
            this.S5.Location = new System.Drawing.Point(122, 113);
            this.S5.Name = "S5";
            this.S5.Size = new System.Drawing.Size(15, 14);
            this.S5.TabIndex = 6;
            this.S5.UseVisualStyleBackColor = true;
            // 
            // S3
            // 
            this.S3.AutoSize = true;
            this.S3.Location = new System.Drawing.Point(183, 285);
            this.S3.Name = "S3";
            this.S3.Size = new System.Drawing.Size(15, 14);
            this.S3.TabIndex = 7;
            this.S3.UseVisualStyleBackColor = true;
            // 
            // S4
            // 
            this.S4.AutoSize = true;
            this.S4.Location = new System.Drawing.Point(122, 265);
            this.S4.Name = "S4";
            this.S4.Size = new System.Drawing.Size(15, 14);
            this.S4.TabIndex = 16;
            this.S4.UseVisualStyleBackColor = true;
            // 
            // S2
            // 
            this.S2.AutoSize = true;
            this.S2.Location = new System.Drawing.Point(244, 265);
            this.S2.Name = "S2";
            this.S2.Size = new System.Drawing.Size(15, 14);
            this.S2.TabIndex = 19;
            this.S2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.y_left);
            this.groupBox2.Controls.Add(this.r_left);
            this.groupBox2.Controls.Add(this.y_left_rear);
            this.groupBox2.Controls.Add(this.r_left_rear);
            this.groupBox2.Controls.Add(this.y_right_rear);
            this.groupBox2.Controls.Add(this.r_right_rear);
            this.groupBox2.Controls.Add(this.y_right);
            this.groupBox2.Controls.Add(this.r_right);
            this.groupBox2.Controls.Add(this.y_rear);
            this.groupBox2.Controls.Add(this.r_rear);
            this.groupBox2.Controls.Add(this.y_front);
            this.groupBox2.Controls.Add(this.r_front);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.S2);
            this.groupBox2.Controls.Add(this.S0);
            this.groupBox2.Controls.Add(this.S1);
            this.groupBox2.Controls.Add(this.S5);
            this.groupBox2.Controls.Add(this.S4);
            this.groupBox2.Controls.Add(this.S3);
            this.groupBox2.Location = new System.Drawing.Point(12, 108);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(387, 413);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sensors";
            // 
            // r_front
            // 
            this.r_front.BackColor = System.Drawing.Color.Red;
            this.r_front.Location = new System.Drawing.Point(143, 67);
            this.r_front.Name = "r_front";
            this.r_front.Size = new System.Drawing.Size(100, 20);
            this.r_front.TabIndex = 20;
            this.r_front.Text = "0";
            // 
            // y_front
            // 
            this.y_front.BackColor = System.Drawing.Color.Yellow;
            this.y_front.Location = new System.Drawing.Point(143, 41);
            this.y_front.Name = "y_front";
            this.y_front.Size = new System.Drawing.Size(100, 20);
            this.y_front.TabIndex = 21;
            this.y_front.Text = "0";
            this.y_front.TextChanged += new System.EventHandler(this.y_front_TextChanged);
            // 
            // y_rear
            // 
            this.y_rear.BackColor = System.Drawing.Color.Yellow;
            this.y_rear.Location = new System.Drawing.Point(143, 303);
            this.y_rear.Name = "y_rear";
            this.y_rear.Size = new System.Drawing.Size(100, 20);
            this.y_rear.TabIndex = 23;
            this.y_rear.Text = "0";
            // 
            // r_rear
            // 
            this.r_rear.BackColor = System.Drawing.Color.Red;
            this.r_rear.Location = new System.Drawing.Point(143, 329);
            this.r_rear.Name = "r_rear";
            this.r_rear.Size = new System.Drawing.Size(100, 20);
            this.r_rear.TabIndex = 22;
            this.r_rear.Text = "0";
            // 
            // y_right
            // 
            this.y_right.BackColor = System.Drawing.Color.Yellow;
            this.y_right.Location = new System.Drawing.Point(265, 96);
            this.y_right.Name = "y_right";
            this.y_right.Size = new System.Drawing.Size(100, 20);
            this.y_right.TabIndex = 25;
            this.y_right.Text = "0";
            // 
            // r_right
            // 
            this.r_right.BackColor = System.Drawing.Color.Red;
            this.r_right.Location = new System.Drawing.Point(265, 122);
            this.r_right.Name = "r_right";
            this.r_right.Size = new System.Drawing.Size(100, 20);
            this.r_right.TabIndex = 24;
            this.r_right.Text = "0";
            // 
            // y_right_rear
            // 
            this.y_right_rear.BackColor = System.Drawing.Color.Yellow;
            this.y_right_rear.Location = new System.Drawing.Point(265, 250);
            this.y_right_rear.Name = "y_right_rear";
            this.y_right_rear.Size = new System.Drawing.Size(100, 20);
            this.y_right_rear.TabIndex = 27;
            this.y_right_rear.Text = "0";
            // 
            // r_right_rear
            // 
            this.r_right_rear.BackColor = System.Drawing.Color.Red;
            this.r_right_rear.Location = new System.Drawing.Point(265, 276);
            this.r_right_rear.Name = "r_right_rear";
            this.r_right_rear.Size = new System.Drawing.Size(100, 20);
            this.r_right_rear.TabIndex = 26;
            this.r_right_rear.Text = "0";
            // 
            // y_left_rear
            // 
            this.y_left_rear.BackColor = System.Drawing.Color.Yellow;
            this.y_left_rear.Location = new System.Drawing.Point(16, 250);
            this.y_left_rear.Name = "y_left_rear";
            this.y_left_rear.Size = new System.Drawing.Size(100, 20);
            this.y_left_rear.TabIndex = 29;
            this.y_left_rear.Text = "0";
            // 
            // r_left_rear
            // 
            this.r_left_rear.BackColor = System.Drawing.Color.Red;
            this.r_left_rear.Location = new System.Drawing.Point(16, 276);
            this.r_left_rear.Name = "r_left_rear";
            this.r_left_rear.Size = new System.Drawing.Size(100, 20);
            this.r_left_rear.TabIndex = 28;
            this.r_left_rear.Text = "0";
            // 
            // y_left
            // 
            this.y_left.BackColor = System.Drawing.Color.Yellow;
            this.y_left.Location = new System.Drawing.Point(16, 96);
            this.y_left.Name = "y_left";
            this.y_left.Size = new System.Drawing.Size(100, 20);
            this.y_left.TabIndex = 31;
            this.y_left.Text = "0";
            // 
            // r_left
            // 
            this.r_left.BackColor = System.Drawing.Color.Red;
            this.r_left.Location = new System.Drawing.Point(16, 122);
            this.r_left.Name = "r_left";
            this.r_left.Size = new System.Drawing.Size(100, 20);
            this.r_left.TabIndex = 30;
            this.r_left.Text = "0";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 384);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 32;
            this.button1.Text = "Reset";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 623);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.btn_cancel);
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.Shown += new System.EventHandler(this.Settings_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rb_steeringaxis;
        private System.Windows.Forms.RadioButton rb_tank;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox S0;
        private System.Windows.Forms.CheckBox S1;
        private System.Windows.Forms.CheckBox S5;
        private System.Windows.Forms.CheckBox S3;
        private System.Windows.Forms.CheckBox S4;
        private System.Windows.Forms.CheckBox S2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox y_left;
        private System.Windows.Forms.TextBox r_left;
        private System.Windows.Forms.TextBox y_left_rear;
        private System.Windows.Forms.TextBox r_left_rear;
        private System.Windows.Forms.TextBox y_right_rear;
        private System.Windows.Forms.TextBox r_right_rear;
        private System.Windows.Forms.TextBox y_right;
        private System.Windows.Forms.TextBox r_right;
        private System.Windows.Forms.TextBox y_rear;
        private System.Windows.Forms.TextBox r_rear;
        private System.Windows.Forms.TextBox y_front;
        private System.Windows.Forms.TextBox r_front;
        private System.Windows.Forms.Button button1;
    }
}