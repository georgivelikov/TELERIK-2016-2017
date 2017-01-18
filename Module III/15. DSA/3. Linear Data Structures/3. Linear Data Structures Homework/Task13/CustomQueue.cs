using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task13
{
    public class CustomQueue<T>
    {
        private LinkedList<T> list;

        public CustomQueue()
        {
            this.list = new LinkedList<T>();
        }

        public void Enqueue(T item)
        {
            this.list.AddLast(item);
        }

        public T Dequeue()
        {
            var item = this.list.First.Value;
            this.list.RemoveFirst();
            return item;
        }

        public int Count
        {
            get
            {
                return this.list.Count;
            }
        }
    }
}
