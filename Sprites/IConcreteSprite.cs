using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IConcreteSprite : ISprite
{
    public ISpriteState still { get; set; }
    public ISpriteState moving { get; set; }
    public ISpriteState damaged { get; set; }
    public ISpriteState dead { get; set; }
    public ISpriteState MoveUpState { get; set; }
    public ISpriteState MoveDownState { get; set; }
    public ISpriteState MoveLeftState { get; set; }
    public ISpriteState MoveRightState { get; set; }
    void SetSpriteState(SpriteAction action, ISpriteState spriteState);

}

