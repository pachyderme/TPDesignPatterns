using System;
using TPDesignPatterns.Models.Exports;
using TPDesignPatterns.Models.Historic;

namespace TPDesignPatterns
{
    class Command
    {
        public const string EXPORTSQL = "EXPORTSQL";
        public const string EXPORTJSON = "EXPORTJSON";
        public const string EXPORTXML = "EXPORTXML";
    }

    class Program
    {
        public static bool displayCompleteMessage = true;
        public static IExportData exportData { get; set; }

        static void Main(string[] args)
        {
            Historic h = Historic.GetInstance();

            Console.WriteLine("================ ALL MESSAGES ==================");

            h.messages.ForEach(m => Console.WriteLine(m.ToString()));
            displayCompleteMessage = false;

            Console.WriteLine("================ ALL MESSAGES ==================");


            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("SEARCH / COMMAND (EXPORTSQL | EXPORTJSON | EXPORTXML) : ");
                String search = Console.ReadLine();

                bool isExport = false;

                switch (search.ToUpper())
                {
                    case Command.EXPORTJSON:
                        exportData = new ExportJSON();
                        isExport = true;
                        break;
                    case Command.EXPORTSQL:
                        exportData = new ExportSQL();
                        isExport = true;
                        break;
                    case Command.EXPORTXML:
                        exportData = new ExportXML();
                        isExport = true;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Green;

                        Console.WriteLine($"---------- SEARCH {search} ----------");
                        h.messages.ForEach(m => {
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
                    exportData.Export();
                }
                    
            }
        }
    }
}
