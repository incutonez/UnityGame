using UnityEngine;

public class WorldObjectSize : MonoBehaviour
{
    private new RectTransform transform;
    private new SpriteRenderer renderer;
    private new BoxCollider2D collider;

    private void Awake()
    {
        transform = GetComponent<RectTransform>();
        renderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
        SetObjectSize(renderer.bounds.size);
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
