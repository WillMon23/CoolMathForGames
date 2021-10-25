﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CoolMathForGames
{
    enum ColliderType
    {
        CIRCLE,
        AABB
    }
    class Collider 
    {
        private Actor _owner;
        private ColliderType _colliderType;

        public ColliderType ColliderType { get { return _colliderType; } }

        public Actor Owner { get { return _owner; } set { _owner = value; } }


        public Collider(Actor owner,ColliderType colliderType)
        {
            _owner = owner;
            _colliderType = ColliderType;
        }

        public bool CheckCollision(Actor other)
        {

            return false;
        }
    }
}
