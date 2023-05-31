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
        public double distance;
        public (double, double, double) point;
        public Primitive primitive;
        public (double, double, double) normvec;
        public static List<Intersection> intersectionlist = new List<Intersection>() { };

        public Intersection(double d, (double, double, double) n, Primitive p, (double, double, double) normvec)
        {
            this.distance = d;
            this.point = n;
            this.primitive = p;
            this.normvec = normvec;
            intersectionlist.Add(this);
        }


    }
}