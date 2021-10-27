﻿using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

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

            float distance = Vector2.Distance(other.Owner.Position, Owner.Position);

            float combinedRadii = other.CollisionRadius + CollisionRadius;

            return distance <= combinedRadii;
        }

        public override bool CheckCollisionAABB(AABBCollider other)
        {

            if (other.Owner == Owner)
                return false;
            //Get the direction from this collider to the AABB
            Vector2 direction = Owner.Position - other.Owner.Position;

            //Clamp the direction vector to be within the bounds of the AABB
            direction.X = Math.Clamp(direction.X, -other.Width / 2, other.Width / 2);
            direction.Y = Math.Clamp(direction.Y, -other.Height / 2, other.Height / 2);

            //Add the direction vector to the AABB center to get closet point to the circle
            Vector2 closetsPoint = other.Owner.Position + direction;

            //Find the distance from the circle's center to the closest point
            float distanceFromClosestPoint = Vector2.Distance(Owner.Position, closetsPoint);

            //Return whether or not distance is less than the circle's radius
            return distanceFromClosestPoint <= CollisionRadius;
        }

        public override void Draw()
        {
            Raylib.DrawCircleLines((int)Owner.Position.X,(int)Owner.Position.Y,CollisionRadius,Color.PINK);
        }




    }
}
