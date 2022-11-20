using CSE3902Project.Commands;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public sealed class KeyboardController : IController
{
    //encapsulates storing two keys 
    private class DoubleKeys {
        public Keys key1 { get; set; }
        public Keys key2 { get; set; }
        public Boolean wasPressed { get; set; }
        public DoubleKeys(Keys key1, Keys key2) {
            this.key1 = key1;
            this.key2 = key2;
            wasPressed = false;
        }
        public Boolean isPressed(Keys[] pressedKeys)
        {
            return pressedKeys.Contains(this.key1) && pressedKeys.Contains(this.key2);
        }
        public Boolean Equals(DoubleKeys keyComb)
        {
            return this.key1.Equals(keyComb.key1) && this.key2.Equals(keyComb.key2);    
        }
    }

    private Dictionary<Keys, ICommand> controllerMappings;
    private Dictionary<DoubleKeys, ICommand> controllerMappingsDoubleKeys;
    private List<(List<Keys> keys, ICommand still)> sprites;
    
    private KeyboardState currentKeyState;
    private KeyboardState previousKeyState;

    private KeyboardController()
    {
        controllerMappings = new Dictionary<Keys, ICommand>();
        sprites = new List<(List<Keys> keys, ICommand still)> ();

        controllerMappingsDoubleKeys = new Dictionary<DoubleKeys, ICommand>();
    }
    private static readonly KeyboardController instance = new KeyboardController();
    public static KeyboardController GetInstance
    {
        get
        {
            return instance;
        }
    }

    //registers single-key commands
    public void RegisterCommand(Keys key, ICommand command)
    {
        if (!controllerMappings.ContainsKey(key))
        {
            controllerMappings.Add(key, command);
        }
    }

    //registers double-key commands
    public void RegisterCommand(Keys key1, Keys key2, ICommand command)
    {
        DoubleKeys keyComb = new DoubleKeys(key1, key2);
        if (!hasCombination(keyComb))
        {
            controllerMappingsDoubleKeys.Add(keyComb, command);
        }
    }
    private Boolean hasCombination(DoubleKeys keyComb)
    {
        foreach (DoubleKeys existingKey in controllerMappingsDoubleKeys.Keys)
        {
            if (keyComb.Equals(existingKey))
            {
                return true;
            }
        }
        return false;
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
        
        Keys[] oldPressedKeys = previousKeyState.GetPressedKeys();
        foreach (Keys key in oldPressedKeys)
        {
            if (previousKeyState.IsKeyDown(key) && !currentKeyState.IsKeyDown(key))
            {
                if (key.CompareTo(Keys.W)==0.0 || key.CompareTo(Keys.Up)==0.0)
                {
                    UpdateSpritePos.GetInstance.smoothUp((ISprite)RoomObjectManager.Instance.currentRoom().Link);
                }else if (key.CompareTo(Keys.A) ==0.0|| key.CompareTo(Keys.Left)==0.0)
                {
                    UpdateSpritePos.GetInstance.smoothLeft((ISprite)RoomObjectManager.Instance.currentRoom().Link);
                }else if (key.CompareTo(Keys.S)==0.0 || key.CompareTo(Keys.Down)==0.0)
                {
                    UpdateSpritePos.GetInstance.smoothDown((ISprite)RoomObjectManager.Instance.currentRoom().Link);
                }else if (key.CompareTo(Keys.D)==0.0 || key.CompareTo(Keys.Right)==0.0)
                {
                    UpdateSpritePos.GetInstance.smoothRight((ISprite)RoomObjectManager.Instance.currentRoom().Link);
                }
            }
        }
       
        //executes single-key commands
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

        //executes double-key commands
        UpdateDoubleKeyCommands(pressedKeys);
    }

    public void Draw(GameTime gameTime)
    {
        //not implemented
    }

    public void resetController()
    {
        controllerMappings.Clear();
        controllerMappingsDoubleKeys.Clear();
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


    private void UpdateDoubleKeyCommands(Keys[] pressedKeys)
    {
        foreach (DoubleKeys keyComb in controllerMappingsDoubleKeys.Keys)
        {
            if (!keyComb.wasPressed && keyComb.isPressed(pressedKeys))
            {
                controllerMappingsDoubleKeys[keyComb].Execute();
                keyComb.wasPressed = true;
            }
            else if (keyComb.wasPressed && !keyComb.isPressed(pressedKeys))
            {
                keyComb.wasPressed = false;
            }
        }
    }

}

