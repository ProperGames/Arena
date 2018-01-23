using System;
using System.Collections.Generic;

namespace Server.Framework
{
    class Server
    {
        private bool m_bSuccessfullyInitialised;
        private List<Layer> m_layers;

        public Server()
        {
            m_bSuccessfullyInitialised = false;
            m_layers = new List<Layer>();
        }
        
        public Tuple<bool, List<Tools.Message>> Initialise(List<string> parameters)
        {
            if (m_bSuccessfullyInitialised)
            {
                return new Tuple<bool, List<Tools.Message>>(false, new List<Tools.Message>() {
                    new Tools.Message(Tools.Message.Types.WARNING, "Already initialised") });
            }

            bool bInitialisationSucceeded = true;
            List<Tools.Message> messages = new List<Tools.Message>();
            
            if (parameters == null)
            {
                parameters = new List<string>();
            }

            m_layers.Add(new IO.Layer(new LayerConfig("IO")));
            m_layers.Add(new System.Layer(new LayerConfig("System")));
            m_layers.Add(new Management.Layer(new LayerConfig("Management")));
            m_layers.Add(new Game.Layer(new LayerConfig("Game")));

            foreach(Layer layer in m_layers)
            {
                Tuple<bool, List<Tools.Message>> layerInitialisationResult = layer.Initialise(parameters);
                string sLayerName = layer.GetName();
                if (!layerInitialisationResult.Item1)
                {
                    bInitialisationSucceeded = false;
                    messages.Add(new Tools.Message(Tools.Message.Types.ERROR, "Failed to initialise layer '" + sLayerName + "'"));
                }

                foreach (Tools.Message message in layerInitialisationResult.Item2)
                {
                    messages.Add(new Tools.Message(message.GetMessageType(), sLayerName + ": " + message.GetMessage()));
                }
            }

            if (bInitialisationSucceeded)
            {
                m_bSuccessfullyInitialised = true;
            }

            return new Tuple<bool, List<Tools.Message>>(bInitialisationSucceeded, messages);
        }
    }
}
