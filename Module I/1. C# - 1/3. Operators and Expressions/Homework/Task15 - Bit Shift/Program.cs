using System;

public class Program
{
    public static void Main()
    {
        uint n = uint.Parse(Console.ReadLine());
        int p = int.Parse(Console.ReadLine());
        int q = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());
        char[] arr = Convert.ToString(n, 2).PadLeft(32, '0').ToCharArray();

        for (int i = 0; i < k; i++)
        {
            char temp = arr[arr.Length - 1 - p - i];
            arr[arr.Length - 1 - p - i] = arr[arr.Length - 1 - q - i];
            arr[arr.Length - 1 - q - i] = temp;
        }
        string s = new string(arr);
        Console.WriteLine(s);
        Console.WriteLine(Convert.ToUInt32(s, 2));
    }
}

