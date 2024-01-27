using System.Collections.Generic;
using TrollsVsElves.Core.Components;
using TrollsVsElves.Core.Lifetime;
using TrollsVsElves.Core.Textures;

namespace TrollsVsElves.Core.GameObjects;

public class GameObject : ITransient
{
    private List<IDrawableComponent> _drawables;
    private List<IUpdateableComponent> _updateables;

    public GameObject(Transform transform)
    {
        Transform = transform;
        _drawables = new List<IDrawableComponent>();
        _updateables = new List<IUpdateableComponent>();
    }

    public Transform Transform { get; }

    public void AddComponent<T>(T component) where T : Component
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