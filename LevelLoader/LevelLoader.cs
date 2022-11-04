using CSE3902Project;
using CSE3902Project.Commands;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Emit;
using System.Xml;

public class LevelLoader: ILevelLoader
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
  

    public LevelLoader(Game1 game1)
    {
        
        constructer = new Dictionary<String, Delegate>();
        initalizeControllers = new InitalizeControllers(game1);
        roomObjectManager = RoomObjectManager.Instance;
        
        parseTypes = new List<(string, string)>()
        {
            ("Blocks", "Block"),
            ("Enemies", "Enemy"),
            ("Items", "Item"),
        };

        populateDictionary();
        this.game1 = game1;
        runOnce = false;
        
    }

    private void populateDictionary()
    {
        //Blocks
        constructer.Add("AlternateBackground", new ConcreteEntities(SpriteFactory.Instance.CreateAlternateBackgroundBlock));
        constructer.Add("DungeonFloor", new ConcreteEntities(SpriteFactory.Instance.CreateDungeonFloorBlock));
        constructer.Add("Barrier", new ConcreteEntities(SpriteFactory.Instance.CreateBarrierBlock));
        constructer.Add("RoughFloor", new ConcreteEntities(SpriteFactory.Instance.CreateRoughFloorBlock));
        constructer.Add("FireBlock", new ConcreteEntities(SpriteFactory.Instance.CreateFireBlock));
        constructer.Add("Stairs", new ConcreteEntities(SpriteFactory.Instance.CreateStairsBlock));
        constructer.Add("Water", new ConcreteEntities(SpriteFactory.Instance.CreateWaterBlock));
        constructer.Add("StatueRight", new ConcreteEntities(SpriteFactory.Instance.CreateStatueRightBlock));
        constructer.Add("StatueLeft", new ConcreteEntities(SpriteFactory.Instance.CreateStatueLeftBlock));
        constructer.Add("WallTop", new ConcreteEntities(SpriteFactory.Instance.CreateWallTopBlock));
        constructer.Add("WallTop1", new ConcreteEntities(SpriteFactory.Instance.CreateWallTop1Block));
        constructer.Add("WallTop2", new ConcreteEntities(SpriteFactory.Instance.CreateWallTop2Block));
        constructer.Add("WallBottom", new ConcreteEntities(SpriteFactory.Instance.CreateWallBottomBlock));
        constructer.Add("WallBottom1", new ConcreteEntities(SpriteFactory.Instance.CreateWallBottom1Block));
        constructer.Add("WallBottom2", new ConcreteEntities(SpriteFactory.Instance.CreateWallBottom2Block));
        constructer.Add("WallRight", new ConcreteEntities(SpriteFactory.Instance.CreateWallRightBlock));
        constructer.Add("WallRight1", new ConcreteEntities(SpriteFactory.Instance.CreateWallRight1Block));
        constructer.Add("WallRight2", new ConcreteEntities(SpriteFactory.Instance.CreateWallRight2Block));
        constructer.Add("WallLeft", new ConcreteEntities(SpriteFactory.Instance.CreateWallLeftBlock));
        constructer.Add("WallLeft1", new ConcreteEntities(SpriteFactory.Instance.CreateWallLeft1Block));
        constructer.Add("WallLeft2", new ConcreteEntities(SpriteFactory.Instance.CreateWallLeft2Block));
        constructer.Add("InvisibleBarrier", new ConcreteEntities(SpriteFactory.Instance.CreateInvisibleBarrierBlock));
        constructer.Add("Opening", new ConcreteEntities(SpriteFactory.Instance.CreateOpeningBlock));
        constructer.Add("Text", new ConcreteEntities(SpriteFactory.Instance.CreateTextBlock));

        //Enemies
        constructer.Add("OldMan", new ConcreteEntities(SpriteFactory.Instance.CreateOldManSprite));
        constructer.Add("Keese", new ConcreteEntities(SpriteFactory.Instance.CreateKeeseSprite));
        constructer.Add("Stalfos", new ConcreteEntities(SpriteFactory.Instance.CreateStalfosSprite));
        constructer.Add("Gel", new ConcreteEntities(SpriteFactory.Instance.CreateGelSprite));
        constructer.Add("Goriya", new ConcreteEntities(SpriteFactory.Instance.CreateGoriyaSprite));
        constructer.Add("Aquamentus", new ConcreteEntities(SpriteFactory.Instance.CreateAquamentusSprite));
        constructer.Add("BladeTraps", new ConcreteEntities(SpriteFactory.Instance.CreateBladeTrapSprite));
        constructer.Add("Wallmaster", new ConcreteEntities(SpriteFactory.Instance.CreateWallmasterSprite));
        constructer.Add("Trap", new ConcreteEntities(SpriteFactory.Instance.CreateTrapSprite));

        //Items 
        constructer.Add("ArrowDrop", new ConcreteEntities(SpriteFactory.Instance.CreateArrowDrop));
        constructer.Add("NickelRuby", new ConcreteEntities(SpriteFactory.Instance.CreateNickelRubyDrop));
        constructer.Add("Ruby", new ConcreteEntities(SpriteFactory.Instance.CreateRubyDrop));
        constructer.Add("Bow", new ConcreteEntities(SpriteFactory.Instance.CreateBowDrop));
        constructer.Add("Clock", new ConcreteEntities(SpriteFactory.Instance.CreateClockDrop));
        constructer.Add("Heart", new ConcreteEntities(SpriteFactory.Instance.CreateHeartDrop));
        constructer.Add("Sword", new ConcreteEntities(SpriteFactory.Instance.CreateSwordDrop));
        constructer.Add("TriforceShard", new ConcreteEntities(SpriteFactory.Instance.CreateTriforceShardDrop));
        constructer.Add("Compass", new ConcreteEntities(SpriteFactory.Instance.CreateCompassDrop));
        constructer.Add("Map", new ConcreteEntities(SpriteFactory.Instance.CreateMapDrop));
        constructer.Add("HeartContainer", new ConcreteEntities(SpriteFactory.Instance.CreateHeartContainerDrop));
        constructer.Add("Key", new ConcreteEntities(SpriteFactory.Instance.CreateKeyDrop));
        constructer.Add("BoomerangDrop", new ConcreteEntities(SpriteFactory.Instance.CreateBoomerangDrop));
        constructer.Add("BombDrop", new ConcreteEntities(SpriteFactory.Instance.CreateBombDrop));



        //Projectiles
        constructer.Add("Arrow", new Projectiles(SpriteFactory.Instance.CreateArrowProjectile));
        constructer.Add("Bomb", new Projectiles(SpriteFactory.Instance.CreateBombProjectile));
        constructer.Add("Boomerang", new Projectiles(SpriteFactory.Instance.CreateBoomerangProjectile));
        constructer.Add("Fireball", new Projectiles(SpriteFactory.Instance.CreateFireballProjectile));

        //Doors
        constructer.Add("DoorRight", new Doors(SpriteFactory.Instance.CreateDoorRightBlock));
        constructer.Add("DoorLeft", new Doors(SpriteFactory.Instance.CreateDoorLeftBlock));
        constructer.Add("DoorUp", new Doors(SpriteFactory.Instance.CreateDoorUpBlock));
        constructer.Add("DoorDown", new Doors(SpriteFactory.Instance.CreateDoorDownBlock));
        constructer.Add("BombDoorRight", new Doors(SpriteFactory.Instance.CreateBombableRightBlock));
        constructer.Add("BombDoorLeft", new Doors(SpriteFactory.Instance.CreateBombableLeftBlock));
        constructer.Add("BombDoorUp", new Doors(SpriteFactory.Instance.CreateBombableUpBlock));
        constructer.Add("BombDoorDown", new Doors(SpriteFactory.Instance.CreateBombableDownBlock));


    }
 
    public void ParseRoom()
    {
        var files = Directory.GetFiles(@"Rooms/", "*.xml");
        
        foreach (var file in files)
        {
            int xPos;
            int yPos;
            int baseX;
            int baseY;
            int id;
            String name;
            int roomObjectType;
            bool read = false;
            bool isDoor = false;
            bool isDoorOpen = false;

            //Projectile variables
            String projectile = null;
            int projDistance = 0;
            int projType = 0;
            ISprite enemyKey = null;
            ISprite enemyVal = null;

            reader = XmlReader.Create(file);
            room = new RoomObject();
       

            //read the base coordinates of each room
            reader.ReadToFollowing("BaseCord");
            reader.ReadToDescendant("xCord");
            baseX = reader.ReadElementContentAsInt();
            reader.ReadToNextSibling("yCord");
            baseY = reader.ReadElementContentAsInt();
            reader.ReadToNextSibling("id");
            id = reader.ReadElementContentAsInt();

            IntializeRooms(baseX, baseY);
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
                        Vector2 _base = new Vector2(baseX, baseY);
                        if (isDoor)
                        {
                            if(constructer.TryGetValue(name, out Delegate doorConstructor))
                            {
                                sprite = (ISprite)doorConstructor.DynamicInvoke(new Vector2(xPos, yPos) + _base, isDoorOpen);
                                if (!isDoorOpen)
                                {
                                    ((IConcreteSprite)sprite).SetSpriteAction(SpriteAction.doorClosed);
                                    room.AddClosedDoor(sprite, name);
                                }
                            }


                            isDoor = false;
                        }
                        else { 
                        if (constructer.TryGetValue(name, out Delegate value))
                        {
                             sprite = (ISprite)value.DynamicInvoke(new Vector2(xPos, yPos)+_base);

                            //case for when we have to pair projectile with parent sprite
                            //check if projectile is not null
                            if (projectile != null && sprite != null)
                            {
                                //now we want to create the projectile from the factory
                                if (constructer.TryGetValue(projectile, out Delegate projectileDel))
                                {
                                    ISprite concreteProj = (ISprite)projectileDel.DynamicInvoke(projDistance, sprite);
                                    //add the projectile created to the room
                                    room.AddGameObject(projType, concreteProj, "");
                                    // Get enemy and projectile for dictionary
                                    enemyKey = sprite; enemyVal = concreteProj;
                                    //reset projectile read in as null since we've added it to the room
                                    projectile = null;
                                }

                                 }
                            
                             }
                           
                        }
                        room.BaseCord = _base;
                        room.AddGameObject(roomObjectType, sprite, name);
                        if (enemyKey != null) room.AddEnemyProjectilePair(enemyKey, enemyVal);
                    }
                    while (reader.ReadToNextSibling(parseType.Item2));
                }
            }

            BuildRoom(id);
        }
       
    }

    private void IntializeRooms(int xBase, int yBase)
    {
        if (!runOnce)
        {
            Vector2 baseCord = new Vector2(xBase, yBase);
            Camera camera = Camera.Instance;
            camera.Move(baseCord);
            CreateLink(baseCord);
        }

        room.AddController(initalizeControllers.InitalizeKeyboard(Link));
        room.AddController(initalizeControllers.InitalizeMouse());
    }

    private void CreateLink(Vector2 baseCord)
    {
        /*
         * Link only needs to be created once.
         * Add him to the starting room only.
         * Colisions will be responsible for moving him between rooms.
         */

        Link = SpriteFactory.Instance.CreateLinkSprite(new Vector2(300, 350) + baseCord);
        room.Link = Link;

        /* Tempelate for creating and adding projectiles to link. Will be useful later*/
        // Create sword for link
        IProjectile Sword = (IProjectile)SpriteFactory.Instance.CreateSwordProjectile(12, Link);

        // Add sword to Link
        ((ConcreteSprite)Link).AddProjectile(Sword, ArrayIndex.sword);

    }

    private void BuildRoom(int id)
    {
        //Build the Room
        roomObjectManager.addRoom(room, id);
        runOnce = true;
    }
}