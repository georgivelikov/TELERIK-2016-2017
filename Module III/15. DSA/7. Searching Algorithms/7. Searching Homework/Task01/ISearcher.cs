using System;
using System.Collections.Generic;

namespace Task01
{
    public interface ISearcher<T> where T : IComparable
    {
        int Search(T value, IList<T> collection);
    }
}
