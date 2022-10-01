using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public sealed class UpdateSpritePos : IPosition
{
    private Vector2 screenCord;
    private int spritePos;

    private UpdateSpritePos(){}

    private static readonly UpdateSpritePos instance = new UpdateSpritePos();

    public static UpdateSpritePos GetInstance
    {
        get
        {
            return instance;
        }
    }
    public void Update(ISprite sprite)
    {
        screenCord = sprite.screenCord;
        spritePos = sprite.spritePos;

        switch(spritePos)
        {
            /* Move sprite to the left */
            case 0:
                if (screenCord.X >= 0 && screenCord.X <= 800)
                {
                    screenCord.X--;
                }
                else
                {
                    screenCord.X = 800;
                }
                sprite.screenCord = screenCord;
                break;
           /* Move sprite to the right */
            case 1:
                if (screenCord.X >= 0 && screenCord.X <= 800)
                {
                    screenCord.X++;
                }
                else
                {
                    screenCord.X = 0;
                }
                sprite.screenCord = screenCord;
                break;
            /* Move sprite up */
            case 2:
                if (screenCord.Y >= 0 && screenCord.Y <= 480)
                {
                    screenCord.Y--;
                }
                else
                {
                    screenCord.Y = 480;
                }
                sprite.screenCord = screenCord;
                break;
            /* Move sprite down */
            case 3:
                if (screenCord.Y >= 0 && screenCord.Y <= 480)
                {
                    screenCord.Y++;
                }
                else
                {
                    screenCord.Y = 0;
                }
                sprite.screenCord = screenCord;
                break;
            default:
                /* If none, don't change the orientation of the sprite on the screen */
                break;
        }
    }
}

