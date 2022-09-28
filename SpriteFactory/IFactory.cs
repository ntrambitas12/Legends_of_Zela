using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

public interface IFactory
{
    void LoadAllContent(ContentManager Content);
    void LoadSprite(int SpriteID, int setLocation, int frameLocation, string textureName);
    void GetNewSprite(int index);

}

