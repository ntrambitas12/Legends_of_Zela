using CSE3902Project.Commands;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public sealed class MouseController : IController
    {
        private Dictionary<int, ICommand> mouseMappings;
        private MouseState currentMouseState;
        private MouseState previousMouseState;
        public MouseController()
        {
            mouseMappings = new Dictionary<int, ICommand>();
        }

        private static readonly MouseController instance = new MouseController();
        public static MouseController GetInstance
        {
            get
            {
                return instance;
            }
        }

        public void RegisterCommand(int button, ICommand command)
        {
            if (!mouseMappings.ContainsKey(button))
            {
                mouseMappings.Add(button, command);
            }
        }

        public void Update(GameTime gametime)
        {
        
        previousMouseState = currentMouseState;
            MouseState state = Mouse.GetState();
            foreach (var mappedState in mouseMappings)
            {

             if (mouseMappings.ContainsKey(mappedState.Key))
             {
            //make sure to check previous state to run only once on key press
             if (currentMouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released)
            {
            mouseMappings[0].Execute();
             }
            if (currentMouseState.RightButton == ButtonState.Pressed && previousMouseState.RightButton == ButtonState.Released)
                    {
                      mouseMappings[1].Execute();
                    }
               }
            }
        }

        public void Draw(GameTime gameTime)
        {
            //not implemented
        }

        public void resetController()
        {
            mouseMappings.Clear();
        }
    }

