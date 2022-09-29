﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSE3902Project.Commands
{
    public class SwitcherBack : ICommand
    {

        public ISprite currentTile;
        private List<ISprite> tiles;
        private int tileIndex;

        public SwitcherBack(List<ISprite> tiles)
        {
            this.tiles = tiles;
            tileIndex = 0;
            currentTile = tiles[tileIndex];
        }

        public void Execute()
        {
            if (tileIndex == -1)
            {
                tileIndex = tiles.Count - 1;
            }
            currentTile = tiles[tileIndex];
            tileIndex--;
        }
    }
}
