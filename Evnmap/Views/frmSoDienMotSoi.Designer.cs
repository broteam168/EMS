namespace LDSong.Views
{
    partial class frmSoDienMotSoi
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btXoaPin = new DevExpress.XtraEditors.SimpleButton();
            this.mcSoDo1Soi = new DevExpress.XtraMap.MapControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.hideContainerRight = new DevExpress.XtraBars.Docking.AutoHideContainer();
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btSetDefault = new DevExpress.XtraEditors.SimpleButton();
            this.textSireFont = new System.Windows.Forms.TextBox();
            this.checkDefaultFont = new System.Windows.Forms.CheckBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.radioButton10 = new System.Windows.Forms.RadioButton();
            this.radioButton8 = new System.Windows.Forms.RadioButton();
            this.radioButton9 = new System.Windows.Forms.RadioButton();
            this.panel5 = new System.Windows.Forms.Panel();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.checkWindow = new System.Windows.Forms.CheckBox();
            this.btTaoKhung = new DevExpress.XtraEditors.SimpleButton();
            this.lbkhoangcach = new System.Windows.Forms.Label();
            this.lbkc = new System.Windows.Forms.Label();
            this.texttoado = new System.Windows.Forms.TextBox();
            this.checkBold = new System.Windows.Forms.CheckBox();
            this.checkOFFobject = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btRefesh = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radio22 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbDonvi = new DevExpress.XtraEditors.LookUpEdit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mcSoDo1Soi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.hideContainerRight.SuspendLayout();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbDonvi.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btXoaPin);
            this.panel1.Controls.Add(this.mcSoDo1Soi);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(625, 535);
            this.panel1.TabIndex = 0;
            // 
            // btXoaPin
            // 
            this.btXoaPin.Location = new System.Drawing.Point(5, 4);
            this.btXoaPin.Name = "btXoaPin";
            this.btXoaPin.Size = new System.Drawing.Size(75, 23);
            this.btXoaPin.TabIndex = 1;
            this.btXoaPin.Text = "Xóa điểm";
            this.btXoaPin.Visible = false;
            this.btXoaPin.Click += new System.EventHandler(this.btXoaPin_Click);
            // 
            // mcSoDo1Soi
            // 
            this.mcSoDo1Soi.Location = new System.Drawing.Point(0, 0);
            this.mcSoDo1Soi.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.mcSoDo1Soi.Name = "mcSoDo1Soi";
            this.mcSoDo1Soi.Size = new System.Drawing.Size(514, 279);
            this.mcSoDo1Soi.TabIndex = 0;
            this.mcSoDo1Soi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mcSoDo1Soi_KeyPress);
            // 
            // timer1
            // 
            this.timer1.Interval = 600;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // dockManager1
            // 
            this.dockManager1.AutoHideContainers.AddRange(new DevExpress.XtraBars.Docking.AutoHideContainer[] {
            this.hideContainerRight});
            this.dockManager1.Form = this;
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane"});
            // 
            // hideContainerRight
            // 
            this.hideContainerRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.hideContainerRight.Controls.Add(this.dockPanel1);
            this.hideContainerRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.hideContainerRight.Location = new System.Drawing.Point(625, 0);
            this.hideContainerRight.Name = "hideContainerRight";
            this.hideContainerRight.Size = new System.Drawing.Size(19, 535);
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanel1.ID = new System.Guid("2f73e925-a4d9-4fcf-a7c0-0b74e2feb537");
            this.dockPanel1.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.OriginalSize = new System.Drawing.Size(235, 200);
            this.dockPanel1.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanel1.SavedIndex = 0;
            this.dockPanel1.Size = new System.Drawing.Size(235, 535);
            this.dockPanel1.Text = "Tùy chọn";
            this.dockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.panel2);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(227, 508);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(227, 508);
            this.panel2.TabIndex = 0;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btSetDefault);
            this.panel7.Controls.Add(this.textSireFont);
            this.panel7.Controls.Add(this.checkDefaultFont);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 445);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(227, 63);
            this.panel7.TabIndex = 6;
            // 
            // btSetDefault
            // 
            this.btSetDefault.Enabled = false;
            this.btSetDefault.Location = new System.Drawing.Point(117, 37);
            this.btSetDefault.Name = "btSetDefault";
            this.btSetDefault.Size = new System.Drawing.Size(75, 23);
            this.btSetDefault.TabIndex = 9;
            this.btSetDefault.Text = "Gán font";
            this.btSetDefault.Click += new System.EventHandler(this.btSetDefault_Click);
            // 
            // textSireFont
            // 
            this.textSireFont.Enabled = false;
            this.textSireFont.Location = new System.Drawing.Point(20, 39);
            this.textSireFont.Name = "textSireFont";
            this.textSireFont.Size = new System.Drawing.Size(78, 21);
            this.textSireFont.TabIndex = 8;
            this.textSireFont.TextChanged += new System.EventHandler(this.textSireFont_TextChanged);
            // 
            // checkDefaultFont
            // 
            this.checkDefaultFont.AutoSize = true;
            this.checkDefaultFont.Location = new System.Drawing.Point(19, 12);
            this.checkDefaultFont.Name = "checkDefaultFont";
            this.checkDefaultFont.Size = new System.Drawing.Size(146, 17);
            this.checkDefaultFont.TabIndex = 0;
            this.checkDefaultFont.Text = "Bỏ độ rộng font mặc định";
            this.checkDefaultFont.UseVisualStyleBackColor = true;
            this.checkDefaultFont.CheckedChanged += new System.EventHandler(this.checkDefaultFont_CheckedChanged);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.radioButton10);
            this.panel6.Controls.Add(this.radioButton8);
            this.panel6.Controls.Add(this.radioButton9);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 403);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(227, 42);
            this.panel6.TabIndex = 5;
            // 
            // radioButton10
            // 
            this.radioButton10.AutoSize = true;
            this.radioButton10.Location = new System.Drawing.Point(167, 13);
            this.radioButton10.Name = "radioButton10";
            this.radioButton10.Size = new System.Drawing.Size(31, 17);
            this.radioButton10.TabIndex = 7;
            this.radioButton10.Text = "3";
            this.radioButton10.UseVisualStyleBackColor = true;
            this.radioButton10.CheckedChanged += new System.EventHandler(this.radioButton10_CheckedChanged);
            // 
            // radioButton8
            // 
            this.radioButton8.AutoSize = true;
            this.radioButton8.Checked = true;
            this.radioButton8.Location = new System.Drawing.Point(18, 13);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new System.Drawing.Size(31, 17);
            this.radioButton8.TabIndex = 5;
            this.radioButton8.TabStop = true;
            this.radioButton8.Text = "1";
            this.radioButton8.UseVisualStyleBackColor = true;
            this.radioButton8.CheckedChanged += new System.EventHandler(this.radioButton8_CheckedChanged);
            // 
            // radioButton9
            // 
            this.radioButton9.AutoSize = true;
            this.radioButton9.Location = new System.Drawing.Point(91, 13);
            this.radioButton9.Name = "radioButton9";
            this.radioButton9.Size = new System.Drawing.Size(31, 17);
            this.radioButton9.TabIndex = 6;
            this.radioButton9.Text = "2";
            this.radioButton9.UseVisualStyleBackColor = true;
            this.radioButton9.CheckedChanged += new System.EventHandler(this.radioButton9_CheckedChanged);
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.radioButton6);
            this.panel5.Controls.Add(this.radioButton7);
            this.panel5.Controls.Add(this.radioButton4);
            this.panel5.Controls.Add(this.radioButton5);
            this.panel5.Controls.Add(this.radioButton3);
            this.panel5.Controls.Add(this.radioButton2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 311);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(227, 92);
            this.panel5.TabIndex = 4;
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Location = new System.Drawing.Point(132, 61);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(41, 17);
            this.radioButton6.TabIndex = 5;
            this.radioButton6.TabStop = true;
            this.radioButton6.Text = "Tím";
            this.radioButton6.UseVisualStyleBackColor = true;
            this.radioButton6.CheckedChanged += new System.EventHandler(this.radioButton6_CheckedChanged);
            // 
            // radioButton7
            // 
            this.radioButton7.AutoSize = true;
            this.radioButton7.Location = new System.Drawing.Point(15, 61);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(39, 17);
            this.radioButton7.TabIndex = 4;
            this.radioButton7.TabStop = true;
            this.radioButton7.Text = "Đỏ";
            this.radioButton7.UseVisualStyleBackColor = true;
            this.radioButton7.CheckedChanged += new System.EventHandler(this.radioButton7_CheckedChanged);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(131, 36);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(76, 17);
            this.radioButton4.TabIndex = 3;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Vàng Xanh";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(14, 36);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(49, 17);
            this.radioButton5.TabIndex = 2;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "Vàng";
            this.radioButton5.UseVisualStyleBackColor = true;
            this.radioButton5.CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(131, 10);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(60, 17);
            this.radioButton3.TabIndex = 1;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Xanh lá";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(14, 10);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(83, 17);
            this.radioButton2.TabIndex = 0;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Xanh da trời";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.checkWindow);
            this.panel4.Controls.Add(this.btTaoKhung);
            this.panel4.Controls.Add(this.lbkhoangcach);
            this.panel4.Controls.Add(this.lbkc);
            this.panel4.Controls.Add(this.texttoado);
            this.panel4.Controls.Add(this.checkBold);
            this.panel4.Controls.Add(this.checkOFFobject);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 133);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(227, 178);
            this.panel4.TabIndex = 3;
            // 
            // checkWindow
            // 
            this.checkWindow.AutoSize = true;
            this.checkWindow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.checkWindow.Location = new System.Drawing.Point(13, 34);
            this.checkWindow.Name = "checkWindow";
            this.checkWindow.Size = new System.Drawing.Size(123, 17);
            this.checkWindow.TabIndex = 9;
            this.checkWindow.Text = "Không bật cửa sổ";
            this.checkWindow.UseVisualStyleBackColor = true;
            // 
            // btTaoKhung
            // 
            this.btTaoKhung.Location = new System.Drawing.Point(74, 142);
            this.btTaoKhung.Name = "btTaoKhung";
            this.btTaoKhung.Size = new System.Drawing.Size(75, 23);
            this.btTaoKhung.TabIndex = 8;
            this.btTaoKhung.Text = "Tạo khung";
            this.btTaoKhung.Click += new System.EventHandler(this.btTaoKhung_Click);
            // 
            // lbkhoangcach
            // 
            this.lbkhoangcach.AutoSize = true;
            this.lbkhoangcach.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lbkhoangcach.Location = new System.Drawing.Point(97, 120);
            this.lbkhoangcach.Name = "lbkhoangcach";
            this.lbkhoangcach.Size = new System.Drawing.Size(84, 13);
            this.lbkhoangcach.TabIndex = 4;
            this.lbkhoangcach.Text = "Khoảng cách :";
            // 
            // lbkc
            // 
            this.lbkc.AutoSize = true;
            this.lbkc.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lbkc.Location = new System.Drawing.Point(13, 119);
            this.lbkc.Name = "lbkc";
            this.lbkc.Size = new System.Drawing.Size(84, 13);
            this.lbkc.TabIndex = 3;
            this.lbkc.Text = "Khoảng cách :";
            // 
            // texttoado
            // 
            this.texttoado.Location = new System.Drawing.Point(12, 84);
            this.texttoado.Name = "texttoado";
            this.texttoado.Size = new System.Drawing.Size(210, 21);
            this.texttoado.TabIndex = 2;
            // 
            // checkBold
            // 
            this.checkBold.AutoSize = true;
            this.checkBold.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.checkBold.Location = new System.Drawing.Point(13, 56);
            this.checkBold.Name = "checkBold";
            this.checkBold.Size = new System.Drawing.Size(105, 17);
            this.checkBold.TabIndex = 1;
            this.checkBold.Text = "Bỏ chữ in đậm";
            this.checkBold.UseVisualStyleBackColor = true;
            this.checkBold.CheckedChanged += new System.EventHandler(this.checkBold_CheckedChanged);
            // 
            // checkOFFobject
            // 
            this.checkOFFobject.AutoSize = true;
            this.checkOFFobject.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.checkOFFobject.Location = new System.Drawing.Point(13, 12);
            this.checkOFFobject.Name = "checkOFFobject";
            this.checkOFFobject.Size = new System.Drawing.Size(213, 17);
            this.checkOFFobject.TabIndex = 0;
            this.checkOFFobject.Text = "Không tương tác với phần tử điện";
            this.checkOFFobject.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btRefesh);
            this.panel3.Controls.Add(this.simpleButton1);
            this.panel3.Controls.Add(this.radioButton1);
            this.panel3.Controls.Add(this.radio22);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.cbDonvi);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(227, 133);
            this.panel3.TabIndex = 2;
            // 
            // btRefesh
            // 
            this.btRefesh.Location = new System.Drawing.Point(129, 94);
            this.btRefesh.Name = "btRefesh";
            this.btRefesh.Size = new System.Drawing.Size(78, 23);
            this.btRefesh.TabIndex = 4;
            this.btRefesh.Text = "Làm mới";
            this.btRefesh.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(27, 94);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(80, 23);
            this.simpleButton1.TabIndex = 5;
            this.simpleButton1.Text = "Xem";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(135, 60);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(52, 17);
            this.radioButton1.TabIndex = 4;
            this.radioButton1.Text = "35 KV";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radio22
            // 
            this.radio22.AutoSize = true;
            this.radio22.Checked = true;
            this.radio22.Location = new System.Drawing.Point(74, 60);
            this.radio22.Name = "radio22";
            this.radio22.Size = new System.Drawing.Size(52, 17);
            this.radio22.TabIndex = 3;
            this.radio22.TabStop = true;
            this.radio22.Text = "22 KV";
            this.radio22.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(11, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Điện áp :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(9, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Đơn vị :";
            // 
            // cbDonvi
            // 
            this.cbDonvi.Location = new System.Drawing.Point(69, 18);
            this.cbDonvi.Name = "cbDonvi";
            this.cbDonvi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbDonvi.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TEN_DVIQLY", "Tên đơn vị quản lý")});
            this.cbDonvi.Properties.DisplayMember = "TEN_DVIQLY";
            this.cbDonvi.Properties.ValueMember = "MA_DVIQLY";
            this.cbDonvi.Size = new System.Drawing.Size(138, 20);
            this.cbDonvi.TabIndex = 0;
            // 
            // frmSoDienMotSoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 535);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.hideContainerRight);
            this.Name = "frmSoDienMotSoi";
            this.Text = "Sơ đồ 1 sợi";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mcSoDo1Soi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.hideContainerRight.ResumeLayout(false);
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbDonvi.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraMap.MapControl mcSoDo1Soi;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraEditors.SimpleButton btXoaPin;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox checkOFFobject;
        private DevExpress.XtraBars.Docking.AutoHideContainer hideContainerRight;
        private System.Windows.Forms.CheckBox checkBold;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private DevExpress.XtraEditors.LookUpEdit cbDonvi;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radio22;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton btRefesh;
        private System.Windows.Forms.TextBox texttoado;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.RadioButton radioButton7;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Label lbkhoangcach;
        private System.Windows.Forms.Label lbkc;
        private System.Windows.Forms.RadioButton radioButton9;
        private System.Windows.Forms.RadioButton radioButton8;
        private System.Windows.Forms.RadioButton radioButton10;
        private System.Windows.Forms.Panel panel6;
        private DevExpress.XtraEditors.SimpleButton btTaoKhung;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.CheckBox checkDefaultFont;
        private DevExpress.XtraEditors.SimpleButton btSetDefault;
        private System.Windows.Forms.TextBox textSireFont;
        private System.Windows.Forms.CheckBox checkWindow;
    }
}