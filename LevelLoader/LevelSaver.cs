using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

public sealed class LevelSaver
{
    private XmlWriter writer;
    private XmlWriterSettings settings;
    private IRoomObjectManager roomObjectManager;
    private IRoomObject room;
    
   
   private LevelSaver()
   {
       
        roomObjectManager = RoomObjectManager.Instance;
        settings = new XmlWriterSettings();
        settings.Indent = true;
        settings.IndentChars = ("    ");
        settings.CloseOutput = true;
        settings.OmitXmlDeclaration = false;
    }
    private static LevelSaver instance = new LevelSaver();
    public static LevelSaver Instance { get { return instance; } }

    //------------------------------------------LINK------------------------------------------
    //handles player inventory 
    public void SaveLink(int saveState)
    {
        //initialize writer
<<<<<<< HEAD
        roomObjectManager = RoomObjectManager.Instance;
=======
<<<<<<< HEAD
        writer = XmlWriter.Create("SavedData/savedData.xml", settings);
=======
>>>>>>> 8af5b1c6cf98a88466e9d019731eaaf01520d023
        writer = XmlWriter.Create("SavedData/" + saveState + "/Link/LinkData.xml", settings);
>>>>>>> 958b4d4858d34744a16f5dda6e1c8f8f5ddba6ee
        room = roomObjectManager.currentRoom();
        writer.WriteStartElement("XnaContent");

        //write content
        WriteLink(); 
        WriteInventory();

        //release writer
        writer.WriteEndElement();
        writer.Flush();
        writer.Close();
       
    }
    private void WriteLink() 
    {
        IConcreteSprite link = (IConcreteSprite)room.Link;
        writer.WriteStartElement("Link");
        writer.WriteElementString("Health", link.health.ToString());
        writer.WriteElementString("MaxHealth", link.maxHealth.ToString());
        writer.WriteElementString("Rupee", link.rubies.ToString());
        writer.WriteElementString("Bombs", link.bombs.ToString());
        writer.WriteElementString("Keys", link.keys.ToString());
        writer.WriteElementString("currentRoom", roomObjectManager.currentRoomIdx().ToString());
        writer.WriteElementString("Compass", link.compass.ToString().ToLower());
        writer.WriteElementString("Map", link.map.ToString().ToLower());
        writer.WriteElementString("xCord", ((int)link.screenCord.X).ToString());
        writer.WriteElementString("yCord", ((int)link.screenCord.Y).ToString());
        writer.WriteEndElement();
       
    }
    private void WriteInventory()
    {
        IConcreteSprite link = (IConcreteSprite)room.Link;
        writer.WriteStartElement("Inventory");
        int idx = 0;
        foreach(var projectiles in link.projectiles)
        {
            
            if(projectiles != null && !projectiles.GetDropName().Contains("Sword"))
            {
                writer.WriteStartElement("Item");
               
                    writer.WriteElementString("Drop", projectiles.GetDropName());
                    writer.WriteElementString("Proj", projectiles.GetDropDescription());
                    writer.WriteElementString("Index", idx.ToString());
                    writer.WriteElementString("Distance", projectiles.Distance().ToString());

                writer.WriteEndElement();

            }
            idx++;
        }
        writer.WriteEndElement();
    }

    //------------------------------------------ROOMS------------------------------------------
    //handles all entities
    public void SaveRooms(int saveState)
    {
        roomObjectManager = RoomObjectManager.Instance;
        IRoomObject[] rooms = roomObjectManager.getRooms();
        int i = 0;
        while (i < rooms.Length)
        {
            if (rooms[i] != null)
            {
                WriteRoom(rooms[i], i, saveState);
            }
            i++;
        }
    }
    private void WriteRoom(IRoomObject room, int i, int saveState)
    {
        //initialize writer
        String savePath = "SavedData/" + saveState + "/Room" + i + ".xml";
        writer = XmlWriter.Create(savePath, settings);
        //room = roomObjectManager.currentRoom();
        writer.WriteStartElement("XnaContent");

        //write content
        WriteBaseCord(room, i);
        WriteBlocks(room);
        WriteEnemies(room);
        WriteItems(room);

        //release writer
        writer.WriteEndElement();
        writer.Flush();
        writer.Close();
        
    }
    private void WriteBaseCord(IRoomObject room, int i)
    {
        writer.WriteStartElement("BaseCord");
        writer.WriteElementString("xCord", room.BaseCord.X.ToString());
        writer.WriteElementString("yCord", room.BaseCord.Y.ToString());
        writer.WriteElementString("id", i.ToString());
        writer.WriteEndElement();
    }
    private void WriteBlocks(IRoomObject room)
    {
        writer.WriteStartElement("Blocks");

        //write door
        foreach(IConcreteSprite item in room.TopLayerNonCollidibleList)
        {
            writer.WriteStartElement("Block");
            writer.WriteAttributeString("isOpen", item.isDoorOpen.ToString().ToLower());
            WriteItem(item);

            writer.WriteEndElement();
        }

        //write dungeon floor
        foreach (IConcreteSprite item in room.floorList)
        {
            writer.WriteStartElement("Block");

            WriteItem(item);

            writer.WriteEndElement();
        }

        //write dungeon floor
        foreach (IConcreteSprite item in room.replacesFloorList)
        {
            writer.WriteStartElement("Block");

            WriteItem(item);

            writer.WriteEndElement();
        }

        foreach (IConcreteSprite item in room.StaticTileList)
        {
            writer.WriteStartElement("Block");

            WriteItem(item);

            writer.WriteEndElement();
        }

        foreach (IConcreteSprite item in room.DynamicTileList)
        {
            writer.WriteStartElement("Block");

            WriteItem(item);

            writer.WriteEndElement();
        }
       
        foreach (IConcreteSprite item in room.MoveableTileList)
        {
            writer.WriteStartElement("Block");

            WriteItem(item);

            writer.WriteEndElement();
        }
        
        writer.WriteEndElement();
    }
    private void WriteEnemies(IRoomObject room)
    {
        writer.WriteStartElement("Enemies");

        foreach (IConcreteSprite enemy in room.EnemyList)
        {
            writer.WriteStartElement("Enemy");
            writer.WriteAttributeString("aiType", enemy.aiType.ToString());

            WriteItem(enemy);

            writer.WriteElementString("Health", enemy.health.ToString());
            writer.WriteElementString("MaxHealth", enemy.maxHealth.ToString());

            /*Deal with writing enemy projectiles here*/
            if (room.EnemyToProjectile.TryGetValue(enemy, out ISprite projVal))
            {   
                IProjectile projectile = projVal as IProjectile;
                int projType = (int)RoomObjectTypes.typeEnemyProjectile;
                writer.WriteStartElement("Projectile");
                writer.WriteElementString("Name", projectile.GetDropName().Replace("Drop", ""));
                writer.WriteElementString("Distance", projectile.Distance().ToString());
                writer.WriteElementString("RoomObjectType", projType.ToString());
                writer.WriteEndElement();
            }

            writer.WriteEndElement();
        }

        writer.WriteEndElement();
    }
    private void WriteItems(IRoomObject room)
    {
        writer.WriteStartElement("Items");

        foreach(IDrop item in room.PickupList)
        {
                writer.WriteStartElement("Item");
                WriteItem(item);
                writer.WriteEndElement();  
        }

        writer.WriteEndElement();
    }

    private void WriteItem(IConcreteSprite item)
    {
        writer.WriteElementString("xPos", item.initalCoord.X.ToString());
        writer.WriteElementString("yPos", item.initalCoord.Y.ToString());
        writer.WriteElementString("Name", item.name);
        writer.WriteElementString("RoomObjectType", item.roomObjectType.ToString());
    }
    private void WriteItem(IDrop item)
    {

        writer.WriteElementString("xPos", item.initScreenCoord.X.ToString());
        writer.WriteElementString("yPos", item.initScreenCoord.Y.ToString());
        writer.WriteElementString("Name", item.name);
        writer.WriteElementString("RoomObjectType", item.RoomObjectType.ToString());
    }
}

