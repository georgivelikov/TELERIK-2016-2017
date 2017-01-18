using System;

namespace Task12
{
    public class CustomStack<T>
    {
        private const int StartSize = 8;

        private T[] array;

        private int count = 0;

        public CustomStack()
        {
            this.array = new T[StartSize];
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public void Push(T item)
        {
            this.array[this.count] = item;
            this.count++;
            if (this.count == this.array.Length)
            {
                this.Resize();
            }
        }

        public T Peek()
        {
            return this.array[this.count - 1];
        }

        public T Pop()
        {
            var item = (T)this.array[this.count - 1];
            this.count--;

            return item;
        }

        private void Resize()
        {
            var newArray = new T[this.Count * 2];
            Array.Copy(this.array, 0, newArray, 0, this.Count);

            this.array = newArray;
        }
    }
}
