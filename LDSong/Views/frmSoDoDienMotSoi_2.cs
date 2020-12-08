using DevExpress.Map.BingServices;
using DevExpress.XtraEditors;
using DevExpress.XtraMap;
using LDSong.Controlers;
using LDSong.Libs;
using LDSong.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LDSong.Views
{
    public partial class frmSoDoDienMotSoi_2 : DevExpress.XtraEditors.XtraForm
    {
        private static int _MenuId = 42;
        DevExpress.XtraMap.ImageTilesLayer imageTilesLayer1;
        private string userName, DVQuanLy,cap="05",loai, toadoLine = "", toadoLineDZ = "", loaiTB;
        private SoDo1SoiControler obj;
        private int idPTD,fontZ=6, TL = 2,dem=0,t;
        private MapItemStorage paintMap;
        MapItemStorage searchDay0TGH, searchDay0TGV, searchDay1TGV, searchDay1TGH, itemstorePolie, ItemStorageLine, itemstorePolieDZ, searchDayWarning, searchDay22, searchDay22A, searchDay35, searchDay35A, mn1MC, mn0MC;
        private SqlConnection connection = null;
        private SqlCommand command = null;
        private DataSet myDataSet = null;
        private MapPolyline Pline11, Pline12, Pline21, Pline22;
        private bool ve = false, stMove = false, qhe = false;
        Bitmap bmp, bmp1;
        Graphics g;
        private List<int> idAlign;
        private MapPolyline Pline;
        private MapLine PlineYellow;
        private double xmv, ymv;
        MapPushpin Pin = new MapPushpin();
        MiniMap mn;
        private bool moi, dc, xoa, cte, cta, kct, kcp, kht, khd;
        public frmSoDoDienMotSoi_2(string userName, string dvql,string loai)
        {
            paintMap = new MapItemStorage();
            ItemStorageLine = new MapItemStorage();
            itemstorePolie = new MapItemStorage();
            itemstorePolieDZ = new MapItemStorage();
            obj = new SoDo1SoiControler();
            this.loai = loai;
            InitializeComponent();
            LDSFunction Fn = new LDSFunction();
            List<string> menus = Fn.getMenuByUser("cmd", _MenuId);

            foreach (string item in menus)
            {
                SimpleButton ctl = this.Controls.Find(item, true).FirstOrDefault() as SimpleButton;
                ctl.Enabled = true;
            }
            moi = cmdThemMoi.Enabled;
            dc = cmdDiChuyen.Enabled;
            xoa = cmdXoa.Enabled;
            cte = cmdbtAlignTop.Enabled;
            cta = cmdbtAlignLeft.Enabled;
            kct = cmdbtSameWidthLR.Enabled;
            kcp = cmdbtSameWidthRL.Enabled;
            kht = cmdbtSameHeightLR.Enabled;
            khd = cmdbtSameHeightRL.Enabled;
            initSoDoMotSoi();
            mcSoDo1Soi. MouseDoubleClick += MapControl_MouseDoubleClick;
            mcSoDo1Soi.MapItemClick += mapControl1_MapItemClick;
            //b.MouseDown += PictureBox1_MouseDown;
            DisposeVH();
            if (EnoughPermission()) autoData();
            this.userName = userName;
            this.DVQuanLy = dvql;
            
            initComboboxDonvi();
        }
        public void DisposeVH()
        {
            // Unregister the notification subscription for the current instance.
            SqlDependency.Stop(LDSong.Properties.Settings.Default.connect);
        }
        public void initComboboxDonvi()
        {
            List<D_DVI_QLY> lstT= obj.listDonvi(DVQuanLy);
            cbDonVi.Properties.DataSource = lstT;
            cbDonVi.Properties.NullText = "Đơn vị quản lý";
        }
        public void paintLineQH()
        {
            bool TTCha = false,tmp=true,nQH;
            List<string> toado;
            List<int> idPTDien = obj.getAllSD1(cbDonVi.EditValue.ToString(), cap);
            List<int> idqh = new List<int>();
            foreach (var item in idPTDien)
            {
                 if (obj.checkWarning(item))
                {
                    TTCha = true;
                }
                else
                {
                    TTCha = false;
                }
                if (obj.nhieuQH(item))
                {
                    nQH = true;
                }
                else
                {
                    nQH = false;
                }
                toado = obj.xulyDiem(obj.toaDoQuanHe(item));
                VectorItemsLayer itemsLayer = new VectorItemsLayer();
                mcSoDo1Soi.Layers.Add(itemsLayer);
                ItemStorageLine = new MapItemStorage();

                string[] xy = toado.ElementAt(0).Trim().Split(' ');
                double x = Convert.ToDouble(xy[0]);
                double y = Convert.ToDouble(xy[1]);

                for (int i = 1; i < toado.Count; i++)
                {
                    if (idqh.Find(f => f == obj.idQH[i]) == 0)
                    {
                        MapLine mline = new MapLine();
                        if (TTCha)
                        {
                            mline.Stroke = Color.Gray;
                            tmp = true;
                        }
                        else
                        {
                            if (obj.checkWarning(obj.idQH[i]))
                            {
                                mline.Stroke = Color.Gray;
                                tmp = true;
                            }
                            else
                            {
                                mline.Stroke = Color.Gold;
                                tmp = false;
                            }
                        }
                        
                        mline.ToolTipPattern = item.ToString();
                        mline.StrokeWidth = 1;
                        string[] xy1 = toado[i].Trim().Split(' ');
                        double x1 = Convert.ToDouble(xy1[0]);
                        double y1 = Convert.ToDouble(xy1[1]);
                        if (nQH)
                        {
                            mline.Point1 = new GeoPoint(x1, y);
                            mline.Point2 = new GeoPoint(x1, y1);
                        }
                        else
                        {
                            mline.Point1 = new GeoPoint(x, y1);
                            mline.Point2 = new GeoPoint(x1, y1);
                        }
                        ItemStorageLine.Items.Add(mline);
                        mline = new MapLine();
                        if (tmp)
                        {
                            mline.Stroke = Color.Gray;
                        }
                        else
                        {
                            mline.Stroke = Color.Gold;
                        }
                        if (nQH)
                        {
                            mline.Point1 = new GeoPoint(x1, y);
                            mline.Point2 = new GeoPoint(x, y);
                        }
                        else
                        {
                            mline.Point1 = new GeoPoint(x, y);
                            mline.Point2 = new GeoPoint(x, y1);
                        }

                        ItemStorageLine.Items.Add(mline);
                        idqh.Add(item);
                    }
                }
                itemsLayer.Data = ItemStorageLine;
                
                
            }
            
        }
        public void initPLine()
        {
            Pline11 = new MapPolyline();
            Pline12 = new MapPolyline();// de tam o day
            Pline21 = new MapPolyline();
            Pline22 = new MapPolyline();
        }
        private void mapControl1_MapItemClick(object sender, MapItemClickEventArgs e)
        {
            idPTD = 0;
            try
            {
                loaiTB = ((MapPolygon)e.Item).Attributes.First().Name.ToString(); 
            }
            catch (Exception)
            {

                try
                {
                    string tempDZ= ((MapLine)e.Item).Attributes.First().Name.ToString();
                    
                    loaiTB = "DZ";
                }
                catch (Exception)
                {
                    loaiTB = "";
                }
            }
            if (cmdThemMoi.Enabled)
            {
                try
                {
                    idPTD = int.Parse(((MapPolygon)e.Item).Attributes.First().Value.ToString());
                }
                catch (Exception)
                {

                    try
                    {
                        idPTD = int.Parse(((MapLine)e.Item).Attributes.First().Value.ToString());
                    }
                    catch (Exception)
                    {
                        idPTD = 0;
                    }
                }
            }
            if (cmdThemMoi.Enabled==false&&idPTD==0)
            {
                try
                {
                    ((MapPolyline)e.Item).Attributes.First().Name.ToString().Equals("CreateLine");
                    menuCreateDZ.Show(mcSoDo1Soi, mcSoDo1Soi.PointToClient(Cursor.Position));
                }
                catch (Exception)
                {
                }
            }
            if (cmdXoa.Enabled==false&&idPTD!=0)
            {
                if (!loaiTB.Equals("DZ"))
                {
                    string query = "DELETE FROM M_VITRI_SD1S WHERE ID_PTDIEN=" + idPTD;
                    obj.insertORupdateVitri(query);
                    RefreshDataLocal();
                }
                else
                {
                    toadoControler1 obj1 = new toadoControler1();
                    List<D_QHE_PTDIEN_VITRI> lstQH = obj1.listLRCon(idPTD);
                    if (lstQH.Count != 0)
                    {
                        obj1.deleteAllLR(lstQH);
                    }
                    xoaPTDDZ();
                }
            }
            else
            {
                if (cmdDiChuyen.Enabled == true && cmdThemMoi.Enabled == true && cmdXoa.Enabled == true && btok.Enabled==false)
                {
                    try
                    {
                        idPTD = int.Parse(((MapPolygon)e.Item).Attributes.First().Value.ToString());
                        lbTenNut.Text = ((MapPolygon)e.Item).ToolTipPattern;
                        if (loai.Equals("1"))
                        {
                            frmTrangthaiTram trangthai = new frmTrangthaiTram(idPTD.ToString(), userName);
                            trangthai.ShowDialog();
                        }
                        if (loai.Equals("0"))
                        {
                            if (qhe == false)
                            {
                                menuAdmin.Show(mcSoDo1Soi, mcSoDo1Soi.PointToClient(Cursor.Position));
                            }
                            else
                            {
                                if (!lbIDNut.Text.Equals(idPTD.ToString()))
                                {
                                    EnableMenuStrip(true, true);
                                    MenuStrip1.Show(mcSoDo1Soi, mcSoDo1Soi.PointToClient(Cursor.Position));
                                }
                                else
                                {
                                    EnableMenuStrip(false, false);
                                    MenuStrip1.Show(mcSoDo1Soi, mcSoDo1Soi.PointToClient(Cursor.Position));
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {
                        try
                        {
                            idPTD = int.Parse(((MapLine)e.Item).Attributes.First().Value.ToString());
                            if (qhe)
                            {
                                EnableMenuStrip(true, true);
                                MenuStrip1.Show(mcSoDo1Soi, mcSoDo1Soi.PointToClient(Cursor.Position));
                            }
                        }
                        catch (Exception)
                        {
                            
                        }
                    }
                }
            }
            if (btok.Enabled==true)
            {
                if (idPTD!=0)
                {
                    if (idAlign.Contains(idPTD)==false)
                    {
                        idAlign.Add(idPTD);
                    }
                    
                }
            }
        }
        public void xoaPTDDZ()
        {
            PTDiencontroler obj = new PTDiencontroler();
            if (obj.checkQH(idPTD))
            {
                obj.deleteTT(idPTD);
                obj.deleteTTVM(idPTD);
                obj.deleteTTLR(idPTD);
                obj.deleteTTLRVM(idPTD);
                obj.deleteQH(idPTD);
                string query = "delete from M_VITRI where ID_PTDIEN=" + idPTD;
                obj.deleteVT(query);
                string query1 = "delete from M_VITRI_SD1S where ID_PTDIEN=" + idPTD;
                obj.deleteVT(query);
                //t = true;
                obj.deleteNodeTree(idPTD);
                obj.delete(idPTD);
            }
            
        }
        public void EnableMenuStrip(bool en, bool df)
        {
            caapToolStripMenuItem.Enabled = en;
            cậpNhậtThôngTinToolStripMenuItem.Enabled = en;
        }
        private void MapControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            VectorItemsLayer VectorLayer = new VectorItemsLayer();
            mcSoDo1Soi.Layers.Add(VectorLayer);
            MapPoint MyPoint = new DevExpress.XtraMap.MapPoint(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y);
            GeoPoint GP1 = VectorLayer.ScreenPointToGeoPoint(MyPoint);
            if (cmdThemMoi.Enabled==false)
            {
                if (idPTD != 0)
                {
                    createPTDien(GP1.GetY().ToString() + " " + GP1.GetX().ToString());
                }
                else
                {
                    CreateDZ(e);
                }
            }
            else
            {
                if (cmdDiChuyen.Enabled==false&&idPTD!=0)
                {
                    string t= "POINT (" + GP1.GetY().ToString() + " " + GP1.GetX().ToString() + ")";
                    string query = "UPDATE M_VITRI_SD1S SET VITRI=geometry::STGeomFromText('" + t + "', 0) where ID_PTDIEN="+idPTD;
                    obj.insertORupdateVitri(query);
                    RefreshDataLocal();
                }
            }
        }
        public void CreateDZ(MouseEventArgs e,bool _lui=false)
        {
            int i = 0;
            toadoLine = "";
            GeoPoint Ga = null, Gb = null;
            double k1 = 0, k2 = 0; //khoangcach = 0;
            var image0 = new Bitmap(@"icon\point.png");
            VectorItemsLayer VectorLayer = new VectorItemsLayer();
            mcSoDo1Soi.Layers.Add(VectorLayer);
            if (itemstorePolieDZ.Items.Contains(Pline))
            {
                itemstorePolieDZ.Items.Remove(Pline);
            }
            Pline = new MapPolyline();
            Pline.StrokeWidth = 1;
            Pline.Stroke = Color.Yellow;
            MapPoint MyPoint = new DevExpress.XtraMap.MapPoint(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y);
            GeoPoint GP = VectorLayer.ScreenPointToGeoPoint(MyPoint);
            MapPushpin Pin = new MapPushpin();
            Pin.Image = new Bitmap(image0);
            Pin.Location = GP;
            Pin.ToolTipPattern = GP.GetY().ToString() + " " + GP.GetX().ToString();
            itemstorePolieDZ.Items.Add(Pin);
            VectorLayer.Data = itemstorePolieDZ;
            foreach (MapPushpin mp in itemstorePolieDZ.Items)
            {
                string[] td = mp.Location.ToString().Split(',');
                double x = double.Parse(td[0]);
                double y = double.Parse(td[1]);
                Pline.Points.Add(mp.Location);
                if (i == 0)
                {
                    Ga = new GeoPoint(x, y);
                    toadoLine = x + " " + y;
                }
                if (i == 1)
                {
                    Gb = new GeoPoint(x, y);
                    //k1 = GeoMath.GetEquirectangularDistance(Ga, Gb);
                    Ga = Gb;
                    toadoLine = toadoLine + "," + x + " " + y;
                }
                if (i != 0 && i != 1)
                {
                    Gb = new GeoPoint(x, y);
                    //k2 = GeoMath.GetEquirectangularDistance(Ga, Gb);
                    //khoangcach = khoangcach + k2;
                    Ga = Gb;
                    toadoLine = toadoLine + "," + x + " " + y;
                }
                i++;
            }
            Pline.Attributes.Add(new MapItemAttribute { Name = "CreateLine" });
            //khoangcach = k1 + khoangcach;
            itemstorePolieDZ.Items.Add(Pline);
            VectorLayer.Data = itemstorePolieDZ;
        }
        public void luilai()
        {
            int i = 0;
            toadoLine = "";
            GeoPoint Ga = null, Gb = null;
            VectorItemsLayer VectorLayer = new VectorItemsLayer();
            mcSoDo1Soi.Layers.Add(VectorLayer);
            Pline = new MapPolyline();
            Pline.StrokeWidth = 1;
            Pline.Stroke = Color.Yellow;
            //toadoLine = toadoLine.Remove(toadoLine.LastIndexOf(","));
            itemstorePolieDZ.Items.RemoveAt(itemstorePolieDZ.Items.Count - 1);
            itemstorePolieDZ.Items.RemoveAt(itemstorePolieDZ.Items.Count - 1);
            foreach (MapPushpin mp in itemstorePolieDZ.Items)
            {
                string[] td = mp.Location.ToString().Split(',');
                double x = double.Parse(td[0]);
                double y = double.Parse(td[1]);
                Pline.Points.Add(mp.Location);
                if (i == 0)
                {
                    Ga = new GeoPoint(x, y);
                    toadoLine = x + " " + y;
                }
                if (i == 1)
                {
                    Gb = new GeoPoint(x, y);
                    //k1 = GeoMath.GetEquirectangularDistance(Ga, Gb);
                    Ga = Gb;
                    toadoLine = toadoLine + "," + x + " " + y;
                }
                if (i != 0 && i != 1)
                {
                    Gb = new GeoPoint(x, y);
                    //k2 = GeoMath.GetEquirectangularDistance(Ga, Gb);
                    //khoangcach = khoangcach + k2;
                    Ga = Gb;
                    toadoLine = toadoLine + "," + x + " " + y;
                }
                i++;
            }
            Pline.Attributes.Add(new MapItemAttribute { Name = "CreateLine" });
            //khoangcach = k1 + khoangcach;
            itemstorePolieDZ.Items.Add(Pline);
            VectorLayer.Data = itemstorePolieDZ;
        }
        public void createPTDien(string toado)
        {
            string q = "select * from M_VITRI_SD1S where ID_PTDIEN=" + idPTD;
            if (obj.checkExist(q))
            {
                try
                {
                    string t = "POINT (" + toado + ")";
                    string query = "INSERT INTO M_VITRI_SD1S VALUES (" + idPTD + ",geometry::STGeomFromText('" + t + "', 0),'V');";
                    obj.insertORupdateVitri(query);
                    RefreshDataLocal();
                }
                catch (Exception)
                {
                    MessageBox.Show("Không thể thêm phần tử điện, bạn vui lòng kiểm tra lại");
                }
            }
            else
            {
                MessageBox.Show("Phần tử điện này đã có,bạn không thể thêm.");
            }
        }
        public void paint()
        {
            cbLoai.Properties.NullText = "Loại phần tử";
            cbLoai.Properties.DataSource = obj.listLoaiPT();
        }
        public void initSoDoMotSoi()
        {
            this.mcSoDo1Soi.Cursor = Cursors.WaitCursor;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSoDienMotSoi));
            imageTilesLayer1 = new DevExpress.XtraMap.ImageTilesLayer();
            this.mcSoDo1Soi.CenterPoint = new DevExpress.XtraMap.GeoPoint(20.250567D, 105.974863D);
            this.mcSoDo1Soi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mcSoDo1Soi.Layers.Add(imageTilesLayer1);
            this.mcSoDo1Soi.Location = new System.Drawing.Point(0, 0);
            this.mcSoDo1Soi.Name = "mcSoDo1Soi";
            this.mcSoDo1Soi.Size = new System.Drawing.Size(540, 457);
            this.mcSoDo1Soi.NavigationPanelOptions.Visible = false;
            this.mcSoDo1Soi.TabIndex = 1;
            this.mcSoDo1Soi.ZoomLevel = 17D;
            //this.mcSoDo1Soi.EnableScrolling = false; khoa keo ban do
            if (loai.Equals("0"))
            {
                this.mcSoDo1Soi.MaxZoomLevel = 19D;
                this.mcSoDo1Soi.MinZoomLevel = 15D;
            }
            else
            {
                this.mcSoDo1Soi.ZoomLevel = 17D;
                this.mcSoDo1Soi.MinZoomLevel = 16D;
            }
            this.mcSoDo1Soi.BackColor = Color.Black;
            LocalProvider provider = new LocalProvider();
            imageTilesLayer1.DataProvider = provider;
            mn = new MiniMap()
            {
                Alignment = MiniMapAlignment.BottomRight
            };
            mn.Layers.AddRange(new MiniMapLayerBase[] {
                new MiniMapImageTilesLayer() {
                    DataProvider = provider
                }
            });
            mcSoDo1Soi.MiniMap = mn;
            DynamicMiniMapBehavior dn = new DynamicMiniMapBehavior();
            dn.ZoomOffset =-3.9;
            mcSoDo1Soi.MiniMap.Behavior = dn;
            this.mcSoDo1Soi.Cursor = Cursors.Hand;
        }

        private void SimpleButton1_Click(object sender, EventArgs e)
        {
            if (cbDonVi.EditValue!=null)
            {
                try
                {
                    PTDien.DataSource = null;
                    PTDien.DataSource = obj.listPTDien(cbDonVi.EditValue.ToString(), cap, cbLoai.EditValue.ToString());
                }
                catch (Exception)
                {
                    MessageBox.Show("Không thực hiện được thao tác bạn vui lòng kiểm tra lại.");
                }
            }
        }



        private void GridPTDien_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                idPTD = 0;
                idPTD = int.Parse(gridPTDien.GetFocusedRowCellValue("ID_PTDIEN").ToString());
                PTDienCon.DataSource = null;
                PTDienCon.DataSource = obj.listLR(idPTD);
            }
            catch (Exception)
            {

            }
        }

        private void GridPTDienCon_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            idPTD = int.Parse(gridPTDienCon.GetFocusedRowCellValue("ID_PTDienCon").ToString());
        }

        private void SimpleButton2_Click(object sender, EventArgs e)
        {
            if (BTXong.Enabled==false)
            {
                idPTD = 0;
                initPLine();
                cmdThemMoi.Enabled = false;
                BTXong.Enabled = true;
                paint();
                dockPanel1.Enabled = true;
                ve = true;
                pictureEdit1.Visible = true;
                pictureEdit2.Visible = true;
            }
            else
            {
                MessageBox.Show("Đang có tác vụ chạy.Vui lòng kết thúc tác vụ.");
            }
        }
        private bool EnoughPermission()
        {

            SqlClientPermission perm = new SqlClientPermission(System.Security.Permissions.PermissionState.Unrestricted);
            try
            {
                perm.Demand();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
        public void autoData()
        {
            string ssql;
            command = null;
            string connstr = LDSong.Properties.Settings.Default.connect;
            /*if (DVQuanLy != "PN")
            {
                ssql = "select TRANG_THAI from dbo.M_TTHAI_PTDIEN where MA_DVQLY='" + DVQuanLy + "';";
            }
            else
            {*/
                ssql = "select TRANG_THAI from dbo.M_TTHAI_PTDIEN ;";
            //}
            SqlDependency.Stop(connstr);
            SqlDependency.Start(connstr);
            if (connection == null)
                connection = new SqlConnection(connstr);
            if (command == null)
            {
                command = new SqlCommand(ssql, connection);
            }
                
            if (myDataSet == null)
                myDataSet = new DataSet();
            GetAdvtData();
        }
        private void GetAdvtData()
        {
            myDataSet.Clear();
            command.Notification = null;
            SqlDependency dependency = new SqlDependency(command);
            dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);

            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                adapter.Fill(myDataSet, "Advt");
            }
        }
        delegate void UIDelegate();
        private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            try
            {
                UIDelegate uidel = new UIDelegate(RefreshData);
                this.Invoke(uidel, null);
                SqlDependency dependency = (SqlDependency)sender;
                dependency.OnChange -= dependency_OnChange;
            }
            catch (Exception)
            {
            }
        }
        public void RefreshData()
        {
            RefreshDataLocal();
            GetAdvtData();
        }
        public void RefreshDataLocal()
        {
            idPTD = 0;
            if (cbDonVi.EditValue != null)
            {
                huydoituongSearchday();
                //paintLineQH();
                DVQuanLy = cbDonVi.EditValue.ToString();
                paintAll(DVQuanLy, cap);
            }
            try
            {
                itemstorePolieDZ.Items.Clear();
            }
            catch (Exception)
            {
            }
        }
        public void huydoituongSearchday()
        {
            try
            {
                mn1MC.Dispose();

            }
            catch (Exception)
            {
            }
            try
            {
                mn0MC.Dispose();
            }
            catch (Exception)
            {
                
            }
            try
            {
                searchDay22A.Dispose();
            }
            catch (Exception)
            {
                try
                {
                    searchDay22A.Items.Clear();
                }
                catch (Exception)
                {
                    
                }
            }

            try
            {
                searchDay35A.Dispose();
            }
            catch (Exception)
            {
                try
                {

                }
                catch (Exception)
                {
                    searchDay35A.Items.Clear();
                }
            }
            mcSoDo1Soi.Layers.Clear();
            
            /*try
            {
                paintMap.Dispose();
            }
            catch (Exception)
            {
                //paintMap.Items.Clear();
            }

            try
            {
                ItemStorageLine.Dispose();
            }
            catch (Exception)
            {
                //ItemStorageLine.Items.Clear();
            }
            try
            {
                searchDay1TGH.Dispose();
            }
            catch (Exception)
            {

            }
            try
            {
                searchDay1TGV.Dispose();
            }
            catch (Exception)
            {

            }
            try
            {
                searchDay0TGH.Dispose();
            }
            catch (Exception)
            {

            }
            try
            {
                searchDay0TGV.Dispose();
            }
            catch (Exception)
            {

            }*/
        }
        public void paintAll(string dvql_cb, string maCapda)
        {
            this.Cursor = Cursors.WaitCursor;
            obj.getAllDZ(dvql_cb, maCapda);
            obj.getWarning(dvql_cb, maCapda);
            obj.getAllTB(dvql_cb, maCapda);

            if (obj.ListsearchDZLine22.Count != 0)
            {
                paintLine22();
                paintLine22A();
            }
            if (obj.ListsearchDZLine35.Count != 0)
            {
                paintLine35();
                paintLine35A();
            }
            if (obj.ListWarning.Count != 0)
            {
                paintLineWarning();
                paintLineWarningA();
            }
            if (obj.ListsearchDZPoint0CDV.Count != 0)
            {
                paintPoint0CDV();
            }
            if (obj.ListsearchDZPoint1CDV.Count != 0)
            {
                paintPoint1CDV();
            }
            
            if (obj.ListsearchDZPoint0MCV.Count != 0)
            {
                paintPoint0MCV();
                paintPoint0MCVA();
            }
            if (obj.ListsearchDZPoint1MCV.Count != 0)
            {
                paintPoint1MCV();
                paintPoint1MCVA();
            }
            if (obj.ListsearchDZPoint0TGH.Count != 0)
            {
                paintPoint0TGH();
            }
            if (obj.ListsearchDZPoint0TGV.Count != 0)
            {
                paintPoint0TGV();
            }
            if (obj.ListsearchDZPoint1TGV.Count != 0)
            {
                paintPoint1TGV();
            }
            if (obj.ListsearchDZPoint1TGH.Count != 0)
            {
                paintPoint1TGH();
            }
            
            if (obj.ListsearchDZPoint0SIV.Count != 0)
            {
                paintPoint0SIV();
            }
            
            if (obj.ListsearchDZPoint1SIV.Count != 0)
            {
                paintPoint1SIV();
            }
            if (obj.ListsearchDZPoint0MCDZV.Count != 0)
            {
                paintPoint0MCDZV();
            }
            
            if (obj.ListsearchDZPoint1MCDZV.Count != 0)
            {
                paintPoint1MCDZV();
            }
            if (obj.ListSearchDZPoint1TBAV.Count != 0)
            {
                paintPoint1TBAV();
            }
            if (obj.ListSearchDZPoint0TBAV.Count != 0)
            {
                paintPoint0TBAV();
            }
            this.Cursor = Cursors.Hand;
        }
        private void paintPolyMC(double x, double y, bool _v, bool _close, bool _MC, int id, string Ten_PTDien)
        {
            paintMap = new MapItemStorage();
            VectorItemsLayer imageLayer0 = new VectorItemsLayer();
            mcSoDo1Soi.Layers.Add(imageLayer0);
            double x1, x2, y1, y2;
            if (_MC)
            {
                if (_v)
                {
                    x1 = Math.Round(x, 5) - 0.0003600;
                    x2 = Math.Round(x, 5) - 0.0007200;
                    y1 = Math.Round(y, 5) + 0.0000950;
                    y2 = Math.Round(y, 5) - 0.0000950;//0.0001250//0.0000950
                }
                else
                {
                    x1 = Math.Round(x, 5) - 0.0001899;
                    x2 = Math.Round(x, 5) + 0.0001899;
                    y1 = Math.Round(y, 5) - 0.0002299;
                    y2 = Math.Round(y, 5) + 0.0002299;
                }
            }
            else
            {
                x1 = Math.Round(x, 7) - 0.0001250;
                x2 = Math.Round(x, 7) + 0.0001250;
                y1 = Math.Round(y, 7) - 0.0000850;
                y2 = Math.Round(y, 7) + 0.0000850;
            }
            var polygon = new MapPolygon() ;
            if (_MC)
            {
                polygon.Points.AddRange(new GeoPoint[] {
                new GeoPoint(x,y1),
                new GeoPoint(x1,y1),
                new GeoPoint(x1,y2),
                new GeoPoint(x,y2)
                });
                polygon.Attributes.Add(new MapItemAttribute { Name = "MC", Value = id });
                MapCustomElement customElement0 = new MapCustomElement();
                customElement0.Location = new GeoPoint(x, y);
                //customElement0.AllowHtmlText = true;
                customElement0.Text = CatChuoi(Ten_PTDien, 15);
                customElement0.Font = new Font("Tahoma", fontZ, FontStyle.Regular);
                customElement0.RenderOrigin = new MapPoint(0.5, 1);
                customElement0.Padding = new System.Windows.Forms.Padding(0);
                paintMap.Items.Add(customElement0);
            }
            else
            {
                polygon.Points.AddRange(new GeoPoint[] {
                new GeoPoint(x2,y),
                new GeoPoint(x,y1),
                new GeoPoint(x1,y),
                new GeoPoint(x,y2)
                });
                polygon.Attributes.Add(new MapItemAttribute { Name = "DS", Value = id });
                MapCustomElement customElement0 = new MapCustomElement();
                customElement0.Location = new GeoPoint(x, y);
                //customElement0.AllowHtmlText = true;
                customElement0.Text = CatChuoi(Ten_PTDien, 15);
                customElement0.Font = new Font("Tahoma", fontZ, FontStyle.Regular);
                customElement0.RenderOrigin = new MapPoint(-0.2, 0.8);
                customElement0.Padding = new System.Windows.Forms.Padding(0);
                paintMap.Items.Add(customElement0);
            }
            //polygon.ToolTipPattern = Ten_PTDien;
            //polygon.TitleOptions.TextColor = Color.Orange;
            //polygon.TitleOptions.TextGlowColor = Color.White;
            //polygon.TitleOptions.Visibility = VisibilityMode.Visible;
            //polygon.TitleOptions.Pattern = Ten_PTDien;
            if (_close)
            {
                polygon.Fill = Color.Red;
                polygon.HighlightedStroke = Color.Red;
            }
            else
            {
                polygon.Fill = Color.Green;
                polygon.HighlightedStroke = Color.Green;
            }
            polygon.ToolTipPattern = Ten_PTDien;
            paintMap.Items.Add(polygon);
            
            imageLayer0.Data = paintMap;
        }
        
        public string CatChuoi(string s, int length)
        {
            if (String.IsNullOrEmpty(s))
                throw new ArgumentNullException(s);
            var words = s.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (words[0].Length > length)
                throw new ArgumentException("Từ đầu tiên dài hơn chuỗi cần cắt");
            var sb = new StringBuilder();
            foreach (var word in words)
            {
                if ((sb + word).Length > length)
                //return string.Format("{0}...", sb.ToString().TrimEnd(' '));
                sb.Append("\n"+word );
                else
                    sb.Append(word + " ");
            }
            return string.Format("{0}", sb.ToString().TrimEnd(' '));
        }

        private void BTXoa_Click(object sender, EventArgs e)
        {
            
            if (BTXong.Enabled==false)
            {
                cmdXoa.Enabled = false;
                BTXong.Enabled = true;
            }
            else
            {
                MessageBox.Show("Đang có tác vụ chạy.Vui lòng kết thúc tác vụ.");
            }
        }

        private void BTDiChuyen_Click(object sender, EventArgs e)
        {
            
            if (BTXong.Enabled==false)
            {
                initPLine();
                cmdDiChuyen.Enabled = false;
                BTXong.Enabled = true;
                ve = true;
                pictureEdit1.Visible = true;
                pictureEdit2.Visible = true;
            }
            else
            {
                MessageBox.Show("Đang có tác vụ chạy.Vui lòng kết thúc tác vụ.");
            }
        }

        private void BTXong_Click(object sender, EventArgs e)
        {
            cmdThemMoi.Enabled = moi;
            cmdXoa.Enabled = xoa;
            cmdDiChuyen.Enabled = dc;
            dockPanel1.Enabled = false;
            BTXong.Enabled = false;
            ve = false;
            pictureEdit1.Visible = false;
            pictureEdit2.Visible = false;
            if (itemstorePolie.Items.Contains(Pline11))
            {
                itemstorePolie.Items.Remove(Pline11);
            }
            if (itemstorePolie.Items.Contains(Pline12))
            {
                itemstorePolie.Items.Remove(Pline12);
            }
            if (itemstorePolie.Items.Contains(Pline21))
            {
                itemstorePolie.Items.Remove(Pline21);
            }
            if (itemstorePolie.Items.Contains(Pline22))
            {
                itemstorePolie.Items.Remove(Pline22);
            }
            idPTD = 0;
        }

        private void paintPolyMCSI(double x, double y, bool _close, int id, string Ten_PTDien,string loai)
        {
            paintMap = new MapItemStorage();
            VectorItemsLayer imageLayer0 = new VectorItemsLayer();
            mcSoDo1Soi.Layers.Add(imageLayer0);
            double x1, x2, y1, y2;
            x1 = Math.Round(x, 5) - 0.000155;
            x2 = Math.Round(x, 5) + 0.000155;
            y1 = Math.Round(y, 5) - 0.0001000;
            y2 = Math.Round(y, 5) + 0.0001000;
            var polygon = new MapPolygon();
            polygon.Points.AddRange(new GeoPoint[] {
                new GeoPoint(x,y1),
                new GeoPoint(x1,y1),
                new GeoPoint(x1,y2),
                new GeoPoint(x,y2)
                });
            polygon.Attributes.Add(new MapItemAttribute { Name = loai, Value = id });

            MapCustomElement customElement0 = new MapCustomElement();
            customElement0.Location = new GeoPoint(x, y);
            //customElement0.AllowHtmlText = true;
            customElement0.Text = CatChuoi(Ten_PTDien, 15);
            customElement0.Font = new Font("Tahoma", fontZ, FontStyle.Regular);
            customElement0.RenderOrigin = new MapPoint(-0.2, 0.3);
            customElement0.Padding = new System.Windows.Forms.Padding(0);
            paintMap.Items.Add(customElement0);
            if (_close)
            {
                polygon.Fill = Color.Red;
                polygon.HighlightedStroke = Color.Red;
            }
            else
            {
                polygon.Fill = Color.Green;
                polygon.HighlightedStroke = Color.Green;
            }
            polygon.ToolTipPattern = Ten_PTDien;
            paintMap.Items.Add(polygon);
            imageLayer0.Data = paintMap;
        }
        private void paintPolyTBA(double x, double y,bool _close, int id, string Ten_PTDien)
        {
            paintMap = new MapItemStorage();
            VectorItemsLayer imageLayer0 = new VectorItemsLayer();
            mcSoDo1Soi.Layers.Add(imageLayer0);
            double x1, x2, y1, y2,y3;
            //x = x - 0.0000650; cho tba chi tram vao day thoi
            x1 = Math.Round(x, 7) - 0.0000650;
            x2 = Math.Round(x, 7) + 0.0000650;
            y1 = Math.Round(y, 5) - 0.0000620;
            y2 = Math.Round(y, 5) + 0.0000620;
            y3 = Math.Round(y, 5) + 0.0001300;
            var polygon = new MapPolygon();
                polygon.Points.AddRange(new GeoPoint[] {
                new GeoPoint(x,y1),
                new GeoPoint(x1,y),
                new GeoPoint(x1,y2),
                new GeoPoint(x,y3),
                new GeoPoint(x2,y2),
                new GeoPoint(x2,y)
                });
                polygon.Attributes.Add(new MapItemAttribute { Name = "TBA", Value = id });

            MapCustomElement customElement0 = new MapCustomElement();
            customElement0.Location = new GeoPoint(x, y);
            //customElement0.AllowHtmlText = true;
            customElement0.Text = CatChuoi(Ten_PTDien, 15);
            customElement0.Font = new Font("Tahoma", fontZ, FontStyle.Regular);
            customElement0.RenderOrigin = new MapPoint(-0.3, 0.6);
            customElement0.Padding = new System.Windows.Forms.Padding(0);
            paintMap.Items.Add(customElement0);
            if (_close)
            {
                polygon.Fill = Color.Red;
                polygon.HighlightedStroke = Color.Red;
            }
            else
            {
                polygon.Fill = Color.Green;
                polygon.HighlightedStroke = Color.Green;
            }
            polygon.ToolTipPattern = Ten_PTDien;
            paintMap.Items.Add(polygon);
            imageLayer0.Data = paintMap;
        }
        public void paintPoint1CDV()
        {
            List<string> toado = obj.xulyDiem(obj.ListsearchDZPoint1CDV);
            for (int i = 0; i < toado.Count; i++)
            {
                string[] xy = toado[i].Trim().Split(' ');
                double x = Convert.ToDouble(xy[0]);
                double y = Convert.ToDouble(xy[1]);
                paintPolyMC(x, y, true, true, false, obj.ListSearchIDCD1V[i], obj.ListSearchNameCD1V[i]);
            }
        }
        public void paintLineWarning()
        {
            double xTam = 0, yTam = 0;
            double xj = 0, yj = 0;
            List<string> toado = obj.xulyLine(obj.ListWarning);
            VectorItemsLayer itemsLayer = new VectorItemsLayer();
            mcSoDo1Soi.Layers.Add(itemsLayer);
            searchDayWarning = new MapItemStorage();
            for (int i = 0; i < toado.Count; i++)
            {
                string[] xline = toado[i].Split(',');
                for (int j = 0; j < xline.Count(); j++)
                {
                    MapLine mline = new MapLine();
                    mline.Stroke = Color.Gray;
                    mline.StrokeWidth = 1;
                    mline.ToolTipPattern = obj.ListSearchNameDZ22[i].ToString();
                    mline.Attributes.Add(new MapItemAttribute { Name = "DZW" });
                    string[] xy = xline[j].Trim().Split(' ');
                    double x = Convert.ToDouble(xy[0]);
                    double y = Convert.ToDouble(xy[1]);

                    if (j == 0)
                    {
                        mline.Point1 = new GeoPoint(x, y);
                        mline.Point2 = new GeoPoint(x, y);
                        xj = x;
                        yj = y;

                    }
                    if (j == 1)
                    {
                        mline.Point1 = new GeoPoint(xj, yj);
                        mline.Point2 = new GeoPoint(x, y);
                        xTam = x;
                        yTam = y;
                    }
                    if (j != 0 && j != 1)
                    {

                        mline.Point1 = new GeoPoint(xTam, yTam);
                        mline.Point2 = new GeoPoint(x, y);
                        xTam = x;
                        yTam = y;

                    }
                    searchDayWarning.Items.Add(mline);
                }
            }
            itemsLayer.Data = searchDayWarning;
            //timer1.Enabled = true;
        }
        public void paintLineWarningA()
        {
            double xTam = 0, yTam = 0;
            double xj = 0, yj = 0;
            List<string> toado = obj.xulyLine(obj.ListWarning);
            searchDayWarning = new MapItemStorage();
            for (int i = 0; i < toado.Count; i++)
            {
                string[] xline = toado[i].Split(',');
                for (int j = 0; j < xline.Count(); j++)
                {
                    MapLine mline = new MapLine();
                    mline.Stroke = Color.Gray;
                    mline.StrokeWidth = 1;
                    mline.ToolTipPattern = obj.ListSearchNameDZ22[i].ToString();
                    mline.Attributes.Add(new MapItemAttribute { Name = "DZW" });
                    string[] xy = xline[j].Trim().Split(' ');
                    double x = Convert.ToDouble(xy[0]);
                    double y = Convert.ToDouble(xy[1]);

                    if (j == 0)
                    {
                        mline.Point1 = new GeoPoint(x, y);
                        mline.Point2 = new GeoPoint(x, y);
                        xj = x;
                        yj = y;

                    }
                    if (j == 1)
                    {
                        mline.Point1 = new GeoPoint(xj, yj);
                        mline.Point2 = new GeoPoint(x, y);
                        xTam = x;
                        yTam = y;
                    }
                    if (j != 0 && j != 1)
                    {

                        mline.Point1 = new GeoPoint(xTam, yTam);
                        mline.Point2 = new GeoPoint(x, y);
                        xTam = x;
                        yTam = y;

                    }

                    searchDayWarning.Items.Add(mline);
                }
            }
            MiniMapVectorItemsLayer vectorLayer = new MiniMapVectorItemsLayer();
            mn.Layers.Add(vectorLayer);
            vectorLayer.Data = searchDayWarning;
            
        }
        public void paintLine22(int w = 1)
        {
            double xTam = 0, yTam = 0;
            double xj = 0, yj = 0;
            List<string> toado = obj.xulyLine(obj.ListsearchDZLine22);
            VectorItemsLayer itemsLayer = new VectorItemsLayer();
            mcSoDo1Soi.Layers.Add(itemsLayer);
            
            searchDay22 = new MapItemStorage();
            for (int i = 0; i < toado.Count; i++)
            {

                string[] xline = toado[i].Split(',');
                for (int j = 0; j < xline.Count(); j++)
                {
                    MapLine mline = new MapLine();
                    //mline.Stroke = color;
                    mline.Stroke = Color.Blue;
                    mline.StrokeWidth = w;
                    mline.ToolTipPattern = obj.ListSearchNameDZ22[i].ToString();
                    mline.Attributes.Add(new MapItemAttribute { Name = "DZ22", Value = obj.ListIDDZ22[i] });
                    string[] xy = xline[j].Trim().Split(' ');
                    double x = Convert.ToDouble(xy[0]);
                    double y = Convert.ToDouble(xy[1]);
                    MapPath path = new MapPath();
                    if (j == 0)
                    {
                        mline.Point1 = new GeoPoint(x, y);
                        mline.Point2 = new GeoPoint(x, y);
                        xj = x;
                        yj = y;
                    }
                    if (j == 1)
                    {
                        mline.Point1 = new GeoPoint(xj, yj);
                        mline.Point2 = new GeoPoint(x, y);
                        xTam = x;
                        yTam = y;
                        M_TTHAI_PTDIEN_LR tbaOLD = obj.getTTHAILR(obj.ListIDDZ22[i]);
                        if (tbaOLD.RIGHT_TRANGTHAI==true&&tbaOLD.LEFT_TRANGTHAI== true)
                        {
                            D_QHE_PTDIEN_VITRI vtP = obj.XemQH(obj.ListIDDZ22[i]);
                            try
                            {
                                if (vtP.ID_PTDienCha.ToString() != null)
                                {
                                    M_TTHAI_PTDIEN_LR qhCha = obj.getTTHAILR(vtP.ID_PTDienCha);
                                    string tdC = obj.xulyDiemTD(obj.vtCha(vtP.ID_PTDienCha));
                                    string[] xyT = tdC.Trim().Split(' '); 
                                    double xT = Convert.ToDouble(xyT[0]);
                                    double yT = Convert.ToDouble(xyT[1]);
                                    MapPathSegment arrow = new MapPathSegment() { IsClosed = true, IsFilled = true, StrokeWidth = 0, Fill = Color.Yellow };
                                    if (x == xj)
                                    {
                                        double tam = (y + yj) / 2;
                                        if (qhCha.CHIEUDONGDIEN.ToString().Equals(vtP.VITRI)&& xT > xj)//&&yT>yj
                                        {
                                            
                                             arrow.Points = new GeoPointCollection() { new GeoPoint(x - 0.00003, tam + 0.00005), new GeoPoint(x, tam), new GeoPoint(x + 0.00003, tam + 0.00005) };
                                        }
                                        else
                                        {
                                            arrow.Points = new GeoPointCollection() { new GeoPoint(x - 0.00003, tam - 0.00005), new GeoPoint(x, tam), new GeoPoint(x + 0.00003, tam - 0.00005) };
                                        }
                                    }
                                    else
                                    {
                                        double tam = (x + xj) / 2;
                                        if (qhCha.CHIEUDONGDIEN.ToString().Equals(vtP.VITRI)&& yT > yj)//&&xT>xj
                                        {
                                            arrow.Points = new GeoPointCollection() { new GeoPoint(tam - 0.00005, y - 0.00003), new GeoPoint(tam, y), new GeoPoint(tam - 0.00005, y + 0.00003) };
                                        }
                                        else
                                        {
                                            arrow.Points = new GeoPointCollection() { new GeoPoint(tam + 0.00005, y - 0.00003), new GeoPoint(tam, y), new GeoPoint(tam + 0.00005, y + 0.00003) };
                                        }


                                    }
                                    path.Segments.Add(arrow);
                                }
                            }
                            catch (Exception)
                            {
                                
                            }
                        }
                        /*MapPathSegment arrow = new MapPathSegment() { IsClosed = true, IsFilled = true, StrokeWidth = 0 };
                        //arrow.Points = new GeoPointCollection() { new GeoPoint(x - 0.000000008, y - 0.000000008), new GeoPoint(x, y), new GeoPoint(x - 0.00000001, y - 0.000000008) };
                        arrow.Points = new GeoPointCollection() { new GeoPoint(19.2, 9.2), new GeoPoint(20, 10), new GeoPoint(19.0, 9.82) };
                        path.Segments.Add(arrow);*/
                    }
                    if (j != 0 && j != 1)
                    {
                        mline.Point1 = new GeoPoint(xTam, yTam);
                        mline.Point2 = new GeoPoint(x, y);
                        xTam = x;
                        yTam = y;

                    }
                    searchDay22.Items.Add(path);
                    searchDay22.Items.Add(mline);
                }
            }
            
            itemsLayer.Data = searchDay22;
            
        }
        public void paintLine22A(int w = 1)
        {
            double xTam = 0, yTam = 0;
            double xj = 0, yj = 0;
            List<string> toado = obj.xulyLine(obj.ListsearchDZLine22);

            searchDay22A = new MapItemStorage();
            for (int i = 0; i < toado.Count; i++)
            {

                string[] xline = toado[i].Split(',');
                for (int j = 0; j < xline.Count(); j++)
                {
                    MapLine mline = new MapLine();
                    //mline.Stroke = color;
                    mline.Stroke = Color.Blue;
                    mline.StrokeWidth = w;
                    mline.ToolTipPattern = obj.ListSearchNameDZ22[i].ToString();
                    mline.Attributes.Add(new MapItemAttribute { Name = "DZ22", Value = obj.ListIDDZ22[i] });
                    string[] xy = xline[j].Trim().Split(' ');
                    double x = Convert.ToDouble(xy[0]);
                    double y = Convert.ToDouble(xy[1]);

                    if (j == 0)
                    {
                        mline.Point1 = new GeoPoint(x, y);
                        mline.Point2 = new GeoPoint(x, y);
                        xj = x;
                        yj = y;

                    }
                    if (j == 1)
                    {
                        mline.Point1 = new GeoPoint(xj, yj);
                        mline.Point2 = new GeoPoint(x, y);
                        xTam = x;
                        yTam = y;
                    }
                    if (j != 0 && j != 1)
                    {

                        mline.Point1 = new GeoPoint(xTam, yTam);
                        mline.Point2 = new GeoPoint(x, y);
                        xTam = x;
                        yTam = y;

                    }

                    searchDay22A.Items.Add(mline);
                }
            }
            MiniMapVectorItemsLayer vectorLayer = new MiniMapVectorItemsLayer();
            mn.Layers.Add(vectorLayer);
            
            vectorLayer.Data = searchDay22A;

        }
        public void paintLine35(int w = 1)
        {
            double xTam = 0, yTam = 0;
            double xj = 0, yj = 0;
            List<string> toado = obj.xulyLine(obj.ListsearchDZLine35);
            VectorItemsLayer itemsLayer = new VectorItemsLayer();
            mcSoDo1Soi.Layers.Add(itemsLayer);
            searchDay35 = new MapItemStorage();
            for (int i = 0; i < toado.Count; i++)
            {

                string[] xline = toado[i].Split(',');
                for (int j = 0; j < xline.Count(); j++)
                {
                    MapLine mline = new MapLine();
                    //mline.Stroke = color;
                    mline.Stroke = Color.Yellow;
                    mline.StrokeWidth = w;
                    mline.ToolTipPattern = obj.ListSearchNameDZ35[i].ToString();
                    mline.Attributes.Add(new MapItemAttribute { Name = "DZ35", Value = obj.ListIDDZ35[i] });
                    string[] xy = xline[j].Trim().Split(' ');
                    double x = Convert.ToDouble(xy[0]);
                    double y = Convert.ToDouble(xy[1]);

                    if (j == 0)
                    {
                        mline.Point1 = new GeoPoint(x, y);
                        mline.Point2 = new GeoPoint(x, y);
                        xj = x;
                        yj = y;

                    }
                    if (j == 1)
                    {
                        mline.Point1 = new GeoPoint(xj, yj);
                        mline.Point2 = new GeoPoint(x, y);
                        xTam = x;
                        yTam = y;
                    }
                    if (j != 0 && j != 1)
                    {

                        mline.Point1 = new GeoPoint(xTam, yTam);
                        mline.Point2 = new GeoPoint(x, y);
                        xTam = x;
                        yTam = y;

                    }
                    searchDay35.Items.Add(mline);
                }
            }
            itemsLayer.Data = searchDay35;
        }
        public void paintLine35A(int w = 1)
        {
            double xTam = 0, yTam = 0;
            double xj = 0, yj = 0;
            List<string> toado = obj.xulyLine(obj.ListsearchDZLine35);
            searchDay35A = new MapItemStorage();
            for (int i = 0; i < toado.Count; i++)
            {

                string[] xline = toado[i].Split(',');
                for (int j = 0; j < xline.Count(); j++)
                {
                    MapLine mline = new MapLine();
                    //mline.Stroke = color;
                    mline.Stroke = Color.Yellow;
                    mline.StrokeWidth = w;
                    mline.ToolTipPattern = obj.ListSearchNameDZ35[i].ToString();
                    mline.Attributes.Add(new MapItemAttribute { Name = "DZ35", Value = obj.ListIDDZ35[i] });
                    string[] xy = xline[j].Trim().Split(' ');
                    double x = Convert.ToDouble(xy[0]);
                    double y = Convert.ToDouble(xy[1]);

                    if (j == 0)
                    {
                        mline.Point1 = new GeoPoint(x, y);
                        mline.Point2 = new GeoPoint(x, y);
                        xj = x;
                        yj = y;

                    }
                    if (j == 1)
                    {
                        mline.Point1 = new GeoPoint(xj, yj);
                        mline.Point2 = new GeoPoint(x, y);
                        xTam = x;
                        yTam = y;
                    }
                    if (j != 0 && j != 1)
                    {

                        mline.Point1 = new GeoPoint(xTam, yTam);
                        mline.Point2 = new GeoPoint(x, y);
                        xTam = x;
                        yTam = y;

                    }
                    searchDay35A.Items.Add(mline);
                }
            }
            MiniMapVectorItemsLayer vectorLayer = new MiniMapVectorItemsLayer();
            mn.Layers.Add(vectorLayer);
            vectorLayer.Data = searchDay35A;
        }
        private void BTLamMoi_Click(object sender, EventArgs e)
        {
            RefreshDataLocal();
            /*if (cbDonVi.EditValue!=null)
            {
                if (mcSoDo1Soi.ZoomLevel >= 17D)
                {
                    fontZ = 6;
                }
                else
                {
                    if (mcSoDo1Soi.ZoomLevel == 16D)
                    {
                        fontZ = 5;
                    }
                    else
                    {
                        fontZ = 4;
                    }
                }
                huydoituongSearchday();
                paintAll(cbDonVi.EditValue.ToString(), cap);
            }*/
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            //pictureBox1.Visible = false;
        }

        private void McSoDo1Soi_MouseMove(object sender, MouseEventArgs e)
        {
            if (ve)
            {
                VectorItemsLayer VectorLayer = new VectorItemsLayer();
                mcSoDo1Soi.Layers.Add(VectorLayer);
                if (itemstorePolie.Items.Contains(Pline11))
                {
                    itemstorePolie.Items.Remove(Pline11);
                }
                Pline11 = new MapPolyline();
                Pline11.StrokeWidth = 1;
                Pline11.Stroke = Color.Red;
                MapPoint MyPoint1A = new DevExpress.XtraMap.MapPoint(((MouseEventArgs)e).X+500, ((MouseEventArgs)e).Y);
                MapPoint MyPoint2A = new DevExpress.XtraMap.MapPoint(((MouseEventArgs)e).X +8, ((MouseEventArgs)e).Y);
                GeoPoint GP1A = VectorLayer.ScreenPointToGeoPoint(MyPoint1A);
                GeoPoint GP2A = VectorLayer.ScreenPointToGeoPoint(MyPoint2A);
                Pline11.Points.Add(GP1A);
                Pline11.Points.Add(GP2A);
                itemstorePolie.Items.Add(Pline11);
                if (itemstorePolie.Items.Contains(Pline12))
                {
                    itemstorePolie.Items.Remove(Pline12);
                }
                Pline12 = new MapPolyline();
                Pline12.StrokeWidth = 1;
                Pline12.Stroke = Color.Red;
                MapPoint MyPoint1B = new DevExpress.XtraMap.MapPoint(((MouseEventArgs)e).X - 500, ((MouseEventArgs)e).Y);
                MapPoint MyPoint2B = new DevExpress.XtraMap.MapPoint(((MouseEventArgs)e).X - 8, ((MouseEventArgs)e).Y);
                GeoPoint GP1B = VectorLayer.ScreenPointToGeoPoint(MyPoint1B);
                GeoPoint GP2B = VectorLayer.ScreenPointToGeoPoint(MyPoint2B);
                Pline12.Points.Add(GP1B);
                Pline12.Points.Add(GP2B);
                itemstorePolie.Items.Add(Pline12);
                if (itemstorePolie.Items.Contains(Pline21))
                {
                    itemstorePolie.Items.Remove(Pline21);
                }
                Pline21 = new MapPolyline();
                Pline21.StrokeWidth = 1;
                Pline21.Stroke = Color.Red;
                MapPoint MyPoint3A = new DevExpress.XtraMap.MapPoint(((MouseEventArgs)e).X , ((MouseEventArgs)e).Y+500);
                MapPoint MyPoint4A = new DevExpress.XtraMap.MapPoint(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y+8);
                GeoPoint GP3A = VectorLayer.ScreenPointToGeoPoint(MyPoint3A);
                GeoPoint GP4A = VectorLayer.ScreenPointToGeoPoint(MyPoint4A);
                Pline21.Points.Add(GP3A);
                Pline21.Points.Add(GP4A);
                itemstorePolie.Items.Add(Pline21);
                if (itemstorePolie.Items.Contains(Pline22))
                {
                    itemstorePolie.Items.Remove(Pline22);
                }
                Pline22 = new MapPolyline();
                Pline22.StrokeWidth = 1;
                Pline22.Stroke = Color.Red;
                MapPoint MyPoint3B = new DevExpress.XtraMap.MapPoint(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y - 500);
                MapPoint MyPoint4B = new DevExpress.XtraMap.MapPoint(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y - 8);
                GeoPoint GP3B = VectorLayer.ScreenPointToGeoPoint(MyPoint3B);
                GeoPoint GP4B = VectorLayer.ScreenPointToGeoPoint(MyPoint4B);
                Pline22.Points.Add(GP3B);
                Pline22.Points.Add(GP4B);
                itemstorePolie.Items.Add(Pline22);
                VectorLayer.Data = itemstorePolie;
            }
        }

        public void paintPoint1MCV()
        {
            List<string> toado = obj.xulyDiem(obj.ListsearchDZPoint1MCV);
            VectorItemsLayer imageLayer0 = new VectorItemsLayer();
            for (int i = 0; i < toado.Count; i++)
            {
                string[] xy = toado[i].Trim().Split(' ');
                double x = Convert.ToDouble(xy[0]);
                double y = Convert.ToDouble(xy[1]);
                paintPolyMC(x, y, true, true, true, obj.ListSearchIDMC1V[i], obj.ListSearchNameMC1V[i].ToString());
            }
        }
        public void paintPoint1MCVA()
        {
            List<string> toado = obj.xulyDiem(obj.ListsearchDZPoint1MCV);
            mn1MC = new MapItemStorage();
            for (int i = 0; i < toado.Count; i++)
            {
                string[] xy = toado[i].Trim().Split(' ');
                double x = Convert.ToDouble(xy[0]);
                double y = Convert.ToDouble(xy[1]);
                mn1MC.Items.Add(new MapDot() { Location = new GeoPoint(x, y), Size = 2, Stroke = Color.Red,Fill=Color.Red });
            }
            MiniMapVectorItemsLayer vectorLayer = new MiniMapVectorItemsLayer();
            mn.Layers.Add(vectorLayer);

            vectorLayer.Data = mn1MC;
        }
        public void paintPoint0MCVA()
        {
            List<string> toado = obj.xulyDiem(obj.ListsearchDZPoint0MCV);
            mn0MC = new MapItemStorage();
            for (int i = 0; i < toado.Count; i++)
            {
                string[] xy = toado[i].Trim().Split(' ');
                double x = Convert.ToDouble(xy[0]);
                double y = Convert.ToDouble(xy[1]);
                mn0MC.Items.Add(new MapDot() { Location = new GeoPoint(x, y), Size = 2, Stroke = Color.Green, Fill = Color.Green });
            }
            MiniMapVectorItemsLayer vectorLayer = new MiniMapVectorItemsLayer();
            mn.Layers.Add(vectorLayer);

            vectorLayer.Data = mn0MC;
        }
        public void paintPoint1MCH()
        {
            List<string> toado = obj.xulyDiem(obj.ListsearchDZPoint1MCH);
            for (int i = 0; i < toado.Count; i++)
            {
                string[] xy = toado[i].Trim().Split(' ');
                double x = Convert.ToDouble(xy[0]);
                double y = Convert.ToDouble(xy[1]);
                paintPolyMC(x, y, false, true, true, obj.ListSearchIDMC1H[i], obj.ListSearchNameMC1H[i].ToString());
            }
        }
        public void paintPoint0CDV()
        {
            List<string> toado = obj.xulyDiem(obj.ListsearchDZPoint0CDV);
            for (int i = 0; i < toado.Count; i++)
            {
                string[] xy = toado[i].Trim().Split(' ');
                double x = Convert.ToDouble(xy[0]);
                double y = Convert.ToDouble(xy[1]);
                paintPolyMC(x, y, true, false, false, obj.ListSearchIDCD0V[i], obj.ListSearchNameCD0V[i].ToString());
            }
        }
        public void paintPoint0MCDZV()
        {
            List<string> toado = obj.xulyDiem(obj.ListsearchDZPoint0MCDZV);
            for (int i = 0; i < toado.Count; i++)
            {
                string[] xy = toado[i].Trim().Split(' ');
                double x = Convert.ToDouble(xy[0]);
                double y = Convert.ToDouble(xy[1]);
                paintPolyMCSI(x, y,  false, obj.ListSearchIDMCDZ0V[i], obj.ListSearchNameMCDZ0V[i].ToString(), "MCDZ0V");
            }
        }
        
        public void paintPoint1MCDZV()
        {
            List<string> toado = obj.xulyDiem(obj.ListsearchDZPoint1MCDZV);
            for (int i = 0; i < toado.Count; i++)
            {
                string[] xy = toado[i].Trim().Split(' ');
                double x = Convert.ToDouble(xy[0]);
                double y = Convert.ToDouble(xy[1]);
                paintPolyMCSI(x, y, false, obj.ListSearchIDMCDZ1V[i], obj.ListSearchNameMCDZ1V[i].ToString(), "MCDZ1V");
            }
        }
        
        public void paintPoint0SIV()
        {
            List<string> toado = obj.xulyDiem(obj.ListsearchDZPoint0SIV);
            for (int i = 0; i < toado.Count; i++)
            {
                string[] xy = toado[i].Trim().Split(' ');
                double x = Convert.ToDouble(xy[0]);
                double y = Convert.ToDouble(xy[1]);
                paintPolyMCSI(x, y, false, obj.ListSearchIDSI0V[i], obj.ListSearchNameSI0V[i].ToString(), "SI0V");
            }
        }

        private void BTBaner1_Click(object sender, EventArgs e)
        {
            if (panelControl5.Visible==true)
            {
                panelControl5.Visible = false;
            }
            else
            {
                if (loai.Equals("0"))
                {
                    panelControl5.Visible = true; 
                }
                else
                {
                    MessageBox.Show("Bạn không có quyền sử dụng tính năng này");
                }
                
            }
        }

        private void ButtonLeft_Click(object sender, EventArgs e)
        {
            int tl = int.Parse(lbTroLuc.Text);
            if (tl == 6)
            {
                lbTroLuc.Text = "5";
            }
            else
            {
                if (tl == 5)
                {
                    lbTroLuc.Text = "4";
                }
                else
                {
                    if (tl == 4)
                    {
                        lbTroLuc.Text = "3";
                    }
                    else
                    {
                        if (tl == 3)
                        {
                            lbTroLuc.Text = "2";
                        }
                    }
                }
            }
            TL = int.Parse(lbTroLuc.Text);
        }

        private void ButtonRight_Click(object sender, EventArgs e)
        {
            int tl = int.Parse(lbTroLuc.Text);
            if (tl == 1)
            {
                lbTroLuc.Text = "2";
            }
            else
            {
                if (tl == 2)
                {
                    lbTroLuc.Text = "3";
                }
                else
                {
                    if (tl == 3)
                    {
                        lbTroLuc.Text = "4";
                    }
                    else
                    {
                        if (tl == 4)
                        {
                            lbTroLuc.Text = "5";
                        }
                        else
                        {
                            if (tl == 5)
                            {
                                lbTroLuc.Text = "6";
                            }
                        }
                    }
                }
            }
            TL = int.Parse(lbTroLuc.Text);
        }

        private void BtTroLuc_Click(object sender, EventArgs e)
        {
            if (btTroLuc.Text.Equals("Bật trợ lực"))
            {
                btTroLuc.Text = "Tắt trợ lực";
                pictureBox1.Visible = true;
                timerZoom.Enabled = true;
            }
            else
            {
                btTroLuc.Text = "Bật trợ lực";
                pictureBox1.Visible = false;
                timerZoom.Enabled = false;
            }
        }

        private void SimpleButton3_Click(object sender, EventArgs e)
        {
            if (cbDonVi.EditValue==null)
            {
                MessageBox.Show("Vui lòng chọn đơn vị");
            }
            {
                RefreshDataLocal();
            }
        }

        private void SimpleButton4_Click(object sender, EventArgs e)
        {
            idAlign = new List<int>();
            btok.Enabled = true;
            btCancel.Enabled = true;
            cmdbtAlignLeft.Enabled = false;
            cmdbtSameHeightLR.Enabled = false;
            cmdbtSameWidthLR.Enabled = false;
            cmdbtSameHeightRL.Enabled = false;
            cmdbtSameWidthRL.Enabled = false;
        }
        private void BtCancel_Click(object sender, EventArgs e)
        {
            btok.Enabled = false;
            btCancel.Enabled = false;
            cmdbtAlignLeft.Enabled = cta;
            cmdbtAlignTop.Enabled = cte;
            cmdbtSameWidthLR.Enabled = kct;
            cmdbtSameHeightLR.Enabled = kht;
            cmdbtSameWidthRL.Enabled = kcp;
            cmdbtSameHeightRL.Enabled = khd;
            idPTD = 0;
        }

        private void RadioButton35_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton35.Checked)
            {
                cap = "06";
            }
        }

        private void RadioButton22_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton22.Checked)
            {
                cap = "05";
            }
        }

        private void SimpleButton4_Click_1(object sender, EventArgs e)
        {
            if (cbVitri.SelectedIndex==-1)
            {
                MessageBox.Show("Bạn vui lòng chọn vị trí cần đặt");
            }
            else
            {
                if (cbVitri.SelectedIndex==0)
                {
                    LDSong.Properties.Settings.Default.Vitri1 = mcSoDo1Soi.CenterPoint.ToString();
                }
                if (cbVitri.SelectedIndex == 1)
                {
                    LDSong.Properties.Settings.Default.Vitri2 = mcSoDo1Soi.CenterPoint.ToString();
                }
                if (cbVitri.SelectedIndex == 2)
                {
                    LDSong.Properties.Settings.Default.Vitri3 = mcSoDo1Soi.CenterPoint.ToString();
                }
                LDSong.Properties.Settings.Default.Save(); 
            }
        }

        private void thiếtLậpQuanHệToolStripMenuItem_Click(object sender, EventArgs e)
        {
            qhe = true;
            if (!loaiTB.Equals("TBA") && qhe)//luachon.qhe
            {
                toadoControler1 td1 = new toadoControler1();
                groupControl4.Visible = true;
                gridTLQHe.DataSource = null;
                gridTLQHe.DataSource = td1.listLR(idPTD);
                lbIDNut.Text = idPTD.ToString();

            }
            else
            {
                this.qhe = false;
                MessageBox.Show("Loại phần tử điện này không thể thêm.");
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dungXetQH();
        }
        public void dungXetQH()
        {
            qhe = false;
            groupControl4.Visible = false;
        }

        private void caapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool c = true;
            toadoControler1 obj1 = new toadoControler1();
            D_QHE_PTDIEN_VITRI objLR = new D_QHE_PTDIEN_VITRI();
            objLR.ID_PTDienCha = int.Parse(lbIDNut.Text);
            objLR.ID_PTDienCon = idPTD;
            objLR.TENPTDienCon = lbTenNut.Text;
            objLR.VITRI = "L";
            objLR.NGAYCAPNHAT = obj.getDateServer();
            objLR.USERNAME = userName;
            if (obj1.checkQH(int.Parse(objLR.ID_PTDienCha.ToString()), int.Parse(objLR.ID_PTDienCon.ToString())))
            {
                obj1.addLR(objLR);
            }
            else
            {
                c = false;
                MessageBox.Show("Phần tử điện " + objLR.ID_PTDienCon + " đã có. Không thể thêm.");
            }
            if (c)
            {
                MessageBox.Show("Thêm quan hệ thành công!");
            }
            gridTLQHe.DataSource = obj1.listLR(int.Parse(lbIDNut.Text));
        }

        private void cậpNhậtThôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool c = true;
            toadoControler1 obj1 = new toadoControler1();
            D_QHE_PTDIEN_VITRI objLR = new D_QHE_PTDIEN_VITRI();
            objLR.ID_PTDienCha = int.Parse(lbIDNut.Text);
            objLR.ID_PTDienCon = idPTD;
            objLR.TENPTDienCon = lbTenNut.Text;
            objLR.VITRI = "R";
            objLR.NGAYCAPNHAT = obj.getDateServer();
            objLR.USERNAME = userName;
            if (obj1.checkQH(int.Parse(objLR.ID_PTDienCha.ToString()), int.Parse(objLR.ID_PTDienCon.ToString())))
            {
                obj1.addLR(objLR);
            }
            else
            {
                c = false;
                MessageBox.Show("Phần tử điện " + objLR.ID_PTDienCon + " đã có. Không thể thêm.");
            }
            if (c)
            {
                MessageBox.Show("Thêm quan hệ thành công!");
            }
            gridTLQHe.DataSource = obj1.listLR(int.Parse(lbIDNut.Text));
        }

        private void dừngXétQuanHệToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dungXetQH();
        }

        private void xemQuanHệToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInforQuanHe frm = new frmInforQuanHe(idPTD);
            frm.ShowDialog();
        }

        private void xóaTấtCảQuanHệVớiPhầnTửToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa tất cả quan hệ của phần tử này với các phần tử khác?", "Xác nhận", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                toadoControler1 obj1 = new toadoControler1();
                List<D_QHE_PTDIEN_VITRI> lstQH = obj1.listLRCon(idPTD);
                if (lstQH.Count != 0)
                {
                    obj1.deleteAllLR(lstQH);
                    MessageBox.Show("Xóa tất cả quan hệ có liên quan với phần tử này thành công!");
                    gridTLQHe.DataSource = null;
                    gridTLQHe.DataSource = obj1.listLR(int.Parse(lbIDNut.Text));
                }
                else
                {
                    MessageBox.Show("Phần tử này không có quan hệ với phần tử nào nào để xóa");
                }
            }
        }

        private void mcSoDo1Soi_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (Int32)Keys.Enter)
                {
                    frmFindToaDo frm = new frmFindToaDo(false);
                    frm.ShowDialog();
                    string s = frmFindToaDo.td.Trim();
                    if (s != "" && s != null)
                    {
                        try
                        {
                            string[] s1 = s.Split(' ');
                            double s01 = double.Parse(s1[0]);
                            double s11 = double.Parse(s1[1]);
                            this.mcSoDo1Soi.CenterPoint = new DevExpress.XtraMap.GeoPoint(s01, s11);
                            inforSearch(s, s01, s11);
                        }
                        catch (Exception)
                        {
                            string[] toadodiem = obj.searchDiem("", s, DVQuanLy, "05", "06");
                            try
                            {
                                if (toadodiem != null)
                                {
                                    string td = toadodiem[1].ToString().Replace(")", "");
                                    string[] tam = td.Split(' ');
                                    double x = double.Parse(tam[0]);
                                    double y = double.Parse(tam[1].Replace(',', ' '));
                                    mcSoDo1Soi.CenterPoint = new GeoPoint(x, y);
                                    inforSearch(obj.listSearchten[0].ToString(), x, y);
                                }
                            }
                            catch (Exception)
                            {

                                MessageBox.Show("Hệ thống không tìm kiếm được tọa độ bạn nhập vào.Vui lòng kiểm tra lại.");
                            }
                            frmFindToaDo.td = "";
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }
        MapItem[] GetCapitals(string text, double x, double y)
        {
            return new MapItem[] {
                new MapCallout() { Text = text, Location = new GeoPoint(x, y) },
                };
        }
        public void inforSearch(string text, double x, double y)
        {
            VectorItemsLayer itemsLayer = new VectorItemsLayer();
            mcSoDo1Soi.Layers.Add(itemsLayer);
            MapItemStorage storage = new MapItemStorage();
            MapItem[] mapitem = GetCapitals(text, x, y);
            storage.Items.AddRange(mapitem);
            itemsLayer.Data = storage;
            timer1.Enabled = true;
            delay_ms(3000);
            storage.Items.RemoveAt(0);
            timer1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            t++;
            if (t > 6000) t = 0;
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            if (mcSoDo1Soi.MiniMap.Visible)
            {
                mcSoDo1Soi.MiniMap.Visible = false;
                simpleButton6.Text = "Hiện khung con";
            }
            else
            {
                mcSoDo1Soi.MiniMap.Visible = true;
                simpleButton6.Text = "Ẩn khung con";
            }
        }

        private void delay_ms(int delayms)
        {
            t = 0;
            do
            {
                Application.DoEvents();
            }
            while (t < (delayms / 100));
            Application.DoEvents();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa tất cả quan hệ?", "Cảnh báo!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                toadoControler1 obj1 = new toadoControler1();
                List<D_QHE_PTDIEN_VITRI> lstQH = obj1.listLR(int.Parse(lbIDNut.Text));
                if (lstQH.Count != 0)
                {
                    obj1.deleteAllLR(lstQH);
                    MessageBox.Show("Xóa tất cả quan hệ có liên quan với phần tử này thành công!");
                    gridTLQHe.DataSource = null;
                }
                else
                {
                    MessageBox.Show("Phần tử này không có quan hệ nào để xóa");
                }
            }
        }

        private void cậpNhậtTrạngTháiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTrangthaiTram trangthai = new frmTrangthaiTram(idPTD.ToString(), userName);
            trangthai.ShowDialog();
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                itemstorePolieDZ.Items.Clear();
                itemstorePolieDZ.Dispose();
            }
            catch (Exception)
            {
            }
        }

        private void lùiLạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            luilai();
        }

        private void thêmMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!DVQuanLy.Equals(""))
            {
                frmCreatePTDSoDo1Soi_DZ createPTD = new frmCreatePTDSoDo1Soi_DZ(toadoLine, DVQuanLy, userName);
                createPTD.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn đơn vị quản lý.");
            }
        }

        private void SimpleButton5_Click(object sender, EventArgs e)
        {
            if (cbVitri.SelectedIndex == -1)
            {
                MessageBox.Show("Bạn vui lòng chọn vị trí cần đi đến");
            }
            else
            {
                try
                {
                    if (cbVitri.SelectedIndex == 0)
                    {
                        string[] temp = LDSong.Properties.Settings.Default.Vitri1.Split(',');
                        mcSoDo1Soi.CenterPoint = new GeoPoint(double.Parse(temp[0]), double.Parse(temp[1]));
                    }
                    if (cbVitri.SelectedIndex == 1)
                    {
                        string[] temp = LDSong.Properties.Settings.Default.Vitri2.Split(',');
                        mcSoDo1Soi.CenterPoint = new GeoPoint(double.Parse(temp[0]), double.Parse(temp[1]));
                    }
                    if (cbVitri.SelectedIndex == 2)
                    {
                        string[] temp = LDSong.Properties.Settings.Default.Vitri3.Split(',');
                        mcSoDo1Soi.CenterPoint = new GeoPoint(double.Parse(temp[0]), double.Parse(temp[1]));
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Bạn chưa đặt vị trí này");
                }
            }
        }

        private void BtSameWidth_Click(object sender, EventArgs e)
        {
            idAlign = new List<int>();
            btok.Enabled = true;
            btCancel.Enabled = true;
            cmdbtAlignTop.Enabled = false;
            cmdbtSameHeightLR.Enabled = false;
            cmdbtAlignLeft.Enabled = false;
            cmdbtSameHeightRL.Enabled = false;
            cmdbtSameWidthRL.Enabled = false;
        }

        private void BtSameHeight_Click(object sender, EventArgs e)
        {
            idAlign = new List<int>();
            btok.Enabled = true;
            btCancel.Enabled = true;
            cmdbtAlignTop.Enabled = false;
            cmdbtSameWidthLR.Enabled = false;
            cmdbtAlignLeft.Enabled = false;
            cmdbtSameHeightRL.Enabled = false;
            cmdbtSameWidthRL.Enabled = false;
        }

        private void BtSameWidthRL_Click(object sender, EventArgs e)
        {
            idAlign = new List<int>();
            btok.Enabled = true;
            btCancel.Enabled = true;
            cmdbtAlignTop.Enabled = false;
            cmdbtAlignLeft.Enabled = false;
            cmdbtSameHeightLR.Enabled = false;
            cmdbtSameWidthLR.Enabled = false;
            cmdbtSameHeightRL.Enabled = false;
        }

        private void BtSameHeightRL_Click(object sender, EventArgs e)
        {
            idAlign = new List<int>();
            btok.Enabled = true;
            btCancel.Enabled = true;
            cmdbtAlignTop.Enabled = false;
            cmdbtAlignLeft.Enabled = false;
            cmdbtSameHeightLR.Enabled = false;
            cmdbtSameWidthLR.Enabled = false;
            cmdbtSameWidthRL.Enabled = false;
        }

        private void BtAlignLeft_Click(object sender, EventArgs e)
        {
            idAlign = new List<int>();
            btok.Enabled = true;
            btCancel.Enabled = true;
            cmdbtAlignTop.Enabled = false;
            cmdbtSameHeightLR.Enabled = false;
            cmdbtSameWidthLR.Enabled = false;
            cmdbtSameHeightRL.Enabled = false;
            cmdbtSameWidthRL.Enabled = false;
        }

        private void Btok_Click(object sender, EventArgs e)
        {
            if (idAlign.Count>1)
            {
                List<string> td = new List<string>();
                foreach (var item in idAlign)
                {
                    string temp = obj.todoPhanTu(item);
                    if (temp!=null)
                    {
                        td.Add(temp);
                    }
                }
                List<string> xl = obj.xulyDiem(td);
                string[] td1 = xl[0].Split(' ');
                if (cmdbtAlignTop.Enabled)
                {
                    for (int i = 1; i < xl.Count; i++)
                    {
                        string[] td2 = xl[i].Split(' ');
                        string td22 = "POINT (" + td1[0] + " " + td2[1] + ")";
                        string query = "UPDATE M_VITRI_SD1S SET VITRI=geometry::STGeomFromText('" + td22 + "', 0) where ID_PTDIEN=" + idAlign[i];
                        obj.insertORupdateVitri(query);

                    }
                }
                else
                {
                    if (cmdbtAlignLeft.Enabled)
                    {
                        for (int i = 1; i < xl.Count; i++)
                        {
                            string[] td2 = xl[i].Split(' ');
                            string td22 = "POINT (" + td2[0] +" "+ td1[1] + ")";
                            string query = "UPDATE M_VITRI_SD1S SET VITRI=geometry::STGeomFromText('" + td22 + "', 0) where ID_PTDIEN=" + idAlign[i];
                            obj.insertORupdateVitri(query);
                        }
                    }
                    else
                    {
                        if (idAlign.Count>2)
                        {
                            string[] tdS2 = xl[1].Split(' ');
                            
                            if (cmdbtSameWidthLR.Enabled)
                            {
                                double tdS22 = double.Parse(tdS2[1]);
                                double hieu = double.Parse(td1[1]) - tdS22;
                                if (hieu > 0)
                                {
                                    tdS22 = double.Parse(td1[1]);
                                }
                                double tmp = Math.Abs(hieu);
                                for (int i = 2; i < xl.Count; i++)
                                {
                                    
                                    tdS22 = tdS22 + tmp;
                                    string[] td3 = xl[i].Split(' ');
                                    string td33= "POINT (" + td3[0] + " " + tdS22 + ")";
                                    string query = "UPDATE M_VITRI_SD1S SET VITRI=geometry::STGeomFromText('" + td33 + "', 0) where ID_PTDIEN=" + idAlign[i];
                                    obj.insertORupdateVitri(query);
                                }
                            }
                            else
                            {
                                if (cmdbtSameWidthRL.Enabled)
                                {
                                    double tdS22 = double.Parse(tdS2[1]);
                                    double hieu = double.Parse(td1[1]) - tdS22;
                                    if (hieu < 0)
                                    {
                                        tdS22 = double.Parse(td1[1]);
                                    }
                                    double tmp = Math.Abs(hieu);
                                    for (int i = 2; i < xl.Count; i++)
                                    {

                                        tdS22 = tdS22 - tmp;
                                        string[] td3 = xl[i].Split(' ');
                                        string td33 = "POINT (" + td3[0] + " " + tdS22 + ")";
                                        string query = "UPDATE M_VITRI_SD1S SET VITRI=geometry::STGeomFromText('" + td33 + "', 0) where ID_PTDIEN=" + idAlign[i];
                                        obj.insertORupdateVitri(query);
                                    }
                                }
                                else
                                {
                                    if (cmdbtSameHeightLR.Enabled)
                                    {
                                        double tdS22 = double.Parse(tdS2[0]);
                                        double hieu = double.Parse(td1[0]) - tdS22;
                                        if (hieu < 0)
                                        {
                                            tdS22 = double.Parse(td1[0]);
                                        }
                                        double tmp = Math.Abs(hieu);
                                        for (int i = 2; i < xl.Count; i++)
                                        {
                                            tdS22 = tdS22 - tmp;
                                            string[] td3 = xl[i].Split(' ');
                                            string td33 = "POINT (" + tdS22 + " " + td3[1] + ")";
                                            string query = "UPDATE M_VITRI_SD1S SET VITRI=geometry::STGeomFromText('" + td33 + "', 0) where ID_PTDIEN=" + idAlign[i];
                                            obj.insertORupdateVitri(query);
                                        }
                                    }
                                    else
                                    {
                                        if (cmdbtSameHeightRL.Enabled)
                                        {
                                            double tdS22 = double.Parse(tdS2[0]);
                                            double hieu = double.Parse(td1[0]) - tdS22;
                                            if (hieu > 0)
                                            {
                                                tdS22 = double.Parse(td1[0]);
                                            }
                                            double tmp = Math.Abs(hieu);
                                            for (int i = 2; i < xl.Count; i++)
                                            {
                                                tdS22 = tdS22 + tmp;
                                                string[] td3 = xl[i].Split(' ');
                                                string td33 = "POINT (" + tdS22 + " " + td3[1] + ")";
                                                string query = "UPDATE M_VITRI_SD1S SET VITRI=geometry::STGeomFromText('" + td33 + "', 0) where ID_PTDIEN=" + idAlign[i];
                                                obj.insertORupdateVitri(query);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                RefreshDataLocal();
                cmdbtAlignLeft.Enabled = cta;
                cmdbtAlignTop.Enabled = cte;
                cmdbtSameWidthLR.Enabled = kct;
                cmdbtSameHeightLR.Enabled = kht;
                cmdbtSameWidthRL.Enabled = kcp;
                cmdbtSameHeightRL.Enabled = khd;
                btok.Enabled = false;
                btCancel.Enabled = false;
            }
        }

        private void SimpleButton2_Click_1(object sender, EventArgs e)
        {
            panelControl5.Visible = false;
        }

        private void timerZoom_Tick(object sender, EventArgs e)
        {
            troluc(TL - 1);
            var pt1H = mcSoDo1Soi.Size.Height;
            pictureBox1.Location = new Point(Location.X,pt1H - pictureBox1.Height);

        }
        private void troluc(int t)
        {
            var endWidth = pictureBox1.Width;
            var endHeight = pictureBox1.Height;

            var scaleFactor = 2;
            var startWidth = endWidth / scaleFactor;
            var startHeight = endHeight / scaleFactor;

            bmp = new Bitmap(startWidth, startHeight);

            g = this.CreateGraphics();
            g = Graphics.FromImage(bmp);

            var xPos = Math.Max(-100, MousePosition.X - (startWidth / 2)); // divide by two in order to center
            var yPos = Math.Max(-100, MousePosition.Y - (startHeight / 2));

            g.CopyFromScreen(xPos, yPos, 0, 0, new Size(endWidth, endHeight));

            bmp1 = new Bitmap(bmp, new Size(endWidth * t, endHeight * t));
            pictureBox1.Image = bmp1;
            pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
        }
        public void paintPoint1SIV()
        {
            List<string> toado = obj.xulyDiem(obj.ListsearchDZPoint1SIV);
            for (int i = 0; i < toado.Count; i++)
            {
                string[] xy = toado[i].Trim().Split(' ');
                double x = Convert.ToDouble(xy[0]);
                double y = Convert.ToDouble(xy[1]);
                paintPolyMCSI(x, y, false, obj.ListSearchIDSI1V[i], obj.ListSearchNameSI1V[i].ToString(), "SI1V");
            }
        }
        
        public void paintPoint0TGV()
        {
            List<string> toado = obj.xulyDiem(obj.ListsearchDZPoint0TGV);
            VectorItemsLayer imageLayer0 = new VectorItemsLayer();
            mcSoDo1Soi.Layers.Add(imageLayer0);
            searchDay0TGV = new MapItemStorage();
            var image0 = new Bitmap(@"icon\TBA_TG.png");
            for (int i = 0; i < toado.Count; i++)
            {
                MapCustomElement customElement0 = new MapCustomElement();
                string[] xy = toado[i].Trim().Split(' ');
                double x = Convert.ToDouble(xy[0]);
                double y = Convert.ToDouble(xy[1]);
                customElement0.Location = new GeoPoint(x, y);
                customElement0.ToolTipPattern = obj.ListSearchNameTG0V[i].ToString();
                customElement0.Image = new Bitmap(image0);
                customElement0.ImageIndex = i;
                customElement0.RenderOrigin = new MapPoint(0.5, 1);
                customElement0.Padding = new System.Windows.Forms.Padding(0);
                customElement0.Attributes.Add(new MapItemAttribute { Name = "TG0V", Value = obj.ListSearchIDTG0V[i] });
                searchDay0TGV.Items.Add(customElement0);
            }
            imageLayer0.Data = searchDay0TGV;
        }
        public void paintPoint0TGH()
        {
            List<string> toado = obj.xulyDiem(obj.ListsearchDZPoint0TGH);
            VectorItemsLayer imageLayer0 = new VectorItemsLayer();
            mcSoDo1Soi.Layers.Add(imageLayer0);
            searchDay0TGH = new MapItemStorage();
            var image0 = new Bitmap(@"icon\TBA_TG.png");
            for (int i = 0; i < toado.Count; i++)
            {
                MapCustomElement customElement0 = new MapCustomElement();
                string[] xy = toado[i].Trim().Split(' ');
                double x = Convert.ToDouble(xy[0]);
                double y = Convert.ToDouble(xy[1]);
                customElement0.Location = new GeoPoint(x, y);
                customElement0.ToolTipPattern = obj.ListSearchNameTG0H[i].ToString();
                customElement0.Image = new Bitmap(image0);
                customElement0.ImageIndex = i;
                customElement0.RenderOrigin = new MapPoint(0.5, 1);
                customElement0.Padding = new System.Windows.Forms.Padding(0);
                customElement0.Attributes.Add(new MapItemAttribute { Name = "TG0H", Value = obj.ListSearchIDTG1H[i] });
                searchDay0TGH.Items.Add(customElement0);
            }
            imageLayer0.Data = searchDay0TGH;
        }
        public void paintPoint1TGV()
        {
            List<string> toado = obj.xulyDiem(obj.ListsearchDZPoint1TGV);
            VectorItemsLayer imageLayer0 = new VectorItemsLayer();
            mcSoDo1Soi.Layers.Add(imageLayer0);
            searchDay1TGV = new MapItemStorage();
            var image0 = new Bitmap(@"icon\TBA_TG_ON.png");
            for (int i = 0; i < toado.Count; i++)
            {
                MapCustomElement customElement0 = new MapCustomElement();
                string[] xy = toado[i].Trim().Split(' ');
                double x = Convert.ToDouble(xy[0]);
                double y = Convert.ToDouble(xy[1]);
                customElement0.Location = new GeoPoint(x, y);
                customElement0.ToolTipPattern = obj.ListSearchNameTG1V[i].ToString();
                customElement0.Image = new Bitmap(image0);
                customElement0.ImageIndex = i;
                customElement0.RenderOrigin = new MapPoint(0.5, 1);
                customElement0.Padding = new System.Windows.Forms.Padding(0);
                customElement0.Attributes.Add(new MapItemAttribute { Name = "TG1V", Value = obj.ListSearchIDTG1V[i] });
                searchDay1TGV.Items.Add(customElement0);
            }
            imageLayer0.Data = searchDay1TGV;
        }
        public void paintPoint1TGH()
        {
            List<string> toado = obj.xulyDiem(obj.ListsearchDZPoint1TGH);
            VectorItemsLayer imageLayer0 = new VectorItemsLayer();
            mcSoDo1Soi.Layers.Add(imageLayer0);
            searchDay1TGH = new MapItemStorage();
            var image0 = new Bitmap(@"icon\TBA_TG_ON.png");
            for (int i = 0; i < toado.Count; i++)
            {
                MapCustomElement customElement0 = new MapCustomElement();
                string[] xy = toado[i].Trim().Split(' ');
                double x = Convert.ToDouble(xy[0]);
                double y = Convert.ToDouble(xy[1]);
                customElement0.Location = new GeoPoint(x, y);
                customElement0.ToolTipPattern = obj.ListSearchNameTG1H[i].ToString();
                customElement0.Image = new Bitmap(image0);
                customElement0.ImageIndex = i;
                customElement0.RenderOrigin = new MapPoint(0.5, 1);
                customElement0.Padding = new System.Windows.Forms.Padding(0);
                customElement0.Attributes.Add(new MapItemAttribute { Name = "TG1H", Value = obj.ListSearchIDTG1H[i] });
                searchDay1TGH.Items.Add(customElement0);
            }
            imageLayer0.Data = searchDay1TGH;
        }
        public void paintPoint0MCV()
        {
            List<string> toado = obj.xulyDiem(obj.ListsearchDZPoint0MCV);
            for (int i = 0; i < toado.Count; i++)
            {
                string[] xy = toado[i].Trim().Split(' ');
                double x = Convert.ToDouble(xy[0]);
                double y = Convert.ToDouble(xy[1]);
                paintPolyMC(x, y, true, false, true, obj.ListSearchIDMC0V[i], obj.ListSearchNameMC0V[i].ToString());
            }
        }
        public void paintPoint0TBAV()
        {
            List<string> toado = obj.xulyDiem(obj.ListSearchDZPoint0TBAV);
            for (int i = 0; i < toado.Count; i++)
            {
                string[] xy = toado[i].Trim().Split(' ');
                double x = Convert.ToDouble(xy[0]);
                double y = Convert.ToDouble(xy[1]);
                paintPolyTBA(x, y - 0.0000250, false, obj.ListSearchIDTBA0V[i], obj.ListSearchNameTBA0V[i]);
            }
        }
        public void paintPoint1TBAV()
        {
            List<string> toado = obj.xulyDiem(obj.ListSearchDZPoint1TBAV);
            /*VectorItemsLayer imageLayer0 = new VectorItemsLayer();
            mcSoDo1Soi.Layers.Add(imageLayer0);
            searchDay1TBA = new MapItemStorage();*/

            for (int i = 0; i < toado.Count; i++)
            {
                string[] xy = toado[i].Trim().Split(' ');
                double x = Convert.ToDouble(xy[0]);
                double y = Convert.ToDouble(xy[1]);
                paintPolyTBA(x, y - 0.0000250, true,  obj.ListSearchIDTBA1V[i], obj.ListSearchNameTBA1V[i]);
            }
            /*for (int i = 0; i < toado.Count; i++) ve hinh tron 
            {

                MapEllipse polyline = new MapEllipse();
                string[] xy = toado[i].Trim().Split(' ');
                double x = Convert.ToDouble(xy[0]);
                double y = Convert.ToDouble(xy[1]);
                polyline.Location = new GeoPoint(x, y);
                polyline.Width = 0.00000025D;
                polyline.Height = 0.00000025D;

                polyline.Stroke = Color.Yellow;
                polyline.Fill = Color.White;
                polyline.HighlightedFill = Color.Green;
                polyline.SelectedFill = Color.Blue;
                polyline.StrokeWidth = 10;
                searchDay1TBA.Items.Add(polyline);
            }*/
            //imageLayer0.Data = searchDay1TBA;
        }
        public class LocalProvider : MapDataProviderBase
        {

            readonly SphericalMercatorProjection projection = new SphericalMercatorProjection();

            public LocalProvider()
            {
                this.CacheOptions.DiskFolder = @"Maps";
                TileSource = new LocalTileSource(this);
            }

            public override ProjectionBase Projection
            {
                get
                {
                    return projection;
                }
            }

            public override MapSize GetMapSizeInPixels(double zoomLevel)
            {
                double imageSize;
                imageSize = LocalTileSource.CalculateTotalImageSize(zoomLevel);
                return new MapSize(imageSize, imageSize);
            }
            protected override Size BaseSizeInPixels
            {
                get { return new Size(Convert.ToInt32(LocalTileSource.tileSize * 2), Convert.ToInt32(LocalTileSource.tileSize * 2)); }
            }
        }
        public class LocalTileSource : MapTileSourceBase
        {
            public const int tileSize = 256;
            public const int maxZoomLevel = 2;

            internal static double CalculateTotalImageSize(double zoomLevel)
            {
                if (zoomLevel < 1.0)
                    return zoomLevel * tileSize * 2;
                return Math.Pow(2.0, zoomLevel) * tileSize;
            }

            public LocalTileSource(ICacheOptionsProvider cacheOptionsProvider) :
                base((int)CalculateTotalImageSize(maxZoomLevel), (int)CalculateTotalImageSize(maxZoomLevel), tileSize, tileSize, cacheOptionsProvider)
            {
                //DirectoryInfo dir = new DirectoryInfo(Directory.GetCurrentDirectory());
                //directoryPath = dir.Parent.Parent.FullName; 

            }

            public override Uri GetTileByZoomLevel(int zoomLevel, int tilePositionX, int tilePositionY)
            {

                return null;
            }
        }
    }
}
