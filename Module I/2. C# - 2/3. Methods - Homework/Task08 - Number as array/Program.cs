using System;
using System.Linq;
using System.Text;

public class Program
{
    public static void Main()
    {
        int[] size = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();

        string lineOne = Console.ReadLine();
        string lineTwo = Console.ReadLine();

        lineOne = lineOne.Replace(" ", "");
        lineTwo = lineTwo.Replace(" ", "");

        if (size[0] > size[1])
        {
            lineTwo = lineTwo + new string('0', size[0] - size[1]);
        }
        else if (size[0] < size[1])
        {
            lineOne = lineOne + new string('0', size[1] - size[0]);
        }

        int[] arrOne = lineOne.ToCharArray().Select(x => int.Parse(x.ToString())).ToArray();
        int[] arrTwo = lineTwo.ToCharArray().Select(x => int.Parse(x.ToString())).ToArray();

        Console.WriteLine(CalculateSum(arrOne, arrTwo));
    }

    private static string CalculateSum(int[] arrOne, int[] arrTwo)
    {
        StringBuilder sb = new StringBuilder();
        bool b = false;

        for (int i = 0; i < arrOne.Length; i++)
        {
            int sum = arrOne[i] + arrTwo[i];

            if (b)
            {
                sum++;
            }

            if (sum <= 9)
            {
                sb.Append(sum + " ");
                b = false;
            }
            else
            {
                sum -= 10;
                sb.Append(sum + " ");
                b = true;
            }
        }

        return sb.ToString().Trim();
    }
}

