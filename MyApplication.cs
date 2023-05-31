using System.Numerics;

namespace Template
{
    class MyApplication
    {
        // member variables
        public Surface screen;
        public Raytracer raytrace;
        // constructor
        public MyApplication(Surface screen)
        {
            this.screen = screen;
        }
        // initialize
        public void Init()
        {
            new Primitive.Sphere();
            new Primitive.Sphere();
            new Primitive.Plane();
            new Light();
            Scene.SceneLevelIntersect();
            raytrace = new Raytracer(new Camera());
        }
        // tick: renders one frame
        public void Tick()
        {
            screen.Clear(0);
            //screen.Print("hello world", 2, 2, 0xffffff);
            //screen.Line(2, 20, 160, 20, 0xff0000);
            raytrace.Render(screen);
        }
    }
}