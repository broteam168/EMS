namespace LDSong.Views
{
    partial class frmCreatePTDSoDo1Soi
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
            this.textToado = new System.Windows.Forms.TextBox();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.radioNgang = new System.Windows.Forms.RadioButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.radioDoc = new System.Windows.Forms.RadioButton();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.txtIDPTDien = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gridPTDien = new DevExpress.XtraGrid.GridControl();
            this.PTDien = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ID_PTDIEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TEN_PTDIEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MA_DVQLY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TEN_CAPDA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btCreate = new System.Windows.Forms.Button();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPTDien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PTDien)).BeginInit();
            this.SuspendLayout();
            // 
            // textToado
            // 
            this.textToado.Enabled = false;
            this.textToado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textToado.Location = new System.Drawing.Point(143, 9);
            this.textToado.Name = "textToado";
            this.textToado.Size = new System.Drawing.Size(338, 21);
            this.textToado.TabIndex = 31;
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl8.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelControl8.Location = new System.Drawing.Point(24, 10);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(41, 17);
            this.labelControl8.TabIndex = 30;
            this.labelControl8.Text = "Vị trí :";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelControl1.Location = new System.Drawing.Point(26, 96);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(97, 17);
            this.labelControl1.TabIndex = 32;
            this.labelControl1.Text = "Phần tử điện :";
            // 
            // radioNgang
            // 
            this.radioNgang.AutoSize = true;
            this.radioNgang.Location = new System.Drawing.Point(145, 51);
            this.radioNgang.Name = "radioNgang";
            this.radioNgang.Size = new System.Drawing.Size(57, 17);
            this.radioNgang.TabIndex = 33;
            this.radioNgang.TabStop = true;
            this.radioNgang.Text = "Ngang";
            this.radioNgang.UseVisualStyleBackColor = true;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelControl2.Location = new System.Drawing.Point(26, 51);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(39, 17);
            this.labelControl2.TabIndex = 34;
            this.labelControl2.Text = "Kiểu :";
            // 
            // radioDoc
            // 
            this.radioDoc.AutoSize = true;
            this.radioDoc.Location = new System.Drawing.Point(233, 51);
            this.radioDoc.Name = "radioDoc";
            this.radioDoc.Size = new System.Drawing.Size(45, 17);
            this.radioDoc.TabIndex = 35;
            this.radioDoc.TabStop = true;
            this.radioDoc.Text = "Dọc";
            this.radioDoc.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(491, 13);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(26, 13);
            this.linkLabel1.TabIndex = 36;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Sửa";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // txtIDPTDien
            // 
            this.txtIDPTDien.Enabled = false;
            this.txtIDPTDien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDPTDien.Location = new System.Drawing.Point(145, 94);
            this.txtIDPTDien.Name = "txtIDPTDien";
            this.txtIDPTDien.Size = new System.Drawing.Size(85, 21);
            this.txtIDPTDien.TabIndex = 37;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.linkLabel3);
            this.panel1.Controls.Add(this.linkLabel2);
            this.panel1.Controls.Add(this.txtTen);
            this.panel1.Controls.Add(this.txtIDPTDien);
            this.panel1.Controls.Add(this.labelControl8);
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Controls.Add(this.textToado);
            this.panel1.Controls.Add(this.radioDoc);
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Controls.Add(this.labelControl2);
            this.panel1.Controls.Add(this.radioNgang);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(659, 126);
            this.panel1.TabIndex = 38;
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(494, 98);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(87, 13);
            this.linkLabel2.TabIndex = 39;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Lấy phần tử điện";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // txtTen
            // 
            this.txtTen.Enabled = false;
            this.txtTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTen.Location = new System.Drawing.Point(229, 94);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(252, 21);
            this.txtTen.TabIndex = 38;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gridPTDien);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 126);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(659, 161);
            this.panel2.TabIndex = 39;
            // 
            // gridPTDien
            // 
            this.gridPTDien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPTDien.Location = new System.Drawing.Point(0, 0);
            this.gridPTDien.MainView = this.PTDien;
            this.gridPTDien.Name = "gridPTDien";
            this.gridPTDien.Size = new System.Drawing.Size(659, 161);
            this.gridPTDien.TabIndex = 0;
            this.gridPTDien.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.PTDien});
            // 
            // PTDien
            // 
            this.PTDien.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ID_PTDIEN,
            this.TEN_PTDIEN,
            this.MA_DVQLY,
            this.TEN_CAPDA});
            this.PTDien.GridControl = this.gridPTDien;
            this.PTDien.Name = "PTDien";
            this.PTDien.OptionsBehavior.Editable = false;
            this.PTDien.OptionsDetail.EnableMasterViewMode = false;
            this.PTDien.OptionsDetail.ShowDetailTabs = false;
            this.PTDien.OptionsFind.AlwaysVisible = true;
            this.PTDien.OptionsFind.FindFilterColumns = "TEN_PTDIEN";
            this.PTDien.OptionsFind.FindNullPrompt = "Nhập tên phần tử cần tìm";
            this.PTDien.OptionsView.ShowGroupPanel = false;
            this.PTDien.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.PTDien_FocusedRowChanged);
            // 
            // ID_PTDIEN
            // 
            this.ID_PTDIEN.Caption = "ID PTDIEN";
            this.ID_PTDIEN.FieldName = "ID_PTDIEN";
            this.ID_PTDIEN.Name = "ID_PTDIEN";
            this.ID_PTDIEN.Visible = true;
            this.ID_PTDIEN.VisibleIndex = 0;
            this.ID_PTDIEN.Width = 60;
            // 
            // TEN_PTDIEN
            // 
            this.TEN_PTDIEN.Caption = "Tên phần tử điện";
            this.TEN_PTDIEN.FieldName = "TEN_PTDIEN";
            this.TEN_PTDIEN.Name = "TEN_PTDIEN";
            this.TEN_PTDIEN.Visible = true;
            this.TEN_PTDIEN.VisibleIndex = 2;
            this.TEN_PTDIEN.Width = 469;
            // 
            // MA_DVQLY
            // 
            this.MA_DVQLY.Caption = "Mã Đơn vị quản lý";
            this.MA_DVQLY.FieldName = "MA_DVQLY";
            this.MA_DVQLY.MinWidth = 40;
            this.MA_DVQLY.Name = "MA_DVQLY";
            this.MA_DVQLY.Visible = true;
            this.MA_DVQLY.VisibleIndex = 1;
            this.MA_DVQLY.Width = 40;
            // 
            // TEN_CAPDA
            // 
            this.TEN_CAPDA.Caption = "Cấp điện áp";
            this.TEN_CAPDA.FieldName = "D_CAP_DAP.TEN_CAPDA";
            this.TEN_CAPDA.Name = "TEN_CAPDA";
            this.TEN_CAPDA.Visible = true;
            this.TEN_CAPDA.VisibleIndex = 3;
            this.TEN_CAPDA.Width = 60;
            // 
            // btCreate
            // 
            this.btCreate.Location = new System.Drawing.Point(229, 295);
            this.btCreate.Name = "btCreate";
            this.btCreate.Size = new System.Drawing.Size(106, 23);
            this.btCreate.TabIndex = 40;
            this.btCreate.Text = "Tạo phần tử";
            this.btCreate.UseVisualStyleBackColor = true;
            this.btCreate.Click += new System.EventHandler(this.btCreate_Click);
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Location = new System.Drawing.Point(589, 98);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(64, 13);
            this.linkLabel3.TabIndex = 40;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "Tạo ghi chú";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // frmCreatePTDSoDo1Soi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 335);
            this.Controls.Add(this.btCreate);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmCreatePTDSoDo1Soi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thêm phần tử điện";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPTDien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PTDien)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textToado;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.RadioButton radioNgang;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.RadioButton radioDoc;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TextBox txtIDPTDien;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraGrid.GridControl gridPTDien;
        private DevExpress.XtraGrid.Views.Grid.GridView PTDien;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.Button btCreate;
        private DevExpress.XtraGrid.Columns.GridColumn ID_PTDIEN;
        private DevExpress.XtraGrid.Columns.GridColumn TEN_PTDIEN;
        private DevExpress.XtraGrid.Columns.GridColumn MA_DVQLY;
        private DevExpress.XtraGrid.Columns.GridColumn TEN_CAPDA;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel3;
    }
}