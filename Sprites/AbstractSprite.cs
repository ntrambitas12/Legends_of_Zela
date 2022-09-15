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


    private IPosition posUpdate;

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
        _spritePos = 0;
        this.textures = textures;
        posUpdate = new UpdateSpritePos();
        SetSpritePosition(_spritePos);
        

    }
    public abstract void Draw();
    
    public abstract void Update();
    public void SetSpritePosition(int spritePos)
    {
        _spritePos = spritePos;
        _textureToDraw = textures[_spritePos];
        _totalFrames = textureToDraw.Count;
        posUpdate.Update(this);
    }
    }

