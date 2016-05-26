using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TESTAO.tests;

namespace TESTAO
{
    public partial class StyleDemoForm : Form
    {
        private IMapControl3 m_mapControl = null;
         IMap pMap;

            IActiveView pActiveView;


        //样式集
        IStyleGallery styleGallery;
        //样式仓库
        IStyleGalleryStorage styleGalleryStorage;
        //当前样式类
        private string CurrentStyleGalleryClass = "";
        //当前样式类索引
        private int CurrentStyleGalleryClassIndex = -1;
        //当前样式仓库名
        private string CurrentCategoryName;
        //当前样式符号
        private string CurrentStyleFile;
        //当前listview中样式项
        private int CurrentListViewIndex = -1;
        //样式转图片类
        ConvertClass convertClass;
        //样式文件名
        public string filename;
        //样式文件路径
        public string filePath;
        //当前选择的节点
        TreeNode CurNode;

        //符号样式文件.StyleServer路径
        string styleFilePath;

        public StyleDemoForm()
        {
            ESRI.ArcGIS.RuntimeManager.Bind(ESRI.ArcGIS.ProductCode.EngineOrDesktop);
            ESRI.ArcGIS.RuntimeManager.BindLicense(ESRI.ArcGIS.ProductCode.EngineOrDesktop);
            InitializeComponent();

            convertClass = new ConvertClass();


            //读取并显示.StyleServer文件
            showStyleSymbols();

            m_mapControl = (IMapControl3)axMapControl1.Object;
            initBasemap();

        }

        private void showStyleSymbols()
        {
            //获取.styleserver文件路径
            styleFilePath = getStyleFilePath();

            styleGallery = new ServerStyleGalleryClass();
            styleGalleryStorage = styleGallery as IStyleGalleryStorage;
            //判断是否已经加载到树型控件
            bool isExist = false;
            foreach (TreeNode node in this.tvStyleNode.Nodes)
            {
                if (node.Tag.ToString() == styleFilePath)
                {
                    isExist = true;
                }
            }
            if (!isExist)
            {
                //设置根节点
                System.IO.FileInfo fileinfo = new System.IO.FileInfo(styleFilePath);
                TreeNode rootNode = new TreeNode(fileinfo.Name);
                rootNode.Tag = fileinfo.FullName;
                this.tvStyleNode.Nodes.Add(rootNode);
                //加载各种类型的样式目录到树控件
                for (int i = 0; i < this.styleGallery.ClassCount; i++)
                {
                    TreeNode node = new TreeNode(this.styleGallery.get_Class(i).Name);
                    node.Tag = i;
                    rootNode.Nodes.Add(node);
                }
                this.tvStyleNode.ExpandAll();
            }



        }

        private string getStyleFilePath()
        {
            string rootPath = System.Windows.Forms.Application.StartupPath + @"../../../";
            System.IO.Directory.SetCurrentDirectory(rootPath);
            string styleFPath = System.IO.Directory.GetCurrentDirectory() + @"\res\data\jinyao.ServerStyle";
            return styleFPath;
        }

        public void initBasemap()
        {

            string path = System.Windows.Forms.Application.StartupPath + @"../../../";
            System.IO.Directory.SetCurrentDirectory(path);
            string mapPath = System.IO.Directory.GetCurrentDirectory() + @"\res\data\testmxd.mxd";

            m_mapControl.LoadMxFile(mapPath);
        }

        private void showServerStyleBtn_Click(object sender, EventArgs e)
        {

            showStylePanel.Left = 200;
            mapPainterPanel.Left = 800;



        }

        private void startMapPainter_Click(object sender, EventArgs e)
        {
            mapPainterPanel.Left = 200;
            showStylePanel.Left = 800;
        }

        //在listview中预览样式符号
        private void PreviewSymbols(string StyleFile, string StyleGalleryClass)
        {
            //符号枚举接口
            ESRI.ArcGIS.Display.IEnumStyleGalleryItem enumStyleItem;
            //单个符号对象
            ESRI.ArcGIS.Display.IStyleGalleryItem styleItem;
            //判断是初次加载样式文件，或新的样式文件
            if (StyleFile != this.CurrentStyleFile)
            {
                //设置当前样式文件
                this.CurrentStyleFile = StyleFile;
                //设置当前样式类型
                this.CurrentStyleGalleryClass = StyleGalleryClass;
                //设置符号样式文件位置
                this.styleGalleryStorage = styleGallery as ESRI.ArcGIS.Display.IStyleGalleryStorage;
                this.styleGalleryStorage.AddFile(this.CurrentStyleFile);
                //获取枚举的符号
                enumStyleItem = this.styleGallery.get_Items(this.CurrentStyleGalleryClass, this.CurrentStyleFile, "");
            }
            else
            {
                //设置当前选择的符号类型
                CurrentStyleGalleryClass = StyleGalleryClass;
                //获取枚举的符号
                enumStyleItem = this.styleGallery.get_Items(CurrentStyleGalleryClass, this.CurrentStyleFile, CurrentCategoryName);
            }
            //设置LISTVIEW的大图标、小图标
            System.Windows.Forms.ImageList largeImage = new ImageList();
            System.Windows.Forms.ImageList smallImage = new ImageList();
            largeImage.ImageSize = new Size(32, 32);
            smallImage.ImageSize = new Size(16, 16);
            System.Drawing.Bitmap bmpB, bmpS;
            System.Windows.Forms.ListViewItem lvItem;
            this.lvSymbolView.Items.Clear();
            this.lvSymbolView.Columns.Clear();
            //设置LISTVIEW的列样式
            this.lvSymbolView.LargeImageList = largeImage;
            this.lvSymbolView.SmallImageList = smallImage;
            this.lvSymbolView.Columns.Add("Name", 180, System.Windows.Forms.HorizontalAlignment.Left);
            this.lvSymbolView.Columns.Add("Index", 50, System.Windows.Forms.HorizontalAlignment.Left);
            this.lvSymbolView.Columns.Add("Category", 120, System.Windows.Forms.HorizontalAlignment.Left);
            //重设枚举的位置
            enumStyleItem.Reset();
            //获取第一个符号
            styleItem = enumStyleItem.Next();
            int ImageIndex = 0;
            //获取当前样式类
            ESRI.ArcGIS.Display.IStyleGalleryClass styleClass = styleGallery.get_Class(CurrentStyleGalleryClassIndex);
            while (styleItem != null)
            {
                //生成符号的图片预览
                bmpB = convertClass.StyleGalleryItemToBmp(32, 32, styleClass, styleItem);
                bmpS = convertClass.StyleGalleryItemToBmp(16, 16, styleClass, styleItem);
                //添加到控件的图标列表
                largeImage.Images.Add(bmpB);
                smallImage.Images.Add(bmpS);
                //初始化LISTVIEW的子项
                lvItem = new ListViewItem(new string[] { styleItem.Name, styleItem.ID.ToString(), styleItem.Category }, ImageIndex);
                this.lvSymbolView.Items.Add(lvItem);
                styleItem = enumStyleItem.Next();
                ImageIndex++;
            }
            //释放符号枚举，注意，如果不释放有可能在下次加载的时候出错，无法加载
            System.Runtime.InteropServices.Marshal.ReleaseComObject(enumStyleItem);
        }

        //选择样式类型
        private void tvStyleNode_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = this.tvStyleNode.SelectedNode;
            //判断节点不为空，并且不是根节点
            if (node != null && node.Parent != null)
            {
                //设置当前样式类型索引
                this.CurrentStyleGalleryClassIndex = int.Parse(node.Tag.ToString());
                //将符号加载在LISTVIEW中预览
                PreviewSymbols(node.Parent.Tag.ToString(), node.Text);
                CurNode = node;
            }
        }

        private void axMapControl1_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {

            ITopologicalOperator pTopo;
                        IGeometry pGeometry;
                        IFeature pFeature;
                        IFeatureLayer pFeatureLayer;
                        DataTable dataTable;
                        
                        for (int i = 0; i < axMapControl1.Map.LayerCount; i++)
                        {
                            
                            IPoint pPoint = new PointClass();
                            pPoint.PutCoords(e.mapX, e.mapY);
                            pTopo = pPoint as ITopologicalOperator;
                            double m_Radius = 1;
                            pGeometry = pTopo.Buffer(m_Radius); 
                            if (pGeometry == null)
                                continue;
                            axMapControl1.Map.SelectByShape(pGeometry, null, true);//第三个参数为是否只选中一个
                            axMapControl1.Refresh(esriViewDrawPhase.esriViewGeoSelection, null, null); //选中要素高亮显示
                        }

            #region 备用方法
            //pMap = axMapControl1.Map;

            //pActiveView = pMap as IActiveView;

            ////通过鼠标，取得一个包络线对象
            //IEnvelope pEnvelope = axMapControl1.TrackRectangle();

            //// 设置一个新环境
            //ISelectionEnvironment pSelectionEnv = new SelectionEnvironmentClass();

            //// 再改变原来要素的颜色值
            //pSelectionEnv.DefaultColor = GetRGB(255, 112, 67);

            //pMap.SelectByShape(pEnvelope, pSelectionEnv, true);
            //pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
            //MessageBox.Show("是否更改符号","确认？",MessageBoxButtons.YesNo);
            #endregion
        }



        //定义颜色方法
        private IRgbColor GetRGB(int r, int g, int b)
        {

            //利用IRgbColor 接口，分别设置R、G、B三个值参数
            IRgbColor pRgbColor = new RgbColorClass();

            pRgbColor.Red = r;
            pRgbColor.Green = g;
            pRgbColor.Blue = b;

            //返回对象值
            return pRgbColor;


        }

    }
}