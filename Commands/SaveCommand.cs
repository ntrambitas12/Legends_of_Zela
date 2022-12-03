using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSE3902Project.Commands
{
    public class SaveCommand : ICommand
    {
        int savefile;
        public SaveCommand(int savefile)
        {
            this.savefile = savefile;
        }
        public void Execute()
        {
            switch (savefile) {
                case 1:
                LevelSaver.Instance.SaveLink(1);
                LevelSaver.Instance.SaveRooms(1);
                    break;
                case 2:
                LevelSaver.Instance.SaveLink(2);
                LevelSaver.Instance.SaveRooms(2);
                    break;
                case 3:
                LevelSaver.Instance.SaveLink(3);
                LevelSaver.Instance.SaveRooms(3);
                    break;
            }
        }
    }
}
