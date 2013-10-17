using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangeException
{
    public class InvalidRangeException<T> : ApplicationException where T : IComparable
    {
        public T RangeStart {get;private set;}
        public T RangeEnd {get;private set;}

        public InvalidRangeException(string msg, T rangeStart, T rangeEnd) :
            base(msg)
        {
            this.RangeStart = rangeStart;
            this.RangeEnd = rangeEnd;
        }
    }
}
