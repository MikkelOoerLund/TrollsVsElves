using MonoGame.Extended;
using MonoGame.Extended.Collisions;
using TrollsVsElves.Core.Abstractions;

namespace TrollsVsElves.Core.Components.Colliders;

public abstract class ColliderBase : Component, IUpdateableComponent, ICollisionActor, ITransient
{
    private readonly CollisionComponent _collisionComponent;

    public ColliderBase(CollisionComponent collisionComponent)
    {
        _collisionComponent = collisionComponent;
    }

    public IShapeF Bounds { get; private set; }
    private Vector2 origin;

    protected void Initialize(IShapeF shape) => Initialize(shape, Vector2.Zero);
    protected void Initialize(IShapeF shape, Vector2 origin)
    {
        this.origin = origin;

        Bounds = shape;
        _collisionComponent.Insert(this);
    }

    public abstract void OnCollision(CollisionEventArgs collisionInfo);

    public virtual void Update(float deltaTime)
    {
        Bounds.Position = Transform.Position - origin;
    }
}