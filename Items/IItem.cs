using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

public interface IItem : ISprite
{
    public bool ShouldDraw();
    public void SetShouldDraw(Boolean condition);
    public Vector2 Position();
    public void SetPosition(Vector2 pos);
    public ISprite Owner();
    public void SetOwner(ISprite owner);
    public IItemType ItemType();
    public void SetItemType(IItemType itemType);
}
