using System;

public class NextItem : ICommand
{
  
    public NextItem()
    {
       
    }
    public void Execute()
    {
        if (ItemSelectionScreen.isOpen())
        {
            ItemSelectionScreen.NextItem(true);
        }
    }
}


