using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P06BinarySearchTree
{
    // Problem 6. * Define the data structure binary search tree with operations for "adding new element", "searching element" and "deleting elements". It
    // is not necessary to keep the tree balanced. Implement the standard methods from System.Object – ToString(), Equals(…), GetHashCode() and the operators 
    // for comparison  == and !=. Add and implement the ICloneable interface for deep copy of the tree. Remark: Use two types – structure BinarySearchTree (for the tree) 
    // and class TreeNode (for the tree elements). Implement IEnumerable<T> to traverse the tree.


    public class BinarySearchTree<T> : IEnumerable<T>, ICloneable where T : IComparable
    {
        private TreeNode<T> root;
        private TreeNode<T> searchParentReference;
        private int count;

        public BinarySearchTree()
        {
            root = null;
            this.count = 0;
        }
        
        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public void AddElement(T value)
        {
            if (root != null)
            {
                root.AddChild(new TreeNode<T>(value));
                count++;
            }
            else
            {
                root = new TreeNode<T>(value);
                count++;
            }
        }

        public bool SearchElement(T value)
        {
            if (this.root == null)
            {
                throw new ArgumentException("The tree is empty");
            }
            else if (root.Value.CompareTo(value) == 0)
            {
                return true;
            }

            this.searchParentReference = root;
            if (root.Value.CompareTo(value) < 1)
            {
                return SearchWithParentReference(root.LeftChild, value);
            }
            else
            {
                return SearchWithParentReference(root.RightChild, value);
            }
        }

        private bool SearchWithParentReference(TreeNode<T> currentNode, T value)
        {
            if (currentNode == null)
            {
                return false;
            }

            if (currentNode.Value.CompareTo(value) == 0)
            {
                return true;
            }
            else if (currentNode.Value.CompareTo(value) < 1)
            {
                this.searchParentReference = currentNode;
                return SearchWithParentReference(currentNode.LeftChild, value);
            }
            else
            {
                this.searchParentReference = currentNode;
                return SearchWithParentReference(currentNode.RightChild, value);
            }
        }

        public bool DeleteElement(T value)
        {
            if (SearchElement(value))
            {
                if (searchParentReference == null)
                {
                    root = null;
                    count--;
                }
                else
                {
                    TreeNode<T> nodeForDeletion;
                    TreeNode<T> parentNode = searchParentReference;
                    bool isRightChild = false;
                    if (value.CompareTo(parentNode.Value) < 0)
                    {
                        nodeForDeletion = parentNode.LeftChild;
                    }
                    else
                    {
                        nodeForDeletion = parentNode.RightChild;
                        isRightChild = true;
                    }

                    bool leftChildIsNull = nodeForDeletion.LeftChild == null ? true : false;
                    bool rightChildIsNull = nodeForDeletion.RightChild == null ? true : false;
                    if (leftChildIsNull && rightChildIsNull)
                    {
                        nodeForDeletion = null;
                    }
                    else if (leftChildIsNull)
                    {
                        if (isRightChild)
                        {
                            parentNode.RightChild = nodeForDeletion.RightChild;
                        }
                        else
                        {
                            parentNode.LeftChild = nodeForDeletion.RightChild;
                        }
                    }
                    else if (rightChildIsNull)
                    {
                        if (isRightChild)
                        {
                            parentNode.RightChild = nodeForDeletion.LeftChild;
                        }
                        else
                        {
                            parentNode.LeftChild = nodeForDeletion.LeftChild;
                        }
                    }
                    else
                    {
                        TreeNode<T> currentNodeToReplace = nodeForDeletion.RightChild;
                        if (currentNodeToReplace.LeftChild == null)
                        {
                            nodeForDeletion = currentNodeToReplace;
                        }
                        else
                        {
                            while (currentNodeToReplace.LeftChild != null)
                            {
                                currentNodeToReplace = currentNodeToReplace.LeftChild;
                            }
                            nodeForDeletion.Value = currentNodeToReplace.Value;
                            currentNodeToReplace = null;
                        }
                    }
                }
                count--;
                return true;
            }
            else
            {
                return false; //indicates that no element was deleted
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator() //TODO doesnt work correctly always. For tree counts 150-200+, doesnt return all elements -  need to investigate more.
        {

            if (this.root == null)
            {
                throw new NullReferenceException("The tree is empty");
            }

            var stack = new Stack<TreeNode<T>>();
            stack.Push(this.root);
            while (stack.Count > 0)
            {
                var node = stack.Pop();
                yield return node.Value;
                if (node.RightChild != null)
                {
                    stack.Push(node.RightChild);
                }
                if (node.LeftChild != null)
                {
                    stack.Push(node.LeftChild);
                }
            }

        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append("{");
            foreach (var nodeValue in this)
            {
                output.Append(nodeValue);
                output.Append(", ");
            }
            if (this.Count > 0)
            {
                output.Remove(output.Length-2,2);
                output.Append("}");
            }
            return output.ToString();
        }

        public override int GetHashCode()
        {
            if (root != null)
            {
                return root.Value.GetHashCode();
            }
            else
            {
                return base.GetHashCode();
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is BinarySearchTree<T>)
            {
                BinarySearchTree<T> param = obj as BinarySearchTree<T>;
                return this.Equals(param);
            }
            else
            {
                throw new ArgumentException("Argument is invalid type");
            }
        }

        public bool Equals(BinarySearchTree<T> tree)
        {
            if(this.Count!= tree.Count)
            {
                return false;
            }

            List<T> currentTree = new List<T>(this.Count);
            List<T> comparedTree = new List<T>(tree.Count);

            foreach (var nodeValue in this)
            {
                currentTree.Add(nodeValue);
            }
            foreach (var nodeValue in tree)
            {
                comparedTree.Add(nodeValue);
            }

            bool areEqual = true;
            for (int i = 0; i < this.Count; i++)
            {
                if(!currentTree.Contains(comparedTree[i]))
                {
                    areEqual = false;
                    break;
                }
            }

            return areEqual;
        }

        public static bool operator ==(BinarySearchTree<T> treeA, BinarySearchTree<T> treeB)
        {
            return treeA.Equals(treeB);
        }

        public static bool operator !=(BinarySearchTree<T> treeA, BinarySearchTree<T> treeB)
        {
            return !treeA.Equals(treeB);
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public BinarySearchTree<T> Clone()
        {
            BinarySearchTree<T> newTree = new BinarySearchTree<T>();
            foreach (var nodeItem in this)
            {
                newTree.AddElement(nodeItem);
            }

            return newTree;
        }
    }
}
