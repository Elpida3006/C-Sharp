using System;
using System.Collections.Generic;
using System.Linq;

namespace Knapsack_Dynamic_optimization
{
  
    class Program
    {
        static void Main()
        {
            int maxCapacity = int.Parse(Console.ReadLine());

            var items = new List<Item>();
            
            while(true)
            {
                var line = Console.ReadLine();
                if (line == "end")
                {
                    break;
                }

                var parts = line.Split(' ');
                    items.Add(new Item
                    {
                        Name = parts[0],
                        Weight = int.Parse(parts[1]),
                        Price = int.Parse(parts[2])
                    });
              
            }
            var pricesMatrix = new int[items.Count + 1, maxCapacity + 1];
            var itemsIncluded = new bool[items.Count + 1, maxCapacity + 1];

            for (int itemIndex = 1; itemIndex < items.Count; itemIndex++)
            {
                var item = items[itemIndex];
                var rowIndex = itemIndex + 1;

                for (int capacit = 0; capacit <= maxCapacity; capacit++)
                {
                    if (item.Weight > capacit)
                    {
                        continue;
                    }
                    var exluding = pricesMatrix[rowIndex  - 1, capacit];
                    var including = item.Price + pricesMatrix[rowIndex - 1, capacit - item.Weight];

                    if (including > exluding)
                    {
                        pricesMatrix[rowIndex, capacit] = including;
                        itemsIncluded[rowIndex, capacit] = true;
                    }
                    else
                    {
                        pricesMatrix[rowIndex, capacit] = exluding;
                    }
                }

            }
            Console.WriteLine(pricesMatrix[items.Count, maxCapacity]);
            var capacity = maxCapacity;
        

            var result = new List<Item>();

              for (int itemIndex = items.Count - 1; itemIndex >= 0; itemIndex--)
            {
                if (capacity <= 0)
                {
                    break;
                }
                if (itemsIncluded[itemIndex + 1, capacity])
                {
                    var currentitem = items[itemIndex];
                    result.Add(currentitem);
                    capacity -= currentitem.Weight;

                }
            }
            Console.WriteLine(result.Sum(i => i.Weight));
            Console.WriteLine(pricesMatrix[items.Count, maxCapacity]);



        }
    }
}
