using Enums;
using System;
using UnityEngine;

[Serializable]
public class Item
{
    public Items itemType;
    public int amount;

    public Sprite GetSprite()
    {
        return ItemManager.Instance.LoadSprite(itemType);
    }

    // TODOJEF: Add GetPickupSound and play it when item is picked up

    public bool IsStackable()
    {
        switch(itemType)
        {
            case Items.Bomb:
            case Items.Key:
            case Items.RupeeOne:
            case Items.RupeeFive:
                return true;
            default:
                return false;
        }
    }
}