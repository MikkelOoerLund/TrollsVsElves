using Microsoft.Xna.Framework;

namespace TrollsVsElves
{
    public class Transform : ITransient
    {
        private float _rotation;

        private Vector2 _scale;
        private Vector2 _position;


        public float Rotation => _rotation;

        public Vector2 Scale => _scale;
        public Vector2 Position => _position;

        public Transform()
        {
            _scale = Vector2.One;
            _position = Vector2.Zero;
        }


        public void Translate(Vector2 translation)
        {
            _position += translation;
        }



    }
}