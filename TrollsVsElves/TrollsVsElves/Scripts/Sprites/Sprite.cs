using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TrollsVsElves
{
    public class Sprite : ITransient
    {
        private Vector2 _origin;
        private Texture2D _texutre;
        private TextureFactory _textureFactory;

        public Vector2 Origin => _origin;
        public Texture2D Texture => _texutre;

        public Sprite(Texture2D texture, TextureFactory textureFactory)
        {
            _texutre = texture;
            _textureFactory = textureFactory;
        }
    }
}