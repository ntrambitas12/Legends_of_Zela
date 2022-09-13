using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class AnimateSprite: IAnimate
    {
    private int currentFrame;
    private int totalFrames;
    public void Animate(ISprite sprite)
    {
        //get the current frames from the sprite instance variables
        currentFrame = sprite.currentFrame;
        totalFrames = sprite.totalFrames;

        currentFrame++;
        if (currentFrame == totalFrames)
        {
            currentFrame = 0;
        }

        //update the instance variables for the sprite
        sprite.currentFrame = currentFrame;
        sprite.totalFrames = totalFrames;
    }

}

