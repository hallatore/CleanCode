using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace CleanCode.ConsoleApp.Benchmarks
{
    public static class NumberParser_Bytes
    {
        public static Dictionary<int, int> Parse(string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            var length = bytes.Length;
            var result = new Dictionary<int, int>();
            var index = 0;
            var newIndex = SeekSemiColon(ref bytes, index, length);

            while (newIndex > 0)
            {
                var number = ConvertToInt(ref bytes, index, newIndex - index);

                if (result.ContainsKey(number))
                {
                    result[number]++;
                }
                else
                {
                    result.Add(number, 1);
                }

                index = newIndex + 1;
                newIndex = SeekSemiColon(ref bytes, index, length);
            }

            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int SeekSemiColon(ref byte[] buffer, int start, int end)
        {
            while (start < end)
            {
                if (buffer[start] == 59)
                    return start;

                start++;
            }

            return -1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int ConvertToInt(ref byte[] bytes, int start, int length)
        {
            var result = 0;

            for (var i = 0; i < length; i++)
            {
                result = result * 10 + (bytes[start + i] - '0');
            }

            return result;
        }
    }
}