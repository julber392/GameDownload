using UnityEngine;
using UnityEngine.EventSystems;
public class UIItem : MonoBehaviour, IDragHandler,IBeginDragHandler,IEndDragHandler
{
    private CanvasGroup _canvasGroup;
    private RectTransform _rectTransform;
    private Canvas _canvas;
    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvas = GetComponentInParent<Canvas>();
        _canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta/(_canvas.scaleFactor*1.35f);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        var backGroundSlotTransform = _rectTransform.parent;
        backGroundSlotTransform.SetAsLastSibling();
        _canvasGroup.blocksRaycasts = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.localPosition = Vector3.zero;
        _canvasGroup.blocksRaycasts = true;
    }
}
