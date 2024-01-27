namespace TrollsVsElves.Core.Extensions
{
    public static class Vector2Extensions
    {
        private static Vector2 _up = new Vector2(0, -1);
        public static Vector2 Down => _down;
        public static Vector2 Left => _left;
        public static Vector2 Right => _right;
        public static Vector2 Up => _up;
        private static Vector2 _down => new Vector2(0, 1);
        private static Vector2 _left => new Vector2(-1, 0);
        private static Vector2 _right => new Vector2(1, 0);
    }
}