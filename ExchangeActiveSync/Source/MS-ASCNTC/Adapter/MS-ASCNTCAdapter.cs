namespace Microsoft.Protocols.TestSuites.MS_ASCNTC
{
    using System.Xml.XPath;
    using Microsoft.Protocols.TestSuites.Common;
    using Microsoft.Protocols.TestSuites.Common.DataStructures;
    using Microsoft.Protocols.TestTools;

    /// <summary>
    /// Adapter class of MS-ASCNTC.
    /// </summary>
    public partial class MS_ASCNTCAdapter : ManagedAdapterBase, IMS_ASCNTCAdapter
    {
        #region Variables
        /// <summary>
        /// The instance of ActiveSync client.
        /// </summary>
        private ActiveSyncClient activeSyncClient;
        #endregion

        #region IMS_ASCNTCAdapter properties
        /// <summary>
        /// Gets the raw XML request sent to protocol SUT.
        /// </summary>
        public IXPathNavigable LastRawRequestXml
        {
            get { return this.activeSyncClient.LastRawRequestXml; }
        }

        /// <summary>
        /// Gets the raw XML response received from protocol SUT.
        /// </summary>
        public IXPathNavigable LastRawResponseXml
        {
            get { return this.activeSyncClient.LastRawResponseXml; }
        }
        #endregion

        #region IMS_ASCNTCAdapter commands implementation
        /// <summary>
        /// Synchronizes the changes in a collection between the client and the server by sending SyncRequest object.
        /// </summary>
        /// <param name="request">A SyncRequest object which contains the request information.</param>
        /// <returns>A SyncStore object.</returns>
        public SyncStore Sync(SyncRequest request)
        {
            SyncResponse response = this.activeSyncClient.Sync(request, true);
            Site.Assert.IsNotNull(response, "If the Sync command executes successfully, the response from server should not be null.");
            SyncStore syncStore = Common.LoadSyncResponse(response);
            this.VerifyTransport();
            this.VerifyWBXMLCapture();
            this.VerifySyncResponse(syncStore);

            return syncStore;
        }

        /// <summary>
        /// Finds entries in an address book, mailbox or document library by sending SearchRequest object.
        /// </summary>
        /// <param name="request">A SearchRequest object which contains the request information.</param>
        /// <returns>A SearchStore object.</returns>
        public SearchStore Search(SearchRequest request)
        {
            SearchResponse response = this.activeSyncClient.Search(request, true);
            Site.Assert.IsNotNull(response, "If the Search command executes successfully, the response from server should not be null.");
            SearchStore searchStore = Common.LoadSearchResponse(response, Common.GetConfigurationPropertyValue("ActiveSyncProtocolVersion", this.Site));
            this.VerifyTransport();
            this.VerifyWBXMLCapture();
            this.VerifySearchResponse(searchStore);

            return searchStore;
        }

        /// <summary>
        /// Retrieves an item from the server by sending ItemOperationsRequest object.
        /// </summary>
        /// <param name="request">An ItemOperationsRequest object which contains the request information.</param>
        /// <param name="deliveryMethod">The delivery method specifies what kind of response is accepted.</param>
        /// <returns>An ItemOperationsStore object.</returns>
        public ItemOperationsStore ItemOperations(ItemOperationsRequest request, DeliveryMethodForFetch deliveryMethod)
        {
            ItemOperationsResponse response = this.activeSyncClient.ItemOperations(request, deliveryMethod);
            Site.Assert.IsNotNull(response, "If the ItemOperations command executes successfully, the response from server should not be null.");
            ItemOperationsStore itemOperationsStore = Common.LoadItemOperationsResponse(response);
            this.VerifyTransport();
            this.VerifyWBXMLCapture();
            this.VerifyItemOperationsResponse(itemOperationsStore);

            return itemOperationsStore;
        }

        /// <summary>
        /// Sends a MIME-formatted email message to the server.
        /// </summary>
        /// <param name="request">A SendMailRequest object which contains the request information.</param>
        /// <returns>A SendMailResponse object.</returns>
        public SendMailResponse SendMail(SendMailRequest request)
        {
            SendMailResponse response = this.activeSyncClient.SendMail(request);
            Site.Assert.IsNotNull(response, "If the SendMail command executes successfully, the response from server should not be null.");
            this.VerifyTransport();
            return response;
        }

        /// <summary>
        /// Synchronizes the collection hierarchy.
        /// </summary>
        /// <param name="request">A FolderSyncRequest object which contains the request information.</param>
        /// <returns>A FolderSyncResponse object.</returns>
        public FolderSyncResponse FolderSync(FolderSyncRequest request)
        {
            FolderSyncResponse response = this.activeSyncClient.FolderSync(request);
            Site.Assert.IsNotNull(response, "If the FolderSync command executes successfully, the response from server should not be null.");
            this.VerifyTransport();
            return response;
        }
        #endregion

        #region Switch user
        /// <summary>
        /// Changes user to call ActiveSync operation.
        /// </summary>
        /// <param name="userName">The name of the user.</param>
        /// <param name="userPassword">The password of the user.</param>
        /// <param name="userDomain">The domain which the user belongs to.</param>
        public void SwitchUser(string userName, string userPassword, string userDomain)
        {
            this.activeSyncClient.UserName = userName;
            this.activeSyncClient.Password = userPassword;
            this.activeSyncClient.Domain = userDomain;
        }
        #endregion

        #region Overrides IAdapter's Initialize()
        /// <summary>
        /// Overrides IAdapter's Initialize() and sets default protocol short name of the testSite.
        /// </summary>
        /// <param name="testSite">Transfer ITestSite into adapter, make adapter can use ITestSite's function.</param>
        public override void Initialize(TestTools.ITestSite testSite)
        {
            base.Initialize(testSite);
            testSite.DefaultProtocolDocShortName = "MS-ASCNTC";

            // Merge the configuration
            Common.MergeConfiguration(testSite);

            this.activeSyncClient = new ActiveSyncClient(testSite)
            {
                UserName = Common.GetConfigurationPropertyValue("User1Name", testSite),
                Password = Common.GetConfigurationPropertyValue("User1Password", testSite)
            };
        }
        #endregion
    }
}