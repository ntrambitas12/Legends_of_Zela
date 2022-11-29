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
        writer.WriteElementString("Compass", link.compass.ToString().ToLower());
        writer.WriteElementString("Map", link.map.ToString().ToLower());
        writer.WriteEndElement();
       
    }

    private void writeInventory()
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

}

