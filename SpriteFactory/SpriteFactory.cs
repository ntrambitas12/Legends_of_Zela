using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Net;

public sealed class SpriteFactory : IFactory
{

    //Blocks
    private List<Texture2D>[] barrierFrames;
    private List<Texture2D> barrier;
    private List<Texture2D>[] stairsFrames;
    private List<Texture2D> stairs;
    private List<Texture2D>[] waterFrames;
    private List<Texture2D> water;
    private List<Texture2D>[] roughFloorFrames;
    private List<Texture2D> roughFloor;
    private List<Texture2D>[] dungeonFloorFrames;
    private List<Texture2D> dungeonFloor;
    private List<Texture2D>[] alternateBackgroundFrames;
    private List<Texture2D> alternateBackground;
    private List<Texture2D>[] invisibleBarrierFrames;
    private List<Texture2D> invisibleBarrier;
    private List<Texture2D>[] openingFrames;
    private List<Texture2D> opening;
    private List<Texture2D>[] textFrames;
    private List<Texture2D> text;

    private List<Texture2D>[] statueRightFrames;
    private List<Texture2D> statueRight;
    private List<Texture2D>[] statueLeftFrames;
    private List<Texture2D> statueLeft;

    private List<Texture2D>[] doorUpFrames;
    private List<Texture2D> doorUpOpen;
    private List<Texture2D>[] doorDownFrames;
    private List<Texture2D> doorDownOpen;
    private List<Texture2D>[] doorRightFrames;
    private List<Texture2D> doorRightOpen;
    private List<Texture2D>[] doorLeftFrames;
    private List<Texture2D> doorLeftOpen;
    private List<Texture2D> doorUpClosed;
    private List<Texture2D> doorDownClosed;
    private List<Texture2D> doorRightClosed;
    private List<Texture2D> doorLeftClosed;

    private List<Texture2D>[] bombDoorUpFrames;
    private List<Texture2D> bombedUp;
    private List<Texture2D>[] bombDoorDownFrames;
    private List<Texture2D> bombedDown;
    private List<Texture2D>[] bombDoorRightFrames;
    private List<Texture2D> bombedRight;
    private List<Texture2D>[] bombDoorLeftFrames;
    private List<Texture2D> bombedLeft;
    private List<Texture2D> unbombedUp;
    private List<Texture2D> unbombedDown;
    private List<Texture2D> unbombedRight;
    private List<Texture2D> unbombedLeft;

    private List<Texture2D>[] wallTopFrames;
    private List<Texture2D> wallTop;
    private List<Texture2D>[] wallTop1Frames;
    private List<Texture2D> wallTop1;
    private List<Texture2D>[] wallTop2Frames;
    private List<Texture2D> wallTop2;
    private List<Texture2D>[] wallBottomFrames;
    private List<Texture2D> wallBottom;
    private List<Texture2D>[] wallBottom1Frames;
    private List<Texture2D> wallBottom1;
    private List<Texture2D>[] wallBottom2Frames;
    private List<Texture2D> wallBottom2;
    private List<Texture2D>[] wallRightFrames;
    private List<Texture2D> wallRight;
    private List<Texture2D>[] wallRight1Frames;
    private List<Texture2D> wallRight1;
    private List<Texture2D>[] wallRight2Frames;
    private List<Texture2D> wallRight2;
    private List<Texture2D>[] wallLeftFrames;
    private List<Texture2D> wallLeft;
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

    private List<Texture2D>[] aquamentusFrames;
    private List<Texture2D> aquamentusLeft;
    private List<Texture2D> aquamentusRight;
    private List<Texture2D>[] wallmasterFrames;
    private List<Texture2D> wallmasterOpen;
    private List<Texture2D> wallmasterClosed;

    private List<Texture2D>[] keeseFrames;
    private List<Texture2D> keese;
    private List<Texture2D>[] stalfosFrames;
    private List<Texture2D> stalfos;
    private List<Texture2D>[] gelFrames;
    private List<Texture2D> gel;
    private List<Texture2D>[] trapFrames;
    private List<Texture2D> trap;
    private List<Texture2D>[] oldManFrames;
    private List<Texture2D> oldMan;


    //Items
    private List<Texture2D>[] bowFrames;
    private List<Texture2D> bow;
    private List<Texture2D>[] compassFrames;
    private List<Texture2D> compass;
    private List<Texture2D>[] keyFrames;
    private List<Texture2D> key;
    private List<Texture2D>[] mapFrames;
    private List<Texture2D> map;
    private List<Texture2D>[] heartContainerFrames;
    private List<Texture2D> heartContainer;
    private List<Texture2D>[] nickelRupiesFrames;
    private List<Texture2D> nickelRupies;
    private List<Texture2D>[] clockFrames;
    private List<Texture2D> clock;
    private List<Texture2D>[] arrowDropFrames;

    private List<Texture2D>[] triforceFrames;
    private List<Texture2D> triforce;
    private List<Texture2D>[] heartFrames;
    private List<Texture2D> heart;
    private List<Texture2D>[] rupiesFrames;
    private List<Texture2D> rupies;
    private List<Texture2D>[] fireFrames;
    private List<Texture2D> fire;


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
    private List<Texture2D>[] boomerangFrames;
    private List<Texture2D> boomerangLeft;
    private List<Texture2D> boomerangRight;
    private List<Texture2D> boomerangUp;
    private List<Texture2D> boomerangDown;
    private List<Texture2D>[] bombFrames;
    private List<Texture2D> bombLeft;
    private List<Texture2D> bombRight;
    private List<Texture2D> bombUp;
    private List<Texture2D> bombDown;
    private List<Texture2D> bombCloud;
    private List<Texture2D>[] swordFrames;
    private List<Texture2D> swordLeft;
    private List<Texture2D> swordRight;
    private List<Texture2D> swordUp;
    private List<Texture2D> swordDown;
    private List<Texture2D>[] fireballFrames;
    private List<Texture2D> fireball1;
    private List<Texture2D> fireball2;
    private List<Texture2D> fireball3;

    //HUDSprites
    private Texture2D HUDKeys;
    private Texture2D HUDMaps;
    private Texture2D HUDBombs;
    private Texture2D HUDRubies;
    private Texture2D HUDItemBorders;
    private Texture2D HUDHearts;
    private Texture2D HUDLinks;
    private Texture2D HUDTriforces;
    private Texture2D HUDBows;
    private Texture2D HUDBoomerangs;


    private SpriteBatch _spriteBatch;
    private SpriteFactory()
    {
        //Blocks
        textFrames = new List<Texture2D>[4];
        barrierFrames = new List<Texture2D>[4];
        stairsFrames = new List<Texture2D>[4];
        waterFrames = new List<Texture2D>[4];
        statueLeftFrames = new List<Texture2D>[4];
        statueRightFrames = new List<Texture2D>[4];
        roughFloorFrames = new List<Texture2D>[4];
        dungeonFloorFrames = new List<Texture2D>[4];
        alternateBackgroundFrames = new List<Texture2D>[4];
        invisibleBarrierFrames = new List<Texture2D>[4];
        openingFrames = new List<Texture2D>[4];

        wallTopFrames = new List<Texture2D>[4];
        wallTop1Frames = new List<Texture2D>[4];
        wallTop2Frames = new List<Texture2D>[4];
        wallBottomFrames = new List<Texture2D>[4];
        wallBottom1Frames = new List<Texture2D>[4];
        wallBottom2Frames = new List<Texture2D>[4];
        wallRightFrames = new List<Texture2D>[4];
        wallRight1Frames = new List<Texture2D>[4];
        wallRight2Frames = new List<Texture2D>[4];
        wallLeftFrames = new List<Texture2D>[4];
        wallLeft1Frames = new List<Texture2D>[4];
        wallLeft2Frames = new List<Texture2D>[4];

        doorUpFrames = new List<Texture2D>[2];
        doorDownFrames = new List<Texture2D>[2];
        doorRightFrames = new List<Texture2D>[2];
        doorLeftFrames = new List<Texture2D>[2];
        bombDoorUpFrames = new List<Texture2D>[2];
        bombDoorDownFrames = new List<Texture2D>[2];
        bombDoorRightFrames = new List<Texture2D>[2];
        bombDoorLeftFrames = new List<Texture2D>[2];

        doorUpOpen = new List<Texture2D>();
        doorDownOpen = new List<Texture2D>();
        doorRightOpen = new List<Texture2D>();
        doorLeftOpen = new List<Texture2D>();
        doorUpClosed = new List<Texture2D>();
        doorDownClosed = new List<Texture2D>();
        doorRightClosed = new List<Texture2D>();
        doorLeftClosed = new List<Texture2D>();
        bombedUp = new List<Texture2D>();
        bombedDown = new List<Texture2D>();
        bombedRight = new List<Texture2D>();
        bombedLeft = new List<Texture2D>();
        unbombedUp = new List<Texture2D>();
        unbombedDown = new List<Texture2D>();
        unbombedRight = new List<Texture2D>();
        unbombedLeft = new List<Texture2D>();

        wallTop = new List<Texture2D>();
        wallTop1 = new List<Texture2D>();
        wallTop2 = new List<Texture2D>();
        wallBottom = new List<Texture2D>();
        wallBottom1 = new List<Texture2D>();
        wallBottom2 = new List<Texture2D>();
        wallRight = new List<Texture2D>();
        wallRight1 = new List<Texture2D>();
        wallRight2 = new List<Texture2D>();
        wallLeft = new List<Texture2D>();
        wallLeft1 = new List<Texture2D>();
        wallLeft2 = new List<Texture2D>();

        dungeonFloor = new List<Texture2D>();
        roughFloor = new List<Texture2D>();
        barrier = new List<Texture2D>();
        stairs = new List<Texture2D>();
        water = new List<Texture2D>();
        statueRight = new List<Texture2D>();
        statueLeft = new List<Texture2D>();
        alternateBackground = new List<Texture2D>();
        invisibleBarrier = new List<Texture2D>();
        opening = new List<Texture2D>();
        text = new List<Texture2D>();


        //Enemies
        goriyaFrames = new List<Texture2D>[4];
        goriyaLeft = new List<Texture2D>();
        goriyaRight = new List<Texture2D>();
        goriyaDown = new List<Texture2D>();
        goriyaUp = new List<Texture2D>();

        aquamentusFrames = new List<Texture2D>[4];
        aquamentusLeft = new List<Texture2D>();
        aquamentusRight = new List<Texture2D>();
        wallmasterFrames = new List<Texture2D>[4];
        wallmasterOpen = new List<Texture2D>();
        wallmasterClosed = new List<Texture2D>();

        gelFrames = new List<Texture2D>[4];
        gel = new List<Texture2D>();
        keeseFrames = new List<Texture2D>[4];
        keese = new List<Texture2D>();
        stalfosFrames = new List<Texture2D>[4];
        stalfos = new List<Texture2D>();
        trapFrames = new List<Texture2D>[4];
        trap = new List<Texture2D>();
        oldManFrames = new List<Texture2D>[4];
        oldMan = new List<Texture2D>();


        //Items
        bowFrames = new List<Texture2D>[4];
        bow = new List<Texture2D>();
        clockFrames = new List<Texture2D>[4];
        clock = new List<Texture2D>();
        compassFrames = new List<Texture2D>[4];
        compass = new List<Texture2D>();
        heartContainerFrames = new List<Texture2D>[4];
        heartContainer = new List<Texture2D>();
        keyFrames = new List<Texture2D>[4];
        key = new List<Texture2D>();
        mapFrames = new List<Texture2D>[4];
        map = new List<Texture2D>();
        nickelRupiesFrames = new List<Texture2D>[4];
        nickelRupies = new List<Texture2D>();
        arrowDropFrames = new List<Texture2D>[4];


        //Animated Items
        fireFrames = new List<Texture2D>[4];
        fire = new List<Texture2D>();
        heartFrames = new List<Texture2D>[4];
        heart = new List<Texture2D>();
        rupiesFrames = new List<Texture2D>[4];
        rupies = new List<Texture2D>();
        triforceFrames = new List<Texture2D>[4];
        triforce = new List<Texture2D>();


        //Playables
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

        //Projectiles
        arrowFrames = new List<Texture2D>[4];
        arrowLeft = new List<Texture2D>();
        arrowRight = new List<Texture2D>();
        arrowUp = new List<Texture2D>();
        arrowDown = new List<Texture2D>();
        boomerangFrames = new List<Texture2D>[4];
        boomerangLeft = new List<Texture2D>();
        boomerangRight = new List<Texture2D>();
        boomerangUp = new List<Texture2D>();
        boomerangDown = new List<Texture2D>();
        bombFrames = new List<Texture2D>[5];
        bombLeft = new List<Texture2D>();
        bombRight = new List<Texture2D>();
        bombUp = new List<Texture2D>();
        bombDown = new List<Texture2D>();
        bombCloud = new List<Texture2D>();
        swordFrames = new List<Texture2D>[4];
        swordLeft = new List<Texture2D>();
        swordRight = new List<Texture2D>();
        swordUp = new List<Texture2D>();
        swordDown = new List<Texture2D>();
        fireballFrames = new List<Texture2D>[3];
        fireball1 = new List<Texture2D>();
        fireball2 = new List<Texture2D>();
        fireball3 = new List<Texture2D>();

    }

    private static readonly SpriteFactory instance = new SpriteFactory();
    public static SpriteFactory Instance { get { return instance; } }

    public void LoadAllContent(ContentManager content, SpriteBatch spriteBatch)
    {
        _spriteBatch = spriteBatch;

        //Blocks
        text.Add(content.Load<Texture2D>("DungeonSprites/Text"));
        opening.Add(content.Load<Texture2D>("BlockSprites/Black"));
        invisibleBarrier.Add(content.Load<Texture2D>("BlockSprites/InvisibleBarrier"));
        alternateBackground.Add(content.Load<Texture2D>("DungeonSprites/Room07"));
        dungeonFloor.Add(content.Load<Texture2D>("DungeonSprites/DungeonFloor"));
        barrier.Add(content.Load<Texture2D>("BlockSprites/Barrier"));
        stairs.Add(content.Load<Texture2D>("BlockSprites/DungeonStairs"));
        water.Add(content.Load<Texture2D>("BlockSprites/Water"));
        roughFloor.Add(content.Load<Texture2D>("BlockSprites/RoughFloor"));
        statueRight.Add(content.Load<Texture2D>("BlockSprites/StatueRight"));
        statueLeft.Add(content.Load<Texture2D>("BlockSprites/StatueLeft"));
        doorUpOpen.Add(content.Load<Texture2D>("DungeonSprites/DoorTopOpen"));
        doorDownOpen.Add(content.Load<Texture2D>("DungeonSprites/DoorBottomOpen"));
        doorRightOpen.Add(content.Load<Texture2D>("DungeonSprites/DoorRightOpen"));
        doorLeftOpen.Add(content.Load<Texture2D>("DungeonSprites/DoorLeftOpen"));
        bombedUp.Add(content.Load<Texture2D>("DungeonSprites/DoorTopBombed"));
        bombedDown.Add(content.Load<Texture2D>("DungeonSprites/DoorBottomBombed"));
        bombedRight.Add(content.Load<Texture2D>("DungeonSprites/DoorRightBombed"));
        bombedLeft.Add(content.Load<Texture2D>("DungeonSprites/DoorLeftBombed"));
        unbombedUp.Add(content.Load<Texture2D>("DungeonSprites/DoorTopUnbombed"));
        unbombedDown.Add(content.Load<Texture2D>("DungeonSprites/DoorBottomUnbombed"));
        unbombedRight.Add(content.Load<Texture2D>("DungeonSprites/DoorRightUnbombed"));
        unbombedLeft.Add(content.Load<Texture2D>("DungeonSprites/DoorLeftUnbombed"));
        doorUpClosed.Add(content.Load<Texture2D>("DungeonSprites/DoorTopClosed"));
        doorDownClosed.Add(content.Load<Texture2D>("DungeonSprites/DoorBottomClosed"));
        doorRightClosed.Add(content.Load<Texture2D>("DungeonSprites/DoorRightClosed"));
        doorLeftClosed.Add(content.Load<Texture2D>("DungeonSprites/DoorLeftClosed"));
        wallTop.Add(content.Load<Texture2D>("DungeonSprites/WallTop0"));
        wallTop1.Add(content.Load<Texture2D>("DungeonSprites/WallTop1"));
        wallTop2.Add(content.Load<Texture2D>("DungeonSprites/WallTop2"));
        wallBottom.Add(content.Load<Texture2D>("DungeonSprites/WallBottom0"));
        wallBottom1.Add(content.Load<Texture2D>("DungeonSprites/WallBottom1"));
        wallBottom2.Add(content.Load<Texture2D>("DungeonSprites/WallBottom2"));
        wallRight.Add(content.Load<Texture2D>("DungeonSprites/WallRight0"));
        wallRight1.Add(content.Load<Texture2D>("DungeonSprites/WallRight1"));
        wallRight2.Add(content.Load<Texture2D>("DungeonSprites/WallRight2"));
        wallLeft.Add(content.Load<Texture2D>("DungeonSprites/WallLeft0"));
        wallLeft1.Add(content.Load<Texture2D>("DungeonSprites/WallLeft1"));
        wallLeft2.Add(content.Load<Texture2D>("DungeonSprites/WallLeft2"));


        //Enemies
        gel.Add(content.Load<Texture2D>("EnemySprites/Gel1"));
        gel.Add(content.Load<Texture2D>("EnemySprites/Gel2"));
        keese.Add(content.Load<Texture2D>("EnemySprites/Keese1"));
        keese.Add(content.Load<Texture2D>("EnemySprites/Keese2"));
        oldMan.Add(content.Load<Texture2D>("EnemySprites/OldMan"));
        stalfos.Add(content.Load<Texture2D>("EnemySprites/Stalfos1"));
        stalfos.Add(content.Load<Texture2D>("EnemySprites/Stalfos2"));
        trap.Add(content.Load<Texture2D>("EnemySprites/Trap"));
        wallmasterOpen.Add(content.Load<Texture2D>("EnemySprites/WallmasterULOpen"));
        wallmasterClosed.Add(content.Load<Texture2D>("EnemySprites/WallmasterULClosed"));


        //Items
        //This first section is for animated items
        heart.Add(content.Load<Texture2D>("ItemSprites/Heart1"));
        heart.Add(content.Load<Texture2D>("ItemSprites/Heart2"));
        heartFrames[0] = heart;
        triforce.Add(content.Load<Texture2D>("ItemSprites/Triforce1"));
        triforce.Add(content.Load<Texture2D>("ItemSprites/Triforce2"));
        triforceFrames[0] = triforce;
        rupies.Add(content.Load<Texture2D>("ItemSprites/BlinkingRuby1"));
        rupies.Add(content.Load<Texture2D>("ItemSprites/BlinkingRuby2"));
        rupiesFrames[0] = rupies;
        fire.Add(content.Load<Texture2D>("ItemSprites/Fire1"));
        fire.Add(content.Load<Texture2D>("ItemSprites/Fire2"));
        fireFrames[0] = fire;
        //This second section is for items with only 1 frame of animation
        heartContainer.Add(content.Load<Texture2D>("ItemSprites/HeartContainer"));
        bow.Add(content.Load<Texture2D>("ItemSprites/Bow"));
        compass.Add(content.Load<Texture2D>("ItemSprites/Compass"));
        key.Add(content.Load<Texture2D>("ItemSprites/Key"));
        map.Add(content.Load<Texture2D>("ItemSprites/Map"));
        clock.Add(content.Load<Texture2D>("ItemSprites/Clock"));
        nickelRupies.Add(content.Load<Texture2D>("ItemSprites/5Rupies"));


        //Projectiles
        arrowLeft.Add(content.Load<Texture2D>("ItemSprites/ArrowLeft"));
        arrowRight.Add(content.Load<Texture2D>("ItemSprites/ArrowRight"));
        arrowUp.Add(content.Load<Texture2D>("ItemSprites/ArrowUp"));
        arrowDown.Add(content.Load<Texture2D>("ItemSprites/ArrowDown"));
        swordLeft.Add(content.Load<Texture2D>("ItemSprites/SwordLeft"));
        swordRight.Add(content.Load<Texture2D>("ItemSprites/SwordRight"));
        swordUp.Add(content.Load<Texture2D>("ItemSprites/SwordUp"));
        swordDown.Add(content.Load<Texture2D>("ItemSprites/SwordDown"));
        boomerangLeft.Add(content.Load<Texture2D>("ItemSprites/BoomerangLeft"));
        boomerangLeft.Add(content.Load<Texture2D>("ItemSprites/BoomerangDown"));
        boomerangLeft.Add(content.Load<Texture2D>("ItemSprites/BoomerangRight"));
        boomerangLeft.Add(content.Load<Texture2D>("ItemSprites/BoomerangUp"));
        boomerangRight.Add(content.Load<Texture2D>("ItemSprites/BoomerangRight"));
        boomerangRight.Add(content.Load<Texture2D>("ItemSprites/BoomerangUp"));
        boomerangRight.Add(content.Load<Texture2D>("ItemSprites/BoomerangLeft"));
        boomerangRight.Add(content.Load<Texture2D>("ItemSprites/BoomerangDown"));
        boomerangUp.Add(content.Load<Texture2D>("ItemSprites/BoomerangUp"));
        boomerangUp.Add(content.Load<Texture2D>("ItemSprites/BoomerangLeft"));
        boomerangUp.Add(content.Load<Texture2D>("ItemSprites/BoomerangDown"));
        boomerangUp.Add(content.Load<Texture2D>("ItemSprites/BoomerangRight"));
        boomerangDown.Add(content.Load<Texture2D>("ItemSprites/BoomerangDown"));
        boomerangDown.Add(content.Load<Texture2D>("ItemSprites/BoomerangRight"));
        boomerangDown.Add(content.Load<Texture2D>("ItemSprites/BoomerangUp"));
        boomerangDown.Add(content.Load<Texture2D>("ItemSprites/BoomerangLeft"));
        bombLeft.Add(content.Load<Texture2D>("ItemSprites/Bomb"));
        bombRight.Add(content.Load<Texture2D>("ItemSprites/Bomb"));
        bombUp.Add(content.Load<Texture2D>("ItemSprites/Bomb"));
        bombDown.Add(content.Load<Texture2D>("ItemSprites/Bomb"));
        bombCloud.Add(content.Load<Texture2D>("ItemSprites/Cloud1"));
        bombCloud.Add(content.Load<Texture2D>("ItemSprites/Cloud2"));
        bombCloud.Add(content.Load<Texture2D>("ItemSprites/Cloud3"));
        bombCloud.Add(content.Load<Texture2D>("ItemSprites/Cloud4"));
        fireball1.Add(content.Load<Texture2D>("ItemSprites/fireball1"));
        fireball2.Add(content.Load<Texture2D>("ItemSprites/fireball2"));
        fireball3.Add(content.Load<Texture2D>("ItemSprites/fireball3"));

        //HUD Elements
        HUDItemBorders = content.Load<Texture2D>("HUDElements/HUDItemBorder");
        HUDRubies = content.Load<Texture2D>("HUDElements/HUDRuby");
        HUDBombs = content.Load<Texture2D>("HUDElements/HUDBomb");
        HUDKeys = content.Load<Texture2D>("HUDElements/HUDKey");
        HUDHearts = content.Load<Texture2D>("HUDElements/Heart1");
        HUDMaps = content.Load<Texture2D>("HUDElements/HUDMap0");
        HUDLinks = content.Load<Texture2D>("HUDElements/LinkOnMap");
        HUDTriforces = content.Load<Texture2D>("HUDElements/TriforceOnMap");
        HUDBows = content.Load<Texture2D>("ItemSprites/Bow");
        HUDBoomerangs = content.Load<Texture2D>("ItemSprites/BoomerangRight");

        //Populate Blocks and Items
        for (int i = 0; i < 4; i++)
        {
            dungeonFloorFrames[i] = dungeonFloor;
            barrierFrames[i] = barrier;
            stairsFrames[i] = stairs;
            waterFrames[i] = water;
            statueRightFrames[i] = statueRight;
            statueLeftFrames[i] = statueLeft;
            roughFloorFrames[i] = roughFloor;
            alternateBackgroundFrames[i] = alternateBackground;
            invisibleBarrierFrames[i] = invisibleBarrier;

            wallTopFrames[i] = wallTop;
            wallTop1Frames[i] = wallTop1;
            wallTop2Frames[i] = wallTop2;
            wallBottomFrames[i] = wallBottom;
            wallBottom1Frames[i] = wallBottom1;
            wallBottom2Frames[i] = wallBottom2;
            wallRightFrames[i] = wallRight;
            wallRight1Frames[i] = wallRight1;
            wallRight2Frames[i] = wallRight2;
            wallLeftFrames[i] = wallLeft;
            wallLeft1Frames[i] = wallLeft1;
            wallLeft2Frames[i] = wallLeft2;

           

            arrowDropFrames[i] = arrowUp;
            bowFrames[i] = bow;
            heartContainerFrames[i] = heartContainer;
            compassFrames[i] = compass;
            keyFrames[i] = key;
            mapFrames[i] = map;
            clockFrames[i] = clock;
            nickelRupiesFrames[i] = nickelRupies;
            oldManFrames[i] = oldMan;
            openingFrames[i] = opening;
            textFrames[i] = text;
        }

            doorUpFrames[0] = doorUpOpen;
            doorDownFrames[0] = doorDownOpen;
            doorRightFrames[0] = doorRightOpen;
            doorLeftFrames[0] = doorLeftOpen;
            bombDoorUpFrames[0] = bombedUp;
            bombDoorDownFrames[0] = bombedDown;
            bombDoorRightFrames[0] = bombedRight;
            bombDoorLeftFrames[0] = bombedLeft;
            bombDoorUpFrames[1] = unbombedUp;
            bombDoorDownFrames[1] = unbombedDown;
            bombDoorRightFrames[1] = unbombedRight;
            bombDoorLeftFrames[1] = unbombedLeft;
            doorUpFrames[1] = doorUpClosed;
            doorDownFrames[1] = doorDownClosed;
            doorRightFrames[1] = doorRightClosed;
            doorLeftFrames[1] = doorLeftClosed;

        //Populate Enemies and Playables
        for (int i = 1; i <= 2; i++)
        {
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

            aquamentusRight.Add(content.Load<Texture2D>("EnemySprites/AquamentusRight" + i));
            aquamentusLeft.Add(content.Load<Texture2D>("EnemySprites/AquamentusLeft" + i));
        }


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


        // Add enemy frames to the list
        goriyaFrames[(int)SpriteAction.moveLeft] = goriyaLeft;
        goriyaFrames[(int)SpriteAction.moveRight] = goriyaRight;
        goriyaFrames[(int)SpriteAction.moveUp] = goriyaUp;
        goriyaFrames[(int)SpriteAction.moveDown] = goriyaDown;
        gelFrames[(int)SpriteAction.moveLeft] = gel;
        gelFrames[(int)SpriteAction.moveRight] = gel;
        gelFrames[(int)SpriteAction.moveUp] = gel;
        gelFrames[(int)SpriteAction.moveDown] = gel;
        stalfosFrames[(int)SpriteAction.moveLeft] = stalfos;
        stalfosFrames[(int)SpriteAction.moveRight] = stalfos;
        stalfosFrames[(int)SpriteAction.moveUp] = stalfos;
        stalfosFrames[(int)SpriteAction.moveDown] = stalfos;
        keeseFrames[(int)SpriteAction.moveLeft] = keese;
        keeseFrames[(int)SpriteAction.moveRight] = keese;
        keeseFrames[(int)SpriteAction.moveUp] = keese;
        keeseFrames[(int)SpriteAction.moveDown] = keese;
        trapFrames[(int)SpriteAction.moveLeft] = trap;
        trapFrames[(int)SpriteAction.moveRight] = trap;
        trapFrames[(int)SpriteAction.moveUp] = trap;
        trapFrames[(int)SpriteAction.moveDown] = trap;
        wallmasterFrames[(int)SpriteAction.moveLeft] = wallmasterOpen;
        wallmasterFrames[(int)SpriteAction.moveRight] = wallmasterClosed;
        wallmasterFrames[(int)SpriteAction.moveUp] = wallmasterOpen;
        wallmasterFrames[(int)SpriteAction.moveDown] = wallmasterClosed;
        aquamentusFrames[(int)SpriteAction.moveLeft] = aquamentusLeft;
        aquamentusFrames[(int)SpriteAction.moveRight] = aquamentusRight;

        // Add arrow frames to the list
        arrowFrames[(int)SpriteAction.moveLeft] = arrowLeft;
        arrowFrames[(int)SpriteAction.moveRight] = arrowRight;
        arrowFrames[(int)SpriteAction.moveUp] = arrowUp;
        arrowFrames[(int)SpriteAction.moveDown] = arrowDown;
        // Add sword frames to the list
        swordFrames[(int)SpriteAction.moveLeft] = swordLeft;
        swordFrames[(int)SpriteAction.moveRight] = swordRight;
        swordFrames[(int)SpriteAction.moveUp] = swordUp;
        swordFrames[(int)SpriteAction.moveDown] = swordDown;
        // Add fireball frames to the list
        fireballFrames[(int)SpriteAction.moveLeft] = fireball1;
        fireballFrames[(int)SpriteAction.moveRight] = fireball2;
        fireballFrames[(int)SpriteAction.moveUp] = fireball3;
        //Needs to be reworked to rotate...
        boomerangFrames[(int)SpriteAction.moveLeft] = boomerangLeft;
        boomerangFrames[(int)SpriteAction.moveRight] = boomerangRight;
        boomerangFrames[(int)SpriteAction.moveUp] = boomerangUp;
        boomerangFrames[(int)SpriteAction.moveDown] = boomerangDown;
        //Needs to be reworked to explode...
        bombFrames[(int)SpriteAction.moveLeft] = bombLeft;
        bombFrames[(int)SpriteAction.moveRight] = bombRight;
        bombFrames[(int)SpriteAction.moveUp] = bombUp;
        bombFrames[(int)SpriteAction.moveDown] = bombDown;
        bombFrames[(int)SpriteAction.bombCloud] = bombCloud;
    }

    //------------------------------PRIVATE COLLISION METHODS------------------------------
    //creates an entity with a default collider
    private ISprite CreateEntityWithCollision(Vector2 location, List<Texture2D>[] frames1)
    {

        ISprite entity = new ConcreteSprite(_spriteBatch, location, frames1);
        Rectangle collisionRect = frames1[0][0].Bounds;

        int x = 2 * frames1[0][0].Width;
        int y = 2 * frames1[0][0].Height;
        collisionRect = new Rectangle(0, 0, x, y);

        CollisionManager.Instance.AddCollisions(entity, ColliderType.Normal, collisionRect);

        return entity;
    }
    //creates an entity with the specified collider
    private ISprite CreateEntityWithCollision(Vector2 location, List<Texture2D>[] frames1, ColliderType collider)
    {

        ISprite entity = new ConcreteSprite(_spriteBatch, location, frames1);
        Rectangle collisionRect = frames1[0][0].Bounds;

        int x = 2 * frames1[0][0].Width;
        int y = 2 * frames1[0][0].Height;
        collisionRect = new Rectangle(0, 0, x, y);

        CollisionManager.Instance.AddCollisions(entity, collider, collisionRect);

        return entity;
    }

    //------------------------------PRIVATE AI METHODS------------------------------
    //gives entity an ai component, ai type is an enum
    private ISprite AddAI(ISprite entity, AIType ai)
    {
        AIManager.Instance.AddAI(entity, ai);
        return entity;
    }

    //Blocks
    public ISprite CreateTextBlock(Vector2 location)
    {
        return CreateEntityWithCollision(location, textFrames);
    }
    public ISprite CreateOpeningBlock(Vector2 location)
    {
        return CreateEntityWithCollision(location, openingFrames);
    }
    public ISprite CreateAlternateBackgroundBlock(Vector2 location)
    {
        return CreateEntityWithCollision(location, alternateBackgroundFrames);
    }
    public ISprite CreateInvisibleBarrierBlock(Vector2 location)
    {
        return CreateEntityWithCollision(location, invisibleBarrierFrames);
    }
    public ISprite CreateDungeonFloorBlock(Vector2 location)
    {
        return CreateEntityWithCollision(location, dungeonFloorFrames);
    }
    public ISprite CreateBarrierBlock(Vector2 location)
    {
        return CreateEntityWithCollision(location, barrierFrames);
    }
    public ISprite CreateStairsBlock(Vector2 location)
    {
        return CreateEntityWithCollision(location, stairsFrames);
    }
    public ISprite CreateWaterBlock(Vector2 location)
    {
        return CreateEntityWithCollision(location, waterFrames);
    }
    public ISprite CreateRoughFloorBlock(Vector2 location)
    {
        return new ConcreteSprite(_spriteBatch, location, roughFloorFrames);
    }
    public ISprite CreateStatueRightBlock(Vector2 location)
    {
        return CreateEntityWithCollision(location, statueRightFrames);
    }
    public ISprite CreateStatueLeftBlock(Vector2 location)
    {
        return CreateEntityWithCollision(location, statueLeftFrames);
    }
    public ISprite CreateWallTopBlock(Vector2 location)
    {
        return CreateEntityWithCollision(location, wallTopFrames);
    }
    public ISprite CreateWallTop1Block(Vector2 location)
    {
        return CreateEntityWithCollision(location, wallTop1Frames);
    }
    public ISprite CreateWallTop2Block(Vector2 location)
    {
        return CreateEntityWithCollision(location, wallTop2Frames);
    }
    public ISprite CreateWallBottomBlock(Vector2 location)
    {
        return CreateEntityWithCollision(location, wallBottomFrames);
    }
    public ISprite CreateWallBottom1Block(Vector2 location)
    {
        return CreateEntityWithCollision(location, wallBottom1Frames);
    }
    public ISprite CreateWallBottom2Block(Vector2 location)
    {
        return CreateEntityWithCollision(location, wallBottom2Frames);
    }
    public ISprite CreateWallRightBlock(Vector2 location)
    {
        return CreateEntityWithCollision(location, wallRightFrames);
    }
    public ISprite CreateWallRight1Block(Vector2 location)
    {
        return CreateEntityWithCollision(location, wallRight1Frames);
    }
    public ISprite CreateWallRight2Block(Vector2 location)
    {
        return CreateEntityWithCollision(location, wallRight2Frames);
    }
    public ISprite CreateWallLeftBlock(Vector2 location)
    {
        return CreateEntityWithCollision(location, wallLeftFrames);
    }
    public ISprite CreateWallLeft1Block(Vector2 location)
    {
        return CreateEntityWithCollision(location, wallLeft1Frames);
    }
    public ISprite CreateWallLeft2Block(Vector2 location)
    {
        return CreateEntityWithCollision(location, wallLeft2Frames);
    }
    public ISprite CreateDoorUpBlock(Vector2 location, bool isOpen)
    {
        IConcreteSprite door = (IConcreteSprite) CreateEntityWithCollision(location, doorUpFrames);
        door.SetDirection(SpriteAction.up);
        return door;
    }
    public ISprite CreateDoorDownBlock(Vector2 location, bool isOpen)
    {
        IConcreteSprite door = (IConcreteSprite) CreateEntityWithCollision(location, doorDownFrames);
        door.SetDirection(SpriteAction.down);
        return door;
    }
    public ISprite CreateDoorLeftBlock(Vector2 location, bool isOpen)
    {
        IConcreteSprite door = (IConcreteSprite) CreateEntityWithCollision(location, doorLeftFrames);
        door.SetDirection(SpriteAction.left);
        return door;
    }
    public ISprite CreateDoorRightBlock(Vector2 location, bool isOpen)
    {
        IConcreteSprite door = (IConcreteSprite) CreateEntityWithCollision(location, doorRightFrames);
        door.SetDirection(SpriteAction.right);
        return door;
    }
    public ISprite CreateBombableUpBlock(Vector2 location, bool isBombed)
    {
        IConcreteSprite door = (IConcreteSprite) CreateEntityWithCollision(location, bombDoorUpFrames);
        door.SetDirection(SpriteAction.up);
        return door;
    }
    public ISprite CreateBombableDownBlock(Vector2 location, bool isBombed)
    {
        IConcreteSprite door = (IConcreteSprite)CreateEntityWithCollision(location, bombDoorDownFrames);
        door.SetDirection(SpriteAction.down);
        return door;
    }
    public ISprite CreateBombableRightBlock(Vector2 location, bool isBombed)
    {
        IConcreteSprite door = (IConcreteSprite)CreateEntityWithCollision(location, bombDoorRightFrames);
        door.SetDirection(SpriteAction.right);
        return door;
    }
    public ISprite CreateBombableLeftBlock(Vector2 location, bool isBombed)
    {
        IConcreteSprite door = (IConcreteSprite)CreateEntityWithCollision(location, bombDoorLeftFrames);
        door.SetDirection(SpriteAction.left);
        return door;
    }
    public ISprite CreateFireBlock(Vector2 location)
    {
        return CreateEntityWithCollision(location, fireFrames);
    }


    //Enemies
    public ISprite CreateGoriyaSprite(Vector2 location)
    {
        IConcreteSprite goriya = (IConcreteSprite) CreateEntityWithCollision(location, goriyaFrames);
        goriya.health = 2;
        return AddAI(goriya, AIType.RandomMove);
    }
    public ISprite CreateKeeseSprite(Vector2 location)
    {
        IConcreteSprite keese = (IConcreteSprite) CreateEntityWithCollision(location, keeseFrames, ColliderType.Keese);
        keese.health = 1;
        return AddAI(keese, AIType.AlwaysRandomMove);
    }
    public ISprite CreateStalfosSprite(Vector2 location)
    {
        IConcreteSprite stalfos = (IConcreteSprite) CreateEntityWithCollision(location, stalfosFrames);
        stalfos.health = 1;
        return AddAI(stalfos, AIType.RandomMove);
    }
    public ISprite CreateGelSprite(Vector2 location)
    {
        IConcreteSprite gel = (IConcreteSprite) CreateEntityWithCollision(location, gelFrames);
        gel.health = 1;
 return AddAI(gel, AIType.RandomMove);
    }
    public ISprite CreateAquamentusSprite(Vector2 location)
    {
        IConcreteSprite aquamentus = (IConcreteSprite) CreateEntityWithCollision(location, aquamentusFrames);
        aquamentus.health = 4;
        aquamentus.maxHealth = 4;
        return AddAI(aquamentus, AIType.RandomMove);
    }
    public ISprite CreateBladeTrapSprite(Vector2 location)
    {
        IConcreteSprite bladeTrap = (IConcreteSprite) CreateEntityWithCollision(location, trapFrames);
        bladeTrap.health = -1;
        return AddAI(bladeTrap, AIType.RandomMove);
    }
    public ISprite CreateWallmasterSprite(Vector2 location)
    {
        IConcreteSprite wallmaster = (IConcreteSprite) CreateEntityWithCollision(location, wallmasterFrames);
        wallmaster.health = 2;
        return AddAI(wallmaster, AIType.RandomMove);
    }
    public ISprite CreateOldManSprite(Vector2 location)
    {
        IConcreteSprite oldMan = (IConcreteSprite) CreateEntityWithCollision(location, oldManFrames);
        oldMan.health = -1;
        return AddAI(oldMan, AIType.RandomMove);
    }
    public ISprite CreateTrapSprite(Vector2 location)
    {
        IConcreteSprite trap = (IConcreteSprite) CreateEntityWithCollision(location, trapFrames);
        trap.health = -1;
        return AddAI(trap, AIType.RandomMove);
    }


    //Drops
    public ISprite CreateArrowDrop(Vector2 location)
    {
        IDrop arrow = new Drop(_spriteBatch, location, new List<Texture2D>[] { new List<Texture2D> { arrowFrames[2][0] } });

        Rectangle collisionRect = arrowFrames[0][0].Bounds;
        ICollision collisionObject = new Collision(arrow, collisionRect);
        arrow.collider = collisionObject;
        arrow.collider.UpdateCollisionPosition();

        arrow.SetItemType(new ArrowDropType(arrow)); 
        return arrow;
    }
    public ISprite CreateNickelRubyDrop(Vector2 location)
    {
        IDrop nickelRuby = new Drop(_spriteBatch, location, nickelRupiesFrames);

        Rectangle collisionRect = nickelRupiesFrames[0][0].Bounds;
        ICollision collisionObject = new Collision(nickelRuby, collisionRect);
        nickelRuby.collider = collisionObject;
        nickelRuby.collider.UpdateCollisionPosition();

        nickelRuby.SetItemType(new NickelRubyDropType(nickelRuby));
        return nickelRuby;
    }
    public ISprite CreateBoomerangDrop(Vector2 location)
    {
        IDrop boomerang = new Drop(_spriteBatch, location, new List<Texture2D>[] { new List<Texture2D> { boomerangFrames[0][0] } });

        Rectangle collisionRect = boomerangFrames[0][0].Bounds;
        ICollision collisionObject = new Collision(boomerang, collisionRect);
        boomerang.collider = collisionObject;
        boomerang.collider.UpdateCollisionPosition();

        boomerang.SetItemType(new BoomerangDropType(boomerang));
        return boomerang;
    }
    public ISprite CreateBombDrop(Vector2 location)
    {
        IDrop bomb = new Drop(_spriteBatch, location, bombFrames);

        Rectangle collisionRect = bombFrames[0][0].Bounds;
        ICollision collisionObject = new Collision(bomb, collisionRect);
        bomb.collider = collisionObject;
        bomb.collider.UpdateCollisionPosition();

        bomb.SetItemType(new BombDropType(bomb));
        return bomb;
    }
    public ISprite CreateRubyDrop(Vector2 location)
    {
        IDrop ruby = new Drop(_spriteBatch, location, rupiesFrames);

        Rectangle collisionRect = rupiesFrames[0][0].Bounds;
        ICollision collisionObject = new Collision(ruby, collisionRect);
        ruby.collider = collisionObject;
        ruby.collider.UpdateCollisionPosition();

        ruby.SetItemType(new RubyDropType(ruby));
        return ruby;
    }
    public ISprite CreateBowDrop(Vector2 location)
    {
        IDrop bow = new Drop(_spriteBatch, location, bowFrames);

        Rectangle collisionRect = bowFrames[0][0].Bounds;
        ICollision collisionObject = new Collision(bow, collisionRect);
        bow.collider = collisionObject;
        bow.collider.UpdateCollisionPosition();

        bow.SetItemType(new BowDropType(bow));
        return bow;
    }
    public ISprite CreateClockDrop(Vector2 location)
    {
        IDrop clock = new Drop(_spriteBatch, location, clockFrames);

        Rectangle collisionRect = clockFrames[0][0].Bounds;
        ICollision collisionObject = new Collision(clock, collisionRect);
        clock.collider = collisionObject;
        clock.collider.UpdateCollisionPosition();

        clock.SetItemType(new ClockDropType(clock));
        return clock;
    }
    public ISprite CreateCompassDrop(Vector2 location)
    {
        IDrop compass = new Drop(_spriteBatch, location, compassFrames);

        Rectangle collisionRect = compassFrames[0][0].Bounds;
        ICollision collisionObject = new Collision(compass, collisionRect);
        compass.collider = collisionObject;
        compass.collider.UpdateCollisionPosition();

        compass.SetItemType(new CompassDropType(compass));
        return compass;
    }
    public ISprite CreateHeartDrop(Vector2 location)
    {
        IDrop heart = new Drop(_spriteBatch, location, heartFrames);

        Rectangle collisionRect = heartFrames[0][0].Bounds;
        ICollision collisionObject = new Collision(heart, collisionRect);
        heart.collider = collisionObject;
        heart.collider.UpdateCollisionPosition();

        heart.SetItemType(new HeartDropType(heart));
        return heart;
    }
    public ISprite CreateHeartContainerDrop(Vector2 location)
    {
        IDrop heartContainer = new Drop(_spriteBatch, location, heartContainerFrames);

        Rectangle collisionRect = heartContainerFrames[0][0].Bounds;
        ICollision collisionObject = new Collision(heartContainer, collisionRect);
        heartContainer.collider = collisionObject;
        heartContainer.collider.UpdateCollisionPosition();

        heartContainer.SetItemType(new HeartContainerDropType(heartContainer));
        return heartContainer;
    }
    public ISprite CreateKeyDrop(Vector2 location)
    {
        IDrop key = new Drop(_spriteBatch, location, keyFrames);

        Rectangle collisionRect = keyFrames[0][0].Bounds;
        ICollision collisionObject = new Collision(key, collisionRect);
        key.collider = collisionObject;
        key.collider.UpdateCollisionPosition();

        key.SetItemType(new KeyDropType(key));
        return key;
    }
    public ISprite CreateMapDrop(Vector2 location)
    {
        IDrop map = new Drop(_spriteBatch, location, mapFrames);

        Rectangle collisionRect = mapFrames[0][0].Bounds;
        ICollision collisionObject = new Collision(map, collisionRect);
        map.collider = collisionObject;
        map.collider.UpdateCollisionPosition();

        map.SetItemType(new MapDropType(map));
        return map;
    }
    public ISprite CreateSwordDrop(Vector2 location)
    {
        IDrop sword = new Drop(_spriteBatch, location, swordFrames);

        Rectangle collisionRect = swordFrames[0][0].Bounds;
        ICollision collisionObject = new Collision(sword, collisionRect);
        sword.collider = collisionObject;
        sword.collider.UpdateCollisionPosition();

        sword.SetItemType(new SwordDropType(sword));
        return sword;
    }
    public ISprite CreateTriforceShardDrop(Vector2 location)
    {
        IDrop triforce = new Drop(_spriteBatch, location, triforceFrames);

        Rectangle collisionRect = triforceFrames[0][0].Bounds;
        ICollision collisionObject = new Collision(triforce, collisionRect);
        triforce.collider = collisionObject;
        triforce.collider.UpdateCollisionPosition();

        triforce.SetItemType(new TriforceDropType(triforce));
        return triforce;
    }

    // Projectiles
    // Add method for CreateFireballProjectile and CreateSwordProjectile
    public ISprite CreateArrowProjectile(int distance, ISprite owner)
    {
        IProjectile arrow = new Projectile(_spriteBatch, new Vector2(0, 0), arrowFrames);

        Rectangle collisionRect = arrowFrames[0][0].Bounds;
        ICollision collisionObject = new Collision(arrow, collisionRect);
        arrow.collider = collisionObject;
        arrow.collider.UpdateCollisionPosition();

        arrow.SetDistance(distance);
        arrow.SetOwner(owner);
        arrow.SetItemType(new ArrowType(arrow));
        FireProjectile fireArrow = new FireProjectile(arrow);
        arrow.SetFireCommand(fireArrow);
        return arrow;
    }
    public ISprite CreateBombProjectile(int distance, ISprite owner)
    {
        IProjectile bomb = new Projectile(_spriteBatch, new Vector2(0, 0), bombFrames);

        Rectangle collisionRect = bombFrames[0][0].Bounds;
        collisionRect.Inflate(30, 30);
        ICollision collisionObject = new Collision(bomb, collisionRect);
        bomb.collider = collisionObject;
        bomb.collider.UpdateCollisionPosition();

        bomb.SetDistance(distance);
        bomb.SetOwner(owner);
        bomb.SetItemType(new BombType(bomb));
        FireProjectile fireBomb = new FireProjectile(bomb);
        bomb.SetFireCommand(fireBomb);
        return bomb;
    }
    public ISprite CreateBoomerangProjectile(int distance, ISprite owner)
    {
        IProjectile boomerang = new Projectile(_spriteBatch, new Vector2(0, 0), boomerangFrames);

        Rectangle collisionRect = boomerangFrames[0][0].Bounds;
        ICollision collisionObject = new Collision(boomerang, collisionRect);
        boomerang.collider = collisionObject;
        boomerang.collider.UpdateCollisionPosition();

        boomerang.SetDistance(distance);
        boomerang.SetOwner(owner);
        boomerang.SetItemType(new BoomerangType(boomerang));
        FireProjectile fireBoomerang = new FireProjectile(boomerang);
        boomerang.SetFireCommand(fireBoomerang);
        return boomerang;
    }
    public ISprite CreateFireballProjectile(int distance, ISprite owner)
    {
        IProjectile fireball = new Projectile(_spriteBatch, new Vector2(0, 0), fireballFrames);

        Rectangle collisionRect = fireballFrames[0][0].Bounds;
        ICollision collisionObject = new Collision(fireball, collisionRect);
        fireball.collider = collisionObject;
        fireball.collider.UpdateCollisionPosition();

        fireball.SetDistance(distance);
        fireball.SetOwner(owner);
        fireball.SetItemType(new FireballType(fireball));
        FireProjectile fireFireball = new FireProjectile(fireball);
        fireball.SetFireCommand(fireFireball);
        return fireball;
    }
    public ISprite CreateSwordProjectile(int distance, ISprite owner)
    {
        IProjectile sword = new Projectile(_spriteBatch, new Vector2(0, 0), swordFrames);

        Rectangle collisionRect = swordFrames[0][0].Bounds;
        ICollision collisionObject = new Collision(sword, collisionRect);
        sword.collider = collisionObject;
        sword.collider.UpdateCollisionPosition();

        sword.SetDistance(distance);
        sword.SetOwner(owner);
        sword.SetItemType(new SwordType(sword));
        FireProjectile fireFire = new FireProjectile(sword);
        sword.SetFireCommand(fireFire);
        return sword;
    }

    //Playables
    public ISprite CreateLinkSprite(Vector2 location)
    {
        return CreateEntityWithCollision(location, linkFrames);
    }

    //HUD Elements
    public Texture2D HUDHeart()
    {
        return HUDHearts;
    }
    public Texture2D HUDSword()
    {
        return swordUp[0];
    }
    public Texture2D HUDRuby()
    {
        return HUDRubies;
    }
    public Texture2D HUDKey()
    {
        return HUDKeys;
    }
    public Texture2D HUDBomb()
    {
        return HUDBombs;
    }
    public Texture2D HUDItemBorder()
    {
        return HUDItemBorders;
    }
    public Texture2D HUDMap()
    {
        return HUDMaps;
    }
    public Texture2D HUDLink()
    {
        return HUDLinks;
    }
    public Texture2D HUDTriforce()
    {
        return HUDTriforces;
    }
    public Texture2D HUDBoomerang()
    {
        return HUDBoomerangs;
    }
    public Texture2D HUDBow()
    {
        return HUDBows;
    }
    public Texture2D Blank()
    {
        return invisibleBarrier[0];
    }
}
