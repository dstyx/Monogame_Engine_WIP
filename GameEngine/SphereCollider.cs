﻿using Microsoft.Xna.Framework;


namespace CPI311.GameEngine
{
    public class SphereCollider :Collider
    {
        public float Radius { get; set; }

        public override bool Collides(Collider other, out Vector3 normal)
        {
            if (other is SphereCollider)
            {
                SphereCollider collider = other as SphereCollider;
                if ((Transform.Position - collider.Transform.Position).LengthSquared()
                < System.Math.Pow(Radius + collider.Radius, 2))
                {
                    normal = Vector3.Normalize
                        (Transform.Position - collider.Transform.Position);
                    return true;
                }
            }
            else if (other is BoxCollider) return other.Collides(this, out normal);

            return base.Collides(other, out normal);
        }

    }
}
