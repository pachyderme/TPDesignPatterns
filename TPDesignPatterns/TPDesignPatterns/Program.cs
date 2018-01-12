using System;
using TPDesignPatterns.Models.Exports;
using TPDesignPatterns.Models.Historic;
using TPDesignPatterns.Models.Clients;
using TPDesignPatterns.Models.Database;
using TPDesignPatterns.Models.Messages;

namespace TPDesignPatterns
{
    class Command
    {
        public const string EXPORTSQL = "EXPORTSQL";
        public const string EXPORTJSON = "EXPORTJSON";
        public const string EXPORTXML = "EXPORTXML";
        public const string DISCONNECT = "DISCONNECT";
        public const string SEARCH = "SEARCH";
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

                Console.WriteLine("COMMANDS : (EXPORTSQL | EXPORTJSON | EXPORTXML | SEARCH) ");
                Console.WriteLine("TAGS : [b][/b] : BOLD");
                Console.WriteLine("TAGS : [i][/i] : ITALIC");
                Console.WriteLine("TAGS : [u][/u] : UNDERLINE");
                Console.WriteLine("TAGS : [l='http://mylink.com']link name[/l] : LINK");
                Console.WriteLine("TAGS : [c='#333'][/c] : COLOR");
                Console.WriteLine("Enter command or text.....");
                String input = Console.ReadLine();

                switch (input.ToUpper())
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
                    case Command.SEARCH:

                        Console.WriteLine("Enter your search :");

                        string search = Console.ReadLine();

                        Console.ForegroundColor = ConsoleColor.Green;

                        Console.WriteLine($"---------- SEARCH {search} ----------");
                        client.GetMessages().ForEach(m =>
                        {
                            if (m.Search(search))
                            {
                                Console.WriteLine(m.ToString());
                            }
                        });

                        Console.WriteLine($"---------- SEARCH {search} ----------");
                        break;
                    default:
                        displayCompleteMessage = true;
                        client.Send(input);
                        displayCompleteMessage = false;
                        break;
                }
            }
        }
    }
}
