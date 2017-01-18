using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    public class LinearSearcher<T> : ISearcher<T>
        where T : IComparable
    {
        public int Search(T value, IList<T> collection)
        {
            int index = -1;

            for (int i = 0; i < collection.Count; i++)
            {
                if (collection[i].CompareTo(value) == 0)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }
    }
}
