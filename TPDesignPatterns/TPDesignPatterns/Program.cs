using System;
using TPDesignPatterns.Models.Historic;

namespace TPDesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Historic h = Historic.GetInstance();

            h.messages.ForEach(m => Console.WriteLine($"Message : {m.ToString()}"));

            Console.ReadLine();
        }
    }
}
