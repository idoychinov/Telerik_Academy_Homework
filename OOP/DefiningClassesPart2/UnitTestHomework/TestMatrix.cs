using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework;

namespace UnitTestHomework
{
    [TestClass]
    public class TestMatrix
    {
        [TestMethod]
        public void TestMatrixAdd()
        {
            Matrix<decimal> matrix1 = new Matrix<decimal>(2, 2);
            matrix1[0, 0] = 12M;
            matrix1[0, 1] = 17M;
            matrix1[1, 0] = 6M;
            matrix1[1, 1] = 3M;

            Matrix<decimal> matrix2 = new Matrix<decimal>(2, 2);
            matrix2[0, 0] = 3M;
            matrix2[0, 1] = 4M;
            matrix2[1, 0] = -4M;
            matrix2[1, 1] = 0M;

            Matrix<decimal> expectedResultMatrix = new Matrix<decimal>(2, 2);
            expectedResultMatrix[0, 0] = 15M;
            expectedResultMatrix[0, 1] = 21M;
            expectedResultMatrix[1, 0] = 2M;
            expectedResultMatrix[1, 1] = 3M;

            Matrix<decimal> resultMatrix = new Matrix<decimal>(2, 2);

            resultMatrix = matrix1 + matrix2;

            Assert.AreEqual(expectedResultMatrix[0, 0], resultMatrix[0, 0], "The result from addition of 2 matrixes is not the expected one.");
            Assert.AreEqual(expectedResultMatrix[0, 1], resultMatrix[0, 1], "The result from addition of 2 matrixes is not the expected one.");
            Assert.AreEqual(expectedResultMatrix[1, 0], resultMatrix[1, 0], "The result from addition of 2 matrixes is not the expected one.");
            Assert.AreEqual(expectedResultMatrix[1, 1], resultMatrix[1, 1], "The result from addition of 2 matrixes is not the expected one.");


        }
    }
}
