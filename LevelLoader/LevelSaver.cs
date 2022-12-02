using System;
using System.Collections.Generic;
using System.Linq;
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
    public void SaveLink()
    {
        //initialize writer
        writer = XmlWriter.Create("SavedData/LinkData.xml", settings);
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
    public void SaveRooms()
    {
        IRoomObject[] rooms = roomObjectManager.getRooms();
        int i = 0;
        while (i < rooms.Length)
        {
            if (rooms[i] != null)
            {
                WriteRoom(rooms[i], i);
            }
            i++;
        }
    }
    private void WriteRoom(IRoomObject room, int i)
    {
        //initialize writer
        String savePath = "SavedData/Room" + i + ".xml";
        writer = XmlWriter.Create(savePath, settings);
        room = roomObjectManager.currentRoom();
        writer.WriteStartElement("XnaContent");

        //write content
        WriteBaseCord(room, i);
        WriteBlocks(room);
      //  WriteEnemies(room);
        //WriteItems(room);
        // TODO: there may be more lists im missing

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

        foreach(IConcreteSprite item in room.StaticTileList)
        {
            writer.WriteStartElement("Block");
            
            writer.WriteElementString("xPos", item.screenCord.X.ToString());
            writer.WriteElementString("yPos", item.screenCord.Y.ToString());
            writer.WriteElementString("Name", item.name);
            writer.WriteElementString("RoomObjectType", item.roomObjectType.ToString());

            writer.WriteEndElement();
        }

        foreach (IConcreteSprite item in room.DynamicTileList)
        {
            writer.WriteStartElement("Block");

            writer.WriteElementString("xPos", item.screenCord.X.ToString());
            writer.WriteElementString("yPos", item.screenCord.Y.ToString());
            writer.WriteElementString("Name", item.name);
            writer.WriteElementString("RoomObjectType", item.roomObjectType.ToString());

            writer.WriteEndElement();
        }
       
        foreach (IConcreteSprite item in room.MoveableTileList)
        {
            writer.WriteStartElement("Block");

            writer.WriteElementString("xPos", item.screenCord.X.ToString());
            writer.WriteElementString("yPos", item.screenCord.Y.ToString());
            writer.WriteElementString("Name", item.name);
            writer.WriteElementString("RoomObjectType", item.roomObjectType.ToString());

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
            writer.WriteStartAttribute("aiType", enemy.aiType.ToString());

            writer.WriteElementString("xPos", enemy.screenCord.X.ToString());
            writer.WriteElementString("yPos", enemy.screenCord.Y.ToString());
            writer.WriteElementString("Name", enemy.name);
            writer.WriteElementString("RoomObjectType", enemy.roomObjectType.ToString());
            writer.WriteElementString("Health", enemy.health.ToString());
            writer.WriteElementString("MaxHealth", enemy.maxHealth.ToString());

            /*Deal with writing enemy projectiles here*/

            writer.WriteEndElement();
        }

        writer.WriteEndElement();
    }
    private void WriteItems(IRoomObject room)
    {
        writer.WriteStartElement("Items");

        // TODO

        writer.WriteEndElement();
    }
}

