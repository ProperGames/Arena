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
            Common.Tools.ProcessResult result = client.StartUp(parameters);
            PrintMessagesToConsole(result.GetDetails());

            client.Run();

            result = client.ShutDown();
            PrintMessagesToConsole(result.GetDetails());

            client.Dispose();

            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }

        static void PrintMessagesToConsole(List<Common.Tools.Message> messages)
        {
            foreach (Common.Tools.Message message in messages)
            {
                switch (message.GetMessageType())
                {
                    case Common.Tools.Message.Types.INFO:
                        Console.WriteLine("INFO : " + message.GetMessage());
                        break;
                    case Common.Tools.Message.Types.WARNING:
                        Console.WriteLine("WARN : " + message.GetMessage());
                        break;
                    case Common.Tools.Message.Types.ERROR:
                        Console.WriteLine("ERROR: " + message.GetMessage());
                        break;
                    default:
                        Console.WriteLine(message.GetMessage());
                        break;
                }
            }
        }
    }
}
