using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Xna.Framework.Graphics;
using TrollsVsElves.Core.GameObjects;
using TrollsVsElves.Core.Sprites;
using TrollsVsElves.Core.Textures;
using TrollsVsElves.Scripts.Components;

namespace TrollsVsElves.Scripts.GameObjects
{
    public class Player : GameObject
    {
        private readonly SpriteRenderer _spriteRenderer;

        public Player(IServiceProvider services, Transform transform) : base(services, transform)
        {
            var texture = ServiceProvider.GetRequiredKeyedService<Texture2D>("Square");



            var sprite = new Sprite(texture, default);
            _spriteRenderer = new SpriteRenderer(sprite, services.GetRequiredService<SpriteBatch>());

            var spriteRenderer = ServiceProvider.GetRequiredService<SpriteRenderer>();
            var moveWithCursorComponent = ServiceProvider.GetRequiredService<MoveWithCursorComponent>();

            AddComponent(spriteRenderer);
            AddComponent(moveWithCursorComponent);
        }
    }
}