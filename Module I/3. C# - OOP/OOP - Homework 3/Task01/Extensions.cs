namespace Task01
{
    using System;
    using System.Text;

    public static class Extensions
    {
        public static StringBuilder Substring(this StringBuilder sb, int index, int lenght)
        {
            StringBuilder result = new StringBuilder();

            if (index < 0 || index >= sb.Length)
            {
                throw new IndexOutOfRangeException("Index is outside the boundaries of the string!");
            }

            if (lenght < 0)
            {
                throw new ArgumentException("Lenght should be possitive!");
            }

            if (index + lenght > sb.Length)
            {
                throw new ArgumentException("Lenght of the new string is greater than the lenght of the source string!");
            }

            for (int i = index; i < index + lenght; i++)
            {
                result.Append(sb[i]);
            }

            return result;
        }
    }
}
