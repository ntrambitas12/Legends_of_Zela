using CSE3902Project.Controllers;
using CSE3902Project.Commands;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;

namespace CSE3902Project
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

       
        private List<IItem> items;
        private List<IController> controllers;
    
        private ISprite enemy1;
        private ISprite enemy2;
        private ISprite link;
        private ISprite barrierTile;
        private ISprite bushTile;
        private ISprite compassItem;
        private ISprite mapItem;
        private IItem arrow;

        private FireProjectile fireProjectile;

        private ICommand exitGame;
        private ICommand restartGame;

        private NextSprite nextEnemy;
        private PreviousSprite previousEnemy;
        private NextSprite nextItem;
        private PreviousSprite previousItem;
        private NextSprite nextTile;
        private PreviousSprite previousTile;

        private MoveDown linkMoveDown;
        private MoveUp linkMoveUp;
        private MoveLeft linkMoveLeft;
        private MoveRight linkMoveRight;
        private LinkTakeDamage linkDamage;

        private KeyboardController keyboard;
        private EnemyController enemyController;
        private TileController tileController;
        private ItemController itemController;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            // Instantiate lists and commands
            items = new List<IItem>();
            controllers = new List<IController>();
            exitGame = new ExitCommand(this);
            restartGame = new RestartCommand(this);
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Create the controllers
            enemyController = EnemyController.GetInstance;
            tileController = TileController.GetInstance;
            itemController = ItemController.GetInstance;
            keyboard = KeyboardController.GetInstance;


            // Add all controllers to controller lists
            controllers.Add(keyboard);
            controllers.Add(enemyController);
            controllers.Add(tileController);
            controllers.Add(itemController);

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

            // Create items
            compassItem = SpriteFactory.Instance.CreateCompassItem();
            mapItem = SpriteFactory.Instance.CreateMapItem();

            // Add tiles to tile controller
            tileController.AddSprite(barrierTile);
            tileController.AddSprite(bushTile);

            //Add items to the item controller
            itemController.AddSprite(compassItem);
            itemController.AddSprite(mapItem);

            // Create Arrow (Before command is created)
            arrow = SpriteFactory.Instance.CreateArrowSprite();
            arrow.SetDistance(100);
            arrow.SetProjectileType(new BoomerangType(arrow));
            arrow.SetOwner(enemy1);

            // Add items to command lists
            items.Add(arrow);

            // Add enemies to the enemy controller
            enemyController.AddSprite(enemy1);
            enemyController.AddSprite(enemy2);

            // Create Commands
            fireProjectile = new FireProjectile(arrow);
            previousEnemy = new PreviousSprite(enemyController);
            nextEnemy = new NextSprite(enemyController);
            previousTile = new PreviousSprite(tileController);
            nextTile = new NextSprite(tileController);
            previousItem = new PreviousSprite(itemController);
            nextItem = new NextSprite(itemController);

            linkMoveDown = new MoveDown(link);
            linkMoveUp = new MoveUp(link);
            linkMoveRight = new MoveRight(link);
            linkMoveLeft = new MoveLeft(link);
            linkDamage = new LinkTakeDamage(link);

            // Add to keyboard controller
            keyboard.RegisterCommand(Keys.D1, fireProjectile, true);

            keyboard.RegisterCommand(Keys.Up, linkMoveUp, false);
            keyboard.RegisterCommand(Keys.W, linkMoveUp, false);
            keyboard.RegisterCommand(Keys.Left, linkMoveLeft, false);
            keyboard.RegisterCommand(Keys.A, linkMoveLeft, false);
            keyboard.RegisterCommand(Keys.Right, linkMoveRight, false);
            keyboard.RegisterCommand(Keys.D, linkMoveRight, false);
            keyboard.RegisterCommand(Keys.Down, linkMoveDown, false);
            keyboard.RegisterCommand(Keys.S, linkMoveDown, false);
            keyboard.RegisterCommand(Keys.E, linkDamage, true);

            keyboard.RegisterCommand(Keys.Y, nextTile, true);
            keyboard.RegisterCommand(Keys.T, previousTile, true);

            keyboard.RegisterCommand(Keys.U, previousItem, true);
            keyboard.RegisterCommand(Keys.I, nextItem, true);


            keyboard.RegisterCommand(Keys.Q, exitGame, true);
            keyboard.RegisterCommand(Keys.R, restartGame, true);

            keyboard.RegisterCommand(Keys.P, nextEnemy, true);
            keyboard.RegisterCommand(Keys.O, previousEnemy, true);

            // Set arrow command (After command is created)
            arrow.SetFireCommand(fireProjectile);
        }

        public void resetGame()
        {
            foreach (var controller in controllers)
            {
                controller.resetController();
            }

            items.Clear();

            this.LoadContent();
        }

        

        protected override void Update(GameTime gameTime)
        {
          
            GraphicsDevice.Clear(Color.CornflowerBlue);
           

            // Update all controllers
            foreach (var controller in controllers)
            {
                controller.Update();
            }


            foreach (IItem item in items)
            {
                item.Update();
            }

            //Update link
            link.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            //Call each controller to draw
            foreach(var controller in controllers)
            {
                controller.Draw();
            }

            foreach (IItem item in items)
            {
                item.Draw();
            }

            //Draw Link
            link.Draw();
                        
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
} 