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
        private List<(ICommand, int)> mouseMappings;
        private MouseState currentMouseState;
        private MouseState previousMouseState;
        public MouseController()
        {
            mouseMappings = new List<(ICommand, int)>();
        }

        private static readonly MouseController instance = new MouseController();
        public static MouseController GetInstance
        {
            get
            {
                return instance;
            }
        }

        public void RegisterCommand(ICommand command, int button)
        {
            if (!mouseMappings.Contains((command, button)))
            {
                mouseMappings.Add((command, button));
            }
        }

        public void Update(GameTime gametime)
        {
        
            previousMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();
            foreach (var mappedState in mouseMappings)
            {

                if (mappedState.Item2 == 0)
                {
                    // check previous state to run only once on button press
                    if (currentMouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released)
                    {
                        mappedState.Item1.Execute();
                    }

                }
                if (mappedState.Item2 == 1)
                {
                    // check previous state to run only once on button press
                    if (currentMouseState.RightButton == ButtonState.Pressed && previousMouseState.RightButton == ButtonState.Released)
                    {
                        mappedState.Item1.Execute();
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

