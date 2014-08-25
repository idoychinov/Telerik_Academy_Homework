namespace Task01TreeTraversal
{
    using System;
    using System.Collections.Generic;

    class Tree<T>
    {
        public TreeNode<T> Root { get; set; }

        private bool IsLeaf(TreeNode<T> node)
        {
            if (node.ChildList.Count == 0)
            {
                return true;
            }

            return false;
        }

        private bool IsMiddle(TreeNode<T> node)
        {
            if (node.ChildList.Count > 0 && !object.ReferenceEquals(node, this.Root))
            {
                return true;
            }

            return false;
        }

        private string Dfs(TreeNode<T> node, Func<TreeNode<T>, bool> check)
        {
            var output = "";
            foreach (var child in node.ChildList)
            {
                output += Dfs(child, check);
            }
            if (check(node))
            {
                output += node.Value + " ";
            }

            return output;
        }

        private int FindPathLenght(TreeNode<T> node)
        {
            if (node.ChildList.Count == 0)
            {
                return 0;
            }

            int pathLenght = 0;
            foreach(var child in node.ChildList)
            {
                pathLenght = Math.Max(pathLenght, FindPathLenght(child));
            }

            return pathLenght+1;
        }

        public string GetAllLeafs()
        {
            return Dfs(this.Root, IsLeaf);
        }

        public string GetAllMiddleNodes()
        {
            return Dfs(this.Root, IsMiddle);
        }

        public int GetLongestPath()
        {
            return FindPathLenght(this.Root);
        }




    }
}
