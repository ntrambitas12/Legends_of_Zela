using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

   public interface ISpriteState
    {
    public void Update();
    public void Draw();
    public void SetPreviousState(ISpriteState state);
   
}

