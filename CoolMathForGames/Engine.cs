﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CoolMathForGames
{
    class Engine
    {

        private static bool _applicationShouldClose = false;
        private static int _currentSceneIndex;
        private Scene[] _scenes = new Scene[0];
        private Actor _actor;

        /// <summary>
        /// Called to begin the application 
        /// </summary>
       public void Run()
        {
            // Call start for the entire application 
            Start();

            // Loop until the application is told to close
            while(!_applicationShouldClose)
            {
                Draw();
                Update();
            }
            // Called end for the entire application
            End();
        }

        /// <summary>
        /// Called when application starts 
        /// </summary>
        private void Start()
        {
            _actor = new Actor('P', new MathLibrary.Vector2 { X = 0, Y = 0 });
            _scenes[_currentSceneIndex].Update();
        }

        /// <summary>
        /// Called to draw to the scene 
        /// </summary>
        private void Draw()
        {
            _scenes[_currentSceneIndex].Draw();
        }

        /// <summary>
        /// Updates the application and notifies the console of any changes 
        /// </summary>
        private void Update()
        {
            _scenes[_currentSceneIndex].Update();
        }

        /// <summary>
        /// Called once the game has been set to game over 
        /// </summary>
        private void End()
        {
            _scenes[_currentSceneIndex].End();
        }

        /// <summary>
        /// Created to append new scnene to the current listing of scene 
        /// </summary>
        /// <param name="scene">Scene being added to the current list of scens</param>
        /// <returns>returns the new ammount of scenes</returns>
        public int AddScene(Scene scene)
        {
            // Creats a Temporary array 
            Scene[] tempArray = new Scene[_scenes.Length + 1];

            //Copys all the values from old array info to the temp array
            for (int i = 0; i < _scenes.Length; i++)
                tempArray[i] = _scenes[i];
            //Sets adds the new scene to the new size
            tempArray[_scenes.Length] = scene;
            // Set the old array to the new array
            _scenes = tempArray;
            // returns the new allocated size
            return _scenes.Length - 1;
        }
    }
}
