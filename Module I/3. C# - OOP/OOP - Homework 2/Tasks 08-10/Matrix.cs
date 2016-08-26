namespace Tasks_08_10
{
    using System;
    using System.Text;

    public class Matrix<T> where T : struct, IComparable
    {
        private uint rows;

        private uint cols;

        private T[,] matrix;

        public Matrix(uint rows, uint cols)
        {
            this.Rows = rows;
            this.Cols = cols;
            this.matrix = new T[this.Rows, this.Cols];
        }

        public uint Rows
        {
            get
            {
                return this.rows;
            }

            set
            {
                this.rows = value;
            }
        }

        public uint Cols
        {
            get
            {
                return this.cols;
            }

            set
            {
                this.cols = value;
            }
        }

        public T this[int row, int col]
        {
            get
            {
                if (row < 0 || row >= this.Rows)
                {
                    throw new IndexOutOfRangeException(string.Format("Invalid index: {0}.", row));
                }

                if (col < 0 || col >= this.Cols)
                {
                    throw new IndexOutOfRangeException(string.Format("Invalid index: {0}.", col));
                }

                return this.matrix[row, col];
            }

            set
            {
                this.matrix[row, col] = value;
            }
        }

        public static Matrix<T> operator +(Matrix<T> matrixOne, Matrix<T> matrixTwo)
        {
            if (matrixOne.Rows != matrixTwo.Rows || matrixOne.Cols != matrixTwo.Cols)
            {
                throw new InvalidOperationException("Two matrices are with different dimensions");
            }

            uint rows = matrixOne.Rows;
            uint cols = matrixOne.Cols;
            Matrix<T> finalMatrix = new Matrix<T>(rows, cols);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    finalMatrix[i, j] = (dynamic)matrixOne[i, j] + matrixTwo[i, j];
                }
            }

            return finalMatrix;
        }

        public static Matrix<T> operator -(Matrix<T> matrixOne, Matrix<T> matrixTwo)
        {
            if (matrixOne.Rows != matrixTwo.Rows || matrixOne.Cols != matrixTwo.Cols)
            {
                throw new InvalidOperationException("Two matrices are with different dimensions");
            }

            uint rows = matrixOne.Rows;
            uint cols = matrixOne.Cols;
            Matrix<T> finalMatrix = new Matrix<T>(rows, cols);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    finalMatrix[i, j] = (dynamic)matrixOne[i, j] - matrixTwo[i, j];
                }
            }

            return finalMatrix;
        }

        public static Matrix<T> operator *(Matrix<T> matrixOne, Matrix<T> matrixTwo)
        {
            if (matrixOne.Rows != matrixTwo.Rows || matrixOne.Cols != matrixTwo.Cols)
            {
                throw new InvalidOperationException("Two matrices are with different dimensions");
            }

            uint rows = matrixOne.Rows;
            uint cols = matrixOne.Cols;
            Matrix<T> finalMatrix = new Matrix<T>(rows, cols);
            T sum = (dynamic)0;
            for (int i = 0; i < finalMatrix.Rows; i++)
            {
                for (int j = 0; j < finalMatrix.Cols; j++)
                {
                    sum = (dynamic)0;
                    for (int k = 0; k < matrixOne.Cols; k++)
                    {
                        sum += (dynamic)matrixOne[i, k] * matrixTwo[k, j];
                    }

                    finalMatrix[i, j] = sum;
                }
            }

            return finalMatrix;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Cols; j++)
                {
                    sb.Append(this.matrix[i, j] + " ");
                }

                sb.Append('\n');
            }

            return sb.ToString().Trim();
        }
    }
}
