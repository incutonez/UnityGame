using UnityEngine;

public class UIInventory : MonoBehaviour
{
    public SuitHandler suitHandler;
    public ShieldHandler shieldHandler;
    public SwordHandler swordHandler;

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
            if (item.IsRing())
            {
                suitHandler.SetSuitColor(item.itemType);
            }
            else if (item.IsShield())
            {
                shieldHandler.SetShield(item.itemType);
            }
            else if (item.IsSword())
            {
                swordHandler.SetSword(item);
            }
        }
    }
}
