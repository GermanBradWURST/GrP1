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
        public Vector3d Point;
        public Vector3d Vector;//moet normalised zijn

        public Ray(Vector3d p, Vector3d v)
        {
            this.Point = p; this.Vector = v;
        }
    }
}
