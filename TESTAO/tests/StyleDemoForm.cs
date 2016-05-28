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

        private IMap pMap;

        private IActiveView pActiveView;

        private bool hasSelected = false;

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
        public string fileName;
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

            tvPanel.Left = 0;
            symPickerPanel.Left = -200;

            showServerStyleBtn.ForeColor = Color.FromArgb(255, 112, 67);
            startMapPainterBtn.ForeColor = Color.FromArgb(32, 32, 32);

            //��ȡ����ʾ.StyleServer�ļ�
            showStyleSymbols();

        }

        private void startMapPainterBtn_Click(object sender, EventArgs e)
        {
            mapPainterPanel.Left = 200;
            showStylePanel.Left = 800;

            tvPanel.Left = -200;
            symPickerPanel.Left = 0;

            startMapPainterBtn.ForeColor = Color.FromArgb(255, 112, 67);
            showServerStyleBtn.ForeColor = Color.FromArgb(32, 32, 32);
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

            pMap = axMapControl1.Map;

            pActiveView = pMap as IActiveView;

            if (hasSelected)
            {
                axMapControl1.Map.ClearSelection();
                hasSelected = false;
            }
            else
            {
                IPoint pPoint = new PointClass();
                pPoint.PutCoords(e.mapX, e.mapY);
                pTopo = pPoint as ITopologicalOperator;

                //���㴦�뾶1.11m
                double m_Radius = 0.00001;

                pGeometry = pTopo.Buffer(m_Radius);

                //����������Ϊ�Ƿ�ֻѡ��һ��
                pMap.SelectByShape(pGeometry, null, true);
                pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null); //ѡ��Ҫ�ظ�����ʾ
                hasSelected = true;

                if (MessageBox.Show("�Ƿ���ķ���", "ȷ�ϣ�", MessageBoxButtons.YesNo) == DialogResult
 .Yes)
                {
                    Render4rdLayer("green_accent");
                }
                else
                {
                    //nothing 
                }



            }
        }

        private void pgreen_Click(object sender, EventArgs e)
        {
            Render4rdLayer("green_accent");

            //// ��ȡѡ��
            //ISelection pSelection = axMapControl1.Map.FeatureSelection;

            //// �����Ա�ǩ

            //IEnumFeatureSetup pEnumFeatureSetup = pSelection as IEnumFeatureSetup;

            //pEnumFeatureSetup.AllFields = true;

            //IEnumFeature pEnumFeature = pSelection as IEnumFeature;

            //IFeature pFeature = pEnumFeature.Next();


            //while (pFeature != null)
            //{

            //    MessageBox.Show(pFeature.Fields.get_Field(5).Name);

            //    pFeature = pEnumFeature.Next();

            //}


        }

        private void pred_Click(object sender, EventArgs e)
        {
            Render4rdLayer("circle_transparent");
        }

        public void Render4rdLayer(string strSymName)
        {
            IFeatureLayer pFeatureLayer = this.axMapControl1.get_Layer(3) as IFeatureLayer;
            SymbolPainterHelper.UniqueValueRenderFlyr(pFeatureLayer, getStyleFilePath(), strSymName);
            this.axMapControl1.Refresh();
        }

    }
}