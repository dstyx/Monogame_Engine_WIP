using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace dstyx_lab00
{

    public class Lab00 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D texture;
        SpriteFont font;        // **Extra Class Work

        public Lab00()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        protected override void Initialize() { base.Initialize(); }





        protected override void LoadContent()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice);
            texture = Content.Load<Texture2D>("background");

            font = Content.Load<SpriteFont>("font");
        }


        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(texture,
                new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height),
                Color.White);

            spriteBatch.DrawString(font, "ASU is awesome", new Vector2(100, 100), Color.Black);


            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
