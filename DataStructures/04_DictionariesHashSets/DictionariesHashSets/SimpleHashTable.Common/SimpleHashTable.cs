using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHashTable.Common
{
    public class SimpleHashTable<K, V>
    {
        private LinkedList<KeyValuePair<K, V>>[] valuesList;
        private int capacity;
        private int count;
        private List<K> currentKeys; // Thanks to tankovsky :)
        private const int INIT_CAPACITY = 16;
        
        public LinkedList<KeyValuePair<K, V>>[] ValuesList
        {
            get
            {
                return this.valuesList;
            }
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        /* Constructor */
        public SimpleHashTable()
        {
            this.capacity = INIT_CAPACITY;
            this.valuesList = new LinkedList<KeyValuePair<K, V>>[this.capacity];
            this.currentKeys = new List<K>();
        }

        /* METHODS */
        public void Add(K key, V value)
        {
            if (this.Capacity > this.valuesList.Length * 0.75 + 1)
            {
                ResizeList();
            }

            int hashValue = key.GetHashCode() & Int16.MaxValue;
            int hashIndex = hashValue % this.valuesList.Length;

            if (valuesList[hashIndex] == null)
            {
                this.capacity++;
                this.valuesList[hashIndex] = new LinkedList<KeyValuePair<K, V>>();
                this.currentKeys.Add(key);
            }

            KeyValuePair<K, V> newValue = new KeyValuePair<K,V>(key, value);
            this.valuesList[hashIndex].AddFirst(newValue);
            this.count++;
        }

        public V Find(K key)
        {
            int hashValue = key.GetHashCode() & Int16.MaxValue;
            int hashIndex = hashValue % this.valuesList.Length;

            if (this.valuesList[hashIndex] == null)
            {
                throw new ArgumentException(String.Format("Value for key: {0} not found", key));
            }
            else
            {
                // Loop through values:
                var currValue = this.valuesList[hashIndex].First;
                while (currValue != null)
                {
                    if (currValue.Value.Key.Equals(key))
                    {
                        return currValue.Value.Value;
                    }
                    currValue = currValue.Next;
                }
                   
                // If nothing is returned, throw exception
                throw new ArgumentException(String.Format("Value for key: {0} not found", key));
            }
        }

        private void ResizeList()
        {
            var resizeList = new LinkedList<KeyValuePair<K, V>>[this.capacity * 2];

            foreach (var key in currentKeys)
            {
                int currHasValue = key.GetHashCode() & Int16.MaxValue;
                int currHashIndex = currHasValue % this.valuesList.Length;

                int newHasValue = key.GetHashCode() & Int16.MaxValue;
                int newHashIndex = newHasValue % resizeList.Length;

                resizeList[newHashIndex] = this.valuesList[currHashIndex];
            }
            
            this.valuesList = resizeList;
            this.capacity *= 2;
        }

        
    }
}
