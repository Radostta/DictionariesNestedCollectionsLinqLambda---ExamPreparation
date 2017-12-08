using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trainlands
{
    class Trainlands
    {
        static void Main(string[] args)
        {
            var trains = new Dictionary<string, Dictionary<string, long>>();

            string input = Console.ReadLine();
            while (input != "It's Training Men!")
            {
                bool flag = false;
                if (input.IndexOf('=') != -1)
                {
                    flag = true;
                }
                string[] data = input.Split("->=: ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                if (data.Length > 2)
                {
                    var trainName = data[0];
                    var wagonName = data[1];
                    var wagonPower = long.Parse(data[2]);

                    if (!trains.ContainsKey(trainName))
                    {
                        trains.Add(trainName, new Dictionary<string, long>());
                    }
                    trains[trainName][wagonName] = wagonPower;
                }
                else
                {
                    string trainName = data[0];
                    string otherTrainName = data[1];

                    if (flag)
                    {
                        trains.Remove(trainName);
                    }

                    if (!trains.ContainsKey(trainName))
                    {
                        trains.Add(trainName, new Dictionary<string, long>());
                    }
                    
                    foreach (var item in trains[otherTrainName])
                    {
                        trains[trainName].Add(item.Key, item.Value);
                    }

                    if (!flag)
                    {
                        trains.Remove(otherTrainName);
                    }                    
                }

                input = Console.ReadLine();
            }

            foreach (var item in trains.OrderByDescending(x => trains[x.Key].Sum(e => e.Value)).ThenBy(k => k.Value.Count))
            {
                Console.WriteLine($"Train: {item.Key}");

                foreach (var inner in item.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"###{inner.Key} - {inner.Value}");
                }
            }
        }
    }
}
