using System;
using System.Collections.Generic;
using TrollsVsElves.Core.Abstractions;
using TrollsVsElves.Core.Components;

namespace TrollsVsElves.Core.Services;

public class GameObjectCollection : ISingleton
{
    private List<GameObject> _gameObjects;

    public GameObjectCollection()
    {
        _gameObjects = new List<GameObject>();
    }

    public void AddGameObject(GameObject gameObject)
    {
        _gameObjects.Add(gameObject);
    }

    public GameObject GetGameObjectWithName(string name)
    {
        foreach (var gameObject in _gameObjects)
        {
            if (gameObject.Name == name)
            {
                return gameObject;
            }
        }

        throw new Exception($"GameObject with name: {name} not found");
    }

    public void Draw()
    {
        foreach (var item in _gameObjects)
        {
            item.Draw();
        }
    }

    public void Update(float deltaTime)
    {
        foreach (var item in _gameObjects)
        {
            item.Update(deltaTime);
        }
    }
}