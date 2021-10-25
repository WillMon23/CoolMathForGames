using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;

namespace CoolMathForGames
{
    class CircleCollider : Collider
    {
        private float _collisionRadius;

        public float CollisionRadius { get { return _collisionRadius; } set { _collisionRadius = value; } }
        public CircleCollider(float colldionRadius, Actor owner) : base(owner, ColliderType.CIRCLE)
        {
            _collisionRadius = colldionRadius;
        }

        public override bool CheckCollisionCircle(CircleCollider other)
        {
            if (other.Owner == Owner)
                return false;

            float distance = Vector2.Distance(other.Owner.Posistion, Owner.Posistion);

            float combinedRadii = other.CollisionRadius + CollisionRadius;

            return distance <= combinedRadii;
        }


    }
}
