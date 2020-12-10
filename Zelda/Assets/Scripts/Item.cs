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
        return ItemManager.Instance.LoadSpriteByItemType(itemType);
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

    public bool IsSword()
    {
        switch (itemType)
        {
            case Items.Sword:
            case Items.SwordMagical:
            case Items.SwordWhite:
                return true;
        }
        return false;
    }

    public bool IsRing()
    {
        switch(itemType)
        {
            case Items.RingGreen:
            case Items.RingBlue:
            case Items.RingRed:
                return true;
        }
        return false;
    }

    public bool IsShield()
    {
        switch(itemType)
        {
            case Items.Shield:
            case Items.ShieldMagical:
                return true;
        }
        return false;
    }
}