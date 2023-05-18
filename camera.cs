using System;
using System.ComponentModel;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace Template
{
    public class Camera
    {
        public Vector3 P;
        public Vector3 LookVector;
        public Vector3 UpVector;
        public Surface plane;
        public Camera(Vector3 p, Vector3 l, Vector3 u, Surface pl)
        {
            P = p;
            LookVector = l;
            UpVector = u;
            plane = pl;
        }
    }
}