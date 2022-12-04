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

    //Enemy Methods
    public ISprite CreateEnemy(Vector2 location, Vector2 baseCord, String name, int roomObjectType, int health, int maxHealth, int aiType);
    public ISprite CreateDeathCloud(Vector2 location, Vector2 baseCord);

    //Link methods
    public ISprite CreateLinkSprite(Vector2 location, String name, int roomObjectType);

    //Block methods
    public ISprite CreateBlock(Vector2 location, Vector2 baseCord, String name, int roomObjectType);
    public ISprite CreateDoorBlock(Vector2 location, Vector2 baseCord, bool isOpen, String name, int roomObjectType);


    //Drop Methods
    public ISprite CreateDrop(Vector2 location, Vector2 baseCord, String name, int RoomObjectType);

    // Projectile Methods
    public ISprite CreateArrowProjectile(int distance, ISprite owner, String name, int roomObjectType);
    public ISprite CreateBombProjectile(int distance, ISprite owner, String name, int roomObjectType);
    public ISprite CreateBoomerangProjectile(int distance, ISprite owner, String name, int roomObjectType);
    public ISprite CreateFireballProjectile(int distance, ISprite owner, String name, int roomObjectType);
    public ISprite CreateSwordProjectile(int distance, ISprite owner, String name, int roomObjectType);
    public ISprite CreateSwordShootProjectile(int distance, ISprite owner, String name, int roomObjectType);
    public ISprite CreateLowerFireballProjectile(int distance, ISprite owner, String name, int roomObjectType);
    public ISprite CreateUpperFireballProjectile(int distance, ISprite owner, String name, int roomObjectType);

}

