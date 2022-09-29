using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSE3902Project.Controllers
{
    public abstract class AbstractController : IController
    {
        protected List<IConcreteSprite> sprites;
        protected IConcreteSprite currentSprite;

        public AbstractController()
        {
            sprites = new List<IConcreteSprite>();
            currentSprite = null;
        }
        public void AddSprite(ISprite sprite)
        {
            // kill the current sprite before adding a new sprite to the list
            if (currentSprite != null) killSprite();
            sprites.Add((IConcreteSprite)sprite);
            currentSprite = (IConcreteSprite)sprite;
            initSprite();

        }

        public abstract void Update();

        public void Draw()
        {
            foreach (var sprite in sprites)
            {
                sprite.Draw();
            }
        }
        public void nextSprite()
        {
            int listSize = sprites.Count;
            int currentIndex = sprites.IndexOf(currentSprite) + 1;

            if (currentIndex < listSize)
            {
                killSprite();
                currentSprite = sprites[currentIndex];
                initSprite();

            }

        }

        public void previousSprite()
        {
            int currentIndex = sprites.IndexOf(currentSprite) - 1;

            if (currentIndex >= 0)
            {
                killSprite();
                currentSprite = sprites[currentIndex];
                initSprite();
            }

        }

        public void resetController()
        {
            foreach (var sprite in sprites)
            {
                sprite.SetSpriteState(SpriteAction.moveLeft, sprite.dead);
            }
            sprites.Clear();
        }

        protected void killSprite()
        {
            currentSprite.SetSpriteState(SpriteAction.moveLeft, currentSprite.dead);
        }

        protected void initSprite()
        {
            currentSprite.SetSpriteState(SpriteAction.moveLeft, currentSprite.still);
        }

    }
}
