using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danik.Collections
{
    class DanikList<T> where T : IComparable
    {
        private class DanikListItem
        {
            public DanikListItem Previous;
            public T Current;
            public DanikListItem Next;
        }

        private DanikListItem _first;
        private DanikListItem _last;

        public int Count { get; private set; }

        public void Add(T item)
        {
            if (_first == null)
            {
                _first = new DanikListItem() {Current = item};
                _last = _first;
                Count++;
                return;
            }

            DanikListItem carry = _first;
            DanikListItem previouscarry = _first;

            if (item.CompareTo(_first.Current) <= 0)
            {
                _first = new DanikListItem() {Current = item,Next = carry};
                Count++;
                return;
            }

            while ( carry!=null && item.CompareTo(carry.Current) >= 0 )
            {
                previouscarry = carry;
                carry = carry.Next;
            }
            previouscarry.Next = new DanikListItem() {Current = item,Previous = previouscarry,Next = carry};
            Count++;
        }



           
        

        public IEnumerator<T> GetEnumerator()
        {
            DanikListItem current = _first;

            while (current != null)
            {
                yield return current.Current;
                current = current.Next;
            }
        }
    }
}
