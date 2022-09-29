using CSE3902Project.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class PreviousSprite : ICommand
{
    private AbstractController controller;

    public PreviousSprite(AbstractController controller)
    {
        this.controller = controller;
    }

    public void Execute()
    {
        controller.previousSprite();
    }
}

