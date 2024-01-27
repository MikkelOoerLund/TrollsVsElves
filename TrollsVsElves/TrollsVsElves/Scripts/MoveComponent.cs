using Microsoft.Xna.Framework.Input;

namespace TrollsVsElves
{
    public class MoveComponent : Component, IUpdateable, ITransient
    {
        public int _movementSpeed;
        private InputHandler _inputContainer;

        public MoveComponent(InputHandler inputContainer)
        {
            _movementSpeed = 400;
            _inputContainer = inputContainer;
        }

        public void OnUpdate()
        {
            var keyboardState = _inputContainer.KeyboardState;

            if (keyboardState.IsKeyDown(Keys.W)) Transform.Translate(Vector2Extensions.Up * _movementSpeed * Time.DeltaTime);
            if (keyboardState.IsKeyDown(Keys.S)) Transform.Translate(Vector2Extensions.Down* _movementSpeed * Time.DeltaTime);
            if (keyboardState.IsKeyDown(Keys.A)) Transform.Translate(Vector2Extensions.Left * _movementSpeed * Time.DeltaTime);
            if (keyboardState.IsKeyDown(Keys.D)) Transform.Translate(Vector2Extensions.Right * _movementSpeed * Time.DeltaTime);

        }
    }
}