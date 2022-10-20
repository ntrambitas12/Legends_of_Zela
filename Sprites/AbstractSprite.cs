using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


   public abstract class AbstractSprite: ISprite
    {
    public int currentFrame { get { return _currentFrame; } set { _currentFrame = value; } }
    public int spritePos { get { return _spritePos; } set { _spritePos = value; } }
    public Vector2 screenCord { get { return _screenCord; } set { _screenCord = value; } }
    public int totalFrames { get { return _totalFrames; } set {} }
    public SpriteBatch spriteBatch { get { return _spriteBatch; } set {} }
    public List<Texture2D> textureToDraw { get { return _textureToDraw; } set {} }

    /*Declare collider variable*/
    public ICollision collider { get; set; }

    private int _currentFrame;
    private int _totalFrames;
    private int _spritePos;
    private SpriteBatch _spriteBatch;
    private Vector2 _screenCord;
    private List<Texture2D>[] textures;
    private List<Texture2D> _textureToDraw;

    public AbstractSprite(SpriteBatch spriteBatch, Vector2 position, List<Texture2D>[] textures)
    {
        _spriteBatch = spriteBatch;
        _screenCord = position;
        this.textures = textures;
        //needed to get code to intialize
        _spritePos = 999;
        SetSpriteAction(SpriteAction.still);
        

    }
    public abstract void Draw(GameTime gameTime);
    
    public abstract void Update(GameTime gameTime);

    /* This method, SetSpriteAction, sets the correct set of textures to draw, based on the desired action of the sprite.
     * Examples include: set the texture for the sprite moving left, set the texture for sprite moving right,
     * texture for sprite attacking facing left, etc. Textures are loaded in from an array of lists,
     * where each element in the array contains a different list of motion frames of the sprite
     */
    public void SetSpriteAction(SpriteAction action)
    {
        //only run if spritePos changes
        if ((int)action != _spritePos)
        {
            _spritePos = (int)action;
             _textureToDraw = textures[_spritePos];
            _totalFrames = textureToDraw.Count;
            _currentFrame = 0;
       }
    }//at FireProjectile.Execute() in /Users/kylehoefker/Desktop/CSE3902Project/Commands/FireProjectile.cs:line 27\n   at ConcreteSprite.ProjectileAttack() in /Users/kylehoefker/Desktop/CSE3902Project/Sprites/ConcreteSprite.cs:line 100\n   at UseState.Update(GameTime gameTime) in /Users/kylehoefker/Desktop/CSE3902Project/States/UseState.cs:line 52\n   at ConcreteSprite.Update(GameTime gameTime) in /Users/kylehoefker/Desktop/CSE3902Project/Sprites/ConcreteSprite.cs:line 80\n   at RoomObject.Update(GameTime gameTime) in /Users/kylehoefker/Desktop/CSE3902Project/GameObject/RoomObject.cs:line 92\n   at RoomObjectManager.Update(GameTime gameTime) in /Users/kylehoefker/Desktop/CSE3902Project/GameObject/RoomObjectManager.cs:line 54\n   at CSE3902Project.Game1.Update(GameTime gameTime) in /Users/kylehoefker/Desktop/CSE3902Project/Game1.cs:line 115\n   at Microsoft.Xna.Framework.Game.DoUpdate(GameTime gameTime)\n   at Microsoft.Xna.Framework.Game.Tick()\n   at Microsoft.Xna.Framework.SdlGamePlatform.RunLoop()\n   at Microsoft.Xna.Framework.Game.Run(GameRunBehavior runBehavior)\n   at Program.<Main>$(String[] args) in /Users/kylehoefker/Desktop/CSE3902Project/Program.cs:line 3"
    }

