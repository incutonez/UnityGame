using System;
using System.Collections.Generic;

public class Inventory
{
    public event EventHandler OnItemListChanged;

    private Action<Item> _useItemAction;
    private List<Item> items;

    public Inventory(Action<Item> useItemAction)
    {
        _useItemAction = useItemAction;
        items = new List<Item>();
    }

    public void AddItem(Item item)
    {
        if (item != null)
        {
            if (item.IsStackable())
            {
                bool isInInventory = false;
                foreach (Item it in items)
                {
                    if (it.itemType == item.itemType)
                    {
                        isInInventory = true;
                        it.amount += item.amount;
                        break;
                    }
                }
                if (!isInInventory)
                {
                    items.Add(item);
                }
            }
            else
            {
                items.Add(item);
            }
            OnItemListChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public void RemoveItem(Item item)
    {
        if (item.IsStackable())
        {
            Item inventoryItem = null;
            foreach (Item it in items)
            {
                if (it.itemType == item.itemType)
                {
                    inventoryItem = it;
                    it.amount -= item.amount;
                    break;
                }
            }
            if (inventoryItem != null && inventoryItem.amount <= 0)
            {
                items.Remove(inventoryItem);
            }
        }
        else
        {
            items.Remove(item);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void UseItem (Item item)
    {
        _useItemAction(item);
    }

    public List<Item> GetItems()
    {
        return items;
    }
}
