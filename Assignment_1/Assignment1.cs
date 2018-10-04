using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CPI311.GameEngine;
using System;


namespace Assignment_1
{
    
    public class Assignment1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        AnimatedSprite spriteSheet;
        SpriteFont font;

        ProgressBar timer;
        ProgressBar distance;
        Texture2D rectangle;
        Random random;
        Sprite bomb;
        Axis axis= new Axis();
        bool win, lose;

        int x, y;
        float speed;

        

        public Assignment1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            InputManager.Initialize();
            Time.Initialize();
            base.Initialize();
            
            random = new Random();
            //initial position
            spriteSheet.Position = new Vector2(200, 300);
            rectangle = new Texture2D(graphics.GraphicsDevice, 80, 30);
            timer.Position = new Vector2(200, 100);
            distance.Position = new Vector2( 600, 100);
            bomb.Position = new Vector2(random.Next(0, 800) ,random.Next(100,480));
            axis.acceleration = (decimal)0.4;
            axis.negX = Keys.A;
            axis.negY = Keys.W;
            axis.posX = Keys.D;
            axis.posY = Keys.S;

            //set sources and colors for timer and distance
            timer.Source = new Rectangle(0, 0, 256, 32);
            distance.Source = new Rectangle(0, 0, 256, 32);
            timer.FillColor = Color.Red;
            distance.FillColor = Color.Green;
            distance.Color = Color.Black;
            timer.Color = Color.Black;

            //set initial values for value
            speed = 3f;
            distance.width = 0;
            win = false;
            lose = false;


            
        }


        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            spriteSheet = new AnimatedSprite(Content.Load<Texture2D>("explorer"));
            timer = new ProgressBar(Content.Load<Texture2D>("explorer"));
            distance = new ProgressBar(Content.Load<Texture2D>("explorer"));
            bomb = new Sprite(Content.Load<Texture2D>("Cloud"));
            font = Content.Load<SpriteFont>("Font");



        }


        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }


        protected override void Update(GameTime gameTime)
        {
            bomb.Update();
            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            x = random.Next(100, 400);
            y = random.Next(100, 300);
            /*
            if((bomb.Position-spriteSheet.Position).Length() < 25)
            {
                bomb.Position = new Vector2(random.Next(300, 600), random.Next(100,300));
                
            }
            */
            /*
            if (( spriteSheet.Position– bomb.Position).Length() < 50)
            {
                timeBar.Value += < some value >;
                bonus.Position = new Vector2(< provide random x, y >);
            }
            */
            if((spriteSheet.Position - bomb.Position).Length() <70f)
            {
                if (timer.width < 128)
                    timer.width += 128;
                if (timer.width >= 128)
                    timer.width = 256;
                
                timer.Update();
                bomb.Position = new Vector2(x,y);
                bomb.Update();
            }
            //Console.WriteLine((spriteSheet.Position - bomb.Position).Length());
            //Console.WriteLine(Vector2.Distance(spriteSheet.Position, bomb.Position));
            //Console.WriteLine("Sheet" +spriteSheet.Position);
            //Console.WriteLine(timer.width);

            spriteSheet.Update();
            if(timer.width> 0)
                timer.width -= 1;


            //old movement controls
            InputManager.Update();
            /*
            if (InputManager.IsKeyDown(Keys.Left))
            {
                spriteSheet.Position += new Vector2(-4,0);
                spriteSheet.dir = 2;
                distance.width += 1;
            }
            if (InputManager.IsKeyDown(Keys.Right))
            {
                spriteSheet.Position += new Vector2(4, 0);
                spriteSheet.dir = 3;
                distance.width += 1;
            }
            if (InputManager.IsKeyDown(Keys.Up))
            {
                spriteSheet.Position += new Vector2(0, -4);
                spriteSheet.dir = 0;
                distance.width += 1;
            }
            if (InputManager.IsKeyDown(Keys.Down))
            {
                spriteSheet.Position += new Vector2(0, 4);
                spriteSheet.dir = 1;
                distance.width += 1;
            }
            */

            //updated movementcontrols using axis

            
            spriteSheet.Position += new Vector2((float)axis.x, (float)axis.y)*speed;


            
            

            

            if (InputManager.IsKeyDown(Keys.A))
            {
                spriteSheet.dir = 2;
                distance.width += 1;
            }
            if (InputManager.IsKeyDown(Keys.D))
            {
            
                spriteSheet.dir = 3;
                distance.width += 1;
            }
            if (InputManager.IsKeyDown(Keys.W))
            {
                spriteSheet.dir = 0;
                distance.width += 1;
            }
            if (InputManager.IsKeyDown(Keys.S))
            {
                spriteSheet.dir = 1;
                distance.width += 1;
            }
                if (axis.x <0)
                    axis.x += (decimal)0.2;
                if (axis.x > 0  )
                    axis.x -= (decimal)0.2;
                if (axis.y <0)
                    axis.y += (decimal)0.2;
                if (axis.y > 0)
                    axis.y -= (decimal)0.2;
            

            




            Console.WriteLine(axis.y);
            Console.WriteLine(axis.x);
            axis.Update();

            if (timer.width == 0)
                lose = true;
            if (distance.width == 256)
                win = true;



            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);


            

            spriteBatch.Begin();
            if (lose == true)
                spriteBatch.DrawString(font, "YOU LOSE", new Vector2(50, 150), Color.Black);
            if (win == true)
                spriteBatch.DrawString(font, "YOU WIN", new Vector2(50, 150), Color.Black);
            spriteSheet.Draw(spriteBatch);
            timer.Draw(spriteBatch);
            distance.Draw(spriteBatch);
            bomb.Draw(spriteBatch);
            spriteBatch.End();
            

            base.Draw(gameTime);
        }
    }
}
