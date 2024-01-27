using Microsoft.Xna.Framework.Input;
using TrollsVsElves.Core.Abstractions;
using TrollsVsElves.Scripts.Services;

namespace TrollsVsElves.Scripts.Components;

public class RotateComponent : Component, IUpdateableComponent, ITransient
{
    private readonly InputHandlerService _inputHandler;

    public RotateComponent(InputHandlerService inputHandler)
    {
        _inputHandler = inputHandler;
    }

    public float RotateSpeed { get; set; }

    public void OnUpdate(float deltaTime)
    {
        if (_inputHandler.KeyboardState.IsKeyDown(Keys.A)) 
        { 
            Transform.TranslateRotation(1 * deltaTime); 
        }
        if (_inputHandler.KeyboardState.IsKeyDown(Keys.D)) 
        { 
            Transform.TranslateRotation(-1 * deltaTime); 
        }
    }
}