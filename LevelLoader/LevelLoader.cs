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

                }
                while (reader.ReadToNextSibling(parseType.Item2));
        }
       }
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