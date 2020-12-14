using UnityEngine;

public class SwordHandler : MonoBehaviour
{
    public SpriteRenderer sword;
    public WorldObjectData worldObjectData;

    private Items swordType;
    private DamageAttribute damage;

    public void SetSword(Item item)
    {
        sword.sprite = item?.GetSprite();
        swordType = item.itemType;
        worldObjectData.SetObjectSize(sword.sprite.bounds.size);
        damage = swordType.GetAttribute<DamageAttribute>();
    }

    public int GetDamage()
    {
        return Constants.BASE_SWORD_POWER;
    }

    public int GetDamageModifier()
    {
        return (int) damage.WeaponDamage;
    }
}
