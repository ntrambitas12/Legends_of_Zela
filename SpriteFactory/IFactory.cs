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

    public ISprite CreateGoriyaSprite(Vector2 pos);
    public ISprite CreateLinkSprite(Vector2 pos);
    public ISprite CreateBarrierTile(Vector2 pos);
    public ISprite CreateBushTile(Vector2 pos);
    public ISprite CreateDefaultFloorTile(Vector2 pos);
    public ISprite CreateDungeonStairsTile(Vector2 pos);
    public ISprite CreateGravestoneTile(Vector2 pos);
    public ISprite CreateWaterTile(Vector2 pos);
    public ISprite CreateHeartItem(Vector2 pos);
    public ISprite CreateKeyItem(Vector2 pos);
    public ISprite CreateCompassItem(Vector2 pos);
    public ISprite CreatePeahatSprite(Vector2 pos);
    public ISprite CreateOktorokSprite(Vector2 pos);
    public ISprite CreateMapItem(Vector2 pos);
    public ISprite CreateDoorSprite(bool isOpen, Vector2 pos);
    public IProjectile CreateArrowSprite(Vector2 pos);
    public IProjectile CreateSilverArrowSprite(Vector2 pos);
    public IProjectile CreateBoomerangSprite(Vector2 pos);
    public IProjectile CreateMagicBoomerangSprite(Vector2 pos);
    public IProjectile CreateBombSprite(Vector2 pos);
    public IProjectile CreateFireSprite(Vector2 pos);
}

