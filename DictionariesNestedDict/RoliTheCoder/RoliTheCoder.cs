using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RoliTheCoder
{
    public class Event
    {   
        public string Name { get; set; }
        public List<string> Participants { get; set; }

        public Event(string name, List<string> participants)
        {
            Name = name;
            Participants = participants;
        }
    }

    class RoliTheCoder
    {
        static void Main(string[] args)
        {            
            //NB: underline in \w for eventName???
            Regex regex = new Regex(@"^(?<id>\d+)\s*#(?<eventName>\w+)\s*(?<participants>(?:@[A-Za-z0-9'-]+\s*)*)$");

            //key: id -> value: name + List<string>
            var dictEvents = new Dictionary<int, Event>();

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "Time for Code")
                {
                    break;
                }

                Match eventMatch = regex.Match(line);
                if (eventMatch.Success == false)
                {
                    continue;
                }

                int id = int.Parse(eventMatch.Groups["id"].Value);
                string eventName = eventMatch.Groups["eventName"].Value;
                List<string> participants = eventMatch.Groups["participants"].Value.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

                if (!dictEvents.ContainsKey(id))
                {
                    dictEvents.Add(id, new Event(eventName, participants));
                }
                else if (dictEvents[id].Name == eventName)
                {
                    dictEvents[id].Participants.AddRange(participants);
                }                
            }

            foreach (var e in dictEvents)
            {
                e.Value.Participants = e.Value.Participants.Distinct().ToList();
            }

            var ordered = dictEvents.Select(a => a.Value).OrderByDescending(e => e.Participants.Count).ThenBy(e => e.Name);

            foreach (var e in ordered)
            {
                Console.WriteLine($"{e.Name} - {e.Participants.Count}");

                foreach (var p in e.Participants.OrderBy(p => p))
                {
                    Console.WriteLine(p);
                }
            }

            //foreach (var e in dictEvents.OrderByDescending(e => e.Value.Participants.Count).ThenBy(e => e.Value.Name))
            //{
            //    Console.WriteLine($"{e.Value.Name} - {e.Value.Participants.Count}");

            //    foreach (var p in e.Value.Participants.OrderBy(p => p))
            //    {
            //        Console.WriteLine(p);
            //    }
            //}
        }
    }
}
