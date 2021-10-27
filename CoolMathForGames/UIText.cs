using System;
using System.Collections.Generic;
using System.Text;
using Raylib_cs;

namespace CoolMathForGames
{
    class UIText : Actor
    {

        private string _text;
        private int _width;
        private int _height;

        /// <summary>
        /// Text being utalized 
        /// </summary>
        public string Text { get { return _text; } set { _text = value; } }

        public int Width { get { return _width; } set { _width = value; } }

        public int Height { get { return _height; } set { _height = value; } }



        public UIText(float x, float y, string name, Color color, int width, int height, int fontSize, string text = "")
            : base( x, y, color, name, "")
        {
            _text = text;
            _width = width;
            _height = height;
            _

        }

        public override void Draw()
        {
            int cursorPosX = (int)Position.X;

            int cursorPosY = (int)Position.Y;


            //Converts the string for the text into a charactor array 
            char[] textChars = Text.ToCharArray();

            //Iterate through all charactors in the string 
            for (int i = 0; i < textChars.Length; i++)
            {
                //Set the icon symbol 
                currentLetter.Symbol = textChars[i];

                if (currentLetter.Symbol == '\n')
                {
                    cursorPosX = (int)Position.X;
                    cursorPosY++;
                    continue;
                }

                //Add the current charactor to the bugger
                //Engine.Render(currentLetter, new MathLibrary.Vector2 { X = cursorPosX, Y = cursorPosY });

                //Increment the cursor postion so the letters are set side by side
                cursorPosX++;

                //Go to rhe next line if the cursor has reached the max position
                if (cursorPosX > (int)Position.X + Width)
                {
                    //Reset the cursor x position and the increase the y position
                    cursorPosX = (int)Position.X;
                    cursorPosY++;
                }
                //If the cursor has reached the maximum height. . . 
                if (cursorPosY > (int)Position.Y + Height)
                    //. . . Leave the loop
                    break;
            }
        }

    }
}
