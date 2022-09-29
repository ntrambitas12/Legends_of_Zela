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

       
        private List<ISprite> sprites;
        private List<ISprite> tiles;
        private List<IItem> items;
        private List<ISprite> drops;
  
        private IConcreteSprite enemy1;
        private IConcreteSprite enemy2;
        private IConcreteSprite link;


        private ISprite barrierTile;
        private ISprite bushTile;
        private ISprite compassTile;
        private ISprite mapTile;
        private IItem arrow;

        private FireProjectile fireProjectile;
        private Switcher tileNext;
        private SwitcherBack tileBack;
        private Switcher itemNext;
        private SwitcherBack itemBack;

        private ICommand exitGame;
        private ICommand restartGame;

        private NextEnemy nextEnemy;
        private PreviousEnemy previousEnemy;

        private MoveDown linkMoveDown;
        private MoveUp linkMoveUp;
        private MoveLeft linkMoveLeft;
        private MoveRight linkMoveRight;
        private LinkTakeDamage linkDamage;

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
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Create the enemy controller
            enemyController = EnemyController.GetInstance;

            tiles = new List<ISprite>();
            drops = new List<ISprite>();
           
            sprites = new List<ISprite>();
            keyboard = KeyboardController.GetInstance;
            items = new List<IItem>();
            exitGame = new ExitCommand(this);
            restartGame = new RestartCommand(this);

            //Load up the content for the sprite factory
            SpriteFactory.Instance.LoadAllContent(Content, _spriteBatch);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create enemies
            enemy1 = SpriteFactory.Instance.CreateGoriyaSprite();
            enemy2 = SpriteFactory.Instance.CreateGoriyaSprite();

            // Create link
            link = SpriteFactory.Instance.CreateLinkSprite();
   
            // Create tiles
            barrierTile = SpriteFactory.Instance.CreateBarrierTile();
            bushTile = SpriteFactory.Instance.CreateBushTile();
            compassTile = SpriteFactory.Instance.CreateCompassTile();
            mapTile = SpriteFactory.Instance.CreateMapTile();

            // Create Arrow (Before command is created)
            arrow = SpriteFactory.Instance.CreateArrowSprite();
            arrow.SetDistance(100);
            arrow.SetProjectileType(new BoomerangType(arrow));
            arrow.SetOwner(enemy1);

            // Add enemies to the list 
            sprites.Add((ISprite)enemy1);
            sprites.Add((ISprite)enemy2);
            sprites.Add((ISprite)link);

            // Add items to command lists
            items.Add(arrow);
            tiles.Add(barrierTile);
            tiles.Add(bushTile);
            drops.Add(mapTile);
            drops.Add(compassTile);

            // Add enemies to the enemy controller
            enemyController.AddEnemy(enemy1);
            enemyController.AddEnemy(enemy2);

            // Create Commands
            fireProjectile = new FireProjectile(arrow);
            tileNext = new Switcher(tiles);
            tileBack = new SwitcherBack(tiles);
            itemNext = new Switcher(drops);
            itemBack = new SwitcherBack(drops);
            previousEnemy = new PreviousEnemy(enemyController);
            nextEnemy = new NextEnemy(enemyController);

            linkMoveDown = new MoveDown(link);
            linkMoveUp = new MoveUp(link);
            linkMoveRight = new MoveRight(link);
            linkMoveLeft = new MoveLeft(link);
            linkDamage = new LinkTakeDamage(link);

            // Add to keyboard controller
            keyboard.RegisterCommand(Keys.D1, fireProjectile, true);
            keyboard.RegisterCommand(Keys.T, tileBack, true);
            keyboard.RegisterCommand(Keys.Y, tileNext, true);
            keyboard.RegisterCommand(Keys.U, itemBack, true);
            keyboard.RegisterCommand(Keys.I, itemNext, true);

            keyboard.RegisterCommand(Keys.Up, linkMoveUp, false);
            keyboard.RegisterCommand(Keys.W, linkMoveUp, false);
            keyboard.RegisterCommand(Keys.Left, linkMoveLeft, false);
            keyboard.RegisterCommand(Keys.A, linkMoveLeft, false);
            keyboard.RegisterCommand(Keys.Right, linkMoveRight, false);
            keyboard.RegisterCommand(Keys.D, linkMoveRight, false);
            keyboard.RegisterCommand(Keys.Down, linkMoveDown, false);
            keyboard.RegisterCommand(Keys.S, linkMoveDown, false);
            keyboard.RegisterCommand(Keys.E, linkDamage, true);

            keyboard.RegisterCommand(Keys.Q, exitGame, true);
            keyboard.RegisterCommand(Keys.R, restartGame, true);

            keyboard.RegisterCommand(Keys.P, nextEnemy, true);
            keyboard.RegisterCommand(Keys.O, previousEnemy, true);

            // Set arrow command (After command is created)
            arrow.SetFireCommand(fireProjectile);
        }

        public void resetGame()
        {
            enemyController.resetController();
            keyboard.resetController();
            sprites.Clear();
            items.Clear();
            tiles.Clear();
            drops.Clear();

            this.LoadContent();
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
            
            tileNext.currentTile.Draw();
            tileBack.currentTile.Draw();
            itemNext.currentTile.Draw();
            itemBack.currentTile.Draw();
            
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}