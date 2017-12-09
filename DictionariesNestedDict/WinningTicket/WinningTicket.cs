using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WinningTicket
{
    class WinningTicket
    {
        static void Main(string[] args)
        {
            string[] tickets = Console.ReadLine().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            char[] symbols = { '#', '$', '@', '^' };
            bool isMatch = false;

            foreach (var ticket in tickets)
            {
                if (ticket.Length != 20)
                {
                    Console.WriteLine("invalid ticket");
                    continue;
                }

                string leftHalf = ticket.Substring(0, 10);
                string rightHalf = ticket.Substring(10, 10);
                string pattern;
                int occurrencesLeft = 0;
                int occurrencesRight = 0;
                int occurrencesTotal = 0;

                foreach (var symbol in symbols)
                {
                    if (symbol == '^')
                    {
                        pattern = @"[\^]{6,}";
                    }
                    else
                    {
                        pattern = @"[" + symbol + "]{6,}";
                    }
                    occurrencesLeft = Regex.Match(leftHalf, pattern).Length;
                    occurrencesRight = Regex.Match(rightHalf, pattern).Length;
                    occurrencesTotal = Math.Min(occurrencesLeft, occurrencesRight);

                    if (Regex.IsMatch(leftHalf, pattern) && Regex.IsMatch(rightHalf, pattern))
                    {
                        isMatch = true;
                        if (occurrencesTotal >= 6 && occurrencesTotal <= 9)
                        {
                            Console.WriteLine($"ticket \"{ticket}\" - {occurrencesTotal}{symbol}");
                        }
                        else
                        {
                            Console.WriteLine($"ticket \"{ticket}\" - 10{symbol} Jackpot!");
                        }
                        continue;
                    }                                        
                }

                if (isMatch == false)
                {
                    Console.WriteLine($"ticket \"{ticket}\" - no match");
                }

                isMatch = false;
            }
        }
    }
}
