namespace Common.System.Resource
{
    public class System
    {
        private readonly Manager m_resourceManager;

        public System()
        {
            m_resourceManager = new Manager();
        }

        public System(SystemConfig config)
        {
            m_resourceManager = new Manager();
        }
    }
}
