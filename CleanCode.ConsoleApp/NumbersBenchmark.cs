using System;
using BenchmarkDotNet.Attributes;
using CleanCode.ConsoleApp.Benchmarks;

namespace CleanCode.ConsoleApp
{
    [MemoryDiagnoser]
    public class NumbersBenchmark
    {
        private readonly string _content;

        public NumbersBenchmark()
        {
            _content = GenerateContentString();
            Console.WriteLine($"{nameof(_content)} size: {_content.Length}");
            Console.WriteLine($"{_content.Substring(0, 100)}...");
        }

        /// <summary>
        /// Generates a string with 555000 characters.
        /// </summary>
        /// <returns>1000;1001;1002;1003;1004;1005;1006;1007;1008;1009;1010;1011;1012;1013;1014;1015;1016;1017;1018;1019;...</returns>
        public static string GenerateContentString()
        {
            var content = "";

            for (var i = 0; i < 1000; i++)
            for (var y = 1000; y < 1111; y++)
            {
                content += $"{y};";
            }

            return content;
        }

        [Benchmark]
        public void Regex()
        {
            var numbers = NumberParser_Regex.Parse(_content);
        }

        [Benchmark]
        public void IndexOf()
        {
            var numbers = NumberParser_IndexOf.Parse(_content);
        }

        [Benchmark]
        public void Split()
        {
            var numbers = NumberParser_Split.Parse(_content);
        }

        [Benchmark]
        public void Linq()
        {
            var numbers = NumberParser_Linq.Parse(_content);
        }

        [Benchmark]
        public void Bytes()
        {
            var numbers = NumberParser_Bytes.Parse(_content);
        }

        [Benchmark]
        public void Span()
        {
            var numbers = NumberParser_Span.Parse(_content);
        }
    }
}