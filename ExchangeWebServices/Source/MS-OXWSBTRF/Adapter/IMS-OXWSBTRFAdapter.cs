namespace Microsoft.Protocols.TestSuites.MS_OXWSBTRF
{
    using System.Collections.Generic;
    using System.Xml.XPath;
    using Microsoft.Protocols.TestSuites.Common;
    using Microsoft.Protocols.TestTools;

    /// <summary>
    /// The adapter interface which provides methods defined MS-OXWSBTRF.
    /// </summary>
    public interface IMS_OXWSBTRFAdapter : IAdapter
    {
        /// <summary>
        /// Gets the raw XML request sent to protocol SUT.
        /// </summary>
        IXPathNavigable LastRawRequestXml { get; }

        /// <summary>
        /// Gets the raw XML response received from protocol SUT.
        /// </summary>
        IXPathNavigable LastRawResponseXml { get; }

        /// <summary>
        /// Exports items from a specified folder.
        /// </summary>
        /// <param name="exportItemsRequest">Specify the request for ExportItems operation.</param>
        /// <returns>The response to this operation request.</returns>
        ExportItemsResponseType ExportItems(ExportItemsType exportItemsRequest);

        /// <summary>
        /// Uploads the items into a specified folder.
        /// </summary>
        /// <param name="uploadItemsRequest">Specify the request for UploadItems operation.</param>
        /// <returns>The response to this operation request.</returns>
        UploadItemsResponseType UploadItems(UploadItemsType uploadItemsRequest);

        /// <summary>
        /// Configures the SOAP header to cover the case that the header contains all optional parts before calling operations.
        /// </summary>
        /// <param name="headerValues">Specify the values for SOAP header.</param>
        void ConfigureSOAPHeader(Dictionary<string, object> headerValues);
    }
}