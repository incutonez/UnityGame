using UnityEngine;

public class SwordHandler : MonoBehaviour
{
    public SpriteRenderer sword;

    private void Awake()
    {
        sword.sprite = null;
    }

    public void SetSword(Item item)
    {
        sword.sprite = item?.GetSprite();
    }
}
