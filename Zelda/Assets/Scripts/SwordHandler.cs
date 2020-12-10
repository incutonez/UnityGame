using UnityEngine;

public class SwordHandler : MonoBehaviour
{
    public SpriteRenderer sword;
    public WorldObjectSize worldObjectSize;

    private void Awake()
    {
        sword.sprite = null;
    }

    public void SetSword(Item item)
    {
        sword.sprite = item?.GetSprite();
        worldObjectSize.SetObjectSize(sword.sprite.bounds.size);
    }
}
