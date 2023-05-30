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

        public virtual Intersection intersectcalc(Light l) { return ////; }
    }

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

        public override Intersection intersectcalc(Light l)
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
            Intersection i = new Intersection(ll, result, this);
            return i;
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

        public override Intersection intersectcalc(Light l)
        {
            Vector3 planevector = ()
        }
    }
}