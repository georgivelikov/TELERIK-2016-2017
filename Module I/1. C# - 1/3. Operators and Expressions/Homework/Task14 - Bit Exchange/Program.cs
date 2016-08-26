using System;

public class Program
{
    public static void Main()
    {
        uint n = uint.Parse(Console.ReadLine());
        char[] arr = Convert.ToString(n, 2).PadLeft(32, '0').ToCharArray();
        char bit3 = arr[32 - 1 - 3];
        char bit4 = arr[32 - 1 - 4];
        char bit5 = arr[32 - 1 - 5];
        char bit24 = arr[32 - 1 - 24];
        char bit25 = arr[32 - 1 - 25];
        char bit26 = arr[32 - 1 - 26];
        char temp3 = bit3;
        char temp4 = bit4;
        char temp5 = bit5;

        arr[32 - 1 - 3] = bit24;
        arr[32 - 1 - 4] = bit25;
        arr[32 - 1 - 5] = bit26;
        arr[32 - 1 - 24] = temp3;
        arr[32 - 1 - 25] = temp4;
        arr[32 - 1 - 26] = temp5;
        string s = new string(arr);
        Console.WriteLine(Convert.ToUInt32(s, 2));
    }
}

