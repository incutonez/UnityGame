using UnityEngine;

public class WorldCharacter<T> : MonoBehaviour where T : BaseCharacter
{
    public T character;
    public new SpriteRenderer renderer;
    public new RectTransform transform;
    public new BoxCollider2D collider;

    private WorldObjectData worldObjectData;

    private void Awake()
    {
        worldObjectData = GetComponent<WorldObjectData>();
        renderer = GetComponent<SpriteRenderer>();
        transform = GetComponent<RectTransform>();
        collider = GetComponent<BoxCollider2D>();
    }

    public void SetCharacter(T character)
    {
        this.character = character;
        character.Initialize();
        Sprite sprite = character.GetSprite();
        if (sprite != null)
        {
            renderer.sprite = sprite;
            worldObjectData.SetObjectName(sprite.name);
            worldObjectData.SetObjectSize(sprite.bounds.size);
        }
    }

    public float GetTouchDamage()
    {
        return character.GetTouchDamage();
    }

    public float GetWeaponDamage()
    {
        return character.GetWeaponDamage();
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }

    public T GetCharacter()
    {
        return character;
    }
}
