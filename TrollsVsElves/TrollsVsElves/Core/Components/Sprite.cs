using Microsoft.Xna.Framework.Graphics;
using TrollsVsElves.Core.Abstractions;

namespace TrollsVsElves.Core.Components;

public class Sprite : ITransient
{
    public Sprite(Texture2D defaultTexture)
    {
        Texture = defaultTexture;
    }

    public Vector2 Origin { get; set; } = Vector2.Zero;

    public Texture2D Texture { get; set; }
}