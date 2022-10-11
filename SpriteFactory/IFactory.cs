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

    public ISprite CreateGoriyaSprite();
    public ISprite CreateLinkSprite();
    public ISprite CreateBarrierTile();
    public ISprite CreateBushTile();
    public ISprite CreateDefaultFloorTile();
    public ISprite CreateDungeonStairsTile();
    public ISprite CreateGravestoneTile();
    public ISprite CreateWaterTile();
    public ISprite CreateHeartItem();
    public ISprite CreateKeyItem();
    public ISprite CreateCompassItem();
    public ISprite CreatePeahatSprite();
    public ISprite CreateOktorokSprite();
    public ISprite CreateMapItem();
    public ISprite CreateDoorSprite(bool isOpen);
    public IProjectile CreateArrowSprite();
    public IProjectile CreateSilverArrowSprite();
    public IProjectile CreateBoomerangSprite();
    public IProjectile CreateMagicBoomerangSprite();
    public IProjectile CreateBombSprite();
    public IProjectile CreateFireSprite();
}

