using System;
using System.Text;

public class Program
{
    public static void Main()
    {
        string message = Console.ReadLine();
        string cyfer = Console.ReadLine();

        string c = Encrypt(message, cyfer);
        string final = Encode(c + cyfer) + cyfer.Length;
        Console.WriteLine(final);
    }

    private static string Encrypt(string message, string cyfer)
    {
        int maxLen = Math.Max(message.Length, cyfer.Length);
        StringBuilder encrypt = new StringBuilder(message);

        for (int i = 0; i < maxLen; i++)
        {
            int mIndex = i % message.Length;
            int cIndex = i % cyfer.Length;

            char result = (char)(65 + ((encrypt[mIndex] - 65) ^ (cyfer[cIndex] - 65)));
            encrypt[mIndex] = result;
        }

        return encrypt.ToString();
    }

    private static string Encode(string str)
    {
        int counter = 1;
        StringBuilder result = new StringBuilder();
        StringBuilder current = new StringBuilder();
        if (str.Length == 2)
        {
            return str;
        }

        current.Append(str[0]);
        for (int i = 0; i < str.Length - 1; i++)
        {
            if (i != str.Length - 2)
            {
                if (str[i] == str[i + 1])
                {
                    current.Append(str[i + 1]);
                    counter++;
                }
                else
                {
                    // i == last or 0
                    string s = counter + "" + str[i];
                    if (counter > s.Length)
                    {
                        result.Append(s);
                    }
                    else
                    {
                        result.Append(new string(str[i], counter));
                    }

                    counter = 1;
                    current.Clear();
                    current.Append(str[i + 1]);
                }
            }
            else
            {
                if (str[i] == str[i + 1])
                {
                    current.Append(str[i + 1]);
                    counter++;
                    string s = counter + "" + str[i];
                    if (counter > s.Length)
                    {
                        result.Append(s);
                    }
                    else
                    {
                        result.Append(new string(str[i], counter));
                    }

                    counter = 1;
                    current.Clear();
                    current.Append(str[i + 1]);
                }
                else
                {
                    // i == last or 0
                    string s = counter + "" + str[i];
                    if (counter > s.Length)
                    {
                        result.Append(s);
                    }
                    else
                    {
                        result.Append(new string(str[i], counter));
                    }

                    counter = 1;
                    current.Clear();
                    result.Append(str[str.Length - 1]);
                }
            }
        }

        return result.ToString();
    }
}

