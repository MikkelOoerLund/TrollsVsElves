using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TrollsVsElves.Core.Components;
using TrollsVsElves.Core.Lifetime;

namespace TrollsVsElves.Core.Sprites
{
    public class SpriteRenderer : Component, Components.IDrawableComponent, ITransient
    {
        private Sprite _sprite;
        private SpriteBatch _spriteBatch;


        public SpriteRenderer(Sprite sprite, SpriteBatch spriteBatch)
        {
            _sprite = sprite;
            _spriteBatch = spriteBatch;
        }

        public void OnDraw()
        {
            var origin = _sprite.Origin;
            var texture = _sprite.Texture;
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
}