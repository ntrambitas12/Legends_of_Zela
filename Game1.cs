using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902Project
{
    public class Game1 : Game
    {

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private LevelLoader level;
        private SpriteFont textFont;
        private SpriteFont hudFont;
        private IRoomObjectManager roomObjectManager;
        private ItemSelectionScreen inventory;
        private HUD hud;
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
            hudFont = Content.Load<SpriteFont>("Fonts/NESFont");

            roomObjectManager = RoomObjectManager.Instance;
            camera = Camera.Instance;

            hud = new HUD(GraphicsDevice, _spriteBatch, hudFont, (RoomObjectManager)roomObjectManager);
            inventory = new ItemSelectionScreen(GraphicsDevice, _spriteBatch, textFont, hud);
            level = new LevelLoader(this, inventory, hud);

            //Load up the content for the sprite factory
            SoundFactory.Instance.LoadAllContent(Content);
            //plays background music
            SoundManager.Instance.playBackgroundMusic();

            SpriteFactory.Instance.LoadAllContent(Content, _spriteBatch);
            hud.sf = SpriteFactory.Instance;
            base.Initialize();
        }


        protected override void LoadContent()
        {
            level.ParseRoom();
        }

        public void resetGame()
        {
            inventory.Reset();
            camera.reset();
            roomObjectManager.Reset();
            this.Initialize();
            this.LoadContent();
            roomObjectManager.setRoom(1, true);
        }


        protected override void Update(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.Black);
            inventory.Update(gameTime, roomObjectManager.currentRoom());
            roomObjectManager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            if (inventory.isOpen())
            {
                _spriteBatch.Begin();
                inventory.Draw(gameTime);
                hud.Draw(gameTime, true);
                _spriteBatch.End();
            }

            else
            {
                _spriteBatch.Begin();
                hud.Draw(gameTime, false);
                _spriteBatch.End();

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