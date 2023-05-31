using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    public struct Ray
    {
        public Vector3 Point;
        public Vector3 Vector;//moet normalised zijn

        public Ray(Vector3 p, Vector3 v)
        {
            this.Point = p; this.Vector = v;
        }
    }
}
