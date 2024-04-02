using UnityEngine;
using UnityEngine.EventSystems;

public class UISlot : MonoBehaviour,IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        var itemTransform = eventData.pointerDrag.transform;
        itemTransform.SetParent(transform);
        itemTransform.localPosition = Vector3.zero;
    }
}
