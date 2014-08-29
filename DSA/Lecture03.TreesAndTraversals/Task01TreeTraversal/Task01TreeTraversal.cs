namespace Task01TreeTraversal
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// You are given a tree of N nodes represented as a set of N-1 pairs of nodes (parent node, child node), each in the range (0..N-1). 
    /// Write a program to read the tree and find:
    /// a) the root node
    /// b) all leaf nodes
    /// c) all middle nodes
    /// d) the longest path in the tree
    /// e) * all paths in the tree with given sum S of their nodes
    /// f) * all subtrees with given sum S of their nodes
    /// input : 
    /// 7
    /// 2 4
    /// 3 2
    /// 5 0
    /// 3 5
    /// 5 6
    /// 5 1
    /// </summary>
    class Task01TreeTraversal
    {
        static void Main()
        {
            const int SumForPaths = 9;
            const int SumForSubtrees = 6;

            // var tree = ParseTreeFromConsole();
            var tree = ParseTreeFromList();
            Console.WriteLine("\nTree root is: {0}", tree.Root.Value);
            Console.WriteLine("\nTree leaf nodes are: {0}", tree.GetAllLeafs());
            Console.WriteLine("\nTree middle nodes are: {0}", tree.GetAllMiddleNodes());
            Console.WriteLine("\nLongest path: {0}\n", tree.GetLongestPath());
            var allPathsWithSumS = tree.GetAllPathsWithGivenSum(SumForPaths);
            foreach(var path in allPathsWithSumS)
            {
                Console.WriteLine("Path in tree with sum {0}: {1}",SumForPaths, path);
            }
            Console.WriteLine();

            var allSubTreesWithSumS = tree.GetAllSubTreesWithGivenSum(SumForSubtrees);
            foreach(var path in allSubTreesWithSumS)
            {
                Console.WriteLine("Subtree with sum {0}: {1}",SumForSubtrees, path);
            }
        }
 
        private static Tree<int> ParseTreeFromConsole()
        {
            int n;
            n = int.Parse(Console.ReadLine());
            var inputList = new List<string>(); 
            for (var i = 0; i < n - 1; i++)
            {
                inputList.Add(Console.ReadLine());
            }

            return ParseTree(n, inputList);
        }

        private static Tree<int> ParseTreeFromList()
        {
            const int n = 7;
            var inputList = new List<string>() 
            {
                "2 4",
                "3 2",
                "5 0",
                "3 5",
                "5 6",
                "5 1",
            };

            Console.WriteLine(n);
            foreach(var item in inputList)
            {
                Console.WriteLine(item);
            }

            return ParseTree(n,inputList);
        }

        private static Tree<int> ParseTree(int n, IList<string> inputList)
        {
            var nodes = new TreeNode<int>[n];
            var isChild = new bool[n];

            for (int i = 0; i < n; i++)
            {
                nodes[i] = new TreeNode<int>(i);
            }

            for (var i = 0; i < n - 1; i++)
            {
                var inputLine = inputList[i];
                var splitInput = inputLine.Split(new char[] { ' ' });
                var parentId = int.Parse(splitInput[0]);
                var childId = int.Parse(splitInput[1]);
                nodes[parentId].AddChild(nodes[childId]);
                isChild[childId] = true;
            }
            
            var tree = new Tree<int>();

            for (var i = 0; i < n; i++)
            {
                if (isChild[i])
                {
                    continue;
                }
                else
                {
                    tree.Root = nodes[i];
                    break;
                }
            }

            return tree;
        }
    }
}
