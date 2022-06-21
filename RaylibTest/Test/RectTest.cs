using System.Numerics;
using Raylib_CsLo;
using RaylibTest.Model;
using RaylibTest.Model.Interfaces;

namespace RaylibTest.Test;

public struct RectTest : IDrawable, IUpdateable
{
    public Rectangle rec { get; set; } = new (400, 200, 20, 30);
    private float rot;
    private Vector2 m;

    public RectTest()
    {
        rot = 0;
        m = default;
    }

    public void OnUpdate(object? sender, EventArgs e)
    {
        m = Raylib.GetMousePosition();
        rot = RayMath.Vector2Angle(m, new Vector2(rec.x, rec.y));
    }

    public void OnDraw(object? sender, EventArgs e)
    {
        Raylib.DrawLine((int)rec.x, (int)rec.y, (int)m.X, (int)m.Y, Raylib.BLACK);
        Raylib.DrawRectanglePro(rec, new Vector2(rec.width / 2, rec.height / 2), rot, Raylib.RED);
    }
}