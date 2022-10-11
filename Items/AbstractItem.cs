using System;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

public abstract class AbstractItem : AbstractSprite, IItem
{
    private IDraw drawSprite;
    private IPosition posUpdate;
    private IItemType itemType;
    private Vector2 changeCord;
    private Boolean shouldDraw;
    private ISprite owner;

    public AbstractItem(SpriteBatch spriteBatch, Vector2 position, List<Texture2D>[] textures) : base(spriteBatch, position, textures)
    {
        drawSprite = DrawSprite.GetInstance;
        posUpdate = UpdateSpritePos.GetInstance;
        itemType = null;
        changeCord = this.screenCord;
        shouldDraw = false;
        owner = null;
    }

    public override void Draw()
    {
        if (shouldDraw)
        {
            drawSprite.Draw(this, Color.White, true);
        }
    }

    public override void Update(GameTime gameTime)
    {
        itemType.Update(gameTime);
    }

    public bool ShouldDraw()
    {
        return shouldDraw;
    }

    public void SetShouldDraw(bool condition)
    {
        shouldDraw = condition;
    }

    public Vector2 Position()
    {
        return this.screenCord;
    }

    public void SetPosition(Vector2 pos)
    {
        changeCord = pos;
        this.screenCord = changeCord;
    }

    public ISprite Owner()
    {
        return this.owner;
    }

    public void SetOwner(ISprite owner)
    {
        this.owner = owner;
    }

    public IItemType ItemType()
    {
        return this.itemType;
    }

    public void SetItemType(IItemType itemType)
    {
        this.itemType = itemType;
    }
}

