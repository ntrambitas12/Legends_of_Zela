using Microsoft.Xna.Framework;
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
        protected List<IProjectile> projectiles;
        protected IConcreteSprite currentSprite;
        protected IProjectile currentProjectile;

        public AbstractController()
        {
            sprites = new List<IConcreteSprite>();
            projectiles = new List<IProjectile>();
            currentSprite = null;
            currentProjectile = null;
        }

        public void AddSprite(ISprite sprite, IProjectile projectile)
        {
            // kill the current sprite before adding a new sprite to the list
            if (currentSprite != null) killSprite();
            sprites.Add((IConcreteSprite)sprite);
            currentSprite = (IConcreteSprite)sprite;
            initSprite();
            if (currentProjectile != null) killProjectile();
            projectiles.Add(projectile);
            currentProjectile = projectile;
            initProjectile();
        }

        public void AddSprite(ISprite sprite)
        {
            // kill the current sprite before adding a new sprite to the list
            if (currentSprite != null) killSprite();
            sprites.Add((IConcreteSprite)sprite);
            currentSprite = (IConcreteSprite)sprite;
            initSprite();
        }

        public abstract void Update(GameTime gameTime);

        public void Draw(GameTime gameTime)
        {
            foreach (var sprite in sprites)
            {
                sprite.Draw(gameTime);
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
                if (currentProjectile != null)
                {
                    killProjectile();
                    currentProjectile = projectiles[currentIndex];
                    initProjectile();
                }
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
                if (currentProjectile != null)
                {
                    killProjectile();
                    currentProjectile = projectiles[currentIndex];
                    initProjectile();
                }
            }

        }

        public void resetController()
        {
            foreach (var sprite in sprites)
            {
                sprite.SetSpriteState(SpriteAction.moveLeft, sprite.dead);
            }
            sprites.Clear();
            foreach (var projectile in projectiles)
            {
                projectile.SetShouldDraw(false);
            }
            projectiles.Clear();
        }

        protected void killSprite()
        {
            currentSprite.SetSpriteState(SpriteAction.moveLeft, currentSprite.dead);
        }

        protected void killProjectile()
        {
            currentProjectile.SetShouldDraw(false);
        }

        protected virtual void initSprite()
        {
            currentSprite.SetSpriteState(SpriteAction.still, currentSprite.still);
        }

        protected virtual void initProjectile()
        {
            currentProjectile.SetShouldDraw(true);
        }

    }
}
