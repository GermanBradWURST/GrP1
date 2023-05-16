using System;
using Template;

namespace Template
{
    public class Light
    {
        public Point P;
        public float I;
        public static List<Light> lightlist = new List<Light>() { };
        
        public Light(Point p, float i)
        {
            P = p;
            I = i;
            lightlist.Add(this);
        }

        public void lightremove(Light l)
        {
            lightlist.Remove(l);
        }
    }
}

