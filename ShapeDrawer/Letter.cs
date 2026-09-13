using System;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Letter : Shape
    {
        private char _styleType;

        public Letter():this(Color.Green, 100, 100, 'J'){}

        public Letter( Color color, float x, float y, char styleType) : base(color)
        {
            X = x;
            Y = y;
            
            _styleType = Char.ToUpper(styleType);
            if (_styleType == 'J')
            {
                _width = 80f;
                _height = 140f;
                _strokeWidth = 16f;
            }
            else
            {
                _width = 100f;
                _height = 140f;
                _strokeWidth = 16f;
            }
        }

        /// <summary>
        /// Both 'J' and 'N' letter use same smooth thick line
        /// </summary>
        /// <param name="startX"></param>
        /// <param name="startY"></param>
        /// <param name="endX"></param>
        /// <param name="endY"></param>
        /// <param name="thickness"></param>
        public void DrawThickLine(float startX, float startY, float endX, float endY, float thickness)
        {
            if (thickness<=0) return;

            float directionX = endX-startX;
            float directionY = endY-startY;
            float length = (float)Math.Sqrt(directionX*directionX+directionY*directionY);

            if (length<0.001f)
            {
                SplashKit.FillCircle(Color, startX, startY, thickness/2);
                return;
            }

            float px = -directionY/length*thickness/2;
            float py = directionX/length*thickness/2;

            Quad q = SplashKit.QuadFrom(startX+px, startY+py, startX-px, startY-py, endX-px, endY-py, endX+px, endY+py);

            SplashKit.FillQuad(Color, q);
            SplashKit.FillCircle(Color, startX, startY, thickness/2);
            SplashKit.FillCircle(Color, endX, endY, thickness/2);
        }

        public void DrawLetter()
        {
            if (_styleType == 'J')
            {
                DrawThickLine(X+_width*0.23f, Y, X+_width/0.85f, Y, _strokeWidth*1.1f); // Top
                DrawThickLine(X+_width*0.7f, Y+10, X+_width*0.7f, Y+_height*0.8f, _strokeWidth); // Vertical
                DrawThickLine(X+_width*0.7f, Y+_height*0.93f, X+_width*0.35f, Y+_height, _strokeWidth*1.2f); // Curve bottom part left direction
                DrawThickLine(X+_width*0.35f+10, Y+_height, X+_width*0.1f, Y+_height-10, _strokeWidth*1.2f); // Curve finishing line
            } else
            {
                DrawThickLine(X+_width*0.15f, Y, X+_width*0.15f, Y+_height, _strokeWidth); // Left
                DrawThickLine(X+_width*0.85f, Y, X+_width*0.85f, Y+_height, _strokeWidth); // Right
                DrawThickLine(X+_width*0.15f, Y, X+_width*0.85f, Y+_height, _strokeWidth*1.35f); // Diagonal
            }
        }

        public override void Draw()
        {
            if (Selected)
            {
                DrawOutline();
            }
            DrawLetter();
        }

        public override void DrawOutline()
        {
            if (_styleType == 'J')
            {
                for (int i = 12; i>0; i--)
                {
                    float alpha = 0.5f*(i/12f);
                    Color c = Color.RGBAColor(0f, 1f, 0f, alpha); // Glow effect
                    SplashKit.DrawRectangle(c, X-15-i, Y-15-i, _width+50+i*2, _height+30+i*2);
                }
                SplashKit.DrawRectangle(Color.Black, X-15, Y-15, _width+50, _height+30);
            } else
            {
                float rectW = _width+45;
                float rectH = _height+45;

                // Glow effect
                for (int i = 15; i>0; i--)
                {
                    float alpha = 0.25f*(i/15f);
                    Color c = Color.RGBAColor(0f, 1f, 0f, alpha);
                    SplashKit.DrawRectangle(c, X-20-i, Y-20-i, rectW+2*i, rectH+2*i);
                }

                float borderWidth = 3;
                for (int i = 0; i<borderWidth; i++)
                {
                    SplashKit.DrawRectangle(Color.Black, X-12-i, Y-12-i, _width+25+2*i, _height+25+2*i);
                }
            }    
        }

        public override bool IsAt(Point2D pt)
        {
            Rectangle bounds = new Rectangle();
            bounds.X = X;
            bounds.Y = Y;
            bounds.Width = _width;
            bounds.Height = _height;
            if(SplashKit.PointInRectangle(pt, bounds))
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
            if (factor<=0) return;
            _width*=factor;
            _height*=factor;
            _strokeWidth*=factor;
        }
    }
}