using System;
using System.Collections.Generic;
using System.Xml;

public class LevelLoader
{
    public XmlReader reader;
    public XmlReaderSettings settings;
    private List<(string, string)> parseTypes;

    public LevelLoader()
    {
        settings = new XmlReaderSettings();
        settings.IgnoreWhitespace = true;
        reader = XmlReader.Create("C:\\Users\\ntram\\source\\repos\\CSE3902Project\\LevelLoader\\RoomTest.xml");
        parseTypes = new List<(string, string)>()
        {
            ("Blocks", "Block"),
            ("Enemies", "Enemy"),
            ("Items", "Item"),
            ("Playables", "Link")
        };
    }
    public void ParseRoom()
    {
        int xPos;
        int yPos;
        String name;
        int roomObjectType;
        bool read = false;

        // foreach (var parseType in parseTypes)
        //{
        reader.ReadToFollowing("Blocks");
        read = reader.ReadToDescendant("Block");

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
            }
            while (reader.ReadToNextSibling("Block"));
        }
        /* This is where you call the corresponding method from spritefactory
        * and add that ISprite to the roomobject into correct list using add
        */

        reader.ReadToFollowing("Enemies");
       read = reader.ReadToDescendant("Enemy");
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
            }
            while (reader.ReadToNextSibling("Enemy"));
        }


        reader.ReadToFollowing("Items");
        read = reader.ReadToDescendant("Item");
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
            }
            while (reader.ReadToNextSibling("Item"));
        }


        //}
    }

    /*
     * Stuff that needs to be in XML:
     * ---------------
     * Object types:
     *  Link
     *  Background
     *  Collideable wall
     *  Enemies
     * ---------------
     * Location
     * ---------------
     * Object Name
     * 
     */

    private void BuildRoom()
    {

    }
}