using Raylib_CsLo;
using RaylibTest.Lib;
using RaylibTest.Test;

namespace RaylibTest;

static class Program
{
    static BaseGame _game = new ();
    
    public static void Main()
    {
        _game.AddNamedEntity("fpsCounter", new FpsCounter {X = 0, Y = 0});
        _game.AddEntity(new RectTest { rec = new Rectangle(400, 200, 10, 30)});
        _game.AddEntity(new RectTest { rec = new Rectangle(200, 400, 10, 30)});
        _game.AddEntity(new RectTest { rec = new Rectangle(100, 400, 10, 30)});
        _game.AddEntity(new RectTest { rec = new Rectangle(300, 150, 10, 30)});
        
        _game.AddEntity(new Gui());

        _game.Init();
    }
}