using System.Collections;
using System.Collections.Generic;

namespace Task11
{
    public class LinkedList<T> : IEnumerable<ListItem<T>>
    {
        public ListItem<T> FirstItem { get; set; }

        public ListItem<T> LastItem { get; set; }

        public void AddItem(ListItem<T> item)
        {
            if (this.FirstItem == null)
            {
                this.FirstItem = item;
                this.LastItem = item;
            }
            else
            {
                this.LastItem.NextItem = item;
                this.LastItem = item;
            }
        }

        public IEnumerator<ListItem<T>> GetEnumerator()
        {
            var currentItem = this.FirstItem;
            while (currentItem != null)
            {
                yield return currentItem;
                currentItem = currentItem.NextItem;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
