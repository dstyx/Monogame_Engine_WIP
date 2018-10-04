using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CPI311.GameEngine
{
    public class AnimatedSprite :Sprite
    {
        public int Frames { get; set; }
        public float Frame { get; set; }
        public float Speed { get; set; }
        public int dir;
        private int frame;


        public AnimatedSprite(Texture2D texture, int frames = 1):base(texture)
        {
            Frames = frames;
            Frame = 0;
            Speed = 1;
            dir = 0;
        }

        public override void Update()
        {
            frame += 1;
            if (frame > 7)
                frame = 0;

            Source = new Rectangle(frame*32, dir*32, 32, 32);
        }

    }
}
