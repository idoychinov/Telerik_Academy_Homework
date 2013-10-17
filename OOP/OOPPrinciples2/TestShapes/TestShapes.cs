using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shapes;

namespace TestShapes
{
    [TestClass]
    public class TestShapes
    {
        Shape[] shapes;
        const int triangleWidht = 12;
        const int triangleHeight = 3;
        const int circleRadius = 9;
        const int rectangleWidth = 13;
        const int rectangleHeight = 7;

        [TestInitialize]
        public void TestInitialize()
        {
            shapes = new Shape[] { new Triangle(triangleWidht, triangleHeight), new Circle(circleRadius), new Rectangle(rectangleWidth, rectangleHeight) };
        }

        [TestMethod]
        public void TestTriangle()
        {
            decimal surface = (decimal)(triangleHeight * triangleWidht) / 2M;
            TestShape(typeof(Triangle), surface);
        }

        [TestMethod]
        public void TestCircle()
        {
            decimal surface = (decimal)(circleRadius * circleRadius * (decimal)Math.PI);
            TestShape(typeof(Circle), surface);
        }

        [TestMethod]
        public void TestRectangle()
        {
            decimal surface = rectangleWidth * rectangleHeight;
            TestShape(typeof(Rectangle), surface);
        }

        public void TestShape(Type type,decimal expectedResult)
        {
            string errorMessage = "Incorect calculation of" + type.Name + " surface";

            foreach (Shape shape in shapes)
            {
                if (shape.GetType() == type)
                {
                    Assert.AreEqual(expectedResult, shape.CalculateSurface(), errorMessage);
                }

            }
        }
    }
}
