using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class SimpleLinkedList<T> : IEnumerable<T> where T : IComparable<T>
    {
        public ListItem<T> FirstElement { get; set; }

        /*
         * CONSTRUCTOR
         */
        public SimpleLinkedList()
        {
            this.FirstElement = null;
        }

        /*
         * METHODS
         */
        public void Add(T value)
        {
            ListItem<T> newItem = new ListItem<T>(value, null);
            newItem.Next = this.FirstElement;

            this.FirstElement = newItem;
        }

        public void Remove(T value)
        {
            ListItem<T> currItem = this.FirstElement;

            currItem = this.FirstElement;

            // Check if given value is the first item
            if (currItem.Value.CompareTo(value) == 0)
            {
                this.FirstElement = currItem.Next;
                return;
            }

            // else, find the value and remove the link
            while (currItem.Next != null)
            {
                if (currItem.Next.Value.CompareTo(value) == 0)
                {
                    ListItem<T> newNextItem = currItem.Next.Next;
                    currItem.Next = newNextItem;

                    break;
                }

                currItem = currItem.Next;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            ListItem<T> current = this.FirstElement;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }

        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append("{ " + this.FirstElement.Value);
            
            ListItem<T> nextItem = this.FirstElement.Next;
            while (nextItem != null)
	        {
	            output.Append(", " + nextItem.Value);
                nextItem = nextItem.Next;
	        }

            output.Append(" }");

            return output.ToString();
        }
    }
}
