using UnityEngine;

// This class is intended to be the asset manager... it holds the sprites for all of the items
public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public RectTransform prefab;

    public Sprite defaultSprite;
    public Sprite swordWooden;
    public Sprite swordDiamond;
    public Sprite swordMetallicGlass;
    public Sprite swordSteel;
}
