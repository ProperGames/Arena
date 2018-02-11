using System.Collections.Generic;

namespace Server.Environment
{
    class Manager
    {
        public enum States
        {
            /// <summary>
            /// The environment has been suspended and will not receive updates calls until
            /// it is restored.
            /// </summary>
            SUSPENDED,

            /// <summary>
            /// The environment is active and is receiving updates.
            /// </summary>
            ACTIVE
        }

        private readonly ManagerConfig m_config;
        private List<ManagedEnvironment> m_environments;

        public Manager()
        {
            m_config = new ManagerConfig();
        }

        public Manager(ManagerConfig config)
        {
            m_config = (config == null ? new ManagerConfig() : config);
        }

        private struct ManagedEnvironment
        {
            public Environment environment;
            public States state;
        }
    }
}
