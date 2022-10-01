using CSE3902Project.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class NextSprite : ICommand
{
    private AbstractController controller;

    public NextSprite(AbstractController controller)
    {
        this.controller = controller;
    }

    public void Execute()
    {
        controller.nextSprite();
    }
}

