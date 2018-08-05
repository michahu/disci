using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // Vector3 origin;
    public Transform returnParent;

    public void OnBeginDrag(PointerEventData eventData)
    {
        returnParent = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);
        // origin = transform.position;
        // Debug.Log("BEGIN DRAG");

        GetComponent<CanvasGroup>().blocksRaycasts = false;
        Debug.Log("BLOCKING RAYCAST: " + GetComponent<CanvasGroup>().blocksRaycasts);
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.SetParent(returnParent);
        // transform.position = origin;
        // Debug.Log("END DRAG");

        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
