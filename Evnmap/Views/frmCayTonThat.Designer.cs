namespace LDSong.Views
{
    partial class frmCayTonThat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCayTonThat));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.cbDvql = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdAddchild = new DevExpress.XtraEditors.SimpleButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.treeListQHPTDIEN = new DevExpress.XtraTreeList.TreeList();
            this.TEN_PTDIEN = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ID_PTDIEN = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.MA_CAPDA = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.MA_DVIQLY = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.LOAI_PTDIEN = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ID_QHE = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbDvql.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListQHPTDIEN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.cbDvql);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(this.cmdAddchild);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(951, 37);
            this.panelControl1.TabIndex = 5;
            // 
            // cbDvql
            // 
            this.cbDvql.Location = new System.Drawing.Point(83, 8);
            this.cbDvql.Name = "cbDvql";
            this.cbDvql.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.cbDvql.Properties.Appearance.Options.UseFont = true;
            this.cbDvql.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbDvql.Size = new System.Drawing.Size(193, 22);
            this.cbDvql.TabIndex = 8;
            this.cbDvql.SelectedIndexChanged += new System.EventHandler(this.cbDvql_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(21, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Đơn vị  :";
            // 
            // cmdAddchild
            // 
            this.cmdAddchild.Enabled = false;
            this.cmdAddchild.Location = new System.Drawing.Point(298, 7);
            this.cmdAddchild.Name = "cmdAddchild";
            this.cmdAddchild.Size = new System.Drawing.Size(127, 23);
            this.cmdAddchild.TabIndex = 1;
            this.cmdAddchild.Text = "Cập nhật cây tổn thất";
            this.cmdAddchild.Click += new System.EventHandler(this.cmdAddchild_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.treeListQHPTDIEN);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(448, 395);
            this.panel1.TabIndex = 6;
            // 
            // treeListQHPTDIEN
            // 
            this.treeListQHPTDIEN.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.treeListQHPTDIEN.Appearance.Row.Options.UseFont = true;
            this.treeListQHPTDIEN.AppearancePrint.BandPanel.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.treeListQHPTDIEN.AppearancePrint.BandPanel.Options.UseFont = true;
            this.treeListQHPTDIEN.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.TEN_PTDIEN,
            this.ID_PTDIEN,
            this.MA_CAPDA,
            this.MA_DVIQLY,
            this.LOAI_PTDIEN,
            this.ID_QHE});
            this.treeListQHPTDIEN.CustomizationFormBounds = new System.Drawing.Rectangle(954, 424, 216, 209);
            this.treeListQHPTDIEN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListQHPTDIEN.Location = new System.Drawing.Point(0, 0);
            this.treeListQHPTDIEN.Name = "treeListQHPTDIEN";
            this.treeListQHPTDIEN.OptionsBehavior.EnableFiltering = true;
            this.treeListQHPTDIEN.OptionsBehavior.PopulateServiceColumns = true;
            this.treeListQHPTDIEN.OptionsFilter.FilterMode = DevExpress.XtraTreeList.FilterMode.Extended;
            this.treeListQHPTDIEN.OptionsView.ShowAutoFilterRow = true;
            this.treeListQHPTDIEN.Size = new System.Drawing.Size(448, 395);
            this.treeListQHPTDIEN.TabIndex = 1;
            // 
            // TEN_PTDIEN
            // 
            this.TEN_PTDIEN.Caption = "Cây lưới điện";
            this.TEN_PTDIEN.FieldName = "TEN_PTDIEN";
            this.TEN_PTDIEN.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.TEN_PTDIEN.Name = "TEN_PTDIEN";
            this.TEN_PTDIEN.OptionsFilter.AutoFilterCondition = DevExpress.XtraTreeList.Columns.AutoFilterCondition.Contains;
            this.TEN_PTDIEN.OptionsFilter.FilterPopupMode = DevExpress.XtraTreeList.FilterPopupMode.List;
            this.TEN_PTDIEN.OptionsFilter.ImmediateUpdatePopupDateFilter = DevExpress.Utils.DefaultBoolean.True;
            this.TEN_PTDIEN.SortOrder = System.Windows.Forms.SortOrder.Descending;
            this.TEN_PTDIEN.Visible = true;
            this.TEN_PTDIEN.VisibleIndex = 0;
            // 
            // ID_PTDIEN
            // 
            this.ID_PTDIEN.Caption = "treeListColumn1";
            this.ID_PTDIEN.FieldName = "ID_PTDIEN";
            this.ID_PTDIEN.Name = "ID_PTDIEN";
            // 
            // MA_CAPDA
            // 
            this.MA_CAPDA.Caption = "treeListColumn4";
            this.MA_CAPDA.FieldName = "MA_CAPDA";
            this.MA_CAPDA.Name = "MA_CAPDA";
            // 
            // MA_DVIQLY
            // 
            this.MA_DVIQLY.Caption = "treeListColumn4";
            this.MA_DVIQLY.FieldName = "MA_DVIQLY";
            this.MA_DVIQLY.Name = "MA_DVIQLY";
            // 
            // LOAI_PTDIEN
            // 
            this.LOAI_PTDIEN.Caption = "treeListColumn4";
            this.LOAI_PTDIEN.FieldName = "LOAI_PTDIEN";
            this.LOAI_PTDIEN.Name = "LOAI_PTDIEN";
            // 
            // ID_QHE
            // 
            this.ID_QHE.Caption = "treeListColumn4";
            this.ID_QHE.FieldName = "ID_QHE";
            this.ID_QHE.Name = "ID_QHE";
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(448, 37);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(503, 395);
            this.panel2.TabIndex = 7;
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "root.png");
            this.imageCollection1.Images.SetKeyName(1, "mc-cc.png");
            this.imageCollection1.Images.SetKeyName(2, "tram.png");
            this.imageCollection1.Images.SetKeyName(3, "lo.png");
            this.imageCollection1.Images.SetKeyName(4, "locon.png");
            this.imageCollection1.Images.SetKeyName(5, "pha.png");
            // 
            // frmCayTonThat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 432);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelControl1);
            this.Name = "frmCayTonThat";
            this.Text = "Cây tổn thất";
            this.Load += new System.EventHandler(this.frmCayTonThat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbDvql.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListQHPTDIEN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cbDvql;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton cmdAddchild;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraTreeList.TreeList treeListQHPTDIEN;
        private DevExpress.XtraTreeList.Columns.TreeListColumn TEN_PTDIEN;
        private DevExpress.XtraTreeList.Columns.TreeListColumn ID_PTDIEN;
        private DevExpress.XtraTreeList.Columns.TreeListColumn MA_CAPDA;
        private DevExpress.XtraTreeList.Columns.TreeListColumn MA_DVIQLY;
        private DevExpress.XtraTreeList.Columns.TreeListColumn LOAI_PTDIEN;
        private DevExpress.XtraTreeList.Columns.TreeListColumn ID_QHE;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.Utils.ImageCollection imageCollection1;
    }
}