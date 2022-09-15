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
    private IDraw drawSprite = new DrawSprite();
    private IPosition posUpdate = new UpdateSpritePos();

    public override void Update()
    {
        /*This will be part of a state. Enemy updates differently based on state */

        /*posUpdate is what moves the sprite around on the screen.
         * Depending on the state the sprite is in, 
         * you might not want the sprite to move on the screen, so dont call the line below if you want the sprite to stay static*/
        posUpdate.Update(this);

    }

    public override void Draw()
    {
        /* have this line below be in the moving state, since each state will 
         * dictate if the sprite needs to be drawn to the screen or not*/
        
        drawSprite.Draw(this);
    }
}

