using System;
using SplashKitSDK;
using NUnit.Framework;

namespace ShapeDrawer
{
    [TestFixture()]

    public class ShapeTest
    {
        [Test()]

        public void TestShape()
        {
            Rectangle1 s1 = new Rectangle1();

            s1.X = 25;
            s1.Y = 25;
            s1.Width = 50;
            s1.Height = 50;

            Assert.IsTrue(s1.IsAt(SplashKit.PointAt(50, 50)));
            Assert.IsTrue(s1.IsAt(SplashKit.PointAt(25, 25)));
            Assert.IsFalse(s1.IsAt(SplashKit.PointAt(10, 50)));
            Assert.IsFalse(s1.IsAt(SplashKit.PointAt(50, 10)));
        }

        [Test()]

        public void TestShapeAt()
        {
            Rectangle1 s1 = new Rectangle1();

            s1.X = 25;
            s1.Y = 25;
            s1.Width = 50;
            s1.Height = 50;

            Assert.IsTrue(s1.IsAt(SplashKit.PointAt(50, 50)));

            s1.X = 100;
            s1.Y = 100;

            Assert.IsFalse(s1.IsAt(SplashKit.PointAt(50, 50)));
        }

        [Test()]

        public void TestShapeWhenResized()
        {
            Rectangle1 s1 = new Rectangle1();

            s1.X = 25;
            s1.Y = 25;
            s1.Width = 50;
            s1.Height = 50;

            Assert.IsTrue(s1.IsAt(SplashKit.PointAt(70, 70)));

            s1.Width = 5;
            s1.Height = 5;

            Assert.IsFalse(s1.IsAt(SplashKit.PointAt(70, 70)));
        }

        [Test()]
        public void TestSelected()
        {
            Rectangle1 s1 = new Rectangle1();
            s1.Selected = true;
            Assert.IsTrue(s1.Selected);

            s1.Selected = false;
            Assert.IsFalse(s1.Selected);
        }
    }
}