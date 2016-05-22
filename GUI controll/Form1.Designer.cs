namespace GUI_controll
{
    partial class Form1
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

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, -1.5D);
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btn_manuel = new System.Windows.Forms.Button();
            this.btn_disconnect = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.mapexplr = new GMap.NET.WindowsForms.GMapControl();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox12 = new System.Windows.Forms.PictureBox();
            this.label12 = new System.Windows.Forms.Label();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.addToRouteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.driveToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fghjklToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dfghjklToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.googleMapsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.googleMapsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pouteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ladenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speichernToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folgeRouteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goHomeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.carToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.webKitBrowser1 = new WebKit.WebKitBrowser();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.btn_connect = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.rb_lokalcontrol = new System.Windows.Forms.RadioButton();
            this.rb_autopilot = new System.Windows.Forms.RadioButton();
            this.rb_idle = new System.Windows.Forms.RadioButton();
            this.rb_directcontrol = new System.Windows.Forms.RadioButton();
            this.l_status = new System.Windows.Forms.Label();
            this.l_GamePadStatus = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.menuStrip3 = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.einstellungenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.einstellungenToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.extrasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.akustischeWarnungenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aktuelleStellungAlsStandartSetzenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.l_temp = new System.Windows.Forms.Label();
            this.l_temperatur = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.hsb_cam = new System.Windows.Forms.HScrollBar();
            this.vScrollBar2 = new System.Windows.Forms.VScrollBar();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.l_left_hinten = new System.Windows.Forms.Label();
            this.tb_left_hinten = new System.Windows.Forms.TrackBar();
            this.l_right_hinten = new System.Windows.Forms.Label();
            this.tb_right_hinten = new System.Windows.Forms.TrackBar();
            this.l_right_vorn = new System.Windows.Forms.Label();
            this.l_left_vorn = new System.Windows.Forms.Label();
            this.l_back = new System.Windows.Forms.Label();
            this.l_front = new System.Windows.Forms.Label();
            this.tb_left_vorn = new System.Windows.Forms.TrackBar();
            this.tb_right_vorn = new System.Windows.Forms.TrackBar();
            this.tb_back = new System.Windows.Forms.TrackBar();
            this.tb_front = new System.Windows.Forms.TrackBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).BeginInit();
            this.menuStrip2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.menuStrip3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_left_hinten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_right_hinten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_left_vorn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_right_vorn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_back)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_front)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "COMM,LOCAL",
            "COMM,AI"});
            this.comboBox1.Location = new System.Drawing.Point(13, 78);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(138, 21);
            this.comboBox1.TabIndex = 48;
            // 
            // btn_manuel
            // 
            this.btn_manuel.Location = new System.Drawing.Point(13, 49);
            this.btn_manuel.Name = "btn_manuel";
            this.btn_manuel.Size = new System.Drawing.Size(138, 23);
            this.btn_manuel.TabIndex = 45;
            this.btn_manuel.Text = "Manuel send";
            this.btn_manuel.UseVisualStyleBackColor = true;
            this.btn_manuel.Click += new System.EventHandler(this.button3_Click);
            // 
            // btn_disconnect
            // 
            this.btn_disconnect.Location = new System.Drawing.Point(3, 212);
            this.btn_disconnect.Name = "btn_disconnect";
            this.btn_disconnect.Size = new System.Drawing.Size(75, 23);
            this.btn_disconnect.TabIndex = 33;
            this.btn_disconnect.Text = "Disconnect";
            this.btn_disconnect.UseVisualStyleBackColor = true;
            this.btn_disconnect.Click += new System.EventHandler(this.button2_Click);
            // 
            // mapexplr
            // 
            this.mapexplr.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mapexplr.Bearing = 0F;
            this.mapexplr.CanDragMap = true;
            this.mapexplr.EmptyTileColor = System.Drawing.Color.Navy;
            this.mapexplr.GrayScaleMode = false;
            this.mapexplr.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.mapexplr.LevelsKeepInMemmory = 5;
            this.mapexplr.Location = new System.Drawing.Point(0, 32);
            this.mapexplr.MarkersEnabled = true;
            this.mapexplr.MaxZoom = 2;
            this.mapexplr.MinZoom = 2;
            this.mapexplr.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.mapexplr.Name = "mapexplr";
            this.mapexplr.NegativeMode = false;
            this.mapexplr.PolygonsEnabled = true;
            this.mapexplr.RetryLoadTile = 0;
            this.mapexplr.RoutesEnabled = true;
            this.mapexplr.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.mapexplr.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.mapexplr.ShowTileGridLines = false;
            this.mapexplr.Size = new System.Drawing.Size(637, 350);
            this.mapexplr.TabIndex = 40;
            this.mapexplr.Zoom = 0D;
            this.mapexplr.Load += new System.EventHandler(this.mapexplr_Load_1);
            this.mapexplr.Click += new System.EventHandler(this.mapexplr_Click);
            this.mapexplr.Leave += new System.EventHandler(this.mapexplr_Leave);
            this.mapexplr.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mapexplr_MouseClick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.webKitBrowser1);
            this.splitContainer1.Size = new System.Drawing.Size(641, 784);
            this.splitContainer1.SplitterDistance = 388;
            this.splitContainer1.TabIndex = 42;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.pictureBox12);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.menuStrip2);
            this.panel3.Controls.Add(this.mapexplr);
            this.panel3.Controls.Add(this.menuStrip1);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(634, 382);
            this.panel3.TabIndex = 48;
            // 
            // pictureBox12
            // 
            this.pictureBox12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox12.BackColor = System.Drawing.Color.Black;
            this.pictureBox12.Location = new System.Drawing.Point(489, 28);
            this.pictureBox12.Name = "pictureBox12";
            this.pictureBox12.Size = new System.Drawing.Size(148, 108);
            this.pictureBox12.TabIndex = 50;
            this.pictureBox12.TabStop = false;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(2, 352);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 13);
            this.label12.TabIndex = 49;
            this.label12.Text = "Last point:";
            // 
            // menuStrip2
            // 
            this.menuStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip2.Location = new System.Drawing.Point(49, 214);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(55, 24);
            this.menuStrip2.TabIndex = 41;
            this.menuStrip2.Text = "menuStrip2";
            this.menuStrip2.Visible = false;
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToRouteToolStripMenuItem,
            this.driveToToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(47, 20);
            this.toolStripMenuItem1.Text = "Point";
            // 
            // addToRouteToolStripMenuItem
            // 
            this.addToRouteToolStripMenuItem.Name = "addToRouteToolStripMenuItem";
            this.addToRouteToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.addToRouteToolStripMenuItem.Text = "Add to route";
            this.addToRouteToolStripMenuItem.Click += new System.EventHandler(this.addToRouteToolStripMenuItem_Click);
            // 
            // driveToToolStripMenuItem
            // 
            this.driveToToolStripMenuItem.Name = "driveToToolStripMenuItem";
            this.driveToToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.driveToToolStripMenuItem.Text = "Drive to";
            this.driveToToolStripMenuItem.Click += new System.EventHandler(this.driveToToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fghjklToolStripMenuItem,
            this.pouteToolStripMenuItem,
            this.goHomeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(634, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fghjklToolStripMenuItem
            // 
            this.fghjklToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dfghjklToolStripMenuItem,
            this.googleMapsToolStripMenuItem,
            this.googleMapsToolStripMenuItem1});
            this.fghjklToolStripMenuItem.Name = "fghjklToolStripMenuItem";
            this.fghjklToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.fghjklToolStripMenuItem.Text = "Karte";
            // 
            // dfghjklToolStripMenuItem
            // 
            this.dfghjklToolStripMenuItem.Name = "dfghjklToolStripMenuItem";
            this.dfghjklToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.dfghjklToolStripMenuItem.Text = "OSM";
            this.dfghjklToolStripMenuItem.Click += new System.EventHandler(this.dfghjklToolStripMenuItem_Click);
            // 
            // googleMapsToolStripMenuItem
            // 
            this.googleMapsToolStripMenuItem.Name = "googleMapsToolStripMenuItem";
            this.googleMapsToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.googleMapsToolStripMenuItem.Text = "Google Maps";
            this.googleMapsToolStripMenuItem.Click += new System.EventHandler(this.googleMapsToolStripMenuItem_Click);
            // 
            // googleMapsToolStripMenuItem1
            // 
            this.googleMapsToolStripMenuItem1.Name = "googleMapsToolStripMenuItem1";
            this.googleMapsToolStripMenuItem1.Size = new System.Drawing.Size(177, 22);
            this.googleMapsToolStripMenuItem1.Text = "GoogleSatelliteMap";
            this.googleMapsToolStripMenuItem1.Click += new System.EventHandler(this.googleMapsToolStripMenuItem1_Click);
            // 
            // pouteToolStripMenuItem
            // 
            this.pouteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ladenToolStripMenuItem,
            this.speichernToolStripMenuItem,
            this.folgeRouteToolStripMenuItem});
            this.pouteToolStripMenuItem.Name = "pouteToolStripMenuItem";
            this.pouteToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.pouteToolStripMenuItem.Text = "Route";
            // 
            // ladenToolStripMenuItem
            // 
            this.ladenToolStripMenuItem.Name = "ladenToolStripMenuItem";
            this.ladenToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.ladenToolStripMenuItem.Text = "Laden";
            this.ladenToolStripMenuItem.Click += new System.EventHandler(this.ladenToolStripMenuItem_Click);
            // 
            // speichernToolStripMenuItem
            // 
            this.speichernToolStripMenuItem.Name = "speichernToolStripMenuItem";
            this.speichernToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.speichernToolStripMenuItem.Text = "Speichern";
            this.speichernToolStripMenuItem.Click += new System.EventHandler(this.speichernToolStripMenuItem_Click);
            // 
            // folgeRouteToolStripMenuItem
            // 
            this.folgeRouteToolStripMenuItem.Name = "folgeRouteToolStripMenuItem";
            this.folgeRouteToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.folgeRouteToolStripMenuItem.Text = "Folge Route";
            this.folgeRouteToolStripMenuItem.Click += new System.EventHandler(this.folgeRouteToolStripMenuItem_Click);
            // 
            // goHomeToolStripMenuItem
            // 
            this.goHomeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.carToolStripMenuItem});
            this.goHomeToolStripMenuItem.Name = "goHomeToolStripMenuItem";
            this.goHomeToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.goHomeToolStripMenuItem.Text = "Go home";
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.homeToolStripMenuItem.Text = "Home";
            this.homeToolStripMenuItem.Click += new System.EventHandler(this.homeToolStripMenuItem_Click);
            // 
            // carToolStripMenuItem
            // 
            this.carToolStripMenuItem.CheckOnClick = true;
            this.carToolStripMenuItem.Name = "carToolStripMenuItem";
            this.carToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.carToolStripMenuItem.Text = "Car";
            this.carToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.carToolStripMenuItem_CheckStateChanged);
            this.carToolStripMenuItem.Click += new System.EventHandler(this.carToolStripMenuItem_Click);
            // 
            // webKitBrowser1
            // 
            this.webKitBrowser1.BackColor = System.Drawing.Color.White;
            this.webKitBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webKitBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webKitBrowser1.Name = "webKitBrowser1";
            this.webKitBrowser1.Size = new System.Drawing.Size(637, 388);
            this.webKitBrowser1.TabIndex = 1;
            this.webKitBrowser1.Url = null;
            // 
            // btn_connect
            // 
            this.btn_connect.Location = new System.Drawing.Point(84, 212);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(97, 23);
            this.btn_connect.TabIndex = 44;
            this.btn_connect.Text = "Wait to connect";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox2
            // 
            this.listBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(0, 245);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(580, 537);
            this.listBox2.TabIndex = 47;
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 24);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            this.splitContainer2.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer2_Panel1_Paint);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer2.Size = new System.Drawing.Size(1617, 784);
            this.splitContainer2.SplitterDistance = 972;
            this.splitContainer2.TabIndex = 49;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(265, 209);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(311, 23);
            this.progressBar1.TabIndex = 55;
            // 
            // rb_lokalcontrol
            // 
            this.rb_lokalcontrol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rb_lokalcontrol.AutoSize = true;
            this.rb_lokalcontrol.Location = new System.Drawing.Point(491, 95);
            this.rb_lokalcontrol.Name = "rb_lokalcontrol";
            this.rb_lokalcontrol.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rb_lokalcontrol.Size = new System.Drawing.Size(83, 17);
            this.rb_lokalcontrol.TabIndex = 54;
            this.rb_lokalcontrol.Text = "Localcontrol";
            this.rb_lokalcontrol.UseVisualStyleBackColor = true;
            this.rb_lokalcontrol.CheckedChanged += new System.EventHandler(this.rb_lokalcontrol_CheckedChanged);
            // 
            // rb_autopilot
            // 
            this.rb_autopilot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rb_autopilot.AutoSize = true;
            this.rb_autopilot.Location = new System.Drawing.Point(508, 118);
            this.rb_autopilot.Name = "rb_autopilot";
            this.rb_autopilot.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rb_autopilot.Size = new System.Drawing.Size(66, 17);
            this.rb_autopilot.TabIndex = 53;
            this.rb_autopilot.Text = "Autopilot";
            this.rb_autopilot.UseVisualStyleBackColor = true;
            this.rb_autopilot.CheckedChanged += new System.EventHandler(this.rb_autopilot_CheckedChanged);
            // 
            // rb_idle
            // 
            this.rb_idle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rb_idle.AutoSize = true;
            this.rb_idle.Checked = true;
            this.rb_idle.Location = new System.Drawing.Point(532, 49);
            this.rb_idle.Name = "rb_idle";
            this.rb_idle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rb_idle.Size = new System.Drawing.Size(42, 17);
            this.rb_idle.TabIndex = 52;
            this.rb_idle.TabStop = true;
            this.rb_idle.Text = "Idle";
            this.rb_idle.UseVisualStyleBackColor = true;
            this.rb_idle.CheckedChanged += new System.EventHandler(this.rb_idle_CheckedChanged);
            // 
            // rb_directcontrol
            // 
            this.rb_directcontrol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rb_directcontrol.AutoSize = true;
            this.rb_directcontrol.Location = new System.Drawing.Point(489, 72);
            this.rb_directcontrol.Name = "rb_directcontrol";
            this.rb_directcontrol.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rb_directcontrol.Size = new System.Drawing.Size(85, 17);
            this.rb_directcontrol.TabIndex = 51;
            this.rb_directcontrol.Text = "Directcontrol";
            this.rb_directcontrol.UseVisualStyleBackColor = true;
            this.rb_directcontrol.CheckedChanged += new System.EventHandler(this.rb_directcontrol_CheckedChanged);
            // 
            // l_status
            // 
            this.l_status.AutoSize = true;
            this.l_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_status.Location = new System.Drawing.Point(10, 7);
            this.l_status.Name = "l_status";
            this.l_status.Size = new System.Drawing.Size(110, 39);
            this.l_status.TabIndex = 49;
            this.l_status.Text = "offline";
            // 
            // l_GamePadStatus
            // 
            this.l_GamePadStatus.AutoSize = true;
            this.l_GamePadStatus.Location = new System.Drawing.Point(10, 102);
            this.l_GamePadStatus.Name = "l_GamePadStatus";
            this.l_GamePadStatus.Size = new System.Drawing.Size(141, 13);
            this.l_GamePadStatus.TabIndex = 27;
            this.l_GamePadStatus.Text = "GamePad Status unbekannt";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(187, 216);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 17);
            this.checkBox1.TabIndex = 49;
            this.checkBox1.Text = "Autoscroll";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // menuStrip3
            // 
            this.menuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.einstellungenToolStripMenuItem,
            this.extrasToolStripMenuItem});
            this.menuStrip3.Location = new System.Drawing.Point(0, 0);
            this.menuStrip3.Name = "menuStrip3";
            this.menuStrip3.Size = new System.Drawing.Size(1617, 24);
            this.menuStrip3.TabIndex = 50;
            this.menuStrip3.Text = "menuStrip3";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.dateiToolStripMenuItem.Text = "Datei";
            // 
            // einstellungenToolStripMenuItem
            // 
            this.einstellungenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.einstellungenToolStripMenuItem1,
            this.toolStripTextBox1});
            this.einstellungenToolStripMenuItem.Name = "einstellungenToolStripMenuItem";
            this.einstellungenToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.einstellungenToolStripMenuItem.Text = "Einstellungen";
            // 
            // einstellungenToolStripMenuItem1
            // 
            this.einstellungenToolStripMenuItem1.Name = "einstellungenToolStripMenuItem1";
            this.einstellungenToolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
            this.einstellungenToolStripMenuItem1.Text = "Einstellungen";
            this.einstellungenToolStripMenuItem1.Click += new System.EventHandler(this.einstellungenToolStripMenuItem1_Click);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox1.Text = "http://192.168.0.10/html/";
            this.toolStripTextBox1.Click += new System.EventHandler(this.toolStripTextBox1_Click);
            this.toolStripTextBox1.TextChanged += new System.EventHandler(this.toolStripTextBox1_TextChanged);
            // 
            // extrasToolStripMenuItem
            // 
            this.extrasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.akustischeWarnungenToolStripMenuItem,
            this.aktuelleStellungAlsStandartSetzenToolStripMenuItem});
            this.extrasToolStripMenuItem.Name = "extrasToolStripMenuItem";
            this.extrasToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.extrasToolStripMenuItem.Text = "Extras";
            // 
            // akustischeWarnungenToolStripMenuItem
            // 
            this.akustischeWarnungenToolStripMenuItem.CheckOnClick = true;
            this.akustischeWarnungenToolStripMenuItem.Name = "akustischeWarnungenToolStripMenuItem";
            this.akustischeWarnungenToolStripMenuItem.Size = new System.Drawing.Size(263, 22);
            this.akustischeWarnungenToolStripMenuItem.Text = "Akustische Warnungen";
            // 
            // aktuelleStellungAlsStandartSetzenToolStripMenuItem
            // 
            this.aktuelleStellungAlsStandartSetzenToolStripMenuItem.Name = "aktuelleStellungAlsStandartSetzenToolStripMenuItem";
            this.aktuelleStellungAlsStandartSetzenToolStripMenuItem.Size = new System.Drawing.Size(263, 22);
            this.aktuelleStellungAlsStandartSetzenToolStripMenuItem.Text = "Aktuelle Stellung als Standart setzen";
            this.aktuelleStellungAlsStandartSetzenToolStripMenuItem.Click += new System.EventHandler(this.aktuelleStellungAlsStandartSetzenToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // splitContainer3
            // 
            this.splitContainer3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.l_status);
            this.splitContainer3.Panel1.Controls.Add(this.progressBar1);
            this.splitContainer3.Panel1.Controls.Add(this.btn_disconnect);
            this.splitContainer3.Panel1.Controls.Add(this.rb_lokalcontrol);
            this.splitContainer3.Panel1.Controls.Add(this.btn_connect);
            this.splitContainer3.Panel1.Controls.Add(this.rb_autopilot);
            this.splitContainer3.Panel1.Controls.Add(this.listBox2);
            this.splitContainer3.Panel1.Controls.Add(this.rb_idle);
            this.splitContainer3.Panel1.Controls.Add(this.checkBox1);
            this.splitContainer3.Panel1.Controls.Add(this.rb_directcontrol);
            this.splitContainer3.Panel1.Controls.Add(this.btn_manuel);
            this.splitContainer3.Panel1.Controls.Add(this.comboBox1);
            this.splitContainer3.Panel1.Controls.Add(this.l_GamePadStatus);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer3.Size = new System.Drawing.Size(972, 784);
            this.splitContainer3.SplitterDistance = 581;
            this.splitContainer3.SplitterWidth = 10;
            this.splitContainer3.TabIndex = 60;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chart1);
            this.groupBox1.Controls.Add(this.l_temp);
            this.groupBox1.Controls.Add(this.l_temperatur);
            this.groupBox1.Location = new System.Drawing.Point(3, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(371, 157);
            this.groupBox1.TabIndex = 62;
            this.groupBox1.TabStop = false;
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chart1.BackColor = System.Drawing.SystemColors.Control;
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            this.chart1.Location = new System.Drawing.Point(6, 0);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.Name = "Series1";
            series2.Points.Add(dataPoint2);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(218, 157);
            this.chart1.TabIndex = 51;
            this.chart1.Text = "chart1";
            // 
            // l_temp
            // 
            this.l_temp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.l_temp.AutoSize = true;
            this.l_temp.Location = new System.Drawing.Point(295, 16);
            this.l_temp.Name = "l_temp";
            this.l_temp.Size = new System.Drawing.Size(25, 13);
            this.l_temp.TabIndex = 58;
            this.l_temp.Text = "n.a.";
            // 
            // l_temperatur
            // 
            this.l_temperatur.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.l_temperatur.AutoSize = true;
            this.l_temperatur.Location = new System.Drawing.Point(230, 16);
            this.l_temperatur.Name = "l_temperatur";
            this.l_temperatur.Size = new System.Drawing.Size(64, 13);
            this.l_temperatur.TabIndex = 57;
            this.l_temperatur.Text = "Temperatur:";
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(377, 178);
            this.listBox1.TabIndex = 61;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.hsb_cam);
            this.panel2.Controls.Add(this.vScrollBar2);
            this.panel2.Controls.Add(this.vScrollBar1);
            this.panel2.Controls.Add(this.l_left_hinten);
            this.panel2.Controls.Add(this.tb_left_hinten);
            this.panel2.Controls.Add(this.l_right_hinten);
            this.panel2.Controls.Add(this.tb_right_hinten);
            this.panel2.Controls.Add(this.l_right_vorn);
            this.panel2.Controls.Add(this.l_left_vorn);
            this.panel2.Controls.Add(this.l_back);
            this.panel2.Controls.Add(this.l_front);
            this.panel2.Controls.Add(this.tb_left_vorn);
            this.panel2.Controls.Add(this.tb_right_vorn);
            this.panel2.Controls.Add(this.tb_back);
            this.panel2.Controls.Add(this.tb_front);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Location = new System.Drawing.Point(-5, 164);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(381, 429);
            this.panel2.TabIndex = 60;
            // 
            // hsb_cam
            // 
            this.hsb_cam.Location = new System.Drawing.Point(27, 17);
            this.hsb_cam.Maximum = 180;
            this.hsb_cam.Name = "hsb_cam";
            this.hsb_cam.Size = new System.Drawing.Size(337, 17);
            this.hsb_cam.TabIndex = 53;
            this.hsb_cam.Value = 90;
            // 
            // vScrollBar2
            // 
            this.vScrollBar2.Location = new System.Drawing.Point(347, 119);
            this.vScrollBar2.Minimum = -100;
            this.vScrollBar2.Name = "vScrollBar2";
            this.vScrollBar2.Size = new System.Drawing.Size(17, 200);
            this.vScrollBar2.TabIndex = 52;
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(27, 119);
            this.vScrollBar1.Minimum = -100;
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(17, 200);
            this.vScrollBar1.TabIndex = 51;
            // 
            // l_left_hinten
            // 
            this.l_left_hinten.AutoSize = true;
            this.l_left_hinten.Location = new System.Drawing.Point(44, 255);
            this.l_left_hinten.Name = "l_left_hinten";
            this.l_left_hinten.Size = new System.Drawing.Size(41, 13);
            this.l_left_hinten.TabIndex = 26;
            this.l_left_hinten.Text = "label18";
            // 
            // tb_left_hinten
            // 
            this.tb_left_hinten.Location = new System.Drawing.Point(47, 274);
            this.tb_left_hinten.Maximum = 50;
            this.tb_left_hinten.Name = "tb_left_hinten";
            this.tb_left_hinten.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tb_left_hinten.Size = new System.Drawing.Size(90, 45);
            this.tb_left_hinten.TabIndex = 25;
            this.tb_left_hinten.TickStyle = System.Windows.Forms.TickStyle.Both;
            // 
            // l_right_hinten
            // 
            this.l_right_hinten.AutoSize = true;
            this.l_right_hinten.Location = new System.Drawing.Point(303, 258);
            this.l_right_hinten.Name = "l_right_hinten";
            this.l_right_hinten.Size = new System.Drawing.Size(41, 13);
            this.l_right_hinten.TabIndex = 24;
            this.l_right_hinten.Text = "label17";
            // 
            // tb_right_hinten
            // 
            this.tb_right_hinten.Location = new System.Drawing.Point(254, 274);
            this.tb_right_hinten.Maximum = 50;
            this.tb_right_hinten.Name = "tb_right_hinten";
            this.tb_right_hinten.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tb_right_hinten.Size = new System.Drawing.Size(90, 45);
            this.tb_right_hinten.TabIndex = 23;
            this.tb_right_hinten.TickStyle = System.Windows.Forms.TickStyle.Both;
            // 
            // l_right_vorn
            // 
            this.l_right_vorn.AutoSize = true;
            this.l_right_vorn.Location = new System.Drawing.Point(303, 119);
            this.l_right_vorn.Name = "l_right_vorn";
            this.l_right_vorn.Size = new System.Drawing.Size(41, 13);
            this.l_right_vorn.TabIndex = 22;
            this.l_right_vorn.Text = "label16";
            // 
            // l_left_vorn
            // 
            this.l_left_vorn.AutoSize = true;
            this.l_left_vorn.Location = new System.Drawing.Point(44, 119);
            this.l_left_vorn.Name = "l_left_vorn";
            this.l_left_vorn.Size = new System.Drawing.Size(41, 13);
            this.l_left_vorn.TabIndex = 21;
            this.l_left_vorn.Text = "label15";
            // 
            // l_back
            // 
            this.l_back.AutoSize = true;
            this.l_back.Location = new System.Drawing.Point(224, 366);
            this.l_back.Name = "l_back";
            this.l_back.Size = new System.Drawing.Size(41, 13);
            this.l_back.TabIndex = 20;
            this.l_back.Text = "label14";
            // 
            // l_front
            // 
            this.l_front.AutoSize = true;
            this.l_front.Location = new System.Drawing.Point(224, 82);
            this.l_front.Name = "l_front";
            this.l_front.Size = new System.Drawing.Size(41, 13);
            this.l_front.TabIndex = 19;
            this.l_front.Text = "label13";
            // 
            // tb_left_vorn
            // 
            this.tb_left_vorn.Location = new System.Drawing.Point(47, 138);
            this.tb_left_vorn.Maximum = 50;
            this.tb_left_vorn.Name = "tb_left_vorn";
            this.tb_left_vorn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tb_left_vorn.Size = new System.Drawing.Size(90, 45);
            this.tb_left_vorn.TabIndex = 18;
            this.tb_left_vorn.TickStyle = System.Windows.Forms.TickStyle.Both;
            // 
            // tb_right_vorn
            // 
            this.tb_right_vorn.Location = new System.Drawing.Point(254, 135);
            this.tb_right_vorn.Maximum = 50;
            this.tb_right_vorn.Name = "tb_right_vorn";
            this.tb_right_vorn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tb_right_vorn.Size = new System.Drawing.Size(90, 45);
            this.tb_right_vorn.TabIndex = 17;
            this.tb_right_vorn.TickStyle = System.Windows.Forms.TickStyle.Both;
            // 
            // tb_back
            // 
            this.tb_back.Location = new System.Drawing.Point(173, 325);
            this.tb_back.Maximum = 0;
            this.tb_back.Minimum = -50;
            this.tb_back.Name = "tb_back";
            this.tb_back.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tb_back.Size = new System.Drawing.Size(45, 90);
            this.tb_back.TabIndex = 16;
            this.tb_back.TickStyle = System.Windows.Forms.TickStyle.Both;
            // 
            // tb_front
            // 
            this.tb_front.Location = new System.Drawing.Point(173, 42);
            this.tb_front.Maximum = 50;
            this.tb_front.Name = "tb_front";
            this.tb_front.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tb_front.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tb_front.Size = new System.Drawing.Size(45, 90);
            this.tb_front.TabIndex = 15;
            this.tb_front.TickStyle = System.Windows.Forms.TickStyle.Both;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Location = new System.Drawing.Point(143, 138);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(105, 181);
            this.panel1.TabIndex = 2;
            // 
            // splitContainer4
            // 
            this.splitContainer4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.listBox1);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer4.Panel2.Controls.Add(this.panel2);
            this.splitContainer4.Size = new System.Drawing.Size(381, 784);
            this.splitContainer4.SplitterDistance = 182;
            this.splitContainer4.SplitterIncrement = 3;
            this.splitContainer4.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1617, 808);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.menuStrip3);
            this.MainMenuStrip = this.menuStrip3;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).EndInit();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.menuStrip3.ResumeLayout(false);
            this.menuStrip3.PerformLayout();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_left_hinten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_right_hinten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_left_vorn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_right_vorn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_back)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_front)).EndInit();
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_disconnect;
        private System.Windows.Forms.Timer timer1;
        private GMap.NET.WindowsForms.GMapControl mapexplr;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.Button btn_manuel;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fghjklToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dfghjklToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem googleMapsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem googleMapsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pouteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ladenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem speichernToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addToRouteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem driveToToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ToolStripMenuItem goHomeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem carToolStripMenuItem;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ToolStripMenuItem folgeRouteToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox12;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label l_status;
        private System.Windows.Forms.RadioButton rb_autopilot;
        private System.Windows.Forms.RadioButton rb_idle;
        private System.Windows.Forms.RadioButton rb_directcontrol;
        private System.Windows.Forms.RadioButton rb_lokalcontrol;
        private System.Windows.Forms.MenuStrip menuStrip3;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem einstellungenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem einstellungenToolStripMenuItem1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label l_GamePadStatus;
        private WebKit.WebKitBrowser webKitBrowser1;
        private System.Windows.Forms.ToolStripMenuItem extrasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem akustischeWarnungenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aktuelleStellungAlsStandartSetzenToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label l_temp;
        private System.Windows.Forms.Label l_temperatur;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.HScrollBar hsb_cam;
        private System.Windows.Forms.VScrollBar vScrollBar2;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.Label l_left_hinten;
        private System.Windows.Forms.TrackBar tb_left_hinten;
        private System.Windows.Forms.Label l_right_hinten;
        private System.Windows.Forms.TrackBar tb_right_hinten;
        private System.Windows.Forms.Label l_right_vorn;
        private System.Windows.Forms.Label l_left_vorn;
        private System.Windows.Forms.Label l_back;
        private System.Windows.Forms.Label l_front;
        private System.Windows.Forms.TrackBar tb_left_vorn;
        private System.Windows.Forms.TrackBar tb_right_vorn;
        private System.Windows.Forms.TrackBar tb_back;
        private System.Windows.Forms.TrackBar tb_front;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer4;

    }
}

