using Raylib_CsLo;
using RaylibTest.Model;
using RaylibTest.Model.Interfaces;
using RaylibTest.Utils;

namespace RaylibTest.Test;

public class Gui : IDrawable, IUpdateable
{
    private bool _editMode;
    private string _text = string.Empty;
    
    public void OnDraw(object? sender, EventArgs e)
    {
        _editMode = RayGui.GuiToggle(new Rectangle(50f, 50f, 100f, 50f), "Toggle Edit", _editMode);

        if (!_editMode)
            return;
        
        RayGui.GuiTextBox(new Rectangle(50f, 100f, 100f, 50f), _text, _text.Length, _editMode);
        Raylib.DrawText($"{_text} {_text.Length}", 12, 12, 20, Raylib.BLACK);
    }

    public void OnUpdate(object? sender, EventArgs e)
    {
        if(_editMode)
            _text = InputHandler.TextInput(_text);
    }
}