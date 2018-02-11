using System;
using System.Collections.Generic;

namespace Server.Framework
{
    class Server
    {
        private bool m_bInitialised;
        private List<Layer> m_layers;

        public Server()
        {
            m_bInitialised = false;
            m_layers = new List<Layer>();
        }
        
        public Common.Tools.ProcessResult StartUp(List<string> parameters)
        {
            if (m_bInitialised)
            {
                return new Common.Tools.ProcessResult(false, new List<Common.Tools.Message>() {
                    new Common.Tools.Message(Common.Tools.Message.Types.WARNING, "Already initialised") });
            }

            if (parameters == null)
            {
                parameters = new List<string>();
            }

            IO.Layer ioLayer = new IO.Layer(new LayerConfig("IO"));
            System.Layer systemLayer = new System.Layer(new System.LayerConfig(
                "System",
                ioLayer));
            Management.Layer managementLayer = new Management.Layer(
                new Management.LayerConfig(
                    "Management",
                    ioLayer,
                    systemLayer));
            Environment.Layer environmentLayer = new Environment.Layer(
                new Environment.LayerConfig(
                    "Environment",
                    ioLayer,
                    systemLayer,
                    managementLayer));

            m_layers.Add(ioLayer);
            m_layers.Add(systemLayer);
            m_layers.Add(managementLayer);
            m_layers.Add(environmentLayer);

            bool bInitialisationSucceeded = true;
            List<Common.Tools.Message> messages = new List<Common.Tools.Message>();           
            foreach(Layer layer in m_layers)
            {
                Common.Tools.ProcessResult result = layer.StartUp(parameters);
                string sLayerName = layer.GetName();
                if (!result.WasSuccessful())
                {
                    bInitialisationSucceeded = false;
                    messages.Add(new Common.Tools.Message(Common.Tools.Message.Types.ERROR, "Failed to initialise layer '" + sLayerName + "'"));
                }

                foreach (Common.Tools.Message message in result.GetDetails())
                {
                    messages.Add(new Common.Tools.Message(message.GetMessageType(), sLayerName + ": " + message.GetMessage()));
                }
            }

            if (bInitialisationSucceeded)
            {
                m_bInitialised = true;
            }

            return new Common.Tools.ProcessResult(bInitialisationSucceeded, messages);
        }

        public Common.Tools.ProcessResult ShutDown()
        {
            if (!m_bInitialised)
            {
                return new Common.Tools.ProcessResult(false, new List<Common.Tools.Message> {
                    new Common.Tools.Message(Common.Tools.Message.Types.WARNING, "Not yet initialised") });
            }

            bool bSuccess = true;
            List<Common.Tools.Message> messages = new List<Common.Tools.Message>();
            foreach (Layer layer in m_layers)
            {
                Common.Tools.ProcessResult result = layer.ShutDown();
                string sLayerName = layer.GetName();
                if (!result.WasSuccessful())
                {
                    bSuccess = false;
                }

                foreach (Common.Tools.Message message in result.GetDetails())
                {
                    messages.Add(new Common.Tools.Message(message.GetMessageType(), sLayerName + ": " + message.GetMessage()));
                }
            }
            m_layers.Clear();

            return new Common.Tools.ProcessResult(bSuccess, messages);
        }
    }
}
