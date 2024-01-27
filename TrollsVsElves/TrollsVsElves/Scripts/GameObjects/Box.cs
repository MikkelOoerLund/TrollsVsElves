using System;
using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using TrollsVsElves.Core;
using TrollsVsElves.Core.Components;
using TrollsVsElves.Core.Components.Colliders;
using TrollsVsElves.Core.Services;

namespace TrollsVsElves.Scripts.GameObjects;

public class Box : GameObject
{
    private readonly BoxCollider _boxCollider;
    private readonly SpriteRenderer _spriteRenderer;
    private readonly SpriteBatch _spriteBatch;

    public Box(IServiceProvider services)
    {
        _spriteRenderer = AddComponent(services.GetRequiredService<SpriteRenderer>());
        var textureFactory = services.GetRequiredService<TextureFactory>();
        _spriteRenderer.Sprite.Texture = textureFactory.CreateIfNotExists("Sprites/Square");

        _boxCollider = AddComponent(services.GetRequiredService<BoxCollider>());
        _boxCollider.Initialize(_spriteRenderer.Sprite.Texture.Bounds.Size, _spriteRenderer.Origin);
        _boxCollider.SubscribeOnCollision(x => _spriteRenderer.Color = Color.Green);

        Transform.Translate(new Vector2(GameWindowData.Width / 2, GameWindowData.Height / 2));

        _spriteBatch = services.GetRequiredService<SpriteBatch>();

    }

    protected override void OnUpdate(float deltaTime)
    {
        _spriteRenderer.Color = Color.IndianRed;
    }

    protected override void OnDraw()
    {
        _spriteBatch.DrawRectangle((RectangleF)_boxCollider.Bounds, Color.Red, 3);
    }
}