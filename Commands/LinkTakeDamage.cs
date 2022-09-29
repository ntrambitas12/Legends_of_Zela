using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CSE3902Project.Commands
{
    public class LinkTakeDamage : ICommand
    {
        private ISprite Link;

        public LinkTakeDamage(ISprite link)
        {
            this.Link = link;
        }
        public void Execute()
        {
            Link.SetSpriteAction(SpriteAction.damage);
        }
    }
}