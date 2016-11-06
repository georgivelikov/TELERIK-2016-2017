using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

/// <summary>
/// Static class StringExtensions adds functionalities to the System.String type
/// </summary>
public static class StringExtensions
{

    /// <summary>
    /// ToMD5Hash method encrypts a string into a hash value. 
    /// The MD5 message-digest algorithm is a widely used cryptographic hash function producing a 128-bit (16-byte) 
    /// hash value, typically expressed in text format as a 32 digit hexadecimal number. https://en.wikipedia.org/wiki/MD5
    /// </summary>
    /// <param name="input">Variable of type string.</param>
    /// <returns>32 digit hexadecimal number in string format.</returns>
    public static string ToMD5Hash(this string input)
    {
        var md5Hash = MD5.Create();
        var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
        var builder = new StringBuilder();

        for (int i = 0; i < data.Length; i++)
        {
            builder.Append(data[i].ToString("x2"));
        }

        return builder.ToString();
    }
    
    /// <summary>
    /// Checks if the input string can be assumed as a confirmation statement.
    /// If it can, returns true, else - returns false.
    /// </summary>
    /// <param name="input">Variable of type string.</param>
    /// <returns>Variable of boolean type - true or false.</returns>
    public static bool ToBoolean(this string input)
    {
        var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
        return stringTrueValues.Contains(input.ToLower());
    }

    /// <summary>
    /// Parse string input into number of type short. If unsuccessful, returns default value for type short - 0.
    /// </summary>
    /// <param name="input">Variable of type string.</param>
    /// <returns>A value of type short.</returns>
    public static short ToShort(this string input)
    {
        short shortValue;
        short.TryParse(input, out shortValue);
        return shortValue;
    }

    /// <summary>
    /// Parse string input into number of integer type. If unsuccessful, returns default value for integer type - 0.
    /// </summary>
    /// <param name="input">Variable of type string.</param>
    /// <returns>A value of integer type.</returns>
    public static int ToInteger(this string input)
    {
        int integerValue;
        int.TryParse(input, out integerValue);
        return integerValue;
    }

    /// <summary>
    /// Parse string input into number of type long. If unsuccessful, returns default value for type long - 0.
    /// </summary>
    /// <param name="input">Variable of type string.</param>
    /// <returns>A value of type long.</returns>
    public static long ToLong(this string input)
    {
        long longValue;
        long.TryParse(input, out longValue);
        return longValue;
    }

    /// <summary>
    /// Tries to parse string input into DateTime type. If unsuccessful, returns default for DateTime object - 1.1.0001. 00:00:00
    /// </summary>
    /// <param name="input">Variable of type string.</param>
    /// <returns>A value of type DateTime.</returns>
    public static DateTime ToDateTime(this string input)
    {
        DateTime dateTimeValue;
        DateTime.TryParse(input, out dateTimeValue);
        return dateTimeValue;
    }

    /// <summary>
    /// (No need for additional explanation)
    /// </summary>
    /// <param name="input">Variable of type string.</param>
    /// <returns>Returns the input string with capitalized first letter.</returns>
    public static string CapitalizeFirstLetter(this string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        return 
            input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + 
            input.Substring(1, input.Length - 1);
    }

    /// <summary>
    /// Returns a substring of the input string, which is found between the indexes of the 
    /// first occurrences of startString and endString parameters.
    /// </summary>
    /// <param name="input">AA value representing the input string.</param>
    /// <param name="startString">A value representing the starting string.</param>
    /// <param name="endString">A value representing the ending string.</param>
    /// <param name="startFrom">A value of integer type. Represent the index where the search begins. Set to 0 by default.</param>
    /// <returns>A value of type string.</returns>
    public static string GetStringBetween(this string input, string startString, string endString, int startFrom = 0)
    {
        input = input.Substring(startFrom);
        startFrom = 0;
        if (!input.Contains(startString) || !input.Contains(endString))
        {
            return string.Empty;
        }

        var startPosition = 
            input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
        if (startPosition == -1)
        {
            return string.Empty;
        }

        var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
        if (endPosition == -1)
        {
            return string.Empty;
        }

        return input.Substring(startPosition, endPosition - startPosition);
    }

    /// <summary>
    /// (No need for additional explanation)
    /// </summary>
    /// <param name="input">A value of type string.</param>
    /// <returns>A string where all cyrillic letters have been changed to latin letters.</returns>
    public static string ConvertCyrillicToLatinLetters(this string input)
    {
        var bulgarianLetters = new[]
        {
            "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о",
            "п", "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
        };
        var latinRepresentationsOfBulgarianLetters = new[]
        {
            "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
            "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
            "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
        };
        for (var i = 0; i < bulgarianLetters.Length; i++)
        {
            input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
            input = input.Replace(bulgarianLetters[i].ToUpper(), latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
        }

        return input;
    }

    /// <summary>
    /// (No need for additional explanation)
    /// </summary>
    /// <param name="input">A value of type string.</param>
    /// <returns>A string where all latin letters have been changed to cyrillic letters.</returns>
    public static string ConvertLatinToCyrillicKeyboard(this string input)
    {
        var latinLetters = new[]
        {
            "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
            "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
        };

        var bulgarianRepresentationOfLatinKeyboard = new[]
        {
            "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
            "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
            "в", "ь", "ъ", "з"
        };

        for (int i = 0; i < latinLetters.Length; i++)
        {
            input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
            input = input.Replace(latinLetters[i].ToUpper(), bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
        }

        return input;
    }

    /// <summary>
    /// Removes all characters that are not latin letters, numbers, dot or underscore from the input string. 
    /// Returns the modified string and considered it a valid username.
    /// </summary>
    /// <param name="input">A value of type string.</param>
    /// <returns>A value of type string with all specified characters removed.</returns>
    public static string ToValidUsername(this string input)
    {
        input = input.ConvertCyrillicToLatinLetters();
        return Regex.Replace(input, @"[^a-zA-Z0-9_\.]+", string.Empty);
    }

    /// <summary>
    /// Removes all characters that are not latin letters, numbers, dot, dash or underscore from the input string. 
    /// Returns the modified string and considered it a valid filename.
    /// </summary>
    /// <param name="input">A value of type string.</param>
    /// <returns>A value of type string with all specified characters removed.</returns>
    public static string ToValidLatinFileName(this string input)
    {
        input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
        return Regex.Replace(input, @"[^a-zA-Z0-9_\.\-]+", string.Empty);
    }

    /// <summary>
    /// Returns the first charsCount characters of the input string.
    /// </summary>
    /// <param name="input">A value of type string.</param>
    /// <param name="charsCount">Number of characters to be returned.</param>
    /// <returns>A value of type string, substring of the input string.</returns>
    public static string GetFirstCharacters(this string input, int charsCount)
    {
        return input.Substring(0, Math.Min(input.Length, charsCount));
    }

    /// <summary>
    /// Gets the extension of the specified file. If file doesn't exist, returns null.
    /// </summary>
    /// <param name="fileName">The name of the file.</param>
    /// <returns>The extension of the file in string format.</returns>
    public static string GetFileExtension(this string fileName)
    {
        if (string.IsNullOrWhiteSpace(fileName))
        {
            return string.Empty;
        }

        string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
        if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
        {
            return string.Empty;
        }

        return fileParts.Last().Trim().ToLower();
    }

    /// <summary>
    /// Returns the content type of a given file.
    /// </summary>
    /// <param name="fileExtension">The file extension.</param>
    /// <returns>A string containing the content type of the provided file extension.</returns>
    public static string ToContentType(this string fileExtension)
    {
        var fileExtensionToContentType = new Dictionary<string, string>
        {
            { "jpg", "image/jpg" },
            { "jpeg", "image/jpeg" },
            { "png", "image/x-png" },
            { "docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" },
            { "doc", "application/msword" },
            { "pdf", "application/pdf" },
            { "txt", "text/plain" },
            { "rtf", "application/rtf" }
        };
        if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
        {
            return fileExtensionToContentType[fileExtension.Trim()];
        }

        return "application/octet-stream";
    }

    /// <summary>
    /// Returns an array of bytes where each symbol of the input string is converted to its ASCII representation.
    /// </summary>
    /// <param name="input">A value of type string</param>
    /// <returns>A byte array.</returns>
    public static byte[] ToByteArray(this string input)
    {
        var bytesArray = new byte[input.Length * sizeof(char)];
        Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
        return bytesArray;
    }
}
