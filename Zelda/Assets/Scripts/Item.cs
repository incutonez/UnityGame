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

    public bool IsStackable()
    {
        return false;
    }
}