using Raylib_CsLo;

namespace RaylibTest.Utils;

public class InputHandler
{
    public static string TextInput(string text)
    {
        if (Raylib.IsKeyDown(KeyboardKey.KEY_BACKSPACE) && text.Length > 0)
            return text[..^1];

        var key = Raylib.GetCharPressed();
        // Check if more characters have been pressed on the same frame
        while (key > 0)
        {
            text += (char) key;
            key = Raylib.GetCharPressed(); // Check next character in the queue
        }

        return text;
    }
}