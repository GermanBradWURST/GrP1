using System;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace Template
{
    public class Primitive
    {
        public Color4 kleur;
        public Primitive()
        {

        }

        public virtual void intersectcalc(Light l) { }

    public class Sphere : Primitive
    {
        public Vector3 position;
        public float radius;
        public Sphere(Vector3 position, float radius, Color4 kleur)
        {
            this.position = position;
            this.radius = radius;
            this.kleur = kleur;
            Scene.primitivelist.Add(this);
        }

        public override void intersectcalc(Light l)
        {
            Vector3 linevector = (this.position.X - l.Location.X, this.position.Y - l.Location.Y, this.position.Z - l.Location.Z);
            float a = 3;
            float b = 2 * linevector.X + 2 * linevector.Y + 2 * linevector.Z;
            float c = linevector.X * linevector.X + linevector.Y * linevector.Y + linevector.Z * linevector.Z - this.radius * this.radius;
            double t1 = -b / (2 * a) + Math.Sqrt(b*b - 4 * a * c) / (2*a);
            double t2 = -b / (2 * a) + Math.Sqrt(b * b - 4 * a * c) / (2 * a);
            double t = Math.Max(t1, t2);
            (double, double, double) result = (this.position.X - t*linevector.X, this.position.Y - t * linevector.Y, this.position.Z - t * linevector.Z);
            double ll = Math.Sqrt((result.Item1-l.Location.X)*(result.Item1-l.Location.X)+(result.Item2-l.Location.Y) * (result.Item2 - l.Location.Y)+ (result.Item3 - l.Location.Z) * (result.Item3 - l.Location.Z));
            double fac = Math.Sqrt((l.Location.X - result.Item1) * (l.Location.X - result.Item1) + (l.Location.Y - result.Item2) * (l.Location.Y - result.Item2) + (l.Location.Z - result.Item3) * (l.Location.Z - result.Item3));
            (double, double, double) normvec = ((l.Location.X - result.Item1) / fac, (l.Location.Y - result.Item2) / fac, (l.Location.Z - result.Item3) / fac);
            new Intersection(ll, result, this, normvec);
        }
    }

    public class Plane : Primitive
    {
        public Vector3 normal;
        public float origindistance;
        public Plane(Vector3 normal, float origindistance, Color4 kleur)
        {
            this.normal = normal;
            this.origindistance = origindistance;
            this.kleur = kleur;
            Scene.primitivelist.Add(this);
        }

        public override void intersectcalc(Light l)
        {
                double normalise = Math.Sqrt(this.normal.X * this.normal.X + this.normal.Y * this.normal.Y + this.normal.Z * this.normal.Z);
                double D = this.origindistance * normalise;
                double a = (D - this.normal.X * l.Location.X - this.normal.Y * l.Location.Y - this.normal.Z * l.Location.Z) / (this.normal.X * (1/normalise) * this.normal.X + this.normal.Y * (1 / normalise) * this.normal.Y + this.normal.Z * (1 / normalise) * this.normal.Z);
                (double, double, double) result = (l.Location.X + a * (this.normal.X / normalise), l.Location.Y + a * (this.normal.Y / normalise), l.Location.Z + a * (this.normal.Z / normalise));
                double fac = Math.Sqrt((l.Location.X - result.Item1) * (l.Location.X - result.Item1) + (l.Location.Y - result.Item2) * (l.Location.Y - result.Item2) + (l.Location.Z - result.Item3) * (l.Location.Z - result.Item3));
                (double, double, double) normvec = ((l.Location.X - result.Item1)/fac, (l.Location.Y - result.Item2)/fac, (l.Location.Z - result.Item3)/fac);
                new Intersection(Math.Abs(a), result, this, normvec);
        }
    }
}