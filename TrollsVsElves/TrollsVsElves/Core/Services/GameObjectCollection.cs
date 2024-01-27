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

    public void Draw()
    {
        foreach (var item in _gameObjects)
        {
            item.Draw();
        }
    }

    public void Update()
    {
        foreach (var item in _gameObjects)
        {
            item.Update();
        }
    }
}