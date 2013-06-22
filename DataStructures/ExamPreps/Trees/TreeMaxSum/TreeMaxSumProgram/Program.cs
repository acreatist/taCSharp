using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeMaxSumProgram
{
    public class Node
    {
        private List<Node> children;
        private bool hasParent;

        public int Value { get; private set; }

        public bool HasParent
        {
            get
            {
                return this.hasParent;
            }
        }

        public List<Node> Children
        {
            get
            {
                return this.children;
            }
        }

        public int ChildrenCount
        {
            get
            {
                return this.children.Count;
            }
        }

        public Node(int value)
        {
            this.Value = value;
            children = new List<Node>();
        }

        public void AddChild(Node child)
        {
            child.hasParent = true;
            this.children.Add(child);
        }

        public Node GetNode(int index)
        {
            return this.children[index];
        }
    }

    class Program
    {
        static int maxSum = 0;
        static List<Node> used = new List<Node>();

        static void DFS(Node node, int currSum)
        {
            currSum += node.Value;
            used.Add(node);

            for (int i = 0; i < node.ChildrenCount; i++)
            {
                if (used.Contains(node.GetNode(i)))
                {
                    continue;
                }
                DFS(node.GetNode(i), currSum);
            }
            Console.Write("{0} ->", node.Value);
            // if reached another leaf, check sums
            if (node.ChildrenCount == 1)
            {
                if (currSum > maxSum)
                {
                    maxSum = currSum;
                }
            }
        }

        static void Main(string[] args)
        {
            int elementsNum = int.Parse(Console.ReadLine());
            Dictionary<int, Node> nodes = new Dictionary<int, Node>();

            for (int i = 0; i < elementsNum-1; i++)
            {
                string nodeLink = Console.ReadLine();
                char[] separators = { '(', '<', '-', ')' };

                string[] nodeLinkValues = nodeLink.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                int parentValue = int.Parse(nodeLinkValues[0]);
                int childValue = int.Parse(nodeLinkValues[1]);

                Node parentNode;
                if (nodes.ContainsKey(parentValue))
                {
                    parentNode = nodes[parentValue]; 
                }
                else
                {
                    parentNode = new Node(parentValue);
                    nodes.Add(parentValue, parentNode);
                }

                Node childNode;
                if (nodes.ContainsKey(childValue))
                {
                    childNode = nodes[childValue];
                }
                else
                {
                    childNode = new Node(childValue);
                    nodes.Add(childValue, childNode);                    
                }

                parentNode.AddChild(childNode);
                childNode.AddChild(parentNode);
                
            }

            foreach (var node in nodes)
            {
                if (node.Value.ChildrenCount == 1)
                {
                    
                    used.Clear();
                    DFS(node.Value, 0);

                    Console.WriteLine(maxSum);
                }
            }

        }
    }
}
