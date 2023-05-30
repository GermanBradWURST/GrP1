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
        public Scene Scene;
        public Camera Cam;
        public Surface Sur;

        public Raytracer(Scene sc, Camera cam, Surface sr)
        {
            this.Scene = sc;
            this.Cam = cam;
            this.Sur = sr;
        }

        public void Render(Camera cam, Surface surf) //idk what the input/output type should be
        {
            //generate ray for each pixel
            //find intersection of ray to (object?)
            //return pixel??
        }
    }

}