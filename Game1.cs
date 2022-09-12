using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace CSE3902Project
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private List<Texture2D>[] marioFrames;
        private List<Texture2D> marioRight;
        private List<Texture2D> marioLeft;
        private List<ISprite> sprites;
        private EnemyController enemyController;
        private ISprite mario1;
        private ISprite mario2;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            marioFrames = new List<Texture2D>[4];
            marioLeft = new List<Texture2D>();
            marioRight = new List<Texture2D>();
            sprites = new List<ISprite>();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            for (int i = 0; i <= 2; i++)
            {
                marioRight.Add(Content.Load<Texture2D>("marioRight" + i));
                marioLeft.Add(Content.Load<Texture2D>("marioLeft" + i));

            }

            //add the mario frames to the list
            marioFrames[0] = marioRight;
            marioFrames[1] = marioLeft;
            marioFrames[2] = marioRight;
            marioFrames[3] = marioLeft;

            //create the enemy controller
            enemyController = new EnemyController();

            // create mario
            mario1 = new EnemySprite(_spriteBatch, new Vector2(450, 240), marioFrames);
            mario2 = new EnemySprite(_spriteBatch, new Vector2(250, 340), marioFrames);

            //add marios to the list 
            sprites.Add(mario1);
            sprites.Add(mario2);

            //add mario to the enemy controller
            enemyController.AddEnemy(new MoveEnemy(mario1));
            enemyController.AddEnemy(new MoveEnemy(mario2));

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            GraphicsDevice.Clear(Color.CornflowerBlue);
           

            // Update enemies on screen
            enemyController.Update();

            

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
            _spriteBatch.End();
          
            base.Draw(gameTime);
        }
    }
}