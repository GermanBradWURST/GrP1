﻿using System;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Graphics.OpenGL;
using SixLabors.ImageSharp.PixelFormats;

namespace Template
{
    public class Raytracer
    {
        public Camera Cam;
        public int[,] grid;

        public Raytracer(Camera cam)
        {
            this.Cam = cam;
        }

        public void Render(Surface screen) //idk what the input/output type should be
        {
            int pixelw = screen.width;
            int pixelh = screen.height;

            float Ystep = Cam.plane.Ydif / pixelh;
            float Xstep = Cam.plane.Xdif / pixelw;
            float Zstep = Cam.plane.Zdif / pixelw;

            for (int a = 0; a < pixelh; a++)
            {
                for (int b = 0; b < pixelw; b++)
                {
                    Vector3d dir = (Cam.plane.LeftUp.X+b*Xstep+(1/2)*Xstep-Cam.P.X, Cam.plane.LeftUp.Y+a*Ystep+(1/2)*Ystep-Cam.P.Y, Cam.plane.LeftUp.Z+b*Zstep+(1/2)*Zstep-Cam.P.Z);
                    dir.Normalize();
                    Ray ray = new Ray(Cam.P, dir);
                    Scene.SceneLevelIntersect(ray);
                    try { screen.Plot(b, a, Intersection.intersectionlist[0].kleur); }
                    catch { screen.Plot(b, a, 0xf0f000); }
                    Intersection.intersectionlist.Clear();
                }
            }
        }
    }

}