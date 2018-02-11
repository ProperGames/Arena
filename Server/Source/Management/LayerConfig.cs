namespace Server.Management
{
    class LayerConfig : Framework.LayerConfig
    {
        private readonly IO.Layer m_ioLayer;
        private readonly System.Layer m_systemLayer;

        public LayerConfig()
        {
            m_ioLayer = null;
            m_systemLayer = null;
        }

        public LayerConfig(string sLayerName, IO.Layer ioLayer, System.Layer systemLayer) : 
            base(sLayerName)
        {
            m_ioLayer = ioLayer;
            m_systemLayer = systemLayer;
        }

        public IO.Layer GetIoLayer()
        {
            return m_ioLayer;
        }

        public System.Layer GetSystemLayer()
        {
            return m_systemLayer;
        }
    }
}