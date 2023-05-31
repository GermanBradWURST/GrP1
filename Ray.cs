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
        public (double, double, double) Vector;//moet normalised zijn

        public Ray(Vector3 p, (double, double, double) v)
        {
            this.Point = p; this.Vector = v;
        }
    }
}
