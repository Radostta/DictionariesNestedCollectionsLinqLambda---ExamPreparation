using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumMinMaxAverage
{
    class SumMinMaxAverage
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var numbers = new List<int>();

            for (int i = 0; i < n; i++)
            {
                numbers.Add(int.Parse(Console.ReadLine()));
            }

            var sum = numbers.Sum();
            var min = numbers.Min();
            var max = numbers.Max();
            var average = numbers.Average();

            Console.WriteLine($"Sum = {sum}\r\nMin = {min}\r\nMax = {max}\r\nAverage = {average}");
        }



    }
}
