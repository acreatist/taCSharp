using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleStack
{
    public class SimpleStack<T>
    {
        private int capacity;
        private int filled;
        private T[] elements;

        public int Capacity
        {
            get { return this.capacity; }
        }

        public int Count
        {
            get { return this.filled; }
        }

        /* 
         * CONSTRUCTOR: 
         */
        public SimpleStack()
        {
            this.capacity = 2;
            this.filled = 0;
            this.elements = new T[capacity];
        }

        /* 
         * METHODS: 
         */
        private void Enlarge()
        {
            T[] elementsTemp = new T[this.capacity * 2];
            Array.Copy(this.elements, elementsTemp, this.elements.Length);
            this.elements = elementsTemp;
            this.capacity = this.elements.Length;
        }

        public void Push(T value)
        {
            if (this.filled < this.capacity)
            {
                this.elements[filled] = value;
                this.filled++;
            }
            else
            {
                this.Enlarge();
                this.Push(value);
            }
        }

        public T Pop()
        {
            T popValue = this.elements[filled-1];
            
            // Update the array
            this.filled--;
            T[] updatedArray = new T[this.filled];
            
            for (int i=0; i<this.filled; i++)
            {
                updatedArray[i] = this.elements[i];
            }
            this.elements = updatedArray;

            return popValue;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append("{ " + this.elements[0]);

            for (int i = 1; i < this.filled; i++)
            {
                output.Append(", " + this.elements[i]);
            }

            output.Append(" }");

            return output.ToString();
        }
    }
}
