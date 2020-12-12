using NPCs;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private Sprite[] sprites;

    public static EnemyManager Instance { get; private set; }
    public RectTransform prefab;

    private void Awake()
    {
        Instance = this;
        sprites = Resources.LoadAll<Sprite>("Sprites/enemies");
    }

    public Sprite LoadSpriteByType(Enemies enemyType)
    {
        return LoadSprite(enemyType.GetCustomAttr("Resource"));
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
}
