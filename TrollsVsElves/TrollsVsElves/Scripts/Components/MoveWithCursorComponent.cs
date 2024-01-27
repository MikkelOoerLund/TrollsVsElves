using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using TrollsVsElves.Core.Abstractions;
using TrollsVsElves.Core.Textures;
using TrollsVsElves.Scripts.Services;

namespace TrollsVsElves.Scripts.Components;

public class MoveWithCursorComponent : Component, IUpdateableComponent, ITransient
{
    private InputHandlerService _inputHandler;
    private int _movementSpeed;

    public MoveWithCursorComponent(InputHandlerService inputHandler)
    {
        _movementSpeed = 400;
        _inputHandler = inputHandler;
    }

    public void OnUpdate()
    {
        var mouseState = _inputHandler.MouseState;
        var mousePosition = new Vector2(mouseState.X, mouseState.Y);

        var position = Transform.Position;
        var direciton = mousePosition - position;

        var distance = Vector2.Distance(mousePosition, position);
        direciton.Normalize();

        if (distance < 5)
        {
            return;
        }

        if (mouseState.RightButton == ButtonState.Pressed)
        {
            Transform.Translate(direciton * _movementSpeed * Time.DeltaTime);
        }
    }
}