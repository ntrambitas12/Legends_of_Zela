using CSE3902Project;
using CSE3902Project.Commands;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

public class LevelLoader
{
    public XmlReader reader;
    public XmlReaderSettings settings;
    private List<(string, string)> parseTypes;
    private delegate ISprite ConcreteEntities(Vector2 pos);
    private bool runOnce;


    private Dictionary<String, Delegate> constructer;
    private RoomObject room;
    private IRoomObjectManager roomObjectManager;

    //Things needed for keyboard controller
    private List<Keys> linkKeys;
    private KeyboardController keyboard;
    private ISprite Link;
    private Game1 game1;
  

    public LevelLoader(IRoomObjectManager roomObjectManager, Game1 game1)
    {
        settings = new XmlReaderSettings();
        constructer = new Dictionary<String, Delegate>();
        linkKeys = new List<Keys>();
        settings.IgnoreWhitespace = true;

        
        parseTypes = new List<(string, string)>()
        {
            ("Blocks", "Block"),
            ("Enemies", "Enemy"),
            ("Items", "Item"),
        };

        populateDictionary();
        this.roomObjectManager = roomObjectManager;
        this.game1 = game1;
        runOnce = false;
        
    }

    private void populateDictionary()
    {
        constructer.Add("Goriya", new ConcreteEntities(SpriteFactory.Instance.CreateGoriyaSprite));
        //constructer.Add("Keese", new ConcreteEntities(SpriteFactory.Instance.CreateKeeseSprite));
        //constructer.Add("Stalfos", new ConcreteEntities(SpriteFactory.Instance.CreateStalfosSprite));
       // constructer.Add("Gel", new ConcreteEntities(SpriteFactory.Instance.CreateGelSprite));
       // constructer.Add("Aquamentus", new ConcreteEntities(SpriteFactory.Instance.CreateAquamentusSprite));
       // constructer.Add("BladeTraps", new ConcreteEntities(SpriteFactory.Instance.CreateBladeTrapsSprite));
        //constructer.Add("Wallmaster", new ConcreteEntities(SpriteFactory.Instance.CreateWallmasterSprite));
        constructer.Add("Barrier", new ConcreteEntities(SpriteFactory.Instance.CreateBarrierTile));
        constructer.Add("Stairs", new ConcreteEntities(SpriteFactory.Instance.CreateDungeonStairsTile));
        constructer.Add("Water", new ConcreteEntities(SpriteFactory.Instance.CreateWaterTile));
        constructer.Add("Compass", new ConcreteEntities(SpriteFactory.Instance.CreateCompassItem));
        constructer.Add("Map", new ConcreteEntities(SpriteFactory.Instance.CreateMapItem));
        constructer.Add("HeartContainer", new ConcreteEntities(SpriteFactory.Instance.CreateHeartItem));
        constructer.Add("Key", new ConcreteEntities(SpriteFactory.Instance.CreateKeyItem));





    }

    private void CreateLink()
    {
        /*
         * Link only needs to be created once.
         * Add him to the starting room only.
         * Colisions will be responsible for moving him between rooms.
         */

        Link = SpriteFactory.Instance.CreateLinkSprite(new Vector2(120, 120));
        room.Link = Link;
    }
    private void CreateKeyboard()
    {
       keyboard = KeyboardController.GetInstance;

        ConfigureKeyboardKeys(game1);

        // Add link with his keys to playable sprite
        keyboard.AddPlayableSprite(Link, linkKeys);

        //Add keyboard to !!ALL!! rooms read in
        room.AddController(keyboard);
    }

    private void ConfigureKeyboardKeys(Game1 game1)
    {
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

        // Add restart and exit commands to keyboard
        keyboard.RegisterCommand(Keys.Q, new ExitCommand(game1));
        
        //doesnt work, needs refactoring
        //keyboard.RegisterCommand(Keys.R, new RestartCommand(game1));
    }
    public void ParseRoom()
    {
        var files = Directory.GetFiles(@"Rooms/", "*.xml");
        
        foreach (var file in files)
        {
            reader = XmlReader.Create(file);
            room = new RoomObject();

            if (!runOnce)
            {
                CreateLink();
            }
            CreateKeyboard();
            int xPos;
            int yPos;
            String name;
            int roomObjectType;
            bool read = false;

            foreach (var parseType in parseTypes)
            {
                reader.ReadToFollowing(parseType.Item1);
                read = reader.ReadToDescendant(parseType.Item2);

                if (read)
                {
                    do
                    {
                        reader.ReadToDescendant("xPos");
                        xPos = reader.ReadElementContentAsInt();
                        reader.ReadToNextSibling("yPos");
                        yPos = reader.ReadElementContentAsInt();
                        reader.ReadToNextSibling("Name");
                        name = reader.ReadElementContentAsString();
                        reader.ReadToNextSibling("RoomObjectType");
                        roomObjectType = reader.ReadElementContentAsInt();
                        reader.Read();

                        /* This is where you call the corresponding method from spritefactory
                         * and add that ISprite to the roomobject into correct list using add
                         */
                        if (constructer.TryGetValue(name, out Delegate value))
                        {
                            ISprite sprite = (ISprite)value.DynamicInvoke(new Vector2(xPos, yPos));
                            room.AddGameObject(roomObjectType, sprite);

                        }

                    }
                    while (reader.ReadToNextSibling(parseType.Item2));
                }
            }

            //Build the Room
            BuildRoom();
            runOnce = true;
        }
    }

    private void BuildRoom()
    {
        roomObjectManager.addRoom(room);
    }
}