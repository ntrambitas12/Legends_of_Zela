using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public sealed class KeyboardController: IController
    {
    private Dictionary<Keys, (ICommand, bool)> controllerMappings;
    private KeyboardState currentKeyState;
    private KeyboardState previousKeyState;

    private KeyboardController()
    {
        controllerMappings = new Dictionary<Keys, (ICommand, bool)>();
    }
    private static readonly KeyboardController instance = new KeyboardController();
    public static KeyboardController GetInstance
    {
        get
        {
            return instance;
        }
    }

    public void RegisterCommand(Keys key, ICommand command, bool runOnce)
    {
        // make sure the same key does not get added!
        if (!controllerMappings.ContainsKey(key))
        {
            controllerMappings.Add(key, (command, runOnce));
        }
    }

    public void Update()
    {
        previousKeyState = currentKeyState;
        currentKeyState = Keyboard.GetState();

        Keys[] pressedKeys = currentKeyState.GetPressedKeys();

        foreach (Keys key in pressedKeys)
        {

        
            if (controllerMappings.ContainsKey(key))
            { //if runOnce is false
                if (!controllerMappings[key].Item2) {
                    controllerMappings[key].Item1.Execute();
                }

                //if runOnce is true
                else
                {
                    //make sure to check previous state to run only once on key press
                    if (currentKeyState.IsKeyDown(key) && !previousKeyState.IsKeyDown(key))
                    {
                        controllerMappings[key].Item1.Execute();
                    }
                }
            }
        }
    }

    public void resetController()
    {
        controllerMappings.Clear();
    }
}

