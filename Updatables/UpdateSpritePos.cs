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
                screenCord.X-=2;
                sprite.screenCord = screenCord;
                break;
           /* Move sprite to the right */
            case 1:
                screenCord.X+=2;
                sprite.screenCord = screenCord;
                break;
            /* Move sprite up */
            case 2:
                screenCord.Y-=2;
                sprite.screenCord = screenCord;
                break;
            /* Move sprite down */
            case 3:
                screenCord.Y+=2;
                sprite.screenCord = screenCord;
                break;
            default:
                /* If none, don't change the orientation of the sprite on the screen */
                break;
        }
    }

  /*  public void smoothUp(ISprite sprite)//how to get link sprite to keyboard controller
    {
         screenCord = sprite.screenCord;
         spritePos = sprite.spritePos;

         float temp= screenCord.Y;
         temp = temp- (5-temp%10);//isolates last digit of y coordinate and rounds it to nearest 10
         screenCord.Y=temp;
         sprite.screenCord = screenCord;
    }

    public void smoothDown(ISprite sprite)//how to get link sprite to keyboard controller
    {
         screenCord = sprite.screenCord;
         spritePos = sprite.spritePos;

         float temp= screenCord.Y;
         temp. = temp+ (5-temp%10);//isolates last digit of y coordinate and rounds it to nearest 10
         screenCord.Y=temp;
         sprite.screenCord = screenCord;
    }

    public void smoothRight(ISprite sprite)//how to get link sprite to keyboard controller
    {
         screenCord = sprite.screenCord;
         spritePos = sprite.spritePos;

         float temp= screenCord.X;
         temp = temp+ (5-temp%10);//isolates last digit of y coordinate and rounds it to nearest 10
         screenCord.X=temp;
         sprite.screenCord = screenCord;
    }

    public void smoothLeft(ISprite sprite)//how to get link sprite to keyboard controller
    {
         screenCord = sprite.screenCord;
         spritePos = sprite.spritePos;

         float temp= screenCord.X;
         temp = temp- (5-temp%10);//isolates last digit of y coordinate and rounds it to nearest 10
         screenCord.X=temp;
         sprite.screenCord = screenCord;
    }*/

    public void smoothUp(ISprite sprite)//how to get link sprite to keyboard controller
    {
         screenCord = sprite.screenCord;
         spritePos = sprite.spritePos;

         float temp= screenCord.Y;
         temp = (int)temp;//rounds movement to nearest int
         screenCord.Y=temp;
         sprite.screenCord = screenCord;
    }

    public void smoothDown(ISprite sprite)//how to get link sprite to keyboard controller
    {
         screenCord = sprite.screenCord;
         spritePos = sprite.spritePos;

         float temp= screenCord.Y;
         temp = (int)temp;//rounds movement to nearest int
         screenCord.Y=temp;
         sprite.screenCord = screenCord;
    }

    public void smoothRight(ISprite sprite)//how to get link sprite to keyboard controller
    {
         screenCord = sprite.screenCord;
         spritePos = sprite.spritePos;

         float temp= screenCord.X;
         temp = (int)temp;//rounds movement to nearest int
         screenCord.X=temp;
         sprite.screenCord = screenCord;
    }

    public void smoothLeft(ISprite sprite)//how to get link sprite to keyboard controller
    {
         screenCord = sprite.screenCord;
         spritePos = sprite.spritePos;

         float temp= screenCord.X;
         temp = (int)temp;//rounds movement to nearest int
         screenCord.X=temp;
         sprite.screenCord = screenCord;
    }


}

