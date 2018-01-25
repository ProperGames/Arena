using System.Collections.Generic;

namespace Common.Tools
{
    public class ProcessResult
    {
        private bool m_bSuccessful;
        private List<Message> m_messages;

        public ProcessResult()
        {
            m_bSuccessful = false;
            m_messages = new List<Message>();
        }

        public ProcessResult(bool bSuccessful)
        {
            m_bSuccessful = bSuccessful;
            m_messages = new List<Message>();
        }

        public ProcessResult(bool bSuccessful, List<Message> messages)
        {
            m_bSuccessful = bSuccessful;
            m_messages = (messages == null ? new List<Message>() : messages);
        }

        public List<Message> GetDetails()
        {
            return m_messages;
        }

        public bool WasSuccessful()
        {
            return m_bSuccessful;
        }
    }
}
