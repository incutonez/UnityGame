using UnityEngine;

public class WorldObjectData : MonoBehaviour
{
    private new RectTransform transform;
    private new SpriteRenderer renderer;
    private new BoxCollider2D collider;

    private void Awake()
    {
        transform = GetComponent<RectTransform>();
        renderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
    }

    public void SetObjectData(Sprite sprite)
    {
        // TODOJEF: Pick up here... renderer is null for the sword... something not right
        renderer.sprite = sprite;
        if (sprite != null)
        {
            Vector3 size = sprite.bounds.size;
            transform.name = sprite.name;
            SetTransformSize(size);
            SetBoxColliderSize(size);
        }
    }

    public void SetObjectSize(Vector3 size)
    {
        SetTransformSize(size);
        SetBoxColliderSize(size);
    }

    public void SetTransformSize(Vector3 size)
    {
        if (transform != null)
        {
            transform.sizeDelta = size;
        }
    }

    public void SetBoxColliderSize(Vector3 size)
    {
        if (collider != null)
        {
            collider.size = size;
        }
    }
}
