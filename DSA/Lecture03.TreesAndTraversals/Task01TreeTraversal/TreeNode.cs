namespace Task01TreeTraversal
{
    using System;
    using System.Collections.Generic;

    class TreeNode<T> 
    {
        public T Value { get; set; }

        public ICollection<TreeNode<T>> ChildList {get; private set;}

        public TreeNode(T value)
        {
            this.Value = value;
            this.ChildList = new List<TreeNode<T>>();
        }
        
        public void AddChild(TreeNode<T> child)
        {
            this.ChildList.Add(child);
        }    
    }
}
