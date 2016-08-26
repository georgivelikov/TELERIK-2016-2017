using System;

public class ModifyBit
{
    public static void Main()
    {
        int numberN = int.Parse(Console.ReadLine());
        int positionP = int.Parse(Console.ReadLine());
        byte bitValueV = byte.Parse(Console.ReadLine());
        int mask = 1;
        int numberAndMask;

        if (bitValueV == 0)
        {
            int x = ~(mask << positionP);
            numberAndMask = x & numberN;
        }

        else
        {
            int y = mask << positionP;
            numberAndMask = numberN | y;
        }

        Console.WriteLine(numberAndMask);
    }
}
