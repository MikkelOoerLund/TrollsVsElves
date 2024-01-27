using Microsoft.Xna.Framework.Graphics;
using TrollsVsElves.Core.Lifetime;
using TrollsVsElves.Core.Textures;

namespace TrollsVsElves.Core.Sprites
{
    public class Sprite : ITransient
    {
        private Vector2 _origin;
        private TextureFactory _textureFactory;
        private Texture2D _texutre;

        public Sprite(Texture2D texture, TextureFactory textureFactory)
        {
            _texutre = texture;
            _textureFactory = textureFactory;
        }

        public Vector2 Origin => _origin;
        public Texture2D Texture => _texutre;
    }
}