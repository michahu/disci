using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Vector3 origin;

    public void OnBeginDrag(PointerEventData eventData)
    {
        origin = transform.position;
        Debug.Log("BEGIN DRAG");
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // transform.position = origin;
        Debug.Log("END DRAG");
    }
}
