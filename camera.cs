using System;
using System.ComponentModel;
using System.Numerics;

namespace Template
{
    public class Camera
    {
        public Point P;
        public Point LookVector;
        public Point UpVector;
        public Surface plane;
        public Camera(Point p, Point l, Point u, Surface pl)
        {
            P = p;
            LookVector = l;
            UpVector = u;
            plane = pl;
        }
    }
}