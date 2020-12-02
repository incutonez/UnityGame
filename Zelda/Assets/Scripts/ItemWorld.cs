﻿using UnityEngine;

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
            transform.sizeDelta = new Vector2(sprite.bounds.size.x, sprite.bounds.size.y);
            //Vector2 S = sprite.bounds.size;
            //collider.size = S;
            //collider.offset = new Vector2((S.x / 2), 0); ;
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
