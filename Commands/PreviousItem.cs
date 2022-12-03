using System;

public class PreviousItem : ICommand
{
    public PreviousItem()
    {
        
    }
    public void Execute()
    {
        if (ItemSelectionScreen.isOpen())
        {
            ItemSelectionScreen.NextItem(false);
        }
    }
}


