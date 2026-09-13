using System;
using System.Collections.Generic;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Drawing
    {
        private readonly List<Shape> _shapes;
        private Color _background;

        public Drawing(Color background)
        {
            _shapes = new List<Shape>();
            _background = background;
        }

        public Drawing():this(Color.White){}

        public List<Shape> Shapes
        {
            get { return _shapes; }
        }

        public Color Background
        {
            get { return _background; }
            set { _background = value; }
        }

        public int ShapeCount
        {
            get { return _shapes.Count; }
        }

        public void AddShape(Shape s1)
        {
            _shapes.Add(s1);
        }

        public void RemoveShape(Shape s1)
        {
            _shapes.Remove(s1);
        }

        public void SelectShapesAt(Point2D pt)
        {
            foreach (Shape s1 in _shapes)
            {
                if (s1.IsAt(pt) == true)
                {
                    s1.Selected = true;
                }
                else
                {
                    s1.Selected = false;
                }
            }
        }
        
        public List<Shape> SelectedShapes
        {
            get
            {
                List<Shape> result;
                result = new List<Shape>();
                foreach (Shape s1 in _shapes)
                {
                    if (s1.Selected == true)
                    {
                        result.Add(s1);
                    }
                }
                return result;
            }
        }

        /// <summary>
        /// Create random shape use random color
        /// </summary>
        public void AddRandomShape()
        {
            Random r = new Random();

            int choice = r.Next(5);
            Shape shape;

            float x = r.Next(100, 700);
            float y = r.Next(100, 500);

            char _styleType = 'J';

            switch(choice)
            {
                case 0:
                    shape = new Rectangle1(Color.RandomRGB(255), x, y, 100, 100);
                    break;
                case 1:
                    shape = new Circle1(Color.RandomRGB(255), 50)  // Fixed radius
                    {
                        X = x,
                        Y = y
                    };
                    break;
                case 2:
                    shape = new Letter(Color.RandomRGB(255), x, y, 'J');
                    break;
                case 3:
                    shape = new Letter(Color.RandomRGB(255), x, y, 'N');
                    break;
                default:
                    shape = new Line1(Color.RandomRGB(255), x, y, x + 100, y + 100);
                    break;
            }

            _shapes.Add(shape);
        }

        /// <summary>
        /// Change all shape's color to a ramdom color
        /// </summary>
        /// <param name="d1"></param>
        public static void RandomizeShapeColor(Drawing d1)
        {
            foreach (Shape s in d1.Shapes)
            {
                s.Color = Color.RandomRGB(255);
            }
        }

        public void Draw()
        {
            SplashKit.ClearScreen(_background);
            foreach (Shape s1 in _shapes)
            {
                s1.Draw();
            }
        }

        /// <summary>
        /// Make shapes bigger or smaller
        /// </summary>
        /// <param name="factor"></param>
        public void ScaleAllShapes(float factor)
        {
            foreach (Shape shape in _shapes)
            {
                shape.Scale(factor);
            }
        }
    }
}
