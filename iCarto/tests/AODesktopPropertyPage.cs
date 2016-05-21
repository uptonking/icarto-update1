using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.ADF.CATIDs;

namespace iCarto.tests
{
    /// <summary>
    /// Generic property page implementation for ArcGIS Desktop
    /// </summary>
    [Guid("3fb542bc-d1bc-4882-87d2-347b12a33357")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("iCarto.tests.AODesktopPropertyPage")]
    public partial class AODesktopPropertyPage : UserControl, IComPropertyPage
    {
        #region COM Registration Function(s)
        [ComRegisterFunction()]
        [ComVisible(false)]
        static void RegisterFunction(Type registerType)
        {
            // Required for ArcGIS Component Category Registrar support
            ArcGISCategoryRegistration(registerType);

            //
            // TODO: Add any COM registration code here
            //
        }

        [ComUnregisterFunction()]
        [ComVisible(false)]
        static void UnregisterFunction(Type registerType)
        {
            // Required for ArcGIS Component Category Registrar support
            ArcGISCategoryUnregistration(registerType);

            //
            // TODO: Add any COM unregistration code here
            //
        }

        #region ArcGIS Component Category Registrar generated code
        /// <summary>
        /// Required method for ArcGIS Component Category registration -
        /// Do not modify the contents of this method with the code editor.
        /// </summary>
        private static void ArcGISCategoryRegistration(Type registerType)
        {
            string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            PropertyPages.Register(regKey);

        }
        /// <summary>
        /// Required method for ArcGIS Component Category unregistration -
        /// Do not modify the contents of this method with the code editor.
        /// </summary>
        private static void ArcGISCategoryUnregistration(Type registerType)
        {
            string regKey = string.Format("HKEY_CLASSES_ROOT\\CLSID\\{{{0}}}", registerType.GUID);
            PropertyPages.Unregister(regKey);

        }

        #endregion
        #endregion
        private string m_pageTitle;

        private bool m_dirtyFlag = false;
        private IComPropertyPageSite m_pageSite = null;
        private Dictionary<string, object> m_objectBag;

        public AODesktopPropertyPage()
        {
            InitializeComponent();

            //TODO: Modify property page title
            m_pageTitle = "My Property Page";
        }

        /// <summary>
        /// Call this to set dirty flag whenever changes are made to the UI/page
        /// </summary>
        private void SetPageDirty(bool dirty)
        {
            if (m_dirtyFlag != dirty)
            {
                m_dirtyFlag = dirty;
                if (m_pageSite != null)
                    m_pageSite.PageChanged();
            }
        }

        #region IComPropertyPage Members

        string IComPropertyPage.Title
        {
            get
            {
                return m_pageTitle;
            }
            set
            {
                //TODO: Uncomment if title can be modified
                //m_pageTitle = value;
            }
        }

        int IComPropertyPage.Width
        {
            get { return this.Width; }
        }

        int IComPropertyPage.Height
        {
            get { return this.Height; }
        }

        int IComPropertyPage.Activate()
        {
            //TODO: Add other page initialization

            return this.Handle.ToInt32();
        }

        void IComPropertyPage.Deactivate()
        {
            //TODO: Release resources and objects

            m_objectBag = null;
            this.Dispose(true);
        }

        /// <summary>
        /// Indicates if the page applies to the specified objects
        /// Do not hold on to the objects here.
        /// </summary>
        bool IComPropertyPage.Applies(ESRI.ArcGIS.esriSystem.ISet objects)
        {
            if (objects == null || objects.Count == 0)
                return false;

            bool isEditable = false;
            objects.Reset();
            object testObject;
            while ((testObject = objects.Next()) != null)
            {
                //TODO: Modify if statement to further check if test object is applicable
                if (testObject != null)
                {
                    isEditable = true;
                }
            }

            return isEditable;
        }

        /// <summary>
        /// Supplies the page with the object(s) to be edited
        /// </summary>
        void IComPropertyPage.SetObjects(ESRI.ArcGIS.esriSystem.ISet objects)
        {
            if (objects == null || objects.Count == 0)
                return;

            //Prepare to hold on to editable objects
            if (m_objectBag == null)
                m_objectBag = new Dictionary<string, object>();
            else
                m_objectBag.Clear();

            objects.Reset();
            object testObject;
            while ((testObject = objects.Next()) != null)
            {
                //TODO: Hold on to applicable object if necessary
                //if (testObject != null)
                //{
                //    m_objectBag.Add("key", testObject);
                //}
            }
        }

        IComPropertyPageSite IComPropertyPage.PageSite
        {
            set
            {
                m_pageSite = value;
            }
        }

        /// <summary>
        /// Indicates if the Apply button should be enabled
        /// </summary>
        bool IComPropertyPage.IsPageDirty
        {
            get { return m_dirtyFlag; }
        }

        void IComPropertyPage.Apply()
        {
            if (m_dirtyFlag)
            {
                //TODO: Apply change to objects

                SetPageDirty(false);
            }
        }

        void IComPropertyPage.Cancel()
        {
            if (m_dirtyFlag)
            {
                //TODO: Reset UI or any temporary changes made to objects

                SetPageDirty(false);
            }
        }

        void IComPropertyPage.Show()
        {
        }

        void IComPropertyPage.Hide()
        {
        }

        string IComPropertyPage.HelpFile
        {
            get { return string.Empty; }
        }

        int IComPropertyPage.get_HelpContextID(int controlID)
        {
            return 0;
        }

        int IComPropertyPage.Priority
        {
            get
            {
                return 0;
            }
            set
            {
            }
        }

        #endregion
    }
}
