using System;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Graphics.OpenGL;

namespace Template
{
    public class Raytracer
    {
        public Camera Cam;

        public Raytracer(Camera cam)
        {
            this.Cam = cam;
        }

        public void Render(Surface screen) //idk what the input/output type should be
        {
            int w = screen.width;
            int h = screen.height;
            //generate ray for each pixel
            //find intersection of ray to (object?)
            //return pixel??
        }
    }

}