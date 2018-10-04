using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;



namespace CPI311.GameEngine
{

    public class Axis
    {
        public decimal x, y, z, acceleration;
        public int ix, iy, iz;
        public Keys negX, negY, posX, posY, posZ, negZ; 
        
        public Axis()
        {
            x = 0;
            y = 0;
            z = 0;
            ix = 0;
            iy = 0;
            iz = 0;
            acceleration = 0;
            

        }

        //update methods
        public virtual void Update()
        {
            if (InputManager.IsKeyDown(negX))
            {
                if (x > -1)
                {
                    x -= acceleration;
                }
            }

            if (InputManager.IsKeyDown(negY))
            {
                if (y > -1)
                {
                    y -= acceleration;
                }
            }

            if (InputManager.IsKeyDown(posX))
            {
                if (x < 1)
                {
                    x += acceleration;
                }
            }

            if (InputManager.IsKeyDown(posY))
            {
                if (y < 1)
                {
                    y += acceleration;
                }
            }
        }


        //to give a percentage if unable to give float
        public int XCallInt()
        {
            return (int)x * 100;
        }

        public int YCallInt()
        {
            return (int)y * 100;
        }




    }

}
