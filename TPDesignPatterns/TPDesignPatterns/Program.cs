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
        public static IExportData ExportData { get; set; }

        static void Main(string[] args)
        {
            Client client = new Client();
            client.Connect();

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("SEARCH / COMMAND (EXPORTSQL | EXPORTJSON | EXPORTXML) : ");
                String search = Console.ReadLine();

                bool isExport = false;

                switch (search.ToUpper())
                {
                    case Command.EXPORTJSON:

                        isExport = true;
                        break;
                    case Command.EXPORTSQL:
                        ExportData = new ExportSQL();
                        isExport = true;
                        break;
                    case Command.EXPORTXML:
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

                if (isExport)
                {
                    ExportData.Export();
                }
            }
        }
    }
}
