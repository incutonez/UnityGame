using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorld : MonoBehaviour
{
    private Item _item;
    private SpriteRenderer _renderer;

    public static ItemWorld SpawnItem(Vector3 position, Item item)
    {
        Transform transform = Instantiate(ItemAssets.Instance.prefab, position, Quaternion.identity);

        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
        itemWorld.SetItem(item);

        return itemWorld;
    }

    public static ItemWorld DropItem(Vector3 dropPosition, Item item)
    {
        return SpawnItem(dropPosition, item);
    }

    public void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    public void SetItem(Item item)
    {
        _item = item;
        _renderer.sprite = item.GetSprite();
    }

    public Item GetItem()
    {
        return _item;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
