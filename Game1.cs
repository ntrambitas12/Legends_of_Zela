
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
        private IRoomObjectManager roomObjectManager;
        private LevelLoader level;

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

            base.Initialize();
        }


        protected override void LoadContent()
        {
            level.ParseRoom();
        }

        public void resetGame()
        {
           this.Initialize();
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

            roomObjectManager.Draw(gameTime);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
     
    }
}