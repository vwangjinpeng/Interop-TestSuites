namespace Microsoft.Protocols.TestSuites.MS_OXCFXICS
{
    /// <summary>
    /// The Recipient element represents a Recipient object,
    /// which is a subobject of the Message object.
    /// Recipient            = StartRecip propList EndToRecip
    /// </summary>
    public class Recipient : SyntacticalBase
    {
        /// <summary>
        /// The start marker of Recipient.
        /// </summary>
        public const Markers StartMarker = Markers.PidTagStartRecip;

        /// <summary>
        /// The end marker of Recipient.
        /// </summary>
        public const Markers EndMarker = Markers.PidTagEndToRecip;

        /// <summary>
        /// A propList value.
        /// </summary>
        private PropList propList;

        /// <summary>
        /// Initializes a new instance of the Recipient class.
        /// </summary>
        /// <param name="stream">A FastTransferStream.</param>
        public Recipient(FastTransferStream stream)
            : base(stream)
        {
        }

        /// <summary>
        /// Gets or sets the propList.
        /// </summary>
        public PropList PropList
        {
            get { return this.propList; }
            set { this.propList = value; }
        }

        /// <summary>
        /// Verify that a stream's current position contains a serialized Recipient.
        /// </summary>
        /// <param name="stream">A FastTransferStream.</param>
        /// <returns>If the stream's current position contains 
        /// a serialized Recipient, return true, else false.</returns>
        public static bool Verify(FastTransferStream stream)
        {
            return stream.VerifyMarker(StartMarker);
        }

        /// <summary>
        /// Deserialize fields from a FastTransferStream.
        /// </summary>
        /// <param name="stream">A FastTransferStream.</param>
        public override void Deserialize(FastTransferStream stream)
        {
            this.Deserialize<PropList>(
                stream,
                StartMarker,
                EndMarker,
                out this.propList);
        }
    }
}