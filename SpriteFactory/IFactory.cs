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
    public ISprite CreateGoriyaSprite(Vector2 location);
    public ISprite CreateKeeseSprite(Vector2 location);
    public ISprite CreateStalfosSprite(Vector2 location);
    public ISprite CreateGelSprite(Vector2 location);
    public ISprite CreateAquamentusSprite(Vector2 location);
    public ISprite CreateBladeTrapSprite(Vector2 location);
    public ISprite CreateWallmasterSprite(Vector2 location);
    public ISprite CreateOldManSprite(Vector2 location);
    public ISprite CreateTrapSprite(Vector2 location);

    //Link methods
    public ISprite CreateLinkSprite(Vector2 location);

    //Block methods
    public ISprite CreateTextBlock(Vector2 location);
    public ISprite CreateOpeningBlock(Vector2 location);
    public ISprite CreateInvisibleBarrierBlock(Vector2 location);
    public ISprite CreateAlternateBackgroundBlock(Vector2 location);
    public ISprite CreateDungeonFloorBlock(Vector2 location);
    public ISprite CreateBarrierBlock(Vector2 location);
    public ISprite CreateStairsBlock(Vector2 location);
    public ISprite CreateWaterBlock(Vector2 location);
    public ISprite CreateRoughFloorBlock(Vector2 location);
    public ISprite CreateStatueRightBlock(Vector2 location);
    public ISprite CreateStatueLeftBlock(Vector2 location);
    public ISprite CreateDoorUpBlock(Vector2 location, bool isOpen);
    public ISprite CreateDoorDownBlock(Vector2 location, bool isOpen);
    public ISprite CreateDoorRightBlock(Vector2 location, bool isOpen);
    public ISprite CreateDoorLeftBlock(Vector2 location, bool isOpen);
    public ISprite CreateBombableUpBlock(Vector2 location, bool isBombed);
    public ISprite CreateBombableDownBlock(Vector2 location, bool isBombed);
    public ISprite CreateBombableRightBlock(Vector2 location, bool isBombed);
    public ISprite CreateBombableLeftBlock(Vector2 location, bool isBombed);
    public ISprite CreateWallTopBlock(Vector2 location);
    public ISprite CreateWallTop1Block(Vector2 location);
    public ISprite CreateWallTop2Block(Vector2 location);
    public ISprite CreateWallBottomBlock(Vector2 location);
    public ISprite CreateWallBottom1Block(Vector2 location);
    public ISprite CreateWallBottom2Block(Vector2 location);
    public ISprite CreateWallRightBlock(Vector2 location);
    public ISprite CreateWallRight1Block(Vector2 location);
    public ISprite CreateWallRight2Block(Vector2 location);
    public ISprite CreateWallLeftBlock(Vector2 location);
    public ISprite CreateWallLeft1Block(Vector2 location);
    public ISprite CreateWallLeft2Block(Vector2 location);
    public ISprite CreateFireBlock(Vector2 location);

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
    public ISprite CreateArrowProjectile(int distance, ISprite owner);
    public ISprite CreateBombProjectile(int distance, ISprite owner);
    public ISprite CreateBoomerangProjectile(int distance, ISprite owner);
    public ISprite CreateFireballProjectile(int distance, ISprite owner);
    public ISprite CreateSwordProjectile(int distance, ISprite owner);
    public ISprite CreateSwordShootProjectile(int distance, ISprite owner);
}

