using System;
using System.Collections.Generic;
using System.Linq;

public class Knapsack
{
    public static void Main()
    {
        var items = new[]
        {
            new Item { Name = "beer", Weight = 3, Cost = 2m },
            new Item { Name = "vodka", Weight = 8, Cost = 12m },
            new Item { Name = "cheese", Weight = 4, Cost = 5m },
            new Item { Name = "nuts", Weight = 1, Cost = 4m },
            new Item { Name = "ham", Weight = 2, Cost = 3m },
            new Item { Name = "wiskey", Weight = 8, Cost = 13m }
        };

        var knapsackCapacity = 10;

        var itemsTaken = FillKnapsack(items, knapsackCapacity);

        Console.WriteLine("Knapsack weight capacity: {0}", knapsackCapacity);
        Console.WriteLine("Take the following items in the knapsack:");
        foreach (var item in itemsTaken)
        {
            Console.WriteLine(
                "  (name: {0}, weight: {1}, cost: {2})",
                item.Name,
                item.Weight,
                item.Cost);
        }

        Console.WriteLine("Total weight: {0}", itemsTaken.Sum(i => i.Weight));
        Console.WriteLine("Total Cost: {0}", itemsTaken.Sum(i => i.Cost));
    }

    public static Item[] FillKnapsack(Item[] items, int capacity)
    {
        var maxCost = new decimal[items.Length, capacity + 1];
        var isItemTaken = new bool[items.Length, capacity + 1];

        for (int c = 0; c <= capacity; c++)
        {
            if (items[0].Weight <= c)
            {
                maxCost[0, c] = items[0].Cost;
                isItemTaken[0, c] = true;
            }
        }

        for (int i = 1; i < items.Length; i++)
        {
            for (int c = 0; c <= capacity; c++)
            {
                maxCost[i, c] = maxCost[i - 1, c];
                var remainingCapacity = c - items[i].Weight;
                if (remainingCapacity >= 0 &&
                    items[i].Cost + maxCost[i - 1, remainingCapacity] > maxCost[i - 1, c])
                {
                    maxCost[i, c] = items[i].Cost + maxCost[i - 1, remainingCapacity];
                    isItemTaken[i, c] = true;
                }
            }
        }

        var itemsTaken = new List<Item>();
        var index = items.Length - 1;
        while (index >= 0)
        {
            if (isItemTaken[index, capacity])
            {
                itemsTaken.Add(items[index]);
                capacity -= items[index].Weight;
            }

            index--;
        }

        return itemsTaken.ToArray();
    }

    public class Item
    {
        public string Name { get; set; }

        public int Weight { get; set; }

        public decimal Cost { get; set; }
    }
}

