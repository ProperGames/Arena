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
            Common.Tools.ProcessResult result = server.StartUp(parameters);
            PrintMessagesToConsole(result.GetDetails());

            result = server.ShutDown();
            PrintMessagesToConsole(result.GetDetails());

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
