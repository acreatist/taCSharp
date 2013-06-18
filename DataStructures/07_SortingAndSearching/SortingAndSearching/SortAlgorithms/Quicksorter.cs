namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            QuickSort(collection, 0, collection.Count - 1);
        }

        private void QuickSort(IList<T> collection, int left, int right)
        {
            if (left < right)
            {
                //int pivotIndex = collection.Count / 2;
                int partitionIndex = this.GetPartitionIndex(collection, left, right);

                this.QuickSort(collection, left, partitionIndex - 1);

                this.QuickSort(collection, partitionIndex + 1, right);
            }
            else
            {
                return;
            }
        }

        private int GetPartitionIndex(IList<T> collection, int left, int right)
        {
            T pivotValue = collection[right];

            //this.Swap(collection, pivotIndex, left);
            int storeIndex = left;

            for (int i = left; i < right-1; i++)
            {
                if (collection[i].CompareTo(pivotValue) <= 0)
                {
                    storeIndex++;
                    this.Swap(collection, i, storeIndex);
                }
            }

            this.Swap(collection, storeIndex, right);
            return storeIndex++;
        }

        private void Swap(IList<T> collection, int selected, int target)
        {
            T tempVal = collection[selected];
            collection[selected] = collection[target];
            collection[target] = tempVal;
        }
    }
}
