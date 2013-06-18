namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            IList<T> collectionCopy = new List<T>();
            foreach (var item in collection)
            {
                collectionCopy.Add(item);
            }

            collectionCopy = MergeSort(collectionCopy);
            collection.Clear();
            
            foreach (var item in collectionCopy)
            {
                collection.Add(item);
            }

            int a = 5;
        }

        private IList<T> MergeSort(IList<T> collection)
        {
            int elementsCount = collection.Count;
            if (elementsCount <= 1)
            {
                return collection;
            }

            IList<T> leftSide = new List<T>();
            IList<T> rightSide = new List<T>();
            IList<T> mergedSorted = new List<T>();

            int middleIndex = elementsCount / 2;

            for (int i = 0; i < elementsCount; i++)
            {
                if (i < middleIndex)
                {
                    leftSide.Add(collection[i]);
                }
                else
                {
                    rightSide.Add(collection[i]);
                }
            }

            leftSide = MergeSort(leftSide);
            rightSide = MergeSort(rightSide);

            mergedSorted = Merge(leftSide, rightSide);

            return mergedSorted;
        }

        private static IList<T> Merge(IList<T> leftSide, IList<T> rightSide)
        {
            IList<T> result = new List<T>();

            while (leftSide.Count > 0 || rightSide.Count > 0)
            {
                // Check if both sides has values
                if (leftSide.Count > 0 && rightSide.Count > 0)
                {
                    if (leftSide[0].CompareTo(rightSide[0]) <= 0)
                    {
                        result.Add(leftSide[0]);
                        leftSide.RemoveAt(0);
                    }
                    else
                    {
                        result.Add(rightSide[0]);
                        rightSide.RemoveAt(0);
                    }
                }
                // If right side is empty
                else if (leftSide.Count > 0)
                {
                    result.Add(leftSide[0]);
                    leftSide.RemoveAt(0);
                }
                // If left side is empty
                else if (rightSide.Count > 0)
                {
                    result.Add(rightSide[0]);
                    rightSide.RemoveAt(0);
                }
            }

            return result;
        }
    }
}
