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
        private Sprite _sprite;

        

        /// <summary>
        /// True if the start function has been called for this actor
        /// </summary>
        public bool Started { get { return _started; } }

        public string Name { get { return _name; } }

        public Vector2 Forward { get { return _froward; } set { _froward = value; } }

        public Vector2 Position { get { return new Vector2(_transform.M02, _transform.M12); } 
                                   set { _transform.M02 = value.X; _transform.M12 = value.Y; } }

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
           
        }

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

        public virtual void OnCollision( Actor actor)
        {
            Engine.CloseApplication();
        }

        public void SetScale(float x, float y)
        {
            _transform.M00 = x;
            _transform.M11 = y;
        }


    }
}
