using CSE3902Project.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public sealed class ItemController : AbstractController
{
    private ItemController() : base()
    { }
    private static readonly ItemController instance = new ItemController();
    public static ItemController GetInstance
    {
        get
        {
            return instance;
        }
    }

    public override void Update()
    {
        /* Any specific item code that needs to update an item, 
         such as an item's state, or calling methods to animate an item,
        lives here in this block*/
       
    }

    protected override void initSprite()
    {
        currentSprite.SetSpriteState(SpriteAction.still, currentSprite.stillAnimated);
    }
}
