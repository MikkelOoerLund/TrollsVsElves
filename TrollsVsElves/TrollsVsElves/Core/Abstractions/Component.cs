using TrollsVsElves.Core.Components;

namespace TrollsVsElves.Core.Abstractions;

public abstract class Component
{
    public GameObject GameObject { get; set; }
    public Transform Transform => GameObject.Transform;
}