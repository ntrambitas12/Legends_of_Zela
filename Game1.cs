
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
        //Move to spritefactory later
        private Texture2D background;
        private IRoomObjectManager roomObjectManager;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }


        protected override void Initialize()
        {
            level = new LevelLoader(this);
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            roomObjectManager = RoomObjectManager.Instance;

            //Load up the content for the sprite factory
            SpriteFactory.Instance.LoadAllContent(Content, _spriteBatch);
            background = Content.Load<Texture2D>("DungeonSprites/DungeonFloor");

            base.Initialize();
        }


        protected override void LoadContent()
        {
            //levelLoader methods:

            //Turn these into one parse method
            level.ParseRoom();

     
        }

        public void resetGame()
        {
            roomObjectManager.Reset();
            this.Initialize();
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

            roomObjectManager.Draw(gameTime);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
     
    }
}