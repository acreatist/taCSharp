using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkedList;

namespace LinkedList.Demo
{
    class LinkedListDemo
    {
        static void Main(string[] args)
        {
            SimpleLinkedList<int> list = new SimpleLinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            
            string listStr = list.ToString();
            Console.WriteLine(listStr);

            /* Remove an item */
            list.Remove(5);
            listStr = list.ToString();
            Console.WriteLine(listStr);

        }
    }
}
