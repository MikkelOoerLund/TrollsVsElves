namespace TrollsVsElves.Scripts;

internal class Program
{
    public static void Main(string[] args)
    {
        using var game = new Scene();
        game.Run();
    }
}