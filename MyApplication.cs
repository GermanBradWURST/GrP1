using System.Numerics;
using System;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace Template
{
    class MyApplication
    {
        // member variables
        public Surface screen;
        public Raytracer raytrace;
        // constructor
        public MyApplication(Surface screen)
        {
            this.screen = screen;
        }
        // initialize
        public void Init()
        {
            //new Sphere((10, 0, -5), 2, new Color4(1.0f, 0.5f, 0.0f, 1.0f), 0xff0000);
            //new Sphere((10, 0, +5), 2, new Color4(0.5f, 1.0f, 0.0f, 1.0f), 0x00ff00);
            new Plane((0, 1, 0), (0, -2, 0), new Color4(0.0f, 1.0f, 0.5f, 1.0f), 0x0000ff);
            //new Light();
            raytrace = new Raytracer(new Camera((0,0,0), (1,0,0), (0,1,0), new ScreenPlane((3, -3, 3), (3, 3, -3))));
            //raytrace.Render(screen);
        }
        // tick: renders one frame
        public void Tick()
        {
            screen.Clear(0);
            //screen.Print("hello world", 2, 2, 0xffffff);
            //screen.Line(2, 20, 160, 20, 0xff0000);
            raytrace.Render(screen);
        }
    }
}