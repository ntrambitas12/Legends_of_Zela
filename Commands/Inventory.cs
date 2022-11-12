using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Inventory : ICommand
{
    private ItemSelectionScreen inventory;
    public Inventory(ItemSelectionScreen inventory)
    {
        this.inventory = inventory;
    }
    public void Execute()
    {
        inventory.ActivateItemSelection();
    }
}

