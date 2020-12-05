using Enums;
using UnityEngine;

public class ShieldHandler : MonoBehaviour
{
    public SpriteRenderer shield;

    public void SetShield(Items itemType)
    {
        shield.sprite = ItemManager.Instance.LoadSprite(itemType);
    }
}
