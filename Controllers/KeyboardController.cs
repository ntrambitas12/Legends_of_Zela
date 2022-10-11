using CSE3902Project.Commands;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public sealed class KeyboardController: IController
    {
    private Dictionary<Keys, ICommand> controllerMappings;
    private List<(List<Keys> keys, ICommand still)> sprites;

    private KeyboardState currentKeyState;
    private KeyboardState previousKeyState;
    private KeyboardController()
    {
        controllerMappings = new Dictionary<Keys, ICommand>();
        sprites = new List<(List<Keys> keys, ICommand still)> ();
    }
    private static readonly KeyboardController instance = new KeyboardController();
    public static KeyboardController GetInstance
    {
        get
        {
            return instance;
        }
    }

    public void RegisterCommand(Keys key, ICommand command)
    {
        // make sure the same key does not get added!
        if (!controllerMappings.ContainsKey(key))
        {
            controllerMappings.Add(key, command);
        }
    }

    /*
     This method is needed to be able to switch back to the still state
    whenever the keys that control the user playable sprite are released
     */
    public void AddPlayableSprite (ISprite sprite, List<Keys> spriteKeys)
    {
        sprites.Add((spriteKeys, new StillSprite(sprite)));
    }
    public void Update(GameTime gameTime)
    {
        previousKeyState = currentKeyState;
        currentKeyState = Keyboard.GetState();
        
        //reset link to still state
        spriteReset();

        Keys[] pressedKeys = currentKeyState.GetPressedKeys();
       

        foreach (Keys key in pressedKeys)
        {

            if (controllerMappings.ContainsKey(key))
            { 
                    //make sure to check previous state to run only once on key press
                    if (currentKeyState.IsKeyDown(key) && !previousKeyState.IsKeyDown(key))
                    {
                        controllerMappings[key].Execute();
                    }  
            }
        }
    }

    public void Draw()
    {
        //not implemented
    }

    public void resetController()
    {
        controllerMappings.Clear();
        sprites.Clear();
    }

    private void spriteReset()
    {
        foreach (var sprite in sprites)
        {
            foreach(var key in sprite.keys)
            if (previousKeyState.IsKeyUp(key) != currentKeyState.IsKeyUp(key)) {
                    sprite.still.Execute();
            }
        }
    }
}

