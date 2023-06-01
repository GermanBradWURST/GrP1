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
        public Vector3d Location;
        public Vector3d Direction;
        public Vector3d Intensity;
        
        public Light(Vector3d p, Vector3d d, Vector3d i)
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

