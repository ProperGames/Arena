namespace Server.IO
{
    class Layer : Framework.Layer
    {
        private Database.Interface m_databaseInterface;
        private Common.IO.Disk.Interface m_diskInterface;
        private Common.IO.Network.Interface m_networkInterface;

        public Layer(Framework.LayerConfig config) : base(config)
        {
            m_databaseInterface = new Database.Interface();
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
