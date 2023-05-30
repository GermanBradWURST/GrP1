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
        public double D;
        public (double, double, double) N;
        public Primitive P;
        public static List<Intersection> intersectionlist = new List<Intersection>() { };

        public Intersection(double d, (double, double, double) n, Primitive p)
        {
            this.D = d;
            this.N = n;
            this.P = p;
            intersectionlist.Add(this);
        }


    }
}