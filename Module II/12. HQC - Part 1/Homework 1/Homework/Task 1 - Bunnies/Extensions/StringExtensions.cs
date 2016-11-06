using System.Text;

namespace Extensions
{
    public static class StringExtensions
    {
        private const char SingleWhiteSpace = ' ';

        public static string SplitToSeparateWordsByUppercaseLetter(this string inputString)
        {
            var builder = new StringBuilder();

            foreach (var letter in inputString)
            {
                if (char.IsUpper(letter))
                {
                    builder.Append(SingleWhiteSpace);
                }

                builder.Append(letter);
            }

            return builder.ToString().Trim();
        }
    }
}