using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace StreetSweeper.Core
{
    public class DiffList : IEnumerable
    {
        List<DiffItem> _items = new();
        public DiffList(in List<string> oldList, in List<string> newList)
        {
            foreach (var item in oldList)
            {
                DiffItem diffItem = new(item);
                _items.Add(diffItem);
                if (newList.Contains(item))
                {
                    newList.Remove(item);
                    continue;
                }
                diffItem.IsMissing = true;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public DiffListEnum GetEnumerator()
        {
            return new DiffListEnum(_items);
        }

        public DiffItem this[int i]
        {
            get { return _items[i]; }
            set { _items[i] = value; }
        }
    }

    public class DiffListEnum : IEnumerator
    {
        private List<DiffItem> _items;
        private int _position = -1;

        public DiffListEnum(List<DiffItem> items)
        {
            _items = items;
        }

        object IEnumerator.Current
        {
            get => Current;
        }

        public DiffItem Current
        {
            get
            {
                try
                {
                    return _items[_position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public bool MoveNext()
        {
            _position++;
            return (_position >= _items.Count);
        }

        public void Reset()
        {
            _position = -1;
        }
    }
}
