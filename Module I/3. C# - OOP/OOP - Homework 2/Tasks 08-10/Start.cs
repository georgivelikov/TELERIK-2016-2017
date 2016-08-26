namespace Tasks_08_10
{
    using System;

    public class Start
    {
        public static void Main()
        {
            int counter = 1;
            uint rows = 3;
            uint cols = 3;
            Matrix<int> matrixOne = new Matrix<int>(rows, cols);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrixOne[i, j] = counter;
                    counter++;
                }
            }

            Matrix<int> matrixTwo = new Matrix<int>(rows, cols);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrixTwo[i, j] = counter;
                    counter++;
                }
            }

            var addingMatrix = matrixOne + matrixTwo;
            Console.WriteLine(addingMatrix);
            Console.WriteLine();

            var substractingMatrix = matrixOne - matrixTwo;
            Console.WriteLine(substractingMatrix);
            Console.WriteLine();

            var multiplyingMatrix = matrixOne * matrixTwo;
            Console.WriteLine(multiplyingMatrix);

        }
    }
}
