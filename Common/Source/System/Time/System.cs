namespace Common.System.Time
{
    public class System
    {
        private readonly TimerManager m_timerManager;

        public System()
        {
            m_timerManager = new TimerManager();
        }
    }
}
