using System;
using System.Collections.Generic;

namespace CleanCode.ConsoleApp.Benchmarks
{
    public static class NumberParser_Split
    {
        public static Dictionary<int, int> Parse(string input)
        {
            var result = new Dictionary<int, int>();
            var numbers = input.Split(';', StringSplitOptions.RemoveEmptyEntries);

            foreach (var numberString in numbers)
            {
                var number = Convert.ToInt32(numberString);

                if (result.ContainsKey(number))
                {
                    result[number]++;
                }
                else
                {
                    result.Add(number, 1);
                }
            }

            return result;
        }
    }
}