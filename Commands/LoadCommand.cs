using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSE3902Project.Commands
{
    public class LoadCommand : ICommand
    {
        int savefile;
        private Game1 game;
        public LoadCommand(int savefile, Game1 game)
        {
            this.savefile = savefile;
            this.game = game;
        }
        public void Execute()
        {
            switch (savefile) {
                case 1:
                    Game1.defaultLinkPath = "SavedData/1/";
                    Game1.defaultRoomPath = "SavedData/1/";
                    break;
                case 2:
                    Game1.defaultLinkPath = "SavedData/2/";
                    Game1.defaultRoomPath = "SavedData/2/";
                    break;
                case 3:
                    Game1.defaultLinkPath = "SavedData/3/";
                    Game1.defaultRoomPath = "SavedData/3/";
                    break;
            }
            game.resetGame();
        }
    }
}
