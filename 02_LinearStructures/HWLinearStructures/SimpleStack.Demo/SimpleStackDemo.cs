using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleStack;

namespace SimpleStack.Demo
{
    class SimpleStackDemo
    {
        static void Main(string[] args)
        {
            SimpleStack<int> stack = new SimpleStack<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Console.WriteLine(stack.ToString());

            int poped = stack.Pop();
            Console.WriteLine("Poped: {0}", poped);
            Console.WriteLine(stack.ToString());
        }
    }
}
