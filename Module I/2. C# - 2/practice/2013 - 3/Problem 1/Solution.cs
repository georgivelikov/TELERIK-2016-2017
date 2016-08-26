#undef DEBUG

using System;
using System.Collections.Generic;
using System.Text;

class ConvertFrom9NumeralSystem
{
	private static string[] digits = new string[]
	{
		"-!",    // 0
		"**",    // 1
		"!!!",   // 2
		"&&",    // 3
		"&-",    // 4
		"!-",    // 5
		"*!!!",  // 6
		"&*!",   // 7
		"!!**!-" // 8
	};

	static void Main()
	{
		string numberBase9 = Console.ReadLine();
		ulong numberBase10 = ConvertNumberFromBase9(numberBase9);
		Console.WriteLine(numberBase10);

#if DEBUG
		string numberBackInBase9 = ConvertNumberToBase9(numberBase10);
		Console.WriteLine(numberBackInBase9);
#endif
	}

	private static ulong ConvertNumberFromBase9(string numberBase9)
	{
		StringBuilder number = new StringBuilder(numberBase9);
		ulong sum = 0;
		while (number.Length > 0)
		{
			for (int digit = 0; digit < digits.Length; digit++)
			{
				if (number.ToString().StartsWith(digits[digit]))
				{
					sum = sum * 9 + (ulong)digit;
					number.Remove(0, digits[digit].Length);
				}
			}
		}

		return sum;
	}

	private static string ConvertNumberToBase9(ulong number)
	{
		StringBuilder resultDigits = new StringBuilder();
		do
		{
			ulong remainder = number % 9;
			string nextDigit = digits[remainder];
			resultDigits.Insert(0, nextDigit);
			number = number / 9;
		} while (number > 0);
		string result = resultDigits.ToString();
		return result;
	}
}
