using System;
using System.Collections.Generic;
using SplashKitSDK;
using NUnit.Framework;

namespace ShapeDrawer
{
    [TestFixture()]
    public class DrawingTest
    {
        [Test()]
        public void TestDefaultInitialization()
        {
            Drawing d1 = new Drawing();
            Assert.AreEqual(d1.Background, Color.White);
        }

        [Test()]
        public void TestInitialiseWithColor()
        {
            Drawing d1 = new Drawing(Color.Green);
            Assert.AreEqual(d1.Background, Color.Green);
        }

        [Test()]
        public void TestAddShape()
        {
            Drawing d1 = new Drawing();
            int count = d1.ShapeCount;
            Assert.AreEqual(0, count);

            d1.AddShape(new Rectangle1());
            d1.AddShape(new Rectangle1());
            count = d1.ShapeCount;
            Assert.AreEqual(2, count);
        }

        [Test()]
        public void TestSelectShape()
        {
            Drawing d1 = new Drawing();
            Shape[] testShapes =
            {
                new Rectangle1(Color.Red, 25, 25, 50, 50),
                new Rectangle1(Color.Green, 25, 10, 50, 50),
                new Rectangle1(Color.Blue, 10, 25, 50, 50)
            };

            foreach (Shape s1 in testShapes)
            {
                d1.AddShape(s1);
            }

            List<Shape> selected;
            Point2D point;

            point = SplashKit.PointAt(70, 70);
            d1.SelectShapesAt(point);
            selected = d1.SelectedShapes;
            CollectionAssert.Contains(selected, testShapes[0]);
            Assert.AreEqual(1, selected.Count);

            point = SplashKit.PointAt(70, 50);
            d1.SelectShapesAt(point);
            selected = d1.SelectedShapes;
            CollectionAssert.Contains(selected, testShapes[0]);
            CollectionAssert.Contains(selected, testShapes[1]);
            Assert.AreEqual(2, selected.Count);
        }

        [Test()]
        public void TestRemoveShape()
        {
            Drawing d1 = new Drawing();
            Shape[] testShapes =
            {
                new Rectangle1(Color.Red, 25, 25, 50, 50),
                new Rectangle1(Color.Green, 25, 10, 50, 50),
                new Rectangle1(Color.Blue, 10, 25, 50, 50)
            };

            foreach (Shape s1 in testShapes)
            {
                d1.AddShape(s1);
            }

            List<Shape> selected;
            Point2D point;

            point = SplashKit.PointAt(70, 70);
            d1.SelectShapesAt(point);
            selected = d1.SelectedShapes;
            CollectionAssert.Contains(selected, testShapes[0]);
            Assert.AreEqual(1, selected.Count);

            d1.RemoveShape(testShapes[0]);
            selected = d1.SelectedShapes;
            CollectionAssert.DoesNotContain(selected, testShapes[0]);
            Assert.AreEqual(0, selected.Count);
        }
    }
}