using System.Collections.Generic;

namespace Server.Management
{
    class Layer : Framework.Layer
    {
        private User.Manager m_userManager;
        private Command.Manager m_commandManager;
        private IO.Layer m_ioLayer;
        private System.Layer m_systemLayer;

        public Layer(LayerConfig config) : base(config)
        {
            m_userManager = new User.Manager();
            m_commandManager = new Command.Manager();
            m_ioLayer = config.GetIoLayer();
            m_systemLayer = config.GetSystemLayer();
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

            return new Common.Tools.ProcessResult(bSuccess, messages);
        }

        protected override Common.Tools.ProcessResult ShutDownInternal()
        {
            return new Common.Tools.ProcessResult(true);
        }
    }
}
