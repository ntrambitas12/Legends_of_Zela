using CSE3902Project;
using CSE3902Project.Commands;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class InitalizeControllers
    {
    //Things needed for keyboard controller
    private List<Keys> linkKeys;
    private KeyboardController keyboard;
    private Game1 game1;

    //Things needed for mouse controller
    private MouseController mouse;
    private RoomObjectManager roomObjectManager;
    public InitalizeControllers(Game1 game1, RoomObjectManager roomObjectManager)
        {
         this.game1 = game1;
        this.linkKeys = new List<Keys>();
        this.roomObjectManager = roomObjectManager;
        }

    public KeyboardController InitalizeKeyboard(ISprite Link)
    {
        keyboard = KeyboardController.GetInstance;

        //Add link's keys to the list
        linkKeys.Add(Keys.Left);
        linkKeys.Add(Keys.Right);
        linkKeys.Add(Keys.Up);
        linkKeys.Add(Keys.Down);
        linkKeys.Add(Keys.W);
        linkKeys.Add(Keys.A);
        linkKeys.Add(Keys.S);
        linkKeys.Add(Keys.D);

        // Add link movements and actions to keyboard controller
        keyboard.RegisterCommand(Keys.Up, new MoveUp(Link));
        keyboard.RegisterCommand(Keys.W, new MoveUp(Link));
        keyboard.RegisterCommand(Keys.Left, new MoveLeft(Link));
        keyboard.RegisterCommand(Keys.A, new MoveLeft(Link));
        keyboard.RegisterCommand(Keys.Right, new MoveRight(Link));
        keyboard.RegisterCommand(Keys.D, new MoveRight(Link));
        keyboard.RegisterCommand(Keys.Down, new MoveDown(Link));
        keyboard.RegisterCommand(Keys.S, new MoveDown(Link));
        keyboard.RegisterCommand(Keys.E, new TakeDamage(Link));
        keyboard.RegisterCommand(Keys.Z, new Attack(Link));
        keyboard.RegisterCommand(Keys.Space, new ProjectileAttack(Link));
        keyboard.RegisterCommand(Keys.P, new SwitchProjectile(Link));

        // Add restart and exit commands to keyboard
        keyboard.RegisterCommand(Keys.Q, new ExitCommand(game1));

        //doesnt work, needs refactoring
        keyboard.RegisterCommand(Keys.R, new RestartCommand(game1));

        // Add link with his keys to playable sprite
        keyboard.AddPlayableSprite(Link, linkKeys);

        return keyboard;
        }

    public MouseController InitalizeMouse()
    {
        mouse = MouseController.GetInstance;
        mouse.resetController();
        mouse.RegisterCommand(new NextRoom(game1, roomObjectManager), 0);
        mouse.RegisterCommand(new PreviousRoom(game1, roomObjectManager), 1);
        return mouse;
        }
    }

