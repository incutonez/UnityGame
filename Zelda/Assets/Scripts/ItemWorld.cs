using Enums;
using UnityEngine;

public class ItemWorld : MonoBehaviour
{
    public Item item;
    public new SpriteRenderer renderer;
    public new RectTransform transform;
    public new BoxCollider2D collider;

    public static ItemWorld SpawnItem(Vector3 position, Item item)
    {
        RectTransform transform = Instantiate(ItemManager.Instance.prefab, position, Quaternion.identity);

        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
        itemWorld.SetItem(item);

        return itemWorld;
    }

    public static ItemWorld DropItem(Vector3 dropPosition, Item item)
    {
        return SpawnItem(dropPosition, item);
    }

    public void SetItem(Item item)
    {
        this.item = item;
        Sprite sprite = item.GetSprite();
        if (sprite != null)
        {
            renderer.sprite = sprite;
            // Let's use the sprite's name to name the cloned object
            transform.name = sprite.name;
            // Need to make sure our character is sized properly with both the transform and collider
            transform.sizeDelta = sprite.bounds.size;
            collider.size = sprite.bounds.size;
            // If we have a Heart, we need to make it blink, so let's add that animation
            if (item.itemType == Items.Heart)
            {
                Animator anim = gameObject.AddComponent<Animator>();
                anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("HeartBlinkController");
            }
        }
    }

    public Item GetItem()
    {
        return item;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
