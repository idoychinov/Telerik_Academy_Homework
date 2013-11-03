using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using P06BinarySearchTree;

namespace TestBST
{
    [TestClass]
    public class TestBinarySearchTree
    {
        BinarySearchTree<int> testTree;
        List<int> treeValues;
        Random rand = new Random();
        const int treeElementsCount = 100;

        [TestInitialize]
        public void TestInitialize()
        {
            testTree = new BinarySearchTree<int>();
            treeValues = new List<int>();
            for (int i = 0; i < treeElementsCount; i++)
			{
                int currentValue = rand.Next(-10000, 10001);
                testTree.AddElement(currentValue);
                treeValues.Add(currentValue);
			}
        }

        [TestMethod]
        public void TestRootValueIfAdded()
        {
            Assert.AreEqual(true, testTree.SearchElement(treeValues[0]), "Root value not found");
        }

        [TestMethod]
        public void TestIEnumerable()
        {
            bool isInTheList=true;
            int count = 0;
            foreach (var treeNodeValue in testTree)
            {
                if (treeValues.IndexOf(treeNodeValue) < 0)
                {
                    isInTheList = false;
                    break;
                }
                count++;
            }
            if (count != treeValues.Count)
            {
                isInTheList = false;
            }

            Assert.AreEqual(true, isInTheList, "There is tree value that is not in the list.");
        }

        [TestMethod]
        public void TestToString()
        {
            StringBuilder treeString = new StringBuilder();
            treeString.Append("{");
            foreach (var treeNodeValue in testTree)
            {
                treeString.Append(treeNodeValue);
                treeString.Append(", ");
            }
            treeString.Remove(treeString.Length - 2, 2);
            treeString.Append("}");
            Assert.AreEqual(treeString.ToString(), testTree.ToString(), "ToString() doesnt produce correct output.");
        }
    }
}
