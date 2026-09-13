using SplashKitSDK;

namespace ShapeDrawer
{
    public static class ShapeFactory
    {
        public static Shape CreateShape(ShapeKind kind, float x, float y, char style)
        {
            switch (kind)
            {             
                case ShapeKind.Circle:
                    return new Circle1(){X=x, Y=y};

                case ShapeKind.Rectangle:
                    return new Rectangle1(){X=x, Y=y};

                case ShapeKind.Line:
                    return new Line1(){X=x, Y=y, EndX=x+150, EndY=y+150};

                case ShapeKind.LetterN:
                    return new Letter(Color.Green, x, y, style){X=x, Y=y};

                case ShapeKind.LetterJ:
                    return new Letter(Color.Green, x, y, style){X=x, Y=y};

                case ShapeKind.NormalName:
                    return new Name(Color.Green, x, y, style);
                    
                case ShapeKind.SmoothName:
                    return new Name(Color.Green, x, y, style);

                default:
                    return null;
            }
        }
    }
}
