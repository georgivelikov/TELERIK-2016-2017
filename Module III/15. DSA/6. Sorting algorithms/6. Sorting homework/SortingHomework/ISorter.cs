using System.Collections.Generic;

namespace SortingHomework
{
    public interface ISorter<T>
    {
        IList<T> Sort(IList<T> collection);
    }
}
