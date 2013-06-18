namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            IList<T> collectionCopy = collection;

            int indexMin;
            for (int i = 0; i < collectionCopy.Count; i++)
            {
                indexMin = i;
                for (int n = i+1; n < collectionCopy.Count; n++)
                {
                    if (collectionCopy[n].CompareTo(collectionCopy[indexMin]) < 0)
                    {
                        indexMin = n;
                    }
                }

                if (indexMin != i)
                {
                    T tempVal = collectionCopy[i];
                    collectionCopy[i] = collectionCopy[indexMin];
                    collectionCopy[indexMin] = tempVal;
                }
            }
        }
    }
}
