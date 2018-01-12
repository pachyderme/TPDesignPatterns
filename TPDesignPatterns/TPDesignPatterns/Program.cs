using System;
using TPDesignPatterns.Models.Exports;
using TPDesignPatterns.Models.Historic;
using TPDesignPatterns.Models.Clients;
using TPDesignPatterns.Models.Database;

namespace TPDesignPatterns
{
    class Command
    {
        public const string EXPORTSQL = "EXPORTSQL";
        public const string EXPORTJSON = "EXPORTJSON";
        public const string EXPORTXML = "EXPORTXML";
        public const string DISCONNECT = "DISCONNECT";
    }

    class Program
    {
        public static bool displayCompleteMessage = true;

        static void Main(string[] args)
        {
            Client client = new Client("Tuning");
            client.Connect();

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("SEARCH / COMMAND (EXPORTSQL | EXPORTJSON | EXPORTXML) : ");
                String search = Console.ReadLine();

                switch (search.ToUpper())
                {
                    case Command.EXPORTJSON:
                        client.Export(ExportDataType.JSON);
                        break;
                    case Command.EXPORTSQL:
                        client.Export(ExportDataType.SQL);
                        break;
                    case Command.EXPORTXML:
                        client.Export(ExportDataType.XML);
                        break;
                    case Command.DISCONNECT:
                        client.Disconnect();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Green;

                        Console.WriteLine($"---------- SEARCH {search} ----------");
                        client.GetMessage().ForEach(m =>
                        {
                            if (m.Search(search))
                            {
                                Console.WriteLine(m.ToString());
                            }
                        });

                        Console.WriteLine($"---------- SEARCH {search} ----------");
                        break;
                }
            }
        }
    }
}
