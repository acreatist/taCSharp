using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class ListItem<T>
    {
        public T Value { get; set; }
        public ListItem<T> Next { get; set; }

        public ListItem(T value, ListItem<T> next)
        {
            this.Value = value;
            this.Next = next;
        }
    }
}
