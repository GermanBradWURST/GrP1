using System;
using System.Numerics;
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

        public virtual void Intersectcalc(Ray ray) { }


    }
    public class Sphere : Primitive
    {
        public Vector3d mid;
        public float radius;
        public Color4 kleur;
        public int k;
        public Sphere(Vector3d position, float radius, Color4 kleur, int k)
        {
            this.mid = position;
            this.radius = radius;
            this.kleur = kleur;
            Scene.primitivelist.Add(this);
            this.k = k;
        }

        public override void Intersectcalc(Ray ray)
        {

            Vector3d diff = this.mid - ray.Point;
            Vector3d prod = Vector3d.Cross(diff, ray.Vector);
            double distance = prod.Length / ray.Vector.Length;

            if (distance > this.radius) { }
            else {
                double scal = Vector3d.Dot(diff, ray.Vector);

                Vector3d preres = ray.Vector * scal;

                double stepback = Math.Sqrt(this.radius * this.radius - distance * distance);//lengte

                Vector3d result = preres - ray.Vector * stepback;

                double ll = Vector3d.Subtract(result, ray.Point).Length;

                Vector3d normvec = Vector3d.Normalize(result - this.mid);

                new Intersection(ll, result, this, normvec, this.k);
            }



            /*double a = ray.Vector.Item1 * ray.Vector.Item1 + ray.Vector.Item2 * ray.Vector.Item2 + ray.Vector.Item3 * ray.Vector.Item3;

            double b = ray.Point.X*ray.Vector.Item1 - 2*this.mid.X*ray.Vector.Item1 + ray.Point.Y * ray.Vector.Item2 - 2 * this.mid.Y * ray.Vector.Item2 + ray.Point.Z * ray.Vector.Item3 - 2 * this.mid.Z * ray.Vector.Item3;

            double c = (this.mid.X * this.mid.X - 2 * this.mid.X * ray.Point.X + ray.Point.X * ray.Point.X) + (this.mid.Y * this.mid.Y - 2 * this.mid.Y * ray.Point.Y + ray.Point.Y * ray.Point.Y) + (this.mid.Z * this.mid.Z - 2 * this.mid.Z * ray.Point.Z + ray.Point.Z * ray.Point.Y) - this.radius * this.radius;

            double Discriminant = b * b - 4 * a * c;

            double t;

            if (Discriminant < 0 || a ==0) { }

            else if (Discriminant > 0 )
            {
                double t1 = -b / (2 * a) + Math.Sqrt(Discriminant) / (2 * a);
                double t2 = -b / (2 * a) - Math.Sqrt(Discriminant) / (2 * a);
                if (t1 > 0 && t2 >0) { t = Math.Min(t1, t2); }
                else if (t1 < 0 && t2 < 0) { return; }
                else { t = Math.Max(t1, t2); }

                if (t < 0) { }
                else
                {
                    double ll = t;

                    (double, double, double) result = (ray.Point.X + t * ray.Vector.Item1, ray.Point.Y + t * ray.Vector.Item2, ray.Point.Z + t * ray.Vector.Item3);

                    double fac = Math.Sqrt((result.Item1 - this.mid.X) * (result.Item1 - this.mid.X) + (result.Item2 - this.mid.Y) * (result.Item2 - this.mid.Y) + (result.Item3 - this.mid.Z) * (result.Item3 - this.mid.Z));

                    (double, double, double) normvec = ((result.Item1 - this.mid.X) / fac, (result.Item2 - this.mid.Y) / fac, (result.Item3 - this.mid.Z) / fac);

                    new Intersection(ll, result, this, normvec, this.k);
                }
            }*/
        }
    }

    public class Plane : Primitive
    {
        public Vector3d normal;
        public Vector3d planepoint;
        public Color4 kleur;
        public int k;
        public Plane(Vector3d normal, Vector3d planepoint, Color4 kleur, int k)
        {
            this.normal = normal;
            this.planepoint = planepoint;
            this.kleur = kleur;
            Scene.primitivelist.Add(this);
            this.k = k;
        }

        public override void Intersectcalc(Ray ray)
        {
            if (Vector3d.Dot(this.normal, ray.Vector) == 0) { }
            else
            {
                Vector3d normalisedvector = Vector3d.Normalize(this.normal);

                double a = Vector3d.Dot(this.normal, ray.Vector);
                double b = -Vector3d.Dot(this.normal, planepoint - ray.Point);
                double t = -b / a;

                if (t <= 0) { }
                else 
                {
                    Vector3d result = ray.Point + ray.Vector*t;

                    Vector3d normvec;

                    double dotproduct = Vector3d.Dot(normalisedvector, ray.Vector);

                    if (dotproduct > 0)

                    {
                        normvec = -normalisedvector;
                    }
                    else { normvec = normalisedvector; }

                    new Intersection(Math.Abs(a), result, this, normvec, this.k);
                }
            }
        }
    }
}