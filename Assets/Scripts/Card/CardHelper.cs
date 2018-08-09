using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// may be temporary. 

public class CardHelper : MonoBehaviour, IPointerClickHandler{

    public Card card;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(this.gameObject.ToString());
        this.gameObject.GetComponentInParent<ShopManager>().Buy(this.gameObject);
    }
}
