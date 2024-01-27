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
        var origin = Sprite.Origin;
        var texture = Sprite.Texture;
        var sourceRectangle = texture.Bounds;

        var scale = Transform.Scale;
        var rotation = Transform.Rotation;
        var position = Transform.Position;

        var halfWidth = texture.Width / 2;
        var halfHeight = texture.Height / 2;

        var spritePosition = new Vector2(position.X - halfWidth, position.Y - halfHeight);
        _spriteBatch.Draw(texture, spritePosition, sourceRectangle, Color.White, rotation, origin, scale, SpriteEffects.None, 0);
    }
}