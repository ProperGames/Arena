using System.Collections.Generic;

namespace Server.Environment
{
    class Layer : Framework.Layer
    {
        private readonly IO.Layer m_ioLayer;
        private readonly System.Layer m_systemLayer;
        private readonly Management.Layer m_managementLayer;
        private readonly Manager m_environmentManager;

        public Layer(LayerConfig config) : base(config)
        {
            m_environmentManager = new Manager(new ManagerConfig());
            m_ioLayer = config.GetIoLayer();
            m_systemLayer = config.GetSystemLayer();
            m_managementLayer = config.GetManagementLayer();
        }

        protected override Common.Tools.ProcessResult StartUpInternal()
        {
            bool bSuccess = true;
            List<Common.Tools.Message> messages = new List<Common.Tools.Message>();

            if (m_ioLayer == null)
            {
                bSuccess = false;
                messages.Add(new Common.Tools.Message(Common.Tools.Message.Types.ERROR,
                    "Reference to IO layer required"));
            }
            if (m_systemLayer == null)
            {
                bSuccess = false;
                messages.Add(new Common.Tools.Message(Common.Tools.Message.Types.ERROR,
                    "Reference to system layer required"));
            }
            if (m_managementLayer == null)
            {
                bSuccess = false;
                messages.Add(new Common.Tools.Message(Common.Tools.Message.Types.ERROR,
                    "Reference to management layer required"));
            }

            return new Common.Tools.ProcessResult(bSuccess, messages);
        }

        protected override Common.Tools.ProcessResult ShutDownInternal()
        {
            return new Common.Tools.ProcessResult(true);
        }
    }
}
