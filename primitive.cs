﻿using System;
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

        public virtual void intersectcalc(Ray ray) { }
    }
    public class Sphere : Primitive
    {
        public Vector3 mid;
        public float radius;
        public Color4 kleur;
        public int k;
        public Sphere(Vector3 position, float radius, Color4 kleur, int k)
        {
            this.mid = position;
            this.radius = radius;
            this.kleur = kleur;
            Scene.primitivelist.Add(this);
            this.k = k;
        }

        public override void intersectcalc(Ray ray)
        {


            double a = ray.Vector.Item1 * ray.Vector.Item1 + ray.Vector.Item2 * ray.Vector.Item2 + ray.Vector.Item3 * ray.Vector.Item3;

            double b = ray.Point.X*ray.Vector.Item1 - 2*this.mid.X*ray.Vector.Item1 + ray.Point.Y * ray.Vector.Item2 - 2 * this.mid.Y * ray.Vector.Item2 + ray.Point.Z * ray.Vector.Item3 - 2 * this.mid.Z * ray.Vector.Item3;

            double c = (this.mid.X * this.mid.X - 2 * this.mid.X * ray.Point.X + ray.Point.X * ray.Point.X) + (this.mid.Y * this.mid.Y - 2 * this.mid.Y * ray.Point.Y + ray.Point.Y * ray.Point.Y) + (this.mid.Z * this.mid.Z - 2 * this.mid.Z * ray.Point.Z + ray.Point.Z * ray.Point.Y) - this.radius * this.radius;

            double Discriminant = b * b + 4 * a * c;

            double t;

            if (Discriminant > 0 )
                {
                    double t1 = -b / (2 * a) + Math.Sqrt(Discriminant) / (2 * a);
                    double t2 = -b / (2 * a) - Math.Sqrt(Discriminant) / (2 * a);
                    if (t1 > 0 && t2 >0) { t = Math.Min(t1, t2); }
                    else if (t1 < 0 && t2 < 0) { return; }
                    else { t = Math.Max(t1, t2); }
                    
                }

            else if (Discriminant == 0)
                {
                    t = -b / (2 * a);
                }

            else { return; }
            
            if (t < 0) { return; }

            double ll = t;

            (double, double, double) result = (ray.Point.X + t*ray.Vector.Item1, ray.Point.Y + t * ray.Vector.Item2, ray.Point.Z + t * ray.Vector.Item3);

            double fac = Math.Sqrt((result.Item1 - this.mid.X) * (result.Item1 - this.mid.X) + (result.Item2 - this.mid.Y) * (result.Item2 - this.mid.Y) + (result.Item3 - this.mid.Z) * (result.Item3 - this.mid.Z));

            (double, double, double) normvec = ((result.Item1 - this.mid.X) / fac, (result.Item2 - this.mid.Y) / fac, (result.Item3 - this.mid.Z) / fac);

            new Intersection(ll, result, this, normvec, this.k);
        }
    }

    public class Plane : Primitive
    {
        public Vector3 normal;
        public float origindistance;
        public Color4 kleur;
        public int k;
        public Plane(Vector3 normal, float origindistance, Color4 kleur, int k)
        {
            this.normal = normal;
            this.origindistance = origindistance;
            this.kleur = kleur;
            Scene.primitivelist.Add(this);
            this.k = k;
        }

        public override void intersectcalc(Ray ray)
        {   



            double normalise = Math.Sqrt(this.normal.X * this.normal.X + this.normal.Y * this.normal.Y + this.normal.Z * this.normal.Z);
            double D = this.origindistance * normalise;
            (double, double, double) normalisedvector = (this.normal.X / normalise, this.normal.Y / normalise, this.normal.Z / normalise);
            (double, double, double) position = (this.origindistance * normalisedvector.Item1, this.origindistance * normalisedvector.Item2, this.origindistance * normalisedvector.Item3);

            double a = this.normal.X*(position.Item1 - ray.Point.X) + this.normal.Y*(position.Item2 - ray.Point.Y) + this.normal.Z*(position.Item3 - ray.Point.Z);
            double b = -(this.normal.X * ray.Vector.Item1 + this.normal.Y * ray.Vector.Item2 + this.normal.Z * ray.Vector.Item3);
            double t = -b / a;

            if (t<=0) { return; }
            
            (double, double, double) result = (ray.Point.X + t * ray.Vector.Item1, ray.Point.Y + t * ray.Vector.Item2, ray.Point.Z + t * ray.Vector.Item3);

            (double, double, double) normvec;

            double dotproduct = normalisedvector.Item1 * ray.Vector.Item1 + normalisedvector.Item2 * ray.Vector.Item2 + normalisedvector.Item3 * ray.Vector.Item3;

            if ( dotproduct>0)

                {
                    normvec = (-normalisedvector.Item1, -normalisedvector.Item2, -normalisedvector.Item3);
                }
            else { normvec = normalisedvector; }

            new Intersection(Math.Abs(a), result, this, normvec, this.k);
        }
    }
}