using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CSE3902Project.Commands
{
    public class LinkUse : ICommand
    {
        private IConcreteSprite Link;
        private ISpriteState state;

        public LinkUse(IConcreteSprite link)
        {
            this.Link = link;
            //this.state = link.currentState???
        }
        public void Execute()
        {
            /* Link needs to be updated with the correct use command that corresponds to the direction he is facing */
            //switch(state)
            //{
            //    
            //}
        }
    }
}