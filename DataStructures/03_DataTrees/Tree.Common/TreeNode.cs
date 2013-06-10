using System;
using System.Collections.Generic;
using System.Linq;

namespace Tree.Common
{
    public class TreeNode<T>
    {
        public T Value { get; set; }
        private List<TreeNode<T>> childNodes;
        
        /* Properties */
        public bool hasParent { get; set; }
        
        public int ChildrenCount
        {
            get
            {
                return this.childNodes.Count;
            }
        }

        /* Constructors */
        public TreeNode()
        {
            this.childNodes = new List<TreeNode<T>>();
            this.hasParent = false;
        }

        public TreeNode(T value) : this()
        {
            this.Value = value;
        }


        /* Methods */
        public void AddChild(TreeNode<T> childNode)
        {
            if (childNode == null)
            {
                throw new ArgumentNullException();
            }
            this.childNodes.Add(childNode);
        }

        public TreeNode<T> GetChild(int index)
        {
            TreeNode<T> returnChild = this.childNodes[index];

            return returnChild;
        }
    }
}
