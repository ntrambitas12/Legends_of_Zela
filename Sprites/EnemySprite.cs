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
    private IDraw drawSprite = new DrawAnimatedSprite();
    public override void Update()
    {
      /*This will be part of a state. Enemy updates differently based on state */
    }

    public override void Draw()
    {
        /* have this line below be in the moving state, since each state will dictate a different type of drawing*/
        
        drawSprite.Draw(this);
    }
}

