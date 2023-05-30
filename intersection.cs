using System;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Graphics.OpenGL;

namespace Template
{
    public class Intersection
    {
        public float D;
        public Vector3 N;
        public Primitive P;

        public Intersection(float d, Vector3 n, Primitive p)
        {
            this.D = d;
            this.N = n;
            this.P = p;
            Scene.intersecctionlist.Add(this);
        }


    }
}