using System;

public class Program
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int p = int.Parse(Console.ReadLine());
        char v = Convert.ToChar(Console.ReadLine());

        char[] arr = ConvertToBin(n).PadLeft(32, '0').ToCharArray();
        int shift = p % 32;
        arr[arr.Length - 1 - shift] = v;

        string s = new string(arr);

        Console.WriteLine(ConvertToDec(s));
    }
    
    static string ConvertToBin(int number)
    {
        int dec = number;
        string binReverse = string.Empty;
        string bin = string.Empty;

        for (int i = 0; dec > 0; i++)
        {
            string binHelp = (dec % 2).ToString();
            dec /= 2;
            binReverse += binHelp;
        }
        for (int i = binReverse.Length - 1; i >= 0; i--)
        {
            bin += binReverse[i];
        }

        return bin;
    }

    public static int ConvertToDec(string bin) // String representing long number, ako e negative shte izglejda 1111 1111 1111 1111 1111 1111 111 1101 = -3, da se vzeme pod vnimanie
    {
        decimal binNum = 0; //double ili long/ulong?
        for (int i = bin.Length - 1; i >= 0; i--)
        {
            decimal helpDec = decimal.Parse(bin[i].ToString());
            helpDec *= (decimal)Math.Pow(2, bin.Length - 1 - i);
            binNum += helpDec;
        }

        return (int)binNum;
    }
}

