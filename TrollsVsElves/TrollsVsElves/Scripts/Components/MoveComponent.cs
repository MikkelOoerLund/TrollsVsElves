using Microsoft.Xna.Framework.Input;
using TrollsVsElves.Core.Components;
using TrollsVsElves.Core.Extensions;
using TrollsVsElves.Core.Lifetime;
using TrollsVsElves.Scripts.Services;

namespace TrollsVsElves.Scripts.Components
{
    public class MoveComponent : Component, IUpdateableComponent, ITransient
    {
        public int _movementSpeed;
        private InputHandlerService _inputContainer;

        public MoveComponent(InputHandlerService inputContainer)
        {
            _movementSpeed = 400;
            _inputContainer = inputContainer;
        }

        public void OnUpdate()
        {
            var keyboardState = _inputContainer.KeyboardState;

            if (keyboardState.IsKeyDown(Keys.W)) Transform.Translate(Vector2Extensions.Up * _movementSpeed * Time.DeltaTime);
            if (keyboardState.IsKeyDown(Keys.S)) Transform.Translate(Vector2Extensions.Down * _movementSpeed * Time.DeltaTime);
            if (keyboardState.IsKeyDown(Keys.A)) Transform.Translate(Vector2Extensions.Left * _movementSpeed * Time.DeltaTime);
            if (keyboardState.IsKeyDown(Keys.D)) Transform.Translate(Vector2Extensions.Right * _movementSpeed * Time.DeltaTime);
        }
    }
}