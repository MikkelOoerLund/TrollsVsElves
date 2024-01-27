namespace TrollsVsElves.Core;

public static class GameWindow
{
    private static Vector2 _center;
    private static int _height;
    private static int _width;

    public static Vector2 Center => _center;
    public static int Height => _height;
    public static int Width => _width;

    public static void Update(int width, int height)
    {
        _width = width;
        _height = height;
        _center = new Vector2(width / 2, height / 2);
    }
}