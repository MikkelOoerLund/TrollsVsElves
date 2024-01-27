using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using TrollsVsElves.Core.Abstractions;

namespace TrollsVsElves.Core.Services;

public class TextureFactory : ISingleton
{
    private ContentManager _contentManager;
    private Dictionary<string, Texture2D> _texturesByNames;

    public TextureFactory(ContentManager contentManager)
    {
        _contentManager = contentManager;
        _texturesByNames = new Dictionary<string, Texture2D>();
    }

    public Texture2D CreateIfNotExists(string path)
    {
        if (_texturesByNames.ContainsKey(path))
        {
            return _texturesByNames[path];
        }

        var texture = _contentManager.Load<Texture2D>(path);
        _texturesByNames.Add(path, texture);
        return texture;
    }
}