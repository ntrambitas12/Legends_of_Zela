using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Xml;

public class LevelLoader
{
    public XmlReader reader;
    public XmlReaderSettings settings;
    private List<(string, string)> parseTypes;
    private delegate ISprite ConcreteEntities(Vector2 pos); 

    private Dictionary<String, Delegate> constructer;

    public LevelLoader()
    {
        settings = new XmlReaderSettings();
        constructer = new Dictionary<String, Delegate>();
        settings.IgnoreWhitespace = true;
        reader = XmlReader.Create("C:\\Users\\Ben\\source\\repos\\CSE3902Project\\LevelLoader\\RoomTest.xml");
        parseTypes = new List<(string, string)>()
        {
            ("Blocks", "Block"),
            ("Enemies", "Enemy"),
            ("Items", "Item"),
            ("Playables", "Link")
        };

        populateDictionary();
    }

    private void populateDictionary()
    {
        constructer.Add("Goriya", new ConcreteEntities(SpriteFactory.Instance.CreateGoriyaSprite));

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
                     if(constructer.TryGetValue(name, out Delegate value))
                    {
                        ISprite sprite = (ISprite)value.DynamicInvoke(new Vector2(xPos, yPos));
                        
                    }

                }
                while (reader.ReadToNextSibling(parseType.Item2));
        }
       }
    }

    private void BuildRoom()
    {

    }
}