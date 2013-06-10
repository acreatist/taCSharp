using System;
using System.Collections.Generic;
using System.Linq;
using Tree.Common;

namespace Tree.Demo
{
    class TreeDemo
    {
        static void Main(string[] args)
        {
            // TODO: Make it a console input
            int nodesNum = 7;
            string[] nodesAsString = { "2 4", "3 2", "5 0", "3 5", "5 6", "5 1" };
            
            Tree<int> tree = BuildTree(nodesNum, nodesAsString);
            
            /* Tree Root Node */
            Console.WriteLine("Tree Root Node: \n{0}", tree.Root.Value);
            
            /* Tree Middle Nodes */
            List<TreeNode<int>> leafs = tree.GetLeafs();
            
            Console.WriteLine("Tree Middle Nodes");
            int middleLevel = tree.GetTreeLevels() / 2;
            List<Tree<int>> middleTrees = tree.GetSubTree(middleLevel);

            foreach (var middleTree in middleTrees)
            {
                Console.Write("{0}   ", middleTree.Root.Value);
            }

            /* Tree Leafs */
            Console.WriteLine();
            Console.WriteLine("Tree leafs:");
            Console.Write("{0}", leafs[0].Value);

            for (int i = 1; i < leafs.Count; i++)
            {
                Console.Write("   {0}", leafs[i].Value);
            }

            Console.WriteLine();
        }
  
        private static Tree<int> BuildTree(int nodesNum, string[] nodesAsString)
        {
            TreeNode<int>[] nodes = new TreeNode<int>[nodesNum];
            for (int i = 0; i < nodesNum; i++)
            {
                nodes[i] = new TreeNode<int>(i);
            }

            // Define nodes with values
            int nodeValue, nodeChild;
            string[] nodeParts = new string[2];
            for (int i = 0; i < nodesNum - 1; i++)
            {
                nodeParts = nodesAsString[i].Split(' ');
                nodeValue = int.Parse(nodeParts[0]);
                nodeChild = int.Parse(nodeParts[1]);

                nodes[nodeValue].AddChild(nodes[nodeChild]);
                nodes[nodeChild].hasParent = true;
            }

            TreeNode<int> root = null;
            foreach (var node in nodes)
            {
                if (node.hasParent == false)
                {
                    root = node;
                    break;
                }
            }

            Tree<int> tree = new Tree<int>(root);
            return tree;            
        }
    }
}
