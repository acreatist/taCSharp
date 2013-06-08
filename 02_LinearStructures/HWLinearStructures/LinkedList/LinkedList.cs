using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class LinkedList<T> : IEnumerable<T>
    {
        public ListItem<T> FirstElement { get; set; }
        public LinkedList()
        {
            this.FirstElement = null;
        }

        public void Add(T value)
        {
            ListItem<T> newItem = new ListItem<T>(value, null);
            newItem.Next = this.FirstElement;

            this.FirstElement = newItem;
        }

        public IEnumerator<T> GetEnumerator()
        {
            this.firstElement = this.CurrentElement;

            while (CurrentElement != null)
            {
                yield return CurrentElement.Value;
                CurrentElement = CurrentElement.NextItem;
            }

            this.CurrentElement = this.firstElement;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
