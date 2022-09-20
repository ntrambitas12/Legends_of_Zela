using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IConcreteSprite
{
    public int currentFrame { get; set; }
    public int totalFrames { get; set; }
    public int spritePos { get; set; }
    public ISpriteState still { get; set; }
    public ISpriteState moving { get; set; }
    public ISpriteState damaged { get; set; }
    public SpriteBatch spriteBatch { get; set; }
    public Vector2 screenCord { get; set; }
    public List<Texture2D> textureToDraw { get; set; }
    void Draw();
    void Update();
    void SetSpriteAction(SpriteAction action);
    void SetSpriteState(SpriteAction action, ISpriteState spriteState);

}

