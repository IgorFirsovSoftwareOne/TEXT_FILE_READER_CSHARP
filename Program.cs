using System;
using System.Diagnostics;

namespace Textdateiauslesung
{
    class Program
    {
        static void Main(string[] args)
        {
            var textFile = new Textfile();
            Stopwatch sw = new Stopwatch();

            sw.Start();
            // CODE

            textFile.ReadTextFile();
            textFile.DisplayWordFrequency();

            // CODE
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
            Console.ReadLine();
        }
    }
}
