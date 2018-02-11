namespace Client.Environment
{
    class Config
    {
        private readonly string m_sName;

        public Config()
        {
            m_sName = "default";
        }

        public Config(string sName)
        {
            m_sName = string.IsNullOrWhiteSpace(sName) ? "default" : sName;
        }
        
        public string GetName()
        {
            return m_sName;
        }
    }
}
