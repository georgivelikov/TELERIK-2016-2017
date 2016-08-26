namespace Task03
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class InvalidRangeException<T> : Exception
    {
        private T start;
        private T end;


        public InvalidRangeException(string message) 
            : base(message)
        {
        }
    }
}
