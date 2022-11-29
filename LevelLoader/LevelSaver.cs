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
        room = roomObjectManager.currentRoom();
        settings = new XmlWriterSettings();
        settings.Indent = true;
        settings.IndentChars = ("    ");
        settings.CloseOutput = true;
        settings.OmitXmlDeclaration = false;
        writer = XmlWriter.Create("SavedData/gameData1.xml", settings);
    }
    private static LevelSaver instance = new LevelSaver();
    public static LevelSaver Instance { get { return instance; } }

    public void Save()
    {
        writer.WriteStartElement("XnaContent");
        writeLink(); 
        writeInventory();
        writer.WriteEndElement();
        writer.Flush();
        writer.Close();
       
    }

    private void writeLink() 
    {
        IConcreteSprite link = (IConcreteSprite)room.Link;
        writer.WriteStartElement("Link");
        writer.WriteElementString("Health", link.health.ToString());
        writer.WriteElementString("MaxHealth", link.maxHealth.ToString());
        writer.WriteElementString("Rupee", link.rubies.ToString());
        writer.WriteElementString("Bombs", link.bombs.ToString());
        writer.WriteElementString("Keys", link.keys.ToString());
        writer.WriteElementString("currentRoom", roomObjectManager.currentRoomIdx().ToString());
        writer.WriteElementString("Compass", link.compass.ToString());
        writer.WriteElementString("Map", link.map.ToString());
        writer.WriteEndElement();
       
    }

    private void writeInventory()
    {
       
        writer.WriteStartElement("Inventory");
        IConcreteSprite link = (IConcreteSprite)room.Link;
        foreach(var projectiles in link.projectiles)
        {
            if(projectiles != null)
            {
                writer.WriteStartElement("Item");
                IItemType type = projectiles.ItemType();

                /* 
                 Make this data in a dictinoary to look up
                 */
                if (type is ArrowType)
                {
                    writer.WriteElementString("Drop", "ArrowDrop");
                    writer.WriteElementString("Proj", "Arrow");
                    writer.WriteElementString("Index", "0");
                    writer.WriteElementString("Distance", "30");

                }

                if (type is BombType)
                {
                    writer.WriteElementString("Drop", "BombDrop");
                    writer.WriteElementString("Proj", "Bomb");
                    writer.WriteElementString("Index", "1");
                    writer.WriteElementString("Distance", "50");

                }

                if (type is BoomerangType)
                {
                    writer.WriteElementString("Drop", "BoomerangDrop");
                    writer.WriteElementString("Proj", "Boomerang");
                    writer.WriteElementString("Index", "2");
                    writer.WriteElementString("Distance", "2000");

                }

                

                writer.WriteEndElement();

            }
        }
        writer.WriteEndElement();
    }

}

