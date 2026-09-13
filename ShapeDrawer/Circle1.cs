using System;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Circle1 : Shape
    {
        private int _radius;

        public Circle1():this(Color.Green, 50){}

        public Circle1(Color color, int radius) : base(color)
        {
            _radius = radius;
        }

        public int Radius
        {
            get{return _radius;}
            set{_radius = value;}
        }

        public override void Draw()
        {
            if(Selected)
            {
                DrawOutline();
            }
            SplashKit.FillCircle(Color, X, Y, _radius);
        }

        public override void DrawOutline()
        {
            SplashKit.DrawCircle(Color.Black, X, Y, _radius+2);
        }

        public override bool IsAt(Point2D pt)
        {
            Circle c = new Circle();
            c.Radius = _radius;

            Point2D cirPoint = new Point2D();
            cirPoint.X = X;
            cirPoint.Y = Y;

            c.Center = cirPoint;

            if(SplashKit.PointInCircle(pt, c))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void Scale(float factor)
        {
            Radius = (int)(Radius*factor);
        }
    }
}