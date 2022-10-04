using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StreetSweeper.Core
{
    public class DiffItem
    {
        private object _value;
        private bool _isMissing = false;

        public DiffItem(object value)
        {
            _value = value;
        }

        public DiffItem(object value, bool missing) : this(value)
        {
            IsMissing = missing;
        }

        public object Value { get { return _value; } }

        public bool IsMissing
        {
            get { return _isMissing; }
            set { _isMissing = value; }
        }

        override public bool Equals(object? other)
        {
            if (other == null || !GetType().Equals(other.GetType())) return false;
            DiffItem otherItem = (DiffItem)other;
            return otherItem.Value == Value && otherItem.IsMissing == IsMissing;
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }
    }
}
