using System;
using MonoGame.Extended;
using MonoGame.Extended.Collisions;

namespace TrollsVsElves.Core.Components.Colliders;

public class CircleCollider : ColliderBase
{
    private Action<CollisionEventArgs> _onCollision;

    public CircleCollider(CollisionComponent collisionComponent) : base(collisionComponent)
    {
    }

    public void Initialize(float radius) => Initialize(radius, Vector2.Zero);

    public void Initialize(float radius, Vector2 origin)
    {   
        var collider = new CircleF(Transform.Position - origin, radius);
        base.Initialize(collider, origin);
    }

    public override void OnCollision(CollisionEventArgs collisionInfo)
    {
        _onCollision?.Invoke(collisionInfo);
    }

    public void SubscribeOnCollision(Action<CollisionEventArgs> onCollision) => _onCollision += onCollision;
}