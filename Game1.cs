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
        private List<Keys> linkKeys;

        private ISprite enemy1;
        private ISprite enemy2;
        private ISprite enemy3;

        private ISprite link;
        private ISprite barrierTile;
        private ISprite bushTile;
        private ISprite defaultFloorTile;
        private ISprite dungeonStairsTile;
        private ISprite gravestoneTile;
        private ISprite waterTile;
        private ISprite compassItem;
        private ISprite heartItem;
        private ISprite keyItem;
        private ISprite mapItem;
        private ISprite rupiesItem;
        private ISprite swordItem;
        private IItem arrowLink;
        private IItem silverArrowLink;
        private IItem boomerangLink;
        private IItem magicBoomerangLink;
        private IItem bombLink;
        private IItem fireLink;
        private IItem boomerangEnemy1;
        private IItem magicBoomerangEnemy2;
        private IItem fireEnemy3;

        private FireProjectile fireArrowLink;
        private FireProjectile fireSilverArrowLink;
        private FireProjectile fireBoomerangLink;
        private FireProjectile fireMagicBoomerangLink;
        private FireProjectile fireBombLink;
        private FireProjectile fireFireLink;
        private FireProjectile fireBoomerangEnemy1;
        private FireProjectile fireMagicBoomerangEnemy2;
        private FireProjectile fireFireEnemy3;

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
            linkKeys = new List<Keys>();

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
            enemy2 = SpriteFactory.Instance.CreateOktorokSprite();
            enemy3 = SpriteFactory.Instance.CreatePeahatSprite();


            // Create link
            link = SpriteFactory.Instance.CreateLinkSprite();

            // Create tiles
            barrierTile = SpriteFactory.Instance.CreateBarrierTile();
            bushTile = SpriteFactory.Instance.CreateBushTile();
            defaultFloorTile = SpriteFactory.Instance.CreateDefaultFloorTile();
            dungeonStairsTile = SpriteFactory.Instance.CreateDungeonStairsTile();
            gravestoneTile = SpriteFactory.Instance.CreateGravestoneTile();
            waterTile = SpriteFactory.Instance.CreateWaterTile();

            // Create items
            compassItem = SpriteFactory.Instance.CreateCompassItem();
            heartItem = SpriteFactory.Instance.CreateHeartItem();
            keyItem = SpriteFactory.Instance.CreateKeyItem();
            mapItem = SpriteFactory.Instance.CreateMapItem();
            rupiesItem = SpriteFactory.Instance.CreateRupiesItem();
            swordItem = SpriteFactory.Instance.CreateSwordItem();

            // Add tiles to tile controller
            tileController.AddSprite(barrierTile);
            tileController.AddSprite(bushTile);
            tileController.AddSprite(defaultFloorTile);
            tileController.AddSprite(dungeonStairsTile);
            tileController.AddSprite(gravestoneTile);
            tileController.AddSprite(waterTile);

            //Add items to the item controller
            itemController.AddSprite(compassItem);
            itemController.AddSprite(heartItem);
            itemController.AddSprite(keyItem);
            itemController.AddSprite(mapItem);
            itemController.AddSprite(rupiesItem);
            itemController.AddSprite(swordItem);

            // Create Projectiles (Before command is created)
            arrowLink = SpriteFactory.Instance.CreateArrowSprite();
            arrowLink.SetDistance(60);
            arrowLink.SetProjectileType(new ArrowType(arrowLink));
            arrowLink.SetOwner(link);

            silverArrowLink = SpriteFactory.Instance.CreateSilverArrowSprite();
            silverArrowLink.SetDistance(80);
            silverArrowLink.SetProjectileType(new ArrowType(silverArrowLink));
            silverArrowLink.SetOwner(link);

            boomerangLink = SpriteFactory.Instance.CreateBoomerangSprite();
            boomerangLink.SetDistance(100);
            boomerangLink.SetProjectileType(new BoomerangType(boomerangLink));
            boomerangLink.SetOwner(link);

            magicBoomerangLink = SpriteFactory.Instance.CreateMagicBoomerangSprite();
            magicBoomerangLink.SetDistance(140);
            magicBoomerangLink.SetProjectileType(new BoomerangType(magicBoomerangLink));
            magicBoomerangLink.SetOwner(link);

            bombLink = SpriteFactory.Instance.CreateBombSprite();
            bombLink.SetDistance(100); // How long it is on the ground
            bombLink.SetProjectileType(new BombType(bombLink));
            bombLink.SetOwner(link);

            fireLink = SpriteFactory.Instance.CreateFireSprite();
            fireLink.SetDistance(50);
            fireLink.SetProjectileType(new ArrowType(fireLink));
            fireLink.SetOwner(link);

            boomerangEnemy1 = SpriteFactory.Instance.CreateBoomerangSprite();
            boomerangEnemy1.SetDistance(100);
            boomerangEnemy1.SetProjectileType(new BoomerangType(boomerangEnemy1));
            boomerangEnemy1.SetOwner(enemy1);

            magicBoomerangEnemy2 = SpriteFactory.Instance.CreateMagicBoomerangSprite();
            magicBoomerangEnemy2.SetDistance(140);
            magicBoomerangEnemy2.SetProjectileType(new BoomerangType(magicBoomerangEnemy2));
            magicBoomerangEnemy2.SetOwner(enemy2);

            fireEnemy3 = SpriteFactory.Instance.CreateFireSprite();
            fireEnemy3.SetDistance(50);
            fireEnemy3.SetProjectileType(new ArrowType(fireEnemy3));
            fireEnemy3.SetOwner(enemy3);

            // Add items to command lists
            items.Add(arrowLink);
            items.Add(silverArrowLink);
            items.Add(boomerangLink);
            items.Add(magicBoomerangLink);
            items.Add(bombLink);
            items.Add(fireLink);
            items.Add(boomerangEnemy1);
            items.Add(magicBoomerangEnemy2);
            items.Add(fireEnemy3);

            // Create Commands
            fireArrowLink = new FireProjectile(arrowLink);
            fireSilverArrowLink = new FireProjectile(silverArrowLink);
            fireBoomerangLink = new FireProjectile(boomerangLink);
            fireMagicBoomerangLink = new FireProjectile(magicBoomerangLink);
            fireBombLink = new FireProjectile(bombLink);
            fireFireLink = new FireProjectile(fireLink);
            fireBoomerangEnemy1 = new FireProjectile(boomerangEnemy1);
            fireMagicBoomerangEnemy2 = new FireProjectile(magicBoomerangEnemy2);
            fireFireEnemy3 = new FireProjectile(fireEnemy3);
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

            // Set projectile commands (After commands are created)
            arrowLink.SetFireCommand(fireArrowLink);
            silverArrowLink.SetFireCommand(fireSilverArrowLink);
            boomerangLink.SetFireCommand(fireBoomerangLink);
            magicBoomerangLink.SetFireCommand(fireMagicBoomerangLink);
            bombLink.SetFireCommand(fireBombLink);
            fireLink.SetFireCommand(fireFireLink);
            boomerangEnemy1.SetFireCommand(fireBoomerangEnemy1);
            magicBoomerangEnemy2.SetFireCommand(fireMagicBoomerangEnemy2);
            fireEnemy3.SetFireCommand(fireFireEnemy3);

            //Add link's keys to the list
            linkKeys.Add(Keys.Left);
            linkKeys.Add(Keys.Right);
            linkKeys.Add(Keys.Up);
            linkKeys.Add(Keys.Down);
            linkKeys.Add(Keys.W);
            linkKeys.Add(Keys.A);
            linkKeys.Add(Keys.S);
            linkKeys.Add(Keys.D);
            linkKeys.Add(Keys.E);


            // Add to keyboard controller
            keyboard.RegisterCommand(Keys.D1, fireArrowLink);
            keyboard.RegisterCommand(Keys.D2, fireSilverArrowLink);
            keyboard.RegisterCommand(Keys.D3, fireBoomerangLink);
            keyboard.RegisterCommand(Keys.D4, fireMagicBoomerangLink);
            keyboard.RegisterCommand(Keys.D5, fireBombLink);
            keyboard.RegisterCommand(Keys.D6, fireFireLink);

            keyboard.RegisterCommand(Keys.Up, linkMoveUp);
            keyboard.RegisterCommand(Keys.W, linkMoveUp);
            keyboard.RegisterCommand(Keys.Left, linkMoveLeft);
            keyboard.RegisterCommand(Keys.A, linkMoveLeft);
            keyboard.RegisterCommand(Keys.Right, linkMoveRight);
            keyboard.RegisterCommand(Keys.D, linkMoveRight);
            keyboard.RegisterCommand(Keys.Down, linkMoveDown);
            keyboard.RegisterCommand(Keys.S, linkMoveDown);
            keyboard.RegisterCommand(Keys.E, linkDamage);

            keyboard.RegisterCommand(Keys.Y, nextTile);
            keyboard.RegisterCommand(Keys.T, previousTile);

            keyboard.RegisterCommand(Keys.U, previousItem);
            keyboard.RegisterCommand(Keys.I, nextItem);


            keyboard.RegisterCommand(Keys.Q, exitGame);
            keyboard.RegisterCommand(Keys.R, restartGame);

            keyboard.RegisterCommand(Keys.P, nextEnemy);
            keyboard.RegisterCommand(Keys.O, previousEnemy);

            keyboard.AddPlayableSprite(link, linkKeys);

            // Add enemies to the enemy controller (with their items)
            enemyController.AddSprite(enemy1, boomerangEnemy1);
            enemyController.AddSprite(enemy2, magicBoomerangEnemy2);
            enemyController.AddSprite(enemy3, fireEnemy3);
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
            foreach (var controller in controllers)
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