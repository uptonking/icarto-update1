//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by ESRI license initialization tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TESTAOConsole
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using ESRI.ArcGIS.esriSystem;
    using ESRI.ArcGIS;

    /// <summary>
    /// Initialize ArcObjects runtime environment for this application
    /// </summary>
    partial class LicenseInitializer
    {
        /// <summary>
        /// Raised when ArcGIS runtime binding hasn't been established. 
        /// </summary>
        public event EventHandler ResolveBindingEvent;

        /// <summary>
        /// Initialize the application with the specified product and extension license code.
        /// </summary>    
        /// <returns>Initialization is successful.</returns>
        /// <remarks>
        /// Make sure an active ArcGIS runtime has been bound before license initialization.
        /// </remarks>
        public bool InitializeApplication(esriLicenseProductCode[] productCodes, esriLicenseExtensionCode[] extensionLics)
        {
            //Cache product codes by enum int so can be sorted without custom sorter
            m_requestedProducts = new List<int>();
            foreach (esriLicenseProductCode code in productCodes)
            {
                int requestCodeNum = Convert.ToInt32(code);
                if (!m_requestedProducts.Contains(requestCodeNum))
                {
                    m_requestedProducts.Add(requestCodeNum);
                }
            }
            AddExtensions(extensionLics);

            // Make sure an active runtime has been bound before calling any ArcObjects code. 
            if (RuntimeManager.ActiveRuntime == null)
            {
                EventHandler temp = ResolveBindingEvent;
                if (temp != null)
                {
                    temp(this, new EventArgs());
                }
            }

            return Initialize();
        }

        /// <summary>
        /// A summary of the status of product and extensions initialization.
        /// </summary>
        public string LicenseMessage()
        {
            if (RuntimeManager.ActiveRuntime == null)
            {
                return MessageNoRuntimeBinding;
            }

            if (m_AoInit == null)
            {
                return MessageNoAoInitialize;
            }

            string prodStatus = string.Empty;
            string extStatus = string.Empty;
            if (m_productStatus == null || m_productStatus.Count == 0)
            {
                prodStatus = MessageNoLicensesRequested + Environment.NewLine;
            }
            else if (m_productStatus.ContainsValue(esriLicenseStatus.esriLicenseAlreadyInitialized)
                || m_productStatus.ContainsValue(esriLicenseStatus.esriLicenseCheckedOut))
            {
                prodStatus = ReportInformation(m_AoInit as ILicenseInformation,
                    m_AoInit.InitializedProduct(),
                    esriLicenseStatus.esriLicenseCheckedOut) + Environment.NewLine;
            }
            else
            {
                //Failed...
                foreach (KeyValuePair<esriLicenseProductCode, esriLicenseStatus> item in m_productStatus)
                {
                    prodStatus += ReportInformation(m_AoInit as ILicenseInformation,
                        item.Key, item.Value) + Environment.NewLine;
                }
            }

            foreach (KeyValuePair<esriLicenseExtensionCode, esriLicenseStatus> item in m_extensionStatus)
            {
                string info = ReportInformation(m_AoInit as ILicenseInformation, item.Key, item.Value);
                if (!string.IsNullOrEmpty(info))
                    extStatus += info + Environment.NewLine;
            }

            return (prodStatus + extStatus).Trim();
        }

        /// <summary>
        /// Shuts down AoInitialize object and check back in extensions to ensure
        /// any ESRI libraries that have been used are unloaded in the correct order.
        /// </summary>
        /// <remarks>Once Shutdown has been called, you cannot re-initialize the product license
        /// and should not make any ArcObjects call.</remarks>
        public void ShutdownApplication()
        {
            if (m_hasShutDown)
                return;

            //Check back in extensions
            if (m_AoInit != null)
            {
                foreach (KeyValuePair<esriLicenseExtensionCode, esriLicenseStatus> item in m_extensionStatus)
                {
                    if (item.Value == esriLicenseStatus.esriLicenseCheckedOut)
                        m_AoInit.CheckInExtension(item.Key);
                }
                m_AoInit.Shutdown();
            }

            m_requestedProducts = null;
            m_requestedExtensions = null;
            m_extensionStatus = null;
            m_productStatus = null;

            m_hasShutDown = true;
        }

        /// <summary>
        /// Indicates if the extension is currently checked out.
        /// </summary>
        public bool IsExtensionCheckedOut(esriLicenseExtensionCode code)
        {
            return m_AoInit != null && m_AoInit.IsExtensionCheckedOut(code);
        }

        /// <summary>
        /// Set the extension(s) to be checked out for your ArcObjects code. 
        /// </summary>
        public bool AddExtensions(params esriLicenseExtensionCode[] requestCodes)
        {
            if (m_requestedExtensions == null)
                m_requestedExtensions = new List<esriLicenseExtensionCode>();
            foreach (esriLicenseExtensionCode code in requestCodes)
            {
                if (!m_requestedExtensions.Contains(code))
                    m_requestedExtensions.Add(code);
            }

            if (m_hasInitializeProduct)
                return CheckOutLicenses(this.InitializedProduct);

            return false;
        }

        /// <summary>
        /// Check in extension(s) when it is no longer needed.
        /// </summary>
        public void RemoveExtensions(params esriLicenseExtensionCode[] requestCodes)
        {
            if (m_extensionStatus == null || m_extensionStatus.Count == 0)
                return;

            foreach (esriLicenseExtensionCode code in requestCodes)
            {
                if (m_extensionStatus.ContainsKey(code))
                {
                    if (m_AoInit.CheckInExtension(code) == esriLicenseStatus.esriLicenseCheckedIn)
                    {
                        m_extensionStatus[code] = esriLicenseStatus.esriLicenseCheckedIn;
                    }
                }
            }
        }

        /// <summary>
        /// Get/Set the ordering of product code checking. If true, check from lowest to 
        /// highest license. True by default.
        /// </summary>
        public bool InitializeLowerProductFirst
        {
            get
            {
                return m_productCheckOrdering;
            }
            set
            {
                m_productCheckOrdering = value;
            }
        }

        /// <summary>
        /// Retrieves the product code initialized in the ArcObjects application
        /// </summary>
        public esriLicenseProductCode InitializedProduct
        {
            get
            {
                if (m_AoInit != null)
                {
                    try
                    {
                        return m_AoInit.InitializedProduct();
                    }
                    catch
                    {
                        return 0;
                    }
                }
                return 0;
            }
        }

        #region Helper methods

        private bool Initialize()
        {
            if (RuntimeManager.ActiveRuntime == null)
                return false;

            if (m_requestedProducts == null || m_requestedProducts.Count == 0)
                return false;

            bool productInitialized = false;

            m_requestedProducts.Sort();
            if (!InitializeLowerProductFirst) //Request license from highest to lowest
                m_requestedProducts.Reverse();

            m_AoInit = new AoInitializeClass();
            esriLicenseProductCode currentProduct = new esriLicenseProductCode();
            foreach (int prodNumber in m_requestedProducts)
            {
                esriLicenseProductCode prod = (esriLicenseProductCode)Enum.ToObject(typeof(esriLicenseProductCode), prodNumber);
                esriLicenseStatus status = m_AoInit.IsProductCodeAvailable(prod);
                if (status == esriLicenseStatus.esriLicenseAvailable)
                {
                    status = m_AoInit.Initialize(prod);
                    if (status == esriLicenseStatus.esriLicenseAlreadyInitialized ||
                        status == esriLicenseStatus.esriLicenseCheckedOut)
                    {
                        productInitialized = true;
                        currentProduct = m_AoInit.InitializedProduct();
                    }
                }

                m_productStatus.Add(prod, status);

                if (productInitialized)
                    break;
            }

            m_hasInitializeProduct = productInitialized;
            m_requestedProducts.Clear();

            //No product is initialized after trying all requested licenses, quit
            if (!productInitialized)
            {
                return false;
            }

            //Check out extension licenses
            return CheckOutLicenses(currentProduct);
        }

        private bool CheckOutLicenses(esriLicenseProductCode currentProduct)
        {
            bool allSuccessful = true;
            //Request extensions
            if (m_requestedExtensions != null && currentProduct != 0)
            {
                foreach (esriLicenseExtensionCode ext in m_requestedExtensions)
                {
                    esriLicenseStatus licenseStatus = m_AoInit.IsExtensionCodeAvailable(currentProduct, ext);
                    if (licenseStatus == esriLicenseStatus.esriLicenseAvailable)//skip unavailable extensions
                    {
                        licenseStatus = m_AoInit.CheckOutExtension(ext);
                    }
                    allSuccessful = (allSuccessful && licenseStatus == esriLicenseStatus.esriLicenseCheckedOut);
                    if (m_extensionStatus.ContainsKey(ext))
                        m_extensionStatus[ext] = licenseStatus;
                    else
                        m_extensionStatus.Add(ext, licenseStatus);
                }

                m_requestedExtensions.Clear();
            }

            return allSuccessful;
        }


        private string ReportInformation(ILicenseInformation licInfo,
           esriLicenseProductCode code, esriLicenseStatus status)
        {
            string prodName = string.Empty;
            try
            {
                prodName = licInfo.GetLicenseProductName(code);
            }
            catch
            {
                prodName = code.ToString();
            }

            string statusInfo = string.Empty;

            switch (status)
            {
                case esriLicenseStatus.esriLicenseAlreadyInitialized:
                case esriLicenseStatus.esriLicenseCheckedOut:
                    statusInfo = string.Format(MessageProductAvailable, prodName);
                    break;
                default:
                    statusInfo = string.Format(MessageProductNotLicensed, prodName);
                    break;
            }

            return statusInfo;
        }
        private string ReportInformation(ILicenseInformation licInfo,
            esriLicenseExtensionCode code, esriLicenseStatus status)
        {
            string extensionName = string.Empty;
            try
            {
                extensionName = licInfo.GetLicenseExtensionName(code);
            }
            catch
            {
                extensionName = code.ToString();
            }

            string statusInfo = string.Empty;

            switch (status)
            {
                case esriLicenseStatus.esriLicenseAlreadyInitialized:
                case esriLicenseStatus.esriLicenseCheckedOut:
                    statusInfo = string.Format(MessageExtensionAvailable, extensionName);
                    break;
                case esriLicenseStatus.esriLicenseCheckedIn:
                    break;
                case esriLicenseStatus.esriLicenseUnavailable:
                    statusInfo = string.Format(MessageExtensionUnavailable, extensionName);
                    break;
                case esriLicenseStatus.esriLicenseFailure:
                    statusInfo = string.Format(MessageExtensionFailed, extensionName);
                    break;
                default:
                    statusInfo = string.Format(MessageExtensionNotLicensed, extensionName);
                    break;
            }

            return statusInfo;
        }
        #endregion

        private const string MessageNoRuntimeBinding = "Invalid ArcGIS runtime binding.";
        private const string MessageNoAoInitialize = "ArcObjects initialization failed.";
        private const string MessageNoLicensesRequested = "Product: No licenses were requested";
        private const string MessageProductAvailable = "Product: {0}: Available";
        private const string MessageProductNotLicensed = "Product: {0}: Not Licensed";
        private const string MessageExtensionAvailable = " Extension: {0}: Available";
        private const string MessageExtensionNotLicensed = " Extension: {0}: Not Licensed";
        private const string MessageExtensionFailed = " Extension: {0}: Failed";
        private const string MessageExtensionUnavailable = " Extension: {0}: Unavailable";

        #region Private members

        private IAoInitialize m_AoInit = null;
        private bool m_hasShutDown = false;
        private bool m_hasInitializeProduct = false;

        private List<int> m_requestedProducts;
        private List<esriLicenseExtensionCode> m_requestedExtensions;
        private Dictionary<esriLicenseProductCode, esriLicenseStatus> m_productStatus = new Dictionary<esriLicenseProductCode, esriLicenseStatus>();
        private Dictionary<esriLicenseExtensionCode, esriLicenseStatus> m_extensionStatus = new Dictionary<esriLicenseExtensionCode, esriLicenseStatus>();

        private bool m_productCheckOrdering = true; //default from low to high
        #endregion
    }
}