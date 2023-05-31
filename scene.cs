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

            double result;
            Intersection inter;
            try
            {
                result = Intersection.cache[0].distance;
                inter = Intersection.cache[0];
                foreach (Intersection i in Intersection.cache)
                {
                    if (i.distance < result)
                    {
                        result = i.distance;
                        inter = i;
                    }
                }
                Intersection.intersectionlist.Add(inter);
            }
            catch { }
            Intersection.cache.Clear();

        }
    }
}