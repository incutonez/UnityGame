using Assets.Weapons;
using System;
using UnityEngine;

public enum ItemTypes
{
    Weapon = 1,
    Elixir = 2,
    Food = 3
}

[Serializable]
public class Item
{
    public ItemTypes itemType = ItemTypes.Elixir;
    public WeaponTypes subType = WeaponTypes.None;
    public Swords subSubType = Swords.None;
    public int amount = 1;

    public virtual void Use()
    {

    }

    public Sprite GetSprite()
    {
        switch(itemType)
        {
            case ItemTypes.Weapon:
                switch(subType)
                {
                    case WeaponTypes.Sword:
                        switch(subSubType)
                        {
                            case Swords.Wooden:
                                return ItemAssets.Instance.swordWooden;
                            case Swords.Diamond:
                                return ItemAssets.Instance.swordDiamond;
                            case Swords.Steel:
                                return ItemAssets.Instance.swordSteel;
                            case Swords.MetallicGlass:
                                return ItemAssets.Instance.swordMetallicGlass;
                        }
                        break;
                }
                break;
        }
        return ItemAssets.Instance.defaultSprite;
    }

    public bool IsStackable()
    {
        switch (itemType)
        {
            case ItemTypes.Weapon:
                switch(subType)
                {
                    case WeaponTypes.Sword:
                        switch (subSubType)
                        {
                            case Swords.Diamond:
                                return false;
                        }
                        break;
                }
                break;
        }
        return true;
    }
}