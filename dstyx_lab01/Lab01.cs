using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace dstyx_lab01
{

    public class Lab01 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        SpriteFont font; // for drawing the results

        Fractions a = new Fractions(3, 4);
        Fractions b = new Fractions(8, 3);

        public Lab01()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            base.Initialize();
        }


        protected override void LoadContent()
        {
            font = Content.Load<SpriteFont>("Font");
        }


        protected override void UnloadContent()
        {

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

            spriteBatch.DrawString(font, a + " + " + b + " = " + (a + b), new Vector2(50, 50), Color.Black);

            spriteBatch.DrawString(font, a + " - " + b + " = " + (a - b), new Vector2(50, 100), Color.Black);

            spriteBatch.DrawString(font, a + " * " + b + " = " + (a * b), new Vector2(50, 150), Color.Black);

            spriteBatch.DrawString(font, a + " / " + b + " = " + (a / b), new Vector2(50, 200), Color.Black);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
