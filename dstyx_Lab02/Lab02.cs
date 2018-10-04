using System;
using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CPI311.GameEngine;

namespace dstyx_Lab02
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Lab02 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Sprite sprite;
        Vector2 anchor = new Vector2(400, 200);
        float r = 100;
        float timer = 0;
        float factor = 1;
        // KeyboardState prevState;

        public Lab02()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {
            //prevState = Keyboard.GetState();

            base.Initialize();
            InputManager.Initialize();
            Time.Initialize();
        }



        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            sprite = new Sprite(Content.Load<Texture2D>("Square"));

            


        }



        protected override void UnloadContent()
        {
            
        }


        protected override void Update(GameTime gameTime)
        {
            /*
            KeyboardState currentState = Keyboard.GetState();
            if (currentState.IsKeyDown(Keys.Left) && prevState.IsKeyUp(Keys.Left))
                sprite.Position += Vector2.UnitX * -5;
            if (currentState.IsKeyDown(Keys.Right) && prevState.IsKeyUp(Keys.Right))
                sprite.Position += Vector2.UnitX * 5;
            if (currentState.IsKeyDown(Keys.Up) && prevState.IsKeyUp(Keys.Up))
                sprite.Position += Vector2.UnitY * -5;
            if (currentState.IsKeyDown(Keys.Down) && prevState.IsKeyUp(Keys.Down))
                sprite.Position += Vector2.UnitY * 5;
            if (currentState.IsKeyDown(Keys.Space))
                sprite.Rotation += 0.05f;
            prevState = currentState;
            
            Time.Update(gameTime);
            InputManager.Update();
            if (InputManager.IsKeyDown(Keys.Left))
                anchor += Vector2.UnitX * -5;
            if (InputManager.IsKeyDown(Keys.Right))
                anchor += Vector2.UnitX * 5;
            if (InputManager.IsKeyDown(Keys.Up))
                anchor += Vector2.UnitY * -5;
            if (InputManager.IsKeyDown(Keys.Down))
                anchor += Vector2.UnitY * 5;
            if (InputManager.IsKeyDown(Keys.Space))
                sprite.Rotation += 0.05f;

    */

            Time.Update(gameTime);
            InputManager.Update();
            if (InputManager.IsKeyDown(Keys.Left))
                if (r > 10)
                    r -= 5;
            if (InputManager.IsKeyDown(Keys.Right))
                if (r < 1000)
                    r += 5;
            if (InputManager.IsKeyDown(Keys.Up))
                factor += (float)0.1;
            if (InputManager.IsKeyDown(Keys.Down))
                factor -= (float)0.1;



            timer += Time.ElapsedGameTime*factor;

            
            sprite.Position = new Vector2(anchor.X + r*(float)Math.Cos(timer), anchor.Y + r * (float)Math.Sin(timer));

            Console.WriteLine(Time.ElapsedGameTime);
            


        }



        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);


            spriteBatch.Begin();
            sprite.Draw(spriteBatch);
            spriteBatch.End();


            base.Draw(gameTime); 
        }

    }
}
