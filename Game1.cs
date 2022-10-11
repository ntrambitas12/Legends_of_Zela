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
        private IDrop keyDrop;
        private IProjectile arrowLink;
        private IProjectile silverArrowLink;
        private IProjectile boomerangLink;
        private IProjectile magicBoomerangLink;
        private IProjectile bombLink;
        private IProjectile fireLink;
        private IProjectile boomerangEnemy1;
        private IProjectile magicBoomerangEnemy2;
        private IProjectile fireEnemy3;

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
        private TakeDamage linkDamage;
        private Attack linkAttack;

        private KeyboardController keyboard;
        private EnemyController enemyController;
        private TileController tileController;
        private ItemController itemController;

        private RoomObject room1;
        private IRoomObjectManager roomObjectManager;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            //create the game object
            room1 = new RoomObject();
            roomObjectManager = new RoomObjectManager();

            exitGame = new ExitCommand(this);
            restartGame = new RestartCommand(this);
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            linkKeys = new List<Keys>();

            // Create the controllers
            enemyController = EnemyController.GetInstance;
            tileController = TileController.GetInstance;
            itemController = ItemController.GetInstance;
            keyboard = KeyboardController.GetInstance;

            // Add all controllers to the room

            room1.AddController(keyboard);
            room1.AddController(enemyController);
            room1.AddController(tileController);
            room1.AddController(itemController);

            //Load up the content for the sprite factory
            SpriteFactory.Instance.LoadAllContent(Content, _spriteBatch);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            //create the sprites
            createSprites();

            //add to controllers
            addToControllers();

            // Create Projectiles (Before command is created)
            createProjectiles();

            // Add items to command lists
            addToItemList();

            // Create Commands
            createCommands();

            // Set projectile commands (After commands are created)
            setProjectileCommands();

            //register commands with key presses
            registerKeyboard();
           
            // Add enemies to the enemy controller (with their items)
            enemyController.AddSprite(enemy1, boomerangEnemy1);
            enemyController.AddSprite(enemy2, magicBoomerangEnemy2);
            enemyController.AddSprite(enemy3, fireEnemy3);

            //add the room to the roomObjectManager
            roomObjectManager.addRoom(room1);
        }

        public void resetGame()
        {
            roomObjectManager.Reset();
            this.LoadContent();
        }

       


        protected override void Update(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.CornflowerBlue);


            roomObjectManager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();

            roomObjectManager.Draw();

            _spriteBatch.End();

            base.Draw(gameTime);
        }
        private void addToItemList()
        {
            // Add items to command lists
            room1.AddGameObject((int)RoomObjectTypes.typePickup, keyDrop);
            room1.AddGameObject((int)RoomObjectTypes.typeLinkProjectile, arrowLink);
            room1.AddGameObject((int)RoomObjectTypes.typeLinkProjectile, silverArrowLink);
            room1.AddGameObject((int)RoomObjectTypes.typeLinkProjectile, boomerangLink);
            room1.AddGameObject((int)RoomObjectTypes.typeLinkProjectile, magicBoomerangLink);
            room1.AddGameObject((int)RoomObjectTypes.typeLinkProjectile, bombLink);
            room1.AddGameObject((int)RoomObjectTypes.typeLinkProjectile, fireLink);
            room1.AddGameObject((int)RoomObjectTypes.typeEnemyProjectile, boomerangEnemy1);
            room1.AddGameObject((int)RoomObjectTypes.typeEnemyProjectile, magicBoomerangEnemy2);
            room1.AddGameObject((int)RoomObjectTypes.typeEnemyProjectile, fireEnemy3);

            room1.Link = link;
        }
        
        private void addToControllers()
        {
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
        }
        private void createSprites()
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

            keyDrop = SpriteFactory.Instance.CreateKeyDrop();
            keyDrop.SetItemType(new DropType());
            keyDrop.SetShouldDraw(true);
        }
        private void setProjectileCommands()
        {
            arrowLink.SetFireCommand(fireArrowLink);
            silverArrowLink.SetFireCommand(fireSilverArrowLink);
            boomerangLink.SetFireCommand(fireBoomerangLink);
            magicBoomerangLink.SetFireCommand(fireMagicBoomerangLink);
            bombLink.SetFireCommand(fireBombLink);
            fireLink.SetFireCommand(fireFireLink);
            boomerangEnemy1.SetFireCommand(fireBoomerangEnemy1);
            magicBoomerangEnemy2.SetFireCommand(fireMagicBoomerangEnemy2);
            fireEnemy3.SetFireCommand(fireFireEnemy3);
        }
        private void createProjectiles()
        {
            arrowLink = SpriteFactory.Instance.CreateArrowSprite();
            arrowLink.SetDistance(60);
            arrowLink.SetItemType(new ArrowType(arrowLink));
            arrowLink.SetOwner(link);

            silverArrowLink = SpriteFactory.Instance.CreateSilverArrowSprite();
            silverArrowLink.SetDistance(80);
            silverArrowLink.SetItemType(new ArrowType(silverArrowLink));
            silverArrowLink.SetOwner(link);

            boomerangLink = SpriteFactory.Instance.CreateBoomerangSprite();
            boomerangLink.SetDistance(100);
            boomerangLink.SetItemType(new BoomerangType(boomerangLink));
            boomerangLink.SetOwner(link);

            magicBoomerangLink = SpriteFactory.Instance.CreateMagicBoomerangSprite();
            magicBoomerangLink.SetDistance(140);
            magicBoomerangLink.SetItemType(new BoomerangType(magicBoomerangLink));
            magicBoomerangLink.SetOwner(link);

            bombLink = SpriteFactory.Instance.CreateBombSprite();
            bombLink.SetDistance(100); // How long it is on the ground
            bombLink.SetItemType(new BombType(bombLink));
            bombLink.SetOwner(link);

            fireLink = SpriteFactory.Instance.CreateFireSprite();
            fireLink.SetDistance(50);
            fireLink.SetItemType(new ArrowType(fireLink));
            fireLink.SetOwner(link);

            boomerangEnemy1 = SpriteFactory.Instance.CreateBoomerangSprite();
            boomerangEnemy1.SetDistance(100);
            boomerangEnemy1.SetItemType(new BoomerangType(boomerangEnemy1));
            boomerangEnemy1.SetOwner(enemy1);

            magicBoomerangEnemy2 = SpriteFactory.Instance.CreateMagicBoomerangSprite();
            magicBoomerangEnemy2.SetDistance(140);
            magicBoomerangEnemy2.SetItemType(new BoomerangType(magicBoomerangEnemy2));
            magicBoomerangEnemy2.SetOwner(enemy2);

            fireEnemy3 = SpriteFactory.Instance.CreateFireSprite();
            fireEnemy3.SetDistance(50);
            fireEnemy3.SetItemType(new ArrowType(fireEnemy3));
            fireEnemy3.SetOwner(enemy3);
        }
        private void createCommands()
        {
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
            linkDamage = new TakeDamage(link);
            linkAttack = new Attack(link);
        }

        private void registerKeyboard()
        { //Add link's keys to the list
            linkKeys.Add(Keys.Left);
            linkKeys.Add(Keys.Right);
            linkKeys.Add(Keys.Up);
            linkKeys.Add(Keys.Down);
            linkKeys.Add(Keys.W);
            linkKeys.Add(Keys.A);
            linkKeys.Add(Keys.S);
            linkKeys.Add(Keys.D);


            // Add item use to keyboard controller
            keyboard.RegisterCommand(Keys.D1, fireArrowLink);
            keyboard.RegisterCommand(Keys.D2, fireSilverArrowLink);
            keyboard.RegisterCommand(Keys.D3, fireBoomerangLink);
            keyboard.RegisterCommand(Keys.D4, fireMagicBoomerangLink);
            keyboard.RegisterCommand(Keys.D5, fireBombLink);
            keyboard.RegisterCommand(Keys.D6, fireFireLink);

            // Add link movements and actions to keyboard controller
            keyboard.RegisterCommand(Keys.Up, linkMoveUp);
            keyboard.RegisterCommand(Keys.W, linkMoveUp);
            keyboard.RegisterCommand(Keys.Left, linkMoveLeft);
            keyboard.RegisterCommand(Keys.A, linkMoveLeft);
            keyboard.RegisterCommand(Keys.Right, linkMoveRight);
            keyboard.RegisterCommand(Keys.D, linkMoveRight);
            keyboard.RegisterCommand(Keys.Down, linkMoveDown);
            keyboard.RegisterCommand(Keys.S, linkMoveDown);
            keyboard.RegisterCommand(Keys.E, linkDamage);
            keyboard.RegisterCommand(Keys.Z, linkAttack);
            keyboard.RegisterCommand(Keys.N, linkAttack);

            // Add tile switching/item/enemy switching commands to keyboard controller
            keyboard.RegisterCommand(Keys.Y, nextTile);
            keyboard.RegisterCommand(Keys.T, previousTile);
            keyboard.RegisterCommand(Keys.U, previousItem);
            keyboard.RegisterCommand(Keys.I, nextItem);
            keyboard.RegisterCommand(Keys.P, nextEnemy);
            keyboard.RegisterCommand(Keys.O, previousEnemy);

            // Add restart and exit commands to keyboard
            keyboard.RegisterCommand(Keys.Q, exitGame);
            keyboard.RegisterCommand(Keys.R, restartGame);

            // Add link with his keys to playable sprite
            keyboard.AddPlayableSprite(link, linkKeys);
        }
    }
}