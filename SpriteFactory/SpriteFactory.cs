using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;


    public sealed class SpriteFactory : IFactory
    {
    private List<Texture2D>[] compassFrames;
    private List<Texture2D> compass;
    private List<Texture2D>[] mapFrames;
    private List<Texture2D> map;
    private List<Texture2D>[] barrierFrames;
    private List<Texture2D> barrier;
    private List<Texture2D>[] bushFrames;
    private List<Texture2D> bush;
    private List<Texture2D>[] linkFrames;
    private List<Texture2D> linkRight;
    private List<Texture2D> linkLeft;
    private List<Texture2D> linkUp;
    private List<Texture2D> linkDown;
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

    private SpriteBatch _spriteBatch;
    private SpriteFactory()
        {
        compassFrames = new List<Texture2D>[4];
        mapFrames = new List<Texture2D>[4];
        barrierFrames = new List<Texture2D>[4];
        bushFrames = new List<Texture2D>[4];
        linkFrames = new List<Texture2D>[4];
        linkLeft = new List<Texture2D>();
        linkRight = new List<Texture2D>();
        linkDown = new List<Texture2D>();
        linkUp = new List<Texture2D>();
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
        compass = new List<Texture2D>();
        map = new List<Texture2D>();
        bush = new List<Texture2D>();
        barrier = new List<Texture2D>();

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
        map.Add(content.Load<Texture2D>("ItemSprites/Map"));
        bush.Add(content.Load<Texture2D>("TileSprites/Bush"));
        barrier.Add(content.Load<Texture2D>("TileSprites/Barrier"));

        for (int i = 0; i < 4; i++)
        {
            bushFrames[i] = bush;
            barrierFrames[i] = barrier;
            compassFrames[i] = compass;
            mapFrames[i] = map;
        }

        for (int i = 1; i <= 2; i++)
        {
            // Loads sprite frames
            linkRight.Add(content.Load<Texture2D>("LinkSprites/linkRight" + i));
            linkLeft.Add(content.Load<Texture2D>("LinkSprites/linkLeft" + i));
            linkUp.Add(content.Load<Texture2D>("LinkSprites/linkUp" + i));
            linkDown.Add(content.Load<Texture2D>("LinkSprites/linkDown" + i));

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

        // Assign textures to arrow directions
        arrowLeft.Add(content.Load<Texture2D>("ItemSprites/ArrowLeft"));
        arrowRight.Add(content.Load<Texture2D>("ItemSprites/ArrowRight"));
        arrowUp.Add(content.Load<Texture2D>("ItemSprites/ArrowUp"));
        arrowDown.Add(content.Load<Texture2D>("ItemSprites/ArrowDown"));

        // Add the link frames to the list
        linkFrames[(int)SpriteAction.moveLeft] = linkLeft;
        linkFrames[(int)SpriteAction.moveRight] = linkRight;
        linkFrames[(int)SpriteAction.moveUp] = linkUp;
        linkFrames[(int)SpriteAction.moveDown] = linkDown;

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
    }

    public IConcreteSprite CreateGoriyaSprite()
    {
        return new ConcreteSprite(_spriteBatch, new Vector2(250, 340), goriyaFrames);
    }

    public IConcreteSprite CreateOktorokSprite()
    {
        return new ConcreteSprite(_spriteBatch, new Vector2(175, 140), oktorokFrames);
    }

    public IConcreteSprite CreatePeahatSprite()
    {
        return new ConcreteSprite(_spriteBatch, new Vector2(350, 140), peahatFrames);
    }

    public IConcreteSprite CreateLinkSprite()
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

    public ISprite CreateCompassTile()
    {
        return new ConcreteSprite(_spriteBatch, new Vector2(300, 200), compassFrames); 
    }

    public ISprite CreateMapTile()
    {
        return new ConcreteSprite(_spriteBatch, new Vector2(300, 200), mapFrames);
    }

    public IItem CreateArrowSprite()
    {
        return new ConcreteItem(_spriteBatch, new Vector2(50, 50), arrowFrames);
    }
}

