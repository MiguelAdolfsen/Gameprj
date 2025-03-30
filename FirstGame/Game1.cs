using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using FirstGame.NewFolder;

namespace FirstGame;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Map map;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        Window.Title = "First Game";

        Window.AllowUserResizing = true;

    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here...

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);



        // Replace "Tileset" with the actual asset name of your tileset image.
        Texture2D tileset = Content.Load<Texture2D>("Tileset");

        // Create your map object, e.g. a 20x20 grid.
        map = new Map(20, tileset);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
        map.Draw(_spriteBatch);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
