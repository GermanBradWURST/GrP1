using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    public class ScreenPlane
    {
        public Vector3 LeftUp;
        public Vector3 RightDown;
        public float Xdif;
        public float Ydif;
        public float Zdif;

        public ScreenPlane(Vector3 rightDown, Vector3 leftUp)
        {
            this.LeftUp = leftUp;
            this.RightDown = rightDown;
            this.Xdif = LeftUp.X - RightDown.X;
            this.Ydif = LeftUp.Y - RightDown.Y;
            this.Zdif = LeftUp.Z - RightDown.Z;
        }

        //public void Updatescreenplane()
        //{
            //this.Xdif = LeftUp.X - RightDown.X;
            //this.Ydif = LeftUp.Y - RightDown.Y;
            //this.Zdif = LeftUp.Z - RightDown.Z;
        //}
    }
}
