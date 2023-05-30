using System;
using Template;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace Template
{
    public class Light
    {
        public Vector3 P;
        public float I;
        
        public Light(Vector3 p, float i)
        {
            P = p;
            I = i;
            Scene.lightlist.Add(this);
        }

        public void lightremove(Light l)
        {
            Scene.lightlist.Remove(l);
        }
    }
}

