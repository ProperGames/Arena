namespace Tools
{
    public class Message
    {
        public enum Types
        {
            /// <summary>
            /// The message is for information purposes only.
            /// </summary>
            INFO,

            /// <summary>
            /// The message describes a potential problem.
            /// </summary>
            WARNING,

            /// <summary>
            /// The message describes an error.
            /// </summary>
            ERROR
        }

        private readonly Types m_type;
        private readonly string m_sMessage;

        public Message()
        {
            m_type = Types.INFO;
            m_sMessage = string.Empty;
        }

        public Message(Types type, string sMessage)
        {
            m_type = type;
            m_sMessage = (sMessage == null ? string.Empty : sMessage);
        }

        /// <summary>
        /// Gets the message. Never null.
        /// </summary>
        /// <returns>The message</returns>
        public string GetMessage()
        {
            return m_sMessage;
        }

        /// <summary>
        /// Gets the message type.
        /// </summary>
        /// <returns>The message type</returns>
        public Types GetMessageType()
        {
            return m_type;
        }
    }
}
