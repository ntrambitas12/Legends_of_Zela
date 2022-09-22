using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System.Security.Cryptography.X509Certificates;

namespace CSE3902Project.Commands
{
    public class KeyLogic
    {

        // Inspired by @Luca_Carminati on the MonoGame community forum
        private KeyboardState currentKeyState;
        private KeyboardState previousKeyState;

        public KeyLogic()
        {

        }

        public KeyboardState GetState()
        {
            previousKeyState = currentKeyState;
            currentKeyState = Microsoft.Xna.Framework.Input.Keyboard.GetState();
            return currentKeyState;
        }

        public bool OneShotKeyPress(Keys key)
        { 
            //return currentKeyState.IsKeyDown(key) && !previousKeyState.IsKeyDown(key);
            return currentKeyState.IsKeyDown(key);
        }
    }
}
