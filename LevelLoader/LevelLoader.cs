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
    private XmlReader reader;
    private List<(string, string)> parseTypes;
    private delegate ISprite ConcreteEntities(Vector2 pos);
    private delegate ISprite Projectiles(int distance, ISprite owner);
    private delegate ISprite Doors(Vector2 pos, bool isOpen);
    private bool runOnce;


    private Dictionary<String, Delegate> constructer;
    private RoomObject room;
    private IRoomObjectManager roomObjectManager;

    private InitalizeControllers initalizeControllers;
  
    private ISprite Link;
    private Game1 game1;
    private ISprite sprite;
  

    public LevelLoader(IRoomObjectManager roomObjectManager, Game1 game1)
    {
        
        constructer = new Dictionary<String, Delegate>();
        initalizeControllers = new InitalizeControllers(game1);

        
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
       // constructer.Add("Barrier", new ConcreteEntities(SpriteFactory.Instance.CreateBarrierTile));
      //  constructer.Add("Stairs", new ConcreteEntities(SpriteFactory.Instance.CreateDungeonStairsTile));
       constructer.Add("Water", new ConcreteEntities(SpriteFactory.Instance.CreateWaterBlock));
        constructer.Add("Compass", new ConcreteEntities(SpriteFactory.Instance.CreateCompassDrop));
        constructer.Add("Map", new ConcreteEntities(SpriteFactory.Instance.CreateMapDrop));
        constructer.Add("HeartContainer", new ConcreteEntities(SpriteFactory.Instance.CreateHeartDrop));
        constructer.Add("Key", new ConcreteEntities(SpriteFactory.Instance.CreateKeyDrop));
        constructer.Add("Boomerang", new Projectiles(SpriteFactory.Instance.CreateBoomerangProjectile));
        constructer.Add("RightDoor", new Doors(SpriteFactory.Instance.CreateDoorRightBlock));





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
        // Create projectiles
        IProjectile Arrow = (IProjectile) SpriteFactory.Instance.CreateArrowProjectile(60, Link);
        IProjectile Bomb = (IProjectile)SpriteFactory.Instance.CreateBombProjectile(100, Link);
        IProjectile Boomerang = (IProjectile)SpriteFactory.Instance.CreateBoomerangProjectile(100, Link);
        IProjectile Fire = (IProjectile)SpriteFactory.Instance.CreateFireProjectile(50, Link);

        // Add projectiles to Link
        ((ConcreteSprite)Link).AddProjectile(Arrow, ArrayIndex.arrow);
        ((ConcreteSprite)Link).AddProjectile(Bomb, ArrayIndex.bomb);
        ((ConcreteSprite)Link).AddProjectile(Boomerang, ArrayIndex.boomerang);
        ((ConcreteSprite)Link).AddProjectile(Fire, ArrayIndex.fire);
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
           
            room.AddController(initalizeControllers.InitalizeKeyboard(Link));
            int xPos;
            int yPos;
            String name;
            int roomObjectType;
            bool read = false;
            bool isDoor = false;
            bool isDoorOpen = false;

            //Projectile variables
            String projectile = null;
            int projDistance = 0;
            int projType = 0;

            foreach (var parseType in parseTypes)
            {
                reader.ReadToFollowing(parseType.Item1);
                read = reader.ReadToDescendant(parseType.Item2);
               

                if (read)
                {
                    do
                    {
                        if (reader.MoveToAttribute("isOpen"))
                        {
                            isDoor = true;
                            isDoorOpen = reader.ReadContentAsBoolean();
                        }
                        reader.ReadToFollowing("xPos");
                        xPos = reader.ReadElementContentAsInt();
                        reader.ReadToNextSibling("yPos");
                        yPos = reader.ReadElementContentAsInt();
                        reader.ReadToNextSibling("Name");
                        name = reader.ReadElementContentAsString();
                        reader.ReadToNextSibling("RoomObjectType");
                        roomObjectType = reader.ReadElementContentAsInt();
                        if (reader.ReadToNextSibling("Projectile"))
                        {
                            reader.ReadToDescendant("Name");
                            projectile = reader.ReadElementContentAsString();
                            reader.ReadToNextSibling("Distance");
                            projDistance = reader.ReadElementContentAsInt();
                            reader.ReadToNextSibling("RoomObjectType");
                            projType = reader.ReadElementContentAsInt();
                            reader.Read();
                            reader.Read();
                            reader.Read();
                        }


                        /* This is where you call the corresponding method from spritefactory
                         * and add that ISprite to the roomobject into correct list using add
                         */
                        if (isDoor)
                        {
                            if(constructer.TryGetValue(name, out Delegate doorConstructor))
                            {
                                sprite = (ISprite)doorConstructor.DynamicInvoke(new Vector2(xPos, yPos), isDoorOpen);
                            }

                            isDoor = false;
                        }
                        else { 
                        if (constructer.TryGetValue(name, out Delegate value))
                        {
                             sprite = (ISprite)value.DynamicInvoke(new Vector2(xPos, yPos));

                            //case for when we have to pair projectile with parent sprite
                            //check if projectile is not null
                            if (projectile != null && sprite != null)
                            {
                                //now we want to create the projectile from the factory
                                if (constructer.TryGetValue(projectile, out Delegate projectileDel))
                                {
                                    ISprite concreteProj = (ISprite)projectileDel.DynamicInvoke(projDistance, sprite);
                                    //add the projectile created to the room
                                    room.AddGameObject(projType, concreteProj);
                                    //reset projectile read in as null since we've added it to the room
                                    projectile = null;
                                }

                                 }
                            
                             }
                           
                        }
                        room.AddGameObject(roomObjectType, sprite);
                    }
                    while (reader.ReadToNextSibling(parseType.Item2));
                }
            }

            //Build the Room
            roomObjectManager.addRoom(room);
            runOnce = true;
        }
    }
}