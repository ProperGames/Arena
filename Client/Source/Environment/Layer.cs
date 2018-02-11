using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Client.Environment
{
    class Layer : Framework.Layer
    {
        private int m_iNextEnvironmentUid;
        private Environment m_activeEnvironment;
        private EnvironmentLoader m_environmentLoader;
        private System.Layer m_systemLayer;
        private IO.Layer m_ioLayer;
        private SortedDictionary<string, int> m_nameToIdMappings;
        private SortedDictionary<int, Environment> m_environments;

        public Layer(LayerConfig config) : base(config)
        {
            m_iNextEnvironmentUid = 0;
            m_activeEnvironment = null;
            m_systemLayer = config.GetSystemLayer();
            m_ioLayer = config.GetIoLayer();
            m_environmentLoader = new EnvironmentLoader();
            m_nameToIdMappings = new SortedDictionary<string, int>();
            m_environments = new SortedDictionary<int, Environment>();
        }

        protected override Common.Tools.ProcessResult StartUpInternal()
        {
            bool bSuccess = true;
            List<Common.Tools.Message> messages = new List<Common.Tools.Message>();

            if (m_systemLayer == null)
            {
                bSuccess = false;
                messages.Add(new Common.Tools.Message(Common.Tools.Message.Types.ERROR,
                    "Reference to system layer required"));
            }

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

        public override void OnUpdate(GameTime gameTime)
        {
            if (m_activeEnvironment != null)
            {
                m_activeEnvironment.OnUpdate(gameTime);
            }
        }

        private int RegisterEnvironment(Config config)
        {
            if (config == null)
            {
                return -1;
            }

            if (GetEnvironmentId(config.GetName()) != -1)
            {
                return -1;
            }

            int iUid = m_iNextEnvironmentUid;
            m_nameToIdMappings.Add(config.GetName(), iUid);
            m_environments.Add(iUid, new Environment(config));
            ++m_iNextEnvironmentUid;
            return iUid;
        }

        private int GetEnvironmentId(string sEnvironmentName)
        {
            if (string.IsNullOrWhiteSpace(sEnvironmentName))
            {
                return -1;
            }

            int iUid;
            if (m_nameToIdMappings.TryGetValue(sEnvironmentName, out iUid))
            {
                return iUid;
            }

            return -1;
        }
    }
}
