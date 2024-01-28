using System;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using TrollsVsElves.Core.Abstractions;

namespace TrollsVsElves.Core.Components;

public class SpriteRenderer : Component, IDrawableComponent, ITransient
{
    private readonly SpriteBatch _spriteBatch;

    public Color Color { get; set; } = Color.White;

    public SpriteRenderer(Sprite sprite, SpriteBatch spriteBatch)
    {
        Sprite = sprite;
        _spriteBatch = spriteBatch;
    }

    public Sprite Sprite { get; }

    public Vector2 Size => (Size2)Sprite.Texture.Bounds.Size * Transform.Scale;

    public Vector2 Origin => Size / 2;

    public void Draw()
    {
        var rect = new Rectangle
        {
            X = (int)Math.Round(Transform.Position.X),
            Y = (int)Math.Round(Transform.Position.Y),
            Width = (int)Math.Round(Size.X),
            Height = (int)Math.Round(Size.Y)
        };

        _spriteBatch.Draw(
            Sprite.Texture, 
            rect, 
            null, 
            Color, 
            Transform.Rotation, 
            Origin, 
            SpriteEffects.None, 
            0f);
    }
}