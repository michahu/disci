using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler {

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("DROP FIRE");

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (d != null)
        {
            d.returnParent = this.transform;
        }

        Card c = eventData.pointerDrag.GetComponent<CardUI>().card;
        if (c != null)
        {
            c.onPlay();
        }
    }
}
