using CSE3902Project.Controllers;
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

    public override void Update()
    { 
        //tiles don't have any update logic
    }

}

