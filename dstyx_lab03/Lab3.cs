using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CPI311.GameEngine;


namespace dstyx_lab03
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Lab3 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        SpriteFont font;
        Model model;


        //need 3 matricies
        Matrix world;
        Matrix view;
        Matrix projection;

        Vector3 cameraPosition = new Vector3(0, 0, 5);
        Vector3 torusPosition = new Vector3(0,0,0);
        Vector3 torusScale= new Vector3(1,1,1);
        Vector3 torusRoatation = new Vector3(0,0,0);// yaw, pitch and roll

        public Lab3()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            spriteBatch = new SpriteBatch(GraphicsDevice);
            base.Initialize();
            Time.Initialize();
            InputManager.Initialize();
        }

        
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("Font");
            model = Content.Load<Model>("Torus");
        }

        
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

       
        protected override void Update(GameTime gameTime)
        {

            Time.Update(gameTime);
            InputManager.Update();

            //moving the camera
            if (InputManager.IsKeyDown(Keys.W))
                cameraPosition += Vector3.Up*Time.ElapsedGameTime;
            if (InputManager.IsKeyDown(Keys.S))
                cameraPosition += Vector3.Down * Time.ElapsedGameTime;
            if (InputManager.IsKeyDown(Keys.A))
                cameraPosition += Vector3.Left * Time.ElapsedGameTime;
            if (InputManager.IsKeyDown(Keys.D))
                cameraPosition += Vector3.Right * Time.ElapsedGameTime;



            //moving the object
            if (InputManager.IsKeyDown(Keys.Up))
                torusPosition += Vector3.Up * Time.ElapsedGameTime;
            if (InputManager.IsKeyDown(Keys.Down))
                torusPosition += Vector3.Down * Time.ElapsedGameTime;
            if (InputManager.IsKeyDown(Keys.Left))
                torusPosition += Vector3.Left * Time.ElapsedGameTime;
            if (InputManager.IsKeyDown(Keys.Right))
                torusPosition += Vector3.Right * Time.ElapsedGameTime;

            //section for rotation
            if (InputManager.IsKeyDown(Keys.Insert))
                torusRoatation += new Vector3(1,0,0) * Time.ElapsedGameTime;
            if (InputManager.IsKeyDown(Keys.Delete))
                torusRoatation -= new Vector3(1, 0, 0) * Time.ElapsedGameTime;
            if (InputManager.IsKeyDown(Keys.Home))
                torusRoatation += new Vector3(0, 1, 0) * Time.ElapsedGameTime;
            if (InputManager.IsKeyDown(Keys.End))
                torusRoatation -= new Vector3(0, 1, 0) * Time.ElapsedGameTime;
            if (InputManager.IsKeyDown(Keys.PageUp))
                torusRoatation += new Vector3(0, 0, 1) * Time.ElapsedGameTime;
            if (InputManager.IsKeyDown(Keys.PageDown))
                torusRoatation -= new Vector3(0, 0, 1) * Time.ElapsedGameTime;


            //scaling object
            if (InputManager.IsKeyDown(Keys.LeftShift) && InputManager.IsKeyDown(Keys.Up))
                torusScale += Vector3.One * Time.ElapsedGameTime;
            if (InputManager.IsKeyDown(Keys.LeftShift) && InputManager.IsKeyDown(Keys.Down))
                torusScale -= Vector3.One * Time.ElapsedGameTime;




            world = Matrix.CreateScale(torusScale)*Matrix.CreateFromYawPitchRoll(torusRoatation.X,torusRoatation.Y,torusRoatation.Z)*Matrix.CreateTranslation(torusPosition);

            //view = Matrix.CreateLookAt(new Vector3(0, 0, 5), new Vector3(0, 0, 0), new Vector3(0, 1, 0));
            view = Matrix.CreateLookAt(cameraPosition, cameraPosition + Vector3.Forward, Vector3.Up);

            projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver2, GraphicsDevice.Viewport.AspectRatio, 0.1f, 1000f);


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);


            spriteBatch.Begin();
            // TODO: Add your drawing code here
            spriteBatch.DrawString(font, "WASD to move camera, shift+WASD to move object", new Vector2 (0,0), Color.Black);
            spriteBatch.DrawString(font, "Insert/Delete to change yaw", new Vector2(0, 20), Color.Black);
            spriteBatch.DrawString(font, "Home/End to change pitch", new Vector2(0, 40), Color.Black);
            spriteBatch.DrawString(font, "PageUp/PageDown to change roll", new Vector2(0, 60), Color.Black);

            model.Draw(world, view, projection);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
