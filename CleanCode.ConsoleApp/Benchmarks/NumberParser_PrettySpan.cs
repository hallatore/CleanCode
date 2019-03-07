using System;
using System.Collections.Generic;

namespace CleanCode.ConsoleApp.Benchmarks
{
    public static class NumberParser_PrettySpan
    {
        public static Dictionary<int, int> Parse(string input)
        {
            var span = input.AsSpan();
            var result = new Dictionary<int, int>();
            var index = span.IndexOf(';');

            while (index > 0)
            {
                var number = ConvertToInt(span.Slice(0, index));

                if (result.ContainsKey(number))
                {
                    result[number]++;
                }
                else
                {
                    result.Add(number, 1);
                }

                span = span.Slice(index + 1);
                index = span.IndexOf(';');
            }

            return result;
        }

        private static int ConvertToInt(ReadOnlySpan<char> span)
        {
            var result = 0;

            foreach (var n in span)
            {
                result = result * 10 + (n - '0');
            }

            return result;
        }
    }
}