using Microsoft.Extensions.DependencyInjection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using System.Transactions;

namespace TrollsVsElves
{





    public class MoveWithCursorComponent : Component, IUpdateable, ITransient
    {
        private int _movementSpeed;
        private InputHandler _inputHandler;

        public MoveWithCursorComponent(InputHandler inputHandler)
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


    public static class GameWindow
    {
        private static int _width;
        private static int _height;
        private static Vector2 _center;

        public static int Width => _width;
        public static int Height => _height;

        public static Vector2 Center => _center;

        public static void Update(int width, int height)
        {
            _width = width;
            _height = height;
            _center = new Vector2(width/2, height/2);
        }
    }



    public class Scene : Game
    {
        private GameObjectCollection _gameObjectCollection;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private InputHandler _inputHandler;
        private IServiceCollection _serviceCollection;

        public Scene()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            GameWindow.Update(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);

            _serviceCollection = new ServiceCollection();

            _serviceCollection
                .AddSingleton<SpriteBatch>()
                .AddSingleton<TextureFactory>()
                .AddSingleton<InputHandler>()
                .AddSingleton<GameObjectCollection>()
                .AddSingleton<ContentManager>(Content)
                .AddSingleton<GraphicsDevice>(GraphicsDevice);

            _serviceCollection
                .AddTransientServices();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _serviceCollection.AddTransient<Texture2D>((provider) =>
            {
                return Content.Load<Texture2D>("Sprites/Square");
            });

            var provider = _serviceCollection.BuildServiceProvider();

            _gameObjectCollection = provider.GetRequiredService<GameObjectCollection>();

            var gameObject = provider.GetRequiredService<GameObject>();
            var spriteRenderer = provider.GetRequiredService<SpriteRenderer>();
            var moveWithCursorComponent = provider.GetRequiredService<MoveWithCursorComponent>();

            gameObject.AddComponent(spriteRenderer);
            gameObject.AddComponent(moveWithCursorComponent);

            _gameObjectCollection.AddGameObject(gameObject);
            _spriteBatch = provider.GetRequiredService<SpriteBatch>();
            _inputHandler = provider.GetRequiredService<InputHandler>();

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            Time.DeltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            _inputHandler.KeyboardState = Keyboard.GetState();
            _inputHandler.MouseState = Mouse.GetState();
            _gameObjectCollection.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _gameObjectCollection.Draw();
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}