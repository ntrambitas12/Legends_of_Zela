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
    private KeyboardState currentKeyState;
    private KeyboardState previousKeyState;
    private ICommand spriteStill;
    private List<Keys> spriteKeys;
    private KeyboardController()
    {
        controllerMappings = new Dictionary<Keys, ICommand>();
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
        spriteStill = new LinkStill(sprite);
        this.spriteKeys = spriteKeys;
    }
    public void Update()
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
        spriteKeys.Clear();
    }

    private void spriteReset()
    {
        foreach (Keys key in spriteKeys)
        {
            if (previousKeyState.IsKeyUp(key) != currentKeyState.IsKeyUp(key)) {
                spriteStill.Execute();
            }
        }
    }
}

