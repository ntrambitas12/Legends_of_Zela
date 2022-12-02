using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSE3902Project.Commands
{
    public class SaveCommand : ICommand
    {
        public SaveCommand()
        {

        }
        public void Execute()
        {
            LevelSaver.Instance.SaveLink();
            LevelSaver.Instance.SaveRooms();
        }
    }
}
