using System;
using System.Collections.Generic;
using BenchmarkDotNet.Running;
using CleanCode.ConsoleApp.Benchmarks;

namespace CleanCode.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ValidateAll();
            var summary = BenchmarkRunner.Run<NumbersBenchmark>();
        }

        private static void ValidateAll()
        {
            var content = NumbersBenchmark.GenerateContentString();
            var regex = NumberParser_Regex.Parse(content);
            var indexOf = NumberParser_IndexOf.Parse(content);
            var split = NumberParser_Split.Parse(content);
            var linq = NumberParser_Linq.Parse(content);
            var bytes = NumberParser_Bytes.Parse(content);
            var span = NumberParser_Span.Parse(content);
            var prettySpan = NumberParser_PrettySpan.Parse(content);

            ValidateNumbers(regex, indexOf, nameof(indexOf));
            ValidateNumbers(indexOf, split, nameof(split));
            ValidateNumbers(split, linq, nameof(linq));
            ValidateNumbers(linq, bytes, nameof(bytes));
            ValidateNumbers(bytes, span, nameof(span));
            ValidateNumbers(span, prettySpan, nameof(prettySpan));
            ValidateNumbers(prettySpan, regex, nameof(regex));

            Console.WriteLine("Validation complete");
            Console.ReadKey();
        }

        private static void ValidateNumbers(Dictionary<int, int> test1, Dictionary<int, int> test2, string name)
        {
            foreach (var number in test1)
            {
                if (number.Value != test2[number.Key])
                {
                    throw new InvalidOperationException($"{name}, {number.Key}: {number.Value} != {test2[number.Key]}");
                }
            }
        }
    }
}
