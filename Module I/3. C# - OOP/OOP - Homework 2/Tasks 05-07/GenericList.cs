namespace Tasks_05_07
{
    using System;
    using System.Text;

    public class GenericList<T> where T : IComparable<T>
    {
        private const int DefaultStartingCapacity = 4;
        private T[] array;
        private int count;
        private uint capacity;

        private T max = default(T);
        private T min = default(T);

        public GenericList(uint startingCapacity = DefaultStartingCapacity)
        {
            this.array = new T[startingCapacity];
            this.Capacity = startingCapacity;
        }

        public int Count
        {
            get
            {
                return this.count;
            }

            private set
            {
                this.count = value;
            }
        }

        public uint Capacity
        {
            get
            {
                return this.capacity;
            }

            private set
            {
                this.capacity = value;
            }
        }

        public T Max
        {
            get
            {
                if (this.Count == 0)
                {
                    return default(T); // or throw exception
                }

                return this.max;
            }  
        }

        public T Min
        {
            get
            {
                if (this.Count == 0)
                {
                    return default(T); // or throw exception
                }

                return this.min;
            }
        }

        public void Add(T item)
        {
            this.array[this.Count] = item;
            this.Count++;
            if (this.Count == this.Capacity)
            {
                this.Resize();
            }

            if (this.Count == 1)
            {
                this.max = item;
                this.min = item;
            }
            else
            {
                if (item.CompareTo(this.max) > 0)
                {
                    this.max = item;
                }

                if (item.CompareTo(this.min) < 0)
                {
                    this.min = item;
                }
            }
        }

        public void Remove(T item)
        {
            int index = Array.IndexOf(this.array, item);
            if (index < 0)
            {
                Console.WriteLine("Item is not in the list");
                return;
            }

            T[] temp = new T[this.Capacity];
            Array.Copy(this.array, temp, index);
            Array.Copy(this.array, index + 1, temp, index, this.Capacity - index - 1);
            this.array = temp;
            this.Count--;

            if (item.CompareTo(this.max) == 0)
            {
                this.max = this.array[0];
                for (int i = 1; i < this.Count; i++)
                {
                    if (this.array[i].CompareTo(this.max) > 0)
                    {
                        this.max = this.array[i];
                    }
                }
            }

            if (item.CompareTo(this.min) == 0)
            {
                this.min = this.array[0];
                for (int i = 1; i < this.Count; i++)
                {
                    if (this.array[i].CompareTo(this.min) < 0)
                    {
                        this.min = this.array[i];
                    }
                }
            }
        }

        public int IndexOf(T item)
        {
            return Array.IndexOf(this.array, item);
        }

        public void Resize()
        {
            this.Capacity *= 2;
            T[] temp = new T[this.Capacity];
            Array.Copy(this.array, temp, this.Count);
            this.array = temp;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < this.Count; i++)
            {
                result.Append(this.array[i] + ", ");
            }

            return result.ToString().Trim(' ', ',');
        }
    }
}
