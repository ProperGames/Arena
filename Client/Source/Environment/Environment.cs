using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Client.Environment
{
    class Environment
    {
        private Config m_config;
        private List<Subsystem> m_subsystems;

        private Addon.System m_addonSystem;
        private Physics.System m_physicsSystem;
        private Graphics.System m_graphicsSystem;
        private Audio.System m_audioSystem;
        private Flow.System m_flowSystem;
        private UI.System m_uiSystem;

        public Environment(Config config)
        {
            m_config = (config == null ? new Config() : config);
            m_subsystems = new List<Subsystem>();
            m_subsystems.Add(new Addon.System());

            m_addonSystem = new Addon.System();
            m_physicsSystem = new Physics.System();
            m_graphicsSystem = new Graphics.System();
            m_audioSystem = new Audio.System();
            m_flowSystem = new Flow.System();
            m_uiSystem = new UI.System();

            m_subsystems.Add(m_addonSystem);
            m_subsystems.Add(m_physicsSystem);
            m_subsystems.Add(m_graphicsSystem);
            m_subsystems.Add(m_audioSystem);
            m_subsystems.Add(m_flowSystem);
            m_subsystems.Add(m_uiSystem);
        }

        public void OnUpdate(GameTime gameTime)
        {
            foreach (Subsystem subsytem in m_subsystems)
            {
                subsytem.OnUpdate(gameTime);
            }
        }
    }
}
