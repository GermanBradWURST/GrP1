using System;

namespace Template
{
    public struct Point
    {
        public float X {get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public Point(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}