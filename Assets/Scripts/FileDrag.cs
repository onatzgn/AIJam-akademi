using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Transform parentAfterDrag;
    private Vector3 startPosition;
    private Vector3 offset;
    public RectTransform dragArea;
    private Vector2 minBounds;
    private Vector2 maxBounds;

    private void Start()
    {
        if (dragArea != null)
        {
            minBounds = dragArea.rect.min;
            maxBounds = dragArea.rect.max;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPosition = transform.position; 
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();

        Vector3 worldPoint;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(
            transform as RectTransform, eventData.position, eventData.pressEventCamera, out worldPoint);
        offset = transform.position - worldPoint;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 worldPoint;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(
            transform as RectTransform, eventData.position, eventData.pressEventCamera, out worldPoint);
        Vector3 newPos = worldPoint + offset;

        if (dragArea != null)
        {
            RectTransform rt = transform as RectTransform;
            Vector3[] corners = new Vector3[4];
            rt.GetWorldCorners(corners);

            float minX = dragArea.position.x + minBounds.x + (rt.rect.width / 2);
            float maxX = dragArea.position.x + maxBounds.x - (rt.rect.width / 2);
            float minY = dragArea.position.y + minBounds.y + (rt.rect.height / 2);
            float maxY = dragArea.position.y + maxBounds.y - (rt.rect.height / 2);

            newPos.x = Mathf.Clamp(newPos.x, minX, maxX);
            newPos.y = Mathf.Clamp(newPos.y, minY, maxY);
        }

        transform.position = newPos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);

        
        Collider2D hitCollider = Physics2D.OverlapPoint(transform.position);
        if (hitCollider != null && hitCollider.CompareTag("Trash"))
        {
            Destroy(gameObject);
        }
        else 
        {
            transform.position = startPosition;
        }
    }
}
