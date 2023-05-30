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
        public Vector3 Location;
        public Vector3 Direction;
        public Vector3 Intensity;
        
        public Light(Vector3 p, Vector3 d, Vector3 i)
        {
            this.Location = p;
            this.Direction = d;
            this.Intensity = i;
            Scene.lightlist.Add(this);
        }

        public void lightremove(Light l)
        {
            Scene.lightlist.Remove(l);
        }
    }
}

