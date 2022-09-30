using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using CSE3902Project.Commands;

public sealed class SpriteFactory : IFactory
    {
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
    private List<Texture2D>[] barrierFrames;
    private List<Texture2D> barrier;
    private List<Texture2D>[] bushFrames;
    private List<Texture2D> bush;
    private List<Texture2D>[] defaultFloorFrames;
    private List<Texture2D> defaultFloor;
    private List<Texture2D>[] dungeonStairsFrames;
    private List<Texture2D> dungeonStairs;
    private List<Texture2D>[] gravestoneFrames;
    private List<Texture2D> gravestone;
    private List<Texture2D>[] waterFrames;
    private List<Texture2D> water;
    private List<Texture2D>[] linkFrames;
    private List<Texture2D> linkRight;
    private List<Texture2D> linkLeft;
    private List<Texture2D> linkUp;
    private List<Texture2D> linkDown;
    private List<Texture2D> linkUse;
    private List<Texture2D> linkUseLeft;
    private List<Texture2D> linkUseRight;
    private List<Texture2D> linkUseUp;
    private List<Texture2D> linkUseDown;
    private List<Texture2D>[] goriyaFrames;
    private List<Texture2D> goriyaRight;
    private List<Texture2D> goriyaLeft;
    private List<Texture2D> goriyaUp;
    private List<Texture2D> goriyaDown;
    private List<Texture2D>[] oktorokFrames;
    private List<Texture2D> oktorokRight;
    private List<Texture2D> oktorokLeft;
    private List<Texture2D> oktorokUp;
    private List<Texture2D> oktorokDown;
    private List<Texture2D>[] peahatFrames;
    // necessary?
    private List<Texture2D> peahatRight;
    private List<Texture2D> peahatLeft;
    private List<Texture2D> peahatUp;
    private List<Texture2D> peahatDown;

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
        bushFrames = new List<Texture2D>[4];
        defaultFloorFrames = new List<Texture2D>[4];
        dungeonStairsFrames = new List<Texture2D>[4];
        gravestoneFrames = new List<Texture2D>[4];
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
        goriyaFrames = new List<Texture2D>[4];
        goriyaLeft = new List<Texture2D>();
        goriyaRight = new List<Texture2D>();
        goriyaDown = new List<Texture2D>();
        goriyaUp = new List<Texture2D>();
        oktorokFrames = new List<Texture2D>[4];
        oktorokLeft = new List<Texture2D>();
        oktorokRight = new List<Texture2D>();
        oktorokDown = new List<Texture2D>();
        oktorokUp = new List<Texture2D>();
        peahatFrames = new List<Texture2D>[4];
        peahatLeft = new List<Texture2D>();
        peahatRight = new List<Texture2D>();
        peahatDown = new List<Texture2D>();
        peahatUp = new List<Texture2D>();
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
        bombFrames = new List<Texture2D>[4];
        bombLeft = new List<Texture2D>();
        bombRight = new List<Texture2D>();
        bombUp = new List<Texture2D>();
        bombDown = new List<Texture2D>();
        fireFrames = new List<Texture2D>[4];
        fireLeft = new List<Texture2D>();
        fireRight = new List<Texture2D>();
        fireUp = new List<Texture2D>();
        fireDown = new List<Texture2D>();
        compass = new List<Texture2D>();
        heart = new List<Texture2D>();
        key =  new List<Texture2D>();
        map = new List<Texture2D>();
        rupies = new List<Texture2D>();
        sword = new List<Texture2D>();
        bush = new List<Texture2D>();
        barrier = new List<Texture2D>();
        defaultFloor = new List<Texture2D>();
        dungeonStairs = new List<Texture2D>();
        gravestone = new List<Texture2D>();
        water = new List<Texture2D>();

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
        bush.Add(content.Load<Texture2D>("TileSprites/Bush"));
        barrier.Add(content.Load<Texture2D>("TileSprites/Barrier"));
        defaultFloor.Add(content.Load<Texture2D>("TileSprites/DefaultFloor"));
        dungeonStairs.Add(content.Load<Texture2D>("TileSprites/DungeonStairs"));
        gravestone.Add(content.Load<Texture2D>("TileSprites/Gravestone"));
        water.Add(content.Load<Texture2D>("TileSprites/WaterMiddle"));

        for (int i = 0; i < 4; i++)
        {
            bushFrames[i] = bush;
            barrierFrames[i] = barrier;
            defaultFloorFrames[i] = defaultFloor;
            dungeonStairsFrames[i] = dungeonStairs;
            gravestoneFrames[i] = gravestone;
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

            goriyaRight.Add(content.Load<Texture2D>("EnemySprites/GoriyaRedRight" + i));
            goriyaLeft.Add(content.Load<Texture2D>("EnemySprites/GoriyaRedLeft" + i));
            goriyaUp.Add(content.Load<Texture2D>("EnemySprites/GoriyaRedUp" + i));
            goriyaDown.Add(content.Load<Texture2D>("EnemySprites/GoriyaRedDown" + i));

            oktorokRight.Add(content.Load<Texture2D>("EnemySprites/OktorokBlueRight" + i));
            oktorokLeft.Add(content.Load<Texture2D>("EnemySprites/OktorokBlueLeft" + i));
            oktorokUp.Add(content.Load<Texture2D>("EnemySprites/OktorokBlueUp" + i));
            oktorokDown.Add(content.Load<Texture2D>("EnemySprites/OktorokBlueDown" + i));

            peahatRight.Add(content.Load<Texture2D>("EnemySprites/Peahat" + i));
            peahatLeft.Add(content.Load<Texture2D>("EnemySprites/Peahat" + i));
            peahatUp.Add(content.Load<Texture2D>("EnemySprites/Peahat" + i));
            peahatDown.Add(content.Load<Texture2D>("EnemySprites/Peahat" + i));
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

        // Add example enemy frames to the list
        goriyaFrames[(int)SpriteAction.moveLeft] = goriyaLeft;
        goriyaFrames[(int)SpriteAction.moveRight] = goriyaRight;
        goriyaFrames[(int)SpriteAction.moveUp] = goriyaUp;
        goriyaFrames[(int)SpriteAction.moveDown] = goriyaDown;

        oktorokFrames[(int)SpriteAction.moveLeft] = oktorokLeft;
        oktorokFrames[(int)SpriteAction.moveRight] = oktorokRight;
        oktorokFrames[(int)SpriteAction.moveUp] = oktorokUp;
        oktorokFrames[(int)SpriteAction.moveDown] = oktorokDown;

        peahatFrames[(int)SpriteAction.moveLeft] = peahatLeft;
        peahatFrames[(int)SpriteAction.moveRight] = peahatRight;
        peahatFrames[(int)SpriteAction.moveUp] = peahatUp;
        peahatFrames[(int)SpriteAction.moveDown] = peahatDown;

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

        fireFrames[(int)SpriteAction.moveLeft] = fireLeft;
        fireFrames[(int)SpriteAction.moveRight] = fireRight;
        fireFrames[(int)SpriteAction.moveUp] = fireUp;
        fireFrames[(int)SpriteAction.moveDown] = fireDown;
    }

    public ISprite CreateGoriyaSprite()
    {
        return new ConcreteSprite(_spriteBatch, new Vector2(250, 340), goriyaFrames);
    }

    public ISprite CreateOktorokSprite()
    {
        return new ConcreteSprite(_spriteBatch, new Vector2(175, 140), oktorokFrames);
    }

    public ISprite CreatePeahatSprite()
    {
        return new ConcreteSprite(_spriteBatch, new Vector2(350, 140), peahatFrames);
    }

    public ISprite CreateLinkSprite()
    {
        return new ConcreteSprite(_spriteBatch, new Vector2(250, 220), linkFrames);
    }

    public ISprite CreateBarrierTile()
    {
        return new ConcreteSprite(_spriteBatch, new Vector2(100, 100), barrierFrames);
    }

    public ISprite CreateBushTile()
    {
        return new ConcreteSprite(_spriteBatch, new Vector2(100, 100), bushFrames);
    }

    public ISprite CreateDefaultFloorTile()
    {
        return new ConcreteSprite(_spriteBatch, new Vector2(100, 100), defaultFloorFrames);
    }

    public ISprite CreateDungeonStairsTile()
    {
        return new ConcreteSprite(_spriteBatch, new Vector2(100, 100), dungeonStairsFrames);
    }

    public ISprite CreateGravestoneTile()
    {
        return new ConcreteSprite(_spriteBatch, new Vector2(100, 100), gravestoneFrames);
    }

    public ISprite CreateWaterTile()
    {
        return new ConcreteSprite(_spriteBatch, new Vector2(100, 100), waterFrames);
    }

    public ISprite CreateCompassItem()
    {
        return new ConcreteSprite(_spriteBatch, new Vector2(300, 200), compassFrames); 
    }

    public ISprite CreateHeartItem()
    {
        return new ConcreteSprite(_spriteBatch, new Vector2(300, 200), heartFrames);
    }

    public ISprite CreateKeyItem()
    {
        return new ConcreteSprite(_spriteBatch, new Vector2(300, 200), keyFrames);
    }

    public ISprite CreateMapItem()
    {
        return new ConcreteSprite(_spriteBatch, new Vector2(300, 200), mapFrames);
    }

    public ISprite CreateRupiesItem()
    {
        return new ConcreteSprite(_spriteBatch, new Vector2(300, 200), rupiesFrames);
    }

    public ISprite CreateSwordItem()
    {
        return new ConcreteSprite(_spriteBatch, new Vector2(300, 200), swordFrames);
    }

    public IItem CreateArrowSprite()
    {
        return new ConcreteItem(_spriteBatch, new Vector2(50, 50), arrowFrames);
    }

    public IItem CreateSilverArrowSprite()
    {
        return new ConcreteItem(_spriteBatch, new Vector2(50, 50), silverArrowFrames);
    }

    public IItem CreateBoomerangSprite()
    {
        return new ConcreteItem(_spriteBatch, new Vector2(50, 50), boomerangFrames);
    }

    public IItem CreateMagicBoomerangSprite()
    {
        return new ConcreteItem(_spriteBatch, new Vector2(50, 50), magicBoomerangFrames);
    }

    public IItem CreateBombSprite()
    {
        return new ConcreteItem(_spriteBatch, new Vector2(50, 50), bombFrames);
    }

    public IItem CreateFireSprite()
    {
        return new ConcreteItem(_spriteBatch, new Vector2(50, 50), fireFrames);
    }
}

