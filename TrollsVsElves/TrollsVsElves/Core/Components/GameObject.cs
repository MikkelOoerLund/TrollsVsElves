using System.Collections.Generic;
using TrollsVsElves.Core.Abstractions;

namespace TrollsVsElves.Core.Components;

public class GameObject : ITransient
{
    private List<IDrawableComponent> _drawables;
    private List<IUpdateableComponent> _updateables;

    public GameObject()
    {
        _drawables = new List<IDrawableComponent>();
        _updateables = new List<IUpdateableComponent>();
    }

    public Transform Transform { get; init; } = new Transform();

    public T AddComponent<T>(T component) where T : Component
    {
        component.GameObject = this;

        var drawable = component as IDrawableComponent;
        var updateable = component as IUpdateableComponent;

        if (drawable != null)
        {
            _drawables.Add(drawable);
        }

        if (updateable != null)
        {
            _updateables.Add(updateable);
        }

        return component;
    }

    public void Draw()
    {
        foreach (var item in _drawables)
        {
            item.OnDraw();
        }
    }

    public void Update()
    {
        foreach (var item in _updateables)
        {
            item.OnUpdate();
        }
    }
}