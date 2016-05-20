using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/**********************************************************************************     
     * Created by  Yao  on  5/20/2016 5:17:41 PM     
     * README:自定义字体的配置工具
     * ============================================================================
     * CHANGELOG：
    ********************************************************************************/
namespace iCarto.common.utils
{
    public class CustomFontsManager
    {

        public ArrayList prepareLabels(Label[] labels)
        {
            ArrayList labelsArrayList = new ArrayList();
            foreach (var item in labels)
            {
                labelsArrayList.Add(item);
            }
            return labelsArrayList;
        }


        public FontFamily loadFonts()
        {
            PrivateFontCollection pfc = new PrivateFontCollection();
            string fontPath = @"C:\Users\Yao\Documents\Visual Studio 2012\Projects\iCarto\iCarto\res\fonts\SourceHanSansSC-Normal.ttf";

            try
            {

                pfc.AddFontFile(fontPath);//字体的路径及名字 

            }
            catch (Exception)
            {

                MessageBox.Show("字体不存在或加载失败\n程序将以默认字体显示", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

            //Font f = new Font(pfc.Families[0], 14);
            return pfc.Families[0];

        }




    }
}