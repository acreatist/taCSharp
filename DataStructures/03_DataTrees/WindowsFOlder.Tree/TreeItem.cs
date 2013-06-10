using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFolder.Tree
{
    public class TreeItem<T>
    {
        public bool HasParent { get; set; }
        public bool IsFolder { get; set; }
        private List<TreeItem<T>> childNodes;

        public T Value { get; set; }

        public int ChildItemsCount {
            get
            {
                return this.childNodes.Count;
            }
        }

        public TreeItem()
        {
            this.childNodes = new List<TreeItem<T>>();
            this.HasParent = false;
        }

        public TreeItem(T value) : this()
        {
            this.Value = value;
        }


        public void AddChild(TreeItem<T> childNode)
        {
            if (childNode == null)
            {
                throw new ArgumentNullException();
            }
            this.childNodes.Add(childNode);
            childNode.HasParent = true;
        }

        public TreeItem<T> GetChild(int index)
        {
            TreeItem<T> returnChild = this.childNodes[index];

            return returnChild;
        }
    }
}
