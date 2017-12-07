using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousCache
{
    class AnonymousCache
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<string> dataSetList = new List<string>();
            Dictionary<string, Dictionary<string, long>> dataSetInfo = new Dictionary<string, Dictionary<string, long>>();

            while (input != "thetinggoesskrra")
            {
                string[] data = input.Split(" ->|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                if (input.IndexOf('|') == -1) // OR if(data.Length == 1)
                {
                    string dataSet = data[0];
                    dataSetList.Add(dataSet);
                }
                else
                {
                    string dataKey = data[0];
                    long dataSize = long.Parse(data[1]);
                    string dataSet = data[2];

                    if (!dataSetInfo.ContainsKey(dataSet))
                    {
                        dataSetInfo.Add(dataSet, new Dictionary<string, long>());
                    }
                    dataSetInfo[dataSet][dataKey] = dataSize;
                }
                input = Console.ReadLine();
            }

            dataSetInfo.ToList().Where(e => !dataSetList.Contains(e.Key)).ToList().ForEach(e => dataSetInfo.Remove(e.Key));

            ////Non-functional:
            //foreach (var item in dataSetList)
            //{
            //    if (!dataSetInfo.ContainsKey(item))
            //    {
            //        dataSetInfo = dataSetInfo.Remove(item);
            //    }
            //}

            if (dataSetInfo.Count > 0) //OR (dataSetList.Count > 0)
            {
                var result = dataSetInfo.OrderByDescending(x => x.Value.Sum(e => e.Value)).First();

                Console.WriteLine($"Data Set: {result.Key}, Total Size: {result.Value.Sum(e => e.Value)}");

                foreach (var item in result.Value)
                {
                    Console.WriteLine($"$.{item.Key}");
                }
            }


            //// -------- WITH 2 DICTIONARIES --------- //

            ////needed structure: string dataset: string datakey: int datasize

            //var data = new Dictionary<string, Dictionary<string, int>>();
            //var cache = new Dictionary<string, Dictionary<string, int>>();

            //var input = Console.ReadLine();
            //while (input != "thetinggoesskrra")
            //{
            //    if (input.Contains("->"))
            //    {
            //        var tokens = input.Split(" \t->|:".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            //        var dataSet = tokens[2];
            //        var dataKey = tokens[0];
            //        var dataSize = int.Parse(tokens[1]);

            //        if (data.ContainsKey(dataSet))
            //        {
            //            data[dataSet][dataKey] = dataSize;
            //        }
            //        else
            //        {
            //            if (!cache.ContainsKey(dataSet))
            //            {
            //                cache[dataSet] = new Dictionary<string, int>();
            //            }
            //            cache[dataSet][dataKey] = dataSize;
            //        }
            //    }
            //    else if (!data.ContainsKey(input))
            //    {
            //        Dictionary<string, int> dataSet;
            //        if (cache.ContainsKey(input))
            //        {
            //            dataSet = cache[input];
            //            cache.Remove(input);
            //        }
            //        else
            //        {
            //            dataSet = new Dictionary<string, int>();
            //        }
            //        data.Add(input, dataSet);
            //    }
            //    input = Console.ReadLine();
            //}

            //if (data.Count == 0) return;

            //string dataSetKey = string.Empty;
            //long maxSize = -1;

            //foreach (var dataSet in data)
            //{
            //    long size = dataSet.Value.Sum(dataKey => (long)dataKey.Value);
            //    if (size <= maxSize) continue;
            //    maxSize = size;
            //    dataSetKey = dataSet.Key;
            //}

            //var set = data[dataSetKey];

            //Console.WriteLine($"Data Set: {dataSetKey}, Total Size: {maxSize}");
            //foreach (var key in set.Keys)
            //{
            //    Console.WriteLine($"$.{key}");
            //}

        }
    }
}
