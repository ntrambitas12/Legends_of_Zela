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

    //Link methods
    public ISprite CreateLinkSprite(Vector2 location);

    //Block methods
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

    //Item Methods
    public ISprite CreateNickelRubyItem(Vector2 location);
    public ISprite CreateArrowSprite(Vector2 location);
    public ISprite CreateRubyItem(Vector2 location);
    public ISprite CreateBombSprite(Vector2 location);
    public ISprite CreateBoomerangSprite(Vector2 location);
    public ISprite CreateBowItem(Vector2 location);
    public ISprite CreateClockSprite(Vector2 location);
    public ISprite CreateCompassItem(Vector2 location);
    public ISprite CreateFireSprite(Vector2 location);
    public ISprite CreateHeartItem(Vector2 location);
    public ISprite CreateHeartContainerItem(Vector2 location);
    public ISprite CreateKeyItem(Vector2 location);
    public ISprite CreateMapItem(Vector2 location);
    public ISprite CreateSwordItem(Vector2 location);
    public ISprite CreateTriforceShardItem(Vector2 location);
}

