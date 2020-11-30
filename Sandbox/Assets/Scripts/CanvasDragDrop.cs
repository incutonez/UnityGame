using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Canvas Render Mode:
/// Screen Space - Overlay... all UI elements will be rendered in front of any other game objects
/// Screen Space - Camera... if UI element is closer to camera, it will be rendered in front of game objects, and vice versa
///   This gets determined by the plane distance
/// World Space... this makes the UI elements behave like a game object, so they won't be static, like Screen Space - Camera
/// </summary>
public class CanvasDragDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private Vector3 startPos;
    private CanvasGroup canvasGroup;
    private float scaleFactor;
    private RectTransform _transform;

    private void Awake()
    {
        canvasGroup = FindObjectOfType<CanvasGroup>();
        scaleFactor = FindObjectOfType<Canvas>().scaleFactor;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPos = transform.position;
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }
}
