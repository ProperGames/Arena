namespace Server.Environment
{
    class Environment
    {
        private readonly Ability.System m_abilitySystem;
        private readonly EntityComponent.System m_entityComponentSystem;
        private readonly Flow.Manager m_flowManager;
        private readonly Physics.Manager m_physicsManager;
        private readonly Config m_config;

        public Environment(Config config)
        {
            m_abilitySystem = new Ability.System();
            m_entityComponentSystem = new EntityComponent.System();
            m_flowManager = new Flow.Manager();
            m_physicsManager = new Physics.Manager();
            m_config = (config == null ? new Config() : config);
        }
    }
}
