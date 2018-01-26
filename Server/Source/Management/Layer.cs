namespace Server.Management
{
    class Layer : Framework.Layer
    {
        private Access.Manager m_accessManager;
        private Account.Manager m_accountManager;
        private Command.Manager m_commandManager;
        private Configuration.Manager m_configurationManager;

        public Layer(Framework.LayerConfig config) : base(config)
        {
            m_accessManager = new Access.Manager();
            m_accountManager = new Account.Manager();
            m_commandManager = new Command.Manager();
            m_configurationManager = new Configuration.Manager();
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
