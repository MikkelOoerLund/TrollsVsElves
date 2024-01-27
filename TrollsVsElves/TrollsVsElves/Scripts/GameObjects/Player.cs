using System;
using Microsoft.Extensions.DependencyInjection;
using TrollsVsElves.Core.Abstractions;
using TrollsVsElves.Core.Components;
using TrollsVsElves.Core.Services;
using TrollsVsElves.Scripts.Components;

namespace TrollsVsElves.Scripts.GameObjects;

public class Player : GameObject, IUpdateableComponent
{
    private readonly SpriteRenderer _spriteRenderer;
    private readonly MoveWithCursorComponent _moveWithCursorComponent;

    public Player(IServiceProvider services)
    {
        _spriteRenderer = AddComponent(services.GetRequiredService<SpriteRenderer>());
        _moveWithCursorComponent = AddComponent(services.GetRequiredService<MoveWithCursorComponent>());

        var textureFactory = services.GetRequiredService<TextureFactory>();

        _spriteRenderer.Sprite.Texture = textureFactory.CreateIfNotExists("Sprites/Square");
    }

    public void OnUpdate()
    {
        
    }
}