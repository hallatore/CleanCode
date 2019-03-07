using System;
using BenchmarkDotNet.Running;
using CleanCode.ConsoleApp.Benchmarks;

namespace CleanCode.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //LocalTest();
            var summary = BenchmarkRunner.Run<NumbersBenchmark>();
        }

        private static void LocalTest()
        {
            var content = NumbersBenchmark.GenerateContentString();
            var top10 = NumberParser_Linq.Parse(content);

            foreach (var number in top10)
            {
                Console.WriteLine($"{number.Key}:\t{number.Value}");
            }

            Console.ReadKey();
        }
    }
}
