namespace Server.Management
{
    class Layer : Framework.Layer
    {
        public Layer(Framework.LayerConfig config) : base(config)
        {
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
