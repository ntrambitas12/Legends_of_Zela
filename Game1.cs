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
        private List<Texture2D>[] arrowFrames;
        private List<Texture2D> arrowLeft;
        private List<Texture2D> arrowRight;
        private List<Texture2D> arrowUp;
        private List<Texture2D> arrowDown;
        private List<ISprite> sprites;
        private EnemyController enemyController;
        private IConcreteSprite mario1;
        private IConcreteSprite mario2;
        private IItem arrow;
        private List<IItem> items;
        private FireProjectile fireProjectile;
        private KeyboardController keyboard;

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
            arrowFrames = new List<Texture2D>[4];
            arrowLeft = new List<Texture2D>();
            arrowRight = new List<Texture2D>();
            arrowUp = new List<Texture2D>();
            arrowDown = new List<Texture2D>();
            sprites = new List<ISprite>();
            items = new List<IItem>();
            keyboard = new KeyboardController();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            for (int i = 1; i <= 2; i++)
            {
                marioRight.Add(Content.Load<Texture2D>("LinkSprites/LinkRight" + i));
                marioLeft.Add(Content.Load<Texture2D>("LinkSprites/LinkLeft" + i));

            }

            arrowLeft.Add(Content.Load<Texture2D>("ItemSprites/ArrowLeft"));
            arrowRight.Add(Content.Load<Texture2D>("ItemSprites/ArrowRight"));
            arrowUp.Add(Content.Load<Texture2D>("ItemSprites/ArrowUp"));
            arrowDown.Add(Content.Load<Texture2D>("ItemSprites/ArrowDown"));

            //add the mario frames to the list
            marioFrames[0] = marioRight;
            marioFrames[1] = marioLeft;
            marioFrames[2] = marioRight;
            marioFrames[3] = marioLeft;

            arrowFrames[(int)SpriteAction.stillLeft] = arrowLeft;
            arrowFrames[(int)SpriteAction.stillRight] = arrowRight;
            arrowFrames[(int)SpriteAction.stillUp] = arrowUp;
            arrowFrames[(int)SpriteAction.stillDown] = arrowDown;

            //create the enemy controller
            enemyController = new EnemyController();

            // create mario
            mario1 = new ConcreteSprite(_spriteBatch, new Vector2(450, 240), marioFrames);
            mario2 = new ConcreteSprite(_spriteBatch, new Vector2(250, 340), marioFrames);

            arrow = new ConcreteItem(_spriteBatch, new Vector2(50, 50), arrowFrames);
            arrow.SetDistance(100);
            arrow.SetProjectileType(new BombType(arrow));

            //add marios to the list 
            sprites.Add((ISprite)mario1);
            sprites.Add((ISprite)mario2);

            items.Add(arrow);

            //add mario to the enemy controller
            enemyController.AddEnemy(new MoveEnemy(mario1));
            enemyController.AddEnemy(new MoveEnemy(mario2));

            // Create fireProjectile command
            fireProjectile = new FireProjectile((ISprite)mario1, arrow); // SetDist and Set PType before this

            // Add to keyboard controller
            keyboard.RegisterCommand(Keys.D1, fireProjectile);

            arrow.SetFireCommand(fireProjectile);
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
            _spriteBatch.End();
          
            base.Draw(gameTime);
        }
    }
}