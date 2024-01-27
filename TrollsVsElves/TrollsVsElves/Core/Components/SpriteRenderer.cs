using System;
using Microsoft.Xna.Framework.Graphics;
using TrollsVsElves.Core.Abstractions;

namespace TrollsVsElves.Core.Components;

public class SpriteRenderer : Component, IDrawableComponent, ITransient
{
    private readonly SpriteBatch _spriteBatch;

    public SpriteRenderer(Sprite sprite, SpriteBatch spriteBatch)
    {
        Sprite = sprite;
        _spriteBatch = spriteBatch;
    }

    public Sprite Sprite { get; }

    public void OnDraw()
    {
        var texture = Sprite.Texture;

        var scale = Transform.Scale;
        var rotation = Transform.Rotation;
        var position = Transform.Position;

        var size = new Vector2(texture.Width, texture.Height) * scale;

        var origin = size / 2;

        var rect = new Rectangle
        {
            X = (int)Math.Round(position.X),
            Y = (int)Math.Round(position.Y),
            Width = (int)Math.Round(size.X),
            Height = (int)Math.Round(size.Y)
        };

        _spriteBatch.Draw(texture, rect, null, Color.White, rotation, origin, SpriteEffects.None, 0f);
    }
}