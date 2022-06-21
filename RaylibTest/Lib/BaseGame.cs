using Raylib_CsLo;
using RaylibTest.Model;
using RaylibTest.Model.Interfaces;
using RaylibTest.Utils;

namespace RaylibTest.Lib;

public class BaseGame
{
    public event EventHandler? Update;
    public event EventHandler? Draw;

    private readonly Random _rng = new ();
    
    private readonly Dictionary<string, object> _entities = new (Constants.MAX_LOADED_ENTITIES);
    
    public virtual void Init()
    {
        Raylib.InitWindow(800, 480, "Hello World");
        Raylib.SetTargetFPS(60);
        
        RayGui.GuiLoadStyleDefault();
        
        RegisterEntities();

        var updateHandler = Update;
        var drawHandler = Draw;

        while (!Raylib.WindowShouldClose())
        {
            updateHandler?.Invoke(this, EventArgs.Empty);

            Raylib.BeginDrawing();

            Raylib.ClearBackground(Raylib.WHITE);
            drawHandler?.Invoke(this, EventArgs.Empty);

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }

    private void RegisterEntities()
    {
        foreach (IUpdateable entity in _entities.Values.Where(e => e is IUpdateable))
            Update += entity.OnUpdate;
        
        foreach (IDrawable entity in _entities.Values.Where(e => e is IDrawable))
            Draw += entity.OnDraw;
    }

    public void AddEntity(object entity)
    {
        _entities.Add(_rng.NextInt64().ToString(), entity);
    }
    
    public void AddNamedEntity(string name, object entity)
    {
        _entities.Add(name, entity);
    }

    public object? GetNamedEntity(string name)
    {
        if (_entities.ContainsKey(name))
            return _entities[name];

        return null;
    }
}