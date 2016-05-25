using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iCarto.tests
{
    public partial class AOForm : Form
    {
        public AOForm()
        {

            InitializeComponent();

            //MapControl显示shapefile
            string lhkRailFilePath = @"C:\Users\Yao\Documents\Visual Studio 2012\Projects\iCarto\iCarto\res\data\lhk行政驻地点shapefileUpdate\";
            string lhkRailFileName = @"govpoi";
            mainAxMapControl.AddShapeFile(lhkRailFilePath, lhkRailFileName);


        }

        ///<summary>
        ///获取符号库中符号
        ///</summary>
        ///<param name="sServerStylePath">符号库全路径名称</param>
        ///<param name="sGalleryClassName">GalleryClass名称</param>
        ///<param name="symbolName">符号名称</param>
        ///<returns>符号</returns>
        public ISymbol GetSymbol(string sServerStylePath, string sGalleryClassName, string symbolName)
        {

            try
            {

                //ServerStyleGallery对象
                IStyleGallery pStyleGaller = new ServerStyleGalleryClass();
                IStyleGalleryStorage pStyleGalleryStorage = pStyleGaller as IStyleGalleryStorage;
                IEnumStyleGalleryItem pEnumSyleGalleryItem = null;
                IStyleGalleryItem pStyleGallerItem = null;
                IStyleGalleryClass pStyleGalleryClass = null;

                //使用IStyleGalleryStorage接口的AddFile方法加载ServerStyle文件
                pStyleGalleryStorage.AddFile(sServerStylePath);

                //遍历ServerGallery中的Class
                for (int i = 0; i < pStyleGaller.ClassCount; i++)
                {

                    pStyleGalleryClass = pStyleGaller.get_Class(i);

                    if (pStyleGalleryClass.Name != sGalleryClassName)

                        continue;

                    //获取EnumStyleGalleryItem对象
                    pEnumSyleGalleryItem = pStyleGaller.get_Items(sGalleryClassName, sServerStylePath, "");
                    pEnumSyleGalleryItem.Reset();

                    //遍历pEnumSyleGalleryItem
                    pStyleGallerItem = pEnumSyleGalleryItem.Next();
                    while (pStyleGallerItem != null)
                    {

                        if (pStyleGallerItem.Name == symbolName)
                        {
                            //获取符号
                            ISymbol pSymbol = pStyleGallerItem.Item as ISymbol;
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(pEnumSyleGalleryItem);
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(pStyleGalleryClass);
                            return pSymbol;
                        }
                        pStyleGallerItem = pEnumSyleGalleryItem.Next();
                    }
                }
                System.Runtime.InteropServices.Marshal.ReleaseComObject(pEnumSyleGalleryItem);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(pStyleGalleryClass);
                return null;
            }
            catch (Exception Err)
            {
                MessageBox.Show(Err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }

        }


        ///<summary>
        ///设置要素图层唯一值符号化
        ///</summary>
        ///<param name="pFeatureLayer"></param>
        public void UniqueValueRenderFlyr(IFeatureLayer pFeatureLayer)
        {
            string stylePath = @"C:\Users\Yao\Documents\Visual Studio 2012\Projects\iCarto\iCarto\res\symbols\jinyao.ServerStyle";

            try
            {
                //创建UniqueValueRendererClass对象
                IUniqueValueRenderer pUVRender = new UniqueValueRendererClass();

                //存储所需.style样式的符号名
                List<string> pFieldValues = new List<string>();
                pFieldValues.Add("乡镇级政府");
                pFieldValues.Add("cpc_marker");

                //获取所需的符号名的符号
                for (int i = 0; i < pFieldValues.Count; i++)
                {
                    ISymbol pSymbol = new SimpleMarkerSymbolClass();
                    pSymbol = GetSymbol(stylePath, "Marker Symbols", pFieldValues[i]);
                    //添加唯一值符号化字段值和相对应的符号
                    pUVRender.AddValue(pFieldValues[i], pFieldValues[i], pSymbol);
                }

                //设置要素属性表中唯一值符号化的字段个数和字段名
                pUVRender.FieldCount = 1;
                pUVRender.set_Field(0, "SymMatcher");

                IGeoFeatureLayer pGFeatureLyr = pFeatureLayer as IGeoFeatureLayer;

                //设置IGeofeatureLayer的Renderer属性
                pGFeatureLyr.Renderer = pUVRender as IFeatureRenderer;
            }

            catch (Exception Err)
            {
                MessageBox.Show(Err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        public void formatPainterBtn_Click(object sender, EventArgs e)
        {
            IFeatureLayer pFeatureLayer = this.mainAxMapControl.get_Layer(0) as IFeatureLayer;
            UniqueValueRenderFlyr(pFeatureLayer);
            this.mainAxMapControl.Refresh();
        }
    }
}
