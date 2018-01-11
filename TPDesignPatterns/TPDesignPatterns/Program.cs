using System;
using TPDesignPatterns.Models.Historic;

namespace TPDesignPatterns
{
    class Program
    {
        public static bool searching = false;

        static void Main(string[] args)
        {
            Historic h = Historic.GetInstance();

            Console.WriteLine("================ ALL MESSAGES ==================");

            h.messages.ForEach(m => m.ToString());

            Console.WriteLine("================ ALL MESSAGES ==================");


            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;

                String search = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.Green;
                searching = !searching;

                Console.WriteLine($"---------- SEARCH {search} ----------");
                h.messages.ForEach(m => {
                    if (m.Search(search))
                    {
                        m.ToString();
                    }
                });

                searching = !searching;
                Console.WriteLine($"---------- SEARCH {search} ----------");
            }
        }
    }
}
