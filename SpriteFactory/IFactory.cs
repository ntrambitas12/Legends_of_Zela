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
    public ISprite CreateEnemy(Vector2 location, String name, int roomObjectType, int health, int maxHealth, int aiType);
    public ISprite CreateDeathCloud(Vector2 location);

    //Link methods
    public ISprite CreateLinkSprite(Vector2 location, String name, int roomObjectType);

    //Block methods
    public ISprite CreateBlock(Vector2 location, String name, int roomObjectType);
    public ISprite CreateStairsBlock(Vector2 location);
    public ISprite CreateInvisibleStairsBlock(Vector2 location);
    public ISprite CreateDoorBlock(Vector2 location, bool isOpen, String name, int roomObjectType);


    //Drop Methods
    public ISprite CreateArrowDrop(Vector2 location);
    public ISprite CreateNickelRubyDrop(Vector2 location);
    public ISprite CreateRubyDrop(Vector2 location);
    public ISprite CreateBombDrop(Vector2 location);
    public ISprite CreateBoomerangDrop(Vector2 location);
    public ISprite CreateBowDrop(Vector2 location);
    public ISprite CreateClockDrop(Vector2 location);
    public ISprite CreateCompassDrop(Vector2 location);
    public ISprite CreateHeartDrop(Vector2 location);
    public ISprite CreateHeartContainerDrop(Vector2 location);
    public ISprite CreateKeyDrop(Vector2 location);
    public ISprite CreateMapDrop(Vector2 location);
    public ISprite CreateSwordDrop(Vector2 location);
    public ISprite CreateTriforceShardDrop(Vector2 location);

    // Projectile Methods
    public ISprite CreateArrowProjectile(int distance, ISprite owner, String name);
    public ISprite CreateBombProjectile(int distance, ISprite owner, String name);
    public ISprite CreateBoomerangProjectile(int distance, ISprite owner, String name);
    public ISprite CreateFireballProjectile(int distance, ISprite owner, String name);
    public ISprite CreateSwordProjectile(int distance, ISprite owner, String name);
    public ISprite CreateSwordShootProjectile(int distance, ISprite owner, String name);
    public ISprite CreateLowerFireballProjectile(int distance, ISprite owner, String name);
    public ISprite CreateUpperFireballProjectile(int distance, ISprite owner, String name);

}

