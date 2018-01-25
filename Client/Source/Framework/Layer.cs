using System.Collections.Generic;

namespace Client.Framework
{
    abstract class Layer
    {
        private bool m_bInitialised;
        private List<string> m_parameters;
        private LayerConfig m_config;

        protected Layer()
        {
            m_bInitialised = false;
            m_config = new LayerConfig();
        }

        protected Layer(LayerConfig config)
        {
            m_bInitialised = false;
            m_config = config;
        }

        public string GetName()
        {
            return m_config.GetName();
        }

        public Common.Tools.ProcessResult StartUp(List<string> parameters)
        {
            if (m_bInitialised)
            {
                return new Common.Tools.ProcessResult(false, new List<Common.Tools.Message>() {
                    new Common.Tools.Message(Common.Tools.Message.Types.WARNING, "Already initialised") });
            }

            m_parameters = parameters;
            Common.Tools.ProcessResult result = StartUpInternal();
            m_bInitialised = result.WasSuccessful();
            return result;
        }

        public Common.Tools.ProcessResult ShutDown()
        {
            if (!m_bInitialised)
            {
                return new Common.Tools.ProcessResult(false, new List<Common.Tools.Message> {
                    new Common.Tools.Message(Common.Tools.Message.Types.WARNING, "Not yet initialised") });
            }

            return ShutDownInternal();
        }

        protected List<string> GetParameters()
        {
            return m_parameters;
        }

        protected abstract Common.Tools.ProcessResult StartUpInternal();
        protected abstract Common.Tools.ProcessResult ShutDownInternal();
    }
}