using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class EnemySprite: AbstractSprite
    {
    public EnemySprite(SpriteBatch spriteBatch, Vector2 position, List<Texture2D>[] textures) : base(spriteBatch, position, textures) { }

    public override void Update()
    {
        animateObj = new AnimateSprite();
        updateObj = new UpdateSpritePos();

        /*Update the position of the sprite on the screen*/
        screenCord = updateObj.Update(screenCord, spritePos);
        /*Update the current frame of the sprite*/
        currentFrame = animateObj.Animate(currentFrame, totalFrames);
    }
}

