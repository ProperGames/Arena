namespace Common.IO.Network
{
    /// <summary>
    /// A network message header is a small object prepended to the start of each packet transferred across
    /// the network that describes the contents of the message.
    /// </summary>
    public class MessageHeader
    {
        public enum Types
        {
            /// <summary>
            /// The header type is not set. Used as a default value. Unspecified headers will result in 
            /// a discarded message upon receipt.
            /// </summary>
            UNSPECIFIED,

            /// <summary>
            /// A ping. The receiver should immediately respond with a PING_RESPONSE.
            /// </summary>
            PING,

            /// <summary>
            /// A response to a ping.
            /// </summary>
            PING_RESPONSE
        }

        private Types m_type;    

        public MessageHeader()
        {
            m_type = Types.UNSPECIFIED;
        }

        public MessageHeader(Types type)
        {
            m_type = type;
        }

        public Types GetHeaderType()
        {
            return m_type;
        }
    }
}
