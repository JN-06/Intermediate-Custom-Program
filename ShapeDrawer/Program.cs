using System;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Program
    {
        public static void Main()
        {
            Window shapeWindow = new Window("GameMain", 800, 600);

            ShapeKind kindToAdd = ShapeKind.Circle;

            Drawing d1 = new Drawing();

            char _nameStyle = 'D';

            do
            {
                SplashKit.ProcessEvents();

                SplashKit.ClearScreen(Color.White);

                if (SplashKit.KeyTyped(KeyCode.RKey))
                {
                    kindToAdd = ShapeKind.Rectangle;
                } else if (SplashKit.KeyTyped(KeyCode.CKey))
                {
                    kindToAdd = ShapeKind.Circle;
                } else if (SplashKit.KeyTyped(KeyCode.LKey))
                {
                    kindToAdd = ShapeKind.Line;
                } else if (SplashKit.KeyTyped(KeyCode.AKey))
                {
                    d1.AddRandomShape();
                } else if (SplashKit.KeyTyped(KeyCode.NKey))
                {
                    kindToAdd = ShapeKind.LetterN;
                    _nameStyle = 'N';
                } else if (SplashKit.KeyTyped(KeyCode.JKey))
                {
                    kindToAdd = ShapeKind.LetterJ;
                    _nameStyle = 'J';
                } else if (SplashKit.KeyTyped(KeyCode.DKey))
                {
                    kindToAdd = ShapeKind.SmoothName;
                    _nameStyle = 'D';
                } else if (SplashKit.KeyTyped(KeyCode.MKey))
                {
                    kindToAdd = ShapeKind.NormalName;
                    _nameStyle = 'M';
                } else if(SplashKit.KeyTyped(KeyCode.SKey))
                {
                    d1.ScaleAllShapes(0.8f); // Scale down by 20%
                } else if(SplashKit.KeyTyped(KeyCode.BKey))
                {
                    d1.ScaleAllShapes(1.25f); // Scale up by 25%
                } else if(SplashKit.KeyTyped(KeyCode.EKey))
                {
                    d1.Shapes.Clear();
                    d1.Background = Color.White;
                }
                
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Shape newShape = ShapeFactory.CreateShape(kindToAdd, SplashKit.MouseX(),SplashKit.MouseY(), _nameStyle);

                    if (newShape != null)
                    {
                        d1.AddShape(newShape);
                    }
                }

                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    d1.Background = SplashKit.RandomRGBColor(255);
                }

                if (SplashKit.KeyTyped(KeyCode.ReturnKey) || SplashKit.KeyTyped(KeyCode.KeypadEnter))
                {
                    Drawing.RandomizeShapeColor(d1);
                }

                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    d1.SelectShapesAt(SplashKit.MousePosition());
                }

                if (SplashKit.KeyTyped(KeyCode.DeleteKey) || SplashKit.KeyTyped(KeyCode.BackspaceKey))
                {
                    foreach (Shape s1 in d1.SelectedShapes)
                    {
                        d1.RemoveShape(s1);
                    }
                }

                d1.Draw();
                SplashKit.DrawText("R:Rectangle, C:Circle, L:Line, N:Letter N, J:Letter J, D:Smooth Name, M:Normal Name", Color.Black, 10, 10);
                SplashKit.DrawText("S:Scale Down, B:Scale Up, A:Random Shape, Space:Change Background Color, Enter:Change Shape Color", Color.Black, 10, 30);
                SplashKit.DrawText("Left Click:Add Shape, Right Click:Select Shape, Delete/Backspace:Remove Selected Shape, E: Clear", Color.Black, 10, 50);

                SplashKit.RefreshScreen(60);
            } while (!SplashKit.QuitRequested());
        }
    }
}
