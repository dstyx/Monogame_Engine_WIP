using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace CPI311.GameEngine
{
    public class ProgressBar : Sprite
    {
        public Color FillColor { get; set; }
        public float Value { get; set; }

        public int width;

        public ProgressBar(Texture2D texture, float value = 1):base(texture)
        {
            Value = value;
            FillColor = Color.White;
            width = texture.Width;
        }


        public override void Update()
        {
            if (Value > 1)
                Value = 1;
            if (Value < 0)
                Value = 0;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch); // let the sprite do its work
            spriteBatch.Draw(Texture, Position, new Rectangle(0,0,width, 32),
             FillColor, Rotation, Origin, Scale, Effects, Layer);
        }
    }

    
}
