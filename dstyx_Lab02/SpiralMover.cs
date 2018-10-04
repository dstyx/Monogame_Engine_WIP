using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using CPI311.GameEngine;


namespace dstyx_Lab02
{
    public class SpiralMover
    {

        Sprite sprite;
        Vector2 Position;

        float Phase, Radius, Frequency, Amplitude, Speed;

        public SpiralMover()
        {
            Texture2D texture;
            Position = new Vector2(400, 200);
            Radius = 150;
            Speed = 0.01f;
            Frequency = 20;
            Amplitude = 10;
            Phase = 0;

        }


        public void AnimateSpiral(float radius, float time, float speed = 1f)
        {




        }


    }







}