using Microsoft.Extensions.DependencyInjection;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.Collisions;
using TrollsVsElves.Core;
using TrollsVsElves.Core.Extensions;
using TrollsVsElves.Core.Services;
using TrollsVsElves.Scripts.GameObjects;
using TrollsVsElves.Scripts.Services;

namespace TrollsVsElves.Scripts;

public class Scene : Game
{
    private GameObjectCollection _gameObjectCollection;

    private GraphicsDeviceManager _graphics;
    private InputHandlerService _inputHandler;
    private IServiceCollection _serviceCollection;
    private SpriteBatch _spriteBatch;
    private CollisionComponent _collisionComponent;

    public Scene()
    {
        _graphics = new GraphicsDeviceManager(this);
        GameWindowData.Update(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);

        _collisionComponent = new CollisionComponent(new RectangleF(0, 0, GameWindowData.Width, GameWindowData.Height));
        _serviceCollection = new ServiceCollection();

        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
        _gameObjectCollection.Draw();
        _spriteBatch.End();

        base.Draw(gameTime);
    }

    protected override void Initialize()
    {
        _serviceCollection
            .AddSingleton<SpriteBatch>()
            .AddSingleton(_collisionComponent)
            .AddSingleton(Content)
            .AddSingleton(GraphicsDevice)
            .AddSingletonServices();

        _serviceCollection
            .AddTransientServices();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _serviceCollection.AddTransient((provider) =>
        {
            return Content.Load<Texture2D>("Sprites/Square");
        });

        var provider = _serviceCollection.BuildServiceProvider();

        _gameObjectCollection = provider.GetRequiredService<GameObjectCollection>();

        var player = provider.GetRequiredService<Player>();
        var box = provider.GetRequiredService<Box>();

        _gameObjectCollection.AddGameObject(player);
        _gameObjectCollection.AddGameObject(box);

        _spriteBatch = provider.GetRequiredService<SpriteBatch>();
        _inputHandler = provider.GetRequiredService<InputHandlerService>();
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

        _inputHandler.KeyboardState = Keyboard.GetState();
        _inputHandler.MouseState = Mouse.GetState();
        _gameObjectCollection.Update(deltaTime);

        _collisionComponent.Update(gameTime);

        base.Update(gameTime);
    }
}