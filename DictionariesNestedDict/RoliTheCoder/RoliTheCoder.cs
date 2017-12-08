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
            this.Name = name;
            this.Participants = participants;
        }
    }

    class RoliTheCoder
    {
        static void Main(string[] args)
        {
            //INCOMPLETE

            //NB: underline in \w ???
            Regex regex = new Regex(@"^(?<id>\d+)\s*#(?<eventName>\w+)\s+(?<participants>(@[A-Za-z\d'-]+\s*)*)$");

            //key - if -> value: name + List<string>
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
                else if(dictEvents[id].Name == eventName)
                {
                    dictEvents[id].Participants.AddRange(participants);
                    dictEvents[id].Participants = dictEvents[id].Participants.Distinct().ToList();
                }

                foreach (var e in dictEvents.OrderByDescending(e => e.Value.Participants.Count).ThenBy(e => e.Value.Name))
                {
                    Console.WriteLine($"{e.Value.Name} - {e.Value.Participants.Count}");
                    foreach (var p in e.Value.Participants.OrderBy(p => p))
                    {
                        Console.WriteLine(p);
                    }
                }
            }


        }
    }
}
