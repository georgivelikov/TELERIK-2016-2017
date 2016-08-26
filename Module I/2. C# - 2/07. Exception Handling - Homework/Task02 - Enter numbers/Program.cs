using System;

public class Program
{
    public static void Main()
    {
        try
        {
            int up = 100;
            int down = 0;
            int[] arr = new int[12];
            arr[0] = 1;
            arr[11] = 100;
            for (int i = 1; i < 11; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (num < down || num > up)
                {
                    throw new Exception();
                }

                arr[i] = num;

                if (arr[i] <= arr[i - 1])
                {
                    throw new Exception();
                }
                

                
            }

            Console.WriteLine(string.Join(" < ", arr));
        }
        catch (Exception)
        {

            Console.WriteLine("Exception");
        }
    }
}

