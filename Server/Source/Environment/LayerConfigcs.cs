namespace Server.Environment
{
    class LayerConfig : Framework.LayerConfig
    {
        private readonly IO.Layer m_ioLayer;
        private readonly System.Layer m_systemLayer;
        private readonly Management.Layer m_managementLayer;

        public LayerConfig()
        {
            m_ioLayer = null;
            m_systemLayer = null;
            m_managementLayer = null;
        }

        public LayerConfig(string sLayerName, IO.Layer ioLayer, System.Layer systemLayer, 
            Management.Layer managementLayer) : base(sLayerName)
        {
            m_ioLayer = ioLayer;
            m_systemLayer = systemLayer;
            m_managementLayer = managementLayer;
        }

        public IO.Layer GetIoLayer()
        {
            return m_ioLayer;
        }

        public System.Layer GetSystemLayer()
        {
            return m_systemLayer;
        }

        public Management.Layer GetManagementLayer()
        {
            return m_managementLayer;
        }
    }
}