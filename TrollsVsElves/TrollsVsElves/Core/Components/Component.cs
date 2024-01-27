using TrollsVsElves.Core.GameObjects;
using TrollsVsElves.Core.Textures;

namespace TrollsVsElves.Core.Components;

public abstract class Component
{
    public GameObject GameObject { get; set; }
    public Transform Transform => GameObject.Transform;
}