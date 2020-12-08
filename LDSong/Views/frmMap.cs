using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraMap;
using System.Threading;
using LDSong.Controlers;
using LDSong.Libs;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using LDSong.Models;
using System.Drawing.Imaging;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using System.IO;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraCharts;
using SpeechLib;

namespace LDSong.Views
{
    public partial class frmMap : DevExpress.XtraEditors.XtraForm
    {
        DevExpress.XtraMap.ImageTilesLayer imageTilesLayer1;
        private int t, nutload = 0, ngay = 0, gio = 0, phut = 0, giay = 0, dem = 0, IDCD;
        private double khoangcach;
        MapPolyline Pline;
        toadoControler objToado;
        private MAPControler ObjCtl;
        DevExpress.XtraMap.BingMapDataProvider bingMapDataProvider1;
        MapItemStorage searchDay0CD, searchDay1CD, searchDay0TT, searchDay1TT, searchDay0MC, searchDay1MC, searchDay0TG, searchDay1TG, searchDay0SI, searchDay1SI, searchDay0MCDZ, searchDay1MCDZ, searchDay22, searchDay35, itemstorePolie, searchDayWarning;
        MapItemStorage ItemStorage10;
        MapItemStorage ItemStorage110;
        MapItemStorage ItemStorageWarning, paintMap,paintMapTemp;
        V_M_Vitri1 objWarning;
        private string DVQuanLy = "",_dvql,username,loai,dz22="",dz35="",toadoLine="";
        public string loaiTB = "",tenCD;
        private int tinh = 0, elementAt = 0, idPTDien, idLR, idN,TL=2;
        private double getX, getY;
        static object syncObj = new object();
        private SqlConnection connection=null;
        private SqlCommand command=null;
        private DataSet myDataSet = null;
        private SpVoice voice;
        private bool sttVoice = true, initVoice=false,qhe=false,mnTt,mnQh,_btDetailTBA=false,_btXoaAnh=false;
        private List<string> lstTD,lstDVQL;
        private List<D_QHE_PTDIEN_VITRI> lstQH;
        Graphics g;
        Bitmap bmp, bmp1;

        public frmMap()
        {
            InitializeComponent();
            initMap();
            initComboboxDonvi();
            mctSoDo.MapItemClick += mapControl1_MapItemClick; 
        }
        public frmMap(string DVQLY,string username,string loai) {
            this.DVQuanLy = DVQLY;
            this._dvql = DVQLY;
            this.username = username;
            this.loai = loai;
            objWarning = new V_M_Vitri1();
            InitializeComponent();
            objToado = new toadoControler();
            LDSFunction Fn = new LDSFunction();
            List<string> menus = Fn.getMenuByUser("cmd", 3);
            foreach (string item in menus)
            {
                if (item.Contains('_'))
                {
                    if (item.Contains("cmd_CapNhatTSTBA"))
                    {
                        _btDetailTBA = true;
                    }
                    else
                    {
                        if (item.Contains("cmd_XoaAnh"))
                        {
                            _btXoaAnh = true;
                        }
                    }
                }
                else
                {
                    ToolStripMenuItem ctl = this.contextMenuStrip1.Items.Find(item, true).FirstOrDefault() as ToolStripMenuItem;
                    ctl.Enabled = true;
                }
            }
            mnTt = cmdCapNhatTrangThai.Enabled;
            mnQh = cmdThietLapQH.Enabled;
            initMap();
            panelButton.Visible = false;
            initComboboxDonvi();
            if (loai.Equals("0"))
            {
                checkBoxPTD.Visible = true;
                checkBoxRefresh.Visible = true;
            }
            else
            {
                checkBoxPTD.Visible = false;
                checkBoxRefresh.Visible = false;
            }
            labelKH.Text = "";
            labelSumtime.Text = "";
            itemstorePolie = new MapItemStorage();
            mctSoDo.MapItemClick += mapControl1_MapItemClick;
            mctSoDo.MouseDoubleClick += MapControl_MouseDoubleClick; 
            mctSoDo.MouseMove += mapControl1;
            mctSoDo.MouseClick += mapControl2;
            DisposeVH();
            if (EnoughPermission()) autoData();
            if (!loai.Equals("0"))
            {
                checkBoxPTD.Visible = false;
            }
            List<D_CAP_DAP> tam = objToado.listCap();
            chk22kV.Text = tam.ElementAt(1).TEN_CAPDA;
            chk35kV.Text = tam.ElementAt(2).TEN_CAPDA;
            loadCale();
        }
        private void loadCale()
        {
            DateBegin.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            DateBegin.Properties.Mask.EditMask = "HH:mm:ss,dd-MM-yyyy";
            DateBegin.Properties.Mask.UseMaskAsDisplayFormat = true;
            DateBegin.Properties.CharacterCasing = CharacterCasing.Upper;
            DateEnd.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
            DateEnd.Properties.Mask.EditMask = "HH:mm:ss,dd-MM-yyyy";
            DateEnd.Properties.Mask.UseMaskAsDisplayFormat = true;
            DateEnd.Properties.CharacterCasing = CharacterCasing.Upper;
        }
        private void mapControl2(object sender, MouseEventArgs e)
        {
            panelButton.Visible = false;
        }

        private void startRead(int StreamNumber, object StreamPosition)
        {
            sttVoice = false;
        }

        private void endRead(int StreamNumber, object StreamPosition)
        {
            sttVoice = true;
        }
        public void setVoice()
        {
            voice.Rate = LDSong.Properties.Settings.Default.rate;
            voice.Volume = LDSong.Properties.Settings.Default.volume;
        }
        private void MapControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            dungXetQH();
            if (loai.Equals("0") && btVM.Text.Equals("Chạy giả lập") && checkBoxNotice.Checked==false)
            {
                int i = 0;
                toadoLine="";
                GeoPoint Ga = null, Gb = null;
                double k1 = 0, k2 = 0; khoangcach = 0;
                VectorItemsLayer VectorLayer = new VectorItemsLayer();
                mctSoDo.Layers.Add(VectorLayer);
                if (itemstorePolie.Items.Contains(Pline))
                {
                    itemstorePolie.Items.Remove(Pline);
                }
                Pline = new MapPolyline();
                Pline.StrokeWidth = 3;
                Pline.Stroke = Color.Yellow;
                MapPoint MyPoint = new DevExpress.XtraMap.MapPoint(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y);
                GeoPoint GP = VectorLayer.ScreenPointToGeoPoint(MyPoint); 
                MapPushpin Pin = new MapPushpin();
                Pin.Location = GP;
                Pin.ToolTipPattern = GP.GetY().ToString()+" "+GP.GetX().ToString();
                itemstorePolie.Items.Add(Pin);
                VectorLayer.Data = itemstorePolie;
                foreach (MapPushpin mp in itemstorePolie.Items)
                {
                    string[] td = mp.Location.ToString().Split(',');
                    double x = double.Parse(td[0]);
                    double y = double.Parse(td[1]);
                    Pline.Points.Add(mp.Location);
                    if (i == 0)
                    {
                        Ga = new GeoPoint(x, y);
                        toadoLine =  x + " " + y;
                    }
                    if (i == 1)
                    {
                        Gb = new GeoPoint(x, y);
                        k1 = GeoMath.GetEquirectangularDistance(Ga, Gb);
                        Ga = Gb;
                        toadoLine = toadoLine + "," + x + " " + y;
                    }
                    if (i != 0 && i != 1)
                    {
                        Gb = new GeoPoint(x, y);
                        k2 = GeoMath.GetEquirectangularDistance(Ga, Gb);
                        khoangcach = khoangcach + k2;
                        Ga = Gb;
                        toadoLine = toadoLine + "," + x + " " + y;
                    }
                    i++;
                }
                Pline.Attributes.Add(new MapItemAttribute { Name = "CreateLine" });
                khoangcach = k1 + khoangcach;
                itemstorePolie.Items.Add(Pline);
                VectorLayer.Data = itemstorePolie;
                btTinhPin.Visible = true;
                btXoaPin1.Visible = true;
                timer1.Enabled = true;
                delay_ms(500);
                timer1.Enabled = false;
            }
            if (checkBoxNotice.Checked)
            {
                int i = 0;
                toadoLine="";
                GeoPoint Ga = null, Gb = null; khoangcach = 0;
                VectorItemsLayer VectorLayer = new VectorItemsLayer();
                mctSoDo.Layers.Add(VectorLayer);
                if (itemstorePolie.Items.Contains(Pline))
                {
                    itemstorePolie.Items.Remove(Pline);
                }
                Pline = new MapPolyline();
                Pline.StrokeWidth = 3;
                Pline.Stroke = Color.Yellow;
                MapPoint MyPoint = new DevExpress.XtraMap.MapPoint(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y);
                GeoPoint GP = VectorLayer.ScreenPointToGeoPoint(MyPoint); 
                MapPushpin Pin = new MapPushpin();
                Pin.Location = GP;
                Pin.ToolTipPattern = GP.GetY().ToString()+" "+GP.GetX().ToString();
                itemstorePolie.Items.Add(Pin);
                VectorLayer.Data = itemstorePolie;

                VectorItemsLayer imageLayer0 = new VectorItemsLayer();
                mctSoDo.Layers.Add(imageLayer0);
                var polygon = new MapPolygon();
                paintMapTemp = new MapItemStorage();
                foreach (MapPushpin mp in itemstorePolie.Items)
                {
                    string[] td = mp.Location.ToString().Split(',');
                    double x = double.Parse(td[0]);
                    double y = double.Parse(td[1]);
                    Pline.Points.Add(mp.Location);
                    if (i == 0)
                    {
                        Ga = new GeoPoint(x, y);
                        toadoLine =  x + " " + y;
                    }
                    if (i == 1)
                    {
                        Gb = new GeoPoint(x, y);
                        Ga = Gb;
                        toadoLine = toadoLine + "," + x + " " + y;
                    }
                    if (i != 0 && i != 1)
                    {
                        Gb = new GeoPoint(x, y);
                        Ga = Gb;
                        toadoLine = toadoLine + "," + x + " " + y;
                    }
                    polygon.Points.AddRange(new GeoPoint[] {new GeoPoint(x,y)});
                    polygon.Attributes.Add(new MapItemAttribute { Name = "CreateNotice", Value = 0 });
                    polygon.Fill = Color.Red;
                    polygon.HighlightedStroke = Color.Red;
                    paintMapTemp.Items.Add(polygon);
                    imageLayer0.Data = paintMapTemp;
                    i++;
                }
                Pline.Attributes.Add(new MapItemAttribute { Name = "CreateLine" });
                itemstorePolie.Items.Add(Pline);
                VectorLayer.Data = itemstorePolie;
                btXoaPin1.Visible = true;
                timer1.Enabled = true;
                delay_ms(500);
                timer1.Enabled = false;
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
        public void autoData() {
            string ssql;
            command = null;
            string connstr = LDSong.Properties.Settings.Default.connect;
            if (btVM.Text.Equals("Chạy giả lập"))
            {
                if (DVQuanLy!="PN")
                {
                    ssql = "select TRANG_THAI from dbo.M_TTHAI_PTDIEN where MA_DVQLY='" + DVQuanLy + "';";
                }
                else
                {
                    ssql = "select TRANG_THAI from dbo.M_TTHAI_PTDIEN ;";
                }
            }
            else
            {
                if (DVQuanLy != "PN")
                {
                    ssql = "select TRANG_THAI from dbo.M_TTHAI_PTDIEN_VM where MA_DVQLY='" + DVQuanLy + "';";
                }
                else
                {
                    ssql = "select TRANG_THAI from dbo.M_TTHAI_PTDIEN_VM ;";
                }
            }
            SqlDependency.Stop(connstr);
            SqlDependency.Start(connstr);
            if (connection == null)
                connection = new SqlConnection(connstr);
            if (command == null)
                command = new SqlCommand(ssql, connection);
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
            if (checkBoxRefresh.Checked==false)
            {
                huydoituongSearchday();
                paintSearchDuongday();
                initTbDSMatdien();
            }
            GetAdvtData();
        }
        public void DisposeVH()
        {
            // Unregister the notification subscription for the current instance.
            SqlDependency.Stop(LDSong.Properties.Settings.Default.connect);
        }
        private void mapControl1(object sender, MouseEventArgs e)
        {
            if (rdDocPTD.Checked)
            {
                var a = mctSoDo.CalcHitInfo(e.Location);
                if (a.MapCustomElement!=null)
                {
                    //a.MapCustomElement.Fill = Color.Transparent;
                    //a.MapCustomElement.RenderOrigin = new MapPoint(0.8,0.8);
                    //MessageBox.Show(a.MapCustomElement.RenderOrigin.ToString());
                    //a.MapCustomElement.Fill
                    if (sttVoice)
                    {
                        try
                        {
                            sttVoice = false;
                            voice.Speak("<speak version='1.0' xmlns='http://www.w3.org/2001/10/synthesis' xml:lang='vi-VN' gender='female'>" + xulychuoi(a.MapCustomElement.ToolTipPattern) + "</speak>", SpeechVoiceSpeakFlags.SVSFlagsAsync | SpeechVoiceSpeakFlags.SVSFIsXML);
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
            }
        }

        
        private void mapControl1_MapItemClick1(object sender, MapItemEventArgs e)
        {
            ((MapCustomElement)e.Item).AllowHtmlText = false;
        }
        public void initMap() {
            this.mctSoDo.Cursor = Cursors.WaitCursor;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMap));
            imageTilesLayer1 = new DevExpress.XtraMap.ImageTilesLayer();
            this.mctSoDo.CenterPoint = new DevExpress.XtraMap.GeoPoint(20.250567D, 105.974863D);
            this.mctSoDo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mctSoDo.Layers.Add(imageTilesLayer1);
            this.mctSoDo.Location = new System.Drawing.Point(0, 0);
            this.mctSoDo.Name = "mctSoDo";
            this.mctSoDo.Size = new System.Drawing.Size(540, 457);
            this.mctSoDo.TabIndex = 1;
            this.mctSoDo.ZoomLevel = 13D;
            OpenStreetMapDataProvider provider = new OpenStreetMapDataProvider();
            provider.CacheOptions.DiskFolder = @"Maps";
            imageTilesLayer1.DataProvider = provider;
            simpleButton2.Enabled = false;
            simpleButton3.Enabled = false;
            simpleButton4.Enabled = false;
            this.mctSoDo.Cursor = Cursors.Hand;
        }
        public  bool checkConnection()
        {
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                NetworkInterface[] interfaces = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces();
                return (from face in interfaces where face.OperationalStatus == OperationalStatus.Up where (face.NetworkInterfaceType != NetworkInterfaceType.Tunnel) && (face.NetworkInterfaceType != NetworkInterfaceType.Loopback) select face.GetIPv4Statistics()).Any(statistics => (statistics.BytesReceived > 0) && (statistics.BytesSent > 0));
            }
            return false;
        }
        public bool checkSpeedInternet() {
            getSpeedInternet();
            // only recognizes changes related to Internet adapters
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                // however, this will include all adapters -- filter by opstatus and activity
                NetworkInterface[] interfaces = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces();
                return (from face in interfaces
                        where face.OperationalStatus == OperationalStatus.Up
                        where (face.NetworkInterfaceType != NetworkInterfaceType.Tunnel) && (face.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                        select face.GetIPv4Statistics()).Any(statistics => (statistics.BytesReceived >0) && (statistics.BytesSent > 0));
            }

            return false;
        
        }
        public long getSpeedInternet() {
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
            long bytesReceived = 0;
            foreach (NetworkInterface inf in interfaces)
            {
                if (inf.OperationalStatus == OperationalStatus.Up &&
                    inf.NetworkInterfaceType != NetworkInterfaceType.Loopback &&
                    inf.NetworkInterfaceType != NetworkInterfaceType.Tunnel &&
                    inf.NetworkInterfaceType != NetworkInterfaceType.Unknown && !inf.IsReceiveOnly)
                {
                    bytesReceived += inf.GetIPv4Statistics().BytesReceived;
                }
            }
            return bytesReceived;
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
            string directoryPath;

            internal static double CalculateTotalImageSize(double zoomLevel)
            {
                if (zoomLevel < 1.0)
                    return zoomLevel * tileSize * 2;
                return Math.Pow(2.0, zoomLevel) * tileSize;
            }

            public LocalTileSource(ICacheOptionsProvider cacheOptionsProvider) :
                base((int)CalculateTotalImageSize(maxZoomLevel), (int)CalculateTotalImageSize(maxZoomLevel), tileSize, tileSize, cacheOptionsProvider)
            {
                DirectoryInfo dir = new DirectoryInfo(Directory.GetCurrentDirectory());
                directoryPath = dir.Parent.Parent.FullName; 
                
            }

            public override Uri GetTileByZoomLevel(int zoomLevel, int tilePositionX, int tilePositionY)
            {
                if (zoomLevel <= maxZoomLevel)
                {
                    Uri u = new  Uri(string.Format("file://" + directoryPath + "Maps\\dxcache.map", zoomLevel, tilePositionX, tilePositionY));
                    return u;
                }
                return null;
            }
        }
        public void daluong() { 
            ThreadStart ts1 = new ThreadStart(paintLine10);
            //ThreadStart ts2 = new ThreadStart(paintLine110);  Dung ItemStorage110  nay cho tinh nang khac ^^ tan dung tai nguyen
            Thread tA = new Thread(ts1);
            //Thread tB = new Thread(ts2);
            tA.Priority = ThreadPriority.Highest;
            //tB.Priority = ThreadPriority.Highest;
            tA.Start();
            //tB.Start();
            tA.Join();
            //tB.Join();
            }
        
        // viet code tam thoi cho nay
        public void initComboboxDonvi() {
            //toadoControler td = new toadoControler();
            lstTD = new List<string>();
            lstDVQL = new List<string>();
            foreach (var d in objToado.loadComboDonvi(DVQuanLy))
            {
                if (objToado.loadComboDonvi(DVQuanLy).Count == 1)
                {
                    cboDonVi.EditValue = d.TEN_DVIQLY.ToString();
                    setXY();
                    this.mctSoDo.CenterPoint = new GeoPoint(getX,getY);
                    cmdTimPT.Enabled = true;
                    chk22kV.Enabled = true;
                    chk35kV.Enabled = true;
                    btXemNhanh.Enabled = true;
                    //daluong();
                    initTbDSMatdien();
                }
                else
                {
                    cboDonVi.Properties.Items.Add(d.TEN_DVIQLY.ToString());
                    lstTD.Add(d.TOA_DO);
                    lstDVQL.Add(d.MA_DVIQLY);
                }
            }
            
        }
        public void initTbDSMatdien() {
            toadoControler1 td1 = new toadoControler1();
            lbMatdien.Visible = true;
            labelCountDCOpen.Visible = true;
            labelKH.Text = " ";
            labelSumtime.Text = " ";
            if (btVM.Text.Equals("Chạy giả lập"))
            {
                gridDSTmatdien.DataSource = td1.getListTramMatDien(DVQuanLy);
                gridDSDao.DataSource = td1.listCDOpen(DVQuanLy);
            }
            else
            {
                gridDSTmatdien.DataSource = td1.getListTramMatDien_VM(DVQuanLy);
                gridDSDao.DataSource = td1.listCDOpen_VM(DVQuanLy);
            }
            if (DSTmatdien.DataRowCount == 0 )
            {
                lbMatdien.Text = "Số trạm mất điện : 0";
                gridThongTinTram.DataSource = null ;
                timeSumMatDien.Enabled = false;
                timerChangeChose.Enabled = false;
                simpleButton6.Enabled = false;
            }
            else
            {
                lbMatdien.Text = "Số trạm mất điện : " + DSTmatdien.DataRowCount;
                DSTmatdien.FocusedRowHandle = 1;
                if (DSTmatdien.DataRowCount>1)
                {
                    timerChangeChose.Enabled = true;
                    simpleButton6.Enabled = true;
                    dem = 0;
                    timerChangeChose.Interval = 5000;
                }
                else
                {
                    gridDSTmatdien.DataSource = null;
                    if (btVM.Text.Equals("Chạy giả lập"))
                    {
                        gridDSTmatdien.DataSource = td1.getListTramMatDien(DVQuanLy);
                    }
                    else
                    {
                        gridDSTmatdien.DataSource = td1.getListTramMatDien_VM(DVQuanLy);
                    }
                    simpleButton6.Enabled = false;
                }
                simpleButton5.Enabled = false;
            }
            if (DSDao.DataRowCount==0)
            {
                labelCountDCOpen.Text = "Số dao cách ly mờ : 0";
            }
            else
            {
                labelCountDCOpen.Text = "Số dao cách ly mờ : " + DSDao.DataRowCount;
            }
            if (timerChangeChose.Enabled == false)
            {
                simpleButton6.Text = "Tiếp tục";
            }
            else
            {
                simpleButton6.Text = "Tạm dừng";
            }
            if (btVM.Text.Equals("Chạy giả lập"))
            {
                //initBieuDo();
            }
        }
        public void xltd(int index) {
            try
            {
                string td = lstTD.ElementAt(index);
                string[] xl = td.Split(' ');
                getX = double.Parse(xl[0]); getY = double.Parse(xl[1]);
            }
            catch (Exception)
            {
                getX = 20.250567D; getY = 105.974863D;
            }
        }
        public void setXY()
        {
            try
            {
                string td = objToado.getToaDo(this.DVQuanLy).Trim();
                string[] xl = td.Split(' ');
                getX = double.Parse(xl[0]); getY = double.Parse(xl[1]);
            }
            catch (Exception)
            {
                getX = 20.250567D; getY = 105.974863D;
            }
            
        }
        
        // canh bao mat dien
        public void paintPointWarning()
        {
            List<string> toado = objToado.xulyDiem(objWarning.ListWarning);
            VectorItemsLayer imageLayer0 = new VectorItemsLayer();
            mctSoDo.Layers.Add(imageLayer0);
            ItemStorageWarning = new MapItemStorage();
            //var image0 = new Bitmap(@"..//..//icon//icon-warning.png");
            var image0 = new Bitmap(@"icon//icon-warning.png");
            for (int i = 0; i < toado.Count; i++)
            {
                MapCustomElement customElement0 = new MapCustomElement();
                string[] xy = toado[i].Trim().Split(' ');
                double x = Convert.ToDouble(xy[0]); 
                double y = Convert.ToDouble(xy[1]);
                customElement0.Location = new GeoPoint(x, y);
                customElement0.Image = new Bitmap(image0);
                customElement0.RenderOrigin = new MapPoint(0.5, 1);
                customElement0.Padding = new System.Windows.Forms.Padding(0);
                ItemStorageWarning.Items.Add(customElement0);
            }
            imageLayer0.Data = ItemStorageWarning;
        }
        public void paintPointLS0()
        {
            List<string> toado = objToado.xulyDiem(objToado.listLS0);
            VectorItemsLayer imageLayer0 = new VectorItemsLayer();
            mctSoDo.Layers.Add(imageLayer0);
            ItemStorageWarning = new MapItemStorage();
            //var image0 = new Bitmap(@"..//..//icon//icon-warning.png");
            var image0 = new Bitmap(@"icon//Green_LS.png");
            for (int i = 0; i < toado.Count; i++)
            {
                MapCustomElement customElement0 = new MapCustomElement();
                string[] xy = toado[i].Trim().Split(' ');
                double x = Convert.ToDouble(xy[0]);
                double y = Convert.ToDouble(xy[1]);
                customElement0.Location = new GeoPoint(x, y);
                customElement0.Image = new Bitmap(image0);
                customElement0.RenderOrigin = new MapPoint(0.5, 1);
                customElement0.Padding = new System.Windows.Forms.Padding(0);
                ItemStorageWarning.Items.Add(customElement0);
            }
            imageLayer0.Data = ItemStorageWarning;
        }
        public void paintPointLS1()
        {
            List<string> toado = objToado.xulyDiem(objToado.listLS1);
            VectorItemsLayer imageLayer0 = new VectorItemsLayer();
            mctSoDo.Layers.Add(imageLayer0);
            ItemStorageWarning = new MapItemStorage();
            //var image0 = new Bitmap(@"..//..//icon//icon-warning.png");
            var image0 = new Bitmap(@"icon//Red_LS.png");
            for (int i = 0; i < toado.Count; i++)
            {
                MapCustomElement customElement0 = new MapCustomElement();
                string[] xy = toado[i].Trim().Split(' ');
                double x = Convert.ToDouble(xy[0]);
                double y = Convert.ToDouble(xy[1]);
                customElement0.Location = new GeoPoint(x, y);
                customElement0.Image = new Bitmap(image0);
                customElement0.RenderOrigin = new MapPoint(0.5, 1);
                customElement0.Padding = new System.Windows.Forms.Padding(0);
                ItemStorageWarning.Items.Add(customElement0);
            }
            imageLayer0.Data = ItemStorageWarning;
        }
        // code line 10
        public void paintLine10()
        {
            double xTam = 0, yTam = 0;
            double xj = 0, yj = 0;
            List<string> toado = objToado.xulyLine(objToado.getLine("03",DVQuanLy));
            VectorItemsLayer itemsLayer = new VectorItemsLayer();
            mctSoDo.Layers.Add(itemsLayer);
            ItemStorage10 = new MapItemStorage();
            for (int i = 0; i < toado.Count; i++)
            {
                string[] xline = toado[i].Split(',');
                for (int j = 0; j < xline.Count(); j++)
                {
                    MapLine mline = new MapLine();
                    mline.Stroke = Color.CadetBlue;
                    mline.StrokeWidth = 1;
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
                    ItemStorage10.Items.Add(mline);
                }


            }
            itemsLayer.Data = ItemStorage10;
        }
        
        // code line 110
        public void paintLine110()
        {
            double xTam = 0, yTam = 0;
            double xj = 0, yj = 0;
            List<string> toado = objToado.xulyLine(objToado.getLine("08", DVQuanLy)); 
            VectorItemsLayer itemsLayer = new VectorItemsLayer();
            mctSoDo.Layers.Add(itemsLayer);
            ItemStorage110 = new MapItemStorage();
            for (int i = 0; i < toado.Count; i++)
            {

                string[] xline = toado[i].Split(',');
                for (int j = 0; j < xline.Count(); j++)
                {
                    MapLine mline = new MapLine();
                    mline.Stroke = Color.Yellow;
                    mline.StrokeWidth = 1;
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
                    ItemStorage110.Items.Add(mline);
                }


            }
            itemsLayer.Data = ItemStorage110;
            
        }
        public void paintNotice() {
            VectorItemsLayer imageLayer0 = new VectorItemsLayer();
            mctSoDo.Layers.Add(imageLayer0);
            var polygon = new MapPolygon();
            paintMap = new MapItemStorage();
            List<string> toado = objToado.xulyLine(objToado.listtoadoN);
            for (int j = 0; j < toado.Count(); j++)
            {
                string[] xline = toado[j].Split(',');
                for (int i = 0; i < xline.Count(); i++)
                {
                    string[] xy = xline[i].Trim().Split(' ');
                    double x = Convert.ToDouble(xy[0]);
                    double y = Convert.ToDouble(xy[1]);
                    polygon.Points.AddRange(new GeoPoint[] {new GeoPoint(x,y)});
                }
                polygon.Attributes.Add(new MapItemAttribute { Name = objToado.ListNameN[j], Value = objToado.ListIDN[j] });
                if (objToado.ListColorBGN[j].Equals("Đỏ"))
                {
                    polygon.Fill = Color.Red;
                }
                else
                {
                    if (objToado.ListColorBGN[j].Equals("Vàng"))
                    {
                        polygon.Fill = Color.Gold;
                    }
                    else
                    {
                        if (objToado.ListColorBGN[j].Equals("Xanh"))
                        {
                            polygon.Fill = Color.Blue;
                        }
                        else
                        {
                            polygon.Fill = Color.Black;
                        }
                    }
                }
                polygon.HighlightedStroke = Color.Red;
                polygon.ToolTipPattern = objToado.ListNameN[j];
                paintMap.Items.Add(polygon);
            }
            imageLayer0.Data = paintMap;
        }
        public void paintLine22() {
            double xTam = 0, yTam = 0;
            double xj = 0, yj = 0;
            List<string> toado = objToado.xulyLine(objToado.ListsearchDZLine22);
            VectorItemsLayer itemsLayer = new VectorItemsLayer();
            mctSoDo.Layers.Add(itemsLayer);
            searchDay22 = new MapItemStorage();
            for (int i = 0; i < toado.Count; i++)
            {

                string[] xline = toado[i].Split(',');
                for (int j = 0; j < xline.Count(); j++)
                {
                    MapLine mline = new MapLine();
                    mline.Stroke = Color.Blue;
                    mline.StrokeWidth = 3;
                    mline.ToolTipPattern = objToado.ListSearchNameDZ22[i].ToString();
                    mline.Attributes.Add(new MapItemAttribute { Name = "DZ22", Value = objToado.ListIDDZ22[i] });
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

                    searchDay22.Items.Add(mline);
                }
            }
            itemsLayer.Data = searchDay22;
        }
        public void paintLine35() {
            double xTam = 0, yTam = 0;
            double xj = 0, yj = 0;
            List<string> toado = objToado.xulyLine(objToado.ListsearchDZLine35);
            VectorItemsLayer itemsLayer = new VectorItemsLayer();
            mctSoDo.Layers.Add(itemsLayer);
            searchDay35 = new MapItemStorage();
            for (int i = 0; i < toado.Count; i++)
            {

                string[] xline = toado[i].Split(',');
                for (int j = 0; j < xline.Count(); j++)
                {
                    MapLine mline = new MapLine();
                    mline.Stroke = Color.Red;
                    mline.StrokeWidth = 3;
                    mline.ToolTipPattern = objToado.ListSearchNameDZ35[i].ToString();
                    mline.Attributes.Add(new MapItemAttribute { Name = "DZ35", Value = objToado.ListIDDZ35[i] });
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
        public void paintPoint0MCDZ()
        {
            List<string> toado = objToado.xulyDiem(objToado.ListsearchDZPoint0MCDZ);
            VectorItemsLayer imageLayer0 = new VectorItemsLayer();
            mctSoDo.Layers.Add(imageLayer0);
            searchDay0MCDZ = new MapItemStorage();
            //var image0 = new Bitmap(@"..//..//icon//MCDZ_open.png");
            var image0 = new Bitmap(@"icon\MCDZ_open.png");
            for (int i = 0; i < toado.Count; i++)
            {
                MapCustomElement customElement0 = new MapCustomElement();
                string[] xy = toado[i].Trim().Split(' ');
                double x = Convert.ToDouble(xy[0]);
                double y = Convert.ToDouble(xy[1]);
                customElement0.Location = new GeoPoint(x, y);
                customElement0.ToolTipPattern = objToado.ListSearchNameMCDZ0[i].ToString();
                customElement0.Image = new Bitmap(image0);
                customElement0.ImageIndex = i;
                customElement0.RenderOrigin = new MapPoint(0.5, 1);
                customElement0.Padding = new System.Windows.Forms.Padding(0);
                customElement0.Attributes.Add(new MapItemAttribute { Name = "MCDZ0", Value = objToado.ListSearchIDMCDZ0[i] });
                searchDay0MCDZ.Items.Add(customElement0);
            }
            imageLayer0.Data = searchDay0MCDZ;
        }
        public void paintPoint1MCDZ()
        {
            List<string> toado = objToado.xulyDiem(objToado.ListsearchDZPoint1MCDZ);
            VectorItemsLayer imageLayer0 = new VectorItemsLayer();
            mctSoDo.Layers.Add(imageLayer0);
            searchDay1MCDZ = new MapItemStorage();
            //var image0 = new Bitmap(@"..//..//icon//MCDZ_close.png");
            var image0 = new Bitmap(@"icon\MCDZ_close.png");
            for (int i = 0; i < toado.Count; i++)
            {
                MapCustomElement customElement0 = new MapCustomElement();
                string[] xy = toado[i].Trim().Split(' ');
                double x = Convert.ToDouble(xy[0]);
                double y = Convert.ToDouble(xy[1]);
                customElement0.Location = new GeoPoint(x, y);
                customElement0.ToolTipPattern = objToado.ListSearchNameMCDZ1[i].ToString();
                customElement0.Image = new Bitmap(image0);
                customElement0.ImageIndex = i;
                customElement0.RenderOrigin = new MapPoint(0.5, 1);
                customElement0.Padding = new System.Windows.Forms.Padding(0);
                customElement0.Attributes.Add(new MapItemAttribute { Name = "MCDZ1", Value = objToado.ListSearchIDMCDZ1[i] });
                searchDay1MCDZ.Items.Add(customElement0);
            }
            imageLayer0.Data = searchDay1MCDZ;
        }
        public void paintPoint0SI()
        {
            List<string> toado = objToado.xulyDiem(objToado.ListsearchDZPoint0SI);
            VectorItemsLayer imageLayer0 = new VectorItemsLayer();
            mctSoDo.Layers.Add(imageLayer0);
            searchDay0SI = new MapItemStorage();
            //var image0 = new Bitmap(@"..//..//icon//SI_open.png");
            var image0 = new Bitmap(@"icon\SI_open.png");
            for (int i = 0; i < toado.Count; i++)
            {
                MapCustomElement customElement0 = new MapCustomElement();
                string[] xy = toado[i].Trim().Split(' ');
                double x = Convert.ToDouble(xy[0]);
                double y = Convert.ToDouble(xy[1]);
                customElement0.Location = new GeoPoint(x, y);
                customElement0.ToolTipPattern = objToado.ListSearchNameSI0[i].ToString();
                customElement0.Image = new Bitmap(image0);
                customElement0.ImageIndex = i;
                customElement0.RenderOrigin = new MapPoint(0.5, 1);
                customElement0.Padding = new System.Windows.Forms.Padding(0);
                customElement0.Attributes.Add(new MapItemAttribute { Name = "SI0", Value = objToado.ListSearchIDSI0[i] });
                searchDay0SI.Items.Add(customElement0);
            }
            imageLayer0.Data = searchDay0SI;
        }
        public void paintPoint1SI()
        {
            List<string> toado = objToado.xulyDiem(objToado.ListsearchDZPoint1SI);
            VectorItemsLayer imageLayer0 = new VectorItemsLayer();
            mctSoDo.Layers.Add(imageLayer0);
            searchDay1SI = new MapItemStorage();
            //var image0 = new Bitmap(@"..//..//icon//SI_close.png");
            var image0 = new Bitmap(@"icon\SI_close.png");
            for (int i = 0; i < toado.Count; i++)
            {
                MapCustomElement customElement0 = new MapCustomElement();
                string[] xy = toado[i].Trim().Split(' ');
                double x = Convert.ToDouble(xy[0]);
                double y = Convert.ToDouble(xy[1]);
                customElement0.Location = new GeoPoint(x, y);
                customElement0.ToolTipPattern = objToado.ListSearchNameSI1[i].ToString();
                customElement0.Image = new Bitmap(image0);
                customElement0.ImageIndex = i;
                customElement0.RenderOrigin = new MapPoint(0.5, 1);
                customElement0.Padding = new System.Windows.Forms.Padding(0);
                customElement0.Attributes.Add(new MapItemAttribute { Name = "SI1", Value = objToado.ListSearchIDSI1[i] });
                searchDay1SI.Items.Add(customElement0);
            }
            imageLayer0.Data = searchDay1SI;
        }
        public void paintPoint0TG()
        {
            List<string> toado = objToado.xulyDiem(objToado.ListsearchDZPoint0TG);
            VectorItemsLayer imageLayer0 = new VectorItemsLayer();
            mctSoDo.Layers.Add(imageLayer0);
            searchDay0TG = new MapItemStorage();
            //var image0 = new Bitmap(@"..//..//icon//TBA_TG.png");
            var image0 = new Bitmap(@"icon\TBA_TG.png");
            for (int i = 0; i < toado.Count; i++)
            {
                MapCustomElement customElement0 = new MapCustomElement();
                string[] xy = toado[i].Trim().Split(' ');
                double x = Convert.ToDouble(xy[0]);
                double y = Convert.ToDouble(xy[1]);
                customElement0.Location = new GeoPoint(x, y);
                customElement0.ToolTipPattern = objToado.ListSearchNameTG0[i].ToString();
                customElement0.Image = new Bitmap(image0);
                customElement0.ImageIndex = i;
                customElement0.RenderOrigin = new MapPoint(0.5, 1);
                customElement0.Padding = new System.Windows.Forms.Padding(0);
                customElement0.Attributes.Add(new MapItemAttribute { Name = "TG0", Value = objToado.ListSearchIDTG0[i] });
                searchDay0TG.Items.Add(customElement0);
            }
            imageLayer0.Data = searchDay0TG;
        }
        public void paintPoint1TG()
        {
            List<string> toado = objToado.xulyDiem(objToado.ListsearchDZPoint1TG);
            VectorItemsLayer imageLayer0 = new VectorItemsLayer();
            mctSoDo.Layers.Add(imageLayer0);
            searchDay1TG = new MapItemStorage();
            //var image0 = new Bitmap(@"..//..//icon//TBA_TG_ON.png");
            var image0 = new Bitmap(@"icon\TBA_TG_ON.png");
            for (int i = 0; i < toado.Count; i++)
            {
                MapCustomElement customElement0 = new MapCustomElement();
                string[] xy = toado[i].Trim().Split(' ');
                double x = Convert.ToDouble(xy[0]);
                double y = Convert.ToDouble(xy[1]);
                customElement0.Location = new GeoPoint(x, y);
                customElement0.ToolTipPattern = objToado.ListSearchNameTG1[i].ToString();
                customElement0.Image = new Bitmap(image0);
                customElement0.ImageIndex = i;
                customElement0.RenderOrigin = new MapPoint(0.5, 1);
                customElement0.Padding = new System.Windows.Forms.Padding(0);
                customElement0.Attributes.Add(new MapItemAttribute { Name = "TG1", Value = objToado.ListSearchIDTG1[i] });
                searchDay1TG.Items.Add(customElement0);
            }
            imageLayer0.Data = searchDay1TG;
        }
        public void paintPoint0MC()
        {
            List<string> toado = objToado.xulyDiem(objToado.ListsearchDZPoint0MC);
            VectorItemsLayer imageLayer0 = new VectorItemsLayer();
            mctSoDo.Layers.Add(imageLayer0);
            searchDay0MC = new MapItemStorage();
            //var image0 = new Bitmap(@"..//..//icon//MC_on.png");
            var image0 = new Bitmap(@"icon\MC_on.png");
            for (int i = 0; i < toado.Count; i++)
            {
                MapCustomElement customElement0 = new MapCustomElement();
                string[] xy = toado[i].Trim().Split(' ');
                double x = Convert.ToDouble(xy[0]);
                double y = Convert.ToDouble(xy[1]);
                customElement0.Location = new GeoPoint(x, y);
                customElement0.ToolTipPattern = objToado.ListSearchNameMC0[i].ToString();
                customElement0.Image = new Bitmap(image0);
                customElement0.ImageIndex = i;
                customElement0.RenderOrigin = new MapPoint(0.5, 1);
                customElement0.Padding = new System.Windows.Forms.Padding(0);
                customElement0.Attributes.Add(new MapItemAttribute { Name = "CB0", Value = objToado.ListSearchIDMC0[i] });
                searchDay0MC.Items.Add(customElement0);
            }
            imageLayer0.Data = searchDay0MC;
        }
        public void paintPoint1MC()
        {
            List<string> toado = objToado.xulyDiem(objToado.ListsearchDZPoint1MC);
            VectorItemsLayer imageLayer0 = new VectorItemsLayer();
            mctSoDo.Layers.Add(imageLayer0);
            searchDay1MC = new MapItemStorage();
            //var image0 = new Bitmap(@"..//..//icon//MC.png");
            var image0 = new Bitmap(@"icon\MC.png");
            for (int i = 0; i < toado.Count; i++)
            {
                MapCustomElement customElement0 = new MapCustomElement();
                string[] xy = toado[i].Trim().Split(' ');
                double x = Convert.ToDouble(xy[0]);
                double y = Convert.ToDouble(xy[1]);
                customElement0.Location = new GeoPoint(x, y);
                customElement0.ToolTipPattern = objToado.ListSearchNameMC1[i].ToString();
                customElement0.Image = new Bitmap(image0);
                customElement0.ImageIndex = i;
                customElement0.RenderOrigin = new MapPoint(0.5, 1);
                customElement0.Padding = new System.Windows.Forms.Padding(0);
                customElement0.Attributes.Add(new MapItemAttribute { Name = "CB1", Value = objToado.ListSearchIDMC1[i] });
                searchDay1MC.Items.Add(customElement0);
            }
            imageLayer0.Data = searchDay1MC;
        }
        public void paintPoint0CD() {
            List<string> toado = objToado.xulyDiem(objToado.ListsearchDZPoint0CD);
            VectorItemsLayer imageLayer0 = new VectorItemsLayer();
            mctSoDo.Layers.Add(imageLayer0);
            searchDay0CD = new MapItemStorage();
            //var image0 = new Bitmap(@"..//..//icon//CD_on.png");
            var image0 = new Bitmap(@"icon\CD_on.png");
            for (int i = 0; i < toado.Count; i++)
            {
                MapCustomElement customElement0 = new MapCustomElement();
                string[] xy = toado[i].Trim().Split(' ');
                double x = Convert.ToDouble(xy[0]);
                double y = Convert.ToDouble(xy[1]);
                customElement0.Location = new GeoPoint(x, y);
                customElement0.ToolTipPattern = objToado.ListSearchNameCD0[i].ToString();
                if (checkViewTT.Checked && checkViewCD.Checked)
                {
                    customElement0.Text=objToado.ListSearchNameCD0[i].ToString();
                    customElement0.Font = new Font("Tahoma", 8, FontStyle.Bold);
                }
                customElement0.Image = new Bitmap(image0);
                customElement0.ImageIndex = i;
                customElement0.RenderOrigin = new MapPoint(0.5, 1);
                customElement0.Padding = new System.Windows.Forms.Padding(0);
                customElement0.Attributes.Add(new MapItemAttribute {Name="DS0", Value = objToado.ListSearchIDCD0[i] });
                searchDay0CD.Items.Add(customElement0);
            }
            imageLayer0.Data = searchDay0CD;
        }
        public void paintPoint1CD() {
            List<string> toado = objToado.xulyDiem(objToado.ListsearchDZPoint1CD);
            VectorItemsLayer imageLayer0 = new VectorItemsLayer();
            mctSoDo.Layers.Add(imageLayer0);
            searchDay1CD = new MapItemStorage();
            //var image0 = new Bitmap(@"..//..//icon//CD.png");
            var image0 = new Bitmap(@"icon\CD.png");
            for (int i = 0; i < toado.Count; i++)
            {
                MapCustomElement customElement0 = new MapCustomElement();
                string[] xy = toado[i].Trim().Split(' ');
                double x = Convert.ToDouble(xy[0]);
                double y = Convert.ToDouble(xy[1]);
                customElement0.Location = new GeoPoint(x, y);
                customElement0.ToolTipPattern = objToado.ListSearchNameCD1[i].ToString();
                if (checkViewTT.Checked && checkViewCD.Checked)
                {
                    customElement0.Text=objToado.ListSearchNameCD1[i].ToString();
                    customElement0.Font = new Font("Tahoma", 8, FontStyle.Bold);
                }
                customElement0.Image = new Bitmap(image0);
                customElement0.ImageIndex = i;
                customElement0.RenderOrigin = new MapPoint(0.5, 1);
                customElement0.Padding = new System.Windows.Forms.Padding(0);
                customElement0.Attributes.Add(new MapItemAttribute {Name="DS1" ,Value = objToado.ListSearchIDCD1[i] });
                searchDay1CD.Items.Add(customElement0);
            }
            imageLayer0.Data = searchDay1CD;
        }
        public void paintPoint0TT() {
            List<string> toado = objToado.xulyDiem(objToado.ListsearchDZPoint0TT);
            VectorItemsLayer imageLayer0 = new VectorItemsLayer();
            mctSoDo.Layers.Add(imageLayer0);
            searchDay0TT = new MapItemStorage();
            //var image0 = new Bitmap(@"..//..//icon//TBA_PP_open.png");
            var image0 = new Bitmap(@"icon\TBA_PP_open.png");
            for (int i = 0; i < toado.Count; i++)
            {
                MapCustomElement customElement0 = new MapCustomElement();
                string[] xy = toado[i].Trim().Split(' ');
                double x = Convert.ToDouble(xy[0]);
                double y = Convert.ToDouble(xy[1]);
                customElement0.Location = new GeoPoint(x, y);
                customElement0.ToolTipPattern = objToado.ListSearchNameTBA0[i].ToString();
                customElement0.Image = new Bitmap(image0);
                customElement0.ImageIndex = i;
                customElement0.RenderOrigin = new MapPoint(0.5, 1);
                customElement0.Padding = new System.Windows.Forms.Padding(0);
                customElement0.Attributes.Add(new MapItemAttribute {Name="TT0", Value = objToado.ListSearchIDTBA0[i] });
                searchDay0TT.Items.Add(customElement0);
            }
            imageLayer0.Data = searchDay0TT;
        }
        public void paintPoint1TT() {
            List<string> toado = objToado.xulyDiem(objToado.ListsearchDZPoint1TT);
            VectorItemsLayer imageLayer0 = new VectorItemsLayer();
            mctSoDo.Layers.Add(imageLayer0);
            searchDay1TT = new MapItemStorage();
            //var image0 = new Bitmap(@"..//..//icon//TBA_PP.png");
            var image0 = new Bitmap(@"icon\TBA_PP.png");
            for (int i = 0; i < toado.Count; i++)
            {
                MapCustomElement customElement0 = new MapCustomElement();
                string[] xy = toado[i].Trim().Split(' ');
                double x = Convert.ToDouble(xy[0]);
                double y = Convert.ToDouble(xy[1]);
                customElement0.Location = new GeoPoint(x, y);
                customElement0.ToolTipPattern = objToado.ListSearchNameTBA1[i].ToString();
                customElement0.Image = new Bitmap(image0);
                customElement0.ImageIndex = i;
                customElement0.RenderOrigin = new MapPoint(0.5, 1);
                customElement0.Padding = new System.Windows.Forms.Padding(0);
                customElement0.Attributes.Add(new MapItemAttribute {Name="TT1", Value = objToado.ListSearchIDTBA1[i] });
                searchDay1TT.Items.Add(customElement0);
            }
            imageLayer0.Data = searchDay1TT;
        }
        // canh bao mat dien duong day
        public void paintLineWarning()
        {
            double xTam = 0, yTam = 0;
            double xj = 0, yj = 0;
            List<string> toado = objToado.xulyLine(objWarning.ListWarningDZ);
            VectorItemsLayer itemsLayer = new VectorItemsLayer();
            mctSoDo.Layers.Add(itemsLayer);
            searchDayWarning = new MapItemStorage();
            for (int i = 0; i < toado.Count; i++)
            {
                string[] xline = toado[i].Split(',');
                for (int j = 0; j < xline.Count(); j++)
                {
                    MapLine mline = new MapLine();
                    mline.Stroke = Color.Gray;//Goldenrod
                    mline.StrokeWidth = 3;
                    mline.ToolTipPattern = "Đường dây đang mất điện";
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
            timer1.Enabled = true;
        }
        public void paintSearchDuongday() {
            this.Cursor = Cursors.WaitCursor;
            if (btVM.Text.Equals("Chạy giả lập"))
            {
                objToado.getNotice(DVQuanLy, "NT");
                objToado.searcDuongday(checkNode(treeDuongday.Nodes), DVQuanLy, nutload);
                objWarning.getWarning(checkNode(treeDuongday.Nodes), DVQuanLy, nutload);
                objWarning.getWarningDZ(checkNode(treeDuongday.Nodes), DVQuanLy, nutload);
            }
            else
            {
                objToado.getNotice(DVQuanLy, "NT");
                objToado.searcDuongday_VM(checkNode(treeDuongday.Nodes), DVQuanLy, nutload);
                objWarning.getWarning_VM(checkNode(treeDuongday.Nodes), DVQuanLy, nutload);
                objWarning.getWarningDZ_VM(checkNode(treeDuongday.Nodes), DVQuanLy, nutload);
            }
            if (objToado.ListIDN.Count != 0)
            {
                paintNotice();
            }
            if (objToado.ListsearchDZLine22.Count != 0)
            {
                paintLine22();
            }
            if (objToado.ListsearchDZLine35.Count != 0)
            {
                paintLine35();
            }
            if (objWarning.ListWarningDZ.Count != 0)
            {
                paintLineWarning();
            }
            if (objToado.ListsearchDZPoint0CD.Count!=0)
            {
                paintPoint0CD();
            }
            if (objToado.ListsearchDZPoint1CD.Count!=0)
            {
                paintPoint1CD();
            }
            if (objToado.ListsearchDZPoint0TT.Count!=0)
            {
                if (checkViewTT.Checked==false)
                {
                    paintPoint0TT();
                }
            }
            if (objToado.ListsearchDZPoint1TT.Count!=0)
            {
                if (checkViewTT.Checked==false)
                {
                    paintPoint1TT();
                }
            }
            if (objToado.ListsearchDZPoint0MC.Count != 0)
            {
                paintPoint0MC();
            }
            if (objToado.ListsearchDZPoint1MC.Count != 0)
            {
                paintPoint1MC();
            }
            if (objToado.ListsearchDZPoint0TG.Count != 0)
            {
                paintPoint0TG();
            }
            if (objToado.ListsearchDZPoint1TG.Count != 0)
            {
                paintPoint1TG();
            }
            if (objToado.ListsearchDZPoint0SI.Count != 0)
            {
                paintPoint0SI();
            }
            if (objToado.ListsearchDZPoint1SI.Count != 0)
            {
                paintPoint1SI();
            }
            if (objToado.ListsearchDZPoint0MCDZ.Count != 0)
            {
                paintPoint0MCDZ();
            }
            if (objToado.ListsearchDZPoint1MCDZ.Count != 0)
            {
                paintPoint1MCDZ();
            }
            if (objWarning.ListWarning.Count!=0)
            {
                paintPointWarning();
            }
            
            this.Cursor = Cursors.Default;
        }
        MapItem[] GetCapitals(string text,double x,double y)
        {
            return new MapItem[] { 
                new MapCallout() { Text = text, Location = new GeoPoint(x, y) },
                };
        }
        public void inforSearch(string text,double x,double y) {
            VectorItemsLayer itemsLayer = new VectorItemsLayer();
            mctSoDo.Layers.Add(itemsLayer);
            MapItemStorage storage = new MapItemStorage();
            MapItem[] mapitem = GetCapitals(text,x,y);
            storage.Items.AddRange(mapitem); 
            itemsLayer.Data = storage;
            timer1.Enabled = true;
            delay_ms(3000);
            storage.Items.RemoveAt(0);
            timer1.Enabled = false;
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
        public string xulychuoi(string chuoi) {
            if (chuoi.IndexOf("TBA") != -1) {
                return  "Trạm biến áp "+chuoi.Remove(0, chuoi.IndexOf("TBA") + 3);
                
            }
            if (chuoi.IndexOf("DCL")!=-1)
            {
                return  "Dao cách ly "+chuoi.Remove(0, chuoi.IndexOf("DCL") + 3);
            }
            return chuoi;
        }
        private void mapControl1_MapItemClick(object sender, MapItemClickEventArgs e)
        {
            try
            {
                sttVoice = false;
                voice.Speak("<speak version='1.0' xmlns='http://www.w3.org/2001/10/synthesis' xml:lang='vi-VN' gender='female'>" + xulychuoi(((MapCustomElement)e.Item).ToolTipPattern) + "</speak>", SpeechVoiceSpeakFlags.SVSFlagsAsync | SpeechVoiceSpeakFlags.SVSFIsXML);
            }
            catch (Exception)
            {
            }
            if (checkBoxPTD.Checked==false)
            {
                if (btVM.Text.Equals("Chạy giả lập"))
                {
                    
                    try
                    {
                        //string[] tootip = e.Item.ToolTipPattern.Split('-'); 
                        //frmTrangthaiTram trangthai = new frmTrangthaiTram(((MapCustomElement)e.Item).ToolTipPattern);
                        idPTDien=int.Parse(((MapCustomElement)e.Item).Attributes.First().Value.ToString());
                        loaiTB = ((MapCustomElement)e.Item).Attributes.First().Name.ToString();
                        lbTenTram.Text = "Tên trạm : " + ((MapCustomElement)e.Item).ToolTipPattern;
                        thongso(idPTDien,loaiTB);
                        elementAt = ((MapCustomElement)e.Item).ImageIndex;
                        if (loai.Equals("0"))
                        {
                            if (qhe==false)
                            {
                                if (mnQh)
                                {
                                    cmdThietLapQH.Enabled = true;
                                }
                                if (mnTt)
                                {
                                    cmdCapNhatTrangThai.Enabled = true;
                                }
                                contextMenuStrip1.Show(mctSoDo, mctSoDo.PointToClient(Cursor.Position));
                                frmLuachon luachon = new frmLuachon(idPTDien, username, DVQuanLy,loai);
                                //luachon.ShowDialog();
                                //this.qhe = luachon.qhe;
                                
                                lbTenNut.Text = ((MapCustomElement)e.Item).ToolTipPattern;
                            }
                            else
                            {
                                if (!lbIDNut.Text.Equals(idPTDien.ToString()))
                                {
                                    EnableMenuStrip(true, true);
                                    MenuStrip1.Show(mctSoDo, mctSoDo.PointToClient(Cursor.Position));
                                }
                                else
                                {
                                    EnableMenuStrip(false, false);
                                    MenuStrip1.Show(mctSoDo, mctSoDo.PointToClient(Cursor.Position));
                                }
                            }
                        }
                        if (loai.Equals("1"))
                        {
                            frmTrangthaiTram trangthai = new frmTrangthaiTram(((MapCustomElement)e.Item).Attributes.First().Value.ToString(), username);
                            trangthai.ShowDialog();
                        }
                        if (loai.Equals("2"))
                        {
                            frmUpdatePTDien sua = new frmUpdatePTDien(idPTDien, username);
                            sua.ShowDialog();
                        }
                    }
                    catch
                    {
                        try
                        {
                            idPTDien=int.Parse(((MapLine)e.Item).Attributes.First().Value.ToString());
                            if (qhe == false)
                            {
                                //frmLuachon luachon = new frmLuachon(idPTDien, username, DVQuanLy, true);
                                //luachon.ShowDialog();
                                cmdThietLapQH.Enabled = false;
                                cmdCapNhatTrangThai.Enabled = false;
                                cmdThongSoTram.Enabled = false;
                                contextMenuStrip1.Show(mctSoDo, mctSoDo.PointToClient(Cursor.Position));
                            }
                            else
                            {
                                MenuStrip1.Show(mctSoDo, mctSoDo.PointToClient(Cursor.Position));
                            }
                        }
                        catch (Exception)
                        {
                            try
                            {
                                if (loai.Equals("0"))
                                {
                                    frmCreatPTDien createPTD = new frmCreatPTDien(((MapPushpin)e.Item).ToolTipPattern, username, DVQuanLy);
                                    createPTD.ShowDialog();
                                }

                            }
                            catch (Exception)
                            {
                                try
                                {
                                    if (loai.Equals("0"))
                                    {
                                        if (((MapPolyline)e.Item).Attributes.First().Name.ToString().Equals("CreateLine"))
                                        {
                                            frmCreatPTDien createPTD = new frmCreatPTDien(toadoLine, username, DVQuanLy, true);
                                            createPTD.ShowDialog();
                                        }
                                    }

                                }
                                catch (Exception)
                                {
                                    try
                                    {
                                        if (loai.Equals("0"))
                                        {
                                            frmUpdateAllPTDien updateAll = new frmUpdateAllPTDien(int.Parse(((MapLine)e.Item).Attributes.First().Value.ToString()), username, DVQuanLy);
                                            updateAll.ShowDialog();
                                        }

                                    }
                                    catch (Exception)
                                    {
                                        try
                                        {
                                            if (loai.Equals("1")||loai.Equals("0"))
                                            {
                                                if (((MapPolygon)e.Item).Attributes.First().Name.ToString().Equals("CreateNotice"))
                                                {
                                                    frmCreateNotice createN = new frmCreateNotice(toadoLine, username, DVQuanLy);
                                                    createN.ShowDialog();
                                                }
                                                else
                                                {
                                                    idN = int.Parse(((MapPolygon)e.Item).Attributes.First().Value.ToString());
                                                    MenuDeleteN.Show(mctSoDo, mctSoDo.PointToClient(Cursor.Position));
                                                }
                                            }
                                        }
                                        catch (Exception)
                                        {
                                            
                                        }
                                    }

                                }

                            }
                        }

                    }
                    /*finally {
                        loaiTB = ""; // thuc hien set ="" de khi doi tuong bam vao nhưng ko thuc hien thao toat ma thoat ra
                    }*/
                }
                else
                {
                    try
                    {
                        if (loai.Equals("1")||loai.Equals("0"))
                        {
                            frmTrangthaiTram trangthai = new frmTrangthaiTram(((MapCustomElement)e.Item).Attributes.First().Value.ToString(), username,true);
                            trangthai.Text = "Đang chạy giả lập - Thông tin Trạm";
                            trangthai.ShowDialog();
                        }
                    }
                    catch (Exception)
                    {
                    
                    }
                }
            }
        }
        
        private void tsTrangThai_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void cmdTimDDay_Click(object sender, EventArgs e)
        {
            nutload = 0;
            huydoituongSearchday();
            paintSearchDuongday();
            checkViewTT.Enabled = true;
        }
        private string checkNode(TreeListNodes nodes)
        {
            string str = "";
            foreach (TreeListNode node in nodes)
            {
                if (node.CheckState == CheckState.Checked) str = str + String.Format("{0},", node.GetValue("maPmis"));
                str += checkNode(node.Nodes);
            }
            return str;
        }
        private void showInMap(string _MaDV,int _IdPT)
        {
            VectorItemsLayer layer = ObjCtl.getViTriDZ(_MaDV,_IdPT);
            //layer.DataLoaded += layer_DataLoaded;
            MessageBox.Show(layer.Data.Count.ToString());
            mctSoDo.Layers.Add(layer);
        }

        void layer_DataLoaded(object sender, DataLoadedEventArgs e)
        {
            mctSoDo.ZoomToFitLayerItems();
        }

        private void frmMap_Load(object sender, EventArgs e)
        {
            ObjCtl = new MAPControler();
        }

        private void cmdTimPT_Click(object sender, EventArgs e)
        {

            if (txtMaPTu.Text != "" || txtTenPTu.Text!="")
            {
                string[] toadodiem = objToado.searchDiem(txtMaPTu.Text, txtTenPTu.Text, DVQuanLy,dz22,dz35);
                try
                {
                    if (toadodiem != null)
                    {
                        string td = toadodiem[1].ToString().Replace(")", "");
                        string[] tam = td.Split(' ');
                        double x = double.Parse(tam[0]);
                        double y = double.Parse(tam[1].Replace(',',' '));
                        mctSoDo.CenterPoint = new GeoPoint(x, y);
                        dgrCtlPTDien.DataSource = objToado.listSearchten; 
                        inforSearch(objToado.listSearchten[0].ToString(), x, y);
                    }
                }
                catch (Exception)
                {

                   MessageBox.Show("Hệ thống không tìm được! bạn vui lòng kiểm tra lại từ khóa ");
                }

            }
            else
            {
                MessageBox.Show("Bạn vui lòng nhập mã phần tử hoặc tên phần tử ");
            }
            
        }

        private void dgrPTDien_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            showInMap(dgrPTDien.GetFocusedRowCellValue("").ToString(), int.Parse(dgrPTDien.GetFocusedRowCellValue("").ToString()));
            
        }

        private void dgrDDay_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //showInMap(dgrDDay.GetFocusedRowCellValue("MA_DVQLY").ToString(), int.Parse(dgrDDay.GetFocusedRowCellValue("ID_PTDIEN").ToString())); 
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //daluong();

        }

        private void searchPTdien(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (dgrPTDien.RowCount!=1)
            {
                List<string> listtoado = objToado.xulyDiem(objToado.listSearchtoado);
                List<string> listten = objToado.listSearchten;
                string td = listtoado[e.FocusedRowHandle];
                string ten = listten[e.FocusedRowHandle];
                string[] tam = td.Split(' ');
                double x = double.Parse(tam[0]);
                double y = double.Parse(tam[1].Replace(',',' '));
                mctSoDo.CenterPoint = new GeoPoint(x, y);
                inforSearch(ten, x, y);
            }
                

        }

        private void timetick(object sender, EventArgs e)
        {
            t++;
            if (t > 6000) t = 0;
        }
        
        public void huydoituongSearchday() {
            try
            {
                paintMap.Dispose();
            }
            catch (Exception)
            {
                
            }
            try
            {
                searchDay0CD.Dispose();
            }
            catch (Exception)
            {
                
            }
            try
            {
                searchDay1CD.Dispose();
            }
            catch (Exception)
            {
                
                
            }
            try
            {
                searchDay0TT.Dispose();
            }
            catch (Exception)
            {
                
               
            }
            try
            {
                searchDay1TT.Dispose();
            }
            catch (Exception)
            {

                
            }
            try
            {
                searchDay22.Dispose();
            }
            catch (Exception)
            {
                
                
            }
            try
            {
                searchDay35.Dispose();
            }
            catch (Exception)
            {
                
            }
            try
            {
                searchDay0MC.Dispose();
            }
            catch (Exception)
            {
                
            }
            try
            {
                searchDay1MC.Dispose();
            }
            catch (Exception)
            {
                
            }
            try
            {
                searchDay1TG.Dispose();
            }
            catch (Exception)
            {

            }
            try
            {
                searchDay0TG.Dispose();
            }
            catch (Exception)
            {

            }
            try
            {
                searchDay0SI.Dispose();
            }
            catch (Exception)
            {

            }
            try
            {
                searchDay1SI.Dispose();
            }
            catch (Exception)
            {

            }
            try
            {
                searchDay0MCDZ.Dispose();
            }
            catch (Exception)
            {

            }
            try
            {
                searchDay1MCDZ.Dispose();
            }
            catch (Exception)
            {

            }
            try
            {
                ItemStorageWarning.Dispose();
            }
            catch (Exception)
            {
                
            }
            try
            {
                searchDayWarning.Dispose();
            }
            catch (Exception)
            {

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            simpleButton2.Enabled = false;
            simpleButton3.Enabled = true;
            simpleButton4.Enabled = true;
            bingMapDataProvider1.Kind = DevExpress.XtraMap.BingMapKind.Road;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            simpleButton2.Enabled = true;
            simpleButton3.Enabled = false;
            simpleButton4.Enabled = true;
            bingMapDataProvider1.Kind = DevExpress.XtraMap.BingMapKind.Area;
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            simpleButton2.Enabled = true;
            simpleButton3.Enabled = true;
            simpleButton4.Enabled = false;
            bingMapDataProvider1.Kind = DevExpress.XtraMap.BingMapKind.Hybrid;
        }

        private void selechDonvi(object sender, EventArgs e)
        {
            try
            {
                
                int slIndex=cboDonVi.SelectedIndex;
                DVQuanLy = lstDVQL.ElementAt(slIndex);
                if (tinh != 0)
                {
                    huydoituongSearchday();
                }
                xltd(slIndex);
                tinh = tinh + 1;

                cmdTimPT.Enabled = true;
                chk22kV.Enabled = true;
                chk35kV.Enabled = true;
                chk22kV.Checked = false; dz22 = "";
                chk35kV.Checked = false; dz35 = "";
                btXemNhanh.Enabled = true;
                //daluong();
                simpleButton6.Text = "Tạm dừng";
                initTbDSMatdien();
                mctSoDo.CenterPoint = new GeoPoint(getX, getY);
                if (EnoughPermission()) autoData();
            }
            catch (Exception)
            {
                this.Close();
            }
        }
        private void checkUncheck22(object sender, EventArgs e)
        {
            if (chk22kV.Checked == true)
            {
                dz22 = "05";
                if (chk35kV.Checked == false)
                {
                    dz35 = "";
                }
                createMenu(treeDuongday);
            }
            if (chk22kV.Checked == false)
            {
                dz22 = "";
                if (chk35kV.Checked == true)
                {
                    createMenu(treeDuongday);
                }
                else
                {
                    treeDuongday.Nodes.Clear();
                }
            }
        }

        private void checkUncheck35(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            delay_ms(500);
            if (chk35kV.Checked == true)
            {
                dz35 = "06";
                if (chk22kV.Checked == false)
                {
                    dz22 = "";
                }
                createMenu(treeDuongday);
            }
            if (chk35kV.Checked == false)
            {
                dz35 = "";
                if (chk22kV.Checked == true)
                {
                    createMenu(treeDuongday);
                }
                else
                {
                    treeDuongday.Nodes.Clear();
                }
            }
            timer1.Enabled = false;
        }
        
        private void createMenu(TreeList tr)
        {
            tr.BeginUnboundLoad();
            TreeListNode root = null;
            createNode(tr, root);
            tr.EndUnboundLoad();
        }
        private void createNode(TreeList tr, TreeListNode nodes)
        {
            List<string> parent = objToado.getPMISCHA(this.DVQuanLy, this.dz35, this.dz22);
            List<string> maPmis = objToado.listMaPmis;
            tr.Nodes.Clear();
            for (int i = 0; i < parent.Count; i++)
            {
                TreeListNode tmp = tr.AppendNode(new object[] { parent[i],maPmis[i] }, nodes);
            }
            
        }
        private void chonTab(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
    
        }
        public void changeState(TreeListNodes nodes)
        {
            foreach (TreeListNode node in nodes)
            {
                node.CheckState = checkbochon.CheckState;
                changeState(node.Nodes);
            }
        }

        private void checkAnUncheck(object sender, EventArgs e)
        {
            try
            {
                changeState(treeDuongday.Nodes);
            }
            catch (Exception)
            {
                
               
            }
        }
        public void invertState(TreeListNodes nodes)
        {
            foreach (TreeListNode node in nodes)
            {
                node.CheckState = (node.CheckState == CheckState.Checked) ? CheckState.Unchecked : CheckState.Checked;
                invertState(node.Nodes);
            }
        }

        private void reveseCheck(object sender, EventArgs e)
        {
            try
            {
                invertState(treeDuongday.Nodes);
            }
            catch (Exception)
            {
                
               
            }
        }

        private void supportSearch(object sender, EventArgs e)
        {
            /*if (txtTenPTu.Text!=null)
            {
                txtTenPTu.AutoCompleteCustomSource = objToado.supportSearch(txtTenPTu.Text, DVQuanLy);
            }*/
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            itemstorePolie.Items.Clear();
            btTinhPin.Visible = false;
            btXoaPin1.Visible = false;
            try
            {
                paintMapTemp.Dispose();
            }
            catch (Exception)
            {
            }
            try
            {
                ItemStorage110.Dispose();
            }
            catch (Exception)
            {
                
            }
        }

        private void btTinhPin_Click(object sender, EventArgs e)
        {
            if (khoangcach != 0)
            {
                MessageBox.Show("Chiều dài khoảng cách là " + string.Format("{0:0.##}", khoangcach * 1000) + " mét (" + string.Format("{0:0.##}", khoangcach) + " km)");
            }
            else
            {
                MessageBox.Show("Bạn mới chọn 1 điểm, không thể tính được khoảng cách. Vui lòng chọn ít nhất 2 điểm trở lên");
            }
        }
        private void initTinh()
        {
            if ((chk22kV.Checked == false && chk35kV.Checked == false) || (chk22kV.Checked == true && chk35kV.Checked == true))
            {
                nutload = 1;
            }
            else
            {
                if (chk22kV.Checked == true)
                {
                    nutload = 2;
                }
                else
                {
                    nutload = 3;
                }
            }
            if (tinh != 0)
            {
                huydoituongSearchday();
            }
        }
        private void paintAll_()
        {
            if (objToado.ListIDN.Count != 0)
            {
                paintNotice();
            }
            if (objToado.ListsearchDZLine22.Count != 0)
            {
                paintLine22();
            }
            if (objToado.ListsearchDZLine35.Count != 0)
            {
                paintLine35();
            }
            if (objWarning.ListWarningDZ.Count != 0)
            {
                paintLineWarning();
            }
            if (objToado.ListsearchDZPoint0CD.Count != 0)
            {
                paintPoint0CD();
            }
            if (objToado.ListsearchDZPoint1CD.Count != 0)
            {
                paintPoint1CD();
            }
            if (objToado.ListsearchDZPoint0TT.Count != 0)
            {
                if (btVM.Text.Equals("Chạy giả lập") && checkViewTT.Checked == false)
                {
                    paintPoint0TT();
                }
                if (!btVM.Text.Equals("Chạy giả lập") && checkViewTT.Checked == false)
                {
                    paintPoint0TT();
                }
            }
            if (objToado.ListsearchDZPoint1TT.Count != 0)
            {
                if (btVM.Text.Equals("Chạy giả lập") && checkViewTT.Checked == false)
                {
                    paintPoint1TT();
                }
                if (!btVM.Text.Equals("Chạy giả lập") && checkViewTT.Checked == false)
                {
                    paintPoint1TT();
                }
            }
            if (objToado.ListsearchDZPoint0MC.Count != 0)
            {
                paintPoint0MC();
            }
            if (objToado.ListsearchDZPoint1MC.Count != 0)
            {
                paintPoint1MC();
            }
            if (objToado.ListsearchDZPoint0TG.Count != 0)
            {
                paintPoint0TG();
            }
            if (objToado.ListsearchDZPoint1TG.Count != 0)
            {
                paintPoint1TG();
            }
            if (objToado.ListsearchDZPoint0SI.Count != 0)
            {
                paintPoint0SI();
            }
            if (objToado.ListsearchDZPoint1SI.Count != 0)
            {
                paintPoint1SI();
            }
            if (objToado.ListsearchDZPoint0MCDZ.Count != 0)
            {
                paintPoint0MCDZ();
            }
            if (objToado.ListsearchDZPoint1MCDZ.Count != 0)
            {
                paintPoint1MCDZ();
            }
            if (objWarning.ListWarning.Count != 0)
            {
                paintPointWarning();
            }
            checkViewTT.Enabled = true;
        }
        private void simpleButton1_Click_2(object sender, EventArgs e)
        {
            initTinh();
            this.Cursor = Cursors.WaitCursor;
            if (btVM.Text.Equals("Chạy giả lập"))
            {
                objToado.getNotice(DVQuanLy,"NT");
                objToado.searcDuongday(checkNode(treeDuongday.Nodes), DVQuanLy, nutload);
                objWarning.getWarning(checkNode(treeDuongday.Nodes), DVQuanLy, nutload);
                objWarning.getWarningDZ(checkNode(treeDuongday.Nodes), DVQuanLy, nutload);
            }
            else
            {
                objToado.getNotice(DVQuanLy, "NT");
                objToado.searcDuongday_VM(checkNode(treeDuongday.Nodes), DVQuanLy, nutload);
                objWarning.getWarning_VM(checkNode(treeDuongday.Nodes), DVQuanLy, nutload);
                objWarning.getWarningDZ_VM(checkNode(treeDuongday.Nodes), DVQuanLy, nutload);
            }
            paintAll_();
            this.Cursor = Cursors.Default;
            dz22 = "05";
            dz35 = "06";
            tinh = tinh + 1;
        }

        private void DSTmatdien_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                toadoControler1 td1 = new toadoControler1();
                dockThongtinTram.Show();
                dem = DSTmatdien.FocusedRowHandle;
                gridThongTinTram.DataSource= td1.getThongTinTram(int.Parse(DSTmatdien.GetFocusedRowCellValue("ID_PTDIEN").ToString()));
                string tenTT = DSTmatdien.GetFocusedRowCellValue("TEN_PTDIEN").ToString();
                try
                {
                    int SL = td1.getCountKH(DSTmatdien.GetFocusedRowCellValue("MA_CMIS").ToString());
                    labelKH.Text = "Có " + SL + " khách hàng bị ảnh hương mất điện";
                }
                catch (Exception)
                {
                    labelKH.Text = "Chưa có mã trạm,vui lòng cập nhật mã trạm.";
                }
                DateTime begin = DateTime.Parse(DSTmatdien.GetFocusedRowCellValue("NGAY_CAP_NHAT").ToString());
                DateTime end = objToado.getDateServer();
                TimeSpan sum;
                sum = end - begin;
                ngay=sum.Days;
                gio=sum.Hours;
                phut=sum.Minutes;
                giay=sum.Seconds;
                timeSumMatDien.Enabled = true;
                timeSumMatDien.Interval = 1000;
                try
                {
                    if (rdCanhBao.Checked)
                    {
                        sttVoice = false;
                        voice.Speak("<speak version='1.0' xmlns='http://www.w3.org/2001/10/synthesis' xml:lang='vi-VN' gender='female'>" + xulychuoi(tenTT) + " đang cắt điện " + "</speak>", SpeechVoiceSpeakFlags.SVSFlagsAsync | SpeechVoiceSpeakFlags.SVSFIsXML);
                    }
                }
                catch (Exception)
                {
                    
                }
            }
            catch (Exception)
            {
                
            }
        }

        private void thongTinTram_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView; 
            if (e.Column.FieldName == "D_PTDIEN.MA_CMIS" && string.IsNullOrEmpty(View.GetRowCellDisplayText(e.RowHandle, e.Column)))
            {
                e.Appearance.BackColor = Color.Red;
            }
        }

        private void timeSumMatDien_Tick(object sender, EventArgs e)
        {
            giay++;
            if (giay<60)
	        {
                labelSumtime.Text = "Tổng thời gian mất điện ( "+ngay.ToString("00") + ":" + gio.ToString("00") + ":" + phut.ToString("00") + ":" + giay.ToString("00")+ " )";
	        }
            else
	        {
                giay=0;
                phut++;
                if (phut<60)
	            {
                    labelSumtime.Text = "Tổng thời gian mất điện ( "+ngay.ToString("00") + ":" + gio.ToString("00") + ":" + phut.ToString("00") + ":" + giay.ToString("00")+ " )";
	            }
                else
	            {
                    phut=0;
                    gio++;
                    if (gio<24)
	                {
                        labelSumtime.Text = "Tổng thời gian mất điện ( "+ngay.ToString("00") + ":" + gio.ToString("00") + ":" + phut.ToString("00") + ":" + giay.ToString("00")+ " )";
	                }
                    else
	                {
                        gio=0;
                        ngay++;
                        labelSumtime.Text = "Tổng thời gian mất điện ( " + ngay.ToString("00") + ":" + gio.ToString("00") + ":" + phut.ToString("00") + ":" + giay.ToString("00") + " )";
	                }
	            }
	        }   

        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            dockThongtinTram.Show();
            simpleButton5.Enabled = false;
        }

        private void timerChangeChose_Tick(object sender, EventArgs e)
        {

            ++dem; 
            if (dem<DSTmatdien.DataRowCount)
            {
                DSTmatdien.FocusedRowHandle = dem;
            }
            else
            {
                DSTmatdien.FocusedRowHandle = 0;
                dem = 0;
            }
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            if (timerChangeChose.Enabled==true)
            {
                timerChangeChose.Enabled = false;
                simpleButton6.Text = "Tiếp tục";
            }
            else
            {
                timerChangeChose.Enabled = true;
                simpleButton6.Text = "Tạm dừng";
            }
        }

        private void dockThongtinTram_ClosingPanel(object sender, DevExpress.XtraBars.Docking.DockPanelCancelEventArgs e)
        {
            simpleButton5.Enabled = true;
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            if (this.mctSoDo.NavigationPanelOptions.Visible ==true)
            {
                this.mctSoDo.NavigationPanelOptions.Visible = false;
                btanHien.Text = "Hiện trợ năng";
            }
            else
            {
                this.mctSoDo.NavigationPanelOptions.Visible = true;
                btanHien.Text = "Ẩn trợ năng";
            }
        }

        private void mctSoDo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (Int32)Keys.Enter )
                {
                    frmFindToaDo frm = new frmFindToaDo();
                    frm.ShowDialog();
                    string s = frmFindToaDo.td.Trim();
                    if (s!="" && s!=null)
                    {
                        try
                        {
                            string[] s1 = s.Split(' ');
                            double s01=double.Parse(s1[0]);
                            double s11=double.Parse(s1[1]);
                            this.mctSoDo.CenterPoint = new DevExpress.XtraMap.GeoPoint(s01,s11);
                            inforSearch(s, s01, s11);
                        }
                        catch (Exception)
                        {
                            string[] toadodiem = objToado.searchDiem("", s, DVQuanLy, dz22, dz35);
                            try
                            {
                                if (toadodiem != null)
                                {
                                    string td = toadodiem[1].ToString().Replace(")", "");
                                    string[] tam = td.Split(' ');
                                    double x = double.Parse(tam[0]);
                                    double y = double.Parse(tam[1].Replace(',', ' '));
                                    mctSoDo.CenterPoint = new GeoPoint(x, y);
                                    xtraTabControl1.SelectedTabPage = xtraTabPage1;
                                    dgrCtlPTDien.DataSource = objToado.listSearchten;
                                    inforSearch(objToado.listSearchten[0].ToString(), x, y);
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

        private void btOffline_Click(object sender, EventArgs e)
        {
            if (btOffline.Text == "Bản đồ offline")
            {
                this.Cursor = Cursors.WaitCursor;
                OpenStreetMapDataProvider provider = new OpenStreetMapDataProvider();
                //provider.Kind = DevExpress.XtraMap.OpenStreetMapKind.;
                provider.CacheOptions.DiskFolder = @"Maps";
                imageTilesLayer1.DataProvider = provider;
                btOffline.Text = "Bản đồ online";
                simpleButton2.Enabled = false;
                simpleButton3.Enabled = false;
                simpleButton4.Enabled = false;
                this.Cursor = Cursors.Hand;
            }
            else
            {
                if (checkConnection())
                {
                    this.Cursor = Cursors.WaitCursor;
                    bingMapDataProvider1 = new DevExpress.XtraMap.BingMapDataProvider();
                    bingMapDataProvider1.BingKey = "Ni2omY6R0JCa0s9jg672~ScZDKIqSAmTCxBgWfxil2w~AmweYivP5B4wgzndtAYwDEAe2NZjYG1CNmj-V" +
                    "pEbpI1UUWIX08NhvhBP910oj6HA";
                    bingMapDataProvider1.CacheOptions.DiskFolder = @"Maps";
                    bingMapDataProvider1.Kind = DevExpress.XtraMap.BingMapKind.Road;
                    imageTilesLayer1.DataProvider = bingMapDataProvider1;
                    btOffline.Text = "Bản đồ offline";
                    simpleButton2.Enabled = false;
                    simpleButton3.Enabled = true;
                    simpleButton4.Enabled = true;
                    this.Cursor = Cursors.Hand;
                }
                else
                {
                    MessageBox.Show("Không có kết nối internet.Không thể load bản đổ online được.");
                }
            }
        }

        private void DSDao_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {

            GridView View = sender as GridView;
            if (e.Column.FieldName == "TEN_PTDIEN")
            {
                string category = View.GetRowCellDisplayText(e.RowHandle, View.Columns["MA_CAPDA"]);
                if (category == "05")
                    e.Appearance.ForeColor = Color.Blue;
                  
                else if (category == "06")
                    e.Appearance.ForeColor = Color.Red;
                e.Appearance.Font = new Font("Tahoma", 9, FontStyle.Bold);
            }
        }

        private void DSTmatdien_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.Column.FieldName == "TEN_PTDIEN")
            {
                string category = View.GetRowCellDisplayText(e.RowHandle, View.Columns["MA_CAPDA"]);
                if (category == "05")
                    e.Appearance.ForeColor = Color.Blue;

                else if (category == "06")
                    e.Appearance.ForeColor = Color.Red;
                e.Appearance.Font = new Font("Tahoma", 9, FontStyle.Bold);
            }
        }
        public void initBieuDo() {
            toadoControler1 td2 = new toadoControler1();
            Dictionary<string, int> inDay = td2.getCountMatDienTrongNgay(_dvql);
            Dictionary<string, int> present = td2.getCountMatDienHienTaiTrongNgay(_dvql);
            chartControl1.Series.Clear();
            chartControl1.Titles.Clear();
            Series series0 = new Series("Tổng số trạm mất điện trong ngày", ViewType.Bar);
            foreach (var item in inDay)
            {
                series0.Points.Add(new SeriesPoint(item.Key,item.Value));
            }
            Series series1 = new Series("Số Trạm hiện tại mất điện trong ngày",ViewType.Point);
            foreach (var item in present)
            {
                series1.Points.Add(new SeriesPoint(item.Key,item.Value));
            }
            chartControl1.Series.Add(series0);
            chartControl1.Series.Add(series1);
            chartControl1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            ChartTitle chartTitle1 = new ChartTitle();
            chartTitle1.Text = "Biểu đồ so sánh ";
            chartTitle1.Font = new Font("Tahoma", 9, FontStyle.Bold);
            ChartTitle ngay = new ChartTitle();
            ngay.Text ="Ngày "+ td2.getDateServer();
            ngay.Font = new Font("Tahoma", 10, FontStyle.Bold);
            chartControl1.Titles.Add(chartTitle1);
            chartControl1.Titles.Add(ngay);
        }

        private void SimpleButton13_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor; 
            try
            {
                if (!DateBegin.Text.ToString().Trim().Equals("") && !DateEnd.Text.ToString().Trim().Equals(""))
                {
                    if (objToado.ListIDN != null)
                    {
                        if (btVM.Text.Equals("Chạy giả lập"))
                        {
                            huydoituongSearchday();
                            initTinh();
                            DateTime begin, end;
                            begin = DateBegin.DateTime;
                            end = DateEnd.DateTime;
                            string[] b = begin.ToString().Split(',');
                            string[] c = end.ToString().Split(',');
                            objToado.searcDuongday_LS(checkNode(treeDuongday.Nodes), DVQuanLy, nutload, DateBegin.DateTime, DateEnd.DateTime);
                            objWarning.getWarningDZ_LS(checkNode(treeDuongday.Nodes), DVQuanLy, nutload, DateBegin.DateTime.ToString(), DateEnd.DateTime.ToString());
                            objWarning.getWarning_LS(checkNode(treeDuongday.Nodes), DVQuanLy, nutload, DateBegin.DateTime.ToString(), DateEnd.DateTime.ToString());
                            paintAll_();
                            if (objToado.listLS0.Count != 0)
                            {
                                paintPointLS0();
                            }
                            if (objToado.listLS1.Count != 0)
                            {
                                paintPointLS1();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Tính năng này không hỗ trợ trong môi trường giả lập");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bạn vui lòng bấm xem trước khi bấm xem lại lịch sử");
                    }
                    
                }
                else
                {
                    MessageBox.Show("Bạn vui lòng chọn thời gian.");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("Có lỗi xảy ra bạn vui lòng kiểm tra lại.\n"+ee);
            }
            this.Cursor = Cursors.Hand;
            tinh = tinh + 1;
        }


        private void CậpNhậtTrạngTháiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTrangthaiTram trangthai = new frmTrangthaiTram(idPTDien.ToString(), username);
            trangthai.ShowDialog();
        }

        private void CậpNhậtThôngTinVịTríToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmLuachon luachon = new frmLuachon(idPTDien, username, DVQuanLy,loai);
            luachon.FrmThongTin();
        }

        private void cmdXemAnh_Click(object sender, EventArgs e)
        {
            frmViewImage viewImage = new frmViewImage(loai, idPTDien, lbTenTram.Text, _btXoaAnh);
            viewImage.ShowDialog();
        }

        

        private void cmdXemCamera_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tính năng này đang ");
        }

        private void cmdThongSoTram_Click(object sender, EventArgs e)
        {
            if (!loaiTB.Equals("TT0") && !loaiTB.Equals("TT1"))//luachon.qhe
            {
                MessageBox.Show("Đây không phải là trạm nên không thể xem thông số.");
            }
            else
            {
                frmTBADetail frm = new frmTBADetail(idPTDien, _btDetailTBA);
                frm.ShowDialog();
            }
        }

        private void ThiếtLậpQuanHệToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            qhe = true;
            if (!loaiTB.Equals("TT0") && !loaiTB.Equals("TT1") && qhe)//luachon.qhe
            {
                toadoControler1 td1 = new toadoControler1();
                groupControl4.Visible = true;
                gridTLQHe.DataSource = null;
                gridTLQHe.DataSource = td1.listLR(idPTDien);
                lbIDNut.Text = idPTDien.ToString();

            }
            else
            {
                this.qhe = false;
                MessageBox.Show("Loại phần tử điện này không thể thêm.");
            }
            if (frmUpdateAllPTDien.tt == true)
            {
                loaiTB = "";
                frmUpdateAllPTDien.tt = false;
                RefreshData();
            }
        }

        private void XóaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmLuachon luachon = new frmLuachon(idPTDien, username, DVQuanLy,loai);
            luachon.xoa();
        }

        private void btVM_Click(object sender, EventArgs e)
        {
            if (loai.Equals("0")||loai.Equals("1"))
            {
                if (btVM.Text.Equals("Chạy giả lập"))
                {
                    btVM.Text = "Chạy thực tế";
                    huydoituongSearchday();
                    cmdTimDDay.Enabled = false;
                    dockBando.Close();
                    dockThongtinTram.Text = "Cảnh báo - Thông tin trạm mất điện ----- ĐANG CHẠY GIẢ LẬP";
                    initTbDSMatdien();
                    if (EnoughPermission()) autoData();
                }
                else
                {
                    btVM.Text = "Chạy giả lập";
                    huydoituongSearchday();
                    cmdTimDDay.Enabled = true;
                    dockBando.Show();
                    dockThongtinTram.Text = "Cảnh báo - Thông tin trạm mất điện";
                    initTbDSMatdien();
                    if (EnoughPermission()) autoData();
                }
            }
            else
            {
                MessageBox.Show("Bạn không có quyền sử dụng tính năng này.");
            }
        }

        private void simpleButton1_Click_3(object sender, EventArgs e)
        {
            panelButton.Visible = true;
        }

        private void simpleButton7_Click_1(object sender, EventArgs e)
        {
            panelButton.Visible = false;
        }

        private void checkViewTT_CheckedChanged(object sender, EventArgs e)
        {
            if (checkViewTT.Checked)
            {
                try
                {
                    searchDay0TT.Dispose();
                }
                catch (Exception)
                {
                    
                    
                }
                try
                {
                    searchDay1TT.Dispose();
                }
                catch (Exception)
                {
                    
                }
                try
                {
                    searchDay0CD.Dispose();
                }
                catch (Exception)
                {
                    
                    
                }
                try
                {
                    searchDay1CD.Dispose();
                }
                catch (Exception)
                {


                }
                try
                {
                    if (objToado.ListsearchDZPoint0CD.Count != 0)
                    {
                        paintPoint0CD();
                    }
                    if (objToado.ListsearchDZPoint1CD.Count != 0)
                    {
                        paintPoint1CD();
                    }
                }
                catch (Exception)
                {
                    
                }
            }
            else
            {
                try
                {
                    searchDay0CD.Dispose();
                }
                catch (Exception)
                {


                }
                try
                {
                    searchDay1CD.Dispose();
                }
                catch (Exception)
                {


                }
                try
                {
                    if (objToado.ListsearchDZPoint0CD.Count != 0)
                    {
                        paintPoint0CD();
                    }
                    if (objToado.ListsearchDZPoint1CD.Count != 0)
                    {
                        paintPoint1CD();
                    }
                    if (objToado.ListsearchDZPoint0TT.Count != 0)
                    {
                        paintPoint0TT();
                    }
                    if (objToado.ListsearchDZPoint1TT.Count != 0)
                    {
                        paintPoint1TT();
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        private void DSALLCD_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.Column.FieldName == "TEN_PTDIEN")
            {
                string category = View.GetRowCellDisplayText(e.RowHandle, View.Columns["MA_CAPDA"]);
                string trangthai = View.GetRowCellDisplayText(e.RowHandle, View.Columns["TRANG_THAI"]);
                if (category == "05")
                {
                    e.Appearance.ForeColor = Color.Blue;
                    if (trangthai=="0")
                    {
                        e.Appearance.BackColor = Color.Gray;
                    }
                }
                else if (category == "06")
                {
                    e.Appearance.ForeColor = Color.Red;
                    if (trangthai == "0")
                    {
                        e.Appearance.BackColor = Color.Gray;
                    }
                }
                e.Appearance.Font = new Font("Tahoma", 9, FontStyle.Bold);
            }
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            toadoControler1 td1 = new toadoControler1();
            gridDSALLCD.DataSource = td1.listAllCD(DVQuanLy);
        }

        private void DSALLCD_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                IDCD = int.Parse(DSALLCD.GetFocusedRowCellValue("ID_PTDIEN").ToString());
                tenCD=DSALLCD.GetFocusedRowCellValue("TEN_PTDIEN").ToString();
            }
            catch (Exception)
            {
                
            }
        }

        private void DSALLCD_RowClick(object sender, RowClickEventArgs e)
        {
            List<string> tdcd = objToado.xulyDiem(objToado.getToadoCD(IDCD));
            string[] xy = tdcd[0].Trim().Split(' ');
            double x = Convert.ToDouble(xy[0]);
            double y = Convert.ToDouble(xy[1]);
            mctSoDo.CenterPoint = new GeoPoint(x, y);
            inforSearch(tenCD, x, y);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (btVM.Text.Equals("Chạy giả lập"))
            {
                this.Cursor = Cursors.WaitCursor;
                initBieuDo();
                this.Cursor = Cursors.Default;
            }
        }

        private void checkBoxRefresh_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxRefresh.Checked)
            {
                btRefresh.Visible = true;
            }
            else
            {
                btRefresh.Visible = false;
            }
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            huydoituongSearchday();
            paintSearchDuongday();
            initTbDSMatdien();
        }
        public void thongso(int idPTDien,string loaiTB)
        {
            dockThongSo.Show();
            string matram = objToado.getMaTram(idPTDien);
            if (loaiTB=="TT0"||loaiTB=="TT1")
            {
                K_THONGSO_V ts = objToado.getThongSoTT(matram);
                if (ts!=null)
                {
                    lbMaTram.Text = "Mã trạm : "+matram;
                    lbTime.Text = "Thời gian đọc " + ts.NGAY_NHAN;
                    lbIA.Text = ts.IA.ToString()+" A";
                    lbIB.Text = ts.IB.ToString() + " A";
                    lbIC.Text = ts.IC.ToString() + " A";
                    LBI.Text = ts.I.ToString() + " A";
                    lbUA.Text = ts.UA.ToString() + " V";
                    lbUB.Text = ts.UB.ToString() + " V";
                    lbUC.Text = ts.UC.ToString() + " V";
                    lbPA.Text = ts.PA.ToString() + " KW";
                    lbPB.Text = ts.PB.ToString() + " KW";
                    lbPC.Text = ts.PC.ToString() + " KW";
                    lbP.Text = ts.P.ToString() + " KW";
                    lbPG1.Text = ts.PG1.ToString() + " kWh";
                    lbPG2.Text = ts.PG2.ToString() + " kWh";
                    lbPG3.Text = ts.PG3.ToString() + " kWh";
                    lbPG.Text = ts.PG.ToString() + " kWh";
                    lbPN1.Text = ts.PN1.ToString() + " kWh";
                    lbPN2.Text = ts.PN2.ToString() + " kWh";
                    lbPN3.Text = ts.PN3.ToString() + " kWh";
                    lbPN.Text = ts.PN.ToString() + " kWh";
                    lbP1.Text = ts.PMAX.ToString();
                    lbPmaxTime.Text = "vào lúc: "+ts.TIME_PMAX.ToString();
                }
                else
                {
                    if (matram == null || matram.Equals(""))
                    {
                        lbMaTram.Text = "Chưa có mã trạm";

                    }
                    else
                    {
                        lbMaTram.Text = matram;
                    }
                    if (!loaiTB.Equals("TT0") && !loaiTB.Equals("TT1"))
                    {
                        lbTenTram.Text = "";
                        lbMaTram.Text = "";
                        lbTime.Text = "";
                    }
                    lbTime.Text = "Không thể xác định các thông số.";
                    lbIA.Text = "";
                    lbIB.Text = "";
                    lbIC.Text = "";
                    LBI.Text = "";
                    lbUA.Text = "";
                    lbUB.Text = "";
                    lbUC.Text = "";
                    lbUC.Text = "";
                    lbPA.Text = "";
                    lbPB.Text = "";
                    lbPC.Text = "";
                    lbP.Text = "";
                    lbPG1.Text = "";
                    lbPG2.Text = "";
                    lbPG3.Text ="";
                    lbPG.Text = "";
                    lbP1.Text = "";
                    lbPmaxTime.Text = "";
                }   
            }
            else if (loaiTB=="CB0"||loaiTB=="CB1")
            {
                K_THONGSO_CB_V ts = objToado.getThongSoCB(matram);
                if (ts!=null)
                {
                    lbMaTram.Text = "Mã MC : "+matram;
                    lbTime.Text = "Thời gian đọc " + ts.NGAY_NHAN;
                    lbIA.Text = String.Format("{0:0.000}", ts.IA) + " A";
                    lbIB.Text = String.Format("{0:0.000}", ts.IB) + " A";
                    lbIC.Text = String.Format("{0:0.000}", ts.IC) + " A";
                    LBI.Text = ts.I.ToString() + " A";
                    lbUA.Text = String.Format("{0:0.000}", ts.UA) + " V";
                    lbUB.Text = String.Format("{0:0.000}", ts.UB) + " V";
                    lbUC.Text = String.Format("{0:0.000}", ts.UC) + " V";
                    lbPA.Text = String.Format("{0:0.000}", ts.PA) + " KW";
                    lbPB.Text = String.Format("{0:0.000}", ts.PB) + " KW";
                    lbPC.Text = String.Format("{0:0.000}", ts.PC) + " KW";
                    lbP.Text = ts.P.ToString() + " KW";
                    lbPG1.Text = String.Format("{0:0.000}", ts.QA) + " kVAR";
                    lbPG2.Text = String.Format("{0:0.000}", ts.QB) + " kVAR";
                    lbPG3.Text = String.Format("{0:0.000}", ts.QC) + " kVAR";
                    lbPG.Text = ts.Q.ToString() + " kVAR";
                    lbP1.Text = ts.PMAX.ToString();
                    lbPmaxTime.Text = "vào lúc: "+ts.TIME_PMAX.ToString();
                }
                else
                {
                    if (matram == null || matram.Equals(""))
                    {
                        lbMaTram.Text = "Chưa có tagName máy cắt";
                    }
                    else
                    {
                        lbMaTram.Text = matram;
                    }
                    lbTime.Text = "Không thể xác định các thông số.";
                    lbIA.Text = "";
                    lbIB.Text = "";
                    lbIC.Text = "";
                    LBI.Text = "";
                    lbUA.Text = "";
                    lbUB.Text = "";
                    lbUC.Text = "";
                    lbUC.Text = "";
                    lbPA.Text = "";
                    lbPB.Text = "";
                    lbPC.Text = "";
                    lbP.Text = "";
                    lbPG1.Text = "";
                    lbPG2.Text = "";
                    lbPG3.Text ="";
                    lbPG.Text = "";
                    lbP1.Text = "";
                    lbPmaxTime.Text = "";
                }  
            }
            else
            {
                lbTenTram.Text = "";
                lbMaTram.Text = "";
                lbTime.Text = "";
                lbTime.Text = "Không thể xác định các thông số.";
                lbIA.Text = "";
                lbIB.Text = "";
                lbIC.Text = "";
                LBI.Text = "";
                lbUA.Text = "";
                lbUB.Text = "";
                lbUC.Text = "";
                lbUC.Text = "";
                lbPA.Text = "";
                lbPB.Text = "";
                lbPC.Text = "";
                lbP.Text = "";
                lbPG1.Text = "";
                lbPG2.Text = "";
                lbPG3.Text = "";
                lbPG.Text = "";
                lbP1.Text = "";
                lbPmaxTime.Text = "";
            }
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            frmConfigVoice frm = new frmConfigVoice();
            frm.ShowDialog();
            if (initVoice)
            {
                setVoice();
            }
        }

        private void rdCanhBao_CheckedChanged(object sender, EventArgs e)
        {
            if (rdCanhBao.Checked)
            {
                if (initVoice==false)
                {
                    voice = new SpVoice();
                    voice.EndStream += endRead;// su kien doc xong
                    voice.StartStream += startRead;
                    setVoice();
                }
                initVoice = true;
            }
        }

        private void rdDocPTD_CheckedChanged(object sender, EventArgs e)
        {
            if (rdDocPTD.Checked)
            {
                if (initVoice == false)
                {
                    voice = new SpVoice();
                    voice.EndStream += endRead;// su kien doc xong
                    voice.StartStream += startRead;
                    setVoice();
                }
                initVoice = true;
            }
        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            if (loai.Equals("0"))
            {
                frmCreatPTDien createPTD = new frmCreatPTDien("20.2384877332124 105.892637200439", username, DVQuanLy);
                createPTD.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền sử dụng tính năng này");
            }
        }
        
        private void simpleButton10_Click(object sender, EventArgs e)
        {
            if (loai.Equals("0"))
            {
                frmCreatPTDien createPTD = new frmCreatPTDien("20.2384877332124 105.892637200439,20.2310786516556 105.900876946533", username, DVQuanLy, true);
                createPTD.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn không có quyền sử dụng tính năng này");
            }
        }

        private void caapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool c = true;
            toadoControler1 obj1 = new toadoControler1();
            D_QHE_PTDIEN_VITRI objLR = new D_QHE_PTDIEN_VITRI();
            objLR.ID_PTDienCha = int.Parse(lbIDNut.Text);
            objLR.ID_PTDienCon = idPTDien;
            objLR.TENPTDienCon = lbTenNut.Text;
            objLR.VITRI = "L";
            objLR.NGAYCAPNHAT = objToado.getDateServer();
            objLR.USERNAME = username;
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
            objLR.ID_PTDienCon = idPTDien;
            objLR.TENPTDienCon = lbTenNut.Text;
            objLR.VITRI = "R";
            objLR.NGAYCAPNHAT = objToado.getDateServer();
            objLR.USERNAME = username;
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

        private void TLQHe_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                idLR = int.Parse(TLQHe.GetFocusedRowCellValue("ID").ToString());
                
            }
            catch (Exception)
            {

            }
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa quan hệ này?", "Xác nhận", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                toadoControler1 obj1 = new toadoControler1();
                obj1.deleteLR(idLR);
                MessageBox.Show("Xóa thành công!");
                gridTLQHe.DataSource = null;
                gridTLQHe.DataSource = obj1.listLR(int.Parse(lbIDNut.Text));
            }
        }

        private void TLQHe_RowClick(object sender, RowClickEventArgs e)
        {
            MenuDelete.Show(gridTLQHe, gridTLQHe.PointToClient(Cursor.Position));
        }

        private void dừngXétQuanHệToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dungXetQH();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa tất cả quan hệ?","Cảnh báo!",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                toadoControler1 obj1 = new toadoControler1();
                List<D_QHE_PTDIEN_VITRI> lstQH = obj1.listLR(int.Parse(lbIDNut.Text));
                if (lstQH.Count!=0)
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

        private void xóaTấtCảQuanHệVớiPhầnTửToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa tất cả quan hệ của phần tử này với các phần tử khác?", "Xác nhận", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                toadoControler1 obj1 = new toadoControler1();
                List<D_QHE_PTDIEN_VITRI> lstQH = obj1.listLRCon(idPTDien);
                if (lstQH.Count!=0)
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

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dungXetQH();
        }
        public void dungXetQH() {
            qhe = false;
            groupControl4.Visible = false;
            dánQuanHệToolStripMenuItem.Enabled = false;
        }

        private void xóaGhiChúToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa ghi chú này không?", "xác thực", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                PTDiencontroler obj = new PTDiencontroler();
                D_PTDIEN dp = obj.getthongtinDiem(idN);
                HISTORY_DELETE_DPTIDEN _objHDelete = new HISTORY_DELETE_DPTIDEN();
                _objHDelete.ID_PTDIEN = dp.ID_PTDIEN;
                _objHDelete.TEN_PTDIEN = dp.TEN_PTDIEN;
                _objHDelete.LOAI_PTDIEN = dp.LOAI_PTDIEN;
                _objHDelete.MA_CAPDA = dp.MA_CAPDA;
                _objHDelete.MA_CMIS = dp.MA_CMIS;
                _objHDelete.MA_DVQLY = dp.MA_DVQLY;
                _objHDelete.MA_PMIS = dp.MA_PMIS;
                _objHDelete.MA_PMISCHA = dp.MA_PMISCHA;
                _objHDelete.MA_SCADA = dp.MA_SCADA;
                _objHDelete.NGAY_SUA = dp.NGAY_SUA;
                _objHDelete.NGAY_TAO = dp.NGAY_TAO;
                _objHDelete.NGUOI_SUA = dp.NGUOI_SUA;
                _objHDelete.NGUOI_TAO = dp.NGUOI_TAO;
                _objHDelete.NGUOI_XOA = username;
                _objHDelete.NGAY_XOA = obj.getDateServer();
                obj.addHisStoryDelete(_objHDelete);
                obj.deleteTT(idN);
                obj.deleteTTVM(idN);
                string query = "delete from M_VITRI where ID_PTDIEN=" + idN;
                obj.deleteVT(query);
                obj.delete(idN);
                MessageBox.Show("Xóa phần tử điện thành công!");
            }
        }

        private void saoChépQuanHệToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toadoControler1 obj1 = new toadoControler1();
            lstQH = obj1.saoChepQH(idPTDien);
            if (lstQH.Count!=0)
            {
                dánQuanHệToolStripMenuItem.Enabled = true;
            }
            else
            {
                dánQuanHệToolStripMenuItem.Enabled = false;
                MessageBox.Show("Phần tử này chưa có quan hệ nào để sao chép","Thông báo");
            }
        }

        private void dánQuanHệToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toadoControler1 obj1 = new toadoControler1();
            List<D_QHE_PTDIEN_VITRI> lst = new List<D_QHE_PTDIEN_VITRI>();
            foreach (var item in lstQH)
            {
                D_QHE_PTDIEN_VITRI obj = new D_QHE_PTDIEN_VITRI();
                obj.ID_PTDienCha = item.ID_PTDienCha;
                obj.ID_PTDienCon=idPTDien;
                obj.NGAYCAPNHAT = DateTime.Parse(obj1.getDateServer());
                obj.USERNAME = username;
                obj.VITRI = item.VITRI;
                lst.Add(obj);
            }
            obj1.danQH(lst);
            gridTLQHe.DataSource = null;
            gridTLQHe.DataSource = obj1.listLR(int.Parse(lbIDNut.Text));
            MessageBox.Show("Dán quan hệ thành công!");
        }

        private void xemQuanHệToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInforQuanHe frm = new frmInforQuanHe(idPTDien);
            frm.ShowDialog();
        }

        private void timerZoom_Tick(object sender, EventArgs e)
        {
            troluc(TL-1);
            var pt1H = mctSoDo.Size.Height;
            pictureBox1.Location = new Point(Location.X, pt1H - pictureBox1.Height);
            //pictureBox1.Location = this.PointToClient(Cursor.Position);simpleButton1 
            //pictureBox1.Location = new Point(simpleButton1.Bounds.X+3, simpleButton1.Bounds.Y+28); 
        }
        private void troluc(int t) {
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
        private void simpleButton12_Click(object sender, EventArgs e)
        {
            if (btTroLuc.Text.Equals("Bật trợ lực"))
            {
                btTroLuc.Text="Tắt trợ lực";
                pictureBox1.Visible = true;
                timerZoom.Enabled = true;
            }
            else
            {
                btTroLuc.Text="Bật trợ lực";
                pictureBox1.Visible = false;
                timerZoom.Enabled = false;
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
        public void paintLineQH(bool conCha)
        {
            toadoControler1 obj1 = new toadoControler1();
            List<string> toado;
            if (conCha)
            {
                toado= objToado.xulyDiem(obj1.toaDoQuanHe(idPTDien,0));
            }
            else
            {
                toado = objToado.xulyDiem(obj1.toaDoQuanHe(0,idPTDien));
            }
            VectorItemsLayer itemsLayer = new VectorItemsLayer();
            mctSoDo.Layers.Add(itemsLayer);
            ItemStorage110 = new MapItemStorage();

            string[] xy = toado.ElementAt(0).Trim().Split(' ');
            double x = Convert.ToDouble(xy[0]);
            double y = Convert.ToDouble(xy[1]);

            for (int i = 1; i < toado.Count; i++)
            {
                MapLine mline = new MapLine();
                if (conCha)
                {
                    mline.Stroke = Color.Gold;
                }
                else
                {
                    mline.Stroke = Color.DarkSalmon;
                }
                mline.StrokeWidth = 2;
                string[] xy1 = toado[i].Trim().Split(' ');
                double x1 = Convert.ToDouble(xy1[0]);
                double y1 = Convert.ToDouble(xy1[1]);
                mline.Point1 = new GeoPoint(x, y);
                mline.Point2 = new GeoPoint(x1, y1);
                ItemStorage110.Items.Add(mline);
            }
            itemsLayer.Data = ItemStorage110;

        }

        private void xemQHMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            paintLineQH(true);
        }

        private void simpleButton12_Click_1(object sender, EventArgs e)
        {
            if (loai.Equals("0"))
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    openFileDialog1.Filter = "Excel 2003 (*.xls)|*.xls|Excel 2007-2016 (.xlsx)|*.xlsx";
                    if (openFileDialog1.FileName != "")
                    {
                        frmInsertPTDExcel frm = new frmInsertPTDExcel(openFileDialog1.FileName, username, DVQuanLy);
                        frm.ShowDialog(); ;
                    }
                    //XtraMessageBox.Show("Thếm phần tử điện thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            else
            {
                MessageBox.Show("Bạn không có quyền sử dụng tính năng này");
            }
        }

        private void xemQHChaConMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            paintLineQH(false);
        }
        public void EnableMenuStrip(bool en,bool df) {
            caapToolStripMenuItem.Enabled = en;
            cậpNhậtThôngTinToolStripMenuItem.Enabled = en;
            saoChépQuanHệToolStripMenuItem.Enabled = en;
        }
    }
}