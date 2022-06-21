using Raylib_CsLo;
using RaylibTest.Model;
using RaylibTest.Model.Interfaces;

namespace RaylibTest.Test;

public struct FpsCounter : IEntity<EntityType>, IDrawable
{
    public int X { get; set; }
    public int Y { get; set; }
    
    public EntityType Type() => EntityType.Generic;

    public void OnDraw(object? sender, EventArgs e)
    {
        Raylib.DrawFPS(X, Y);
    }
}