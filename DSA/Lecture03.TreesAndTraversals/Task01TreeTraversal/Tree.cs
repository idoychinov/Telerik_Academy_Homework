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
            foreach (var child in node.ChildList)
            {
                pathLenght = Math.Max(pathLenght, FindPathLenght(child));
            }

            return pathLenght + 1;
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

        // This is very bad design - casting T to int via parsing, but I've already made the class generic 
        // (which does not allow for arithmetic operations, that i forgot I'll need for the last two subtasks) and redesigning it or implementing
        // more elegant solution will take up too much time that i don't have at the moment :(
        public IList<string> GetAllPathsWithGivenSum(int sum)
        {
            IList<string> allPaths = new List<string>();
            FindPathWithSum(sum, int.Parse(this.Root.Value.ToString()), allPaths, this.Root.Value.ToString(), this.Root, true);
            return allPaths;
        }

        private void FindPathWithSum(
            int targetSum, int currentSum, IList<string> paths, string currentPath, TreeNode<T> node, bool searchOnlyFullPaths)
        {
            var sumFound = (currentSum == targetSum) && (!searchOnlyFullPaths || (node.ChildList.Count == 0));
            if (sumFound)
            {
                paths.Add(currentPath);
            }

            foreach (var childNode in node.ChildList)
            {
                var newSum = currentSum + int.Parse(childNode.Value.ToString());
                string newPath = currentPath + " " + childNode.Value.ToString();
                FindPathWithSum(targetSum, newSum, paths, newPath, childNode, searchOnlyFullPaths);
            }
        }

        public IList<string> GetAllSubTreesWithGivenSum(int sum)
        {
            IList<string> allPaths = new List<string>();
            Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();
            queue.Enqueue(this.Root);
            while (queue.Count != 0)
            {
                var node = queue.Dequeue();
                FindPathWithSum(sum, int.Parse(node.Value.ToString()), allPaths, node.Value.ToString(), node, false);
                foreach (var childNode in node.ChildList)
                {
                    queue.Enqueue(childNode);
                }
            }

            return allPaths;
        }
    }
}
