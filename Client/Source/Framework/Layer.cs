using System;
using System.Collections.Generic;

namespace Client.Framework
{
    abstract class Layer
    {
        private bool m_bSuccessfullyInitialised;
        private List<string> m_parameters;
        private LayerConfig m_config;

        protected Layer()
        {
            m_bSuccessfullyInitialised = false;
            m_config = new LayerConfig();
        }

        protected Layer(LayerConfig config)
        {
            m_bSuccessfullyInitialised = false;
            m_config = config;
        }

        public string GetName()
        {
            return m_config.GetName();
        }

        public Tuple<bool, List<Tools.Message>> Initialise(List<string> parameters)
        {
            if (m_bSuccessfullyInitialised)
            {
                return new Tuple<bool, List<Tools.Message>>(false, new List<Tools.Message>() {
                    new Tools.Message(Tools.Message.Types.WARNING, "Already initialised") });
            }

            m_parameters = parameters;
            Tuple<bool, List<Tools.Message>> result = Initialise();
            m_bSuccessfullyInitialised = result.Item1;
            return result;
        }

        protected List<string> GetParameters()
        {
            return m_parameters;
        }

        protected abstract Tuple<bool, List<Tools.Message>> Initialise();
    }
}