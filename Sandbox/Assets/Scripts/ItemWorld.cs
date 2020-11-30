using UnityEngine;

public class ItemWorld : MonoBehaviour
{
    private Item _item;
    private SpriteRenderer _renderer;

    private bool _draggable = false;
    public bool draggable
    {
        get
        {
            return _draggable;
        }
        set
        {
            _draggable = value;
            if (value)
            {
                gameObject.AddComponent<WorldDragDrop>();
            }
            else
            {

            }
        }
    }

    public static ItemWorld SpawnItem(Vector3 position, Item item, bool canDragDrop = false)
    {
        RectTransform transform = Instantiate(ItemAssets.Instance.prefab, position, Quaternion.identity);
        // Let's use the sprite's name to name the cloned object
        transform.name = item.GetSprite().name;

        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
        itemWorld.SetItem(item);
        itemWorld.draggable = canDragDrop;

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
