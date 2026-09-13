using System;
using SplashKitSDK;

namespace ShapeDrawer
{
    public abstract class Shape
    {
        private Color _color;
        private float _x;
        private float _y;
        private bool _selected;
        protected float _width;
        protected float _height;
        protected float _strokeWidth;

        public Shape()
        {
            _color = Color.White;
        }

        public Shape(Color color)
        {
            _color = color;
        }

        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public float X
        {
            get { return _x; }
            set { _x = value; }
        }

        public float Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }
        
        public float Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public float Height
        {
            get { return _height; }
            set { _height = value; }
        }
        
        public abstract void Draw();

        public abstract void DrawOutline();

        public abstract Boolean IsAt(Point2D pt);

        /// <summary>
        /// Scale the shape's size
        /// </summary>
        /// <param name="factor"></param>
        public abstract void Scale(float factor);
    }
}