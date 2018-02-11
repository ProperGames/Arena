namespace Common.System.Timing
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
