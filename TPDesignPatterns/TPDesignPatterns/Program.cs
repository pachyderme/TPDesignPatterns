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
    }

    class Program
    {
        public static bool displayCompleteMessage = true;
        public static IExportData ExportData { get; set; }

        static void Main(string[] args)
        {


            Client c = new Client();
            c.Connect();

            // Historic h = Historic.GetInstance();






            //while (true)
            //{
            //    Console.ForegroundColor = ConsoleColor.White;

            //    Console.WriteLine("SEARCH / COMMAND (EXPORTSQL | EXPORTJSON | EXPORTXML) : ");
            //    String search = Console.ReadLine();

            //    bool isExport = false;

            //    switch (search.ToUpper())
            //    {
            //        case Command.EXPORTJSON:

            //            isExport = true;
            //            break;
            //        case Command.EXPORTSQL:
            //            exportData = new ExportSQL();
            //            isExport = true;
            //            break;
            //        case Command.EXPORTXML:
            //            break;
            //        default:
            //            Console.ForegroundColor = ConsoleColor.Green;

            //            Console.WriteLine($"---------- SEARCH {search} ----------");
            //            h.messages.ForEach(m => {
            //                if (m.Search(search))
            //                {
            //                    Console.WriteLine(m.ToString());
            //                }
            //            });

            //            Console.WriteLine($"---------- SEARCH {search} ----------");
            //            break;

            //    }

            //    if (isExport)
            //    {
            //        exportData.Export();
            //    }

            //}
            Console.ReadLine();
        }
    }
}
