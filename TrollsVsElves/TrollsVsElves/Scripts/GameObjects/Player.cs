using System;
using Microsoft.Extensions.DependencyInjection;
using TrollsVsElves.Core.Components;
using TrollsVsElves.Core.Services;
using TrollsVsElves.Scripts.Components;

namespace TrollsVsElves.Scripts.GameObjects;

public class Player : GameObject
{
    private readonly MoveWithCursorComponent _moveWithCursorComponent;
    private readonly RotateComponent _rotateComponent;
    private readonly SpriteRenderer _spriteRenderer;

    public Player(IServiceProvider services)
    {
        _moveWithCursorComponent = AddComponent(services.GetRequiredService<MoveWithCursorComponent>());
        _rotateComponent = AddComponent(services.GetRequiredService<RotateComponent>());
        _spriteRenderer = AddComponent(services.GetRequiredService<SpriteRenderer>());

        _rotateComponent.RotateSpeed = 1;

        var textureFactory = services.GetRequiredService<TextureFactory>();

        _spriteRenderer.Sprite.Texture = textureFactory.CreateIfNotExists("Sprites/Square");
    }
}