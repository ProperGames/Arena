using System;
using System.Collections.Generic;

namespace Server
{
    public static class Launcher
    {
        static void Main(string[] args)
        {
            List<string> parameters = new List<string>(args);

            Server.Framework.Server server = new Server.Framework.Server();
            Tuple<bool, List<Tools.Message>> initialisationResult = server.Initialise(parameters);

            foreach (Tools.Message message in initialisationResult.Item2)
            {
                switch (message.GetMessageType())
                {
                    case Tools.Message.Types.INFO:
                        Console.WriteLine("INFO : " + message.GetMessage());
                        break;
                    case Tools.Message.Types.WARNING:
                        Console.WriteLine("WARN : " + message.GetMessage());
                        break;
                    case Tools.Message.Types.ERROR:
                        Console.WriteLine("ERROR: " + message.GetMessage());
                        break;
                    default:
                        Console.WriteLine(message.GetMessage());
                        break;
                }
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }
    }
}
