using TrollsVsElves.Core.Abstractions;

namespace TrollsVsElves.Core.Components;

public class Transform : ITransient
{
    private Vector2 _position;
    private float _rotation;

    private Vector2 _scale;

    public Transform()
    {
        _scale = Vector2.One;
        _position = Vector2.Zero;
    }

    public Vector2 Position => _position;
    public float Rotation => _rotation;

    public Vector2 Scale => _scale;

    public void Translate(Vector2 translation)
    {
        _position += translation;
    }
}