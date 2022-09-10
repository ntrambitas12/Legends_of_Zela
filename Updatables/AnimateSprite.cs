using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class AnimateSprite: IAnimate
    {
    public int Animate(int currentFrame, int totalFrames)
    {
        currentFrame++;
        if (currentFrame == totalFrames)
        {
            currentFrame = 0;
        }
        return currentFrame;
    }

}

