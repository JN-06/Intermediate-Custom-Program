using System;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Name : Shape
    {
        private char _styleType;

        public Name():this(Color.Green, 100, 100, 'D'){}

        public Name( Color color, float x, float y, char styleType) : base(color)
        {
            X = x;
            Y = y;
            
            _styleType = Char.ToUpper(styleType);
            if (_styleType == 'D')
            {
                _width = 600f;
                _height = 160f;
                _strokeWidth = 16f;
            }
            else
            {
                _width = 480f;
                _height = 120f;
                _strokeWidth = 8f;
            }
        }

        /// <summary>
        /// For 'M' style
        /// </summary>
        /// <param name="startX"></param>
        /// <param name="startY"></param>
        /// <param name="endX"></param>
        /// <param name="endY"></param>
        /// <param name="thickness"></param>
        public void DrawThickLineNormal(float startX, float startY, float endX, float endY, float thickness)
        {
            for (int i = 0; i<thickness; i++)
            {
                SplashKit.DrawLine(Color, startX, startY+i-thickness/2.0f, endX, endY+i-thickness/2.0f);
            }
        }

        /// <summary>
        /// For 'D' style
        /// </summary>
        /// <param name="startX"></param>
        /// <param name="startY"></param>
        /// <param name="endX"></param>
        /// <param name="endY"></param>
        /// <param name="thickness"></param>
        public void DrawThickLineSmooth(float startX, float startY, float endX, float endY, float thickness)
        {
            if (thickness<=0) return;

            // Direction
            float directionX = endX-startX;
            float directionY = endY-startY;
            float length = (float)Math.Sqrt(directionX*directionX+directionY*directionY);

            // If line is short, draw circle
            if (length<0.001f)
            {
                SplashKit.FillCircle(Color, startX, startY, thickness/2);
                return;
            }

            // Perpendicular
            float px = -directionY/length*thickness/2;
            float py = directionX/length*thickness/2;

            // Build thick quad
            Quad q = SplashKit.QuadFrom(startX+px, startY+py, startX-px, startY-py, endX-px, endY-py, endX+px, endY+py);

            SplashKit.FillQuad(Color, q);
            // Round end caps
            SplashKit.FillCircle(Color, startX, startY, thickness/2);
            SplashKit.FillCircle(Color, endX, endY, thickness/2);
        }

        public void DrawLetterC(float x, float y, float w, float h)
        {
            if(_styleType == 'D')
            {
                float r = w*0.22f;

                DrawThickLineSmooth(x+r, y, x+w-r, y, _strokeWidth); // Top
                DrawThickLineSmooth(x+r, y+h, x+w-r, y+h, _strokeWidth); //Bottom
                DrawThickLineSmooth(x, y+r, x, y+h-r, _strokeWidth); // Left side
                DrawThickLineSmooth(x+w-r, y, x+w, y+r, _strokeWidth); // Curve top right
                DrawThickLineSmooth(x+w-r, y+h, x+w, y+h-r, _strokeWidth); // Curve bottom right
            } else
            {
                DrawThickLineNormal(x + w * 0.2f, y, x + w * 0.8f, y, _strokeWidth); // Top
                DrawThickLineNormal(x + w * 0.2f, y, x + w * 0.2f, y + h, _strokeWidth); // Left vertical
                DrawThickLineNormal(x + w * 0.2f, y + h, x + w * 0.8f, y + h, _strokeWidth); // Bottom
            }
        }

        public void DrawLetterH(float x, float y, float w, float h)
        {
            if (_styleType == 'D')
            {
                DrawThickLineSmooth(x, y, x, y+h, _strokeWidth); // Left vertical
                DrawThickLineSmooth(x+w, y, x+w, y+h, _strokeWidth); // Right vertical
                DrawThickLineSmooth(x, y+h*0.5f, x+w, y+h*0.5f, _strokeWidth*1.15f); // Middle bar
            }else
            {
                DrawThickLineNormal(x, y, x, y+h, _strokeWidth); // Normal left
                DrawThickLineNormal(x+w, y, x+w, y+h, _strokeWidth); // Normal right
                DrawThickLineNormal(x, y+h*0.5f, x+w, y+h*0.5f, _strokeWidth); // Middle
            }
        }

        public void DrawLetterE(float x, float y, float w, float h)
        {
            if(_styleType == 'D')
            {
                float arm = w * 0.85f;
                DrawThickLineSmooth(x, y, x, y+h, _strokeWidth); // Vertical
                DrawThickLineSmooth(x, y, x+arm, y, _strokeWidth*1.2f); // Top
                DrawThickLineSmooth(x, y+h * 0.5f, x+arm*0.9f, y+h*0.5f, _strokeWidth); //Middle
                DrawThickLineSmooth(x, y+h, x+arm, y+h, _strokeWidth*1.2f); // Bottom
            } else
            {
                DrawThickLineNormal(x, y, x+w, y, _strokeWidth); // Top
                DrawThickLineNormal(x, y+h*0.5f, x+w*0.65f, y+h*0.5f, _strokeWidth); // Middle
                DrawThickLineNormal(x, y+h, x+w, y+h, _strokeWidth); // Bottom
                DrawThickLineNormal(x, y+ _strokeWidth, x, y+h-_strokeWidth, _strokeWidth); // Vertical
            }
        }

        public void DrawLetterN(float x, float y, float w, float h)
        {
            if(_styleType == 'D')
            {
                DrawThickLineSmooth(x, y, x, y+h, _strokeWidth); // Left
                DrawThickLineSmooth(x + w, y, x+w, y+h, _strokeWidth); // Right
                DrawThickLineSmooth(x, y, x+w, y+h, _strokeWidth * 1.3f); // Diagonal
            } else
            {
                DrawThickLineNormal(x+w*0.15f, y, x+w*0.15f, y+h, _strokeWidth); // Left
                DrawThickLineNormal(x+w*0.85f, y, x+w*0.85f, y+h, _strokeWidth); // Right
                DrawThickLineNormal(x+w*0.15f, y, x+w*0.85f, y+h, _strokeWidth*1.35f); // Diagonal
            }
        }

        public void DrawNameCHEN()
        {
            float letterSpacing = _width/4; // Spacing per letter
            float letterWidth = letterSpacing*0.78f;

            DrawLetterC(X+letterSpacing*0.1f, Y, letterWidth, _height);
            DrawLetterH(X+letterSpacing*1.15f, Y, letterWidth, _height);
            DrawLetterE(X+letterSpacing*2.25f, Y, letterWidth, _height);
            DrawLetterN(X+letterSpacing*3.15f, Y, letterWidth, _height);
        }

        public override void Draw()
        {
            if (Selected)
            {
                DrawOutline();
            }
            DrawNameCHEN();
        }

        public override void DrawOutline()
        {
            if (_styleType == 'D')
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

                // Normal
                float borderWidth = 3;
                for (int i = 0; i<borderWidth; i++)
                {
                    SplashKit.DrawRectangle(Color.Black, X-12-i, Y-12-i, _width+25+2*i, _height+25+2*i);
                }
            } else
            {   
                // 'M' style
                SplashKit.DrawRectangle(Color.Black, X-5, Y-5, _width+10, _height+10);
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