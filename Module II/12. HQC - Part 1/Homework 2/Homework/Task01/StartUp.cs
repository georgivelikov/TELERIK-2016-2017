using System;

public class StartUp
{
    private const int MaxCount = 6;

    public static void Main()
    {
        BoolPrinter stringParser = new BoolPrinter();

        stringParser.ConvertBoolToString(true);
    }

    public class BoolPrinter
    {
        public void ConvertBoolToString(bool boolValue)
        {
            string valueAsString = boolValue.ToString();

            Console.WriteLine(valueAsString);
        }
    }
}
