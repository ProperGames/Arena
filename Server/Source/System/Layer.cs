using System.Collections.Generic;

namespace Server.System
{
    class Layer : Framework.Layer
    {
        private Common.System.ObjectPool.System m_objectPoolSystem;
        private Common.System.Resource.System m_resourceSystem;
        private Common.System.Timing.System m_timerSystem;
        private Common.System.Event.System m_eventSystem;
        private IO.Layer m_ioLayer;

        public Layer(LayerConfig config) : base(config)
        {
            m_objectPoolSystem = new Common.System.ObjectPool.System();
            m_resourceSystem = new Common.System.Resource.System();
            m_timerSystem = new Common.System.Timing.System();
            m_eventSystem = new Common.System.Event.System();
            m_ioLayer = config.GetIoLayer();
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

            return new Common.Tools.ProcessResult(bSuccess, messages);
        }

        protected override Common.Tools.ProcessResult ShutDownInternal()
        {
            return new Common.Tools.ProcessResult(true);
        }
    }
}
