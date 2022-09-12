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
    public int totalFrames { get { return _totalFrames; } set { _totalFrames = value; } }

    private int _currentFrame;
    private int _totalFrames;
    private int _spritePos;
    private SpriteBatch spriteBatch;
    private Vector2 _screenCord;
    private List<Texture2D>[] textures;
    private List<Texture2D> textureToDraw;

    public AbstractSprite(SpriteBatch spriteBatch, Vector2 position, List<Texture2D>[] textures)
    {
        this.spriteBatch = spriteBatch;
        _screenCord = position;
        _spritePos = 0;
        this.textures = textures;
        SetSpritePosition(_spritePos);
        

    }
    public void Draw()
    {
        spriteBatch.Draw(textureToDraw[_currentFrame], _screenCord, Color.White);


    }
    
    public abstract void Update();
    public void SetSpritePosition(int spritePos)
    {
        _spritePos = spritePos;
        textureToDraw = textures[_spritePos];
        _totalFrames = textureToDraw.Count;
    }
    }

