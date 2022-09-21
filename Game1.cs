using CSE3902Project.Commands;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Threading;

namespace CSE3902Project
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private List<Texture2D>[] linkFrames;
        private List<Texture2D> linkRight;
        private List<Texture2D> linkLeft;
        private List<Texture2D> linkUp;
        private List<Texture2D> linkDown;
        private List<Texture2D>[] goriyaFrames;
        private List<Texture2D> goriyaRight;
        private List<Texture2D> goriyaLeft;
        private List<Texture2D> goriyaUp;
        private List<Texture2D> goriyaDown;
        private List<Texture2D>[] arrowFrames;
        private List<Texture2D> arrowLeft;
        private List<Texture2D> arrowRight;
        private List<Texture2D> arrowUp;
        private List<Texture2D> arrowDown;
        private List<ISprite> sprites;
        private EnemyController enemyController;
        private IConcreteSprite enemy1;
        private IConcreteSprite enemy2;
        private IItem arrow;
        private List<IItem> items;
        private ICommand fireProjectile;
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
            linkFrames = new List<Texture2D>[4];
            linkLeft = new List<Texture2D>();
            linkRight = new List<Texture2D>();
            linkDown = new List<Texture2D>();
            linkUp = new List<Texture2D>();
            goriyaFrames = new List<Texture2D>[4];
            goriyaLeft = new List<Texture2D>();
            goriyaRight = new List<Texture2D>();
            goriyaDown = new List<Texture2D>();
            goriyaUp = new List<Texture2D>();
            arrowFrames = new List<Texture2D>[4];
            arrowLeft = new List<Texture2D>();
            arrowRight = new List<Texture2D>();
            arrowUp = new List<Texture2D>();
            arrowDown = new List<Texture2D>();
            sprites = new List<ISprite>();
            keyboard = new KeyboardController();
            items = new List<IItem>();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            for (int i = 1; i <= 2; i++)
            {
                linkRight.Add(Content.Load<Texture2D>("LinkSprites/linkRight" + i));
                linkLeft.Add(Content.Load<Texture2D>("LinkSprites/linkLeft" + i));
                linkUp.Add(Content.Load<Texture2D>("LinkSprites/linkUp" + i));
                linkDown.Add(Content.Load<Texture2D>("LinkSprites/linkDown" + i));

                goriyaRight.Add(Content.Load<Texture2D>("EnemySprites/GoriyaRedRight" + i));
                goriyaLeft.Add(Content.Load<Texture2D>("EnemySprites/GoriyaRedLeft" + i));
                goriyaUp.Add(Content.Load<Texture2D>("EnemySprites/GoriyaRedUp" + i));
                goriyaDown.Add(Content.Load<Texture2D>("EnemySprites/GoriyaRedDown" + i));

            }

            arrowLeft.Add(Content.Load<Texture2D>("ItemSprites/ArrowLeft"));
            arrowRight.Add(Content.Load<Texture2D>("ItemSprites/ArrowRight"));
            arrowUp.Add(Content.Load<Texture2D>("ItemSprites/ArrowUp"));
            arrowDown.Add(Content.Load<Texture2D>("ItemSprites/ArrowDown"));

            //add the mario frames to the list
            linkFrames[0] = linkRight;
            linkFrames[1] = linkLeft;
            linkFrames[2] = linkDown;
            linkFrames[3] = linkUp;

            //add example enemy frames to the list
            goriyaFrames[0] = goriyaRight;
            goriyaFrames[1] = goriyaLeft;
            goriyaFrames[2] = goriyaDown;
            goriyaFrames[3] = goriyaUp;

            arrowFrames[(int)SpriteAction.stillLeft] = arrowLeft;
            arrowFrames[(int)SpriteAction.stillRight] = arrowRight;
            arrowFrames[(int)SpriteAction.stillUp] = arrowUp;
            arrowFrames[(int)SpriteAction.stillDown] = arrowDown;

            //create the enemy controller
            enemyController = new EnemyController();

            // create mario
            enemy1 = new ConcreteSprite(_spriteBatch, new Vector2(450, 240), linkFrames);
            enemy2 = new ConcreteSprite(_spriteBatch, new Vector2(250, 340), goriyaFrames);

            // Create new items
            arrow = new ArrowItem(_spriteBatch, new Vector2(50, 50), arrowFrames);

            //add marios to the list 
            sprites.Add((ISprite)enemy1);
            sprites.Add((ISprite)enemy2);

            // Add items to command lists
            items.Add(arrow);

            //add mario to the enemy controller
            enemyController.AddEnemy(new MoveEnemy(enemy1));
            enemyController.AddEnemy(new MoveEnemy(enemy2));

            // Create fireProjectile Command
            fireProjectile = new FireProjectile((ISprite)enemy1, arrow);

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