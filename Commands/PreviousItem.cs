using System;

public class PreviousItem : ICommand
{
    private ItemSelectionScreen inventory;
    public PreviousItem(ItemSelectionScreen inventory)
    {
        this.inventory = inventory;
    }
    public void Execute()
    {
        if (inventory.isOpen())
        {
            inventory.NextItem(false);
        }
    }
}


