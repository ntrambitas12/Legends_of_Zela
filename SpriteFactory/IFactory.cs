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
    public void LoadAllContent(ContentManager Content, SpriteBatch spriteBatch);

    public IConcreteSprite CreateGoriyaSprite();
    public IConcreteSprite CreateLinkSprite();
    public ISprite CreateBarrierTile();
    public ISprite CreateBushTile();
    public ISprite CreateCompassTile();
    public ISprite CreateMapTile();
    public IItem CreateArrowSprite();

}

