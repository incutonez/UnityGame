using UnityEngine;

public class SetRectSize : MonoBehaviour
{
    private new RectTransform transform;
    private new SpriteRenderer renderer;

    private void Awake()
    {
        transform = GetComponent<RectTransform>();
        renderer = GetComponent<SpriteRenderer>();
        SetTransformSize(renderer.bounds.size);
    }

    public void SetTransformSize(Vector3 size)
    {
        transform.sizeDelta = size;
    }
}
