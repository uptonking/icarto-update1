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


        //��ʽ��
        IStyleGallery styleGallery;
        //��ʽ�ֿ�
        IStyleGalleryStorage styleGalleryStorage;
        //��ǰ��ʽ��
        private string CurrentStyleGalleryClass = "";
        //��ǰ��ʽ������
        private int CurrentStyleGalleryClassIndex = -1;
        //��ǰ��ʽ�ֿ���
        private string CurrentCategoryName;
        //��ǰ��ʽ����
        private string CurrentStyleFile;
        //��ǰlistview����ʽ��
        private int CurrentListViewIndex = -1;
        //��ʽתͼƬ��
        ConvertClass convertClass;
        //��ʽ�ļ���
        public string filename;
        //��ʽ�ļ�·��
        public string filePath;
        //��ǰѡ��Ľڵ�
        TreeNode CurNode;

        //������ʽ�ļ�.StyleServer·��
        string styleFilePath;

        public StyleDemoForm()
        {
            ESRI.ArcGIS.RuntimeManager.Bind(ESRI.ArcGIS.ProductCode.EngineOrDesktop);
            ESRI.ArcGIS.RuntimeManager.BindLicense(ESRI.ArcGIS.ProductCode.EngineOrDesktop);
            InitializeComponent();

            convertClass = new ConvertClass();


            //��ȡ����ʾ.StyleServer�ļ�
            showStyleSymbols();

            m_mapControl = (IMapControl3)axMapControl1.Object;
            initBasemap();

        }

        private void showStyleSymbols()
        {
            //��ȡ.styleserver�ļ�·��
            styleFilePath = getStyleFilePath();

            styleGallery = new ServerStyleGalleryClass();
            styleGalleryStorage = styleGallery as IStyleGalleryStorage;
            //�ж��Ƿ��Ѿ����ص����Ϳؼ�
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
                //���ø��ڵ�
                System.IO.FileInfo fileinfo = new System.IO.FileInfo(styleFilePath);
                TreeNode rootNode = new TreeNode(fileinfo.Name);
                rootNode.Tag = fileinfo.FullName;
                this.tvStyleNode.Nodes.Add(rootNode);
                //���ظ������͵���ʽĿ¼�����ؼ�
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

        //��listview��Ԥ����ʽ����
        private void PreviewSymbols(string StyleFile, string StyleGalleryClass)
        {
            //����ö�ٽӿ�
            ESRI.ArcGIS.Display.IEnumStyleGalleryItem enumStyleItem;
            //�������Ŷ���
            ESRI.ArcGIS.Display.IStyleGalleryItem styleItem;
            //�ж��ǳ��μ�����ʽ�ļ������µ���ʽ�ļ�
            if (StyleFile != this.CurrentStyleFile)
            {
                //���õ�ǰ��ʽ�ļ�
                this.CurrentStyleFile = StyleFile;
                //���õ�ǰ��ʽ����
                this.CurrentStyleGalleryClass = StyleGalleryClass;
                //���÷�����ʽ�ļ�λ��
                this.styleGalleryStorage = styleGallery as ESRI.ArcGIS.Display.IStyleGalleryStorage;
                this.styleGalleryStorage.AddFile(this.CurrentStyleFile);
                //��ȡö�ٵķ���
                enumStyleItem = this.styleGallery.get_Items(this.CurrentStyleGalleryClass, this.CurrentStyleFile, "");
            }
            else
            {
                //���õ�ǰѡ��ķ�������
                CurrentStyleGalleryClass = StyleGalleryClass;
                //��ȡö�ٵķ���
                enumStyleItem = this.styleGallery.get_Items(CurrentStyleGalleryClass, this.CurrentStyleFile, CurrentCategoryName);
            }
            //����LISTVIEW�Ĵ�ͼ�ꡢСͼ��
            System.Windows.Forms.ImageList largeImage = new ImageList();
            System.Windows.Forms.ImageList smallImage = new ImageList();
            largeImage.ImageSize = new Size(32, 32);
            smallImage.ImageSize = new Size(16, 16);
            System.Drawing.Bitmap bmpB, bmpS;
            System.Windows.Forms.ListViewItem lvItem;
            this.lvSymbolView.Items.Clear();
            this.lvSymbolView.Columns.Clear();
            //����LISTVIEW������ʽ
            this.lvSymbolView.LargeImageList = largeImage;
            this.lvSymbolView.SmallImageList = smallImage;
            this.lvSymbolView.Columns.Add("Name", 180, System.Windows.Forms.HorizontalAlignment.Left);
            this.lvSymbolView.Columns.Add("Index", 50, System.Windows.Forms.HorizontalAlignment.Left);
            this.lvSymbolView.Columns.Add("Category", 120, System.Windows.Forms.HorizontalAlignment.Left);
            //����ö�ٵ�λ��
            enumStyleItem.Reset();
            //��ȡ��һ������
            styleItem = enumStyleItem.Next();
            int ImageIndex = 0;
            //��ȡ��ǰ��ʽ��
            ESRI.ArcGIS.Display.IStyleGalleryClass styleClass = styleGallery.get_Class(CurrentStyleGalleryClassIndex);
            while (styleItem != null)
            {
                //���ɷ��ŵ�ͼƬԤ��
                bmpB = convertClass.StyleGalleryItemToBmp(32, 32, styleClass, styleItem);
                bmpS = convertClass.StyleGalleryItemToBmp(16, 16, styleClass, styleItem);
                //��ӵ��ؼ���ͼ���б�
                largeImage.Images.Add(bmpB);
                smallImage.Images.Add(bmpS);
                //��ʼ��LISTVIEW������
                lvItem = new ListViewItem(new string[] { styleItem.Name, styleItem.ID.ToString(), styleItem.Category }, ImageIndex);
                this.lvSymbolView.Items.Add(lvItem);
                styleItem = enumStyleItem.Next();
                ImageIndex++;
            }
            //�ͷŷ���ö�٣�ע�⣬������ͷ��п������´μ��ص�ʱ������޷�����
            System.Runtime.InteropServices.Marshal.ReleaseComObject(enumStyleItem);
        }

        //ѡ����ʽ����
        private void tvStyleNode_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = this.tvStyleNode.SelectedNode;
            //�жϽڵ㲻Ϊ�գ����Ҳ��Ǹ��ڵ�
            if (node != null && node.Parent != null)
            {
                //���õ�ǰ��ʽ��������
                this.CurrentStyleGalleryClassIndex = int.Parse(node.Tag.ToString());
                //�����ż�����LISTVIEW��Ԥ��
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
                            axMapControl1.Map.SelectByShape(pGeometry, null, true);//����������Ϊ�Ƿ�ֻѡ��һ��
                            axMapControl1.Refresh(esriViewDrawPhase.esriViewGeoSelection, null, null); //ѡ��Ҫ�ظ�����ʾ
                        }

            #region ���÷���
            //pMap = axMapControl1.Map;

            //pActiveView = pMap as IActiveView;

            ////ͨ����꣬ȡ��һ�������߶���
            //IEnvelope pEnvelope = axMapControl1.TrackRectangle();

            //// ����һ���»���
            //ISelectionEnvironment pSelectionEnv = new SelectionEnvironmentClass();

            //// �ٸı�ԭ��Ҫ�ص���ɫֵ
            //pSelectionEnv.DefaultColor = GetRGB(255, 112, 67);

            //pMap.SelectByShape(pEnvelope, pSelectionEnv, true);
            //pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
            //MessageBox.Show("�Ƿ���ķ���","ȷ�ϣ�",MessageBoxButtons.YesNo);
            #endregion
        }



        //������ɫ����
        private IRgbColor GetRGB(int r, int g, int b)
        {

            //����IRgbColor �ӿڣ��ֱ�����R��G��B����ֵ����
            IRgbColor pRgbColor = new RgbColorClass();

            pRgbColor.Red = r;
            pRgbColor.Green = g;
            pRgbColor.Blue = b;

            //���ض���ֵ
            return pRgbColor;


        }

    }
}