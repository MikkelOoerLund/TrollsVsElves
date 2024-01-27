using System;
using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using TrollsVsElves.Core.Components;
using TrollsVsElves.Core.Components.Colliders;
using TrollsVsElves.Core.Services;
using TrollsVsElves.Scripts.Components;

namespace TrollsVsElves.Scripts.GameObjects;

public class Player : GameObject
{
    private readonly MoveWithCursorComponent _moveWithCursorComponent;
    private readonly RotateComponent _rotateComponent;
    private readonly SpriteRenderer _spriteRenderer;
    private readonly CircleCollider _circleCollider;
    private readonly SpriteBatch _spriteBatch;

    private readonly float _colliderRadius;

    public Player(IServiceProvider services)
    {
        _moveWithCursorComponent = AddComponent(services.GetRequiredService<MoveWithCursorComponent>());
        
        _rotateComponent = AddComponent(services.GetRequiredService<RotateComponent>());
        _rotateComponent.RotateSpeed = 1;

        _spriteRenderer = services.GetRequiredService<SpriteRenderer>();
        AddComponent(_spriteRenderer);
        var textureFactory = services.GetRequiredService<TextureFactory>();
        _spriteRenderer.Sprite.Texture = textureFactory.CreateIfNotExists("Sprites/Square");

        _colliderRadius = _spriteRenderer.Sprite.Texture.Width / 2;
        _circleCollider = AddComponent(services.GetRequiredService<CircleCollider>());
        _circleCollider.Initialize(_colliderRadius);
        _circleCollider.SubscribeOnCollision(x => Debug.WriteLine("PLAYER IS TOUCHING!!! at" + DateTime.Now));

        _spriteBatch = services.GetRequiredService<SpriteBatch>();
    }

    protected override void OnDraw()
    {
        _spriteBatch.DrawCircle((CircleF)_circleCollider.Bounds, 8, Color.Red, 3f);
    }
}