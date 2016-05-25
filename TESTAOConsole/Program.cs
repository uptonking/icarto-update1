using System;
using System.Collections.Generic;
using System.Text;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Framework;
using System.IO;

namespace TESTAOConsole
{
    class Program
    {
        private static LicenseInitializer m_AOLicenseInitializer = new TESTAOConsole.LicenseInitializer();

        //open desktop style gallery
        static private IStyleGallery _iStyleGallery = new StyleGalleryClass();
        //open server style gallery
        static private IStyleGallery _iServerStyleGallery = new ServerStyleGalleryClass();


        [STAThread()]
        static void Main(string[] args)
        {
            #region 输入.style文件所在文件夹路径
            if (args.Length == 0)
            {
                Console.WriteLine("A path to a folder with style files needs to be specified. Press ENTER to exit.");
                Console.ReadLine();

                //release underlying com objects
                ReleaseCOMObjects();

                return;
            }
            #endregion

            #region 初始化许可
            //ESRI License Initializer generated code.
            m_AOLicenseInitializer.InitializeApplication(new esriLicenseProductCode[] { esriLicenseProductCode.esriLicenseProductCodeAdvanced },
            new esriLicenseExtensionCode[] { esriLicenseExtensionCode.esriLicenseExtensionCode3DAnalyst, esriLicenseExtensionCode.esriLicenseExtensionCodeNetwork, esriLicenseExtensionCode.esriLicenseExtensionCodeSchematics, esriLicenseExtensionCode.esriLicenseExtensionCodeArcScan, esriLicenseExtensionCode.esriLicenseExtensionCodeBusiness, esriLicenseExtensionCode.esriLicenseExtensionCodeMLE, esriLicenseExtensionCode.esriLicenseExtensionCodeSpatialAnalyst, esriLicenseExtensionCode.esriLicenseExtensionCodeCOGO, esriLicenseExtensionCode.esriLicenseExtensionCodeGeoStats, esriLicenseExtensionCode.esriLicenseExtensionCodePublisher, esriLicenseExtensionCode.esriLicenseExtensionCodeDataInteroperability, esriLicenseExtensionCode.esriLicenseExtensionCodeTracking });
            //ESRI License Initializer generated code.
            
            #endregion

            


            try
            {
                String[] files = System.IO.Directory.GetFiles(args[0]);
                foreach (string file in files)
                {
                    //filter all *.style files and convert them into *.ServerStyle files 
                    string ext = Path.GetExtension(file).ToLower();
                    if (ext.Equals(".style"))
                        ConvertStyleFile(Path.Combine(args[0], file), Path.Combine(args[0], Path.GetFileNameWithoutExtension(file) + ".ServerStyle"));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                //release underlying com objects
                ReleaseCOMObjects();

                ESRI.ArcGIS.ADF.COMSupport.AOUninitialize.Shutdown();

                //ESRI License Initializer generated code.
                //Do not make any call to ArcObjects after ShutDownApplication()
                m_AOLicenseInitializer.ShutdownApplication();

                Console.WriteLine("Finished style file conversion. Press ENTER to exit.");
                Console.ReadLine();
            }

            
        }


        /// <summary>
        /// Converts a .style file into a .ServerStyle file.
        /// </summary>
        /// <param name="sourceFile">A path to a desktop style file such as "c:\mystyles\mystylefile.style".</param>
        /// <param name="targetFile">A path to a server style file such as "c:\mystyles\mystylefile.ServerStyle".</param>
        static private void ConvertStyleFile(string sourceFile, string targetFile)
        {
            //get the storage interfaces
            IStyleGalleryStorage iStyleGalleryStorage = (IStyleGalleryStorage)_iStyleGallery;
            IStyleGalleryStorage iServerStyleGalleryStorage = (IStyleGalleryStorage)_iServerStyleGallery;

            //clear both style galleries of contents
            _iStyleGallery.Clear();
            _iServerStyleGallery.Clear();

            //load the specified style file
            iStyleGalleryStorage.AddFile(sourceFile);

            //set the target file
            iServerStyleGalleryStorage.TargetFile = targetFile;

            // For each class loop over and copy the contents into the server style gallery
            int classCount = _iStyleGallery.ClassCount;
            for (int i = 0; i < classCount; ++i)
            {
                IStyleGalleryClass iStyleGalleryClass = _iStyleGallery.get_Class(i);
                string className = iStyleGalleryClass.Name;

                IEnumBSTR categories = _iStyleGallery.get_Categories(className);
                categories.Reset();

                string category = categories.Next();
                while (category != null)
                {
                    IEnumStyleGalleryItem items = _iStyleGallery.get_Items(className, sourceFile, category);
                    items.Reset();

                    IStyleGalleryItem item = items.Next();
                    while (item != null)
                    {
                        IStyleGalleryItem newItem = new ServerStyleGalleryItemClass();

                        object obj = item.Item;
                        newItem.Item = obj;

                        string name = item.Name;
                        newItem.Name = name;

                        string cat = item.Category;
                        newItem.Category = cat;

                        _iServerStyleGallery.AddItem(newItem);

                        item = items.Next();
                    }

                    //release underlying com object
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(items);

                    category = categories.Next();
                }

                //release underlying com objects
                System.Runtime.InteropServices.Marshal.ReleaseComObject(iStyleGalleryClass);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(categories);

            }

            //close the target file
            iServerStyleGalleryStorage.RemoveFile(targetFile);
        }

        static private void ReleaseCOMObjects()
        {
            System.Runtime.InteropServices.Marshal.ReleaseComObject(_iServerStyleGallery);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(_iStyleGallery);
        }

    }
}

