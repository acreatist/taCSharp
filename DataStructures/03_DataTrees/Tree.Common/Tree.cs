using System;
using System.Collections.Generic;
using System.Linq;

namespace Tree.Common
{
    public class Tree<T>
    {
        private TreeNode<T> root;

        public TreeNode<T> Root {
            get 
            {
                return this.root;
            }
        }

        public Tree(TreeNode<T> rootNode)
        {
            this.root = rootNode;
        }

        // BFS Traverse to get all leafs
        public List<TreeNode<T>> GetLeafs()
        {
            List<TreeNode<T>> leafs = new List<TreeNode<T>>();
            Queue<TreeNode<T>> currNodes = new Queue<TreeNode<T>>();
            
            currNodes.Enqueue(this.Root);
            while (currNodes.Count > 0)
            {
                TreeNode<T> currNode = currNodes.Dequeue();
                if (currNode.ChildrenCount > 0)
                {   
                    for (int i = 0; i < currNode.ChildrenCount; i++)
                    {
                        currNodes.Enqueue(currNode.GetChild(i));
                    }
                }
                else
                {
                    leafs.Add(currNode);
                }
            }

            return leafs;
        }

        // BSF Traverse to get depth level
        public int GetTreeLevels()
        {
            Queue<TreeNode<T>> currNodes = new Queue<TreeNode<T>>();
            int levels = 0;

            currNodes.Enqueue(this.Root);
            while (currNodes.Count > 0)
            {
                TreeNode<T> currNode = currNodes.Dequeue();
                if (currNode.ChildrenCount > 0)
                {
                    levels++;
                    for (int i = 0; i < currNode.ChildrenCount; i++)
                    {
                        currNodes.Enqueue(currNode.GetChild(i));
                    }
                }
            }

            return levels;
        }

        // By given node, return the subtree
        public Tree<T> GetSubTree(TreeNode<T> subTreeRoot)
        {
            Tree<T> subTree = new Tree<T>(subTreeRoot);

            return subTree;
        }

        // BSF Traverse to get subtrees on a given level
        public List<Tree<T>> GetSubTree(int subTreeLevel)
        {
            Queue<TreeNode<T>> currNodes = new Queue<TreeNode<T>>();
            List<Tree<T>> subTrees = new List<Tree<T>>();
            int currLevel = 0;

            currNodes.Enqueue(this.Root);
            while (currNodes.Count > 0)
            {
                if (currLevel == subTreeLevel)
                {
                    foreach (var node in currNodes)
                    {
                        Tree<T> subTree = new Tree<T>(node);
                        subTrees.Add(subTree);
                    }

                    break;
                }

                TreeNode<T> currNode = currNodes.Dequeue();
                if (currNode.ChildrenCount > 0)
                {   
                    currLevel++;                    
                    for (int i = 0; i < currNode.ChildrenCount; i++)
                    {
                        currNodes.Enqueue(currNode.GetChild(i));
                    }
                }
            }

            return subTrees;
        }

    }
}
