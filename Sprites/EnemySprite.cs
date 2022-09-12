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
       /*This is where code relating to the state of the enemy lives.
        * Things that need to be updated without changing the position of the enemy */
    }
}

