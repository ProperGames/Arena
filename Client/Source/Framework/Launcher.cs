using System;
using System.Collections.Generic;

namespace Client
{
    public static class Launcher
    {
        [STAThread]
        static void Main(string[] args)
        {
            List<string> parameters = new List<string>(args);

            Client.Framework.Client client = new Client.Framework.Client();
            Tuple<bool, List<Tools.Message>> initialisationResult = client.Initialise(parameters);

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

            client.Run();
            client.Dispose();

            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }
    }
}
