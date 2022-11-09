using System;

public class NextItem : ICommand
{
    private ItemSelectionScreen inventory;
    public NextItem(ItemSelectionScreen inventory)
    {
        this.inventory = inventory;
    }
    public void Execute()
    {
        if (inventory.isOpen())
        {
            inventory.NextItem(true);
        }
    }
}


