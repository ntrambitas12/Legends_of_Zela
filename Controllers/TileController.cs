using CSE3902Project.Controllers;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public sealed class TileController : AbstractController
{
    private TileController() : base()
    { }
    private static readonly TileController instance = new TileController();
    public static TileController GetInstance
    {
        get
        {
            return instance;
        }
    }

    public override void Update(GameTime gameTime)
    { 
        //tiles don't have any update logic
    }

}

