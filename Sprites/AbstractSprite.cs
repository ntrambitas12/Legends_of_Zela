using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


   public abstract class AbstractSprite: ISprite
    {
    private int currentFrame;
    private int totalFrames;
    private int spritePos;
    private SpriteBatch spriteBatch;
    private Vector2 screenCord;
    private List<Texture2D>[] textures;
    private List<Texture2D> textureToDraw;

    public AbstractSprite(SpriteBatch spriteBatch, Vector2 position, List<Texture2D>[] textures)
    {
        this.spriteBatch = spriteBatch;
        this.screenCord = position;
        this.spritePos = 0;
        this.textures = textures;
        currentFrame = 0;
        
    }
    public void Draw()
    {
        spriteBatch.Draw(textureToDraw[currentFrame], screenCord, Color.White);


    }
    
    public abstract void Update();
    public void SetSpritePosition(int spritePos)
    {
        this.spritePos = spritePos;
        textureToDraw = textures[spritePos];
        totalFrames = textureToDraw.Count;
    }
    }

