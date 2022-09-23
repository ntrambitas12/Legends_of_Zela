using CSE3902Project.Commands;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Net;
using System.Threading;

namespace CSE3902Project
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private List<Texture2D>[] compassFrames;
        private List<Texture2D>[] mapFrames;
        private List<Texture2D>[] barrierFrames;
        private List<Texture2D>[] bushFrames;
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
        private List<Texture2D>[] arrowFrames;
        private List<Texture2D> arrowLeft;
        private List<Texture2D> arrowRight;
        private List<Texture2D> arrowUp;
        private List<Texture2D> arrowDown;
        private List<ISprite> sprites;
        private List<ISprite> tiles;
        private List<IItem> items;
        private List<ISprite> drops;
        private List<Texture2D> compass;
        private List<Texture2D> map;
        private List<Texture2D> bush;
        private List<Texture2D> barrier;

        private IConcreteSprite enemy1;
        private IConcreteSprite enemy2;
        private ISprite barrierTile;
        private ISprite bushTile;
        private ISprite compassTile;
        private ISprite mapTile;
        private IItem arrow;

        private FireProjectile fireProjectile;
        private TileSwitch tileSwitcher;
        private TileSwitch itemSwitcher;
        private KeyLogic keyLogic;

        private KeyboardController keyboard;
        private EnemyController enemyController;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            compass = new List<Texture2D>();
            map = new List<Texture2D>();
            bush = new List<Texture2D>();
            barrier = new List<Texture2D>();
            tiles = new List<ISprite>();
            drops = new List<ISprite>();
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
            arrowFrames = new List<Texture2D>[4];
            arrowLeft = new List<Texture2D>();
            arrowRight = new List<Texture2D>();
            arrowUp = new List<Texture2D>();
            arrowDown = new List<Texture2D>();
            sprites = new List<ISprite>();
            keyboard = new KeyboardController();
            keyLogic = new KeyLogic();
            items = new List<IItem>();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            // TODO: Fix this so that you don't need a frame for each ENUM
            // Load tiles in
            compass.Add(Content.Load<Texture2D>("ItemSprites/Compass"));
            map.Add(Content.Load<Texture2D>("ItemSprites/Map"));
            bush.Add(Content.Load<Texture2D>("TileSprites/Bush"));
            barrier.Add(Content.Load<Texture2D>("TileSprites/Barrier"));

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
                linkRight.Add(Content.Load<Texture2D>("LinkSprites/linkRight" + i));
                linkLeft.Add(Content.Load<Texture2D>("LinkSprites/linkLeft" + i));
                linkUp.Add(Content.Load<Texture2D>("LinkSprites/linkUp" + i));
                linkDown.Add(Content.Load<Texture2D>("LinkSprites/linkDown" + i));

                goriyaRight.Add(Content.Load<Texture2D>("EnemySprites/GoriyaRedRight" + i));
                goriyaLeft.Add(Content.Load<Texture2D>("EnemySprites/GoriyaRedLeft" + i));
                goriyaUp.Add(Content.Load<Texture2D>("EnemySprites/GoriyaRedUp" + i));
                goriyaDown.Add(Content.Load<Texture2D>("EnemySprites/GoriyaRedDown" + i));
            }

            // Assign textures to arrow directions
            arrowLeft.Add(Content.Load<Texture2D>("ItemSprites/ArrowLeft"));
            arrowRight.Add(Content.Load<Texture2D>("ItemSprites/ArrowRight"));
            arrowUp.Add(Content.Load<Texture2D>("ItemSprites/ArrowUp"));
            arrowDown.Add(Content.Load<Texture2D>("ItemSprites/ArrowDown"));

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

            // Add arrow frames to the list
            arrowFrames[(int)SpriteAction.moveLeft] = arrowLeft;
            arrowFrames[(int)SpriteAction.moveRight] = arrowRight;
            arrowFrames[(int)SpriteAction.moveUp] = arrowUp;
            arrowFrames[(int)SpriteAction.moveDown] = arrowDown;

            // Create the enemy controller
            enemyController = new EnemyController();

            // Create enemies
            enemy1 = new ConcreteSprite(_spriteBatch, new Vector2(450, 240), linkFrames);
            enemy2 = new ConcreteSprite(_spriteBatch, new Vector2(250, 340), goriyaFrames);

            // Create tiles
            barrierTile = new ConcreteSprite(_spriteBatch, new Vector2(100, 100), barrierFrames);
            bushTile = new ConcreteSprite(_spriteBatch, new Vector2(100, 100), bushFrames);
            compassTile = new ConcreteSprite(_spriteBatch, new Vector2(300, 200), compassFrames);
            mapTile = new ConcreteSprite(_spriteBatch, new Vector2(300, 200), mapFrames);

            // Arrow stuff?
            arrow = new ConcreteItem(_spriteBatch, new Vector2(50, 50), arrowFrames);
            arrow.SetDistance(100);
            arrow.SetProjectileType(new BombType(arrow));

            // Add enemies to the list 
            sprites.Add((ISprite)enemy1);
            sprites.Add((ISprite)enemy2);

            // Add items to command lists
            items.Add(arrow);
            tiles.Add(barrierTile);
            tiles.Add(bushTile);
            drops.Add(mapTile);
            drops.Add(compassTile);

            // Add enemies to the enemy controller
            enemyController.AddEnemy(new MoveEnemy(enemy1));
            enemyController.AddEnemy(new MoveEnemy(enemy2));

            // Create Commands
            fireProjectile = new FireProjectile((ISprite)enemy1, arrow);
            tileSwitcher = new TileSwitch(tiles);
            itemSwitcher = new TileSwitch(drops);

            // Add to keyboard controller
            keyboard.RegisterCommand(Keys.D1, fireProjectile);
            keyboard.RegisterCommand(Keys.T, tileSwitcher);
            keyboard.RegisterCommand(Keys.U, itemSwitcher);

            // More arrow stuffs?
            arrow.SetFireCommand(fireProjectile);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            GraphicsDevice.Clear(Color.CornflowerBlue);
           

            // Update enemies on screen
            enemyController.Update();

            // Only update keyboard if no projectiles are on screen
            // Might need something in keyboard controller to handle this
            bool updateKeys = true;
            foreach (IItem item in items)
            {
                updateKeys = updateKeys && !(item.ShouldDraw());
            }

            if (updateKeys)
            {
                keyboard.Update();
            }

            foreach (IItem item in items)
            {
                item.Update();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            foreach (ISprite sprite in sprites)
            {
                sprite.Draw();
            }

            foreach (IItem item in items)
            {
                item.Draw();
            }

            //if(keyLogic.OneShotKeyPress(Keys.T))
            //{
            tileSwitcher.currentTile.Draw();
            itemSwitcher.currentTile.Draw();
            //}
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}