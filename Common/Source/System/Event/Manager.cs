namespace Common.System.Event
{
    internal class Manager
    {
        private readonly ManagerConfig m_config;

        public Manager()
        {
            m_config = new ManagerConfig();
        }

        public Manager(ManagerConfig config)
        {
            m_config = config;
        }
    }
}
