namespace Client.System
{
    class LayerConfig : Framework.LayerConfig
    {
        private readonly IO.Layer m_ioLayer;

        public LayerConfig()
        {
            m_ioLayer = null;
        }

        public LayerConfig(string sLayerName, IO.Layer ioLayer) : base(sLayerName)
        {
            m_ioLayer = ioLayer;
        }

        public IO.Layer GetIoLayer()
        {
            return m_ioLayer;
        }
    }
}
