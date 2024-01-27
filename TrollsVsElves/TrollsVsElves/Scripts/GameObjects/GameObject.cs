using System.Collections.Generic;

namespace TrollsVsElves
{
    public class GameObject : ITransient
    {
        private List<IDrawable> _drawables;
        private List<IUpdateable> _updateables;

        public Transform Transform { get; }


        public GameObject(Transform transform)
        {
            Transform = transform;
            _drawables = new List<IDrawable>();
            _updateables = new List<IUpdateable>();
        }

        public void AddComponent<T>(T component) where T : Component
        {
            component.GameObject = this;

            var drawable = component as IDrawable;
            var updateable = component as IUpdateable;

            if (drawable != null)
            {
                _drawables.Add(drawable);
            }

            if (updateable != null)
            {
                _updateables.Add(updateable);
            }
        }



        public void Update()
        {
            foreach (var item in _updateables)
            {
                item.OnUpdate();
            }
        }

        public void Draw()
        {
            foreach (var item in _drawables)
            {
                item.OnDraw();
            }
        }
    }
}