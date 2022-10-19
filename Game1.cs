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




        // private ISprite link;
        private ISprite barrierTile;
        // private ISprite bushTile;
        //private ISprite defaultFloorTile;
        private ISprite dungeonStairsTile;
        //private ISprite gravestoneTile;
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




        private NextSprite nextItem;
        private PreviousSprite previousItem;
        private NextSprite nextTile;
        private PreviousSprite previousTile;



        private IRoomObjectManager roomObjectManager;
        private LevelLoader level;

        //Move to spritefactory later
        private Texture2D background;

        //Delete prior to sprint submission; for sprite pos testing
        private Texture2D door;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            roomObjectManager = new RoomObjectManager();
            level = new LevelLoader(roomObjectManager, this);
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //Load up the content for the sprite factory
            SpriteFactory.Instance.LoadAllContent(Content, _spriteBatch);
            background = Content.Load<Texture2D>("DungeonSprites/DungeonFloor");

            //Delete prior to sprint submission; was used for testing
            door = Content.Load<Texture2D>("DungeonSprites/DoorTopOpen");

            base.Initialize();
        }

        protected override void LoadContent()
        {
            //levelLoader methods:

            //Turn these into one parse method
            level.ParseRoom();



            // Create Projectiles (Before command is created)
            //createProjectiles();

            // Add items to command lists
            // addToItemList();

            // Create Commands
            // createCommands();

            // Set projectile commands (After commands are created)
            //setProjectileCommands();



        }

        public void resetGame()
        {
            roomObjectManager.Reset();
            this.LoadContent();
        }




        protected override void Update(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.Black);

            roomObjectManager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            _spriteBatch.Draw(background, new Vector2(144, 114), null, Color.White, 0, new Vector2(0, 0), 2, SpriteEffects.None, 0);

            //Delete this before sprint submisison; was used for testing sprite locations
            //_spriteBatch.Draw(door, new Vector2(368, 114), null, Color.White, 0, new Vector2(0,0), 2, SpriteEffects.None, 0);

            roomObjectManager.Draw(gameTime);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
        private void addToItemList()
        {
            // Add items to command lists
            // room1.AddGameObject((int)RoomObjectTypes.typePickup, keyDrop);
            //room1.AddGameObject((int)RoomObjectTypes.typeLinkProjectile, arrowLink);
            //room1.AddGameObject((int)RoomObjectTypes.typeLinkProjectile, silverArrowLink);
            //room1.AddGameObject((int)RoomObjectTypes.typeLinkProjectile, boomerangLink);
            //room1.AddGameObject((int)RoomObjectTypes.typeLinkProjectile, magicBoomerangLink);
            // room1.AddGameObject((int)RoomObjectTypes.typeLinkProjectile, bombLink);
            // room1.AddGameObject((int)RoomObjectTypes.typeLinkProjectile, fireLink);
            // room1.AddGameObject((int)RoomObjectTypes.typeEnemyProjectile, boomerangEnemy1);
            // room1.AddGameObject((int)RoomObjectTypes.typeEnemyProjectile, magicBoomerangEnemy2);
            //  room1.AddGameObject((int)RoomObjectTypes.typeEnemyProjectile, fireEnemy3);

            //   room1.Link = link;
        }


        //private void createSprites()
        //{




        //    // Create tiles
        //    barrierTile = SpriteFactory.Instance.CreateBarrierTile(new Vector2(0, 0));
        //    //bushTile = SpriteFactory.Instance.CreateBushTile(new Vector2(0, 0));
        //    //defaultFloorTile = SpriteFactory.Instance.CreateDefaultFloorTile(new Vector2(0, 0));
        //    dungeonStairsTile = SpriteFactory.Instance.CreateDungeonStairsTile(new Vector2(0, 0));
        //    // gravestoneTile = SpriteFactory.Instance.CreateGravestoneTile(new Vector2(0, 0));
        //    waterTile = SpriteFactory.Instance.CreateWaterTile(new Vector2(0, 0));

        //    // Create items
        //    compassItem = SpriteFactory.Instance.CreateCompassItem(new Vector2(0, 0));
        //    heartItem = SpriteFactory.Instance.CreateHeartItem(new Vector2(0, 0));
        //    keyItem = SpriteFactory.Instance.CreateKeyItem(new Vector2(0, 0));
        //    mapItem = SpriteFactory.Instance.CreateMapItem(new Vector2(0, 0));
        //    rupiesItem = SpriteFactory.Instance.CreateRupiesItem(new Vector2(0, 0));
        //    swordItem = SpriteFactory.Instance.CreateSwordItem(new Vector2(0, 0));

        //    keyDrop = SpriteFactory.Instance.CreateKeyDrop(new Vector2(0, 0));
        //    keyDrop.SetItemType(new DropType());
        //    keyDrop.SetShouldDraw(true);


        //}
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
        //private void createProjectiles()
        //{

        //    arrowLink = SpriteFactory.Instance.CreateArrowSprite(new Vector2(0, 0));
        //    arrowLink.SetDistance(60);
        //    arrowLink.SetItemType(new ArrowType(arrowLink));
        //    //arrowLink.SetOwner(link);

        //    silverArrowLink = SpriteFactory.Instance.CreateSilverArrowSprite(new Vector2(0, 0));
        //    silverArrowLink.SetDistance(80);
        //    silverArrowLink.SetItemType(new ArrowType(silverArrowLink));
        //    // silverArrowLink.SetOwner(link);

        //    boomerangLink = SpriteFactory.Instance.CreateBoomerangSprite(new Vector2(0, 0));
        //    boomerangLink.SetDistance(100);
        //    boomerangLink.SetItemType(new BoomerangType(boomerangLink));
        //    // boomerangLink.SetOwner(link);

        //    magicBoomerangLink = SpriteFactory.Instance.CreateMagicBoomerangSprite(new Vector2(0, 0));
        //    magicBoomerangLink.SetDistance(140);
        //    magicBoomerangLink.SetItemType(new BoomerangType(magicBoomerangLink));
        //    //  magicBoomerangLink.SetOwner(link);

        //    bombLink = SpriteFactory.Instance.CreateBombSprite(new Vector2(0, 0));
        //    bombLink.SetDistance(100); // How long it is on the ground
        //    bombLink.SetItemType(new BombType(bombLink));
        //    // bombLink.SetOwner(link);

        //    fireLink = SpriteFactory.Instance.CreateFireSprite(new Vector2(0, 0));
        //    fireLink.SetDistance(50);
        //    fireLink.SetItemType(new ArrowType(fireLink));
        //    //  fireLink.SetOwner(link);

        //    boomerangEnemy1 = SpriteFactory.Instance.CreateBoomerangSprite(new Vector2(0, 0));
        //    boomerangEnemy1.SetDistance(100);
        //    boomerangEnemy1.SetItemType(new BoomerangType(boomerangEnemy1));
        //    //boomerangEnemy1.SetOwner(enemy1);

        //    magicBoomerangEnemy2 = SpriteFactory.Instance.CreateMagicBoomerangSprite(new Vector2(0, 0));
        //    magicBoomerangEnemy2.SetDistance(140);
        //    magicBoomerangEnemy2.SetItemType(new BoomerangType(magicBoomerangEnemy2));
        //    // magicBoomerangEnemy2.SetOwner(enemy2);

        //    fireEnemy3 = SpriteFactory.Instance.CreateFireSprite(new Vector2(0, 0));
        //    fireEnemy3.SetDistance(50);
        //    fireEnemy3.SetItemType(new ArrowType(fireEnemy3));
        //    //fireEnemy3.SetOwner(enemy3);

        //}
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



        }

        private void registerKeyboard()
        {

            /*
            // Add item use to keyboard controller
            keyboard.RegisterCommand(Keys.D1, fireArrowLink);
            keyboard.RegisterCommand(Keys.D2, fireSilverArrowLink);
            keyboard.RegisterCommand(Keys.D3, fireBoomerangLink);
            keyboard.RegisterCommand(Keys.D4, fireMagicBoomerangLink);
            keyboard.RegisterCommand(Keys.D5, fireBombLink);
            keyboard.RegisterCommand(Keys.D6, fireFireLink);
            */


        }
    }
}