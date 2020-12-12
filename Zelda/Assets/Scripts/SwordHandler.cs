using UnityEngine;

public class SwordHandler : MonoBehaviour
{
    public SpriteRenderer sword;
    public WorldObjectData worldObjectData;

    private void Awake()
    {
        sword.sprite = null;
    }

    public void SetSword(Item item)
    {
        sword.sprite = item?.GetSprite();
        worldObjectData.SetObjectSize(sword.sprite.bounds.size);
    }
}
