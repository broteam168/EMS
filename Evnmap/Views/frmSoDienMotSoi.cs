using DevExpress.XtraMap;
using LDSong.Controlers;
using LDSong.Libs;
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
    public partial class frmSoDienMotSoi : DevExpress.XtraEditors.XtraForm
    {
        DevExpress.XtraMap.ImageTilesLayer imageTilesLayer1;
        private bool stMove = false,stV=false,stH=false;
        private MapPolyline Pline;
        private MapLine PlineYellow;
        private string toadoLine = "", toadoLineDZ="", dvql, dvql_cb, userName, maCapda, loai;
        private int t,dem=0,size=1,sizeFont=6;
        double xmv, ymv;
        private toado_SD1SControler objToado;
        MapItemStorage  searchDay0TGH, searchDay0TGV, searchDay1TGV, searchDay1TGH, searchDay0SIV, searchDay0SIH, searchDay1SIV, searchDay1SIH, searchDay0MCDZV, searchDay0MCDZH, searchDay1MCDZH, searchDay1MCDZV, searchDay22, searchDay35, itemstorePolie, itemstorePolieYellow, searchDayWarning, mapNote, paintMap,paintKH;
        private SqlConnection connection = null;
        private SqlCommand command = null;
        private DataSet myDataSet = null;
        private FontStyle f=FontStyle.Bold;
        private Color color = Color.Blue;
        MapPushpin Pin = new MapPushpin();
        public frmSoDienMotSoi()
        {
            InitializeComponent();
            initSoDoMotSoi();
            itemstorePolie = new MapItemStorage();
            mcSoDo1Soi.MapItemClick += mapControl1_MapItemClick;
            mcSoDo1Soi.MouseDoubleClick += MapControl_MouseDoubleClick;
            
        }

        public frmSoDienMotSoi(string dvql,string userName,string loai)
        {
            paintMap = new MapItemStorage();
            objToado = new toado_SD1SControler();
            InitializeComponent();
            initSoDoMotSoi();
            lbkhoangcach.Text = "";
            this.dvql = dvql;
            this.userName = userName;
            this.loai = loai;
            itemstorePolie = new MapItemStorage();
            itemstorePolieYellow = new MapItemStorage();
            mcSoDo1Soi.MapItemClick += mapControl1_MapItemClick;
            mcSoDo1Soi.MouseDoubleClick += MapControl_MouseDoubleClick;
            mcSoDo1Soi.MouseMove += MapControl_MouseMove;
            if (EnoughPermission()) autoData();
            initCBdvql();
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            paintAll(dvql_cb,maCapda);
            bool fontDefault = LDSong.Properties.Settings.Default.SireFontDefault;
            if (fontDefault)
            {
                sizeFont=LDSong.Properties.Settings.Default.SireFont;
                textSireFont.Text = sizeFont.ToString();
            }
            string c = LDSong.Properties.Settings.Default.Color;
            if (c.Equals("green"))
            {
                color = Color.Green;
                radioButton3.Checked = true;
                textSireFont.Enabled = true;
                btSetDefault.Enabled = true;
            }
            else
            {
                if (c.Equals("red"))
                {
                    color = Color.Red;
                    radioButton7.Checked = true;
                }
                else
                {
                    if (c.Equals("blue"))
                    {
                        color = Color.Blue;
                        radioButton2.Checked = true;
                    }
                    else
                    {
                        if (c.Equals("violet"))
                        {
                            color = Color.Violet;
                            radioButton6.Checked = true;
                        }
                        else
                        {
                            if (c.Equals("yellow"))
                            {
                                color = Color.Yellow;
                                radioButton5.Checked = true;
                            }
                            else
                            {
                                color = Color.YellowGreen;
                                radioButton4.Checked = true;
                            }
                        }
                    }
                }
            }
        }

        
        private void MapControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (stMove)
            {
                //int i = 0;
                string[] td1 = toadoLine.Split(' ');
                VectorItemsLayer VectorLayer = new VectorItemsLayer();
                mcSoDo1Soi.Layers.Add(VectorLayer);
                if (itemstorePolie.Items.Contains(Pline))
                {
                    itemstorePolie.Items.Remove(Pline);
                }
                Pline = new MapPolyline();
                Pline.StrokeWidth = 3;
                Pline.Stroke = Color.Red;
                MapPoint MyPoint = new DevExpress.XtraMap.MapPoint(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y);
                GeoPoint GP1 = VectorLayer.ScreenPointToGeoPoint(MyPoint); 
                
                if (stV)
                {
                    xmv = GP1.GetY();
                    ymv = double.Parse(td1[1]);
                }
                else
                {
                    if (stH)
                    {
                        xmv = double.Parse(td1[0]);
                        ymv = GP1.GetX();
                    }
                    else
                    {
                        xmv = GP1.GetY();
                        ymv = GP1.GetX();
                    }
                }
                GeoPoint GP = new GeoPoint(xmv,ymv);
                foreach (MapPushpin mp in itemstorePolie.Items)
                {
                    Pline.Points.Add(mp.Location);
                }
                
                double kk = GeoMath.GetEquirectangularDistance(new GeoPoint(double.Parse(td1[0]), double.Parse(td1[1])), GP);
                lbkhoangcach.Text = string.Format("{0:0.######}", kk);
                Pline.Points.Add(GP);
                //Pline.Attributes.Add(new MapItemAttribute { Name = "CreateLine" });
                itemstorePolie.Items.Add(Pline);
                VectorLayer.Data = itemstorePolie;
            }

            
        }
        public void initCBdvql() {
            cbDonvi.Properties.DataSource = objToado.listDVQL(dvql);
            cbDonvi.Properties.NullText = "Vui lòng chọn đơn vị.";
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
            if (dvql!="PN")
            {
                ssql = "select TRANG_THAI from dbo.M_TTHAI_PTDIEN where MA_DVQLY='" + dvql + "';";
            }
            else
            {
                ssql = "select TRANG_THAI from dbo.M_TTHAI_PTDIEN ;";
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
            huydoituongSearchday();
            paintAll(dvql_cb, maCapda);
        }
        public void paintAll(string dvql_cb,string maCapda) {
            this.Cursor = Cursors.WaitCursor;
            objToado.getAllTB(dvql_cb, maCapda);
            objToado.getAllDZ(dvql_cb, maCapda);
            objToado.getWarning(dvql_cb, maCapda);
            objToado.getNote(dvql_cb, maCapda);
            if (checkBold.Checked)
            {
                f = FontStyle.Regular;
            }
            else
            {
                f = FontStyle.Bold;
            }
            if (objToado.ListsearchDZLine22.Count != 0)
            {
                paintLine22(size);
            }
            if (objToado.ListsearchDZLine35.Count != 0)
            {
                paintLine35(size);
            }
            if (objToado.ListsearchDZPoint0CDH.Count != 0)
            {
                paintPoint0CDH();
            }
            if (objToado.ListsearchDZPoint0CDV.Count != 0)
            {
                paintPoint0CDV();
            }
            if (objToado.ListsearchDZPoint1CDH.Count != 0)
            {
                paintPoint1CDH();
            }
            if (objToado.ListsearchDZPoint1CDV.Count != 0)
            {
                paintPoint1CDV();
            }
            if (objToado.ListsearchDZPoint0MCH.Count != 0)
            {
                paintPoint0MCH();
            }
            if (objToado.ListsearchDZPoint0MCV.Count != 0)
            {
                paintPoint0MCV();
            }
            if (objToado.ListsearchDZPoint1MCH.Count != 0)
            {
                paintPoint1MCH();
            }
            if (objToado.ListsearchDZPoint1MCV.Count != 0)
            {
                paintPoint1MCV();
            }
            if (objToado.ListsearchDZPoint0TGH.Count != 0)
            {
                paintPoint0TGH();
            }
            if (objToado.ListsearchDZPoint0TGV.Count != 0)
            {
                paintPoint0TGV();
            }
            if (objToado.ListsearchDZPoint1TGV.Count != 0)
            {
                paintPoint1TGV();
            }
            if (objToado.ListsearchDZPoint1TGH.Count != 0)
            {
                paintPoint1TGH();
            }
            if (objToado.ListsearchDZPoint0SIH.Count != 0)
            {
                paintPoint0SIH();
            }
            if (objToado.ListsearchDZPoint0SIV.Count != 0)
            {
                paintPoint0SIV();
            }
            if (objToado.ListsearchDZPoint1SIH.Count != 0)
            {
                paintPoint1SIH();
            }
            if (objToado.ListsearchDZPoint1SIV.Count != 0)
            {
                paintPoint1SIV();
            }
            if (objToado.ListsearchDZPoint0MCDZH.Count != 0)
            {
                paintPoint0MCDZH();
            }
            if (objToado.ListsearchDZPoint0MCDZV.Count != 0)
            {
                paintPoint0MCDZV();
            }
            if (objToado.ListsearchDZPoint1MCDZH.Count != 0)
            {
                paintPoint1MCDZH();
            }
            if (objToado.ListsearchDZPoint1MCDZV.Count != 0)
            {
                paintPoint1MCDZV();
            }
            if (objToado.ListWarning.Count != 0)
            {
                paintLineWarning();
            }
            if (objToado.ListNotePoint.Count!=0)
            {
                paintPointNote();
            }
            this.Cursor = Cursors.Hand;
        }
        public void huydoituongSearchday()
        {
            try
            {
                paintMap.Dispose();
            }
            catch (Exception)
            {
                paintMap.Items.Clear();
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

            }
            try
            {
                searchDay0SIH.Dispose();
            }
            catch (Exception)
            {

            }
            try
            {
                searchDay0SIV.Dispose();
            }
            catch (Exception)
            {

            }
            try
            {
                searchDay1SIH.Dispose();
            }
            catch (Exception)
            {

            }
            try
            {
                searchDay1SIV.Dispose();
            }
            catch (Exception)
            {

            }
            try
            {
                searchDay0MCDZH.Dispose();
            }
            catch (Exception)
            {

            }
            try
            {
                searchDay0MCDZV.Dispose();
            }
            catch (Exception)
            {

            }
            try
            {
                searchDay1MCDZH.Dispose();
            }
            catch (Exception)
            {

            }
            try
            {
                searchDay1MCDZV.Dispose();
            }
            catch (Exception)
            {

            }
            try
            {
                timer1.Enabled = false;
                searchDayWarning.Dispose();
            }
            catch (Exception)
            {

            }
            try
            {
                mapNote.Dispose();
            }
            catch (Exception)
            {
                
            }
        }
        public void initSoDoMotSoi(){
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
            this.mcSoDo1Soi.ZoomLevel = 16D;
            this.mcSoDo1Soi.MaxZoomLevel = 17D;
            this.mcSoDo1Soi.MinZoomLevel = 15D;
            this.mcSoDo1Soi.BackColor = Color.Black;
            LocalProvider provider = new LocalProvider();
            imageTilesLayer1.DataProvider = provider;
            MiniMap miniMap = new MiniMap()
            {
                Alignment = MiniMapAlignment.BottomLeft
            };
            mcSoDo1Soi.MiniMap = miniMap;
            this.mcSoDo1Soi.Cursor = Cursors.Hand;
        }
        private IMapDataAdapter CreateMiniMapAdapter(object source)
        {
            ListSourceDataAdapter adapter = new ListSourceDataAdapter();

            adapter.DataSource = source;

            adapter.Mappings.Latitude = "Latitude";
            adapter.Mappings.Longitude = "Longitude";

            adapter.PropertyMappings.Add(new MapItemFillMapping() { DefaultValue = Color.Red });
            adapter.PropertyMappings.Add(new MapItemStrokeMapping() { DefaultValue = Color.White });
            adapter.PropertyMappings.Add(new MapItemStrokeWidthMapping() { DefaultValue = 2 });
            adapter.PropertyMappings.Add(new MapDotSizeMapping() { DefaultValue = 8 });

            adapter.DefaultMapItemType = MapItemType.Dot;

            return adapter;
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
        private void paintPolyMC(double x, double y ,bool _v,bool _close,bool _MC,int id,string Ten_PTDien)
        {
            VectorItemsLayer imageLayer0 = new VectorItemsLayer();
            mcSoDo1Soi.Layers.Add(imageLayer0);
            double x1, x2, y1, y2;
            if (_MC)
            {
                if (_v)
                {
                    x1 = Math.Round(x,5) - 0.00036;
                    x2 = Math.Round(x,5) + 0.0003600;
                    y1 = Math.Round(y,5) - 0.0001250;
                    y2 = Math.Round(y,5) + 0.0001250; 
                }
                else
                {
                    x1 = Math.Round(x,5) - 0.0001899;
                    x2 = Math.Round(x,5) + 0.0001899;
                    y1 = Math.Round(y,5) - 0.0002299;
                    y2 = Math.Round(y,5) + 0.0002299; 
                }
            }
            else
            {
                x1 = Math.Round(x,7) - 0.0001250;
                x2 = Math.Round(x,7) + 0.0001250;
                y1 = Math.Round(y,7) - 0.0000850;
                y2 = Math.Round(y,7) + 0.0000850;
            }
            var polygon = new MapPolygon();
            if (_MC)
            {
                polygon.Points.AddRange(new GeoPoint[] {
                new GeoPoint(x,y1),
                new GeoPoint(x1,y1),
                new GeoPoint(x1,y2),
                new GeoPoint(x,y2)
                });
                polygon.Attributes.Add(new MapItemAttribute { Name = "MC", Value = id });
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
            }
            polygon.ToolTipPattern = Ten_PTDien;
            
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
            paintMap.Items.Add(polygon);
            imageLayer0.Data = paintMap;
        }
        // hinh binh hanh
        private void paintKhung(double x = 20.250567D, double y = 105.974863D)
        {
            this.mcSoDo1Soi.CenterPoint = new DevExpress.XtraMap.GeoPoint(x, y);
            paintKH = new MapItemStorage();
            VectorItemsLayer imageLayer0 = new VectorItemsLayer();
            mcSoDo1Soi.Layers.Add(imageLayer0);
            double x1, x2, y1, y2;
            x1 = x - 0.0065000; 
            x2 = x + 0.0065000; 
            y1 = y - 0.0139999; 
            y2 = y + 0.0139999;
            var PlineKH1 = new MapLine();
            PlineKH1.StrokeWidth = 2;
            PlineKH1.Stroke = Color.Yellow;
            PlineKH1.Point1 = new GeoPoint(x1,y2);
            PlineKH1.Point2 = new GeoPoint(x2, y2);
            paintKH.Items.Add(PlineKH1);
            var PlineKH2 = new MapLine();
            PlineKH2.StrokeWidth = 2;
            PlineKH2.Stroke = Color.Yellow;
            PlineKH2.Point1 = new GeoPoint(x2, y2);
            PlineKH2.Point2 = new GeoPoint(x2, y1);
            paintKH.Items.Add(PlineKH2);
            var PlineKH3 = new MapLine();
            PlineKH3.StrokeWidth = 2;
            PlineKH3.Stroke = Color.Yellow;
            PlineKH3.Point1 = new GeoPoint(x2, y1);
            PlineKH3.Point2 = new GeoPoint(x1, y1);
            paintKH.Items.Add(PlineKH3);
            var PlineKH4 = new MapLine();
            PlineKH4.StrokeWidth = 2;
            PlineKH4.Stroke = Color.Yellow;
            PlineKH4.Point1 = new GeoPoint(x1, y1);
            PlineKH4.Point2 = new GeoPoint(x1, y2);
            paintKH.Items.Add(PlineKH4);
            imageLayer0.Data = paintKH;
        }
        private void MapControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            GeoPoint GP;
            dem = 0;
            VectorItemsLayer VectorLayer = new VectorItemsLayer();
            VectorItemsLayer VectorLayerYellow = new VectorItemsLayer();
            MapPoint MyPoint = new DevExpress.XtraMap.MapPoint(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y);
            texttoado.Text = "";
            var image0 = new Bitmap(@"icon\danhdau.png");
            mcSoDo1Soi.Layers.Add(VectorLayer);
            mcSoDo1Soi.Layers.Add(VectorLayerYellow);
            if (itemstorePolie.Items.Contains(Pline))
            {
                itemstorePolie.Items.Remove(Pline);
            }
            Pline = new MapPolyline();
            Pline.StrokeWidth = 3;
            Pline.Stroke = Color.Yellow;
            PlineYellow = new MapLine();
            PlineYellow.StrokeWidth = 3;
            PlineYellow.Stroke = Color.Yellow;
            PlineYellow.Attributes.Add(new MapItemAttribute { Name = "CreateLine" });
            if (stMove)
            {
                string[] td1 = toadoLine.Split(' '); 
                double x1 = double.Parse(td1[0]); 
                double y1 = double.Parse(td1[1]);
                PlineYellow.Point1 = new GeoPoint(x1, y1);
                GeoPoint GP2 = new GeoPoint(xmv,ymv);
                GP = new GeoPoint(xmv, ymv);
                toadoLine = toadoLine + "," + ymv + " " + xmv;
                toadoLineDZ = toadoLineDZ + "," + xmv + " " + ymv;
                PlineYellow.Point2 = GP2;
                PlineYellow.ToolTipPattern = toadoLine;
                stMove = false;
            }
            else
            {
                itemstorePolie.Items.Clear();
                GeoPoint GP1 = VectorLayer.ScreenPointToGeoPoint(MyPoint);
                toadoLine = GP1.GetY() + " " + GP1.GetX();
                if (dem==0)
                {
                    toadoLineDZ = GP1.GetY() + " " + GP1.GetX();
                    GP = VectorLayer.ScreenPointToGeoPoint(MyPoint);
                }
                else
                {
                    toadoLineDZ = toadoLineDZ+","+GP1.GetY() + " " + GP1.GetX();
                    GP = new GeoPoint(xmv, ymv);
                }
                stMove = true;
            }
            
            Pin.Location = GP;
            Pin.Image = new Bitmap(image0);
            Pin.RenderOrigin = new MapPoint(0.5, 1);
            Pin.ToolTipPattern = GP.GetY().ToString() + " " + GP.GetX().ToString();
            texttoado.Text = GP.GetY().ToString() + " " + GP.GetX().ToString();
            itemstorePolie.Items.Add(Pin);
            VectorLayer.Data = itemstorePolie;
            
            Pline.Attributes.Add(new MapItemAttribute { Name = "CreateLine" });
            itemstorePolie.Items.Add(Pline);
            if (stMove==false)
            {
                itemstorePolieYellow.Items.Add(PlineYellow);
            }
            VectorLayerYellow.Data = itemstorePolieYellow;
            VectorLayer.Data = itemstorePolie;
            btXoaPin.Visible = true;
            dem++;
            //timer1.Enabled = true;
            //delay_ms(300);
            //timer1.Enabled = false; 
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

        private void btXoaPin_Click(object sender, EventArgs e)
        {
            itemstorePolie.Items.Clear();
            itemstorePolieYellow.Items.Clear();
            toadoLineDZ = "";
            dem = 0;
            btXoaPin.Visible = false;
        }
        private void mapControl1_MapItemClick(object sender, MapItemClickEventArgs e)
        {
            if (checkOFFobject.Checked==false)
            {
                try
                {
                    if (loai.Equals("0"))
                    {
                        if (checkWindow.Checked==false)
                        {
                            frmCreatePTDSoDo1Soi createPTD = new frmCreatePTDSoDo1Soi(((MapPushpin)e.Item).ToolTipPattern, dvql_cb, maCapda);
                            createPTD.ShowDialog();
                            if (frmCreatePTDSoDo1Soi.success)
                            {
                                frmCreatePTDSoDo1Soi.success = false;
                                huydoituongSearchday();
                                paintAll(dvql_cb,maCapda);
                            }
                        }
                        stMove = true;
                        toadoLine = ((MapPushpin)e.Item).ToolTipPattern;
                    }
                }
                catch
                {

                    try
                    {
                        if (loai.Equals("0"))
                        {
                            if (stMove==false)
                            {
                                if (((MapLine)e.Item).Attributes.First().Name.ToString().Equals("CreateLine"))
                                {
                                    frmCreatePTDSoDo1Soi_DZ createPTD = new frmCreatePTDSoDo1Soi_DZ(toadoLineDZ, dvql_cb, userName);
                                    createPTD.ShowDialog();
                                }
                                else
                                {
                                    frmLuachon_SD1S luachon = new frmLuachon_SD1S(int.Parse(((MapCustomElement)e.Item).Attributes.First().Value.ToString()), userName, dvql, false, false, ((MapCustomElement)e.Item).Attributes.First().Name.ToString());
                                    luachon.ShowDialog();
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {
                        try
                        {
                            if (loai.Equals("0"))
                            {
                                frmLuachon_SD1S luachon = new frmLuachon_SD1S(int.Parse(((MapPolygon)e.Item).Attributes.First().Value.ToString()), userName, dvql, false, false, ((MapPolygon)e.Item).Attributes.First().Name.ToString());
                                luachon.ShowDialog();
                                if (frmUpdatePTDienSoDo1Soi.success || frmLuachon_SD1S.del)
                                {
                                    huydoituongSearchday();
                                    paintAll(dvql_cb, maCapda);
                                }
                            }
                            
                        }
                        catch (Exception)
                        {
                            try
                            {
                                if (loai.Equals("0"))
                                {
                                    frmLuachon_SD1S luachon = new frmLuachon_SD1S(int.Parse(((MapLine)e.Item).Attributes.First().Value.ToString()), userName, dvql, true, true);
                                    luachon.ShowDialog();
                                }

                            }
                            catch (Exception)
                            {

                                try
                                {
                                    if (loai.Equals("0"))
                                    {
                                        frmLuachon_SD1S luachon = new frmLuachon_SD1S(int.Parse(((MapCustomElement)e.Item).Attributes.First().Value.ToString()), userName, dvql, false, false, ((MapCustomElement)e.Item).Attributes.First().Name.ToString());
                                        luachon.ShowDialog();
                                        if (frmUpdatePTDienSoDo1Soi.success || frmLuachon_SD1S.del)
                                        {
                                            huydoituongSearchday();
                                            paintAll(dvql_cb, maCapda);
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
            
        }
        public void paintPointNote(bool _defaultFont=true)
        {
            List<string> toado = objToado.xulyDiem(objToado.ListNotePoint);
            VectorItemsLayer imageLayer0 = new VectorItemsLayer();
            mcSoDo1Soi.Layers.Add(imageLayer0);
            mapNote = new MapItemStorage();
            var image0 = new Bitmap(@"icon\note.png");
            for (int i = 0; i < toado.Count; i++)
            {
                MapCustomElement customElement0 = new MapCustomElement();
                string[] xy = toado[i].Trim().Split(' ');
                double x = Convert.ToDouble(xy[0]);
                double y = Convert.ToDouble(xy[1]);
                customElement0.Location = new GeoPoint(x, y);
                customElement0.Text = objToado.ListNoteTen[i].ToString();
                if (_defaultFont)
                {
                    customElement0.Font = new Font("Tahoma", objToado.ListNoteFont[i], f);
                }
                else
                {
                    customElement0.Font = new Font("Tahoma", sizeFont, f);
                }
                customElement0.Image = new Bitmap(image0);
                customElement0.ImageIndex = i;
                customElement0.RenderOrigin = new MapPoint(0.5, 1);
                customElement0.Padding = new System.Windows.Forms.Padding(0);
                customElement0.Attributes.Add(new MapItemAttribute { Name = "NT", Value = objToado.ListNoteID[i] });
                mapNote.Items.Add(customElement0);
            }
            imageLayer0.Data = mapNote;
        }
        public void paintLineWarning()
        {
            double xTam = 0, yTam = 0;
            double xj = 0, yj = 0;
            List<string> toado = objToado.xulyLine(objToado.ListWarning);
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
                    mline.ToolTipPattern = objToado.ListSearchNameDZ22[i].ToString();
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
        public void paintLine22(int w=1)
        {
            double xTam = 0, yTam = 0;
            double xj = 0, yj = 0;
            List<string> toado = objToado.xulyLine(objToado.ListsearchDZLine22);
            VectorItemsLayer itemsLayer = new VectorItemsLayer();
            mcSoDo1Soi.Layers.Add(itemsLayer);
            searchDay22 = new MapItemStorage();
            for (int i = 0; i < toado.Count; i++)
            {

                string[] xline = toado[i].Split(',');
                for (int j = 0; j < xline.Count(); j++)
                {
                    MapLine mline = new MapLine();
                    mline.Stroke = color;
                    mline.StrokeWidth = w;
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
        public void paintLine35(int w=1)
        {
            double xTam = 0, yTam = 0;
            double xj = 0, yj = 0;
            List<string> toado = objToado.xulyLine(objToado.ListsearchDZLine35);
            VectorItemsLayer itemsLayer = new VectorItemsLayer();
            mcSoDo1Soi.Layers.Add(itemsLayer);
            searchDay35 = new MapItemStorage();
            for (int i = 0; i < toado.Count; i++)
            {

                string[] xline = toado[i].Split(',');
                for (int j = 0; j < xline.Count(); j++)
                {
                    MapLine mline = new MapLine();
                    mline.Stroke = color;
                    mline.StrokeWidth = w;
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
        public void paintPoint0MCDZV()
        {
            List<string> toado = objToado.xulyDiem(objToado.ListsearchDZPoint0MCDZV);
            VectorItemsLayer imageLayer0 = new VectorItemsLayer();
            mcSoDo1Soi.Layers.Add(imageLayer0);
            searchDay0MCDZV = new MapItemStorage();
            //var image0 = new Bitmap(@"..//..//icon//MCDZ_open.png");
            var image0 = new Bitmap(@"icon\MCDZVOpen.gif");
            for (int i = 0; i < toado.Count; i++)
            {
                MapCustomElement customElement0 = new MapCustomElement();
                string[] xy = toado[i].Trim().Split(' ');
                double x = Convert.ToDouble(xy[0]);
                double y = Convert.ToDouble(xy[1]);
                customElement0.Location = new GeoPoint(x, y);
                customElement0.ToolTipPattern = objToado.ListSearchNameMCDZ0V[i].ToString();
                customElement0.Image = new Bitmap(image0);
                customElement0.ImageIndex = i;
                customElement0.RenderOrigin = new MapPoint(0.5, 1);
                customElement0.Padding = new System.Windows.Forms.Padding(0);
                customElement0.Attributes.Add(new MapItemAttribute { Name = "MCDZ0V", Value = objToado.ListSearchIDMCDZ0V[i] });
                searchDay0MCDZV.Items.Add(customElement0);
            }
            imageLayer0.Data = searchDay0MCDZV;
        }
        public void paintPoint0MCDZH()
        {
            List<string> toado = objToado.xulyDiem(objToado.ListsearchDZPoint0MCDZH);
            VectorItemsLayer imageLayer0 = new VectorItemsLayer();
            mcSoDo1Soi.Layers.Add(imageLayer0);
            searchDay0MCDZH = new MapItemStorage();
            //var image0 = new Bitmap(@"..//..//icon//MCDZ_open.png");
            var image0 = new Bitmap(@"icon\MCDZHOpen.gif");
            for (int i = 0; i < toado.Count; i++)
            {
                MapCustomElement customElement0 = new MapCustomElement();
                string[] xy = toado[i].Trim().Split(' ');
                double x = Convert.ToDouble(xy[0]);
                double y = Convert.ToDouble(xy[1]);
                customElement0.Location = new GeoPoint(x, y);
                customElement0.ToolTipPattern = objToado.ListSearchNameMCDZ0H[i].ToString();
                customElement0.Image = new Bitmap(image0);
                customElement0.ImageIndex = i;
                customElement0.RenderOrigin = new MapPoint(0.5, 1);
                customElement0.Padding = new System.Windows.Forms.Padding(0);
                customElement0.Attributes.Add(new MapItemAttribute { Name = "MCDZ0H", Value = objToado.ListSearchIDMCDZ0H[i] });
                searchDay0MCDZH.Items.Add(customElement0);
            }
            imageLayer0.Data = searchDay0MCDZH;
        }
        public void paintPoint1MCDZV()
        {
            List<string> toado = objToado.xulyDiem(objToado.ListsearchDZPoint1MCDZV);
            VectorItemsLayer imageLayer0 = new VectorItemsLayer();
            mcSoDo1Soi.Layers.Add(imageLayer0);
            searchDay1MCDZV = new MapItemStorage();
            var image0 = new Bitmap(@"icon\MCDZVClose.gif");
            for (int i = 0; i < toado.Count; i++)
            {
                MapCustomElement customElement0 = new MapCustomElement();
                string[] xy = toado[i].Trim().Split(' ');
                double x = Convert.ToDouble(xy[0]);
                double y = Convert.ToDouble(xy[1]);
                
                customElement0.Location = new GeoPoint(x, y);
                customElement0.ToolTipPattern = objToado.ListSearchNameMCDZ1V[i].ToString();
                customElement0.Image = new Bitmap(image0);
                customElement0.ImageIndex = i;
                customElement0.RenderOrigin = new MapPoint(0.5, 1);
                customElement0.Padding = new System.Windows.Forms.Padding(0);
                customElement0.Attributes.Add(new MapItemAttribute { Name = "MCDZ1V", Value = objToado.ListSearchIDMCDZ1V[i] });
                searchDay1MCDZV.Items.Add(customElement0);
            }
            imageLayer0.Data = searchDay1MCDZV;
        }
        public void paintPoint1MCDZH()
        {
            List<string> toado = objToado.xulyDiem(objToado.ListsearchDZPoint1MCDZH);
            VectorItemsLayer imageLayer0 = new VectorItemsLayer();
            mcSoDo1Soi.Layers.Add(imageLayer0);
            searchDay1MCDZH = new MapItemStorage();
            //var image0 = new Bitmap(@"..//..//icon//MCDZ_close.png");
            var image0 = new Bitmap(@"icon\MCDZHClose.gif");
            for (int i = 0; i < toado.Count; i++)
            {
                MapCustomElement customElement0 = new MapCustomElement();
                string[] xy = toado[i].Trim().Split(' ');
                double x = Convert.ToDouble(xy[0]);
                double y = Convert.ToDouble(xy[1]);
                customElement0.Location = new GeoPoint(x, y);
                customElement0.ToolTipPattern = objToado.ListSearchNameMCDZ1H[i].ToString();
                customElement0.Image = new Bitmap(image0);
                customElement0.ImageIndex = i;
                customElement0.RenderOrigin = new MapPoint(0.5, 1);
                customElement0.Padding = new System.Windows.Forms.Padding(0);
                customElement0.Attributes.Add(new MapItemAttribute { Name = "MCDZ1H", Value = objToado.ListSearchIDMCDZ1H[i] });
                searchDay1MCDZH.Items.Add(customElement0);
            }
            imageLayer0.Data = searchDay1MCDZH;
        }
        public void paintPoint0SIV()
        {
            List<string> toado = objToado.xulyDiem(objToado.ListsearchDZPoint0SIV);
            VectorItemsLayer imageLayer0 = new VectorItemsLayer();
            mcSoDo1Soi.Layers.Add(imageLayer0);
            searchDay0SIV = new MapItemStorage();
            //var image0 = new Bitmap(@"..//..//icon//SI_open.png");
            var image0 = new Bitmap(@"icon\SI_open.png");
            for (int i = 0; i < toado.Count; i++)
            {
                MapCustomElement customElement0 = new MapCustomElement();
                string[] xy = toado[i].Trim().Split(' ');
                double x = Convert.ToDouble(xy[0]);
                double y = Convert.ToDouble(xy[1]);
                customElement0.Location = new GeoPoint(x, y);
                customElement0.ToolTipPattern = objToado.ListSearchNameSI0V[i].ToString();
                customElement0.Image = new Bitmap(image0);
                customElement0.ImageIndex = i;
                customElement0.RenderOrigin = new MapPoint(0.5, 1);
                customElement0.Padding = new System.Windows.Forms.Padding(0);
                customElement0.Attributes.Add(new MapItemAttribute { Name = "SI0V", Value = objToado.ListSearchIDSI0V[i] });
                searchDay0SIV.Items.Add(customElement0);
            }
            imageLayer0.Data = searchDay0SIV;
        }
        public void paintPoint0SIH()
        {
            List<string> toado = objToado.xulyDiem(objToado.ListsearchDZPoint0SIH);
            VectorItemsLayer imageLayer0 = new VectorItemsLayer();
            mcSoDo1Soi.Layers.Add(imageLayer0);
            searchDay0SIH = new MapItemStorage();
            //var image0 = new Bitmap(@"..//..//icon//SI_open.png");
            var image0 = new Bitmap(@"icon\SI_open.png");
            for (int i = 0; i < toado.Count; i++)
            {
                MapCustomElement customElement0 = new MapCustomElement();
                string[] xy = toado[i].Trim().Split(' ');
                double x = Convert.ToDouble(xy[0]);
                double y = Convert.ToDouble(xy[1]);
                customElement0.Location = new GeoPoint(x, y);
                customElement0.ToolTipPattern = objToado.ListSearchNameSI1H[i].ToString();
                customElement0.Image = new Bitmap(image0);
                customElement0.ImageIndex = i;
                customElement0.RenderOrigin = new MapPoint(0.5, 1);
                customElement0.Padding = new System.Windows.Forms.Padding(0);
                customElement0.Attributes.Add(new MapItemAttribute { Name = "SI0H", Value = objToado.ListSearchIDSI1H[i] });
                searchDay0SIH.Items.Add(customElement0);
            }
            imageLayer0.Data = searchDay0SIH;
        }
        public void paintPoint1SIV()
        {
            List<string> toado = objToado.xulyDiem(objToado.ListsearchDZPoint1SIV);
            VectorItemsLayer imageLayer0 = new VectorItemsLayer();
            mcSoDo1Soi.Layers.Add(imageLayer0);
            searchDay1SIV = new MapItemStorage();
            var image0 = new Bitmap(@"icon\SI_close.png");
            for (int i = 0; i < toado.Count; i++)
            {
                MapCustomElement customElement0 = new MapCustomElement();
                string[] xy = toado[i].Trim().Split(' ');
                double x = Convert.ToDouble(xy[0]);
                double y = Convert.ToDouble(xy[1]);
                customElement0.Location = new GeoPoint(x, y);
                customElement0.ToolTipPattern = objToado.ListSearchNameSI1V[i].ToString();
                customElement0.Image = new Bitmap(image0);
                customElement0.ImageIndex = i;
                customElement0.RenderOrigin = new MapPoint(0.5, 1);
                customElement0.Padding = new System.Windows.Forms.Padding(0);
                customElement0.Attributes.Add(new MapItemAttribute { Name = "SI1V", Value = objToado.ListSearchIDSI1V[i] });
                searchDay1SIV.Items.Add(customElement0);
            }
            imageLayer0.Data = searchDay1SIV;
        }
        public void paintPoint1SIH()
        {
            List<string> toado = objToado.xulyDiem(objToado.ListsearchDZPoint1SIH);
            VectorItemsLayer imageLayer0 = new VectorItemsLayer();
            mcSoDo1Soi.Layers.Add(imageLayer0);
            searchDay1SIH = new MapItemStorage();
            var image0 = new Bitmap(@"icon\SI_close.png");
            for (int i = 0; i < toado.Count; i++)
            {
                MapCustomElement customElement0 = new MapCustomElement();
                string[] xy = toado[i].Trim().Split(' ');
                double x = Convert.ToDouble(xy[0]);
                double y = Convert.ToDouble(xy[1]);
                customElement0.Location = new GeoPoint(x, y);
                customElement0.ToolTipPattern = objToado.ListSearchNameSI1H[i].ToString();
                customElement0.Image = new Bitmap(image0);
                customElement0.ImageIndex = i;
                customElement0.RenderOrigin = new MapPoint(0.5, 1);
                customElement0.Padding = new System.Windows.Forms.Padding(0);
                customElement0.Attributes.Add(new MapItemAttribute { Name = "SI1H", Value = objToado.ListSearchIDSI1H[i] });
                searchDay1SIH.Items.Add(customElement0);
            }
            imageLayer0.Data = searchDay1SIH;
        }
        public void paintPoint0TGV()
        {
            List<string> toado = objToado.xulyDiem(objToado.ListsearchDZPoint0TGV);
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
                customElement0.ToolTipPattern = objToado.ListSearchNameTG0V[i].ToString();
                customElement0.Image = new Bitmap(image0);
                customElement0.ImageIndex = i;
                customElement0.RenderOrigin = new MapPoint(0.5, 1);
                customElement0.Padding = new System.Windows.Forms.Padding(0);
                customElement0.Attributes.Add(new MapItemAttribute { Name = "TG0V", Value = objToado.ListSearchIDTG0V[i] });
                searchDay0TGV.Items.Add(customElement0);
            }
            imageLayer0.Data = searchDay0TGV;
        }
        public void paintPoint0TGH()
        {
            List<string> toado = objToado.xulyDiem(objToado.ListsearchDZPoint0TGH);
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
                customElement0.ToolTipPattern = objToado.ListSearchNameTG0H[i].ToString();
                customElement0.Image = new Bitmap(image0);
                customElement0.ImageIndex = i;
                customElement0.RenderOrigin = new MapPoint(0.5, 1);
                customElement0.Padding = new System.Windows.Forms.Padding(0);
                customElement0.Attributes.Add(new MapItemAttribute { Name = "TG0H", Value = objToado.ListSearchIDTG1H[i] });
                searchDay0TGH.Items.Add(customElement0);
            }
            imageLayer0.Data = searchDay0TGH;
        }
        public void paintPoint1TGV()
        {
            List<string> toado = objToado.xulyDiem(objToado.ListsearchDZPoint1TGV);
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
                customElement0.ToolTipPattern = objToado.ListSearchNameTG1V[i].ToString();
                customElement0.Image = new Bitmap(image0);
                customElement0.ImageIndex = i;
                customElement0.RenderOrigin = new MapPoint(0.5, 1);
                customElement0.Padding = new System.Windows.Forms.Padding(0);
                customElement0.Attributes.Add(new MapItemAttribute { Name = "TG1V", Value = objToado.ListSearchIDTG1V[i] });
                searchDay1TGV.Items.Add(customElement0);
            }
            imageLayer0.Data = searchDay1TGV;
        }
        public void paintPoint1TGH()
        {
            List<string> toado = objToado.xulyDiem(objToado.ListsearchDZPoint1TGH);
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
                customElement0.ToolTipPattern = objToado.ListSearchNameTG1H[i].ToString();
                customElement0.Image = new Bitmap(image0);
                customElement0.ImageIndex = i;
                customElement0.RenderOrigin = new MapPoint(0.5, 1);
                customElement0.Padding = new System.Windows.Forms.Padding(0);
                customElement0.Attributes.Add(new MapItemAttribute { Name = "TG1H", Value = objToado.ListSearchIDTG1H[i] });
                searchDay1TGH.Items.Add(customElement0);
            }
            imageLayer0.Data = searchDay1TGH;
        }
        public void paintPoint0MCV()
        {
            Console.WriteLine("vao day");
            List<string> toado = objToado.xulyDiem(objToado.ListsearchDZPoint0MCV);
            for (int i = 0; i < toado.Count; i++)
            {
                Console.WriteLine("vao day1");
                string[] xy = toado[i].Trim().Split(' ');
                double x = Convert.ToDouble(xy[0]);
                double y = Convert.ToDouble(xy[1]); Console.WriteLine("â"+xy +""+objToado.ListSearchIDMC0V[i]+""+ objToado.ListSearchNameMC0V[i].ToString());
                //paintPolyMC(x, y, true, false, true, objToado.ListSearchIDMC0V[i], objToado.ListSearchNameMC0V[i].ToString());
            }
        }
        public void paintPoint0MCH()
        {
            List<string> toado = objToado.xulyDiem(objToado.ListsearchDZPoint0MCH);
            for (int i = 0; i < toado.Count; i++)
            {
                string[] xy = toado[i].Trim().Split(' ');
                double x = Convert.ToDouble(xy[0]);
                double y = Convert.ToDouble(xy[1]);
                paintPolyMC(x, y, false, false, true, objToado.ListSearchIDMC0H[i], objToado.ListSearchNameMC0H[i].ToString());
            }
        }
        public void paintPoint1MCV()
        {
            List<string> toado = objToado.xulyDiem(objToado.ListsearchDZPoint1MCV);
            VectorItemsLayer imageLayer0 = new VectorItemsLayer();
            for (int i = 0; i < toado.Count; i++)
            {
                string[] xy = toado[i].Trim().Split(' ');
                double x = Convert.ToDouble(xy[0]);
                double y = Convert.ToDouble(xy[1]);
                paintPolyMC(x, y, true, true, true, objToado.ListSearchIDMC1V[i], objToado.ListSearchNameMC1V[i].ToString());
            }
        }
        public void paintPoint1MCH()
        {
            List<string> toado = objToado.xulyDiem(objToado.ListsearchDZPoint1MCH);
            for (int i = 0; i < toado.Count; i++)
            {
                string[] xy = toado[i].Trim().Split(' ');
                double x = Convert.ToDouble(xy[0]);
                double y = Convert.ToDouble(xy[1]);
                paintPolyMC(x, y, false, true, true, objToado.ListSearchIDMC1H[i], objToado.ListSearchNameMC1H[i].ToString());
            }
        }
        public void paintPoint0CDV()
        {
            List<string> toado = objToado.xulyDiem(objToado.ListsearchDZPoint0CDV);
            for (int i = 0; i < toado.Count; i++)
            {
                string[] xy = toado[i].Trim().Split(' ');
                double x = Convert.ToDouble(xy[0]);
                double y = Convert.ToDouble(xy[1]);
                paintPolyMC(x, y, true, false, false, objToado.ListSearchIDCD0V[i], objToado.ListSearchNameCD0V[i].ToString());
            }
        }
        public void paintPoint0CDH()
        {
            List<string> toado = objToado.xulyDiem(objToado.ListsearchDZPoint0CDH);
            for (int i = 0; i < toado.Count; i++)
            {
                MapCustomElement customElement0 = new MapCustomElement();
                string[] xy = toado[i].Trim().Split(' ');
                double x = Convert.ToDouble(xy[0]);
                double y = Convert.ToDouble(xy[1]);
                paintPolyMC(x, y, true, false, false, objToado.ListSearchIDCD0H[i], objToado.ListSearchNameCD0H[i].ToString());
            }
        }
        public void paintPoint1CDV()
        {
            List<string> toado = objToado.xulyDiem(objToado.ListsearchDZPoint1CDV);
            for (int i = 0; i < toado.Count; i++)
            {
                string[] xy = toado[i].Trim().Split(' ');
                double x = Convert.ToDouble(xy[0]);
                double y = Convert.ToDouble(xy[1]);
                paintPolyMC(x, y, true, true, false, objToado.ListSearchIDCD1V[i], objToado.ListSearchNameCD1V[i]);
            }
        }
        public void paintPoint1CDH()
        {
            List<string> toado = objToado.xulyDiem(objToado.ListsearchDZPoint1CDH);
            for (int i = 0; i < toado.Count; i++)
            {
                string[] xy = toado[i].Trim().Split(' ');
                double x = Convert.ToDouble(xy[0]);
                double y = Convert.ToDouble(xy[1]);
                paintPolyMC(x, y, true, true, false, objToado.ListSearchIDCD1H[i], objToado.ListSearchNameCD1H[i].ToString());
            }
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (dem%2==0)
            {
                try
                {
                    searchDayWarning.Dispose();
                }
                catch (Exception)
                {
                    try
                    {
                        searchDayWarning.Items.Clear();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            else
            {
                paintLineWarning();
            }
            dem++;
        }

        private void checkBold_CheckedChanged(object sender, EventArgs e)
        {
            huydoituongSearchday();
            paintAll(dvql_cb, maCapda);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                dvql_cb = cbDonvi.EditValue.ToString();
                if (radio22.Checked==true)
                {
                    maCapda = "05";
                }
                else
                {
                    maCapda="06";
                }
                paintAll(dvql_cb, maCapda);
                panel5.Visible = true;
                panel4.Visible = true;
                panel6.Visible = true;
                panel7.Visible = true;
                btRefesh.Visible = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Bạn vui lòng chọn đơn vị");
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            huydoituongSearchday();
            paintAll(dvql_cb,maCapda);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                LDSong.Properties.Settings.Default.Color = "blue";
                color = Color.Blue;
                LDSong.Properties.Settings.Default.Save();
                refreshDZ();
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                LDSong.Properties.Settings.Default.Color = "green";
                color = Color.Green;
                LDSong.Properties.Settings.Default.Save();
                refreshDZ();
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
            {
                LDSong.Properties.Settings.Default.Color = "yellow";
                color = Color.Yellow;
                LDSong.Properties.Settings.Default.Save();
                refreshDZ();
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                LDSong.Properties.Settings.Default.Color = "yellowGreen";
                color = Color.YellowGreen;
                LDSong.Properties.Settings.Default.Save();
                refreshDZ();
            }
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton7.Checked)
            {
                LDSong.Properties.Settings.Default.Color = "red";
                color = Color.Red;
                LDSong.Properties.Settings.Default.Save();
                refreshDZ();
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked)
            {
                LDSong.Properties.Settings.Default.Color = "violet";
                color = Color.Violet;
                LDSong.Properties.Settings.Default.Save();
                refreshDZ();
            }
        }

        private void mcSoDo1Soi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Int32)Keys.Enter)
            {
                if (stMove)
                {
                    stMove = false;
                    stV = false;
                    stH = false;
                }
                else
                {
                    stMove = true;
                }
            }
            else
            {
                if (e.KeyChar == (Int32)Keys.N)
                {
                    stH = true;
                    stV = false;
                }
                else
                {
                    if (e.KeyChar == (Int32)Keys.D)
                    {
                        stV = true;
                        stH = false;
                    }
                    else
                    {
                        if (e.KeyChar==(Int32)Keys.Escape)
                        {
                            itemstorePolie.Items.Clear();
                            itemstorePolieYellow.Items.Clear();
                            toadoLineDZ = "";
                            dem = 0;
                            //btXoaPin.Visible = false;
                            stV = false;
                            stH = false;
                        }
                        else
                        {
                            stV = false;
                            stH = false;
                        }
                    }
                }
            }
        }
        

        private void ImageTilesLayer_ViewportChanged(object sender, DevExpress.XtraMap.ViewportChangedEventArgs e)
        {

        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton8.Checked)
            {
                size = 1;
                refreshDZ();
            }
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton9.Checked)
            {
                size = 2;
                refreshDZ();
            }
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton10.Checked)
            {
                size = 3;
                refreshDZ();
            }
        }
        private void refreshDZ() {
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
            if (objToado.ListsearchDZLine22.Count != 0)
            {
                paintLine22(size);
            }
            if (objToado.ListsearchDZLine35.Count != 0)
            {
                paintLine35(size);
            }
        }

        private void btTaoKhung_Click(object sender, EventArgs e)
        {
            if (btTaoKhung.Text.Equals("Tạo khung"))
            {
                paintKhung();
                btTaoKhung.Text = "Xóa khung";
            }
            else
            {
                try
                {
                    paintKH.Dispose();
                    btTaoKhung.Text = "Tạo khung";
                }
                catch (Exception)
                {
                    
                }
            }
        }

        private void checkDefaultFont_CheckedChanged(object sender, EventArgs e)
        {
            if (checkDefaultFont.Checked)
            {
                textSireFont.Enabled = true;
                btSetDefault.Enabled = true;
                textSireFont.Text = LDSong.Properties.Settings.Default.SireFont.ToString();
                LDSong.Properties.Settings.Default.SireFontDefault = true;
                LDSong.Properties.Settings.Default.Save();
                sizeFont = LDSong.Properties.Settings.Default.SireFont;
                mapNote.Dispose();
                paintPointNote(false);
            }
            else
            {
                textSireFont.Enabled = false;
                btSetDefault.Enabled = false;
                LDSong.Properties.Settings.Default.SireFontDefault = false;
                LDSong.Properties.Settings.Default.Save();
                mapNote.Dispose();
                paintPointNote(true);
            }
        }

        private void btSetDefault_Click(object sender, EventArgs e)
        {
            
            try
            {
                int sire = int.Parse(textSireFont.Text);
                if (sire>0&&sire<21)
                {
                    LDSong.Properties.Settings.Default.SireFont = sire;
                    LDSong.Properties.Settings.Default.Save();
                    mapNote.Dispose();
                    paintPointNote(false);
                    MessageBox.Show("Thiết lập độ rộng font thành công.");
                }
                else
                {
                    MessageBox.Show("Bạn vui lòng nhập độ rộng font lớn hơn 0 và nhỏ hơn 21.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Bạn vui lòng nhập số.");
            }
        }

        private void textSireFont_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
