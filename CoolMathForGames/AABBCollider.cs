using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;

namespace CoolMathForGames
{
    class AABBCollider : Collider
    {
        private float _width;
        private float _height;

        public float Width { get { return _width; } set { _width = value; } }

        public float Height { get { return _height; } set { _height = value; } }


        public float Left { get { return -(Height / 2) ; } }

        public float Right { get { return (Height / 2); } }

        public float Top { get { return -(Width / 2); } }

        public float Bottom { get { return (Width / 2); } }
    }


}
