using System;

namespace CohesionAndCoupling.FileUtilities
{
    public static class FileUtils
    {
        private static string dotSymbol = ".";

        public static string GetFileExtension(string fileName)
        {
            int indexOfLastDot = fileName.LastIndexOf(dotSymbol, StringComparison.Ordinal);
            if (indexOfLastDot == -1)
            {
                throw new ArgumentException("Input does not provide file with extension");
            }

            string extension = fileName.Substring(indexOfLastDot + 1);
            return extension;
        }

        public static string GetFileNameWithoutExtension(string fileName)
        {
            int indexOfLastDot = fileName.LastIndexOf(dotSymbol, StringComparison.Ordinal);
            if (indexOfLastDot == -1)
            {
                throw new ArgumentException("Input does not provide file with extension");
            }

            string extension = fileName.Substring(0, indexOfLastDot);
            return extension;
        }
    }
}
