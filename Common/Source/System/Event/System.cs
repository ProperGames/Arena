namespace Common.System.Event
{
    public class System
    {
        private readonly Manager m_eventManager;

        public System()
        {
            m_eventManager = new Manager();
        }
    }
}
