    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoldAndSum
{
    class FoldAndSum
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int k = numbers.Length / 4;

            //First Row:
            var leftPart = numbers.Take(k).Reverse().ToArray();
            var rightPart = numbers.Reverse().Take(k).ToArray();
            var firstRow = leftPart.Concat(rightPart).ToArray();

            //Second Row:

            var secondRow = numbers.Skip(k).Take(2 * k).ToArray();

            //Sum:

            var sum = firstRow.Select((x, index) => x + secondRow[index]).ToArray();

            Console.WriteLine(string.Join(" ", sum));
        }
    }
}
