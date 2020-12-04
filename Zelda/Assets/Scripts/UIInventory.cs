using Enums;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    public SuitHandler suitHandler;

    private Inventory inventory;
    private PlayerCharacter player;

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        inventory.OnItemListChanged += Inventory_OnItemListChanged;
    }

    public void SetPlayer(PlayerCharacter player)
    {
        this.player = player;
    }

    private void Inventory_OnItemListChanged(object sender, InventoryChangeArgs args)
    {
        Item item = args.item;
        if (item != null)
        {
            switch(item.itemType)
            {
                case Items.RingBlue:
                case Items.RingRed:
                    suitHandler.SetSuitColor(item.itemType);
                    break;
            }
        }
    }
}
