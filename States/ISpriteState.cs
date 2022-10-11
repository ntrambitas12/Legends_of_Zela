using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

   public interface ISpriteState
{
    public void Update(GameTime gameTime);
    public void Draw();
    public void SetPreviousState(ISpriteState state);
   
}

