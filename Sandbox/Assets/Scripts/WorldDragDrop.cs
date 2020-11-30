using UnityEngine;

public class WorldDragDrop : MonoBehaviour
{
    private bool isDragging = false;
    private float startX;
    private float startY;
    private SpriteRenderer _renderer;

    private void Awake()
    {
        // gameObject here is a pfItemWorld prefab
        _renderer = GetComponent<SpriteRenderer>();
    }

    public void OnMouseDown()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        startX = mousePos.x - transform.localPosition.x;
        startY = mousePos.y - transform.localPosition.y;
        SetIsDragging(true);
    }

    public void OnMouseUp()
    {
        SetIsDragging(false);
    }

    private void Update()
    {
        if (isDragging)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(new Vector3(mousePos.x - startX, mousePos.y - startY, 0));
        }
    }

    public void SetRendererAlpha(float alpha)
    {
        Color color = _renderer.color;
        color.a = alpha;
        _renderer.color = color;
    }

    public void SetIsDragging(bool dragging)
    {
        isDragging = dragging;
        SetRendererAlpha(dragging ? 0.6f : 1f);
    }
}
