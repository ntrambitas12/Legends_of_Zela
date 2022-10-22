
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
        private IRoomObjectManager roomObjectManager;
//<<<<<<< HEAD
//        //Move to spritefactory later
//        private Texture2D background;
//        

//=======
//>>>>>>> origin/AttackRework

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

            base.Initialize();
        }


        protected override void LoadContent()
        {
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

            roomObjectManager.Draw(gameTime);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
     
    }
}