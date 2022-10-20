
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
     
    }
}