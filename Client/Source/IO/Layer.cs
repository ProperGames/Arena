namespace Client.IO
{
    class Layer : Framework.Layer
    {
        private Common.IO.Disk.Interface m_diskInterface;
        private Common.IO.Network.Interface m_networkInterface;

        public Layer(Framework.LayerConfig config) : base(config)
        {
            m_diskInterface = new Common.IO.Disk.Interface();
            m_networkInterface = new Common.IO.Network.Interface();
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
