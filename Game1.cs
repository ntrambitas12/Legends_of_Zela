﻿using CSE3902Project.Commands;
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


        private ISprite barrierTile;
        private ISprite bushTile;
        private ISprite compassTile;
        private ISprite mapTile;
        private IItem arrow;

        private FireProjectile fireProjectile;
        private TileSwitch tileSwitcher;
        private TileSwitch itemSwitcher;
        private NextEnemy nextEnemy;
        private PreviousEnemy previousEnemy;

        private List<Texture2D>[] boomerangFrames;
        private List<Texture2D> boomerangLeft;
        private List<Texture2D> boomerangRight;
        private List<Texture2D> boomerangUp;
        private List<Texture2D> boomerangDown;
        private IItem boomerang;
        private FireProjectile fireProjectile2;

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
            
            tiles = new List<ISprite>();
            drops = new List<ISprite>();
           
            sprites = new List<ISprite>();
            keyboard = KeyboardController.GetInstance;
            items = new List<IItem>();
            boomerangFrames = new List<Texture2D>[4];
            boomerangLeft = new List<Texture2D>();
            boomerangRight = new List<Texture2D>();
            boomerangUp = new List<Texture2D>();
            boomerangDown = new List<Texture2D>();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

<<<<<<< HEAD
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

            // Assign textures to boomerang                        (NEED TO CHANGE SO BOOMERANG ROTATES)
            boomerangLeft.Add(Content.Load<Texture2D>("ItemSprites/Boomerang"));
            boomerangRight.Add(Content.Load<Texture2D>("ItemSprites/Boomerang"));
            boomerangUp.Add(Content.Load<Texture2D>("ItemSprites/Boomerang"));
            boomerangDown.Add(Content.Load<Texture2D>("ItemSprites/Boomerang"));

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
=======
            //Load up the content for the sprite factory
            SpriteFactory.Instance.LoadAllContent(Content, _spriteBatch);
>>>>>>> develop


            // Add boomerang frames to the list
            boomerangFrames[(int)SpriteAction.moveLeft] = boomerangLeft;
            boomerangFrames[(int)SpriteAction.moveRight] = boomerangRight;
            boomerangFrames[(int)SpriteAction.moveUp] = boomerangUp;
            boomerangFrames[(int)SpriteAction.moveDown] = boomerangDown;

            // Create the enemy controller
            enemyController = EnemyController.GetInstance;

            // Create enemies
            enemy1 = SpriteFactory.Instance.CreateGoriyaSprite();
            enemy2 = SpriteFactory.Instance.CreateGoriyaSprite();
   

            // Create tiles
            barrierTile = SpriteFactory.Instance.CreateBarrierTile();
            bushTile = SpriteFactory.Instance.CreateBushTile();
            compassTile = SpriteFactory.Instance.CreateCompassTile();
            mapTile = SpriteFactory.Instance.CreateMapTile();

            // Create Arrow (Before command is created)
            arrow = SpriteFactory.Instance.CreateArrowSprite();
            arrow.SetDistance(100);
            arrow.SetProjectileType(new ArrowType(arrow));
            arrow.SetOwner(enemy1);

            // Create Boomerang (Before command is created)
            boomerang = new ConcreteItem(_spriteBatch, new Vector2(50, 50), boomerangFrames);
            boomerang.SetDistance(150);
            boomerang.SetProjectileType(new BoomerangType(boomerang));
            boomerang.SetOwner(enemy2);

            // Add enemies to the list 
            sprites.Add((ISprite)enemy1);
            sprites.Add((ISprite)enemy2);

            // Add items to command lists
            items.Add(arrow);
            items.Add(boomerang);
            tiles.Add(barrierTile);
            tiles.Add(bushTile);
            drops.Add(mapTile);
            drops.Add(compassTile);

            // Add enemies to the enemy controller
            enemyController.AddEnemy(enemy1);
            enemyController.AddEnemy(enemy2);

            // Create Commands
            fireProjectile = new FireProjectile(arrow);
            fireProjectile2 = new FireProjectile(boomerang);
            tileSwitcher = new TileSwitch(tiles);
            itemSwitcher = new TileSwitch(drops);
            previousEnemy = new PreviousEnemy(enemyController);
            nextEnemy = new NextEnemy(enemyController);

            // Add to keyboard controller
            keyboard.RegisterCommand(Keys.D1, fireProjectile, true);
            keyboard.RegisterCommand(Keys.T, tileSwitcher, true);
            keyboard.RegisterCommand(Keys.U, itemSwitcher, true);
            keyboard.RegisterCommand(Keys.P, nextEnemy, true);
            keyboard.RegisterCommand(Keys.O, previousEnemy, true);

            // Set arrow command (After command is created)
            arrow.SetFireCommand(fireProjectile);

            // Set boomerang command (After command is created)
            boomerang.SetFireCommand(fireProjectile2);

            // Set enemy fire command
            enemyController.SetFireCommand(fireProjectile2);
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
            
            tileSwitcher.currentTile.Draw();
            itemSwitcher.currentTile.Draw();
            
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}