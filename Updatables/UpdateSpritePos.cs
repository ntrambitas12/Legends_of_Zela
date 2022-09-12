using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UpdateSpritePos: IPosition
{
    public Vector2 Update(Vector2 screenPos, int spritePos)
    {
        
        switch(spritePos)
        {
            /*move sprite to the right*/
            case 0:
                if (screenPos.X >= 0 && screenPos.X <= 800)
                {
                    screenPos.X++;
                }
                else
                {
                    screenPos.X = 0;
                }
                break;
           /*move sprite to the left*/
            case 1:
                if (screenPos.X >= 0 && screenPos.X <= 800)
                {
                    screenPos.X--;
                }
                else
                {
                    screenPos.X = 800;
                }
                break;
            /*move sprite up*/
            case 2:
                if (screenPos.Y >= 0 && screenPos.Y <= 480)
                {
                    screenPos.Y++;
                }
                else
                {
                    screenPos.Y = 0;
                }
                break;
            /*move sprite down*/
            case 3:
                if (screenPos.Y >= 0 && screenPos.Y <= 480)
                {
                    screenPos.Y--;
                }
                else
                {
                    screenPos.Y = 480;
                }
                break;
                default:
                break;
        }
        return screenPos;
    }
}

