using System;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Graphics.OpenGL;

namespace Template
{   

    public static class Scene
    {
        public static List<Light> lightlist = new List<Light>() { };
        public static List<Primitive> primitivelist = new List<Primitive>() { };


        public static void SceneLevelIntersect(Ray ray)
        {
            foreach (Primitive p in primitivelist)
            {
                p.intersectcalc(ray);

            }
        }
    }
}