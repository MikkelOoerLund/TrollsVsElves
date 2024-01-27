using Microsoft.Extensions.DependencyInjection;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TrollsVsElves.Core.Extensions;
using TrollsVsElves.Core.GameObjects;
using TrollsVsElves.Core.Textures;
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

    public Scene()
    {
        _serviceCollection = new ServiceCollection();
        _graphics = new GraphicsDeviceManager(this);
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
        Core.GameWindow.Update(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);

        _serviceCollection
            .AddSingleton<SpriteBatch>()
            .AddSingleton<TextureFactory>()
            .AddSingleton<InputHandlerService>()
            .AddSingleton<GameObjectCollection>()
            .AddSingleton(Content)
            .AddSingleton(GraphicsDevice);

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

        _gameObjectCollection.AddGameObject(player);
        _spriteBatch = provider.GetRequiredService<SpriteBatch>();
        _inputHandler = provider.GetRequiredService<InputHandlerService>();
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
}