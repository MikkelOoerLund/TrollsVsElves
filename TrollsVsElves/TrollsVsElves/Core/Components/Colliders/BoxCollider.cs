using System;
using MonoGame.Extended;
using MonoGame.Extended.Collisions;

namespace TrollsVsElves.Core.Components.Colliders;

public class BoxCollider : ColliderBase
{
    private Action<CollisionEventArgs> _onCollision;

    public BoxCollider(CollisionComponent collisionComponent) : base(collisionComponent)
    {
    }

    public void Initialize(Size2 size) => Initialize(size, Vector2.Zero);
    public void Initialize(Size2 size, Vector2 offset)
    {
        var collider = new RectangleF(Transform.Position - offset, size);
        base.Initialize(collider, offset);
    }

    public override void OnCollision(CollisionEventArgs collisionInfo)
    {
        _onCollision?.Invoke(collisionInfo);
    }

    public void SubscribeOnCollision(Action<CollisionEventArgs> onCollision) => _onCollision += onCollision;
}