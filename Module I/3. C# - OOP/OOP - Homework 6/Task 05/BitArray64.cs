namespace Task_05
{
    using System.Collections;
    using System.Collections.Generic;

    public class BitArray64 : IEnumerable<int>
    {
        private const int LenghtOfArray = 64;

        private ulong numberValue;
        private char[] array;

        public BitArray64(ulong numberValue)
        {
            this.NumberValue = numberValue;
            this.array = this.ConvertUlongToString(numberValue);
        }

        public ulong NumberValue
        {
            get
            {
                return this.numberValue;
            }

            private set
            {
                this.numberValue = value;
            }
        }

        public int Lenght
        {
            get
            {
                return this.array.Length;
            }
        }

        public IEnumerable Array
        {
            get
            {
                return this.array;
            }
        }

        public static bool operator ==(BitArray64 arr1, BitArray64 arr2)
        {
            return arr1.Equals(arr2);
        }

        public static bool operator !=(BitArray64 arr1, BitArray64 arr2)
        {
            return !(arr1 == arr2);
        }

        public char this[int i]
        {
            get
            {
                return this.array[i];
            }
        }

        public IEnumerator<int> GetEnumerator()
        {
            foreach (var num in this.array)
            {
                yield return num - 48;
            }
        }

        public override string ToString()
        {
            return string.Join(string.Empty, this.array);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ (int)this.NumberValue;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override bool Equals(object obj)
        {
            var other = obj as BitArray64;

            if (this.NumberValue == other.NumberValue)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private char[] ConvertUlongToString(ulong number)
        {
            string result = string.Empty;

            while (number > 0)
            {
                ulong num = number % 2;
                result = num + result;
                number /= 2;
            }

            result = result.PadLeft(LenghtOfArray, '0');

            return result.ToCharArray();
        }
    }
}
