namespace Server.Framework
{
    class LayerConfig
    {
        private static string m_sDefaultLayerName = "Unnamed layer";
        private string m_sName;

        public LayerConfig()
        {
            m_sName = m_sDefaultLayerName;
        }

        public LayerConfig(string sName)
        {
            if (string.IsNullOrWhiteSpace(sName))
            {
                m_sName = m_sDefaultLayerName;
            }
            else
            {
                m_sName = sName;
            }         
        }

        /// <summary>
        /// Gets the layer name. Guaranteed to be a valid string containing at least one
        /// non-whitespace character.
        /// </summary>
        /// <returns>The layer name</returns>
        public string GetName()
        {
            return m_sName;
        }
    }
}
