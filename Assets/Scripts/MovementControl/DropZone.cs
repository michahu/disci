using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler {

    public void OnDrop(PointerEventData eventData)
    {
        // Debug.Log("DROP FIRE");

        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        Card c = eventData.pointerDrag.GetComponent<CardHelper>().card;

        if (d != null && c.manaCost <= PlayerStats.playerStatsInstance.currentMana)
        {
            d.returnParent = this.transform;

            if (c != null)
            {
                c.onPlay();
            }
        }

       
    } 

    public void OnCombatEnd()
    {
        foreach (Transform t in this.transform)
        {
            t.transform.SetParent(Deck.deckInstance.transform);
        }
    }
}
