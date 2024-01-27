﻿using System.Collections.Generic;

namespace TrollsVsElves
{
    public class GameObjectCollection
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


        public void Update()
        {
            foreach (var item in _gameObjects)
            {
                item.Update();
            }
        }

        public void Draw()
        {
            foreach (var item in _gameObjects)
            {
                item.Draw();
            }
        }
    }
}