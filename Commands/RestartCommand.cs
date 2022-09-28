﻿using System;
using Microsoft.Xna.Framework;

namespace CSE3902Project
{
    public class RestartCommand : ICommand
    {
        private Game1 game;
        public RestartCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.resetGame();
           
        }
    }
}
