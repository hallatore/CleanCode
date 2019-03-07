using System;
using System.Collections.Generic;

namespace CleanCode.ConsoleApp.Benchmarks
{
    public static class NumberParser_IndexOf
    {
        public static Dictionary<int, int> Parse(string input)
        {
            var result = new Dictionary<int, int>();
            var index = 0;

            while (true)
            {
                var newIndex = input.IndexOf(";", index, StringComparison.Ordinal);

                if (newIndex < 0)
                {
                    break;
                }

                var number = Convert.ToInt32(input.Substring(index, newIndex - index));

                if (result.ContainsKey(number))
                {
                    result[number]++;
                }
                else
                {
                    result.Add(number, 1);
                }

                index = newIndex + 1;
            }

            return result; 
        }
    }
}