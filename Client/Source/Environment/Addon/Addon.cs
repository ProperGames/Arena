namespace Client.Environment.Addon
{
    /// <summary>
    /// The base class for all addons.
    /// </summary>
    public class Addon
    {
        private AddonConfig m_config;

        protected Addon(AddonConfig config)
        {
            m_config = (config == null ? new AddonConfig() : m_config);
        }
    }
}
