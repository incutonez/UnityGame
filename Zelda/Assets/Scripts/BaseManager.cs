using System;
using UnityEngine;

public class BaseManager<T> : MonoBehaviour
{
    private Sprite[] sprites;
    public RectTransform prefab;

    public static TWorldCharacter Spawn<TWorldCharacter, TManager, TCharacter, TEnum>(TManager Instance, Vector3 position, TEnum characterType)
        where TWorldCharacter : WorldCharacter<TCharacter>
        where TManager : BaseManager<T>
        where TCharacter : BaseCharacter, new()
        where TEnum : Enum
    {
        RectTransform transform = Instantiate(Instance.prefab, position, Quaternion.identity);

        TWorldCharacter worldCharacter = transform.GetComponent<TWorldCharacter>();
        TCharacter character = new TCharacter { characterType = characterType };
        worldCharacter.SetCharacter(character, Instance.LoadSprite(character.GetSpriteName()));

        return worldCharacter;
    }

    public void LoadSprites(string spriteLocation)
    {
        sprites = Resources.LoadAll<Sprite>(spriteLocation);
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
