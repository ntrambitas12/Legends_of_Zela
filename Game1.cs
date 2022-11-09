
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
        private LevelLoader level;
        private SpriteFont textFont;
        private IRoomObjectManager roomObjectManager;
        private ItemSelectionScreen inventory;
        private Camera camera;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }


        protected override void Initialize()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            //load text font
            textFont = Content.Load<SpriteFont>("Fonts/InventoryFont");
            inventory = new ItemSelectionScreen(GraphicsDevice, _spriteBatch, textFont);
            level = new LevelLoader(this, inventory);
            roomObjectManager = RoomObjectManager.Instance;
            camera = Camera.Instance;
            //Load up the content for the sprite factory
            SoundFactory.Instance.LoadAllContent(Content);
            //plays background music
            SoundManager.Instance.playBackgroundMusic();

            SpriteFactory.Instance.LoadAllContent(Content, _spriteBatch);


            base.Initialize();
        }


        protected override void LoadContent()
        {
            level.ParseRoom();
        }

        public void resetGame()
        {
            camera.reset();
            roomObjectManager.Reset();
            this.Initialize();
            this.LoadContent();
            roomObjectManager.setRoom(1, true);
           
        }


        protected override void Update(GameTime gameTime)
        {
            
            GraphicsDevice.Clear(Color.Black);
            if (inventory.isOpen())
            {
                roomObjectManager.currentRoom().PauseEnemies();
            }
            roomObjectManager.currentRoom().UnpauseEnemies();
            roomObjectManager.Update(gameTime);
            inventory.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
          
            _spriteBatch.Begin();
            inventory.Draw(gameTime);
            _spriteBatch.End();

            if (!inventory.isOpen())
            {
                _spriteBatch.Begin(SpriteSortMode.Immediate,
                            BlendState.AlphaBlend,
                            null,
                            null,
                            null,
                            null,
                            camera.getTransformation(GraphicsDevice));


                roomObjectManager.Draw(gameTime);

                _spriteBatch.End();
            }

            base.Draw(gameTime);
        }
     
    }
}