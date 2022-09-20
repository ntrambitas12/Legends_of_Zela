using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSE3902Project.SpriteFactory
{
    public class SpriteFactory : IFactory
    {

        private Texture2D linkSpriteSheet;
        // More sheets potentially placed here based on approach

        private static SpriteFactory instance = new SpriteFactory();
        public static SpriteFactory Instance
        {
            get { return instance; }
        }

        public void LoadAllContent(ContentManager content)
        {
            linkSpriteSheet = content.Load<Texture2D>("LinkSprites");

            // Idea: Load content from array of lists of Texture2D rather than from individual sprite sheets
            // Try to eliminate the need for multiple load calls.
            // Furthermore, CreateSprite could return the enum of the associated sprite in the array
        }

        public void CreateSprite()
        {
            //return new ISprite();
        }
    }
}
