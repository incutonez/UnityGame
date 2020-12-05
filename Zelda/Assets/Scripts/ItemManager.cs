using Enums;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private Sprite[] sprites;

    public static ItemManager Instance { get; private set; }
    public RectTransform prefab;

    private void Awake()
    {
        Instance = this;
        sprites = Resources.LoadAll<Sprite>("Sprites/items");
        LoadAllItems();
    }

    public Sprite LoadSpriteByItemType(Items itemType)
    {
        return LoadSprite(itemType.GetCustomAttr("Resource"));
    }

    // Idea taken from https://answers.unity.com/questions/1417421/how-to-load-all-my-sprites-in-my-folder-and-put-th.html
    public Sprite LoadSprite(string spriteName)
    {
        Sprite sprite = null;
        foreach (Sprite item in sprites)
        {
            if (item.name == spriteName)
            {
                sprite = item;
                break;
            }
        }
        return sprite;

    }

    #region Debug
    /// <summary>
    /// This method will load all of the available items from the enum and place them in the world
    /// in a sequential order... it's used for debugging purposes only
    /// </summary>
    public void LoadAllItems()
    {
        var x = -1.9f;
        var y = 0.9f;
        List<Items> items = EnumExtensions.GetValues<Items>();
        foreach (Items item in items)
        {
            ItemWorld.SpawnItem(new Vector3(x, y), new Item { itemType = item });
            x += .2f;
            if (x > 1.9)
            {
                x = -1.9f;
                y -= 0.2f;
            }
        }
    }
    #endregion
}
