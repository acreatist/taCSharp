namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            bool found = false;
            for (int i = 0; i < this.Items.Count; i++)
            {
                if (this.Items[i].CompareTo(item) == 0)
                {
                    found = true;
                    break;
                }
            }

            return found;
        }

        public bool BinarySearch(T item)
        {
            bool found = false;


            found = BinarySearchRecursive(item, 0, this.Items.Count-1, found);
            
            return found;
        }

        private bool BinarySearchRecursive(T item, int start, int end, bool found)
        {
            if (start > end)
            {
                return false;
            }
            else
            {
                int midIndex = start + ((end - start) / 2);
                if (item.CompareTo(this.Items[midIndex]) < 0)
                {
                    found = BinarySearchRecursive(item, start, midIndex - 1, found);
                }
                else if (item.CompareTo(this.Items[midIndex]) > 0)
                {
                    found = BinarySearchRecursive(item, midIndex + 1, end, found);
                }
                else
                {
                    found = true;
                }
            }
            return found;
        }

        public void Shuffle()
        {
            int randomIndex = RandomIndex();
            T tempItemValue;
            for (int i = 0; i < this.Items.Count; i++)
            {
                tempItemValue = this.Items[i];
                this.Items[i] = this.Items[randomIndex];
                this.Items[randomIndex] = tempItemValue;

                randomIndex = RandomIndex();    
            }
        }

        private int RandomIndex()
        {
            Random randomGen = new Random();
            return randomGen.Next(this.Items.Count);
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }
    }
}
