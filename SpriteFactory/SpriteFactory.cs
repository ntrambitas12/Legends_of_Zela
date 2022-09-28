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

        public Dictionary<int key, ISprite sprite> loadedSprites;

        private static SpriteFactory instance = new SpriteFactory();
        public static SpriteFactory Instance
        {
            get { return instance; }
        }

        public void LoadAllContent(ContentManager content)
        {
            // Idea: Load content from array of lists of Texture2D rather than from individual sprite sheets
            // Try to eliminate the need for multiple load calls.
        }

        public void LoadSprite(int SpriteID, int setLocation, int frameLocation, string textureName)
        {
            
        }

        public void GetNewSprite(int index)
        {
            
        }
    }
}
