namespace Client.System
{
    class Layer : Framework.Layer
    {
        private Common.System.ObjectPool.Manager m_objectPoolManager;
        private Common.System.Resource.Manager m_resourceManager;
        private Common.System.Timing.TimerManager m_timerManager;

        public Layer(Framework.LayerConfig config) : base(config)
        {
            m_objectPoolManager = new Common.System.ObjectPool.Manager();
            m_resourceManager = new Common.System.Resource.Manager();
            m_timerManager = new Common.System.Timing.TimerManager();
        }

        protected override Common.Tools.ProcessResult StartUpInternal()
        {
            return new Common.Tools.ProcessResult(true);
        }

        protected override Common.Tools.ProcessResult ShutDownInternal()
        {
            return new Common.Tools.ProcessResult(true);
        }
    }
}
