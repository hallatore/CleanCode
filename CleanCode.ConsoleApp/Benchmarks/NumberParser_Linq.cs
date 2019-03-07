using System;
using System.Collections.Generic;
using System.Linq;

namespace CleanCode.ConsoleApp.Benchmarks
{
    public static class NumberParser_Linq
    {
        public static Dictionary<int, int> Parse(string input) => input
            .Split(';', StringSplitOptions.RemoveEmptyEntries)
            .Select(n => Convert.ToInt32(n))
            .GroupBy(n => n, n => (object)null)
            .ToDictionary(n => n.Key, n => n.Count());
    }
}