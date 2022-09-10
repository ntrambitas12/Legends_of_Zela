using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public interface IPosition
    {
    public Vector2 Update(Vector2 screenPos, int spritePos);
    }

