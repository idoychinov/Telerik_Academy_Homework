using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06BinarySearchTree
{
    internal class TreeNode<T> where T : IComparable
    {
        private T nodeValue;
        private TreeNode<T> leftChild;
        private TreeNode<T> rightChild;

        public T Value
        {
            get
            {
                return this.nodeValue;
            }
            set
            {
                this.nodeValue = value;
            }
        }

        public TreeNode<T> LeftChild
        {
            get
            {
                return this.leftChild;
            }
            set
            {
                this.leftChild = value;
            }
        }

        public TreeNode<T> RightChild
        {
            get
            {
                return this.rightChild;
            }
            set
            {
                this.rightChild = value;
            }
        }

        public TreeNode(T nodeValue)
        {
            this.Value = nodeValue;
            this.LeftChild = null;
            this.RightChild = null;
        }

        public void AddChild(TreeNode<T> child)
        {
            if (this.nodeValue.CompareTo(child.Value) < 0)
            {
                if (this.LeftChild == null)
                {
                    this.LeftChild = child;
                }
                else
                {
                    this.LeftChild.AddChild(child);
                }
            }
            else if (this.nodeValue.CompareTo(child.Value) > 0)
            {
                if (this.RightChild == null)
                {
                    this.RightChild = child;
                }
                else
                {
                    this.RightChild.AddChild(child);
                }
            }
        }



    }
}
