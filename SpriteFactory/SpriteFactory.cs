using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Net;

public sealed class SpriteFactory : IFactory
{

    //Blocks
    private List<Texture2D>[] barrierFrames;
    private List<Texture2D> barrier;

    private List<Texture2D>[] dungeonStairsFrames;
    private List<Texture2D> dungeonStairs;

    private List<Texture2D>[] waterFrames;
    private List<Texture2D> water;

    private List<Texture2D>[] doorFrames;
    private List<Texture2D> doorOpen;
    private List<Texture2D> doorClosed;

    private List<Texture2D>[] statueFrames;
    private List<Texture2D> statueRight;
    private List<Texture2D> statueLeft;

    private List<Texture2D>[] roughFloorFrames;
    private List<Texture2D> roughFloor;

    private List<Texture2D>[] wallTopFullFrames;
    private List<Texture2D> wallTopFull;

    private List<Texture2D>[] wallTop1Frames;
    private List<Texture2D> wallTop1;

    private List<Texture2D>[] wallTop2Frames;
    private List<Texture2D> wallTop2;

    private List<Texture2D>[] wallBottomFullFrames;
    private List<Texture2D> wallBottomFull;

    private List<Texture2D>[] wallBottom1Frames;
    private List<Texture2D> wallBottom1;

    private List<Texture2D>[] wallBottom2Frames;
    private List<Texture2D> wallBottom2;

    private List<Texture2D>[] wallRightFullFrames;
    private List<Texture2D> wallRightFull;

    private List<Texture2D>[] wallRight1Frames;
    private List<Texture2D> wallRight1;

    private List<Texture2D>[] wallRight2Frames;
    private List<Texture2D> wallRight2;

    private List<Texture2D>[] wallLeftFullFrames;
    private List<Texture2D> wallLeftFull;

    private List<Texture2D>[] wallLeft1Frames;
    private List<Texture2D> wallLeft1;

    private List<Texture2D>[] wallLeft2Frames;
    private List<Texture2D> wallLeft2;


    //Enemies
    private List<Texture2D>[] goriyaFrames;
    private List<Texture2D> goriyaRight;
    private List<Texture2D> goriyaLeft;
    private List<Texture2D> goriyaUp;
    private List<Texture2D> goriyaDown;

    private List<Texture2D>[] KeeseFrames;
    private List<Texture2D> KeeseRight;
    private List<Texture2D> KeeseLeft;

    //private List<Texture2D>[] ;

    //Items
    private List<Texture2D>[] compassFrames;
    private List<Texture2D> compass;

    private List<Texture2D>[] heartFrames;
    private List<Texture2D> heart;

    private List<Texture2D>[] keyFrames;
    private List<Texture2D> key;

    private List<Texture2D>[] mapFrames;
    private List<Texture2D> map;

    private List<Texture2D>[] rupiesFrames;
    private List<Texture2D> rupies;

    private List<Texture2D>[] swordFrames;
    private List<Texture2D> sword;


    //Link
    private List<Texture2D>[] linkFrames;
    private List<Texture2D> linkRight;
    private List<Texture2D> linkLeft;
    private List<Texture2D> linkUp;
    private List<Texture2D> linkDown;
    private List<Texture2D> linkUseLeft;
    private List<Texture2D> linkUseRight;
    private List<Texture2D> linkUseUp;
    private List<Texture2D> linkUseDown;
    private List<Texture2D> linkAttackLeft;
    private List<Texture2D> linkAttackRight;
    private List<Texture2D> linkAttackUp;
    private List<Texture2D> linkAttackDown;


    //Projectiles
    private List<Texture2D>[] arrowFrames;
    private List<Texture2D> arrowLeft;
    private List<Texture2D> arrowRight;
    private List<Texture2D> arrowUp;
    private List<Texture2D> arrowDown;
    private List<Texture2D>[] silverArrowFrames;
    private List<Texture2D> silverArrowLeft;
    private List<Texture2D> silverArrowRight;
    private List<Texture2D> silverArrowUp;
    private List<Texture2D> silverArrowDown;
    private List<Texture2D>[] boomerangFrames;
    private List<Texture2D> boomerangLeft;
    private List<Texture2D> boomerangRight;
    private List<Texture2D> boomerangUp;
    private List<Texture2D> boomerangDown;
    private List<Texture2D>[] magicBoomerangFrames;
    private List<Texture2D> magicBoomerangLeft;
    private List<Texture2D> magicBoomerangRight;
    private List<Texture2D> magicBoomerangUp;
    private List<Texture2D> magicBoomerangDown;
    private List<Texture2D>[] bombFrames;
    private List<Texture2D> bombLeft;
    private List<Texture2D> bombRight;
    private List<Texture2D> bombUp;
    private List<Texture2D> bombDown;
    private List<Texture2D> bombCloud;
    private List<Texture2D>[] fireFrames;
    private List<Texture2D> fireLeft;
    private List<Texture2D> fireRight;
    private List<Texture2D> fireUp;
    private List<Texture2D> fireDown;


    private SpriteBatch _spriteBatch;
    private SpriteFactory()
    {
        compassFrames = new List<Texture2D>[4];
        heartFrames = new List<Texture2D>[4];
        keyFrames = new List<Texture2D>[4];
        mapFrames = new List<Texture2D>[4];
        rupiesFrames = new List<Texture2D>[4];
        swordFrames = new List<Texture2D>[4];
        barrierFrames = new List<Texture2D>[4];
        dungeonStairsFrames = new List<Texture2D>[4];
        waterFrames = new List<Texture2D>[4];

        linkFrames = new List<Texture2D>[16];
        linkLeft = new List<Texture2D>();
        linkRight = new List<Texture2D>();
        linkDown = new List<Texture2D>();
        linkUp = new List<Texture2D>();
        linkUseLeft = new List<Texture2D>();
        linkUseRight = new List<Texture2D>();
        linkUseUp = new List<Texture2D>();
        linkUseDown = new List<Texture2D>();
        linkAttackLeft = new List<Texture2D>();
        linkAttackRight = new List<Texture2D>();
        linkAttackUp = new List<Texture2D>();
        linkAttackDown = new List<Texture2D>();
        goriyaFrames = new List<Texture2D>[4];
        goriyaLeft = new List<Texture2D>();
        goriyaRight = new List<Texture2D>();
        goriyaDown = new List<Texture2D>();
        goriyaUp = new List<Texture2D>();
        arrowFrames = new List<Texture2D>[4];
        arrowLeft = new List<Texture2D>();
        arrowRight = new List<Texture2D>();
        arrowUp = new List<Texture2D>();
        arrowDown = new List<Texture2D>();
        silverArrowFrames = new List<Texture2D>[4];
        silverArrowLeft = new List<Texture2D>();
        silverArrowRight = new List<Texture2D>();
        silverArrowUp = new List<Texture2D>();
        silverArrowDown = new List<Texture2D>();
        boomerangFrames = new List<Texture2D>[4];
        boomerangLeft = new List<Texture2D>();
        boomerangRight = new List<Texture2D>();
        boomerangUp = new List<Texture2D>();
        boomerangDown = new List<Texture2D>();
        magicBoomerangFrames = new List<Texture2D>[4];
        magicBoomerangLeft = new List<Texture2D>();
        magicBoomerangRight = new List<Texture2D>();
        magicBoomerangUp = new List<Texture2D>();
        magicBoomerangDown = new List<Texture2D>();
        bombFrames = new List<Texture2D>[5];
        bombLeft = new List<Texture2D>();
        bombRight = new List<Texture2D>();
        bombUp = new List<Texture2D>();
        bombDown = new List<Texture2D>();
        bombCloud = new List<Texture2D>();
        fireFrames = new List<Texture2D>[4];
        fireLeft = new List<Texture2D>();
        fireRight = new List<Texture2D>();
        fireUp = new List<Texture2D>();
        fireDown = new List<Texture2D>();
        compass = new List<Texture2D>();
        heart = new List<Texture2D>();
        key = new List<Texture2D>();
        map = new List<Texture2D>();
        rupies = new List<Texture2D>();
        sword = new List<Texture2D>();
        barrier = new List<Texture2D>();
        dungeonStairs = new List<Texture2D>();
        water = new List<Texture2D>();

        doorOpen = new List<Texture2D>();
        doorClosed = new List<Texture2D>();


    }

    private static readonly SpriteFactory instance = new SpriteFactory();
    public static SpriteFactory Instance
    {
        get { return instance; }
    }



    public void LoadAllContent(ContentManager content, SpriteBatch spriteBatch)
    {
        _spriteBatch = spriteBatch;

        // Load tiles in
        compass.Add(content.Load<Texture2D>("ItemSprites/Compass"));
        key.Add(content.Load<Texture2D>("ItemSprites/Key"));
        map.Add(content.Load<Texture2D>("ItemSprites/Map"));
        rupies.Add(content.Load<Texture2D>("ItemSprites/5Rupies"));
        sword.Add(content.Load<Texture2D>("ItemSprites/Sword"));
        barrier.Add(content.Load<Texture2D>("TileSprites/Barrier"));
        dungeonStairs.Add(content.Load<Texture2D>("TileSprites/DungeonStairs"));
        water.Add(content.Load<Texture2D>("TileSprites/WaterMiddle"));

        for (int i = 0; i < 4; i++)
        {
            barrierFrames[i] = barrier;
            dungeonStairsFrames[i] = dungeonStairs;
            waterFrames[i] = water;

            compassFrames[i] = compass;
            keyFrames[i] = key;
            mapFrames[i] = map;
            rupiesFrames[i] = rupies;
            swordFrames[i] = sword;
        }

        /*Testing for heart*/
        heart.Add(content.Load<Texture2D>("ItemSprites/Heart1"));
        heart.Add(content.Load<Texture2D>("ItemSprites/Heart2"));
        heartFrames[0] = heart;

        for (int i = 1; i <= 2; i++)
        {
            // Loads sprite frames
            linkRight.Add(content.Load<Texture2D>("LinkSprites/linkRight" + i));
            linkLeft.Add(content.Load<Texture2D>("LinkSprites/linkLeft" + i));
            linkUp.Add(content.Load<Texture2D>("LinkSprites/linkUp" + i));
            linkDown.Add(content.Load<Texture2D>("LinkSprites/linkDown" + i));
            linkUseRight.Add(content.Load<Texture2D>("LinkSprites/LinkRightUse"));
            linkUseLeft.Add(content.Load<Texture2D>("LinkSprites/LinkLeftUse"));
            linkUseUp.Add(content.Load<Texture2D>("LinkSprites/LinkUpUse"));
            linkUseDown.Add(content.Load<Texture2D>("LinkSprites/LinkDownUse"));
            linkAttackRight.Add(content.Load<Texture2D>("LinkSprites/LinkRightSword"));
            linkAttackLeft.Add(content.Load<Texture2D>("LinkSprites/LinkLeftSword"));
            linkAttackUp.Add(content.Load<Texture2D>("LinkSprites/LinkUpSword"));
            linkAttackDown.Add(content.Load<Texture2D>("LinkSprites/LinkDownSword"));

            goriyaRight.Add(content.Load<Texture2D>("EnemySprites/GoriyaRedRight" + i));
            goriyaLeft.Add(content.Load<Texture2D>("EnemySprites/GoriyaRedLeft" + i));
            goriyaUp.Add(content.Load<Texture2D>("EnemySprites/GoriyaRedUp" + i));
            goriyaDown.Add(content.Load<Texture2D>("EnemySprites/GoriyaRedDown" + i));

        }

        // Assign textures to projectile directions
        arrowLeft.Add(content.Load<Texture2D>("ItemSprites/ArrowLeft"));
        arrowRight.Add(content.Load<Texture2D>("ItemSprites/ArrowRight"));
        arrowUp.Add(content.Load<Texture2D>("ItemSprites/ArrowUp"));
        arrowDown.Add(content.Load<Texture2D>("ItemSprites/ArrowDown"));
        silverArrowLeft.Add(content.Load<Texture2D>("ItemSprites/SilverArrow"));
        silverArrowRight.Add(content.Load<Texture2D>("ItemSprites/SilverArrow"));
        silverArrowUp.Add(content.Load<Texture2D>("ItemSprites/SilverArrow"));
        silverArrowDown.Add(content.Load<Texture2D>("ItemSprites/SilverArrow"));
        boomerangLeft.Add(content.Load<Texture2D>("ItemSprites/Boomerang"));
        boomerangRight.Add(content.Load<Texture2D>("ItemSprites/Boomerang"));
        boomerangUp.Add(content.Load<Texture2D>("ItemSprites/Boomerang"));
        boomerangDown.Add(content.Load<Texture2D>("ItemSprites/Boomerang"));
        magicBoomerangLeft.Add(content.Load<Texture2D>("ItemSprites/MagicBoomerang"));
        magicBoomerangRight.Add(content.Load<Texture2D>("ItemSprites/MagicBoomerang"));
        magicBoomerangUp.Add(content.Load<Texture2D>("ItemSprites/MagicBoomerang"));
        magicBoomerangDown.Add(content.Load<Texture2D>("ItemSprites/MagicBoomerang"));
        bombLeft.Add(content.Load<Texture2D>("ItemSprites/Bomb"));
        bombRight.Add(content.Load<Texture2D>("ItemSprites/Bomb"));
        bombUp.Add(content.Load<Texture2D>("ItemSprites/Bomb"));
        bombDown.Add(content.Load<Texture2D>("ItemSprites/Bomb"));
        for (int i = 1; i <= 4; i++) bombCloud.Add(content.Load<Texture2D>("ItemSprites/Cloud" + i));
        fireLeft.Add(content.Load<Texture2D>("ItemSprites/Fire1"));
        fireRight.Add(content.Load<Texture2D>("ItemSprites/Fire1"));
        fireUp.Add(content.Load<Texture2D>("ItemSprites/Fire1"));
        fireDown.Add(content.Load<Texture2D>("ItemSprites/Fire1"));
        fireLeft.Add(content.Load<Texture2D>("ItemSprites/Fire2"));
        fireRight.Add(content.Load<Texture2D>("ItemSprites/Fire2"));
        fireUp.Add(content.Load<Texture2D>("ItemSprites/Fire2"));
        fireDown.Add(content.Load<Texture2D>("ItemSprites/Fire2"));

        // Add the link frames to the list
        linkFrames[(int)SpriteAction.moveLeft] = linkLeft;
        linkFrames[(int)SpriteAction.moveRight] = linkRight;
        linkFrames[(int)SpriteAction.moveUp] = linkUp;
        linkFrames[(int)SpriteAction.moveDown] = linkDown;
        linkFrames[(int)SpriteAction.useLeft] = linkUseLeft;
        linkFrames[(int)SpriteAction.useRight] = linkUseRight;
        linkFrames[(int)SpriteAction.useUp] = linkUseUp;
        linkFrames[(int)SpriteAction.useDown] = linkUseDown;
        linkFrames[(int)SpriteAction.attackLeft] = linkAttackLeft;
        linkFrames[(int)SpriteAction.attackRight] = linkAttackRight;
        linkFrames[(int)SpriteAction.attackUp] = linkAttackUp;
        linkFrames[(int)SpriteAction.attackDown] = linkAttackDown;
        linkFrames[(int)SpriteAction.damageLeft] = linkLeft;
        linkFrames[(int)SpriteAction.damageRight] = linkRight;
        linkFrames[(int)SpriteAction.damageUp] = linkUp;
        linkFrames[(int)SpriteAction.damageDown] = linkDown;




        // Add example enemy frames to the list
        goriyaFrames[(int)SpriteAction.moveLeft] = goriyaLeft;
        goriyaFrames[(int)SpriteAction.moveRight] = goriyaRight;
        goriyaFrames[(int)SpriteAction.moveUp] = goriyaUp;
        goriyaFrames[(int)SpriteAction.moveDown] = goriyaDown;

        // Add arrow frames to the list
        arrowFrames[(int)SpriteAction.moveLeft] = arrowLeft;
        arrowFrames[(int)SpriteAction.moveRight] = arrowRight;
        arrowFrames[(int)SpriteAction.moveUp] = arrowUp;
        arrowFrames[(int)SpriteAction.moveDown] = arrowDown;

        silverArrowFrames[(int)SpriteAction.moveLeft] = silverArrowLeft;
        silverArrowFrames[(int)SpriteAction.moveRight] = silverArrowRight;
        silverArrowFrames[(int)SpriteAction.moveUp] = silverArrowUp;
        silverArrowFrames[(int)SpriteAction.moveDown] = silverArrowDown;

        boomerangFrames[(int)SpriteAction.moveLeft] = boomerangLeft;
        boomerangFrames[(int)SpriteAction.moveRight] = boomerangRight;
        boomerangFrames[(int)SpriteAction.moveUp] = boomerangUp;
        boomerangFrames[(int)SpriteAction.moveDown] = boomerangDown;

        magicBoomerangFrames[(int)SpriteAction.moveLeft] = magicBoomerangLeft;
        magicBoomerangFrames[(int)SpriteAction.moveRight] = magicBoomerangRight;
        magicBoomerangFrames[(int)SpriteAction.moveUp] = magicBoomerangUp;
        magicBoomerangFrames[(int)SpriteAction.moveDown] = magicBoomerangDown;

        bombFrames[(int)SpriteAction.moveLeft] = bombLeft;
        bombFrames[(int)SpriteAction.moveRight] = bombRight;
        bombFrames[(int)SpriteAction.moveUp] = bombUp;
        bombFrames[(int)SpriteAction.moveDown] = bombDown;
        bombFrames[(int)SpriteAction.bombCloud] = bombCloud;

        fireFrames[(int)SpriteAction.moveLeft] = fireLeft;
        fireFrames[(int)SpriteAction.moveRight] = fireRight;
        fireFrames[(int)SpriteAction.moveUp] = fireUp;
        fireFrames[(int)SpriteAction.moveDown] = fireDown;
    }

    public ISprite CreateGoriyaSprite(Vector2 location)
    {
        return new ConcreteSprite(_spriteBatch, location, goriyaFrames);
    }

    public ISprite CreateLinkSprite(Vector2 location)
    {
        return new ConcreteSprite(_spriteBatch, location, linkFrames);
    }

    public ISprite CreateBarrierTile(Vector2 location)
    {
        return new ConcreteSprite(_spriteBatch, location, barrierFrames);
    }
    public ISprite CreateDungeonStairsTile(Vector2 location)
    {
        return new ConcreteSprite(_spriteBatch, location, dungeonStairsFrames);
    }

    public ISprite CreateWaterTile(Vector2 location)
    {
        return new ConcreteSprite(_spriteBatch, location, waterFrames);
    }

    public ISprite CreateCompassItem(Vector2 location)
    {
        return new ConcreteSprite(_spriteBatch, location, compassFrames);
    }

    public ISprite CreateHeartItem(Vector2 location)
    {
        return new ConcreteSprite(_spriteBatch, location, heartFrames);
    }

    public ISprite CreateKeyItem(Vector2 location)
    {
        return new ConcreteSprite(_spriteBatch, location, keyFrames);
    }

    public ISprite CreateMapItem(Vector2 location)
    {
        return new ConcreteSprite(_spriteBatch, location, mapFrames);
    }

    public ISprite CreateRupiesItem(Vector2 location)
    {
        return new ConcreteSprite(_spriteBatch, location, rupiesFrames);
    }

    public ISprite CreateSwordItem(Vector2 location)
    {
        return new ConcreteSprite(_spriteBatch, location, swordFrames);
    }

    public IDrop CreateKeyDrop(Vector2 location)
    {
        return new Drop(_spriteBatch, location, keyFrames);
    }

    public IProjectile CreateArrowSprite(Vector2 location)
    {
        return new Projectile(_spriteBatch, location, arrowFrames);
    }

    public IProjectile CreateSilverArrowSprite(Vector2 location)
    {
        return new Projectile(_spriteBatch, location, silverArrowFrames);
    }

    public IProjectile CreateBoomerangSprite(Vector2 location)
    {
        return new Projectile(_spriteBatch, location, boomerangFrames);
    }

    public IProjectile CreateMagicBoomerangSprite(Vector2 location)
    {
        return new Projectile(_spriteBatch, location, magicBoomerangFrames);
    }

    public IProjectile CreateBombSprite(Vector2 location)
    {
        return new Projectile(_spriteBatch, location, bombFrames);
    }

    public IProjectile CreateFireSprite(Vector2 location)
    {
        return new Projectile(_spriteBatch, location, fireFrames);
    }

    public ISprite CreateDoorSprite(bool isOpen)
    {
        return new ConcreteSprite(_spriteBatch, new Vector2(420, 69), doorFrames, isOpen);//need someone to create door frames and load them into game
    }
}

