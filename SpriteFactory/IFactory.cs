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
    public ISprite CreateGoriyaSprite(Vector2 location);
    public ISprite CreateLinkSprite(Vector2 location);
    public ISprite CreateBarrierTile(Vector2 location);
    public ISprite CreateDungeonStairsTile(Vector2 location);
    public ISprite CreateWaterTile(Vector2 location);
    public ISprite CreateHeartItem(Vector2 location);
    public ISprite CreateKeyItem(Vector2 location);
    public ISprite CreateCompassItem(Vector2 location);
    public ISprite CreateMapItem(Vector2 location);
    public ISprite CreateDoorSprite(bool isOpen);
    public IProjectile CreateArrowSprite(Vector2 location);
    public IProjectile CreateSilverArrowSprite(Vector2 location);
    public IProjectile CreateBoomerangSprite(Vector2 location);
    public IProjectile CreateMagicBoomerangSprite(Vector2 location);
    public IProjectile CreateBombSprite(Vector2 location);
    public IProjectile CreateFireSprite(Vector2 location);
}

