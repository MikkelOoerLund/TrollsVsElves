using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TrollsVsElves.Core.Abstractions;

namespace TrollsVsElves.Core.Components;

public class GameObject : ITransient
{
    private List<Component> _components;
    private List<IDrawableComponent> _drawables;
    private List<IUpdateableComponent> _updateables;

    public string Name { get; set; }

    public GameObject()
    {
        _components = new List<Component>();
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

        _components.Add(component);
        return component;
    }

    public T GetComponent<T>() where T : Component
    {
        var type = typeof(T);

        foreach (var component in _components)
        {
            if (component.GetType() == type)
            {
                return component as T;
            }
        }

        throw new Exception($"GameObject has no component of type {type}");
    }


    public void Draw()
    {
        foreach (var item in _drawables)
        {
            item.Draw();
        }

        OnDraw();
    }

    public void Update(float deltaTime)
    {
        foreach (var item in _updateables)
        {
            item.Update(deltaTime);
        }

        OnUpdate(deltaTime);
    }
    
    protected virtual void OnDraw() { }
    protected virtual void OnUpdate(float deltaTime) { }
}