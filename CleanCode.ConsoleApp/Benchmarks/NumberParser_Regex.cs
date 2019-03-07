using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CleanCode.ConsoleApp.Benchmarks
{
    public static class NumberParser_Regex
    {
        public static Dictionary<int, int> Parse(string input)
        {
            var result = new Dictionary<int, int>();
            var matches = Regex.Matches(input, @"(\d+);");

            for (var i = 0; i < matches.Count; i++)
            {
                var number = Convert.ToInt32(matches[i].Groups[1].Value);

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