using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;

namespace CoolMathForGames
{
    class Actor
    {
        private char _icon;
        private string _name;
        private Vector2 _position;

        public Vector2 Posistion { get { return _position; } set { _position = value; } }
        

        public Actor(char icon, Vector2 position, string name = "Actor")
        {
            _icon = icon; 
            _name = name;
            _position = position;
        }
        public virtual void Start()
        {

        }

        public virtual void Update()
        {
            _position.X = Posistion.X + 1;
        }

        public virtual void Draw()
        {
            Console.SetCursorPosition((int)Posistion.X, (int)Posistion.Y);
            Console.Write(_icon);
        }

        public virtual void End()
        {

        }


    }
}
