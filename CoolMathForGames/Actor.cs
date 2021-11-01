using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace CoolMathForGames
{
    class Actor
    {
        private string _name;
        private bool _started;
        private Vector2 _froward = new Vector2(1, 0);
        private Collider _collider;
        private Matrix3 _transform = Matrix3.Identity;
        private Matrix3 _translation = Matrix3.Identity;
        private Matrix3 _rotation = Matrix3.Identity;
        private Matrix3 _scale = Matrix3.Identity;
        private Sprite _sprite;

        

        /// <summary>
        /// True if the start function has been called for this actor
        /// </summary>
        public bool Started { get { return _started; } }

        public string Name { get { return _name; } }

        public Vector2 Forward { get { return new Vector2(_rotation.M00, _rotation.M11); } set {
                Vector2 point = value.Normalzed + Position;
                LookAt(point);
            } }

        public Vector2 Position { get { return new Vector2(_transform.M02, _transform.M12); } 
                                   set { SetTranslation(value.X, value.Y); } }

        public Vector2 Size { get { return new Vector2(_scale.M00, _scale.M11); } set { SetScale(value.X, value.Y); } }

        public Collider Collider { get { return _collider; } set { _collider = value; } }

        public Sprite Sprite { get { return _sprite; } set { _sprite = value; } }

        public Actor(Vector2 position, string name = "Actor", string path = "")
        {
            _name = name;
            Position = position;
            if(path != "")
                _sprite = new Sprite(path);
        }

        public Actor( float x, float y,  string name = "Actor", string path = "") :
            this (new Vector2 { X = x, Y = y }, name, path){ }

        public virtual void Start()
        {
            _started = true;
        }

        public virtual void Update(float deltaTime)
        {
            _transform = _translation * _rotation * _scale;
        }

        /// <summary>
        /// Draws Out To The Consoole
        /// </summary>
        public virtual void Draw()
        {
            if (_sprite != null)
                _sprite.Draw(_transform);
            Collider.Draw();
            //Raylib.DrawCircleLines((int)Position.X, (int)Position.Y, 20, Color.LIME);
        }

        public virtual void End()
        {

        }

        /// <summary>
        /// Checks if this actor collides with another 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public virtual bool CheckForCollision(Actor other)
        {
            if (Collider == null || other.Collider == null)
                return false;

            return Collider.CheckCollision(other);
        }

        /// <summary>
        /// Applies the given values to the current translation
        /// </summary>
        /// <param name="transkationX">The amount to move on the x</param>
        /// <param name="translationY">The amount to move on the y</param>
        public void SetTranslation(float transkationX, float translationY)
        {
            _translation = Matrix3.CreateTranslation(transkationX,translationY);
        }

        public void Translate(float translationX, float translationY)
        {
            _translation *= Matrix3.CreateTranslation(translationX, translationY);
        }

        public void SetRoation(float radians)
        {
            _rotation = Matrix3.CreateRotation(radians);
        }
        public void Rotate(float radians)
        {
            _rotation *= Matrix3.CreateRotation(radians);
        } 

        public virtual void OnCollision( Actor actor)
        {
            Engine.CloseApplication();
        }

        public void SetScale(float x, float y)
        {
            _scale = Matrix3.CreateScale(x, y);

        }

        /// <summary>
        /// Scales the actor by the 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Scale(float x,float y)
        {
            _scale *= Matrix3.CreateScale(x, y);
        }
        
        /// <summary>
        /// Rotates the actor at any given postion
        /// </summary>
        /// <param name="position"></param>
        public void LookAt(Vector2 position)
        {
            //Find the direction the actor should look in
            Vector2 direction = (position - Position).Normalzed;

            //Use the dot product to find the andle the actor needs to rotate 
            float dotProd = Vector2.DotProduct(direction, Forward);

            if (dotProd > 1)
                dotProd = 1;

            float angle = (float)Math.Acos(dotProd);

            //Perpendiculer Direction
            //Finds perpindicular vector to the direction
            Vector2 perpDirection = new Vector2(-direction.Y, direction.X);

            //Perpendicular Dot-Product 
            //Find the dot product of the perpindicular vector and current forward
            float perpDot = Vector2.DotProduct(perpDirection, Forward);

            //If the result isn't 0, use it to change the sign of the angle to be either positiove or negative
            if (perpDot != 0)
                angle *= -perpDot / Math.Abs(perpDot);

            Rotate(angle);
        }

    }
}
