using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFolder.Tree
{
    public class Tree<T>
    {
        private TreeItem<T> root;
        
        public TreeItem<T> Root
        {
            get
            {
                return this.root;
            }            
        }

        public Tree(TreeItem<T> rootNode)
        {
            this.root = rootNode;
        }
    }
}
