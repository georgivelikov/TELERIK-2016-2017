using System;
using System.Collections.Generic;

public class ThreeInOne
{
    private static void Main()
    {
        // First task (Blackjack winner)
        string playersListAsString = Console.ReadLine();
        var playersListStringParts = playersListAsString.Split(',');
        var players = new List<int>();
        foreach (var playersListStringPart in playersListStringParts)
        {
            players.Add(int.Parse(playersListStringPart));
        }
        Console.WriteLine(FindBlackjackWinner(players));

        // Second task (Cakes)
        string sizesListAsString = Console.ReadLine();
        var sizesListStringParts = sizesListAsString.Split(',');
        var sizes = new List<int>();
        foreach (var sizesListStringPart in sizesListStringParts)
        {
            sizes.Add(int.Parse(sizesListStringPart));
        }
        int friendsCount = int.Parse(Console.ReadLine());
        Console.WriteLine(FindBitesCount(sizes, friendsCount));

        // Third task
        string thirdTaskInputAsString = Console.ReadLine();
        var thirdTaskInputStringParts = thirdTaskInputAsString.Split(' ');
        int G1 = int.Parse(thirdTaskInputStringParts[0]);
        int S1 = int.Parse(thirdTaskInputStringParts[1]);
        int B1 = int.Parse(thirdTaskInputStringParts[2]);
        int G2 = int.Parse(thirdTaskInputStringParts[3]);
        int S2 = int.Parse(thirdTaskInputStringParts[4]);
        int B2 = int.Parse(thirdTaskInputStringParts[5]);
        Console.WriteLine(BuyBeer(G1, S1, B1, G2, S2, B2));
    }

    private static int FindBlackjackWinner(List<int> points)
    {
        int bestPoints = -1;
        int bestPlayer = -1;

        for (int i = 0; i < points.Count; i++)
        {
            if (points[i] > 21)
            {
                continue;
            }

            if (points[i] > bestPoints)
            {
                bestPoints = points[i];
                bestPlayer = i;
            }
            else if (points[i] == bestPoints)
            {
                bestPlayer = -1;
            }
        }

        return bestPlayer;
    }

    private static int FindBitesCount(List<int> sizes, int friendsCount)
    {
        sizes.Sort(); // Side effect
        int bites = 0;

        for (int i = sizes.Count - 1; i >= 0; i -= friendsCount + 1)
        {
            bites += sizes[i];
        }

        return bites; 
    }

    private static int BuyBeer(int G1, int S1, int B1, int G2, int S2, int B2)
    {
        int exchangeOperations = 0;
        while (G2 > G1)
        {
            --G2;
            S2 += 11;
            exchangeOperations++;
        }

        while (S2 > S1)
        {
            if (G1 > G2)
            {
                --G1;
                S1 += 9;
                exchangeOperations++;
            }
            else
            {
                --S2;
                B2 += 11;
                exchangeOperations++;
            }
        }

        while (B2 > B1)
        {
            if (S1 > S2)
            {
                --S1;
                B1 += 9;
                exchangeOperations++;
            }
            else if (G1 > G2)
            {
                --G1;
                S1 += 9;
                exchangeOperations++;
            }
            else
            {
                return -1;
            }
        }

        return exchangeOperations; 
    }
}
