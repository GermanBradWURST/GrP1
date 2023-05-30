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
        public Primitive()
        {

        }
    }

    public class Sphere : Primitive
    {
        public Vector3 position;
        public float radius;
        public Sphere(Vector3 position, float radius)
        {
            this.position = position;
            this.radius = radius;
            Scene.primitivelist.Add(this);
        }
    }

    public class Plane : Primitive
    {
        public Vector3 normal;
        public float origindistance;
        public Plane(Vector3 normal, float origindistance)
        {
            this.normal = normal;
            this.origindistance = origindistance;
            Scene.primitivelist.Add(this);
        }
    }
}