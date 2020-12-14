using UnityEngine;

public class SwordHandler : MonoBehaviour
{
    public SpriteRenderer sword;
    public WorldObjectData worldObjectData;

    private Items swordType;
    private DamageAttribute damage;

    public void Awake()
    {
        sword = GetComponent<SpriteRenderer>();
        worldObjectData = GetComponent<WorldObjectData>();
    }

    public void SetSword(Item item)
    {
        swordType = item.itemType;
        worldObjectData.SetObjectData(item?.GetSprite());
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
