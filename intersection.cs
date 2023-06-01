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
        public Vector3d point;
        public Primitive primitive;
        public Vector3d normvec;
        public int kleur;
        public static List<Intersection> cache = new List<Intersection>() { };
        public static List<Intersection> intersectionlist = new List<Intersection>() { };

        public Intersection(double d, Vector3d n, Primitive p, Vector3d normvec, int kleur)
        {
            this.distance = d;
            this.point = n;
            this.primitive = p;
            this.normvec = normvec;
            this.kleur = kleur;
            cache.Add(this);
        }


    }
}